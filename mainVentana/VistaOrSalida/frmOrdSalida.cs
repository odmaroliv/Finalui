using ClosedXML.Excel;
using Datos.Datosenti;
using Datos.ViewModels;
using Datos.ViewModels.hooks;
using Datos.ViewModels.Salidas;
using Datos.ViewModels.Servicios;
using Guna.UI.WinForms;
using iTextSharp.text.pdf.qrcode;
using mainVentana.reportes.vmreportes;
using mainVentana.VistaEntrada;
using Microsoft.Win32;
using Negocios;
using Negocios.Acceso_Salida;
using Negocios.LOGs;
using Negocios.NGCotizacion;
using Negocios.Odoo;
using Negocios.WebHooks;
using OfficeOpenXml;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ventana1;
using Ventana1.vm;

namespace mainVentana.VistaOrSalida
{
    public partial class frmOrdSalida : Form
    {
        string ulSalidaPSolo = "";
        string ulDato = "";
        string ulDatoSolo = "";
        string sOrigen = "";
        string sDestino = "";
        int iniciodesalida = 0;
        private SoundPlayer alertaNoCargaPlayer;
        private SoundPlayer alertaBienPlayer;
        private bool _noCarga = false;

        private readonly OdooClient _odooClient;
        enum ModoAltakdment
        {
            Alta,
            Baja
        }
        enum EnumScaneadas
        {
            EscaneadasBien,
            EscaneadasMal
        }

        public frmOrdSalida()
        {
            InitializeComponent();
            try
            {
                alertaNoCargaPlayer = new SoundPlayer(Properties.Resources.AlertaNoCargaArsys);
                alertaBienPlayer = new SoundPlayer(Properties.Resources.AlertaBienArsys);
            }
            catch (Exception)
            {
                // Aquí puedes manejar el error si los archivos de sonido no pueden ser cargados
            }
            _odooClient = new OdooClient();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            using (frmBuscarOrdCarga oc = new frmBuscarOrdCarga())
            {
                oc.pasado += new frmBuscarOrdCarga.pasar(agrgaCargatabla);
                oc.cerrado += new frmBuscarOrdCarga.cerrar(BuscaentradasCarga);
                oc.sOrigen = sOrigen;
                oc.sucsdest = sDestino;
                oc.ShowDialog();
                oc.pasado -= new frmBuscarOrdCarga.pasar(agrgaCargatabla);
                oc.cerrado -= new frmBuscarOrdCarga.cerrar(BuscaentradasCarga);

            }


        }
        List<string> lst = new List<string>();
        private void agrgaCargatabla(string dato)
        {

            if (dgvListaCargas.Rows.Count > 0)
            {
                int bandera = 0;
                foreach (DataGridViewRow i in dgvListaCargas.Rows)
                {
                    if (i.Cells[0].Value.ToString().Trim() == dato)
                    {
                        bandera = 1;

                    }
                    else
                    {
                        bandera = 0;

                    }
                }

                if (bandera == 1)
                {
                    MessageBox.Show("Esa orden ya esta cargada");
                }
                else
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvListaCargas);

                    row.Cells[0].Value = dato;


                    dgvListaCargas.Rows.Add(row);
                }

            }
            else if (dgvListaCargas.Rows.Count == 0)
            {

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvListaCargas);

                row.Cells[0].Value = dato;


                dgvListaCargas.Rows.Add(row);

            }



        }

        private void gunaGradientTileButton2_Click(object sender, EventArgs e)
        {
            VistaEntrada.Desbloqueo buscador = new Desbloqueo();

            buscador.cambiar += new Desbloqueo.cambio(IniSalida);
            buscador.ShowDialog();
           
        }

        private void BuscaUltimaSalida(string suc)
        {
            if (ulSalidaPSolo == "")
            {
                if (iniciodesalida == 0)
                {

                    //List<string> lista1 = new List<string>();
                    Negocios.Acceso_Salida.AccesoSalidas sls = new Negocios.Acceso_Salida.AccesoSalidas();
                    var lista1 = sls.BuscUltimaSalida(suc, 45);


                    foreach (var i in lista1)
                    {
                        int sl = Convert.ToInt32(i.salida.ToString());
                        ulDato = sOrigen + "-UD4501-" + sl.ToString("D7");
                        lblSalida.Text = ulDato;
                        ulDatoSolo = sl.ToString("D7");
                    }
                    iniciodesalida = 1;// establece el numero de salida en el actual
                }
            }
            else
            {
                char[] ch = "-".ToCharArray();
                string sl = ulSalidaPSolo.Split(ch)[2];
                ulDato = sOrigen + "-UD4501-" + sl;
                lblSalida.Text = ulDato;
                ulDatoSolo = sl.ToString();
            }




        }





        private void BuscaUltimaSalidaFull(string suc)
        {
          
              
                    //List<string> lista1 = new List<string>();
                    Negocios.Acceso_Salida.AccesoSalidas sls = new Negocios.Acceso_Salida.AccesoSalidas();
                    var lista1 = sls.BuscUltimaSalida(suc, 45);


                    foreach (var i in lista1)
                    {
                        int sl = Convert.ToInt32(i.salida.ToString());
                        ulDato = sOrigen + "-UD4501-" + sl.ToString("D7");
                        lblSalida.Text = ulDato;
                        ulDatoSolo = sl.ToString("D7");
                    }
                    iniciodesalida = 1;// establece el numero de salida en el actual
                
          

        }








        public void ActualizaSqlIov(string datoSucIni, int modo, string dato)
        {


            string br = "KFUD" + modo + "01." + datoSucIni;
            using (modelo2Entities modelo = new modelo2Entities())
            {

                try
                {
                    modelo.aumentaSQLint(br, modo.ToString().Trim());
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Ha Ocurrido un error, datos faltantes o incorrectos.");
                }
            }
        }

        private void ValidaOrigen(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Name == "rbOTJ")
            {
                sOrigen = "TJ";
                lblSalida.ForeColor = Color.Blue;

            }
            if (rb.Name == "rbOCSL")
            {
                sOrigen = "CSL";
                lblSalida.ForeColor = Color.DarkViolet;

            }
            if (rb.Name == "rbOSD")
            {
                sOrigen = "SD";
                lblSalida.ForeColor = Color.Red;

            }
            iniciodesalida = 0;
            BuscaUltimaSalida(sOrigen);

        }
        private void ValidaDestino(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Name == "rbDTJ")
            {
                sDestino = "TJ";


            }
            if (rb.Name == "rbDCSL")
            {
                sDestino = "CSL";

            }
            if (rb.Name == "rbDSD")
            {
                sDestino = "SD";

            }


        }

        private void dgvListaCargas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            if (MessageBox.Show("Seguro que quieres borrar la fila: " + this.dgvListaCargas.SelectedRows[0].Index, "Cuidado!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (this.dgvListaCargas.SelectedRows.Count > 0)
                {
                    dgvListaCargas.Rows.RemoveAt(this.dgvListaCargas.SelectedRows[0].Index);
                    BuscaentradasCarga();
                }
            }


        }
        List<vmEntByCarga> lista = new List<vmEntByCarga>();
        private async void BuscaentradasCarga()
        {
            Servicios datos = new Servicios();

            dgvOrdenesEntrada.DataSource = null;
            


            lista.Clear();
            foreach (DataGridViewRow i in dgvListaCargas.Rows)
            {
                lista.AddRange(await datos.CargaEntByCarga(i.Cells[0].Value.ToString().Trim(), sOrigen));

            }
            for (int i = 0; i < dgvListaCargas.Rows.Count; i++)
            {
                
            }
            //ValidatablaObserva();
            Validatabla();
            ValidatablaObserva();
            dgvOrdenesEntrada.DataSource = lista;

            new Guna.UI.Lib.ScrollBar.DataGridViewScrollHelper(dgvOrdenesEntrada, gsbCargaEti, true);

            datos = null;






        }

        private void GeneraExcel()
        {
            if (_noCarga==false && dgvEscaneados.Rows.Count <= 0)
            {
                MessageBox.Show("No hay datos para Enviar");
                return;
            }

            List<vmEnviodeNotificacion> list = new List<vmEnviodeNotificacion>();
            int filasE = dgvEscaneados.Rows.Count;
            int filasA = dgvObser.Rows.Count;
            int filasO = dgvOrdenesEntrada.Rows.Count;

            list.Add(new vmEnviodeNotificacion { OrdenSalidaAplicada = ulDato });
            if (_noCarga == false)
            {
                for (int i = 0; i < filasE; i++)
                {

                    list.Add(new vmEnviodeNotificacion
                    {

                        Etiqueta = dgvEscaneados.Rows[i].Cells[0].Value == null ? "" : dgvEscaneados.Rows[i].Cells[0].Value.ToString().Trim(),
                        Pertenece = dgvEscaneados.Rows[i].Cells[1].Value == null ? "" : dgvEscaneados.Rows[i].Cells[1].Value.ToString().Trim(),
                        Correo = dgvEscaneados.Rows[i].Cells[2].Value == null ? "" : dgvEscaneados.Rows[i].Cells[2].Value.ToString().Trim(),

                    });
                }
            }
            
            for (int i = 0; i < filasA; i++)
            {

                list.Add(new vmEnviodeNotificacion
                {
                    Etiqueta = dgvObser.Rows[i].Cells[0].Value == null ? "" : dgvObser.Rows[i].Cells[0].Value.ToString().Trim(),
                    notas = _noCarga == true ? "Salida creada sin Orden de Carga" : "Esta entrada no se encontro en ninguna orden cargada en esta salida (Pordria no existir)",
                    Correo = dgvObser.Rows[i].Cells[2].Value == null ? "sistemas@arnian.com" : dgvObser.Rows[i].Cells[2].Value.ToString().Trim()

                });


            }
            if (_noCarga==false)
            {
                for (int i = 0; i < filasO; i++)
                {
                    list.Add(new vmEnviodeNotificacion
                    {
                        Etiqueta = dgvOrdenesEntrada.Rows[i].Cells[0].Value == null ? "" : dgvOrdenesEntrada.Rows[i].Cells[0].Value.ToString().Trim(),
                        NoCargadas = "ESTA ETIQUETA NO FUE ESCANEADA EN ESTA SALIDA A PESAR DE ESTAR EN LAS ÓRDENES DE CARGA."

                        //Correo = string.IsNullOrEmpty(dgvObser.Rows[i].Cells[2].Value.ToString()) ? "" : dgvObser.Rows[i].Cells[2].Value.ToString().Trim(),

                    });


                }

            }



            GeneraCorreo(list);

        }


        private async void GeneraCorreo(List<vmEnviodeNotificacion> dato)
        {


            var correos = new HashSet<string>(dato.Select(d => d.Correo).ToList()).ToList();


            List<vmEnviodeNotificacion> lss = new List<vmEnviodeNotificacion>();
            


            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folder = path + "\\temp\\";
            string hoy = DateTime.Now.ToString("dd-MM-yyyy");
            string fullPath = folder + hoy + "-Salida-" + ulDato + ".xlsx";

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);


            

            new frmOrdSalida().Export<vmEnviodeNotificacion>(dato, fullPath, "salida");
            //  await llamasmtp(mensaje, q, fullPath);
            
            

            string plantilla = Properties.Resources.salidacorreo.ToString();
            plantilla = plantilla.Replace("@nSalida", ulDato);



            int bandera = 0;
            List<string> lscorreos = new List<string>();

            foreach (var q in correos)
            {
                if (!string.IsNullOrEmpty(q))
                {
                    if (q!=null)
                    {
                        lscorreos.Add(q);
                    }

                    //bandera = bandera + 1;
                }

            }
            String[] str = lscorreos.ToArray();

            try
            {
                await llamasmtp(plantilla, str, fullPath, ulDato, bandera);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo enviar el correo con el Excel");
            }
          
        }
        private async Task llamasmtp(string body, string[] correo, string path, string salida, int bndra)
        {
            using (MailMessage msg = new MailMessage())
            {
                SmtpClient smtp = new SmtpClient();
                msg.IsBodyHtml = true;
                msg.From = new MailAddress(Negocios.Common.Cache.CacheLogin.smtpemail);
                msg.Subject = "Salida: " + salida;

                msg.IsBodyHtml = true;
                using (StringReader sr = new StringReader(body))
                {
                    msg.Body = sr.ReadToEnd().ToString();
                }

                msg.To.Add(new MailAddress("sistemas@arnian.com"));

                var corrr = string.Join(",", correo);
                if (corrr != "")
                {
                    string[] toCC = corrr.Split(',');
                    foreach (string ToCCId in toCC)
                    {
                        try
                        {
                            MailAddress mailAddress = new MailAddress(ToCCId);
                            msg.CC.Add(mailAddress);
                        }
                        catch (FormatException)
                        {
                            // La dirección de correo electrónico no es válida
                            // Descarta la dirección
                        }
                    }
                }

                if (bndra == 0)
                {
                    //msg.CC.Add(new MailAddress("susano.limon@arnian.com"));
                    //msg.CC.Add(new MailAddress("sistemas@arnian.com"));
                    msg.CC.Add(new MailAddress("operaciones@arnian.com"));
                    //msg.CC.Add(new MailAddress("operaciones@arnian.com"));
                }

                msg.Attachments.Add(new Attachment(path));

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                NetworkCredential nc = new NetworkCredential(Negocios.Common.Cache.CacheLogin.smtpemail, Negocios.Common.Cache.CacheLogin.smatppss);
                smtp.Credentials = nc;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                try
                {
                    await smtp.SendMailAsync(msg);
                }
                catch (Exception)
                {

                    MessageBox.Show("Existe un problema con los correos, es probable que tengan un formato incorrecto, no he podido enviar el correo, pero las entradas se han agregado a la orden, correctamente; te recomiendo verificarlo");
                }
              

            }

        }

        public bool Export<T>(List<T> list, string file, string nombre)
        {
            bool exportado = false;
            using (XLWorkbook xlfile = new XLWorkbook())
            {
                xlfile.AddWorksheet(nombre).FirstCell().InsertTable<T>(list, false);
                //xlfile.Worksheets.Add("Reporte");
                //xlfile.Table("Reporte").ShowAutoFilter = false;// Disable AutoFilter.
                //xlfile.Table(nombre).Theme = XLTableTheme.TableStyleDark5;// Remove Theme.
                xlfile.SaveAs(file);
                exportado = true;
               
            }
            return exportado;
        }

        private void Validatabla()
        {
            /*
            foreach (DataGridViewRow i in dgvEscaneados.Rows)
            {

                foreach (var e in lista)
                {
                    if (e.Etiqueta.Trim() == (i.Cells[0].Value.ToString().Trim()))
                    {
                        int index = lista.FindIndex(a => a.Etiqueta.Trim().Contains(i.Cells[0].Value.ToString().Trim()));
                        lista.RemoveAt(index);
                        break;
                    }
                }
            }
            */
            foreach (DataGridViewRow i in dgvEscaneados.Rows)
            {
                var etiqueta = i.Cells[0].Value.ToString().Trim();
                var index = lista.FindIndex(a => a.Etiqueta.Trim().Contains(etiqueta));
                if (index != -1)
                {
                    lista.RemoveAt(index);
                }
            }
        }

        private void ValidatablaObserva()
        {
            /*
            List<vmEntByCarga> lst2 = new List<vmEntByCarga>();
            foreach (DataGridViewRow i in dgvListaCargas.Rows)
            {
                lst2.Add(new vmEntByCarga { Carga = i.Cells[0].Value.ToString().Trim() });
            }
            List<vmEntByCarga> lst3 = new List<vmEntByCarga>();
            foreach (DataGridViewRow i in dgvEscaneados.Rows)
            {
                lst3.Add(new vmEntByCarga { Carga = i.Cells[1].Value == null?"No se encontro": i.Cells[1].Value.ToString().Trim(), Etiqueta = i.Cells[0].Value == null ? "": i.Cells[0].Value.ToString().Trim() });
            }
            //var noExistewn = (from t in lst3 where lst2.Select(x=>x.Carga).Any(t.Carga.Trim()!=) select t).ToList();
            var noExisten = lst3.Where(ds => !lst2.Any(db => db.Carga == ds.Carga)).ToList();


            foreach (var i in noExisten)
            {

                int fila = -1;

                int roww = 0;
                string dato = i.Etiqueta;
                foreach (DataGridViewRow e in dgvEscaneados.Rows)
                {
                    string etiquetaD = e.Cells[0].Value.ToString().Trim();
                    if (etiquetaD == dato)
                    {                      
                        fila = e.Index;
                        dgvEscaneados.Rows.RemoveAt(e.Index);
                    
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dgvObser);

                        row.Cells[0].Value = dato;
                        row.Cells[1].Value = "No se encotro en ninguna Orden Cargada en este documento";
                        row.Cells[2].Value = e.Cells[2].Value.ToString().Trim();
                        dgvObser.Rows.Add(row);
                        roww = roww + 1;
                        break;
                    }
                    else
                    {
                      
                    }
                }
            }
            */
            var cargas = dgvListaCargas.Rows.Cast<DataGridViewRow>().Select(row => row.Cells[0].Value.ToString().Trim()).ToList();
            var escaneados = dgvEscaneados.Rows.Cast<DataGridViewRow>().Select(row => new vmEntByCarga { Carga = row.Cells[1].Value == null ? "No se encontro" : row.Cells[1].Value.ToString().Trim(), Etiqueta = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString().Trim() }).ToList();
            var noExisten = escaneados.Where(vm => !cargas.Contains(vm.Carga)).ToList();

            foreach (var noExistente in noExisten)
            {
                var row = dgvEscaneados.Rows.Cast<DataGridViewRow>().FirstOrDefault(ro => ro.Cells[0].Value.ToString().Trim() == noExistente.Etiqueta);
                if (row == null) continue;

                dgvEscaneados.Rows.RemoveAt(row.Index);

                var newRow = new DataGridViewRow();
                newRow.CreateCells(dgvObser);

                newRow.Cells[0].Value = noExistente.Etiqueta;
                newRow.Cells[1].Value = _noCarga==true?"Sin orden de carga" : "No se encotro en ninguna Orden Cargada en este documento";
                newRow.Cells[2].Value = row.Cells[2].Value.ToString().Trim();
                dgvObser.Rows.Add(newRow);
            }

        }


        private async void btnScanini_Click(object sender, EventArgs e)
        {
            int result = await ConeccionRed.TestInternet();

            if (result == 1)
            {
                MessageBox.Show("No tienes internet");
                return;
            }

            if (btnIniciaSalida.Enabled == true)
            {
                MessageBox.Show("Primero tienes que Iniciar la salida");
                return;
            }

            int error = ValidacionesGenerales(); //1 error o 0 normal
           

            if (error == 1)
            {
                return;
            }

            if (MessageBox.Show("Estas apunto de iniciar el Scaneo, revisa las Ordenes para evitar errores, da click en Cancelar para dar un segundo vistazo", "Atencion", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ModificaKDM1();
                txbEscaneo.Enabled = true;
                txbEscaneo.Focus();

            }

        }

        private void txbEscaneo_Leave(object sender, EventArgs e)
        {
            if (MessageBox.Show("para dejar de scannear dá click en CANCELAR", "Cuidado", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                txbEscaneo.Focus();
            }
        }

        private int ValidacionesGenerales()
        {
            int error = 0;
            if (_noCarga == false)
            {
                if (dgvListaCargas.RowCount == 0)
                {
                    MessageBox.Show("No se han seleccionado Cargas");
                    error = 1;
                }
            }
           
            if (sOrigen == "")
            {
                MessageBox.Show("Es necesario selccionar una sucursal de Origen");
                error = 1;
            }
            if (sDestino == "")
            {
                MessageBox.Show("Es necesario selccionar una sucursal de Destino");
                error = 1;
            }
            if (sDestino == sOrigen)
            {
                MessageBox.Show("Las sucursales no pueden ser las mismas");
                error = 1;
            }
            if (txbReferencia.Text.Trim() == "" || txbReferencia.Text.Length < 2)
            {
                MessageBox.Show("Es necesario agregar una referencia");
                error = 1;
            }

            return error;
        }
        private Queue<string> colaEtiquetas = new Queue<string>();
       

        private void txbEscaneo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            var etiqueta = txbEscaneo.Text?.Trim()?.ToUpper()?.Replace("'", "-");
            txbEscaneo.Text = "";

            colaEtiquetas.Enqueue(etiqueta);
            ProcesadoColaEtiquetas();
        }

        private void ProcesadoColaEtiquetas()
        {
            while (colaEtiquetas.Count > 0)
            {
                var etiqueta = colaEtiquetas.Dequeue();
                ProcesadoEtiqueta(etiqueta);
            }
        }


        private void ProcesadoEtiqueta(string etiqueta)
        {
            if (string.IsNullOrEmpty(etiqueta))
            {
                lblMensaje.Text = "Etiqueta no válida";
                //txbEscaneo.Text = "";
                return;
            }

            if (dgvEscaneados.Rows.Cast<DataGridViewRow>().Any(r => r.Cells[0].Value.ToString().Trim() == etiqueta))
            {
                lblMensaje.Text = "La etiqueta " + etiqueta + " ya está en la tabla principal";
                //txbEscaneo.Text = "";
                return;
            }

            if (dgvObser.Rows.Cast<DataGridViewRow>().Any(r => r.Cells[0].Value.ToString().Trim() == etiqueta))
            {
                lblMensaje.Text = "La etiqueta " + etiqueta + " ya está en la tabla de Obs";
                // txbEscaneo.Text = "";
                return;
            }

            var sls = new Negocios.Acceso_Salida.AccesoSalidas();
            var index = lista.FindIndex(a => a.Etiqueta.Trim().Contains(etiqueta));

            if (index == -1)
            {
                RepSonido(0);
                if (sOrigen != "TJ")
                {
                    if (_noCarga==false)
                    {
                        if (MessageBox.Show("Se agregara la etiqueta: \n" + etiqueta + "\nVolver a preguntar?", "Cuidado", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            RepSonido(0);
                            if (MessageBox.Show("Deseas agregar esta etiqueta a la salida?\n" + etiqueta, "Cuidado", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                   
                }
               
                AltKDMENT(etiqueta,ModoAltakdment.Alta);
                GeneralMovimientosLog.AddMovimientoConParametrosDirectos(GeneralMovimientosLog.ObtenerFolioDesdeEtiqueta(etiqueta), 35, etiqueta, 45, ulDatoSolo, sOrigen, sDestino,"", "Scaneo","","Se agrega a la salida "+ulDatoSolo);
                



                var cO = sls.ObtieCorreo(etiqueta, sOrigen.Trim());
                _odooClient.UpdateCurrentSalida(cO.OdooIdProductos, ulDato);
                var obsRow = new DataGridViewRow();
                obsRow.CreateCells(dgvObser);
                obsRow.Cells[0].Value = etiqueta;
                obsRow.Cells[1].Value = _noCarga == true?"Salida sin Carga" : "Esta etiqueta no se encontró en ninguna Orden Cargada en este documento";
                obsRow.Cells[2].Value = cO;
                dgvObser.Rows.Add(obsRow);
                lblMensaje.Text = "Etiqueta: " + etiqueta + " no se encontró en las ordenes cargadas";
            }
            else
            {
                AltKDMENT(etiqueta, ModoAltakdment.Alta);
                GeneralMovimientosLog.AddMovimientoConParametrosDirectos(GeneralMovimientosLog.ObtenerFolioDesdeEtiqueta(etiqueta), 35, etiqueta,45, ulDatoSolo, sOrigen,sDestino,"","Scaneo","", "Se agrega a la salida " + ulDatoSolo);
                RepSonido(1);


                var cOr = sls.ObtieCorreo(etiqueta, sOrigen.Trim());
                _odooClient.UpdateCurrentSalida(cOr.OdooIdProductos, ulDato);
                lista.RemoveAt(index);
                dgvOrdenesEntrada.DataSource = null;
                dgvOrdenesEntrada.DataSource = lista;

                var row = new DataGridViewRow();
                row.CreateCells(dgvEscaneados);
                row.Cells[0].Value = string.IsNullOrEmpty(cOr.Etiqueta) ? "La etiqueta: " + etiqueta + " No se encontró en la Base de Datos" : cOr.Etiqueta.Trim(); ;
                row.Cells[1].Value = string.IsNullOrEmpty(cOr.orden) ? "" : cOr.orden.Trim();
                row.Cells[2].Value = string.IsNullOrEmpty(cOr.Correo) ? "" : cOr.Correo.Trim();
                dgvEscaneados.Rows.Add(row);
                lblMensaje.Text = "Etiqueta: " + etiqueta + " agregada correctamente";
                lblTotalFaltantes.Text = dgvOrdenesEntrada.Rows.Count.ToString();
            }

            //  txbEscaneo.Text = "";
        }
        private async void RepSonido(int modo)
        {
            await Task.Run(() => {
                try
                {
                    if (modo == 0)
                    {
                        alertaNoCargaPlayer.Play();
                    }
                    else
                    {
                        alertaBienPlayer.Play();
                    }
                }
                catch (Exception)
                {
                    // Aquí puedes manejar el error si el sonido no puede ser reproducido
                }
            });


        }
        

        private async void CreaSalidaEnKDM1()
        {

            string estatuss = default;
            estatuss = "PS" + sOrigen.Trim();
            /* if (sOrigen.Trim() == "TJ")
             {
                 estatuss = "PSTJ";
             }
             if (sOrigen.Trim() == "SD")
             {
                 estatuss = "PSSD";
             }
             if (sOrigen.Trim() == "CSL")
             {
                 estatuss = "PSCSL";
             }
            */
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            BuscaUltimaSalidaFull(sOrigen);
            ActualizaSqlIov(sOrigen.Trim(), 45, ulDatoSolo.Trim());
            Negocios.AltasBD at = new AltasBD();
            bool resultado = await at.CSalidaEnKDM1(sOrigen
                , "U"
                , "D"
                , Convert.ToDecimal(45)
                , Convert.ToDecimal(1)
                , ulDatoSolo
                , Convert.ToDecimal(1)
                , DateTime.Now
                , txbReferencia.Text
                , 1
                , DateTime.Now
                , "Notas"
                , "Ord"
                , estatuss
                , "UD4501-"
                , Negocios.Common.Cache.CacheLogin.username.ToString()
                , DateTime.Now
                , txbTransportista.Text.Length >= 100 ? txbTransportista.Text.Substring(0, 100) : txbTransportista.Text
                , txbPlacas.Text.Length >= 50 ? txbPlacas.Text.Substring(0, 50) : txbPlacas.Text
                , txbChofer.Text.Length >= 100 ? txbChofer.Text.Substring(0, 100) : txbChofer.Text
                , sDestino);

            if (resultado == false)
            {
                ActualizaSqlIov(sOrigen.Trim(), 45, ulDatoSolo.Trim());
            }

            btnIniciaSalida.Enabled = false;
            bntSalidaPausa.Enabled = false;

        }

        private async Task ModificaKDM1()
        {


            
            Negocios.AltasBD at = new AltasBD();
           
            foreach (DataGridViewRow q in dgvListaCargas.Rows)
            {

                char[] ch = "-".ToCharArray();
                string datosalida = ulSalidaPSolo == "" ? ulDatoSolo : ulSalidaPSolo.Split(ch)[2];
                string dato = q.Cells[0].Value.ToString().Trim();
                string datolimpio = dato.Split(ch)[2];
                await at.ModificaStatusSalida(sOrigen,datosalida, datolimpio);


            }


            btnIniciaSalida.Enabled = false;
            bntSalidaPausa.Enabled = false;

        }

        private async Task FinalizaSalidaKDM1()
        {

           int  error = ValidacionesGenerales();


            if (error == 1)
            {
                return;
            }

            else
            {
                BuscaUltimaSalida(sOrigen);
                Negocios.AltasBD at = new AltasBD();
                char[] ch = "-".ToCharArray();
                string datosalida = ulSalidaPSolo == "" ? ulDatoSolo : ulSalidaPSolo.Split(ch)[2];
                await at.TerminaSalida(ulDatoSolo,sOrigen);
            }
        }



        private async void AltKDMENT(string etiqueta, ModoAltakdment modo, GunaDataGridView tipoTabla = null)
        {
            // Casos especiales donde se ejecuta ModificaKDMENTtj
            if ((sDestino == "SD" && sOrigen == "TJ") || (sDestino == "CSL" && sOrigen == "TJ"))
            {
                
                    if (modo == ModoAltakdment.Alta)
                    {
                    await ModificaKDMENTtj(etiqueta);
                    }
                    else if (modo == ModoAltakdment.Baja)
                {
                    await ModificaKDMENTBajatj(etiqueta);
                    EliminarFilaPorEtiqueta(etiqueta,tipoTabla);
                    MessageBox.Show("Se dio de baja","Alerta");
                }




            }
            // Todos los demás casos ejecutan ModificaKDMENTsd
            else
            {
                if (modo == ModoAltakdment.Alta)
                {
                    await ModificaKDMENTsd(etiqueta);
                }
                else if (modo == ModoAltakdment.Baja)
                {
                    await ModificaKDMENTBajasd(etiqueta);
                    EliminarFilaPorEtiqueta(etiqueta, tipoTabla);
                    MessageBox.Show("Se dio de baja", "Alerta");
                }
            }
        }

        //Sucursal destino cabo sucursal origen tijuana
        private async Task<bool> ModificaKDMENTtj(string etiqueta)
        {
            string uld = (string)ulDato.Trim().Clone();
            string sc = sDestino == "CSL" ? "PR" : "OC";

            return await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    try
                    {

                        var d = (from fd in modelo.KDMENT
                                 where fd.C9 == etiqueta.ToUpper().Trim()
                                 select fd).FirstOrDefault();

                        if (d != null)
                        {

                            d.C19 = sOrigen;
                            d.C20 = sc;
                            d.C23 = "";
                            d.C55 = uld;
                            d.C63 = uld;
                            d.C64 = uld;
                            d.C65 = "E";
                            d.C75 = DateTime.Now.ToString("MM/dd/yyyy");


                            modelo.SaveChanges();
                            return true; // Devuelve true si se actualizó exitosamente
                        }
                        else
                        {

                            Negocios.LOGs.ArsLogs.LogEdit("Etiqueta no encontrada: " + etiqueta, "Escaneo de Etiqueta");
                            MessageBox.Show("Etiqueta no encontrada, por favor contacte al administrador.");
                            return false;
                        }
                    }
                    catch (Exception x)
                    {

                        Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Escaneo de Etiqueta " + etiqueta);
                        MessageBox.Show("Ocurrió un error, por favor no continúe escaneando y contacte al administrador.");
                        return false;
                    }
                }
            });
        }



        private async Task<bool> ModificaKDMENTBajatj(string etiqueta)
        {
            string uld = (string)ulDato.Trim().Clone();
            string sc = sDestino == "CSL" ? "PR" : "OC";

            return await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    try
                    {
                        // Selecciona el registro que cumple con la condición
                        var d = (from fd in modelo.KDMENT
                                 where fd.C9 == etiqueta.ToUpper().Trim()
                                 select fd).FirstOrDefault();

                        if (d != null)
                        {
                            // Actualiza los campos necesarios
                            d.C19 = sOrigen;
                            d.C20 = "OC";
                            d.C55 = "";
                            d.C63 = "";
                            d.C64 = "";
                            d.C65 = "";
                            d.C75 = DateTime.Now.ToString("MM/dd/yyyy");

                            // Guarda el cambio en la base de datos
                            modelo.SaveChanges();
                            return true; // Devuelve true si la actualización es exitosa
                        }
                        else
                        {
                            // Registra un error si no se encuentra el registro
                            Negocios.LOGs.ArsLogs.LogEdit("Etiqueta no encontrada: " + etiqueta, "Escaneo de Etiqueta");
                            MessageBox.Show("Etiqueta no encontrada, por favor contacte al administrador.");
                            return false;
                        }
                    }
                    catch (Exception x)
                    {
                        // Registra el error y muestra un mensaje de advertencia
                        Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Escaneo de Etiqueta " + etiqueta);
                        MessageBox.Show("Ocurrió un error, por favor no continúe escaneando y contacte al administrador.");
                        return false;
                    }
                }
            });
        }


        private async Task<bool> ModificaKDMENTsd(string etiqueta)
        {
            string sc = sDestino == "CSL" ? "PR" : "OC";
            string uld = (string)ulDato.Trim().Clone();

            return await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    try
                    {
                        // Selecciona el registro que cumple con la condición
                        var d = (from fd in modelo.KDMENT
                                 where fd.C9 == etiqueta.ToUpper().Trim()
                                 select fd).FirstOrDefault();

                        if (d != null)
                        {
                            // Actualiza los campos necesarios
                            d.C12 = "E";
                            d.C17 = uld;
                            d.C18 = "";
                            d.C19 = sOrigen;
                            d.C20 = sc;
                            d.C23 = "";
                            d.C55 = uld;
                            d.C56 = "";
                            d.C63 = "";
                            d.C64 = "";
                            d.C65 = "";
                            d.C66 = "";
                            d.C67 = "";
                            d.C68 = "";
                            d.C73 = DateTime.Now.ToString("MM/dd/yyyy");
                            d.C75 = "";

                            // Guarda los cambios en la base de datos
                            modelo.SaveChanges();
                            return true; // Devuelve true si la actualización es exitosa
                        }
                        else
                        {
                            // Registra un error si no se encuentra el registro
                            Negocios.LOGs.ArsLogs.LogEdit("Etiqueta no encontrada: " + etiqueta, "Escaneo de Etiqueta");
                            return false;
                        }
                    }
                    catch (Exception x)
                    {
                        // Registra el error y muestra un mensaje de advertencia
                        Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Escaneo de Etiqueta " + etiqueta);
                        return false;
                    }
                }
            });
        }

        private async Task<bool> ModificaKDMENTBajasd(string etiqueta)
        {
            string sc = sDestino == "CSL" ? "PR" : "OC";
            string uld = (string)ulDato.Trim().Clone();

            return await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    try
                    {
                        // Selecciona el registro que cumple con la condición
                        var d = (from fd in modelo.KDMENT
                                 where fd.C9 == etiqueta.ToUpper().Trim()
                                 select fd).FirstOrDefault();

                        if (d != null)
                        {
                            // Actualiza los campos necesarios
                            d.C12 = "";
                            d.C17 = "";
                            d.C19 = sOrigen;
                            d.C20 = "OC";
                            d.C55 = "";
                            d.C73 = DateTime.Now.ToString("MM/dd/yyyy");

                            // Guarda los cambios en la base de datos
                            modelo.SaveChanges();
                            return true; // Devuelve true si la actualización es exitosa
                        }
                        else
                        {
                            // Registra un error si no se encuentra el registro
                            Negocios.LOGs.ArsLogs.LogEdit("Etiqueta no encontrada: " + etiqueta, "Escaneo de Etiqueta");
                            return false;
                        }
                    }
                    catch (Exception x)
                    {
                        // Registra el error y muestra un mensaje de advertencia
                        Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Escaneo de Etiqueta " + etiqueta);
                        return false;
                    }
                }
            });
        }

        private void EliminarFilaPorEtiqueta(string etiqueta, GunaDataGridView dgv)
        {
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == etiqueta)
                    {
                        // Elimina la fila
                        dgv.Rows.Remove(row);
                        break; // Si solo esperas encontrar una coincidencia, usa break para salir del bucle
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }



        private void Notifica(int nttipo, string nsalida)
        {

            /*
             2 = ERROR
             1 = EXITO
            */


            if (nttipo == 1)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Text = nsalida + " CARGADA";
                notifyIcon1.BalloonTipTitle = "Sin Errores: Salida terminada " + nsalida;
                notifyIcon1.BalloonTipText = "Se ha cargado la salida: " + nsalida + " sin eerores\r\n";
                notifyIcon1.ShowBalloonTip(10000);


            }
            else if (nttipo == 2)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Text = nsalida + " ERROR: la salida contiene errores";
                notifyIcon1.BalloonTipTitle = " ERROR: no se han cargado todas las etiquetas " + nsalida;
                notifyIcon1.BalloonTipText = " algunas etiquetas no fueron cargadas en la salida: " + nsalida;
                notifyIcon1.ShowBalloonTip(10000);

            }

        }

        private void gunaGradientTileButton3_Click(object sender, EventArgs e)
        {
            int error = ValidacionesGenerales(); //1 error o 0 normal


            if (error == 1)
            {
                return;
            }
            if (MessageBox.Show("Estas apunto de iniciar la salida; recuerda que este numero quedara reservado hasta que la finalices formalmente", "Atencion", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                 CreaSalidaEnKDM1();
                btnIniciaSalida.Enabled = false;
                btnImportarExcel.Enabled = false;
                 bntSalidaPausa.Enabled = false;
                    gbxDetalles.Enabled = false;
                }
                catch (Exception)
                {

                    throw;
                }
              
            }
            
        }

        private void IniSalida( bool dato)
        {
            

            if (dato == true)
            {
                Ventana1.frmSalidas d = new frmSalidas();
                d.ShowDialog();
                d.Dispose();
            }
            else
            {
                MessageBox.Show("No puedes usar esta opcion, pide ayuda a un supervisor o a Sistemas.");
            }



        }

 

        private void gunaGradientTileButton2_Click_1(object sender, EventArgs e)
        {
            using (frmBuscarOrdSalida oc = new frmBuscarOrdSalida())
            {
                oc.pasadoS += new frmBuscarOrdSalida.pasarS(CargaLisataSalidas);
                oc.sOrigen = sOrigen;
                oc.sucsdest = sDestino;
                oc.ShowDialog();
            }
           
         
        }

        private async void CargaLisataSalidas(string dato)
        {
            if (dato.Trim().Contains(ulDato))
            {
                return;
            }
            Negocios.Acceso_Salida.AccesoSalidas sls = new Negocios.Acceso_Salida.AccesoSalidas();
            
            ulSalidaPSolo = dato;
            var lista1 = await sls.BuscEntradasEnSalida(dato,sOrigen);
            dgvEscaneados.DataSource = null;
            dgvEscaneados.Rows.Clear();
            dgvEscaneados.Refresh();

            dgvListaCargas.Rows.Clear();
            dgvListaCargas.Refresh();

            dgvObser.Rows.Clear();
            dgvObser.Refresh();


            foreach (var i in lista1)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvEscaneados);

                row.Cells[0].Value = i.Documento.Trim();
                row.Cells[1].Value = string.IsNullOrEmpty(i.Referencia) ? "" : i.Referencia.Trim();
                //var cO = sls.ObtieCorreo(i.Documento.Trim());
                row.Cells[2].Value = string.IsNullOrEmpty(i.correo) ? "" : i.correo.Trim();
                dgvEscaneados.Rows.Add(row);
                
            }
            BuscaUltimaSalida(sOrigen);


            var lss = await sls.LlenaDGVpausadas(ulDatoSolo);
            foreach (var q in lss)
            {
                string datocarga = "";
                if (sOrigen.Contains("TJ"))
                {
                    datocarga= sOrigen+"-UD5001-" + q.Documento;
                }
                else
                {
                    datocarga = sOrigen + "-UD4001-" + q.Documento;
                }
                
                agrgaCargatabla(datocarga);
            }
            BuscaentradasCarga();
            
            await CargaGenerales();
            btnIniciaSalida.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            btnImportarExcel.Enabled = false;

        }
        private async Task CargaGenerales()
        {
            Negocios.Acceso_Salida.AccesoSalidas sls = new Negocios.Acceso_Salida.AccesoSalidas();

            var gn = await sls.LlenaGeneralesSalida(ulDatoSolo,sOrigen);

            foreach (var i in gn)
            {/*

                if (i.sDestino.Trim().Contains("TJ"))
                {
                    rbDTJ.Checked = true;
                }
                if (i.sDestino.Trim().Contains("CSL"))
                {
                    rbDCSL.Checked = true;
                }
                if (i.sDestino.Trim().Contains("SD"))
                {
                    rbDSD.Checked = true;
                }*/


                /* if (i.sOrigen.Trim().Contains("TJ"))
                 {
                     rbOTJ.Checked = true;
                 }
                 if (i.sOrigen.Trim().Contains("CSL"))
                 {
                     rbOCSL.Checked = true;
                 }
                 if (i.sOrigen.Trim().Contains("SD"))
                 {
                     rbOSD.Checked = true;
                 }
                */

                cmbSucOrigen.SelectedIndexChanged -= cmbSucOrigen_SelectedIndexChanged;
                sucDestino.SelectedIndexChanged -= sucDestino_SelectedIndexChanged;

                foreach (Sucursales item in cmbSucOrigen.Items)
                {
                    if (item.c1.Trim() == i.sOrigen.Trim())
                    {
                        cmbSucOrigen.SelectedValue = item.c1;
                        break;

                    }

                }
          
                foreach (Sucursales item in sucDestino.Items)
                {
                    if (item.c1.Trim() == i.sDestino.Trim())
                    {
                        sucDestino.SelectedValue = item.c1;
                        break;

                    }

                }
                cmbSucOrigen.SelectedIndexChanged += cmbSucOrigen_SelectedIndexChanged;
                sucDestino.SelectedIndexChanged += sucDestino_SelectedIndexChanged;

                txbTransportista.Text = i.Transportista.ToString();
                txbReferencia.Text = i.Referencia.ToString();
                txbPlacas.Text = i.Placas.ToString();
                txbChofer.Text = i.Chofer.ToString();
                this.Refresh();

            }

        }

        private async void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            if (ValidacionesGenerales()==0)
            {
                if (_noCarga == true || dgvEscaneados.Rows.Count>0)
                {
                    if (MessageBox.Show("Estás a punto de cerrar la salida \nA partir de aquí ya no se podrá modificar \nContinuar?", "Alerta", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        await FinalizaSalidaKDM1();
                        iniciodesalida = 0;

                        try
                        {
                            MandaHookRing();
                        }
                        catch 
                        {

                           
                        }


                        try
                        {
                          

                            GeneraExcel();
                           // string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                            string carpetaTemporal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "temp");
                            if (Directory.Exists(carpetaTemporal))
                                Process.Start(carpetaTemporal);

                         

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("El documento de Excel no se pudo generar correctamente, pero la Salida se creó satisfactoriamente");
                        }
                        try
                        {
                            MessageBox.Show("Salida: " + ulDatoSolo + " con origen: " + sOrigen + " finalizada");
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                       
                        this.Dispose();
                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show("No hay escaneos");
                    return;
                }

            }

        }
        private async void MandaHookRing()
        {

            var client = new RingCentralClient();
            string carg = GetDataGridValues(dgvListaCargas);
            string noScaneadas = GetDataGridValues(dgvOrdenesEntrada);

            await client.SendMessageAsync(ulDato, DateTime.Now.ToString(), Negocios.Common.Cache.CacheLogin.nombre + " " + Negocios.Common.Cache.CacheLogin.apellido, carg, noScaneadas, txbReferencia.Text);
        }
        private string GetDataGridValues(DataGridView dgv)
        {
            var values = new List<string>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    values.Add(row.Cells[0].Value.ToString());
                }
            }

            return string.Join(",", values);
        }
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            if (btnIniciaSalida.Enabled == true)
            {
                MessageBox.Show("Primero tienes que Iniciar la salida");
                return;
            }

            int error = ValidacionesGenerales(); //1 error o 0 normal


            if (error == 1)
            {
                return;
            }
            ObtieneDatosDeExcel();

        }
        private async void ObtieneDatosDeExcel()
        {
            openFileDialog1.InitialDirectory = @"C:\\";
            openFileDialog1.Filter = "Archivos de texto (*.xlsx)|*.xlsx";
            List<Ventana1.vm.Salidas_por_cotizacion> lst = new List<Ventana1.vm.Salidas_por_cotizacion>();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (ExcelPackage package = new ExcelPackage(new FileInfo(openFileDialog1.FileName)))
                    {
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                        ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
                        int IRow = 2;

                        while (!string.IsNullOrEmpty(workSheet.Cells[IRow, 1].Value?.ToString()))
                        {
                            Ventana1.vm.Salidas_por_cotizacion Odats = new Ventana1.vm.Salidas_por_cotizacion();

                            Odats.c2 = workSheet.Cells[IRow, 1].Value?.ToString().Replace("'", "-").Replace("’", "-").Replace(" ", "").ToUpper().Trim() ?? string.Empty;

                            if (!string.IsNullOrEmpty(workSheet.Cells[IRow, 2].Value?.ToString().Trim()))
                            {
                                txbChofer.Text = workSheet.Cells[IRow, 2].Value.ToString().Trim().Length >= 50 ? workSheet.Cells[IRow, 2].Value.ToString().Trim().Substring(0, 50) : workSheet.Cells[IRow, 2].Value.ToString().Trim();
                            }
                            if (!string.IsNullOrEmpty(workSheet.Cells[IRow, 3].Value?.ToString().Trim()))
                            {
                                txbPlacas.Text = workSheet.Cells[IRow, 3].Value.ToString().Trim().Length >= 50 ? workSheet.Cells[IRow, 3].Value.ToString().Trim().Substring(0, 50) : workSheet.Cells[IRow, 3].Value.ToString().Trim();
                            }
                            if (!string.IsNullOrEmpty(workSheet.Cells[IRow, 4].Value?.ToString().Trim()))
                            {
                                txbTransportista.Text = workSheet.Cells[IRow, 4].Value.ToString().Trim().Length >= 50 ? workSheet.Cells[IRow, 4].Value.ToString().Trim().Substring(0, 50) : workSheet.Cells[IRow, 4].Value.ToString().Trim();
                            }

                            lst.Add(Odats);

                            IRow++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cierra bien el archivo " + ex.Message);
                }

                var query = lst.GroupBy(x => x.c2)
                    .Where(g => g.Count() > 1)
                    .Select(y => new { Etiquetas = y.Key, No = y.Count() - 1 })
                    .ToList();

                var listasinduplis = new HashSet<string>(lst.Select(d => d.c2).ToList()).ToList();

                var nlst = lst.Select(d => d.c2).Distinct();
                List<Salidas_por_cotizacion> nls = new List<Salidas_por_cotizacion>();
                foreach (var q in nlst)
                {
                    nls.Add(new Salidas_por_cotizacion { c2 = q.ToString() });
                }

                foreach (var q in nls)
                {
                    await ProcesarEtiquetaAsync(q.c2);
                }
            }
        }

        private async Task ProcesarEtiquetaAsync(string etiqueta)
        {
            await Task.Run(() => {
                this.Invoke(new Action(() => {
                    ProcesadoEtiqueta(etiqueta);
                }));
            });
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
           MandaHookRing();
        }

        private void frmOrdSalida_Load(object sender, EventArgs e)
        {
            
            Task.Run(() => { CargaSOrigen(); });
           
        }
        private void CargaSOrigen()
        {
            Servicios datos = new Servicios();
            var lst2 = datos.llenaSuc();
            var lst2_2 = new List<Sucursales>(lst2);

            // Utilizamos Invoke para actualizar la UI de manera segura desde un hilo secundario
            this.Invoke(new Action(() =>
            {
                cmbSucOrigen.DisplayMember = "C2";
                cmbSucOrigen.ValueMember = "C1";
                cmbSucOrigen.DataSource = lst2;
                foreach (var i in from Sucursales i in cmbSucOrigen.Items select i)
                {
                    cmbSucOrigen.SelectedValue = i.c1;
                    break;
                }

                sucDestino.DisplayMember = "C2";
                sucDestino.ValueMember = "C1";
                sucDestino.DataSource = lst2_2;
            }));

            datos = null;
        }


        private void frmOrdSalida_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (colaEtiquetas.Count > 0)
            {
                MessageBox.Show("Hay etiquetas procesandoce");
                return;
            }
            alertaNoCargaPlayer.Dispose();
            alertaBienPlayer.Dispose();
        }

        private void cmbSucOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
           var name = cmbSucOrigen.SelectedValue?.ToString().Trim();

            if (String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("La sucursal Destino no puede esta bacia");
                return;
            }
            sOrigen = name.Trim();
            if (sOrigen == "TJ")
            {
                
                lblSalida.ForeColor = Color.Blue;

            }
            if (sOrigen == "CSL")
            {
                
                lblSalida.ForeColor = Color.DarkViolet;

            }
            if (sOrigen == "SD")
            {
               
                lblSalida.ForeColor = Color.Red;

            }
            if (sOrigen == "IMSD")
            {

                lblSalida.ForeColor = Color.Yellow;

            }
            iniciodesalida = 0;
            BuscaUltimaSalida(sOrigen);
        }

        private void sucDestino_SelectedIndexChanged(object sender, EventArgs e)
        {

             var name = sucDestino.SelectedValue?.ToString().Trim();

            if (String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("La sucursal Destino no puede esta bacia");
                return;
            }
            sDestino = name.Trim();
            
        }

        private void gunaGoogleSwitch13_CheckedChanged(object sender, EventArgs e)
        {
            gunaGoogleSwitch13.CheckedChanged -= gunaGoogleSwitch13_CheckedChanged;
            VistaEntrada.Desbloqueo buscador = new Desbloqueo();

            buscador.cambiar += new Desbloqueo.cambio(SalidaSinCargaCheck);
            buscador.ShowDialog();
            gunaGoogleSwitch13.CheckedChanged += gunaGoogleSwitch13_CheckedChanged;



        }

        public async void SalidaSinCargaCheck(bool dato)
        {
            if (dato == true)
            {
               
                if (MessageBox.Show("Seguro que quieres hacer una salida sin carga? \nNo se recomienda.", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string us = Negocios.Common.Cache.CacheLogin.username;
                        if (us == "DOLIVARES" || us == "EZAVALA" || us == "CARLOSDA")
                        {
                            _noCarga = true;
                            gunaGoogleSwitch13.Checked =_noCarga;
                        }
                        else
                        {

                            _noCarga = false;
                            gunaGoogleSwitch13.Checked = _noCarga;
                            MessageBox.Show("No tienes autorizacion");
                        }


                    }
                    catch (Exception)
                    {
                        _noCarga = false;
                        gunaGoogleSwitch13.Checked = _noCarga;
                        throw;
                    }


                }
            }
            else
            {
                _noCarga = false;
                gunaGoogleSwitch13.Checked = _noCarga;
                MessageBox.Show("No tienes autorizacion");
            }
           
        }

        private void dgvObser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedCell = dgvObser.SelectedCells[0];
            string folioSeleccionado = selectedCell.Value?.ToString();
            if (String.IsNullOrWhiteSpace(folioSeleccionado))
            {
                return;
            }
            if (MessageBox.Show($"Borrar la entrada {folioSeleccionado}\nde la salida?", "Borrar", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            AltKDMENT(folioSeleccionado, ModoAltakdment.Baja,dgvObser);

        }

        private void dgvEscaneados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedCell = dgvEscaneados.SelectedCells[0];
            string folioSeleccionado = selectedCell.Value?.ToString();
            if (String.IsNullOrWhiteSpace(folioSeleccionado))
            {
                return;
            }
            if (MessageBox.Show($"Borrar la entrada {folioSeleccionado}\nde la salida?", "Borrar", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            AltKDMENT(folioSeleccionado, ModoAltakdment.Baja,dgvEscaneados);
        }
    }


}
