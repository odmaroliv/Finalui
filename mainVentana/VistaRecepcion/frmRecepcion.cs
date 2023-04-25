
using ClosedXML.Excel;
using Datos.Datosenti;
using Datos.ViewModels;
using Datos.ViewModels.Recepciones;
using Datos.ViewModels.Salidas;
using mainVentana.VistaOrSalida;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaRecepcion
{
    public partial class frmRecepcion : Form
    {
        public frmRecepcion()
        {
            InitializeComponent();
        }
        string ulSalidaPSolo = "";
        string ulDato = "";
        string ulDatoSolo = "";
        string sRecepcion = "";
        int iniciodesalida = 0;



        //abre la ventana de seleccion de ordenes de salida
        private void btnAlta_Click(object sender, EventArgs e)
        {
            using (frmListaSalidasRecep oc = new frmListaSalidasRecep())
            {
                oc.pasado += new frmListaSalidasRecep.pasar(agrgaCargatabla);
                oc.cerrado += new frmListaSalidasRecep.cerrar(BuscaentradasCarga);
                oc.sOrigen = sRecepcion;

                oc.sEnvia = cmbSucOrigen.SelectedValue.ToString().Trim();


                oc.ShowDialog();
                oc.pasado -= new frmListaSalidasRecep.pasar(agrgaCargatabla);
                oc.cerrado -= new frmListaSalidasRecep.cerrar(BuscaentradasCarga);

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
                    MessageBox.Show("Esa Recepcion ya esta cargada");
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

        //Valida el origen y el destino (otra)
        private void ValidaOrigen(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Name == "rbOTJ")
            {
                sRecepcion = "TJ";
                lblSalida.ForeColor = Color.Blue;

            }
            if (rb.Name == "rbOCSL")
            {
                sRecepcion = "CSL";
                lblSalida.ForeColor = Color.DarkViolet;

            }
            if (rb.Name == "rbOSD")
            {
                sRecepcion = "SD";
                lblSalida.ForeColor = Color.Red;

            }
            iniciodesalida = 0;
            BuscaUltimaSalida(sRecepcion);

        }


        private void BuscaUltimaSalida(string suc)
        {
            if (ulSalidaPSolo == "")
            {

                if (iniciodesalida == 0)
                {

                    //List<string> lista1 = new List<string>();
                    Negocios.AccesoRecepciones.ngAccesoRecepciones sls = new Negocios.AccesoRecepciones.ngAccesoRecepciones();
                    var lista1 = sls.ultimaRecepcionsql(sRecepcion, 50);


                    foreach (var i in lista1)
                    {
                        int sl = Convert.ToInt32(i.recep.ToString());
                        ulDato = sRecepcion + "-UD5001-" + sl.ToString("D7");
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
                ulDato = sRecepcion + "-UD5001-" + sl;
                lblSalida.Text = ulDato;
                ulDatoSolo = sl.ToString();
            }

        }
        List<vmEntBySalida> lista = new List<vmEntBySalida>();
        private async void BuscaentradasCarga()
        {
            Negocios.AccesoRecepciones.ngAccesoRecepciones datos = new Negocios.AccesoRecepciones.ngAccesoRecepciones();

            dgvOrdenesEntrada.DataSource = null;
           string  sEnvia = cmbSucOrigen.SelectedValue.ToString().Trim();


            lista.Clear();
            foreach (DataGridViewRow i in dgvListaCargas.Rows)
            {
                lista.AddRange(await datos.CargaEntBySalida(i.Cells[0].Value.ToString().Trim(), sRecepcion, sEnvia));
            }
           
            //ValidatablaObserva();
            Validatabla();
            ValidatablaObserva();
            dgvOrdenesEntrada.DataSource = lista;

            new Guna.UI.Lib.ScrollBar.DataGridViewScrollHelper(dgvOrdenesEntrada, gsbCargaEti, true);

            datos = null;






        }
        private void Validatabla()
        {

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
        }

        private void ValidatablaObserva()
        {

            List<vmEntBySalida> lst2 = new List<vmEntBySalida>();
            foreach (DataGridViewRow i in dgvListaCargas.Rows)
            {
                lst2.Add(new vmEntBySalida { Salida = i.Cells[0].Value.ToString().Trim() });
            }
            List<vmEntBySalida> lst3 = new List<vmEntBySalida>();
            foreach (DataGridViewRow i in dgvEscaneados.Rows)
            {
                lst3.Add(new vmEntBySalida { Salida = i.Cells[1].Value == null ? "No se encontro" : i.Cells[1].Value.ToString().Trim(), Etiqueta = i.Cells[0].Value == null ? "" : i.Cells[0].Value.ToString().Trim() });
            }
            //var noExistewn = (from t in lst3 where lst2.Select(x=>x.Carga).Any(t.Carga.Trim()!=) select t).ToList();
            var noExisten = lst3.Where(ds => !lst2.Any(db => db.Salida == ds.Salida)).ToList();


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
                        row.Cells[1].Value = "No se encotro en ninguna Recepcion Cargada en este documento";
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



        private int ValidacionesGenerales()
        {
            int error = 0;
            if (dgvListaCargas.RowCount == 0)
            {
                MessageBox.Show("No se han seleccionado Cargas");
                error = 1;
            }
            if (sRecepcion == "")
            {
                MessageBox.Show("Es necesario selccionar una sucursal de Origen");
                error = 1;
            }
            if (txbReferencia.Text.Trim() == "" || txbReferencia.Text.Length<2)
            {
                MessageBox.Show("Es necesario agregar una referencia");
                error = 1;
            }


            return error;
        }


        private async void AltKDMENT(string eti)
        {
            if (sRecepcion == "SD")
            {
                await ModificaKDMENTsd(sRecepcion, eti);
            }

            if (sRecepcion == "CSL")
            {
                await ModificaKDMENTsd(sRecepcion, eti);
            }


            if (sRecepcion == "TJ")
            {
                await ModificaKDMENTtj(sRecepcion, eti);
            }

        }

        private void txbEscaneo_Leave(object sender, EventArgs e)
        {
            if (MessageBox.Show("para dejar de scannear dá click en CANCELAR", "Cuidado", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                txbEscaneo.Focus();
            }
        }



        private void txbEscaneo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            string etiqueta = ObtenerEtiquetaEscaneada();
            if (EtiquetaYaEscaneada(etiqueta))
            {
                txbEscaneo.Text = "";
                return;
            }
            int fila = BuscarFilaEtiqueta(etiqueta);
            if (fila != -1)
            {
                ProcesarEtiquetaEncontrada(etiqueta, fila);
            }
            else
            {
                ProcesarEtiquetaNoEncontrada(etiqueta);
            }

            txbEscaneo.Text = "";
        }

        private string ObtenerEtiquetaEscaneada()
        {
            return txbEscaneo.Text.Trim().ToUpper().Replace("'", "-");
        }

        private bool EtiquetaYaEscaneada(string etiqueta)
        {
            if (dgvEscaneados.Rows.Count == 0) return false;

            if (CheckDataGridView(dgvEscaneados, etiqueta))
            {
                lblMensaje.Text = $"La etiqueta {etiqueta} ya fue escaneada";
                txbEscaneo.Text = "";
                return true;
            }

            if (CheckDataGridView(dgvObser, etiqueta))
            {
                lblMensaje.Text = $"La etiqueta {etiqueta} Ya esta en la tabla de Obs";
                return true;
            }

            return false;
        }

        private int BuscarFilaEtiqueta(string etiqueta)
        {
            foreach (DataGridViewRow rowOrdenes in dgvOrdenesEntrada.Rows)
            {
                if (rowOrdenes.Cells[0].Value.ToString().Trim() == etiqueta)
                {
                    return rowOrdenes.Index;
                }
            }

            return -1;
        }

        private void ProcesarEtiquetaEncontrada(string etiqueta, int fila)
        {
            AltKDMENT(etiqueta);
            var correoOrden = new Negocios.Acceso_Salida.AccesoSalidas().ObtieCorreo(etiqueta);
            lista.RemoveAt(lista.FindIndex(a => a.Etiqueta.Trim().Equals(etiqueta)));
            dgvOrdenesEntrada.DataSource = null;
            dgvOrdenesEntrada.DataSource = lista;

            DataGridViewRow rowEscaneados = new DataGridViewRow();
            rowEscaneados.CreateCells(dgvEscaneados);
            rowEscaneados.Cells[0].Value = string.IsNullOrEmpty(correoOrden.Etiqueta) ? $"La etiqueta: {etiqueta} No se encontro el la Base de Datos" : correoOrden.Etiqueta.Trim();
            rowEscaneados.Cells[1].Value = string.IsNullOrEmpty(correoOrden.orden) ? "" : correoOrden.orden.Trim();
            rowEscaneados.Cells[2].Value = string.IsNullOrEmpty(correoOrden.Correo) ? "" : correoOrden.Correo.Trim();
            dgvEscaneados.Rows.Add(rowEscaneados);
            lblMensaje.Text = $"Etiqueta: {etiqueta} agregada correctamente";
        }

        private void ProcesarEtiquetaNoEncontrada(string etiqueta)
        {
            AltKDMENT(etiqueta);
            var correoOrden = new Negocios.Acceso_Salida.AccesoSalidas().ObtieCorreo(etiqueta);
            DataGridViewRow rowObser = new DataGridViewRow();
            rowObser.CreateCells(dgvObser);
            rowObser.Cells[0].Value = etiqueta;
            rowObser.Cells[1].Value = "Esta etiqueta no se encotro en ninguna Orden Cargada en este documento";
            rowObser.Cells[2].Value = correoOrden;
            dgvObser.Rows.Add(rowObser);
            lblMensaje.Text = $"Etiqueta: {etiqueta} no se encontro en las ordenes cargadas";
        }


        private bool CheckDataGridView(DataGridView dgv, string etiquet)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[0].Value.ToString().Trim().Equals(etiquet))
                {
                    lblMensaje.Text = "La etiqueta " + etiquet + " Ya esta en la tabla principal";
                    return true;
                }
            }
            return false;
        }

        //Sucursal ORIGEN TIJUANA REPCEPCION
        private async Task<bool> ModificaKDMENTtj(string sucOrigen, string etiqueta)
        {

            string uld = (string)ulDato.Trim().Clone();
            //string sc = sDestino == "CSL" ? "PR" : "OC";

            //string eti = String.IsNullOrWhiteSpace(txbEscaneo.Text) ? "000000" : txbEscaneo.Text.ToString().ToUpper().Trim();
            string statusRecep =  VerificaEntrada(etiqueta, sucOrigen);
            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    List<KDMENT> kd = new List<KDMENT>();

                    try
                    {
                        var d = (from fd in modelo.KDMENT
                                 where fd.C9 == etiqueta// 
                                 select fd).First();
                        //d.C17 = uld;
                        d.C19 = sRecepcion;
                        d.C20 = statusRecep;
                        d.C23 = "";

                        d.C56 = uld;
                        d.C66 = uld;
                        d.C67 = uld;
                        d.C68 = "E";
                        d.C76 = DateTime.Now.ToString("MM/dd/yyyy");


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

            

            return true;

        }




        /// <summary>
        /// 1 = verifica si la sucursal ya es la sucursal final
        /// </summary>
        /// <param name="etiqueta">Etiqueta de la entrada a verificar</param>
        /// <param name="verificador">Indice del caso verificador</param>
        /// <returns>FALSE si no se cumple la condicion o TRUE si se resuelve correctamente</returns>
        private  string VerificaEntrada(string etiqueta,string sucActual, int verificador = default)
        {
           

            Negocios.AccesoRecepciones.ngAccesoRecepciones dt = new Negocios.AccesoRecepciones.ngAccesoRecepciones();
            var fila = dt.VerificaEntrada(etiqueta);

            string valor = default;
            if (fila.C10 != null)
            {
                if (fila.C10.Trim().Contains(sucActual.Trim()))
                {
                    valor = "F";
                }
                else
                {
                    valor = "R";
                }
            }
            else
            {
               // valor = "R";
            }
            
            return valor;
        }

        //sucursa recibe san diego o cabo
        private async Task<bool> ModificaKDMENTsd(string sucOrigen, string etiqueta)
        {

           // string eti = String.IsNullOrWhiteSpace(txbEscaneo.Text) ? "000000" : txbEscaneo.Text.ToString().ToUpper().Trim();
            string statusRecep =  VerificaEntrada(etiqueta, sucOrigen);
            // string sc = sDestino == "CSL" ? "PR" : "OC";
            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    List<Datos.Datosenti.KDMENT> kd = new List<Datos.Datosenti.KDMENT>();


                    string uld = (string)ulDato.Trim().Clone();

                    try
                    {

                        var d = (from fd in modelo.KDMENT
                                 where fd.C9 == etiqueta
                                 select fd).First();

                        d.C13 = "E";
                        d.C18 = uld;
                        //d.C18 = "";
                        d.C19 = sRecepcion;
                        d.C20 = statusRecep;

                        d.C23 = "";
                        d.C56 = uld;
                        // d.C56 = "";

                        d.C74 = DateTime.Now.ToString("MM/dd/yyyy");
                        //d.C75 = "";
                        kd.Add(d);
                        //modelo.SaveChanges();

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




            return true;
        }
        private void gunaGradientTileButton3_Click(object sender, EventArgs e)
        {
            int error = ValidacionesGenerales(); //1 error o 0 normal


            if (error == 1)
            {
                return;
            }
            string senvi = cmbSucOrigen.SelectedValue.ToString();
            if (MessageBox.Show("Estas apunto de iniciar la Recepcion,\renvía: "+senvi+"\rRecibe: "+sRecepcion+ "\rrecuerda que este numero quedara reservado hasta que la finalices formalmente", "Atencion", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                CreaRecepcionEnKDM1();
                btnIniciaSalida.Enabled = false;
                btnImportarExcel.Enabled = false;
                bntSalidaPausa.Enabled = false;
            }
        }

        private async void CreaRecepcionEnKDM1()
        {
            groupBox1.Enabled = false;
            cmbSucOrigen.Enabled = false;
            string estatuss=default;

            if (sRecepcion.Trim() == "TJ")
            {
                estatuss = "PRTJ";
            }
            if (sRecepcion.Trim() == "SD")
            {
                estatuss = "PRSD";
            }
            if (sRecepcion.Trim() == "CSL")
            {
                estatuss = "PRCSL";
            }

            BuscaUltimaSalida(sRecepcion);
            Negocios.AccesoRecepciones.altasRecepciones at = new Negocios.AccesoRecepciones.altasRecepciones();
            at.ActualizaSqlIov(sRecepcion.Trim(), 50, ulDatoSolo.Trim());
            at.CRecepcionEnKDM1(sRecepcion.Trim()
                , "U"
                , "D"
                , Convert.ToDecimal(50)
                , Convert.ToDecimal(1)
                , ulDatoSolo
                , Convert.ToDecimal(1)
                , DateTime.Now
                , txbReferencia.Text
                , 1
                , DateTime.Now
                , txbNotas.Text
                , "Rec"
                , estatuss //P es un nuevo estatus que significa pausado
                , "UD5001-"
                , Negocios.Common.Cache.CacheLogin.username.ToString()
                , DateTime.Now
                , cmbSucOrigen.SelectedValue.ToString().Trim());
            btnIniciaSalida.Enabled = false;
            bntSalidaPausa.Enabled = false;

        }

        private void gunaGradientTileButton2_Click_1(object sender, EventArgs e)
        {
            using (frmBuscarRecepP oc = new frmBuscarRecepP())
            {
                oc.pasadoS += new frmBuscarRecepP.pasarS(CargaLisataSalidas);
                oc.sOrigen = sRecepcion;

                oc.ShowDialog();
            }


        }

        private async void CargaLisataSalidas(string dato)
        {
            if (dato.Trim().Contains(ulDato))
            {
                return;
            }
            Negocios.AccesoRecepciones.ngAccesoRecepciones sls = new Negocios.AccesoRecepciones.ngAccesoRecepciones();
            string sEnvia = cmbSucOrigen.SelectedValue.ToString().Trim();
            ulSalidaPSolo = dato;
            var lista1 = await sls.BuscEntradasEnRecepcion(dato, sRecepcion, sEnvia);
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
            BuscaUltimaSalida(sRecepcion);


            var lss = await sls.LlenaDGVpausadas(ulDatoSolo);
            foreach (var q in lss)
            {
                string datoSalida = "";
                if (sRecepcion.Contains("TJ"))
                {
                    datoSalida = cmbSucOrigen.SelectedValue.ToString().Trim() + "-UD4501-" + q.Documento;
                }
                else
                {
                    datoSalida = cmbSucOrigen.SelectedValue.ToString().Trim() + "-UD4501-" + q.Documento;
                }

                agrgaCargatabla(datoSalida);
            }
            BuscaentradasCarga();

            await CargaGenerales();
            btnIniciaSalida.Enabled = false;
            groupBox1.Enabled = false;

            btnImportarExcel.Enabled = false;
            cmbSucOrigen.Enabled = false;

        }
        private async Task CargaGenerales()
        {
            Negocios.AccesoRecepciones.ngAccesoRecepciones sls = new Negocios.AccesoRecepciones.ngAccesoRecepciones();

            var gn = await sls.LlenaGeneralesRecepcion(ulDatoSolo, sRecepcion);
            try
            {
                foreach (var i in gn)
                {


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

                    foreach (Sucursales r in cmbSucOrigen.Items)
                    {
                        if (r.c1.Trim() == i.Placas.Trim())
                        {
                            cmbSucOrigen.SelectedValue = r.c1;
                            break;

                        }

                    }


                    txbReferencia.Text = i.Referencia.ToString();
                    txbNotas.Text = i.Chofer.ToString();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hay un problema con las sucursales, se han cargado o guardado mal, por favor contacta al administrador del sistema");
            }
          

        }
        private async Task ModificaKDM1()
        {



            Negocios.AccesoRecepciones.altasRecepciones at = new Negocios.AccesoRecepciones.altasRecepciones();

            foreach (DataGridViewRow q in dgvListaCargas.Rows)
            {

                char[] ch = "-".ToCharArray();
                string datosalida = ulSalidaPSolo == "" ? ulDatoSolo : ulSalidaPSolo.Split(ch)[2];
                string dato = q.Cells[0].Value.ToString().Trim();
                string datolimpio = dato.Split(ch)[2];
                await at.ModificaStatusRecepcionSDCSL(sRecepcion, datosalida, datolimpio);


            }


            btnIniciaSalida.Enabled = false;
            bntSalidaPausa.Enabled = false;

        }

        private async Task FinalizaSalidaKDM1()
        {

            int error = ValidacionesGenerales();


            if (error == 1)
            {
                Notifica(2, ulDatoSolo);
                return;
               
            }

            else
            {
                BuscaUltimaSalida(sRecepcion);
                Negocios.AccesoRecepciones.altasRecepciones at = new Negocios.AccesoRecepciones.altasRecepciones();
                char[] ch = "-".ToCharArray();
                string datosalida = ulSalidaPSolo == "" ? ulDatoSolo : ulSalidaPSolo.Split(ch)[2];
                await at.TerminaRecepcion(ulDatoSolo, sRecepcion);
                Notifica(1, ulDatoSolo);
            }
        }

        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            if (ValidacionesGenerales() == 0)
            {
                if (dgvEscaneados.Rows.Count > 0)
                {
                    if (MessageBox.Show("Estás a punto de cerrar la Recepción \nA partir de aquí ya no se podrá modificar \nContinuar?", "Alerta", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        FinalizaSalidaKDM1();
                        iniciodesalida = 0;
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

                        MessageBox.Show("Salida: " + ulDatoSolo + " con origen: " + sRecepcion + " finalizada");
                       
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

                    Etiqueta = dgvEscaneados.Rows[i].Cells[0].Value == null ? "" : dgvEscaneados.Rows[i].Cells[0].Value.ToString().Trim(),
                    Pertenece = dgvEscaneados.Rows[i].Cells[1].Value == null ? "" : dgvEscaneados.Rows[i].Cells[1].Value.ToString().Trim(),
                    Correo = dgvEscaneados.Rows[i].Cells[2].Value == null ? "" : dgvEscaneados.Rows[i].Cells[2].Value.ToString().Trim(),

                });
            }
            for (int i = 0; i < filasA; i++)
            {
                list.Add(new vmEnviodeNotificacion
                {
                    Etiqueta = dgvObser.Rows[i].Cells[0].Value == null ? "" : dgvObser.Rows[i].Cells[0].Value.ToString().Trim(),
                    notas = "Esta entrada no se encontro en ninguna orden cargada en esta recepción (Pordria no existir)",
                    Correo = dgvObser.Rows[i].Cells[2].Value == null ? "sistemas@arnian.com" : dgvObser.Rows[i].Cells[2].Value.ToString().Trim()

                });

            }
            for (int i = 0; i < filasO; i++)
            {
                list.Add(new vmEnviodeNotificacion
                {
                    Etiqueta = dgvOrdenesEntrada.Rows[i].Cells[0].Value == null ? "" : dgvOrdenesEntrada.Rows[i].Cells[0].Value.ToString().Trim(),
                    NoCargadas = "ESTA ETIQUETA NO FUE ESCANEADA EN ESTA RECEPCION A PESAR DE ESTAR EN LAS ÓRDENES DE CARGA."

                    //Correo = string.IsNullOrEmpty(dgvObser.Rows[i].Cells[2].Value.ToString()) ? "" : dgvObser.Rows[i].Cells[2].Value.ToString().Trim(),

                });


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
            string fullPath = folder + hoy + "-Recepcion-" + ulDato + ".xlsx";

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);




            new frmRecepcion().Export<vmEnviodeNotificacion>(dato, fullPath, "Recepcion");
           



            string plantilla = Properties.Resources.salidacorreo.ToString();
            plantilla = plantilla.Replace("@nSalida", ulDato);



            int bandera = 0;
            List<string> lscorreos = new List<string>();

            foreach (var q in correos)
            {
                if (!string.IsNullOrEmpty(q))
                {
                    if (q != null)
                    {
                        lscorreos.Add(q);
                    }

                    //bandera = bandera + 1;
                }

            }
            String[] str = lscorreos.ToArray();

            try
            {
              //  await llamasmtp(plantilla, str, fullPath, ulDato, bandera);
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

        private void frmRecepcion_Load(object sender, EventArgs e)
        {
            Servicios datos = new Servicios();
            var lst2 = datos.llenaSuc();
            var lst2_2 = new List<Sucursales>(lst2);

            cmbSucOrigen.DisplayMember = "C2";
            cmbSucOrigen.ValueMember = "C1";
            cmbSucOrigen.DataSource = lst2;
            foreach (var i in from Sucursales i in cmbSucOrigen.Items

                              select i)
            {
                cmbSucOrigen.SelectedValue = i.c1;
                break;
            }
            datos = null;
        }
      

        private void Notifica(int nttipo, string nsalida)
        {

            //   2 = ERROR
            //  1 = EXITO



            if (nttipo == 1)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Text = nsalida + " CARGADA";
                notifyIcon1.BalloonTipTitle = "Sin Errores: Recepcion terminada " + nsalida;
                notifyIcon1.BalloonTipText = "Se ha cargado la recepcion: " + nsalida + " sin eerores\r\n";
                notifyIcon1.ShowBalloonTip(10000);


            }
            else if (nttipo == 2)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Text = nsalida + " ERROR: la Recepcion contiene errores";
                notifyIcon1.BalloonTipTitle = " ERROR: no se han cargado todas las etiquetas " + nsalida;
                notifyIcon1.BalloonTipText = " algunas etiquetas no fueron cargadas en la recepcion: " + nsalida;
                notifyIcon1.ShowBalloonTip(10000);

            }

        }



    }
}
