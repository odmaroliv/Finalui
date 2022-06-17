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
using System.Diagnostics;
using mainVentana.Loading;
using ImageMagick;
using System.Drawing.Imaging;
using Datos.ViewModels.Reportes;

namespace mainVentana.VistaEntrada
{

    public partial class AltaEntrada : Form
    {
        //KunLibertad_DesktopControl Desk = new KunLibertad_DesktopControl();


        //int ventana;
        public int tipodeDocumento = 1;
        public AltaEntrada()
        {

            InitializeComponent();

        }

        private void AltaEntrada_Load(object sender, EventArgs e)
        {

            if (tipodeDocumento == 1)
            {
                InicioEntrada();
            }


        }


        #region ALTA DE ENTRADA__________________________________________________________________________________________________________________________________

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


        private void LimpiaList()
        {
            mnd.Clear(); // Localizacion de img correo 
            larch.Clear(); // localizacion del archivo correo
            lstFotos.Clear(); // archivos para base de datos 
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



                lstFotos.Add(new vmListaFotos { documento = pictureBox2.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-1", realnombre = filename, bytedocumto = RedimencionaIMG(pictureBox2.ImageLocation.ToString()), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Imagen" });
            }

            if (pictureBox3.Image != null)
            {

                string filename = null;
                filename = Path.GetFileName(pictureBox3.ImageLocation);

                lstFotos.Add(new vmListaFotos { documento = pictureBox3.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-2", realnombre = filename, bytedocumto = RedimencionaIMG(pictureBox3.ImageLocation.ToString()), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Imagen" });
            }

            if (pictureBox4.Image != null)
            {


                string filename = null;
                filename = Path.GetFileName(pictureBox4.ImageLocation);

                lstFotos.Add(new vmListaFotos { documento = pictureBox4.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-3", realnombre = filename, bytedocumto = RedimencionaIMG(pictureBox4.ImageLocation.ToString()), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Imagen" });
            }

            if (pictureBox5.Image != null)
            {

                string filename = null;
                filename = Path.GetFileName(pictureBox5.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox5.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-4", realnombre = filename, bytedocumto = RedimencionaIMG(pictureBox5.ImageLocation.ToString()), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Imagen" });

            }
            if (pictureBox6.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox6.ImageLocation);

                lstFotos.Add(new vmListaFotos { documento = pictureBox6.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-5", realnombre = filename, bytedocumto = RedimencionaIMG(pictureBox6.ImageLocation.ToString()), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Imagen" });

            }
            if (pictureBox7.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox7.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox7.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-6", realnombre = filename, bytedocumto = RedimencionaIMG(pictureBox7.ImageLocation.ToString()), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Imagen" });
            }
            if (pictureBox8.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox8.ImageLocation);

                lstFotos.Add(new vmListaFotos { documento = pictureBox8.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-7", realnombre = filename, bytedocumto = RedimencionaIMG(pictureBox8.ImageLocation.ToString()), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Imagen" });
            }
            if (pictureBox9.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox9.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox9.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-8", realnombre = filename, bytedocumto = RedimencionaIMG(pictureBox9.ImageLocation.ToString()), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Imagen" });
            }
            if (pictureBox10.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox10.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox10.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-9", realnombre = filename, bytedocumto = RedimencionaIMG(pictureBox10.ImageLocation.ToString()), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Imagen" });
            }
            if (pictureBox11.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox11.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox11.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-10", realnombre = filename, bytedocumto = RedimencionaIMG(pictureBox11.ImageLocation.ToString()), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Imagen" });
            }
            if (pictureBox12.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox12.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox12.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-11", realnombre = filename, bytedocumto = RedimencionaIMG(pictureBox12.ImageLocation.ToString()), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Imagen" });
            }
            if (pictureBox13.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox13.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox13.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-12", realnombre = filename, bytedocumto = RedimencionaIMG(pictureBox13.ImageLocation.ToString()), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Imagen" });
            }
            if (pictureBox14.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox14.ImageLocation);


                lstFotos.Add(new vmListaFotos { documento = pictureBox14.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-13", realnombre = filename, bytedocumto = RedimencionaIMG(pictureBox14.ImageLocation.ToString()), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Imagen" });
            }
            if (pictureBox15.Image != null)
            {
                string filename = null;
                filename = Path.GetFileName(pictureBox15.ImageLocation);

                lstFotos.Add(new vmListaFotos { documento = pictureBox15.ImageLocation, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-14", realnombre = filename, bytedocumto = RedimencionaIMG(pictureBox15.ImageLocation.ToString()), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Imagen" });
            }

        }
        private void AgregaArchivoslist()
        {


            if (label27.Text != null && label27.Text != "")
            {
                string filename = null;
                filename = Path.GetFileName(label27.Text);



                lstFotos.Add(new vmListaFotos { documento = label27.Text, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-1", realnombre = filename, bytedocumto = docbyte(label27.Text), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Doc" });
            }

            if (label28.Text != null && label28.Text != "")
            {

                string filename = null;
                filename = Path.GetFileName(label28.Text);

                lstFotos.Add(new vmListaFotos { documento = label28.Text, entrada = datoEntrada, nombre = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada + "-2", realnombre = filename, bytedocumto = docbyte(label28.Text), sucursal = sucEntrada.SelectedValue.ToString(), tipo = "Doc" });
            }
        }

        #endregion

        private void pictureBox2_DoubleClick(object sender, EventArgs e) // Alimina con doble clicl las fotos seleccionadas, configura el PictureBox a null, para volver a ser utilizado
        {
            if (tipodeDocumento == 1)
            {
                PictureBox pic = (PictureBox)sender;
                pic.Image = null;
            }
            else if (tipodeDocumento == 2)
            {
                PictureBox pic = (PictureBox)sender;
                Abre_Fotos_P_Defecto(pic.Image, pic.Name.ToString());
            }

        }

        private void InicioEntrada()
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


        private void Guardar_Click(object sender, EventArgs e) //Click al boton guardar
        {
            ValidacionEntradas validacion = new ValidacionEntradas();
            if (tipodeDocumento == 1)
            {
                LimpiaList();
                creaListadeFotos();
                AgregaArchivos();
                int ps = Calcula_peso_de_email();


                if (validacion.validacampo(sucEntrada.Text, sucDestino.Text, tipoOper.Text, cord.Text, cliente.Text, proveedor.Text, ordenCompra.Text, numFlete.Text, unidades.Text, peso.Text, bultos.Text, detalles.Text) == true && ps == 1)
                {

                    //creaListadeFotos();
                    //AgregaArchivos();

                    altaKDM1();

                    altaKDM1coment();
                    SubeFotos();


                    envEmail();
                    //barcode();
                    Crea_codigo_de_barras();
                    llamareporte();
                    //CreaEriquetas();
                    //envEmail();

                    ReiniciaInfo(0);
                    LimpiaList();
                    //cargaultent();
                }
            }

            if (tipodeDocumento == 2)
            {
                if (validacion.validacampo(sucEntrada.Text, sucDestino.Text, tipoOper.Text, cord.Text, cliente.Text, proveedor.Text, ordenCompra.Text, numFlete.Text, unidades.Text, peso.Text, bultos.Text, detalles.Text) == true)
                {
                    if (lblEntrada.Text != "" || lblEntrada.Text != null)
                    {
                        string pagado = default;
                        if (rdbPagado.Checked == true)
                        {
                            pagado = "Pagado";
                        }
                        else
                        {
                            pagado = "NoPagado";
                        }
                        updateDatos(pagado);
                        llamareporte();
                        MessageBox.Show("Se ha modificado el docimento " + lblEntrada.Text);
                        InicioModifica();
                        

                    }
                    else
                    {

                        MessageBox.Show("No se ha ingresado ninguna entrada!");
                    }
                }
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
            string datoNuCliente = lblCodCliente.Text;
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
            string datoNota = txbNotas.Text;
            string datoReferencia = txbReferencia.Text;


            bd.agregaKDM1(datoSucIni, datoEntrada, datoMoneda, datoFecha, datoNuCliente, datoNoCord, datoValArn, datoNomCliente, datoCalle, datoColonia, datoCiudadZip,
            datoValFact, datoParidad, datoNoTrakin, datoProvedor, datoOrdCompra, datoNoFlete, datoNoUnidades, datoTipoUnidad, datoPeso, datoUnidadMedida, datoTipoOper,
            datoSucDestino, datoBultos, datosAlias, datoNota, datoReferencia);

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
        private async void envEmail()
        {
            EnviarEmail servicio = new EnviarEmail();
            var respuesta = await servicio.EnviaMail(lblEntrada.Text, cliente.Text, tbxRastreo.Text, alias.Text, ordenCompra.Text, numFlete.Text, proveedor.Text, detalles.Text, mnd, larch, coreoClientes);
            if (respuesta == 1)
            {
                MessageBox.Show("El correo NO SE ENVIÓ PORQUE supera el límite máximo de 25 MB en cada correo, intenta borrar documentos y reenvía la notificación", "CUIDADO EL CORREO NO SE ENVIO");
                NotificaEmail(0, lblEntrada.Text, cliente.Text);
            }
            else
            {
                NotificaEmail(1, lblEntrada.Text, cliente.Text);
            }

        }
        private int Calcula_peso_de_email()
        {
            long pesoArch = 0;

            foreach (var item in mnd) //Attachment
            {

                FileInfo fileinfo = new FileInfo(item);
                pesoArch = pesoArch + fileinfo.Length;
            }
            foreach (var item in larch) //Attachment
            {

                FileInfo fileinfo = new FileInfo(item);
                pesoArch = pesoArch + fileinfo.Length;
            }

            if (pesoArch >= 25000000)
            {
                MessageBox.Show("La suma maxima de los archivos supera la catidad que permite Gmail, por favor borra archivos/fotos", "Limite alcanzado");
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void CreaEriquetas()
        {
            int bulto = Convert.ToInt32(bultos.Text);

            impirmepdf();

        }

        private void barcode()
        {
            AltasBD bdalta = new AltasBD();

            using (MemoryStream ms = new MemoryStream())
            {
                for (int i = 1; i < Convert.ToInt32(bultos.Text); i++)
                {
                    string eti = sucEntrada.SelectedValue.ToString().Trim() + datoEntrada.ToString().Trim() + i.ToString().Trim();
                    byte[] code;
                    BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                    System.Drawing.Image imge = b.Encode(BarcodeLib.TYPE.CODE128, eti.Trim(), Color.Black, Color.White, 250, 40);

                    imge.Save(ms, ImageFormat.Png);
                    code = ms.ToArray();
                    bdalta.codeBar(sucEntrada.SelectedValue.ToString().Trim(), datoEntrada.Trim(), eti, code);
                }



            }
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
                            string etiqueta = sucEntrada.SelectedValue.ToString().Trim() + "-" + lblEntrada.Text + "-" + i.ToString();
                            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ORIGEN", sucEntrada.GetItemText(sucEntrada.SelectedItem).ToString().Trim());
                            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DESTINO", sucDestino.GetItemText(sucDestino.SelectedItem).ToString().Trim());
                            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ENTRADA", lblEntrada.Text);
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
        private byte[] RedimencionaIMG(string path)
        {
            byte[] pic;
            using (MagickImage imk = new MagickImage(path))
            {
                imk.Resize(1000, 0);
                pic = imk.ToByteArray();

            }
            return pic;

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

                //var lst3                = sucEntrada.DataSource;
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

            lblFecha.Text = lst.datetime.Date.ToString("dd-MM-yyyy");

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
            rdbNoPagado.Enabled = false;
            rdbPagado.Enabled = true;
        }



        private void gunaMediumRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            rdbPagado.Enabled = false;
        }

        private void gunaTileButton3_Click(object sender, EventArgs e)
        {

            if (rdbNoPagado.Checked == true)
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
                rdbNoPagado.Enabled = true;
            }
            else
            {
                rdbNoPagado.Enabled = false;
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
            if (tipodeDocumento == 1)
            {
                cargaultent();
            }

        }
        private void cargaultent()
        {
            Servicios datos = new Servicios();

            foreach (var i in datos.NumeroEntrada(sucEntrada.SelectedValue.ToString()))
            {
                int numero = Convert.ToInt32(i.entrada) + 1;
                lblEntrada.Text = numero.ToString("D7");
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


        private void label27_DoubleClick(object sender, EventArgs e) //borra doc
        {
            Label pic = (Label)sender;
            if (tipodeDocumento == 1)
            {
                pic.Text = "";
            }
            else if (tipodeDocumento == 2)
            {
                Abre_doc_por_defecto(pic.Text.Trim());

            }
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            regresafecha();
        }


        public void limpiaImg()
        {
            if (pictureBox2.Image != null)
            {
                //pictureBox2.Dispose();
                pictureBox2.Image = null;
                pictureBox2.ImageLocation = null;

            }
            if (pictureBox3.Image != null)
            {

                pictureBox3.Image = null;
                pictureBox3.ImageLocation = null;

            }
            if (pictureBox4.Image != null)
            {
                pictureBox4.Image = null;
                pictureBox4.ImageLocation = null;
            }
            if (pictureBox5.Image != null)
            {
                pictureBox5.Image = null;
                pictureBox5.ImageLocation = null;
            }
            if (pictureBox6.Image != null)
            {

                pictureBox6.Image = null;
                pictureBox6.ImageLocation = null;
            }
            if (pictureBox7.Image != null)
            {

                pictureBox7.Image = null;
                pictureBox7.ImageLocation = null;
            }
            if (pictureBox8.Image != null)
            {

                pictureBox8.Image = null;
                pictureBox8.ImageLocation = null;
            }
            if (pictureBox9.Image != null)
            {

                pictureBox9.Image = null;
                pictureBox9.ImageLocation = null;
            }
            if (pictureBox10.Image != null)
            {
                pictureBox10.Image = null;
                pictureBox10.ImageLocation = null;
            }
            if (pictureBox11.Image != null)
            {
                pictureBox11.Image = null;
                pictureBox11.ImageLocation = null;
            }
            if (pictureBox12.Image != null)
            {

                pictureBox12.Image = null;
                pictureBox12.ImageLocation = null;
            }
            if (pictureBox13.Image != null)
            {
                pictureBox13.Image = null;
                pictureBox13.ImageLocation = null;
            }
            if (pictureBox14.Image != null)
            {

                pictureBox14.Image = null;
                pictureBox14.ImageLocation = null;
            }
            if (pictureBox15.Image != null)
            {

                pictureBox15.Image = null;
                pictureBox15.ImageLocation = null;
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
                notifyIcon1.Visible = true;
                notifyIcon1.Text = ntentrada + " Enviado";
                notifyIcon1.BalloonTipTitle = "EXITO: Email Correcto " + ntentrada;
                notifyIcon1.BalloonTipText = "El email de la entrada " + ntentrada + " ha sido enviado correctamente\r\nCliente: " + ntcliente;
                notifyIcon1.ShowBalloonTip(10000);


            }
            else if (nttipo == 2)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Text = ntentrada + " ERROR: El email NO se ha enviado";
                notifyIcon1.BalloonTipTitle = "ERROR: Email Correcto " + ntentrada;
                notifyIcon1.BalloonTipText = "El email de la entrada " + ntentrada + "NO ha sido enviado\r\nCliente: " + ntcliente;
                notifyIcon1.ShowBalloonTip(10000);

            }

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
        }

        //
        // Notificaciones-------------------------------------------------------------------------------------------------------------------------------
        //
        private void button1_Click_2(object sender, EventArgs e)
        {
            ReiniciaInfo(1);
            //abreModifica();

        }
        private async void GeneraRastreo()
        {
            Servicios datos = new Servicios();
            foreach (var i in await datos.generaRastreo())
            {
                tbxRastreo.Text = i.c1.ToString();
            }
        }

        public void ReiniciaInfo(int msn) // reinicia los valores para una nueva entrada
        {
            if (msn == 1) // 1 muestra mensaje
            {
                if (MessageBox.Show("Estas seguro de que deseas reiniciar todo los datos?", "Cuidado!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    sucEntrada.SelectedIndex = 0;
                    //datoEntrada               = recuperUltimaent();
                    cargaultent();
                    cmbMoneda.SelectedIndex = 0;
                    //regresafecha();
                    cargafecha();
                    lblCodCliente.Text = default;
                    cord.SelectedIndex = 0;
                    txbValArn.Text = default;
                    cliente.Text = default;
                    label23.Text = default;
                    label24.Text = default;
                    label25.Text = default;
                    txbValFact.Text = default;
                    lblParidad.Text = default;
                    tbxRastreo.Text = default;
                    proveedor.SelectedIndex = 0;
                    ordenCompra.Text = default;
                    numFlete.Text = default;
                    unidades.Text = default;
                    cmbUnidades.SelectedIndex = 0;
                    peso.Text = default;
                    cmbPeso.SelectedIndex = 0;
                    tipoOper.SelectedIndex = 0;
                    sucDestino.SelectedIndex = 0;
                    bultos.Text = default;
                    alias.Text = default;
                    txbNotas.Text = default;
                    txbReferencia.Text = default;
                    label27.Text = default;
                    label28.Text = default;
                    detalles.Text = default;

                    limpiaImg();
                    GeneraRastreo();
                    Cargaparidad();

                }
                return;

            }
            else if (msn == 0)
            {
                sucEntrada.SelectedIndex = 0;
                //datoEntrada               = recuperUltimaent();
                cargaultent();
                cmbMoneda.SelectedIndex = 0;
                //regresafecha();
                cargafecha();
                lblCodCliente.Text = default;
                cord.SelectedIndex = 0;
                txbValArn.Text = default;
                cliente.Text = default;
                label23.Text = default;
                label24.Text = default;
                label25.Text = default;
                txbValFact.Text = default;
                lblParidad.Text = default;
                tbxRastreo.Text = default;
                proveedor.SelectedIndex = 0;
                ordenCompra.Text = default;
                numFlete.Text = default;
                unidades.Text = default;
                cmbUnidades.SelectedIndex = 0;
                peso.Text = default;
                cmbPeso.SelectedIndex = 0;
                tipoOper.SelectedIndex = 0;
                sucDestino.SelectedIndex = 0;
                bultos.Text = default;
                alias.Text = default;
                txbNotas.Text = default;
                txbReferencia.Text = default;
                label27.Text = default;
                label28.Text = default;
                detalles.Text = default;

                limpiaImg();
                GeneraRastreo();
                Cargaparidad();
            }


        }

        #endregion Fin del Alta de entrada__________________________________________________________________________________________________________________________________
        /*
        En esta region se trata de poner todo lo relacionado con el negocio en una modificacion de entrada, la ide es bloaquar los campos y solo permitir algunos.
        
        */
        #region INICIO DE MODIFICA ENTRAD__________________________________________________________________________________________________________________________________

        public void CambiaDocumento(int dato)
        {
            if (dato == 1)//Abre alta entrada
            {
                tipodeDocumento = dato;
                btnBuscarEnt.Visible = false;
                txbBuscarEnt.Visible = false;
                lblBuscarEnt.Visible = false;
                btnAgregarBultos.Visible = false;
                btnAgrepaFD.Visible = false;
                abreModifica(true);
                ReiniciaInfo(1);
                limpiaImg();

            }
            if (dato == 2)
            {
                tipodeDocumento = dato;
                InicioModifica();
            }


        }
        private void InicioModifica()
        {
            btnBuscarEnt.Visible = true;
            txbBuscarEnt.Visible = true;
            lblBuscarEnt.Visible = true;
            btnAgregarBultos.Visible = true;
            btnAgrepaFD.Visible = true;
            abreModifica(false);
            limpiaImg();

        }

        private void abreModifica(bool estatus)
        {

            //tipodeDocumento = tipo;

            //if  (MessageBox.Show("Estas seguro de que deseas cambiar a la pestaña?", "Cuidado!", MessageBoxButtons.OKCancel) == DialogResult.OK)

            //{



            sucEntrada.SelectedIndex = 0;
            //sucEntrada.Enabled      = estatus;

            //cmbMoneda.SelectedIndex = 1;
            //cmbMoneda.Enabled         = estatus;

            lblCodCliente.Text = default;
            lblCodCliente.Enabled = estatus;

            cord.SelectedIndex = 0;
            //cord.Enabled            = estatus;


            cliente.Text = default;
            cliente.Enabled = estatus;

            proveedor.SelectedIndex = 0;
            proveedor.Enabled = estatus;

            ordenCompra.Text = default;
            ordenCompra.Enabled = estatus;

            numFlete.Text = default;
            numFlete.Enabled = estatus;

            unidades.Text = default;
            unidades.Enabled = estatus;

            cmbUnidades.SelectedIndex = 0;
            cmbUnidades.Enabled = estatus;

            peso.Text = default;
            peso.Enabled = estatus;

            cmbPeso.SelectedIndex = 0;
            cmbPeso.Enabled = estatus;



            bultos.Text = default;
            bultos.Enabled = estatus;

            alias.Text = default;
            alias.Enabled = estatus;

            gunaTileButton1.Enabled = estatus;
            gunaTileButton2.Enabled = estatus;

            detalles.Enabled = estatus;



            if (estatus != true)
            {
                txbNotas.Text = default;
                txbReferencia.Text = default;
                txbValFact.Text = default;
                txbValArn.Text = default;
                tipoOper.SelectedIndex = 0;
                sucDestino.SelectedIndex = 0;
                detalles.Text = default;
                tbxRastreo.Text = default;

                lblParidad.Text = default;
                label23.Text = default;
                label24.Text = default;
                label25.Text = default;
                label27.Text = default;
                label28.Text = default;
                lblEntrada.Text = default;
                lblFecha.Text = default;

            }




            //}

        }
        private void btnBuscarEnt_Click(object sender, EventArgs e)
        {
            Funciones_para_Busqueda();

        }
        private void txbBuscarEnt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                Funciones_para_Busqueda();


            }
        }
        private void Funciones_para_Busqueda()
        {
            int valida = Validaciones_P_Busqueda();
            if (valida == 1)
            {
                LimpiaIMG2();
                if (Busqueda_Entrada(txbBuscarEnt.Text.Trim(), sucEntrada.SelectedValue.ToString().Trim()) == 0)
                {
                    return;
                }

                CargaFotos(txbBuscarEnt.Text.Trim(), sucEntrada.SelectedValue.ToString().Trim());
                CargaDocPDF();
                label27.Text = "";
                label28.Text = "";
            }

        }
        private int Validaciones_P_Busqueda() //Validacion primitiva antes de hacer la busqueda de entrada
        {
            if (txbBuscarEnt.Text == "")
            {
                MessageBox.Show("El campo de busqueda esta vacio!");
                return 2;
            }
            int datparseado;
            bool bent = Int32.TryParse(txbBuscarEnt.Text, out datparseado);
            if (bent == true)
            {
                txbBuscarEnt.Text = datparseado.ToString("D7");
                return 1;
            }
            else
            {
                MessageBox.Show("Las entradas tienen que ser un codigo numerico, y no pueden contener letras");
                return 2;
            }

        }

        //--------------------------------------------------------------*
        // Busqueda_Entrada(string id, string sucursal) 
        // Trae los valores de la bd y los asgina al frm
        //--------------------------------------------------------------*
        private int Busqueda_Entrada(string id, string sucursal)
        {
            Servicios datos = new Servicios();
            var lst = datos.LLenaEntradaByID(id, sucursal);
            int bandera = 0;
            if (lst.Count < 1)
            {
                MessageBox.Show("Entrada no encontrada", "Esta bien escrito todo?");
                return bandera = 0;
            }


            foreach (var q in lst)
            {
                //-------Sucursal inicia---------------
                foreach (Sucursales i in sucEntrada.Items)
                {
                    if (i.c1.Trim() == q.C1.Trim())
                    {
                        sucEntrada.SelectedValue = i.c1;
                        break;

                    }

                }
                //-----------------------------------

                lblEntrada.Text = q.C6.Trim();
                //cmbMoneda.Text = q.C7;
                cmbMoneda.Text = q.C7.Trim();
                lblFecha.Text = q.C9.Value.Date.ToString("dd-MM-yyyy");
                lblCodCliente.Text = q.C10.Trim();
                string vtxtref = q.C11 ?? "";
                txbReferencia.Text = vtxtref.Trim();

                //--------Coordinador asignado-------------------
                foreach (vmCordinadores i in cord.Items)
                {
                    if (i.c2.Trim() == q.C12.Trim())
                    {
                        cord.SelectedValue = i.c2;
                        break;

                    }

                }

                txbValArn.Text = q.C16.ToString().Trim();
                txbNotas.Text = q.C24?.Trim();
                cliente.Text = q.C32.Trim();
                alias.Text = q.C112.Trim();
                lblParidad.Text = q.C40.ToString().Trim();
                tbxRastreo.Text = q.C80.Trim();
                lblUser.Text = q.C81.Trim();


                //------proveedores-------------------
                foreach (Proveedores i in proveedor.Items)
                {
                    if (i.c2.Trim() == q.C92.Trim())
                    {
                        proveedor.SelectedValue = i.c2;
                        break;

                    }

                }

                ordenCompra.Text = q.C93.Trim();
                numFlete.Text = q.C95.Trim();
                unidades.Text = Convert.ToInt32(q.C97).ToString().Trim();

                //------Tipo de unidad-----------
                foreach (vmPiezas i in cmbUnidades.Items)
                {
                    if (i.c1.Trim() == q.C98.Trim())
                    {
                        cmbUnidades.SelectedValue = i.c1;
                        break;

                    }

                }

                peso.Text = q.C99.ToString();

                //------Peso-------------------
                foreach (vmPeso i in cmbPeso.Items)
                {
                    if (i.c1.Trim() == q.C100.Trim())
                    {
                        cmbPeso.SelectedValue = i.c1;
                        break;

                    }

                }

                tipoOper.Text = q.C101.Trim();
                txbValFact.Text = q.C102.Trim();

                //-------Sucursal destino---------------
                foreach (Sucursales i in sucDestino.Items)
                {
                    if (i.c1.Trim() == q.C103.Trim())
                    {
                        sucDestino.SelectedValue = i.c1;
                        break;

                    }

                }
                //-----------------------------------

                bultos.Text = Convert.ToInt32(q.C108).ToString().Trim();
                detalles.Text = q.descripcion.Trim();
                string rbt = q.C44 ?? "NoPagado";
                RDBpagar(rbt.Trim());
                bandera = 1;
                // alias.Text = q.C112;
            }
            return bandera;
        }

        //--------------------------------------------------------------*
        // RDBpagar(string dato)
        // Establece de acuerdo a los datos de la bd si los radio de pagado o no pagado deben de estar activos o no
        //--------------------------------------------------------------*
        private void RDBpagar(string dato)
        {
            if (dato == "Pagado")
            {
                rdbPagado.Checked = true;
                rdbNoPagado.Checked = false;
                rdbNoPagado.Enabled = false;
                rdbPagado.Enabled = false;
            }
            else if (dato == "NoPagado")
            {
                rdbPagado.Checked = false;
                rdbNoPagado.Checked = true;
                rdbNoPagado.Enabled = false;
                //rdbPagado.Enabled = false;
            }

        }

        //--------------------------------------------------------------*
        // updateDatos(string pagado)
        // Obtiene los datos a modificar y los manda a la funcion de UPDATEKDM1
        //--------------------------------------------------------------*
        private void updateDatos(string pagado)
        {
            string datoSucDestino = sucDestino.SelectedValue.ToString().Trim();
            string datoNoCord = cord.SelectedValue.ToString().Trim();
            string datoNota = txbNotas.Text.Trim();
            string datoReferencia = txbReferencia.Text.Trim();
            string datoTipoOper = tipoOper.SelectedValue.ToString().Trim();
            string datoValFact = txbValFact.Text.Trim();
            string datoValArn = txbValArn.Text.Trim();
            AltasBD bd = new AltasBD();
            bd.UpdateKDM1(lblEntrada.Text.Trim(), datoSucDestino, datoNoCord, datoNota, datoReferencia, pagado, datoTipoOper, datoValFact, datoValArn);
        }

        //--------------------------------------------------------------*
        // CargaDocPDF()
        // carga el nimero de documento en un label, para se utilizado como id en un evento.
        //--------------------------------------------------------------*
        private async void CargaDocPDF()
        {
            Servicios datos = new Servicios();
            // GifLoading(1);
            var lst = await datos.ObtieneDOC(txbBuscarEnt.Text.Trim(), sucEntrada.SelectedValue.ToString().Trim());
            int vl = 0;
            foreach (var i in lst)
            {
                if (vl == 0)
                {
                    label27.Text = i.nombre.Trim();
                }
                else if (vl == 1)
                {
                    label28.Text = i.nombre.Trim();
                }


                vl++;
            }



            // GifLoading(2);
        }

        //--------------------------------------------------------------*
        // Abre_doc_por_defecto(string id)
        // Mediante el evento de doble click crea una carpeta temporal para guardar el documento que trae de la base de datos y lo abre con el programa por defecto para la extencion
        //--------------------------------------------------------------*
        private async void Abre_doc_por_defecto(string id)
        {
            Servicios datos = new Servicios();
            GifLoading(1);
            var lst = await datos.ObtieneByteDOC(id.Trim(), sucEntrada.SelectedValue.ToString().Trim());
            foreach (var i in lst)
            {
                var ms = new MemoryStream(i.bytedocumento.ToArray());
                Abre_Doc_P_Defecto(ms.ToArray(), i.realnombre);

                ms.Dispose();
            }
            GifLoading(2);
        }

        //--------------------------------------------------------------*
        // CargaFotos(string entrada, string sucursalOri)
        // Obtiene las fotografias de la base de datos y las asigna a un memorystream para mandarlas a la funcion que las agrega a los picture box, se hace de manera asincrona.
        //--------------------------------------------------------------*
        private async void CargaFotos(string entrada, string sucursalOri)
        {
            Servicios datos = new Servicios();
            GifLoading(1);
            var lst = await datos.ObtieneIMG(entrada, sucursalOri);

            foreach (var i in lst)
            {
                var ms = new MemoryStream(i.bytedocumento.ToArray());
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                Recarga_fotos(img, i.realnombre);
                ms.Dispose();
            }
            GifLoading(2);
        }

        //--------------------------------------------------------------*
        // Recarga_fotos(System.Drawing.Image img, string name)
        //Carga las fotos en los picture box y les asigna un nombre para poder utilizarlo como sender en el evento de hacer doble click sobre ellos
        //--------------------------------------------------------------*
        private void Recarga_fotos(System.Drawing.Image img, string name)
        {
            if (pictureBox2.Image == null)
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    img = new Bitmap(bmp);
                    pictureBox2.Image = img;
                    pictureBox2.Name = name;
                }
            }

            else if (pictureBox3.Image == null)
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    img = new Bitmap(bmp);
                    pictureBox3.Image = img;
                    pictureBox3.Name = name;
                }

            }
            else if (pictureBox4.Image == null)
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    img = new Bitmap(bmp);
                    pictureBox4.Image = img;
                    pictureBox4.Name = name;
                }

            }
            else if (pictureBox5.Image == null)
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    img = new Bitmap(bmp);
                    pictureBox5.Image = img;
                    pictureBox5.Name = name;
                }

            }
            else if (pictureBox6.Image == null)
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    img = new Bitmap(bmp);
                    pictureBox6.Image = img;
                    pictureBox6.Name = name;
                }

            }
            else if (pictureBox7.Image == null)
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    img = new Bitmap(bmp);
                    pictureBox7.Image = img;
                    pictureBox7.Name = name;
                }

            }
            else if (pictureBox8.Image == null)
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    img = new Bitmap(bmp);
                    pictureBox8.Image = img;
                    pictureBox8.Name = name;
                }

            }
            else if (pictureBox9.Image == null)
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    img = new Bitmap(bmp);
                    pictureBox9.Image = img;
                    pictureBox9.Name = name;
                }

            }
            else if (pictureBox10.Image == null)
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    img = new Bitmap(bmp);
                    pictureBox10.Image = img;
                    pictureBox10.Name = name;
                }

            }
            else if (pictureBox11.Image == null)
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    img = new Bitmap(bmp);
                    pictureBox11.Image = img;
                    pictureBox11.Name = name;
                }


            }
            else if (pictureBox12.Image == null)
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    img = new Bitmap(bmp);
                    pictureBox12.Image = img;
                    pictureBox12.Name = name;
                }


            }
            else if (pictureBox13.Image == null)
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    img = new Bitmap(bmp);
                    pictureBox13.Image = img;
                    pictureBox13.Name = name;
                }

            }
            else if (pictureBox14.Image == null)
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    img = new Bitmap(bmp);
                    pictureBox14.Image = img;
                    pictureBox14.Name = name;
                }


            }
            else if (pictureBox15.Image == null)
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    img = new Bitmap(bmp);
                    pictureBox15.Image = img;
                    pictureBox15.Name = name;
                }


            }

        }

        //--------------------------------------------------------------*
        // Abre_Fotos_P_Defecto(System.Drawing.Image imagen, string nombrereal)
        // Crea una carpeta de archivos temporales y abre el archivo en el dispositivo con el programa por defecto para esa extencion
        //--------------------------------------------------------------*
        private void Abre_Fotos_P_Defecto(System.Drawing.Image imagen, string nombrereal)
        {
            using (var ms = new MemoryStream())
            {
                imagen.Save(ms, ImageFormat.Png);
                byte[] imgbyte = ms.ToArray();


                string path = AppDomain.CurrentDomain.BaseDirectory;
                string folder = path + "\\temp\\";
                string fullFilePath = folder + nombrereal;

                if (File.Exists(fullFilePath))
                    File.Delete(fullFilePath);

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);



                File.WriteAllBytes(fullFilePath, imgbyte);

                Process.Start(fullFilePath);

            }
        }

        private void Abre_Doc_P_Defecto(byte[] doc, string nombrereal)
        {
            using (var ms = new MemoryStream())
            {
                //imagen.Save(ms, ImageFormat.Png);
                byte[] imgbyte = doc;


                string path = AppDomain.CurrentDomain.BaseDirectory;
                string folder = path + "\\temp\\";
                string fullFilePath = folder + nombrereal;

                if (File.Exists(fullFilePath))
                    File.Delete(fullFilePath);

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);



                File.WriteAllBytes(fullFilePath, imgbyte);

                Process.Start(fullFilePath);

            }
        }

        //--------------------------------------------------------------*
        // LimpiaIMG2()
        // Establece como null las propiedades de Image e ImageLocation de los picturebox NO HACE DISPOSE.
        //--------------------------------------------------------------*
        public void LimpiaIMG2()
        {

            if (pictureBox2.Image != null)
            {

                pictureBox2.Image = null;
                pictureBox2.ImageLocation = null;

            }
            if (pictureBox3.Image != null)
            {

                pictureBox3.Image = null;
                pictureBox3.ImageLocation = null;

            }
            if (pictureBox4.Image != null)
            {
                pictureBox4.Image = null;
                pictureBox4.ImageLocation = null;
            }
            if (pictureBox5.Image != null)
            {

                pictureBox5.Image = null;
                pictureBox5.ImageLocation = null;
            }
            if (pictureBox6.Image != null)
            {

                pictureBox6.Image = null;
                pictureBox6.ImageLocation = null;
            }
            if (pictureBox7.Image != null)
            {

                pictureBox7.Image = null;
                pictureBox7.ImageLocation = null;
            }
            if (pictureBox8.Image != null)
            {

                pictureBox8.Image = null;
                pictureBox8.ImageLocation = null;
            }
            if (pictureBox9.Image != null)
            {

                pictureBox9.Image = null;
                pictureBox9.ImageLocation = null;
            }
            if (pictureBox10.Image != null)
            {

                pictureBox10.Image = null;
                pictureBox10.ImageLocation = null;
            }
            if (pictureBox11.Image != null)
            {

                pictureBox11.Image = null;
                pictureBox11.ImageLocation = null;
            }
            if (pictureBox12.Image != null)
            {

                pictureBox12.Image = null;
                pictureBox12.ImageLocation = null;
            }
            if (pictureBox13.Image != null)
            {
                pictureBox13.Image = null;
                pictureBox13.ImageLocation = null;
            }
            if (pictureBox14.Image != null)
            {
                pictureBox14.Image = null;
                pictureBox14.ImageLocation = null;
            }
            if (pictureBox15.Image != null)
            {

                pictureBox15.Image = null;
                pictureBox15.ImageLocation = null;
            }
        }

        #endregion Fin de Modifica entrada__________________________________________________________________________________________________________________________________
        private void abreBaja()
        {

        }
        private void abreConsulta()
        {

        }
        /************************************************************
         Aqui cargo las iamgenes de loading, asi como el agregado al contenerdor 
         ************************************************************/
        public LoadingPatoControl usss { get; set; }
        private void GifLoading(int estado)//1 abre el el gif 2 detiene el gif
        {
            LoadingPatoControl loadingPatoControl = new LoadingPatoControl();
            if (estado == 1)
            {
                loadingPatoControl.Dock = DockStyle.Fill;
                panelLoading.Controls.Add(loadingPatoControl);

            }
            if (estado == 2)
            {
                panelLoading.Controls.Clear();

            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Reportes.TestReport rp = new Reportes.TestReport();
            //rp.Entrada = lblEntrada.Text;
            //rp.sucursalIni = sucEntrada.SelectedValue.ToString();
            Servicios sv = new Servicios();

            var lst = new List<vmEtiquetasReporte>();
            lst = sv.LlenaEtiquetas(lblEntrada.Text.Trim(), sucEntrada.SelectedValue.ToString().Trim());

            foreach (var q in lst)
            {
                rp.repTOrigen = q.Origen;
                rp.repTdest = q.Destino;
                rp.repTCliente = q.Cliente;
                rp.repTEtiqueta = q.Etiqueta;
                rp.repTEntrada = q.Entrada;
                rp.repTFecha = q.Fecha.Value.Date.ToString();
                rp.repTAlias = q.Alias;
                rp.ShowDialog();
            }





        }

        private void llamareporte()
        {
            
            Reportes.TestReport rp = new Reportes.TestReport();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Servicios sv = new Servicios();

            //var lst = new List<vmEtiquetasReporte>();
            //lst = sv.LlenaEtiquetas(lblEntrada.Text.Trim(), sucEntrada.SelectedValue.ToString().Trim());
           // rp.lstrep = lst;
            
                

            for (int i = 1; i <=Convert.ToInt32(bultos.Text); i++)
            {
                string ett="";
                if (tipodeDocumento == 2)
                {
                    ett = sucEntrada.SelectedValue.ToString().Trim() + "-" + lblEntrada.Text.ToString().Trim() + "-" + i.ToString().Trim();
                }
                if (tipodeDocumento == 1)
                {
                    ett = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada.ToString().Trim() + "-" + i.ToString().Trim();
                }
                
                
                string folder = path + "\\barcode\\";
                string fullFilePath = folder + ett.Trim()+ ".png";

               
                rp.repTOrigen = sucEntrada.SelectedValue.ToString().Trim();
                rp.repTdest = sucDestino.SelectedValue.ToString().Trim();
                rp.repTCliente = cliente.Text.Trim();
                rp.repTEtiqueta = ett;
                rp.repTEntrada = lblEntrada.Text.ToString().Trim();
                rp.repTFecha = lblFecha.Text.Trim();
                rp.repTAlias = alias.Text;
                rp.repTBar = fullFilePath;
                rp.ShowDialog();

            }

              
            

        }



        private void Crea_codigo_de_barras()
        {
            


            for (int i = 1; i <= Convert.ToInt32(bultos.Text); i++)
            {
                string eti = sucEntrada.SelectedValue.ToString().Trim() + "-" + datoEntrada.ToString().Trim() + "-" + i.ToString().Trim();
               // byte[] code;
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                System.Drawing.Image imge = b.Encode(BarcodeLib.TYPE.CODE128, eti.Trim(), Color.Black, Color.White, 250, 40);


                Guarda_el_codigodebarras_en_img_local(imge, eti);
            }

        }
        private void Guarda_el_codigodebarras_en_img_local(System.Drawing.Image bar, string etiqueta)
        {
            using (var ms = new MemoryStream())
            {
                bar.Save(ms, ImageFormat.Png);
                byte[] imgbyte = ms.ToArray();


                string path = AppDomain.CurrentDomain.BaseDirectory;
                string folder = path + "\\barcode\\";
                string fullFilePath = folder + etiqueta+".png";

                if (File.Exists(fullFilePath))
                    File.Delete(fullFilePath);

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);



               File.WriteAllBytes(fullFilePath, imgbyte);

                //Process.Start(fullFilePath);

            }
        }

    }
}
