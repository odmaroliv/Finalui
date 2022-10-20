using Datos.Datosenti;
using Datos.ViewModels.Salidas;
using Negocios;
using Negocios.Acceso_Salida;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public frmOrdSalida()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {

            frmBuscarOrdCarga oc = new frmBuscarOrdCarga();
            oc.pasado += new frmBuscarOrdCarga.pasar(agrgaCargatabla);
            oc.cerrado += new frmBuscarOrdCarga.cerrar(BuscaentradasCarga);
            oc.sorigen = sOrigen;
            oc.sucsdest = sDestino;
            oc.ShowDialog();

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
                lista.AddRange(await datos.CargaEntByCarga(i.Cells[0].Value.ToString().Trim()));
            }
            Validatabla();
            dgvOrdenesEntrada.DataSource = lista;
            datos = null;




        }

        private void Validatabla()
        {

            foreach (DataGridViewRow i in dgvEscaneados.Rows)
            {

                foreach (var e in lista)
                {
                    if (e.Etiqueta.Contains(i.Cells[0].Value.ToString().Trim()))
                    {
                        int index = lista.FindIndex(a => a.Etiqueta.Trim().Contains(i.Cells[0].Value.ToString().Trim()));
                        lista.RemoveAt(index);
                        break;
                    }
                }



            }

        }

        private void btnScanini_Click(object sender, EventArgs e)
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

            return error;
        }

        private void txbEscaneo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                //---------------------------------------------------------------------

                string etiqueta = txbEscaneo.Text.Trim();
                int fila = -1;


                int bandera = 0;

                foreach (DataGridViewRow i in dgvOrdenesEntrada.Rows)
                {
                    if (i.Cells[0].Value.ToString().Trim() == etiqueta)
                    {
                        bandera = 1;
                        fila = i.Index;
                        break;
                    }
                    else
                    {
                        bandera = 0;

                    }
                }

                if (bandera == 1)
                {
                    AltKDMENT();



                    int index = lista.FindIndex(a => a.Etiqueta.Trim().Contains(etiqueta));
                    lista.RemoveAt(index);
                    dgvOrdenesEntrada.DataSource = null;
                    dgvOrdenesEntrada.DataSource = lista;

                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvEscaneados);

                    row.Cells[0].Value = etiqueta;


                    dgvEscaneados.Rows.Add(row);


                    lblMensaje.Text = "Etiqueta agregada correctamente";

                }
                else
                {
                    lblMensaje.Text = "Esta etiqueta no se encotro en ninguna Orden Cargada en este documento";
                }



            }
        }

        private async void CreaSalidaEnKDM1()
        {


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
                , "P"
                , "UD4501-"
                , Negocios.Common.Cache.CacheLogin.idusuario.ToString()
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
                await at.ModificaStatusSalida(datosalida, datolimpio);


            }


            btnIniciaSalida.Enabled = false;
            bntSalidaPausa.Enabled = false;

        }

        private async void AltKDMENT()
        {
            if (sDestino == "TJ" && sOrigen == "SD")
            {
                await ModificaKDMENTsd();
            }

            if (sDestino == "CSL" && sOrigen == "SD")
            {
                await ModificaKDMENTsd();
            }


            if (sDestino == "SD" && sOrigen == "TJ")
            {
                await ModificaKDMENTtj();
            }
            if (sDestino == "CSL" && sOrigen == "TJ")
            {

                await ModificaKDMENTtj();
            }
            if (sDestino == "TJ" || sDestino == "SD" && sOrigen == "CSL")
            {
                await ModificaKDMENTsd();
            }
        }

        //Sucursal destino cabo sucursal origen tijuana
        private async Task<bool> ModificaKDMENTtj()
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
                                 where fd.C9 == txbEscaneo.Text.ToString().ToUpper().Trim()// 
                                 select fd).First();
                        //d.C17 = uld;
                        d.C19 = sOrigen;
                        d.C20 = sc;
                        d.C23 = "";
                        d.C55 = uld;
                        d.C56 = "";

                        d.C63 = uld;
                        d.C64 = uld;
                        d.C65 = "E";
                        d.C66 = "";
                        d.C67 = "";
                        d.C68 = "";
                        d.C75 = DateTime.Now.ToString("dd/MM/yyyy");
                        kd.Add(d);
                    }

                    catch (Exception)
                    {

                        throw;

                    }

                    modelo.BulkUpdate(kd.ToList());

                }
            });




            //----------------------------------------



            return true;

        }

        private async Task<bool> ModificaKDMENTsd()
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
                                 where fd.C9 == txbEscaneo.Text.ToString().ToUpper().Trim()// 
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
                        d.C73 = DateTime.Now.ToString("dd/MM/yyyy");
                        d.C75 = "";
                        kd.Add(d);
                        //modelo.SaveChanges();

                    }
                    catch (Exception J)
                    {

                        throw;
                    }


                    modelo.BulkUpdate(kd.ToList());
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
            }


        }

        private void gunaGradientTileButton2_Click_1(object sender, EventArgs e)
        {
            frmBuscarOrdSalida oc = new frmBuscarOrdSalida();
            oc.pasadoS += new frmBuscarOrdSalida.pasarS(CargaLisataSalidas);
            oc.sorigen = sOrigen;
            oc.sucsdest = sDestino;
            oc.ShowDialog();
        }

        private async void CargaLisataSalidas(string dato)
        {
            if (dato.Trim().Contains(ulDato))
            {
                return;
            }
            Negocios.Acceso_Salida.AccesoSalidas sls = new Negocios.Acceso_Salida.AccesoSalidas();
            
            ulSalidaPSolo = dato;
            var lista1 = await sls.BuscEntradasEnSalida(dato);
            dgvEscaneados.DataSource = null;
            dgvEscaneados.Rows.Clear();
            dgvEscaneados.Refresh();

            dgvListaCargas.Rows.Clear();
            dgvListaCargas.Refresh();

            foreach (var i in lista1)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvEscaneados);

                row.Cells[0].Value = i.Documento;


                dgvEscaneados.Rows.Add(row);
            }
            BuscaUltimaSalida(sOrigen);


            var lss = await sls.LlenaDGVpausadas(ulDatoSolo);
            foreach (var q in lss)
            {
                string datocarga = sOrigen + "-UD4001-" + q.Documento;
                agrgaCargatabla(datocarga);
            }
            BuscaentradasCarga();
            await CargaGenerales();
            btnIniciaSalida.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;

        }
        private async Task CargaGenerales()
        {
            Negocios.Acceso_Salida.AccesoSalidas sls = new Negocios.Acceso_Salida.AccesoSalidas();

            var gn = await sls.LlenaGeneralesSalida(ulDatoSolo);

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


    }


}
