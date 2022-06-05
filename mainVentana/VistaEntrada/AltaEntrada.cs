using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.ViewModels.Entradas;
using Negocios;
using System.IO;
//using DesktopControl;
using Datos.ViewModels.Entradas.mvlistas;
using iTextSharp.text;

using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Document = iTextSharp.text.Document;
using System.Windows.Input;
using Datos.Datosenti;
using Datos.ViewModels;
using Datos.ViewModels.Servicios;
using Newtonsoft.Json;
using mainVentana.Email;
using Negocios.Common.Cache;

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
            unidades.Text = "";
            bultos.Text = "";
            peso.Text = "";
            //Desk.SpecialKeyButtons(false);
            llenaCampos();



            #region Autocompletar ref



            proveedor.AutoCompleteCustomSource = proveeList();

            coloresSucursales();


            #endregion
        }




        #region PASAR LAS FOTOS DEL FORMULARIO HIJO CAMARA AL FORMULARIO PADRE ALTENTRADA
        public void ejecutarfoto(System.Drawing.Image img, string ruta)
        {
            using (img)
            {
                if (pictureBox2.Image == null)
                {
                    pictureBox2.Image = (System.Drawing.Image)img.Clone();
                    pictureBox2.ImageLocation = ruta;
                }
                else if (pictureBox3.Image == null)
                {
                    pictureBox3.Image = (System.Drawing.Image)img.Clone();
                    pictureBox3.ImageLocation = ruta;
                }
                else if (pictureBox4.Image == null)
                {
                    pictureBox4.Image = (System.Drawing.Image)img.Clone();
                    pictureBox4.ImageLocation = ruta;
                }
                else if (pictureBox5.Image == null)
                {
                    pictureBox5.Image = (System.Drawing.Image)img.Clone();
                    pictureBox5.ImageLocation = ruta;
                }
                else if (pictureBox6.Image == null)
                {
                    pictureBox6.Image = (System.Drawing.Image)img.Clone();
                    pictureBox6.ImageLocation = ruta;
                }
                else if (pictureBox7.Image == null)
                {
                    pictureBox7.Image = (System.Drawing.Image)img.Clone();
                    pictureBox7.ImageLocation = ruta;
                }
                else if (pictureBox8.Image == null)
                {
                    pictureBox8.Image = (System.Drawing.Image)img.Clone();
                    pictureBox8.ImageLocation = ruta;
                }
                else if (pictureBox9.Image == null)
                {
                    pictureBox9.Image = (System.Drawing.Image)img.Clone();
                    pictureBox9.ImageLocation = ruta;
                }
                else if (pictureBox10.Image == null)
                {
                    pictureBox10.Image = (System.Drawing.Image)img.Clone();
                    pictureBox10.ImageLocation = ruta;
                }
                else if (pictureBox11.Image == null)
                {
                    pictureBox11.Image = (System.Drawing.Image)img.Clone();
                    pictureBox11.ImageLocation = ruta;
                }
                else if (pictureBox12.Image == null)
                {
                    pictureBox12.Image = (System.Drawing.Image)img.Clone();
                    pictureBox12.ImageLocation = ruta;
                }
                else if (pictureBox13.Image == null)
                {
                    pictureBox13.Image = (System.Drawing.Image)img.Clone();
                    pictureBox13.ImageLocation = ruta;
                }
                else if (pictureBox14.Image == null)
                {
                    pictureBox14.Image = (System.Drawing.Image)img.Clone();
                    pictureBox14.ImageLocation = ruta;
                }
                else if (pictureBox15.Image == null)
                {
                    pictureBox15.Image = (System.Drawing.Image)img.Clone();
                    pictureBox15.ImageLocation = ruta;
                }
            }




        }


        private void iconButton2_Click(object sender, EventArgs e) //lo utiliazmos para pasar las imagenes del form camara al forma alta de entrada <Tiene que conectarse con CAM2>
        {
            string[] imagen;

             
            openFileDialog1.Multiselect = true;
            openFileDialog1.InitialDirectory = "@C:\\";
            openFileDialog1.Filter = "Solo imagenes (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF"; ;



            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imagen = openFileDialog1.FileNames;

                    foreach (var i in imagen)
                    {
                        ejecutarfoto(System.Drawing.Image.FromFile(i), i.ToString());
                        openFileDialog1.Dispose();
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
        List<string> mnd = new List<string>();
        private void creaListadeFotos()
        {
            mnd.Clear();
            if (pictureBox2.Image != null)
            {
                mnd.Add(pictureBox2.ImageLocation);
            }

            if (pictureBox3.Image != null)
            {
                mnd.Add(pictureBox3.ImageLocation);
            }

            if (pictureBox4.Image != null)
            {
                mnd.Add(pictureBox4.ImageLocation);
            }

            if (pictureBox5.Image != null)
            {
                mnd.Add(pictureBox5.ImageLocation);
            }
            if (pictureBox6.Image != null)
            {
                mnd.Add(pictureBox6.ImageLocation);
            }
            if (pictureBox7.Image != null)
            {
                mnd.Add(pictureBox7.ImageLocation);
            }
            if (pictureBox8.Image != null)
            {
                mnd.Add(pictureBox8.ImageLocation);
            }
            if (pictureBox9.Image != null)
            {
                mnd.Add(pictureBox9.ImageLocation);
            }
            if (pictureBox10.Image != null)
            {
                mnd.Add(pictureBox10.ImageLocation);
            }
            if (pictureBox11.Image != null)
            {
                mnd.Add(pictureBox11.ImageLocation);
            }
            if (pictureBox12.Image != null)
            {
                mnd.Add(pictureBox12.ImageLocation);
            }
            if (pictureBox13.Image != null)
            {
                mnd.Add(pictureBox13.ImageLocation);
            }
            if (pictureBox14.Image != null)
            {
                mnd.Add(pictureBox14.ImageLocation);
            }
            if (pictureBox15.Image != null)
            {
                mnd.Add(pictureBox15.ImageLocation);
            }

        }

        List<vmListaFotos> lstFotos = new List<vmListaFotos>();
        private void creaListadepARAMSFotos()
        {
            lstFotos.Clear();
            if (pictureBox2.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox2.ImageLocation);



                lstFotos.Add(new vmListaFotos { documento = pictureBox2.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim()+"-"+datoEntrada + "-1", realnombre = filename, bytedocumto = imgbyte(pictureBox2.ImageLocation, pictureBox2.Image),sucursal = sucEntrada.SelectedValue.ToString() , tipo = "Imagen"});
            }

            if (pictureBox3.Image != null)
            {

                string filename = null;
                filename = Path.GetFileName(pictureBox3.ImageLocation);

                lstFotos.Add(new vmListaFotos { documento = pictureBox3.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim()+"-"+datoEntrada + "-2", realnombre = filename, bytedocumto = imgbyte(pictureBox3.ImageLocation, pictureBox3.Image), sucursal = sucEntrada.SelectedValue.ToString() , tipo = "Imagen" });
            }

            if (pictureBox4.Image != null)
            {


                string filename = null;
                filename = Path.GetFileName(pictureBox4.ImageLocation);

                lstFotos.Add(new vmListaFotos { documento = pictureBox4.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim()+"-"+datoEntrada + "-3", realnombre = filename, bytedocumto = imgbyte(pictureBox4.ImageLocation, pictureBox4.Image), sucursal = sucEntrada.SelectedValue.ToString() , tipo = "Imagen" });
            }

            if (pictureBox5.Image != null)
            { 

                string filename = null;
                filename = Path.GetFileName(pictureBox5.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox5.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim()+"-"+datoEntrada + "-4", realnombre = filename, bytedocumto = imgbyte(pictureBox5.ImageLocation, pictureBox5.Image), sucursal = sucEntrada.SelectedValue.ToString() , tipo = "Imagen"  });

            }
            if (pictureBox6.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox6.ImageLocation);

                lstFotos.Add(new vmListaFotos { documento = pictureBox6.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim()+"-"+datoEntrada + "-5", realnombre = filename, bytedocumto = imgbyte(pictureBox6.ImageLocation, pictureBox6.Image), sucursal = sucEntrada.SelectedValue.ToString() , tipo = "Imagen" });

            }
            if (pictureBox7.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox7.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox7.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim()+"-"+datoEntrada + "-6", realnombre = filename, bytedocumto = imgbyte(pictureBox7.ImageLocation, pictureBox7.Image) , sucursal = sucEntrada.SelectedValue.ToString() , tipo = "Imagen" });
            }
            if (pictureBox8.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox8.ImageLocation);

                lstFotos.Add(new vmListaFotos { documento = pictureBox8.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim()+"-"+datoEntrada + "-7", realnombre = filename, bytedocumto = imgbyte(pictureBox8.ImageLocation, pictureBox8.Image) , sucursal = sucEntrada.SelectedValue.ToString() , tipo = "Imagen" });
            }
            if (pictureBox9.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox9.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox9.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim()+"-"+datoEntrada + "-8", realnombre = filename, bytedocumto = imgbyte(pictureBox9.ImageLocation, pictureBox9.Image) , sucursal = sucEntrada.SelectedValue.ToString() , tipo = "Imagen" });
            }
            if (pictureBox10.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox10.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox10.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim()+"-"+datoEntrada + "-9", realnombre = filename, bytedocumto = imgbyte(pictureBox10.ImageLocation, pictureBox10.Image) , sucursal = sucEntrada.SelectedValue.ToString() , tipo = "Imagen" });
            }
            if (pictureBox11.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox11.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox11.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim()+"-"+datoEntrada + "-10", realnombre = filename, bytedocumto = imgbyte(pictureBox11.ImageLocation, pictureBox11.Image) , sucursal = sucEntrada.SelectedValue.ToString() , tipo = "Imagen" });
            }
            if (pictureBox12.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox12.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox12.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim()+"-"+datoEntrada + "-11", realnombre = filename, bytedocumto = imgbyte(pictureBox12.ImageLocation, pictureBox12.Image)   , sucursal = sucEntrada.SelectedValue.ToString() , tipo = "Imagen" });
            }
            if (pictureBox13.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox13.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox13.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim()+"-"+datoEntrada + "-12", realnombre = filename, bytedocumto = imgbyte(pictureBox13.ImageLocation, pictureBox13.Image) , sucursal = sucEntrada.SelectedValue.ToString() , tipo = "Imagen" });
            }
            if (pictureBox14.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox14.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox14.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim()+"-"+datoEntrada + "-13", realnombre = filename, bytedocumto = imgbyte(pictureBox14.ImageLocation, pictureBox14.Image) , sucursal = sucEntrada.SelectedValue.ToString() , tipo = "Imagen" });
            }
            if (pictureBox15.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox15.ImageLocation);

                lstFotos.Add(new vmListaFotos { documento = pictureBox15.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim()+"-"+datoEntrada + "-14", realnombre = filename, bytedocumto = imgbyte(pictureBox15.ImageLocation, pictureBox15.Image) , sucursal = sucEntrada.SelectedValue.ToString() , tipo = "Imagen" });
            }
            
        }
        private void AgregaArchivoslist()
        {
           
                
                if (label27.Text != null && label27.Text != "")
                {
                    string filename = null;
                    filename = Path.GetFileName(label27.Text);



                    lstFotos.Add(new vmListaFotos { documento = label27.Text, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-1", realnombre = filename, bytedocumto = docbyte(label27.Text), sucursal = sucEntrada.SelectedValue.ToString() ,tipo = "Doc" });
                }

                if (label28.Text != null && label28.Text != "")
                {

                    string filename = null;
                    filename = Path.GetFileName(label28.Text);

                    lstFotos.Add(new vmListaFotos { documento = label28.Text, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-2", realnombre = filename, bytedocumto = docbyte(label28.Text), sucursal = sucEntrada.SelectedValue.ToString() ,tipo = "Doc" });
                }
            }

        #endregion

        private void pictureBox2_DoubleClick(object sender, EventArgs e) // Alimina con doble clicl las fotos seleccionadas, configura el PictureBox a null, para volver a ser utilizado
        {
            PictureBox pic = (PictureBox)sender;
            pic.Image = null;
        }




        private void Guardar_Click(object sender, EventArgs e) //Click al boton guardar
        {

            ValidacionEntradas validacion = new ValidacionEntradas();

            if (validacion.validacampo(sucEntrada.Text, sucDestino.Text, tipoOper.Text, cord.Text, cliente.Text, proveedor.Text, ordenCompra.Text, numFlete.Text, unidades.Text, bultos.Text, peso.Text, detalles.Text) == true)
            {

                creaListadeFotos();
                AgregaArchivos();
                altaKDM1();
                altaKDM1coment();
                SubeFotos();
                
                CreaEriquetas();
                envEmail();
                limpiaImg();
                

                cargaultent();
            }

        }
        string datoEntrada; //variable global de entrada cuando se click al boton de guardar ---------------------------------------
        private void altaKDM1()
        {
            AltasBD bd = new AltasBD();

            string datoSucIni = sucEntrada.SelectedValue.ToString();
            datoEntrada = recuperUltimaent();
            string datoMoneda = cmbMoneda.GetItemText(cmbMoneda.SelectedItem).ToString();
            DateTime datoFecha = regresafecha();
            string datoNuCliente = lblCodCliente.Text; // agregar numero de cliente
            string datoNoCord = cord.SelectedValue.ToString();
            string datoValArn = txbValArn.Text;
            string datoNomCliente = cliente.Text;
            string datoCalle = label23.Text;
            string datoColonia = label24.Text;
            string datoCiudadZip = label25.Text;
            string datoValFact = txbValFact.Text;
            string datoParidad = lblParidad.Text;
            string datoNoTrakin = tbxRastreo.Text;
            string datoProvedor = proveedor.SelectedValue.ToString();
            string datoOrdCompra = ordenCompra.Text;
            string datoNoFlete = numFlete.Text;
            string datoNoUnidades = unidades.Text;
            string datoTipoUnidad = cmbUnidades.GetItemText(cmbUnidades.SelectedItem).ToString();
            string datoPeso = peso.Text;
            string datoUnidadMedida = cmbPeso.SelectedValue.ToString();
            string datoTipoOper = tipoOper.SelectedValue.ToString();
            string datoSucDestino = sucDestino.SelectedValue.ToString();
            string datoBultos = bultos.Text;
            string datosAlias = alias.Text;


            bd.agregaKDM1(datoSucIni, datoEntrada, datoMoneda, datoFecha, datoNuCliente, datoNoCord, datoValArn, datoNomCliente, datoCalle, datoColonia, datoCiudadZip,
            datoValFact, datoParidad, datoNoTrakin, datoProvedor, datoOrdCompra, datoNoFlete, datoNoUnidades, datoTipoUnidad, datoPeso, datoUnidadMedida, datoTipoOper,
            datoSucDestino, datoBultos, datosAlias);

            actualizaKDMENT(datoSucIni, datoEntrada, datoBultos, datoSucDestino, datoFecha);

        }

        private void altaKDM1coment()
        {
            AltasBD bd = new AltasBD();

            string datoSucIni = sucEntrada.SelectedValue.ToString();
            string dtEntrada = datoEntrada;
            string datoMoneda = cmbMoneda.GetItemText(cmbMoneda.SelectedItem).ToString();
            DateTime datoFecha = regresafecha();
            string datoNuCliente = lblCodCliente.Text;
            string datoDetalles = detalles.Text;

            bd.agregaComentKDM1(datoSucIni, dtEntrada, datoMoneda, datoFecha, datoNuCliente, datoDetalles);


        }

        private void actualizaKDMENT(string datoSucIni, string datoEntrada, string datoBultos, string datoSucDestino, DateTime datoFecha)
        {
            string datoDetalles = detalles.Text;
            AltasBD bd = new AltasBD();
            for (int i = 1; i <= Convert.ToInt32(datoBultos); i++)
            {
                bd.agregaKDMENT(datoSucIni, datoEntrada, i.ToString(), datoSucIni.Trim() + "-UD3501-" + datoEntrada.Trim(), datoSucIni.Trim() + "-" + datoEntrada.Trim() + "-" + i.ToString(), datoSucDestino, datoSucIni.Trim(),
                datoDetalles.Length >= 100 ? datoDetalles.Substring(0, 100) : datoDetalles, datoFecha.ToString(), 0, 0, "OE");
            }




            //bd.agregaKDMENT();
        }
        private void envEmail()
        {
            EnviarEmail servicio = new EnviarEmail();
            var respuesta = servicio.EnviaMail(label41.Text, cliente.Text, tbxRastreo.Text, alias.Text, ordenCompra.Text, numFlete.Text, proveedor.Text, detalles.Text, mnd, larch, coreoClientes);
            if (respuesta == 1)
            {
                MessageBox.Show("El correo NO SE ENVIÓ PORQUE supera el límite máximo de 25 MB en cada correo, intenta borrar documentos y reenvía la notificación", "CUIDADO EL CORREO NO SE ENVIO");
                NotificaEmail(0, label41.Text, cliente.Text);
            }
            else
            {
                NotificaEmail(1, label41.Text, cliente.Text);
            }

        }

        private void CreaEriquetas()
        {
            int bulto = Convert.ToInt32(bultos.Text);

            impirmepdf();

        }
        private void impirmepdf()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}" + ".pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));
            var pgSize = new iTextSharp.text.Rectangle(288, 432);
            Document pdfDoc = new Document(pgSize, 25, 25, 25, 25);



            //string PaginaHTML_Texto = "<table border=\"1\"><tr><td>HOLA MUNDO</td></tr></table>";



            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    //Creamos un nuevo documento y lo definimos como PDF


                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    try
                    {
                        int bulto = Convert.ToInt32(bultos.Text);
                        for (int i = 1; i <= bulto; i++)
                        {
                            string PaginaHTML_Texto = Properties.Resources.Plantilla.ToString();
                            pdfDoc.NewPage();
                            pdfDoc.Add(new Phrase(""));
                            string etiqueta = sucEntrada.SelectedValue.ToString().Trim() + "-" + label41.Text + "-" + i.ToString();
                            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ORIGEN", sucEntrada.GetItemText(sucEntrada.SelectedItem).ToString().Trim());
                            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DESTINO", sucDestino.GetItemText(sucDestino.SelectedItem).ToString().Trim());
                            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ENTRADA", label41.Text);
                            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@OPERACION", tipoOper.GetItemText(tipoOper.SelectedItem).ToString());
                            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@PROVEEDOR", proveedor.GetItemText(proveedor.SelectedItem).ToString());
                            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CLIENTE", cliente.Text.ToString());
                            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ETIQUETA", etiqueta.ToString());

                            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                            System.Drawing.Image imge = b.Encode(BarcodeLib.TYPE.CODE128, etiqueta.ToString(), Color.Black, Color.White, 250, 40);
                            iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(imge, System.Drawing.Imaging.ImageFormat.Png);
                            img2.ScaleToFit(250, 40);
                            img2.Alignment = iTextSharp.text.Image.ALIGN_CENTER;

                            //img.SetAbsolutePosition(10,100);
                            img2.SetAbsolutePosition(20, 20);
                            pdfDoc.Add(img2);

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

                            //Agregamos la imagen del banner al documento
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.arniacolor, System.Drawing.Imaging.ImageFormat.Png);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;

                            //img.SetAbsolutePosition(10,100);
                            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                            pdfDoc.Add(img);
                            using (StringReader sr = new StringReader(PaginaHTML_Texto))
                            {
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            }

                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }


                    //pdfDoc.Add(new Phrase("Hola Mundo"));


                    pdfDoc.Close();
                    stream.Close();
                }

            }
        }

        private void SubeFotos()
        {

          /* foreach (var I in lstFotos)
            {
               MessageBox.Show(I.documento.ToString()+"------"+I.bytedocumto.ToString());
            }*/
            

            AltasBD bd = new AltasBD();
            creaListadepARAMSFotos();
            AgregaArchivoslist();
            bd.agregarFotos(lstFotos);
        }
        private byte[] imgbyte(string ruta, System.Drawing.Image picture)
        {
            byte[] file = null;
            vmListaFotos lsf = new vmListaFotos();
            //Stream fs = new FileStream(ruta, FileMode.Create);
            var img = picture;
           // img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                file = ms.ToArray();
            }
            return file;
            //picture.Dispose();
        }

        private byte[] docbyte(string ruta)
        {
            byte[] file = null;
            vmListaFotos lsf = new vmListaFotos();
            Stream fs = new FileStream(ruta, FileMode.Open);
            //var img = ruta;
            // img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            using (MemoryStream ms = new MemoryStream())
            {
                fs.CopyTo(ms);
                file = ms.ToArray();
                fs.Dispose();
            }
            return file;
            //picture.Dispose();
        }


        private void AltaEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {

        }





        private async void llenaCampos()
        {
            try
            {
                Servicios datos = new Servicios();
                var lst2 = datos.llenaSuc();

                sucEntrada.DisplayMember = "C2";
                sucEntrada.ValueMember = "C1";
                sucEntrada.DataSource = lst2;

                cargaultent();

                lblUser.Text = CacheLogin.username;

                var lst1 = await datos.llenaCord();
                cord.ValueMember = "C2";
                cord.DisplayMember = "C3";
                cord.DataSource = lst1;



                List<Sucursales> lst3 = new List<Sucursales>(lst2); //clonamos la lista anterior para no volver a hacer la busqueda en la base de datos 

                //var lst3 = sucEntrada.DataSource;
                sucDestino.DisplayMember = "C2";
                sucDestino.ValueMember = "C1";
                sucDestino.DataSource = lst3;

                var lst4 = datos.llenaProveedores();

                proveedor.DisplayMember = "C3";
                proveedor.ValueMember = "C2";
                proveedor.DataSource = lst4;

                var lst5 = await datos.llenaPieza();

                cmbUnidades.DisplayMember = "C2";
                cmbUnidades.ValueMember = "C1";
                cmbUnidades.DataSource = lst5;

                var lst6 = await datos.llenaPeso();

                cmbPeso.DisplayMember = "C2";
                cmbPeso.ValueMember = "C1";
                cmbPeso.DataSource = lst6;


                var lst7 = await datos.llenaOpera();

                tipoOper.DisplayMember = "C2";
                tipoOper.ValueMember = "C1";
                tipoOper.DataSource = lst7;

                //

                foreach (var i in await datos.generaRastreo())
                {
                    tbxRastreo.Text = i.c1.ToString();
                }

                var lst8 = await datos.llenaAlmacenes();

                cmbAlmacen.DisplayMember = "C2";
                cmbAlmacen.ValueMember = "C1";
                cmbAlmacen.DataSource = lst8;


                Cargaparidad();
                cargafecha();
                Moneda();






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
            Servicios datos = new Servicios();
            var lst = datos.llenaProveedores();

            foreach (var p in lst)
            {
                List.Add(p.c3);
            }


            return List;
        }



        #endregion



        private void gunaTileButton1_Click(object sender, EventArgs e) //abre el formulario de busqueda con datos de cliente
        {
            VistaEntrada.BusquedasEnt buscador = new BusquedasEnt();
            buscador.label2.Text = "CLIENTE";
            buscador.pasado += new BusquedasEnt.pasar(moverinfo);
            buscador.ShowDialog();
        }
        string coreoClientes;
        public void moverinfo(string dato, string dato2, string dato3, string dato4, string dato5, string dato6, string dato7, string correoCliente, int bandera) //cambia los datos de los textbox alias y clientes, la bandera dependera de la manera en la que se haya abierto el frm buscar, 0 clientes 1 alias, ADEMAS tambien sirve para cambiar el campo de cord
        {
            coreoClientes = correoCliente;
            if (bandera == 0) //clientes
            {
                cliente.Text = dato;
                alias.Text = dato2;
                label23.Text = dato4;
                label24.Text = dato5;
                label25.Text = dato6;
                label26.Text = "Dir Cliente";
                lblCodCliente.Text = dato7;

                foreach (vmCordinadores i in cord.Items)
                {
                    if (i.c2.Trim() == dato3)
                    {
                        cord.SelectedValue = i.c2;
                        break;

                    }

                }

            }
            else if (bandera == 1)//alias
            {
                alias.Text = dato;
                cliente.Text = dato2;
                label23.Text = dato4;
                label24.Text = dato5;
                label25.Text = dato6;
                label26.Text = "Dir Alias";
                lblCodCliente.Text = dato7;
                foreach (vmCordinadores i in cord.Items)
                {
                    if (i.c2.Trim() == dato3)
                    {
                        cord.SelectedValue = i.c2;
                        break;

                    }

                }
            }
        }


        private void gunaTileButton2_Click(object sender, EventArgs e) //abre el formulario de busqueda con datos de alias
        {
            VistaEntrada.BusquedasEnt buscador = new BusquedasEnt();
            buscador.label2.Text = "ALIAS";
            buscador.pasado += new BusquedasEnt.pasar(moverinfo);
            buscador.ShowDialog();
        }

        private void cliente_TextChanged(object sender, EventArgs e)
        {
            cord.Text = alias.Text;
        }

        private void proveedor_Leave(object sender, EventArgs e)
        {
            int bandera = 0;
            foreach (Proveedores d in proveedor.Items)
            {
                string dato = proveedor.Text.ToString().Trim();

                if (d.c3.Trim() == dato)
                {
                    bandera = 1;
                    break;
                }

            }
            if (bandera == 0)
            {
                MessageBox.Show("El proveedor que has ingresado es incorrecto por favor, busca y selecciona uno de los resultados.");
                proveedor.Focus();
            }
        }


        private void coloresSucursales()//cambia los coleres del control de seleccion de sucursales
        {

        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "@C:\\";
            openFileDialog1.Filter = "Solo documentos (PDF,WORD)|*.PDF;*.DOCX"; ;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string doc = openFileDialog1.FileName;
                    if (label27.Text == "")
                    {
                        label27.Text = doc;
                    }
                    else
                    {
                        label28.Text = doc;
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        List<string> larch = new List<string>();
        private void AgregaArchivos()
        {
            larch.Clear();
            if (label27.Text != "")
            {
                larch.Add(label27.Text);
            }
            if (label28.Text != "")
            {
                larch.Add(label28.Text);
            }


        }

        public async void Cargaparidad()
        {
            Servicio datos = new Servicio();
            string paridad1 = await datos.GetParidad();
            var lst = JsonConvert.DeserializeObject<Root>(paridad1);

            //var lst = JsonConvert.DeserializeObject<List<Paridad>>(paridad1);
            //Paridad lst = JsonConvert.DeserializeObject<ListParidad>>(paridad1);

            var lista = from d in lst.ListaIndicadores.Where(c => c.codTipoIndicador == 158)

                        select new ListaIndicadore
                        {
                            valor = d.valor

                        };

            foreach (var i in lista.ToList())
            {
                lblParidad.Text = i.valor.ToString();
            }


        }


        private async void cargafecha()
        {
            Servicio datos = new Servicio();
            string fecha1 = await datos.fechaLapaz();
            //List<FechaActual> lst = JsonConvert.DeserializeObject<List<FechaActual>>(paridad1);
            //var lst = JsonConvert.DeserializeObject<List<FechaActual>>(fecha1);
            FechaActual lst = JsonConvert.DeserializeObject<FechaActual>(fecha1);

            label40.Text = lst.datetime.Date.ToString("dd-MM-yyyy");

        }

        private DateTime regresafecha()
        {

            Servicio datos = new Servicio();
            string fecha1 = datos.retornafechaLapaz();

            FechaActual lst = JsonConvert.DeserializeObject<FechaActual>(fecha1);

            return lst.datetime;


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbMoneda.SelectedValue) == 1)
            {
                lblParidad.Text = "";
            }
            else if (Convert.ToInt32(cmbMoneda.SelectedValue) == 2)
            {
                Cargaparidad();
            }
        }




        private void gunaMediumRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gunaMediumRadioButton2.Enabled = false;
            gunaMediumRadioButton1.Enabled = true;
        }



        private void gunaMediumRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gunaMediumRadioButton1.Enabled = false;
        }

        private void gunaTileButton3_Click(object sender, EventArgs e)
        {

            if (gunaMediumRadioButton2.Checked == true)
            {
                MessageBox.Show("Para liberar una entrada primero tiene que estar pagada");
                return;

            }
            VistaEntrada.Desbloqueo buscador = new Desbloqueo();

            buscador.cambiar += new Desbloqueo.cambio(deledesbloqueo);
            buscador.ShowDialog();
        }

        public void deledesbloqueo(bool dato)
        {
            if (dato == true)
            {
                gunaMediumRadioButton2.Enabled = true;
            }
            else
            {
                gunaMediumRadioButton2.Enabled = false;
            }

        }

        private void Moneda()
        {
            List<Moneda> mnd = new List<Moneda> {
                new Moneda{id=2,moneda="DLLS"},
                new Moneda{id=1,moneda="PESOS"}};




            var lista = from d in mnd
                        select new Moneda
                        {
                            id = d.id,
                            moneda = d.moneda

                        };
            lista = lista.ToList();

            cmbMoneda.DisplayMember = "moneda";
            cmbMoneda.ValueMember = "id";
            cmbMoneda.DataSource = lista;

        }

        private void sucEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaultent();
        }
        private void cargaultent()
        {
            Servicios datos = new Servicios();

            foreach (var i in datos.NumeroEntrada(sucEntrada.SelectedValue.ToString()))
            {
                int numero = Convert.ToInt32(i.entrada) + 1;
                label41.Text = numero.ToString("D7");
            }
        }
        private string recuperUltimaent()
        {
            Servicios datos = new Servicios();
            string dato = default;
            foreach (var i in datos.NumeroEntrada(sucEntrada.SelectedValue.ToString()))
            {
                int numero = Convert.ToInt32(i.entrada) + 1;
                dato = numero.ToString("D7");
            }
            return dato;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            creaListadeFotos();
        }

        private void label28_DoubleClick(object sender, EventArgs e)
        {
            label28.Text = "";
        }

        private void label27_DoubleClick(object sender, EventArgs e)
        {
            label27.Text = "";
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            regresafecha();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            


        }
        public void limpiaImg()
        {

            if (pictureBox2.Image != null)
            {
                
                pictureBox2.Dispose();
                
            }
            if (pictureBox3.Image != null)
            {
                
                pictureBox3.Dispose();
            }
            if (pictureBox4.Image != null)
            {
                
                pictureBox4.Dispose();
            }
            if (pictureBox5.Image != null)
            {
                
                pictureBox5.Dispose();
            }
            if (pictureBox6.Image != null)
            {
                
                pictureBox6.Dispose();
            }
            if (pictureBox7.Image != null)
            {
                
                pictureBox7.Dispose();
            }
            if (pictureBox8.Image != null)
            {
                
                pictureBox8.Dispose();
            }
            if (pictureBox9.Image != null)
            {
                
                pictureBox9.Dispose();
            }
            if (pictureBox10.Image != null)
            {
                
                pictureBox10.Dispose();
            }
            if (pictureBox11.Image != null)
            {
                
                pictureBox11.Dispose();
            }
            if (pictureBox12.Image != null)
            {
                
                pictureBox12.Dispose();
            }
            if (pictureBox13.Image != null)
            {
                
                pictureBox13.Dispose();
            }
            if (pictureBox14.Image != null)
            {
                
                pictureBox14.Dispose();
            }
            if (pictureBox15.Image != null)
            {
                
                pictureBox15.Dispose();
            }
        
             
        }

        //
        // Notificaciones-------------------------------------------------------------------------------------------------------------------------------
        //

        private void NotificaEmail(int nttipo, string ntentrada, string ntcliente)
        {
            /*
             0 = ERROR
             1 = EXITO
            */

            if (nttipo == 1)
            {
                notifyIcon1.Text = "El email se ha enviado exitosamente";
                notifyIcon1.BalloonTipTitle = "EXITO: Email Correcto " + ntentrada;
                notifyIcon1.BalloonTipText = "El email de la entrada " + ntentrada + " ha sido enviado correctamente\r\nCliente: "+ntcliente;
                notifyIcon1.ShowBalloonTip(10000);
            }
            else if (nttipo == 2)
            {
                notifyIcon1.Text = "ERROR: El email NO se ha enviado";
                notifyIcon1.BalloonTipTitle = "ERROR: Email Correcto " + ntentrada;
                notifyIcon1.BalloonTipText = "El email de la entrada " + ntentrada + "NO ha sido enviado\r\nCliente: " + ntcliente;
                notifyIcon1.ShowBalloonTip(10000);
            }
           
        }

    }
}
