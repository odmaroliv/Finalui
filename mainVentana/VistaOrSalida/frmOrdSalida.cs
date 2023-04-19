using ClosedXML.Excel;
using Datos.Datosenti;
using Datos.ViewModels.Salidas;
using Negocios;
using Negocios.Acceso_Salida;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventana1;

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
        public frmOrdSalida()
        {
            InitializeComponent();
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
            Ventana1.frmSalidas d = new frmSalidas();
            d.ShowDialog();
            d.Dispose();
        }

        private void BuscaUltimaSalida(string suc)
        {
            if (ulSalidaPSolo == "")
            {
                if (iniciodesalida ==0)
                {

                //List<string> lista1 = new List<string>();
                Negocios.Acceso_Salida.AccesoSalidas sls = new Negocios.Acceso_Salida.AccesoSalidas();
                var lista1 = sls.BuscUltimaSalida(suc);


                    foreach (var i in lista1)
                    {
                        int sl = Convert.ToInt32(i.ToString()) + 1;
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
            if (dgvEscaneados.Rows.Count <= 0)
            {
                MessageBox.Show("No hay datos para Enviar");
                return;
            }

            List<vmEnviodeNotificacion> list = new List<vmEnviodeNotificacion>();
            int filasE = dgvEscaneados.Rows.Count;
            int filasA = dgvObser.Rows.Count;
            int filasO = dgvOrdenesEntrada.Rows.Count;

            list.Add(new vmEnviodeNotificacion { OrdenSalidaAplicada = ulDato });

            for (int i = 0; i < filasE; i++)
            {

                list.Add(new vmEnviodeNotificacion
                {

                    Etiqueta =  dgvEscaneados.Rows[i].Cells[0].Value == null ?"": dgvEscaneados.Rows[i].Cells[0].Value.ToString().Trim(),
                    Pertenece = dgvEscaneados.Rows[i].Cells[1].Value == null ?"": dgvEscaneados.Rows[i].Cells[1].Value.ToString().Trim(),
                    Correo =  dgvEscaneados.Rows[i].Cells[2].Value == null ? "" : dgvEscaneados.Rows[i].Cells[2].Value.ToString().Trim(),

                });
            }
            for (int i = 0; i < filasA; i++)
            {
                list.Add(new vmEnviodeNotificacion
                {
                    Etiqueta =dgvObser.Rows[i].Cells[0].Value == null ? "" : dgvObser.Rows[i].Cells[0].Value.ToString().Trim(),
                    notas = "Esta entrada no se encontro en ninguna orden cargada en esta salida (Pordria no existir)",
                    Correo = dgvObser.Rows[i].Cells[2].Value == null ? "sistemas@arnian.com" : dgvObser.Rows[i].Cells[2].Value.ToString().Trim()

                });


            }
            for (int i = 0; i < filasO; i++)
            {
                list.Add(new vmEnviodeNotificacion
                {
                    Etiqueta = dgvOrdenesEntrada.Rows[i].Cells[0].Value == null ? "" : dgvOrdenesEntrada.Rows[i].Cells[0].Value.ToString().Trim(),
                    NoCargadas = "ESTA ETIQUETA NO FUE ESCANEADA EN ESTA SALIDA A PESAR DE ESTAR EN LAS ÓRDENES DE CARGA."

                    //Correo = string.IsNullOrEmpty(dgvObser.Rows[i].Cells[2].Value.ToString()) ? "" : dgvObser.Rows[i].Cells[2].Value.ToString().Trim(),

                });


            }



            GeneraCorreo(list);

        }


        private async void GeneraCorreo(List<vmEnviodeNotificacion> dato)
        {


            var correos = new HashSet<string>(dato.Select(d => d.Correo).ToList()).ToList();


            List<vmEnviodeNotificacion> lss = new List<vmEnviodeNotificacion>();
            


            string path = AppDomain.CurrentDomain.BaseDirectory;
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
                msg.Subject = "Salida: "+ salida;

                msg.IsBodyHtml = true;
                using (StringReader sr = new StringReader(body))
                {
                    msg.Body = sr.ReadToEnd().ToString();
                }

                msg.To.Add(new MailAddress("sistemas@arnian.com"));

                var corrr = string.Join(",", correo);
                if (corrr != "")
                {
                    string[] toCC = corrr.Split(',')[0].Trim() == ""  ? "licencias@arnian.com".Split(',') : corrr.Split(',');
                    foreach (string ToCCId in toCC)
                    {
                        msg.CC.Add(new MailAddress(ToCCId));
                    }
                }

                if (bndra==0)
                {
                    msg.CC.Add(new MailAddress("susano.limon@arnian.com"));
                    //msg.CC.Add(new MailAddress("sistemas@arnian.com"));
                    msg.CC.Add(new MailAddress("operaciones@arnian.com"));
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
                newRow.Cells[1].Value = "No se encotro en ninguna Orden Cargada en este documento";
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
            if (dgvListaCargas.RowCount == 0)
            {
                MessageBox.Show("No se han seleccionado Cargas");
                error = 1;
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
        private void txbEscaneo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            var etiqueta = txbEscaneo.Text?.Trim()?.ToUpper()?.Replace("'", "-");
            if (string.IsNullOrEmpty(etiqueta))
            {
                lblMensaje.Text = "Etiqueta no válida";
                txbEscaneo.Text = "";
                return;
            }

            if (dgvEscaneados.Rows.Cast<DataGridViewRow>().Any(r => r.Cells[0].Value.ToString().Trim() == etiqueta))
            {
                lblMensaje.Text = "La etiqueta " + etiqueta + " ya está en la tabla principal";
                txbEscaneo.Text = "";
                return;
            }

            if (dgvObser.Rows.Cast<DataGridViewRow>().Any(r => r.Cells[0].Value.ToString().Trim() == etiqueta))
            {
                lblMensaje.Text = "La etiqueta " + etiqueta + " ya está en la tabla de Obs";
                txbEscaneo.Text = "";
                return;
            }

            var sls = new Negocios.Acceso_Salida.AccesoSalidas();
            var index = lista.FindIndex(a => a.Etiqueta.Trim().Contains(etiqueta));

            if (index == -1)
            {
                AltKDMENT(etiqueta);

                var cO = sls.ObtieCorreo(etiqueta, sOrigen.Trim());
                var obsRow = new DataGridViewRow();
                obsRow.CreateCells(dgvObser);
                obsRow.Cells[0].Value = etiqueta;
                obsRow.Cells[1].Value = "Esta etiqueta no se encontró en ninguna Orden Cargada en este documento";
                obsRow.Cells[2].Value = cO;
                dgvObser.Rows.Add(obsRow);
                lblMensaje.Text = "Etiqueta: " + etiqueta + " no se encontró en las ordenes cargadas";
            }
            else
            {
                AltKDMENT(etiqueta);

                var cOr = sls.ObtieCorreo(etiqueta, sOrigen.Trim());
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

            txbEscaneo.Text = "";
        }


        private async void CreaSalidaEnKDM1()
        {

            string estatuss = default;

            if (sOrigen.Trim() == "TJ")
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

            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            BuscaUltimaSalida(sOrigen);
            Negocios.AltasBD at = new AltasBD();
            at.CSalidaEnKDM1(sOrigen
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
             

           


        



        private async void AltKDMENT(string etiqueta)
        {
            if (sDestino == "TJ" && sOrigen == "SD")
            {
                await ModificaKDMENTsd(etiqueta);
            }

            if (sDestino == "CSL" && sOrigen == "SD")
            {
                await ModificaKDMENTsd(etiqueta);
            }


            if (sDestino == "SD" && sOrigen == "TJ")
            {
                await ModificaKDMENTtj(etiqueta);
            }
            if (sDestino == "CSL" && sOrigen == "TJ")
            {

                await ModificaKDMENTtj(etiqueta);
            }
            if (sDestino == "TJ" || sDestino == "SD" && sOrigen == "CSL")
            {
                await ModificaKDMENTsd(etiqueta);
            }
        }

        //Sucursal destino cabo sucursal origen tijuana
        private async Task<bool> ModificaKDMENTtj(string etiqueta)
        {
           
            string uld = (string)ulDato.Trim().Clone();
            string sc = sDestino == "CSL" ? "PR" : "OC";


            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    List<KDMENT> kd = new List<KDMENT>();

                    try
                    {
                        var d = (from fd in modelo.KDMENT
                                 where fd.C9 == etiqueta.ToUpper().Trim()// 
                                 select fd).First();
                        //d.C17 = uld;
                        d.C19 = sOrigen;
                        d.C20 = sc;
                        d.C23 = "";
                        d.C55 = uld;
                        //d.C56 = "";

                        d.C63 = uld;
                        d.C64 = uld;
                        d.C65 = "E";
                       // d.C66 = "";
                       // d.C67 = "";
                      //  d.C68 = "";
                        d.C75 = DateTime.Now.ToString("MM/dd/yyyy");
                        kd.Add(d);
                    }

                    catch (Exception x)
                    {
                        Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Escaneo de Etiqueta" + etiqueta);

                        MessageBox.Show("Ocurrio un Error, por favor no continue scaneando y contacte al administrador");

                    }
                    try
                    {
                        modelo.BulkUpdate(kd.ToList());
                    }
                    catch (Exception x)
                    {

                        Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Escaneo de Etiqueta" + etiqueta);

                        MessageBox.Show("Ocurrio un Error, por favor no continue scaneando y contacte al administrador");

                    }


                }
            });




            //----------------------------------------



            return true;

        }

        private async Task<bool> ModificaKDMENTsd(string etiqueta)
        {


            string sc = sDestino == "CSL" ? "PR" : "OC";
            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    List<Datos.Datosenti.KDMENT> kd = new List<Datos.Datosenti.KDMENT>();


                    string uld = (string)ulDato.Trim().Clone();

                    try
                    {

                        var d = (from fd in modelo.KDMENT
                                 where fd.C9 == etiqueta.ToUpper().Trim()// 
                                 select fd).First();

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
                        kd.Add(d);
                        //modelo.SaveChanges();

                    }
                    catch (Exception x)
                    {

                        Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Escaneo de Etiqueta" + etiqueta);

                       // MessageBox.Show("Ocurrio un Error, por favor no continue scaneando y contacte al administrador");

                    }
                    try
                    {
                        modelo.BulkUpdate(kd.ToList());
                    }
                    catch (Exception x)
                    {
                        Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Escaneo de Etiqueta" + etiqueta);

                       // MessageBox.Show("Ocurrio un Error, por favor no continue scaneando y contacte al administrador");
                    }

                   
                }
            });




            return true;
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

                CreaSalidaEnKDM1();
                btnIniciaSalida.Enabled = false;
                btnImportarExcel.Enabled = false;
                bntSalidaPausa.Enabled = false;
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
            {

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
                }


                if (i.sOrigen.Trim().Contains("TJ"))
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

                
                txbTransportista.Text = i.Transportista.ToString();
                txbReferencia.Text = i.Referencia.ToString();
                txbPlacas.Text = i.Placas.ToString(); 
                txbChofer.Text = i.Chofer.ToString();

            }

        }

        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            if (ValidacionesGenerales()==0)
            {
                if (dgvEscaneados.Rows.Count>0)
                {
                    if (MessageBox.Show("Estás a punto de cerrar la salida \nA partir de aquí ya no se podrá modificar \nContinuar?", "Alerta", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        FinalizaSalidaKDM1();
                        iniciodesalida = 0;

                        try
                        {
                            GeneraExcel();
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
    }


}
