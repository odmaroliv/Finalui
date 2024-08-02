using Datos.ViewModels;
using Datos.ViewModels.Coord;
using GMap.NET.MapProviders;
using GMap.NET;
using Guna.UI.WinForms;
using mainVentana.Reportes.Entrega;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Negocios.NGBill;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Crmf;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms;

namespace mainVentana.VistaInicioCoordinadores
{
    public partial class frmEvidenciasEntrega : Form
    {

        private string sucursal = "SD";
        private string _dtoCompleto = "";
        private string _codigoBee;
        Dispatch datosEntrada;
        public frmEvidenciasEntrega()
        {
            InitializeComponent();
            try
            {
               
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            Aldatagrid();
        }

        private void LimpiaDatos()
        {
            lblEnt.Text = "";
            lblRecibe.Text = "";
            flowLayoutPanel1.Controls.Clear();
            pbxFirma.Image = null;
         
            _dtoCompleto = "";


        }

        private void Aldatagrid()
        {
            if (String.IsNullOrWhiteSpace(_codigoBee))
            {
                LimpiaDatos();
                MessageBox.Show("Error");
                return;
            }
            string auth = _codigoBee.Trim();
            string idprod = _dtoCompleto ?? _dtoCompleto.Trim();
            string sURL = $"https://arniangroup.dispatchtrack.com/api/external/v1/dispatches/{idprod}?evaluations=true";

            // Limpiar los controles PictureBox existentes antes de agregar nuevos
            flowLayoutPanel1.Controls.Clear();

            try
            {
                using (var client = new RestClient(sURL))
                {
                    var request = new RestRequest("", Method.Get);
                    request.AddHeader("X-AUTH-TOKEN", auth);
                    var response = client.Execute(request);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        vmResponceBeeEnt myResponse = JsonConvert.DeserializeObject<vmResponceBeeEnt>(response.Content);
                        List<Dispatch> myList = new List<Dispatch>();
                        Dispatch ispatch = myResponse.response;
                        //myList.Add(myResponse.response);
                        //  gunaDataGridView1.DataSource = myList;
                        datosEntrada = ispatch;
                        lblEnt.Text = ispatch.identifier.ToString();
                        lblRecibe.Text = ispatch.evaluation_answers[2].value ?? ispatch.evaluation_answers[2].value.ToString();


                        if (ispatch != null && ispatch.evaluation_answers != null)
                        {
                            LoadEvaluationAnswers(ispatch);
                        }
                        else
                        {
                            LimpiaDatos();
                        }
                    
                    }
                    else
                    {
                        LimpiaDatos();
                    }

                }
            }
            catch (Exception)
            {
                LimpiaDatos();
                throw;
            }
        }
        
        private void LoadEvaluationAnswers(Dispatch ispatch)
        {
            foreach (var answer in ispatch.evaluation_answers)
            {
                if (answer.cast == "photo")
                {
                    string[] imageUrls = answer.value.Split(',');
                    foreach (string imageUrl in imageUrls)
                    {
                        CreatePictureBox(imageUrl.Trim());
                    }
                }
                if (answer.cast == "signature")
                {
                    string[] imageUrls = answer.value.Split(',');
                    foreach (string imageUrl in imageUrls)
                    {
                        CreatePictureSignature(imageUrl.Trim());
                    }
                }


            }







        }
       




        private void CreatePictureBox(string imageUrl)
        {
            PictureBox pb = new PictureBox();
            pb.Load(imageUrl);

            pb.Size = new Size(200, 200); // Define el tamaño del PictureBox
            pb.SizeMode = PictureBoxSizeMode.Zoom; // Adapta la imagen al tamaño del PictureBox

            // Guarda el tamaño original en la propiedad Tag para usarlo más tarde
            pb.Tag = pb.Size;

            // Añade los manejadores de eventos
            pb.MouseEnter += Pb_MouseEnter;
            pb.MouseLeave += Pb_MouseLeave;

            flowLayoutPanel1.Controls.Add(pb); // Añade el PictureBox al FlowLayoutPanel
        }

        private void CreatePictureSignature(string imageUrl)
        {
        
            pbxFirma.Load(imageUrl);

            pbxFirma.Size = new Size(200, 200); 
            pbxFirma.SizeMode = PictureBoxSizeMode.Zoom; // Adapta la imagen al tamaño del PictureBox

           
            pbxFirma.Tag = pbxFirma.Size;

            // Añade los manejadores de eventos
            pbxFirma.MouseEnter += Pb_MouseEnter;
            pbxFirma.MouseLeave += Pb_MouseLeave;

          
        }

        private void Pb_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.Size = new Size((int)(pb.Width * 1.0), (int)(pb.Height * 1.0));
        }

        private void Pb_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.Size = (Size)pb.Tag; // Restaura el tamaño original
        }

        private async  void frmEvidenciasEntrega_Load(object sender, EventArgs e)
        {
            BusquedaBill dt = new BusquedaBill();
            
                _codigoBee = await dt.BeetrackCode();
            
        }



        private void rSd_CheckedChanged_1(object sender, EventArgs e)
        {
            var radioButtonMapping = new Dictionary<RadioButton, string>
                {
        { rSd, "SD" },
        { rTj, "TJ" },
        { rCa, "CSL" },

                 };

            // Encontrar el RadioButton seleccionado y obtener su valor correspondiente
            sucursal = radioButtonMapping.FirstOrDefault(r => r.Key.Checked).Value;
        }

        private void txbBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrWhiteSpace(txbBuscar.Text))
                {
                    return;
                }
                try
                {
                    e.Handled = true;
                    ValidabPrincipal();
                    //  _billBuscado = Convert.ToInt32(txbBuscar.Text);
                    //buscaEntradasEnBill();
                    Aldatagrid();
                }
                catch (Exception)
                {
                    MessageBox.Show("Solo se permiten numeros");
                }
            }


        }


        private void ValidabPrincipal()
        {
            if (txbBuscar.Text == "") 
            {
                MessageBox.Show("El campo de busqueda esta vacio!");
                return;
            }
            int datparseado;
            string numer = "";
            bool bent = Int32.TryParse(txbBuscar.Text, out datparseado);
            if (bent == true)
            {
                numer = datparseado.ToString("D7");
                txbBuscar.Text = numer;
                _dtoCompleto = sucursal.Trim() + "-" + numer;
            }
            else
            {
                MessageBox.Show("Las entradas tienen que ser un codigo numerico, y no pueden contener letras");
                return;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(_dtoCompleto))
            {
                MessageBox.Show("No puedes imprimir");
                return;
            }
            using (frmComprobanteEntImp rp = new frmComprobanteEntImp())
            {
                rp.clienteParam = datosEntrada.contact_name;
                rp.nArnian = datosEntrada.identifier.ToString();
                rp.recibio = datosEntrada.evaluation_answers[2].value ?? datosEntrada.evaluation_answers[2].value.ToString();
                // Asume que datosEntrada.arrived_at es una cadena en formato ISO 8601
                string arrivedAtUtc = datosEntrada.arrived_at;

                // Convierte la cadena a DateTime
                DateTime arrivedAtDateTimeUtc = DateTime.Parse(arrivedAtUtc, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);

                // Convierte la DateTime a una cadena y almacénala en rp.fechaEntrega
                rp.fechaEntrega = arrivedAtDateTimeUtc.ToString("MM/dd/yyyy HH:mm");

                rp.cordsEnt = datosEntrada.latitude + "," + datosEntrada.longitude;

                if (pbxFirma.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pbxFirma.Image.Save(ms, pbxFirma.Image.RawFormat);
                        rp.imgSignature = ms.ToArray();
                    }
                }
                else
                {
                    return;
                }
               

                // Abre el formulario rp
                rp.ShowDialog();
            }
        }
    }
}
