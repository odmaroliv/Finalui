using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.ViewModels;
using Datos.ViewModels.Carga;
using Datos.ViewModels.Entradas;
using Negocios;
using Negocios.NGCarga;
using Ventana1.LoadControl;

namespace mainVentana.VistaOrdenCarga
{
    public partial class frmModificaCarga : Form
    {

        public string modoForm;
        private string cargaAModificar;
        public string sucursalGlobal = Negocios.Common.Cache.CacheLogin.sucGlobal == default ? "SD" : Negocios.Common.Cache.CacheLogin.sucGlobal;
        public frmModificaCarga()
        {
            InitializeComponent();
        }

        private void txtOperacion_Click(object sender, EventArgs e)
        {

        }
        private bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !char.IsLetterOrDigit(ch));
        }
        private void txbCarga_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Return)
            {
                ColocaDatos();
            }




        }

        private void ColocaDatos()
        {
            var lst = new vmCargaConsultaGeneral();
            string numeroDeCarga = !String.IsNullOrEmpty(txbCarga.Text) ? txbCarga.Text.Trim() : "";
            numeroDeCarga = HasSpecialChars(numeroDeCarga) == false ? numeroDeCarga : "";


            numeroDeCarga = numeroDeCarga != "" ? Convert.ToInt32(numeroDeCarga).ToString("D7") : "";

            txbCarga.Text = numeroDeCarga;

            GETcarga get = new GETcarga();
            lst = get.ObtieneOrdenDeCargaPorIdYSucursal(cmbSucOrigen.SelectedValue.ToString().Trim(), numeroDeCarga);




            if (lst == null || lst.numeroCarga.Length < 4)
            {
                MessageBox.Show("No hay datos para mostrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!lst.estatus.Contains("N") && modoForm!="Consulta")
            {
                MessageBox.Show("Esta Orden ya no se puede modificar (Cerrada), contacte al administradir de Sistemas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cargaAModificar = numeroDeCarga;

            if (modoForm=="Consulta" || modoForm == "Cerrar")
            {
                CargaEntradaEnDgv();
            }
           

            foreach (Sucursales i in cmbSucOrigen.Items)
            {
                if (i.c1.Trim() == lst.sucursalOrigen.Trim())
                {
                    cmbSucOrigen.SelectedValue = i.c1;
                    break;
                }
            }
            foreach (Sucursales i in cmbSucDest.Items)
            {
                if (i.c1.Trim() == lst.sucursalDestino.Trim())
                {
                    cmbSucDest.SelectedValue = i.c1;
                    break;
                }
            }
            foreach (vmTOperacion i in tipoOper.Items)
            {
                if (i.c1.Trim() == lst.tipoOperacion.Trim())
                {
                    tipoOper.SelectedValue = i.c1;
                    break;
                }
            }

            foreach (Moneda i in cmbMoneda.Items)
            {
                if (i.moneda.Trim() == lst.moneda.Trim())
                {
                    cmbMoneda.SelectedValue = i.id;
                    break;
                }
            }






            txbParidad.Text = !String.IsNullOrEmpty(lst.paridad.ToString()) ? lst.paridad.ToString().Trim() : "";
            txbReferencia.Text = !String.IsNullOrEmpty(lst.referencia) ? lst.referencia.ToString().Trim() : "";
            txbFechaAlta.Text = lst.fechaAlta.Value.Date.ToString("MM/dd/yyyy");

            // DateTime ts = new DateTime(lst.fechaCierre.Value.Year, lst.fechaCierre.Value.Month, lst.fechaCierre.Value.Day);


            dtmFcierre.Value = lst.fechaCierre.Value;
            dtmHora.Value = Convert.ToDateTime(lst.horaCierre);
            lst = null;
        }


        private void txbCarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private async void llenaCampos()
        {


            try
            {

                dtmHora.CustomFormat = "HH:mm:ss";
                Moneda();

                //Capa de acceso a datos
                Servicios datos = new Servicios();

                //LLenado de los CoboBox de las sucursales
                var lst2 = datos.llenaSuc();
                var lst2_2 = new List<Sucursales>(lst2);

                cmbSucOrigen.DisplayMember = "C2";
                cmbSucOrigen.ValueMember = "C1";
                cmbSucOrigen.DataSource = lst2;
                foreach (var i in from Sucursales i in cmbSucOrigen.Items
                                  where i.c1.Trim() == sucursalGlobal.Trim()
                                  select i)
                {
                    cmbSucOrigen.SelectedValue = i.c1;
                    break;
                }

                cmbSucDest.DisplayMember = "C2";
                cmbSucDest.ValueMember = "C1";
                cmbSucDest.DataSource = lst2_2;

                //Llenado del tipo de operacion
                var lst7 = await datos.llenaOpera();

                tipoOper.DisplayMember = "C2";
                tipoOper.ValueMember = "C1";
                tipoOper.DataSource = lst7;

                //Obtiene la fecha de hoy y la asigna al timer 



            }
            catch
            {
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

        private void frmModificaCarga_Load(object sender, EventArgs e)
        {
            llenaCampos();
            selectorDeForm(); 
        }

        private void selectorDeForm()
        {
            if (modoForm == "Modifica")
            {

            }
            if (modoForm == "Consulta")
            {
                consultaLLena();
            }
            if (modoForm == "Cerrar")
            {
                CierraLlena();
            }
        }
        private void consultaLLena()
        {
            gunaGradientTileButton1.Visible = false;
            gunaGradientTileButton1.Enabled = false;
            txtOperacion.Text = "Consulta General";
            
           tipoOper.Enabled = false;
            cmbSucDest.Enabled = false ;
            cmbMoneda.Enabled = false ;
            txbParidad.Enabled = false;  
            txbReferencia.Enabled = false ;
            dtmFcierre.Enabled = false;
            dtmHora.Enabled = false;
            cambiaColorGroupBox(gunaGroupBox1, Color.BlanchedAlmond);
            cambiaColorGroupBox(gunaGroupBox2, Color.BlanchedAlmond);
            cambiaColorGroupBox(gunaGroupBox3, Color.BlanchedAlmond);
            btnImprimir.Enabled = true;
            btnImprimir.Visible = true;
        }
        List<vmEntradasEnCarga> entradasTo = new List<vmEntradasEnCarga>();
        private void CargaEntradaEnDgv()
        {
            entradasTo = null;
           Negocios.NGCarga.GETcarga get = new Negocios.NGCarga.GETcarga();
            entradasTo = get.EntradasEnCarga(cmbSucOrigen.SelectedValue.ToString(), Convert.ToInt32(cargaAModificar));
            dgvEntEnCarga.DataSource = entradasTo;
            txbTotal.Text = dgvEntEnCarga.Rows.Count.ToString();
        }



        private void CierraLlena()
        {
            gunaGradientTileButton1.Visible = false;
            gunaGradientTileButton1.Enabled = false;
            txtOperacion.Text = "Cerrar Orden";

            tipoOper.Enabled = false;
            cmbSucDest.Enabled = false;
            cmbMoneda.Enabled = false;
            txbParidad.Enabled = false;
            txbReferencia.Enabled = false;
            dtmFcierre.Enabled = false;
            dtmHora.Enabled = false;
            cambiaColorGroupBox(gunaGroupBox1, Color.DarkCyan);
            cambiaColorGroupBox(gunaGroupBox2, Color.DarkCyan);
            cambiaColorGroupBox(gunaGroupBox3, Color.DarkCyan);
            btnImprimir.Enabled = false;
            btnImprimir.Visible = false;
            btnCerrar.Enabled = true;
            btnCerrar.Visible = true;
        }

        private void cambiaColorGroupBox(object sender,Color color)
        {
            Guna.UI.WinForms.GunaGroupBox pic = (Guna.UI.WinForms.GunaGroupBox)sender;
            pic.LineColor = color;
           
        }

        private void cmbSucOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbCarga.Text = "";

        }

        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            gunaGradientTileButton1.Enabled = false;
            loadControl1.Visible = true;
            int validacion = ValidacionesGenerales();
            if (validacion == 1)
            {
                Notificacion(2, "Ocurrio Un problema", "Alerta");
            }
            else if (validacion == 0)
            {
                string datoSucIni = cmbSucOrigen.SelectedValue.ToString().Trim();
                string datoOrdCarga = cargaAModificar;
                string fechaDato = txbFechaAlta.Text.Trim();
                DateTime datoFechaAlta;
                bool conversionExitosa = DateTime.TryParse(fechaDato, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out datoFechaAlta);
                string datoOperacion = tipoOper.SelectedValue.ToString();
                string datoSucDest = cmbSucDest.SelectedValue.ToString().Trim();
                string datoMoneda = cmbMoneda.GetItemText(cmbMoneda.SelectedItem).ToString();
                double datoParidad = txbParidad.Text.ToString().Trim() != "" ? Convert.ToDouble(txbParidad.Text.ToString().Trim()) : 0;
                string datoRefe = txbReferencia.Text.ToString();
                DateTime datoFCorte = dtmFcierre.Value.Date;
                string datoHora = dtmHora.Text.ToString();


                altasBDCarga bd = new altasBDCarga();

                try
                {
                    bd.ModificaOrdCarga(datoSucIni,
                    datoOrdCarga,
                    datoFechaAlta,
                    datoOperacion,
                    datoSucDest,
                    datoMoneda,
                    datoParidad,
                    datoRefe,
                    datoFCorte,
                    datoHora);

                    MessageBox.Show("Documento " + datoOrdCarga + " Modificado con exito", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch
                {

                    throw;
                }

                gunaGradientTileButton1.Enabled = true;
                loadControl1.Visible = false;
                Notificacion(1, "El documento: " + cargaAModificar + "\rDe: " + datoSucIni + " Con destino a: " + datoSucDest + "\rSe Modifico.", "Exito " + datoOrdCarga, datoOrdCarga);
                //txbCarga.Text = cargaultent();

                this.Dispose();
                this.Close();
            }

        }

        private int ValidacionesGenerales()
        {
            //0 no hay error 1 error
            int error = 0;
            var fcha = DateTime.Compare(dtmFcierre.Value.Date, DateTime.Now.Date);

            if (String.IsNullOrEmpty(txbCarga.Text))
            {
                MessageBox.Show("Error en la Orden de Carga");
                txbCarga.Focus();
                error = 1;
            }


            if (cmbSucDest.SelectedValue == cmbSucOrigen.SelectedValue)
            {
                MessageBox.Show("Las Sucursal de origen y destino no puede ser las misma");
                cmbSucDest.Focus();
                error = 1;
            }

            if (fcha == -1)
            {
                MessageBox.Show("La fecha de cierre no puede ser anterior a la fecha de hoy");
                dtmFcierre.Focus();
                error = 1;
            }
            if (fcha == 0)
            {
                if (dtmHora.Value.Hour <= DateTime.Now.Hour)
                {
                    MessageBox.Show("La Hora de cierre no puede ser anterior a la hora de hoy");
                    dtmHora.Focus();
                    error = 1;
                }
            }
            return error;
        }
        //Notificaciones 
        private void Notificacion(int estatus, string Texto, string titulo, string cursor = null)
        {
            /*
             2 = ERROR
             1 = EXITO
            */
            try
            {
                if (estatus == 1)
                {
                    notifyIcon1.Icon = SystemIcons.Information;
                    notifyIcon1.Visible = true;
                    notifyIcon1.Text = cursor;
                    notifyIcon1.BalloonTipTitle = titulo;
                    notifyIcon1.BalloonTipText = Texto;
                    notifyIcon1.ShowBalloonTip(10000);

                }
                else if (estatus == 2)
                {
                    notifyIcon1.Icon = SystemIcons.Warning;
                    notifyIcon1.Visible = true;
                    notifyIcon1.Text = "Error";
                    notifyIcon1.BalloonTipTitle = titulo;
                    notifyIcon1.BalloonTipText = Texto;
                    notifyIcon1.ShowBalloonTip(10000);

                }

            }
            catch (Exception)
            {

                
            }
           

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            llamareporte();

        }
        private void llamareporte()
        {
            if (String.IsNullOrEmpty(txbCarga.Text))
            {
                MessageBox.Show("Error en la Orden de Carga");
                txbCarga.Focus();
                return;
            }
            Reportes.OrdenDeCarga.reporteSencilloCarga rp = new Reportes.OrdenDeCarga.reporteSencilloCarga();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Servicios sv = new Servicios();



            rp.sucursalInicial = cmbSucOrigen.GetItemText(cmbSucOrigen.SelectedItem).ToString();
            rp.sucursalDestino = cmbSucDest.GetItemText(cmbSucDest.SelectedItem).ToString();
            rp.tipoDeOperacion = tipoOper.GetItemText(tipoOper.SelectedItem).ToString();
            rp.numeroDeCarga = cargaAModificar;
            rp.fechaDeAlta = txbFechaAlta.Text.Trim();
            rp.referencia = txbReferencia.Text;
            rp.horaCierre = txbTotal.Text;
            rp.lst = entradasTo;

          //  rp.horaCierre = dtmHora.Value.Date.ToString("HH:mm:ss tt");
            rp.fechaCierre = dtmFcierre.Value.Date.ToString("MM/dd/yyyy");
            rp.fechaImprecion = DateTime.Now.ToString();
            rp.ShowDialog();



        }

        private async void btnCerrar_Click(object sender, EventArgs e)
        {
            

            if (dgvEntEnCarga.Rows.Count==0)
            {
                return;
            }
            await CerrarKdment();
            CerrarCarga();
            this.Dispose();
            this.Close();

        }
        private async Task CerrarKdment()
        {

            int validacion = ValidacionesGenerales();
            if (validacion == 1)
            {
                Notificacion(2, "Ocurrio Un problema", "Alerta");
            }
            else if (validacion == 0)
            {

                try
                {
                    Negocios.NGCarga.altasBDCarga get = new Negocios.NGCarga.altasBDCarga();
                    DataGridViewRow selectedRow = dgvEntEnCarga.Rows[dgvEntEnCarga.SelectedCells[0].RowIndex];
                    string e_eti;
                    string c_so = cmbSucOrigen.SelectedValue.ToString().Trim();
                    string c_cargacompleta = c_so + "-UD4001-" + cargaAModificar;
                    foreach (DataGridViewRow i in dgvEntEnCarga.Rows)
                    {
                        e_eti = Convert.ToString(i.Cells[1].Value).Trim();
                        await get.CerrarCargaKdment(e_eti, c_cargacompleta);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
            
        private void CerrarCarga()
        {
            btnCerrar.Enabled = false;
            loadControl1.Visible = true;
            int validacion = ValidacionesGenerales();
            if (validacion == 1)
            {
                Notificacion(2, "Ocurrio Un problema", "Alerta");
            }
            else if (validacion == 0)
            {
                string datoSucIni = cmbSucOrigen.SelectedValue.ToString().Trim();
                string datoOrdCarga = cargaAModificar;
              //  DateTime datoFechaAlta = Convert.ToDateTime(txbFechaAlta.Text.Trim());
              //  string datoOperacion = tipoOper.SelectedValue.ToString();
                string datoSucDest = cmbSucDest.SelectedValue.ToString().Trim();
              //  string datoMoneda = cmbMoneda.GetItemText(cmbMoneda.SelectedItem).ToString();
              //  double datoParidad = txbParidad.Text.ToString().Trim() != "" ? Convert.ToDouble(txbParidad.Text.ToString().Trim()) : 0;
              //  string datoRefe = txbReferencia.Text.ToString();
              //  DateTime datoFCorte = dtmFcierre.Value.Date;
              //  string datoHora = dtmHora.Text.ToString();


                altasBDCarga bd = new altasBDCarga();

                try
                {
                    bd.CerrarCarga(datoSucIni,
                    datoOrdCarga);

                    MessageBox.Show("Documento " + datoOrdCarga + " Cerrado con exito", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch
                {

                    throw;
                }
                btnCerrar.Enabled = true;
                loadControl1.Visible = false;
                Notificacion(1, "El documento: " + cargaAModificar + "\rDe: " + datoSucIni + " Con destino a: " + datoSucDest + "\rSe Cerro.", "Exito " + datoOrdCarga, datoOrdCarga);
                //txbCarga.Text = cargaultent();
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
