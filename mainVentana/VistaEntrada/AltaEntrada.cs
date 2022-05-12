using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.ViewModels.Entradas;
using Negocios;
using System.IO;
//using DesktopControl;

using iTextSharp.text;

using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Document = iTextSharp.text.Document;
using System.Windows.Input;
using Datos.Datosenti;

namespace mainVentana.VistaEntrada
{

    public partial class AltaEntrada : Form
    {
        //KunLibertad_DesktopControl Desk = new KunLibertad_DesktopControl();
        public AltaEntrada()
        {
            InitializeComponent();
        }

        private void AltaEntrada_Load(object sender, EventArgs e)
        {
            unidades.Text = "0";
            peso.Text = "0";
            bultos.Text = "0";
            //Desk.SpecialKeyButtons(false);
            llenaCampos();



            #region Autocompletar ref



            proveedor.AutoCompleteCustomSource = proveeList();
         
            


            #endregion
        }




        #region PASAR LAS FOTOS DEL FORMULARIO HIJO CAMARA AL FORMULARIO PADRE ALTENTRADA
        public void ejecutarfoto(System.Drawing.Image img)
        {

            if (pictureBox2.Image == null)
            {
                pictureBox2.Image = img;
            }
            else if (pictureBox3.Image == null)
            {
                pictureBox3.Image = img;
            }
            else if (pictureBox4.Image == null)
            {
                pictureBox4.Image = img;
            }
            else if (pictureBox5.Image == null)
            {
                pictureBox5.Image = img;
            }
            else if (pictureBox6.Image == null)
            {
                pictureBox6.Image = img;
            }
            else if (pictureBox7.Image == null)
            {
                pictureBox7.Image = img;
            }
            else if (pictureBox8.Image == null)
            {
                pictureBox8.Image = img;
            }
            else if (pictureBox9.Image == null)
            {
                pictureBox9.Image = img;
            }
            else if (pictureBox10.Image == null)
            {
                pictureBox10.Image = img;
            }
            else if (pictureBox11.Image == null)
            {
                pictureBox11.Image = img;
            }
            else if (pictureBox11.Image == null)
            {
                pictureBox11.Image = img;
            }
            else if (pictureBox12.Image == null)
            {
                pictureBox12.Image = img;
            }
            else if (pictureBox13.Image == null)
            {
                pictureBox13.Image = img;
            }
            else if (pictureBox14.Image == null)
            {
                pictureBox14.Image = img;
            }
            else if (pictureBox15.Image == null)
            {
                pictureBox15.Image = img;
            }

        }
        

        private void iconButton2_Click(object sender, EventArgs e) //lo utiliazmos para pasar las imagenes del form camara al forma alta de entrada <Tiene que conectarse con CAM2>
        {
           
            
        }
        #endregion

        private void pictureBox2_DoubleClick(object sender, EventArgs e) // Alimina con doble clicl las fotos seleccionadas, configura el PictureBox a null, para volver a ser utilizado
        {
            PictureBox pic = (PictureBox)sender;
            pic.Image = null;
        }

        


        private void iconButton1_Click(object sender, EventArgs e)
        {
            ValidacionEntradas validacion = new ValidacionEntradas();   

            if (validacion.validacampo(sucEntrada.Text,sucDestino.Text,tipoOper.Text,cord.Text,cliente.Text,proveedor.Text,ordenCompra.Text,numFlete.Text,unidades.Text,peso.Text,bultos.Text,detalles.Text) == true)
            {
                impirmepdf();
            }
            
            

            


        }

        private void impirmepdf()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}" + ".pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));



            //string PaginaHTML_Texto = "<table border=\"1\"><tr><td>HOLA MUNDO</td></tr></table>";
            string PaginaHTML_Texto = Properties.Resources.Plantilla.ToString();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CLIENTE", sucEntrada.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOCUMENTO", sucDestino.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

            //string filas = string.Empty;
            //decimal total = 0;
            //foreach (DataGridViewRow row in dgvproductos.Rows)
            //{
            //    filas += "<tr>";
            //    filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
            //    filas += "<td>" + row.Cells["Descripcion"].Value.ToString() + "</td>";
            //    filas += "<td>" + row.Cells["PrecioUnitario"].Value.ToString() + "</td>";
            //    filas += "<td>" + row.Cells["Importe"].Value.ToString() + "</td>";
            //    filas += "</tr>";
            //    total += decimal.Parse(row.Cells["Importe"].Value.ToString());
            //}
            //PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
            //PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TOTAL", total.ToString());



            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    //Creamos un nuevo documento y lo definimos como PDF
                    Document pdfDoc = new Document(PageSize.A5, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    //Agregamos la imagen del banner al documento
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.arniacolor, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(60, 60);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;

                    //img.SetAbsolutePosition(10,100);
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    pdfDoc.Add(img);


                    //pdfDoc.Add(new Phrase("Hola Mundo"));
                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }

            }
        }

        private void AltaEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

      



        private void llenaCampos()
        {
            try
            {
                validacionesdatos datos = new validacionesdatos();
                var lst1 = datos.llenaCord();
                cord.DisplayMember = "C3";
                cord.DataSource = lst1;



                var lst2 = datos.llenaSuc();

                sucEntrada.DisplayMember = "C2";
                sucEntrada.ValueMember = "C1";
                sucEntrada.DataSource = lst2;

                var lst3 = datos.llenaSuc();

                sucDestino.DisplayMember = "C2";
                sucDestino.ValueMember = "C1";
                sucDestino.DataSource = lst3;

                var lst4 = datos.llenaProveedores();

                proveedor.DisplayMember = "C3";
                proveedor.ValueMember = "C2";
                proveedor.DataSource = lst4;

               
               

            }
            catch (Exception)
            {

                throw;
            }
            
        }


        #region //funciones para autocompletar
        private AutoCompleteStringCollection proveeList()
        {
            AutoCompleteStringCollection List = new AutoCompleteStringCollection();
            validacionesdatos datos = new validacionesdatos();
            var lst = datos.llenaProveedores();

            foreach (var p in lst)
            {
                List.Add(p.c3);
            }


            return List;
        }
       
        

        #endregion



        private void label21_Click(object sender, EventArgs e)
        {

        }

        

        


        private void gunaTileButton1_Click(object sender, EventArgs e) //abre el formulario de busqueda con datos de cliente
        {
            VistaEntrada.BusquedasEnt buscador = new BusquedasEnt();
            buscador.label2.Text = "CLIENTE";
            buscador.pasado += new BusquedasEnt.pasar(moverinfo);
            buscador.ShowDialog();
        }

        public void moverinfo(string dato, int bandera) //cambia los datos de los textbox alias y clientes, la bandera dependera de la manera en la que se haya abierto el frm buscar, 0 clientes 1 alias
        {
            
            if(bandera == 0)
            {
                cliente.Text = dato;
            }
            else if(bandera == 1)
            {
                alias.Text = dato;
            }
        }

        private void gunaTileButton2_Click(object sender, EventArgs e) //abre el formulario de busqueda con datos de alias
        {
            VistaEntrada.BusquedasEnt buscador = new BusquedasEnt();
            buscador.label2.Text = "ALIAS";
            buscador.pasado += new BusquedasEnt.pasar(moverinfo);
            buscador.ShowDialog();
        }
    }
}
