using Datos.ViewModels;
using Datos.ViewModels.Entradas;
using Datos.ViewModels.Servicios;
using Negocios;
using Negocios.NGCarga;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaOrdenCarga
{
    public partial class frmOrdenDeCarga : Form
    {
        public string sucursalGlobal = Negocios.Common.Cache.CacheLogin.sucGlobal == default ? "SD" : Negocios.Common.Cache.CacheLogin.sucGlobal;

        public frmOrdenDeCarga()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        //Establece las monedas en el ComboBox
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

        //Obtiene el la ultima Orden de Carga.
        private string cargaultent()
        {
            string carga = "";
            string datoSucIni = cmbSucOrigen.SelectedValue.ToString().Trim();
            GETcarga datos = new GETcarga();
            
            foreach (var i in datos.ultimaCarga(datoSucIni, 40))
            {
                int numero = Convert.ToInt32(i.OrdenCarga);
                carga =  numero.ToString("D7");  
            }
            return carga != "" || carga == null ? carga.ToString().Trim() : "";
        }

        //Sevicio que obtiene la paridad del diario oficial de la federacion
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

            if (lista.Count() <= 0)
            {
                if (MessageBox.Show("No pudimos acceder a la paridad del Diario Oficial de la Federación \r(Si es fin de semana los servicios de DOF no funcionan )\rAl hacer click te redireccionare a la pagina oficial para establecerla manualmente", "No paridad automatica", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
                {
                    Process.Start("https://dof.gob.mx/indicadores.php");
                }
                txbParidad.Enabled = true;
            }
            else
            {
                

                foreach (var i in lista.ToList())
                {
                    txbParidad.Text = i.valor.ToString();
                }
            }
            


        }

        //Servicio obtiene la fecha de Cabo San Lucas.
        private async void cargafecha()
        {
            Servicio datos = new Servicio();
            try
            {
                string fecha1 = await datos.fechaLapaz();
                //List<FechaActual> lst = JsonConvert.DeserializeObject<List<FechaActual>>(paridad1);
                //var lst = JsonConvert.DeserializeObject<List<FechaActual>>(fecha1);
                FechaActual lst = JsonConvert.DeserializeObject<FechaActual>(fecha1);

                txbFechaAlta.Text = lst.datetime.Date.ToString("MM/dd/yyyy");

            }
            catch (Exception)
            {

                txbFechaAlta.Text = DateTime.Now.ToString();
            }
          
        }

        //Llena campos del FORM en general.
        private async void llenaCampos()
        {
            Moneda();
            dtmHora.CustomFormat = "HH:mm:ss";

            try
            {
               

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
                dtmFcierre.Value = DateTime.Now;
                cargafecha();

            }
            catch
            {
            }
        }

        //Accesa al servicio de paridad al cambiar el Combobox
        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Convert.ToInt32(cmbMoneda.SelectedValue) == 1)
            {
                txbParidad.Text = "";
            }
            else if (Convert.ToInt32(cmbMoneda.SelectedValue) == 2)
            {
                try
                {
                    Cargaparidad();
                }
                catch (Exception)
                {

                    MessageBox.Show("la paridad no pudo se encontrada en el diario oficial de la federacion por favor agregela manualmente");
                    txbParidad.Enabled = true;
                }

            }
        }
        //Test de internet
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        private int TestInternet()
        {
            
            int error = 0; // 0 no error 1 error 
            int desc;
            if (InternetGetConnectedState(out desc, 0) == true)
            {

            }
            else
            {
                MessageBox.Show("Nececitas una coneccion a internet para poder accesar", "Sin coneccion");
                error = 1;
            }
            return error;
        }

        //Evento de inicio del Form
        private void frmOrdenDeCarga_Load(object sender, EventArgs e)
        {
           
            llenaCampos();
        }

        //Llama a la ultima Orden de carga deacuerdo con la seleccion.
        private void cmbSucOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //carga ultima orden de carga
            txbCarga.Text = cargaultent();
        }


        //Boton de Dar de Alta la Orden de Carga.
        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            if (hopeSwitch1.Checked == true)
            {
                
                tipoOper.SelectedValue = "09";

            }
            int validacion = ValidacionesGenerales();
            if (validacion==1)
            {
                Notificacion(2, "Ocurrio Un problema", "Alerta");
            }
            else if (validacion == 0)
            {
                string datoSucIni = cmbSucOrigen.SelectedValue.ToString().Trim();
                string datoOrdCarga = cargaultent();
                DateTime datoFechaAlta;
                try { datoFechaAlta =  Convert.ToDateTime(txbFechaAlta.Text.Trim()); }catch { datoFechaAlta = DateTime.Now; }
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
                    bd.AltaOrdCarga(datoSucIni,
                    datoOrdCarga,
                    datoFechaAlta,
                    datoOperacion,
                    datoSucDest,
                    datoMoneda,
                    datoParidad,
                    datoRefe,
                    datoFCorte,
                    datoHora);
                    bd.ActualizaSqlIov(datoSucIni.Trim(), 40, datoOrdCarga.Trim());
                    MessageBox.Show("Documento " + datoOrdCarga + " creado con exito", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (DbEntityValidationException o)
                {
                    Negocios.LOGs.ArsLogs.LogEdit(o.Message, "frmOrdenDeCarga.cs, Cuando se dio click al boton de crear orden de Carga... " + datoOrdCarga + "");
                    throw;
                }
                Notificacion(1,"El documento: "+ datoOrdCarga +"\rDe: "+datoSucIni+" Con destino a: "+ datoSucDest + "\rSe creo correctamente.", "Exito "+ datoOrdCarga,datoOrdCarga);
                //txbCarga.Text = cargaultent();

                this.Dispose();
                this.Close();
            }

        }


        private int ValidacionesGenerales()
        {
            int error = 0;
            try
            {
                var fcha = DateTime.Compare(dtmFcierre.Value.Date, DateTime.Now.Date);

                //0 no hay error 1 error
              
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
              
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error en la validación");
            }
            return error;
        }
        //Notificaciones 
        private void Notificacion(int estatus, string Texto, string titulo,string cursor = null)
        {
            /*
             2 = ERROR
             1 = EXITO
            */

            if (estatus == 1)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Text = cursor;
                notifyIcon1.BalloonTipTitle = titulo;
                notifyIcon1.BalloonTipText = Texto;
                notifyIcon1.ShowBalloonTip(10000);
                notifyIcon1.Icon = SystemIcons.Information;
            }
            else if (estatus == 2)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Text = "Error";
                notifyIcon1.BalloonTipTitle = titulo;
                notifyIcon1.BalloonTipText = Texto;
                notifyIcon1.ShowBalloonTip(10000);
                notifyIcon1.Icon = SystemIcons.Warning;
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                frmModificaCarga ent = new frmModificaCarga();
                ent.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                frmModificaCarga ent = new frmModificaCarga();
                ent.Text = "Consulta";
                ent.modoForm = "Consulta";
                
                ent.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            try
            {
                frmModificaCarga ent = new frmModificaCarga();
                ent.Text = "Cerrar";
                ent.modoForm = "Cerrar";

                ent.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void hopeSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (hopeSwitch1.Checked == true)
            {
                Servicios datos = new Servicios();

                var lst2 = datos.llenaChofer();

                cmbSucDest.DisplayMember = "C3";
                cmbSucDest.ValueMember = "C1";
                cmbSucDest.DataSource = lst2;
                
            }
        }
    }
}

