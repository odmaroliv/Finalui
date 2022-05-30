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

            if (pictureBox2.Image == null)
            {
                pictureBox2.Image = img;
                pictureBox2.ImageLocation = ruta;
            }
            else if (pictureBox3.Image == null)
            {
                pictureBox3.Image = img;
                pictureBox3.ImageLocation = ruta;
            }
            else if (pictureBox4.Image == null)
            {
                pictureBox4.Image = img;
                pictureBox4.ImageLocation = ruta;
            }
            else if (pictureBox5.Image == null)
            {
                pictureBox5.Image = img;
                pictureBox5.ImageLocation = ruta;
            }
            else if (pictureBox6.Image == null)
            {
                pictureBox6.Image = img;
                pictureBox6.ImageLocation = ruta;
            }
            else if (pictureBox7.Image == null)
            {
                pictureBox7.Image = img;
                pictureBox7.ImageLocation = ruta;
            }
            else if (pictureBox8.Image == null)
            {
                pictureBox8.Image = img;
                pictureBox8.ImageLocation = ruta;
            }
            else if (pictureBox9.Image == null)
            {
                pictureBox9.Image = img;
                pictureBox9.ImageLocation = ruta;
            }
            else if (pictureBox10.Image == null)
            {
                pictureBox10.Image = img;
                pictureBox10.ImageLocation = ruta;
            }
            else if (pictureBox11.Image == null)
            {
                pictureBox11.Image = img;
                pictureBox11.ImageLocation = ruta;
            }
            else if (pictureBox12.Image == null)
            {
                pictureBox12.Image = img;
                pictureBox12.ImageLocation = ruta;
            }
            else if (pictureBox13.Image == null)
            {
                pictureBox13.Image = img;
                pictureBox13.ImageLocation = ruta;
            }
            else if (pictureBox14.Image == null)
            {
                pictureBox14.Image = img;
                pictureBox14.ImageLocation = ruta;
            }
            else if (pictureBox15.Image == null)
            {
                pictureBox15.Image = img;
                pictureBox15.ImageLocation = ruta;
            }
            

        }

        
        private void iconButton2_Click(object sender, EventArgs e) //lo utiliazmos para pasar las imagenes del form camara al forma alta de entrada <Tiene que conectarse con CAM2>
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.InitialDirectory = "@C:\\";
            openFileDialog1.Filter = "Solo imagenes (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF"; ;

            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] imagen = openFileDialog1.FileNames;

                    foreach (var i in imagen)
                    {
                        ejecutarfoto(System.Drawing.Image.FromFile(i),i.ToString());
                         
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
                CreaEriquetas();
                EnviarEmail servicio = new EnviarEmail();
                var respuesta = servicio.EnviaMail(label41.Text, cliente.Text, tbxRastreo.Text, alias.Text, ordenCompra.Text, numFlete.Text, proveedor.Text, detalles.Text, mnd, larch);
                if (respuesta == 1)
                {
                    MessageBox.Show("El correo NO SE ENVIÓ PORQUE supera el límite máximo de 25 MB en cada correo, intenta borrar documentos y reenvía la notificación", "CUIDADO EL CORREO NO SE ENVIO");
                }
                else
                {
                    MessageBox.Show("Correo enviado con éxito", "éxito!");
                }
                // servicio.EnviaMail(label41.Text, cliente.Text, tbxRastreo.Text, alias.Text, ordenCompra.Text, numFlete.Text, proveedor.Text, detalles.Text,mnd);
                cargaultent();
            }

        }

        private void altaKDM1()
        {
            AltasBD bd = new AltasBD();

            string datoSucIni = sucEntrada.SelectedValue.ToString();
            string datoEntrada = recuperUltimaent();
            string datoMoneda = cmbMoneda.GetItemText(cmbMoneda.SelectedItem).ToString();
            DateTime datoFecha = regresafecha();
            string datoNuCliente = lblCodCliente.Text; // agregar numero de cliente
            string datoNoCord = cord.SelectedValue.ToString();
            decimal datoValArn = Convert.ToDecimal(txbValArn.Text);
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
                            System.Drawing.Image imge = b.Encode(BarcodeLib.TYPE.CODE128,etiqueta.ToString(), Color.Black, Color.White, 250, 40);
                            iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(imge, System.Drawing.Imaging.ImageFormat.Png);
                            img2.ScaleToFit(250, 40);
                            img2.Alignment = iTextSharp.text.Image.ALIGN_CENTER;

                            //img.SetAbsolutePosition(10,100);
                           img2.SetAbsolutePosition(20,20);
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

        private void AltaEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {

        }





        private async void llenaCampos()
        {
            try
            {
                Servicios datos = new Servicios();
                var lst2 =  datos.llenaSuc();

                sucEntrada.DisplayMember = "C2";
                sucEntrada.ValueMember = "C1";
                sucEntrada.DataSource = lst2;

                cargaultent();

                var lst1 = await datos.llenaCord();
                cord.ValueMember = "C2";
                cord.DisplayMember = "C3";
                cord.DataSource = lst1;



                List<Sucursales> lst3 = new List<Sucursales>(lst2); //clonamos la lista anterior para no volver a hacer la busqueda en la base de datos 

                //var lst3 = sucEntrada.DataSource;
                sucDestino.DisplayMember = "C2";
                sucDestino.ValueMember = "C1";
                sucDestino.DataSource = lst3;

                var lst4 =  datos.llenaProveedores();

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

        public void moverinfo(string dato, string dato2, string dato3, string dato4, string dato5, string dato6,string dato7, int bandera) //cambia los datos de los textbox alias y clientes, la bandera dependera de la manera en la que se haya abierto el frm buscar, 0 clientes 1 alias, ADEMAS tambien sirve para cambiar el campo de cord
        {

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
    }
}
