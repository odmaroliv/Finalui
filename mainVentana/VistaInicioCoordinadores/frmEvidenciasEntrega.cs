using Datos.ViewModels;
using Datos.ViewModels.Coord;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            Aldatagrid();
        }

        private void Aldatagrid()
        {
            if (String.IsNullOrWhiteSpace(_codigoBee))
            {
                MessageBox.Show("Error");
                return;
            }
            string auth = _codigoBee.Trim();
            string idprod = _dtoCompleto ?? _dtoCompleto.Trim();
            string sURL = $"https://app.beetrack.com/api/external/v1/dispatches/{idprod}?evaluations=true";

            // Limpiar los controles PictureBox existentes antes de agregar nuevos
            flowLayoutPanel1.Controls.Clear();

            try
            {
                using (var client = new RestClient(sURL))
                {
                    var request = new RestRequest("", Method.Get);
                    request.AddHeader("X-AUTH-TOKEN", auth);
                    var response = client.Execute(request);

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
                        // No se encontraron evaluaciones o la respuesta fue nula
                        // Realiza la lógica correspondiente o muestra un mensaje de error si es necesario
                    }
                }
            }
            catch (Exception)
            {
                // Agrega un manejo de errores más detallado aquí
                throw;
            }
        }

        private void LoadEvaluationAnswers(Dispatch ispatch)
        {
            foreach (var answer in ispatch.evaluation_answers)
            {
                if ( answer.cast == "photo")
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
            pb.Size = new Size((int)(pb.Width * 2.5), (int)(pb.Height * 2.5));
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
            using (frmComprobanteEntImp rp = new frmComprobanteEntImp())
            {
                rp.nArnian = datosEntrada.identifier.ToString();
                rp.recibio = datosEntrada.evaluation_answers[2].value ?? datosEntrada.evaluation_answers[2].value.ToString();
                // Obtén la imagen del PictureBox pbxFirma
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
