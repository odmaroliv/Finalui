using Datos.Datosenti;
using Datos.ViewModels;
using Datos.ViewModels.Carga;
using Datos.ViewModels.Entradas;
using Datos.ViewModels.Servicios;
using DocumentFormat.OpenXml.Presentation;
using iTextSharp.text.pdf.codec.wmf;
using mainVentana.VistaBill;
using mainVentana.VistaEntrada;
using mainVentana.VistaOrSalida;
using Negocios;
using Negocios.NGBill;
using Negocios.NGCarga;
using Negocios.NGReportes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaInicioCoordinadores
{
    public partial class frmAddToCarga : Form
    {
        private string sucursal = "SD";
        string datoTipoOper = "";
        private bool _isBussy = false;
        private DateTime _cierreFecha = DateTime.Now;
        private bool _isBill = false;
        private List<vmEntradasEnCarga> listaBultos = new List<vmEntradasEnCarga>();
        private List<vmEntradasEnCarga> entradasCargadas = new List<vmEntradasEnCarga>();


        private string _numeroBill = "";

        private string calle;
        private string colonia;
        private string estado;
        private string zipp;
        private string numm;

        private bool _infoDesdeAlias = false;

        public frmAddToCarga()
        {
            InitializeComponent();
        }

        private async void btnAlta_Click(object sender, EventArgs e)
        {
            ActualizarProgreso(5);

            await OperacionBoton();
           // await CargaEntradas();
        }

        private async Task OperacionBoton()
        { 
            ActualizarProgreso(40);
            LimpiaDatos();
           
            try
            {
                dtgSinAsignar.Enabled = false;
                btnAlta.Enabled = false;
                ActualizarProgreso(50);
                if (_isBussy == true)
                {
                    await ProgressRetro();
                    return;
                }
                ActualizarProgreso(60);

                if (swBill.Checked == false)
                {
                    await CargaOrdenes();

                }
                //await CargaOrdenes();
                ActualizarProgreso(70);
                await CargaEntradas();
                ActualizarProgreso(80);
                ActualizarProgreso(100);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                btnAlta.Enabled = true;
                dtgSinAsignar.Enabled = true;
                await ProgressRetro();
            }
        }

        private async void ActualizarProgreso(int valorFinal)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action(() => ActualizarProgreso(valorFinal)));
            }
            else
            {
                // Si el valor es mayor que el actual, incrementamos.
                if (valorFinal > progressBar1.Value)
                {
                    for (int i = progressBar1.Value; i <= valorFinal; i++)
                    {
                        progressBar1.Value = i;
                        await Task.Delay(10); 
                    }
                }
                // Si el valor es menor que el actual, decrementamos.
                else
                {
                    for (int i = progressBar1.Value; i >= valorFinal; i--)
                    {
                        progressBar1.Value = i;
                        await Task.Delay(10); 
                    }
                }
            }
        }


        private async Task ProgressRetro()
        {
            
                progressBar1.Value = 0;
                progressBar1.Visible = false;
        }

        private async void frmAddToCarga_Load(object sender, EventArgs e)
        {
            dtFecha1.Value = DateTime.Now.AddDays(-80);
            dtFecha2.Value = DateTime.Now.AddDays(1);
            dtFecha1.MinDate = DateTime.Now.AddDays(-9000);
            dtFecha1.MaxDate = DateTime.Now.AddDays(90);
            dtFecha2.MinDate = DateTime.Now.AddDays(-900);
            dtFecha2.MaxDate = DateTime.Now.AddDays(90);

            //CargaOrdenes();
            await CargaOperaciones();
            await Task.Run(() => CargaSOrigen()); ;
            

        }
        private void CargaSOrigen()
        {
            Servicios datos = new Servicios();
            var lst2 = datos.llenaSuc();
         

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

            }));

            datos = null;
        }
        private async Task CargaOrdenes()
        {

            cbxOrdenes.DataSource = null;
            await Task.Run(() =>
            {

                this.Invoke(new Action(() =>
                {

                    try
                    {
                        DateTime dFechaServicio = regresafecha();
                        datoTipoOper = tipoOper.SelectedValue.ToString().Trim();
                        Negocios.NGCarga.GETcarga get = new Negocios.NGCarga.GETcarga();

                        var lst7 = get.ObtieneCargasDeEntrega(sucursal, datoTipoOper, dFechaServicio);

                        cbxOrdenes.DisplayMember = "numeroCarga";
                        cbxOrdenes.ValueMember = "numeroCarga";
                        cbxOrdenes.DataSource = lst7;

                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }));


            });

        }

        private DateTime regresafecha()
        {
            Servicio datos = new Servicio();
            try
            {
                string fecha1 = datos.retornafechaLapaz();
                FechaActual lst = JsonConvert.DeserializeObject<FechaActual>(fecha1);
                DateTime fechaActual = lst.datetime;
                return fechaActual;
            }
            catch (Exception ex)
            {
                // Si hay una excepción, devuelve la fecha actual del equipo
                return DateTime.Now;
            }
        }

        private async Task CargaOperaciones()
        {
            Servicios datos = new Servicios();

            var lst7 = await datos.llenaOpera();

            tipoOper.DisplayMember = "C2";
            tipoOper.ValueMember = "C1";
            tipoOper.DataSource = lst7;
        }

        private async void cbxOrdenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmboBox = (ComboBox)sender;
            string valor = cmboBox.SelectedValue != null ? cmboBox.SelectedValue.ToString() : "000000000";
            if (valor == "000000000")
            {
                return;
            }
            try
            {
                GETcarga get = new GETcarga();
                var lst = await get.ObtieneOrdenDeCargaPorIdYSucursal(sucursal, valor);
                /*foreach (vmTOperacion i in tipoOper.Items)
                {
                    if (i.c1.Trim() == lst.tipoOperacion.Trim())
                    {
                        tipoOper.SelectedValue = i.c1;
                        break;
                    }
                }*/
                txbCarga.Text = lst.numeroCarga.ToString();
                tmCierre.Value = (DateTime)lst.fechaCierre;
                _cierreFecha = (DateTime)lst.fechaCierre;
                txbReferencia.Text = lst.referencia;

                CargaEntradaEnDgv(lst.numeroCarga.ToString());
            }
            catch (Exception)
            {

                throw;
            }
            //await OperacionBoton();

        }

        private void CargaEntradaEnDgv(string nCarga)
        {
            entradasCargadas.Clear();
            Negocios.NGCarga.GETcarga get = new Negocios.NGCarga.GETcarga();
            entradasCargadas = get.EntradasEnCargaConUsuario(sucursal, Convert.ToInt32(nCarga), datoTipoOper);
            dgvCargadas.DataSource = entradasCargadas;

        }
        List<CargaCordsGeneral> lssGlobal = null;

        private async Task CargaEntradas()
        {
            _isBussy = true;
            try
            {
                ngbdReportes rep = new ngbdReportes();
                lssGlobal = await rep.CargaEntradasParaAsignarACarga(sucursal, dtFecha1.Value, dtFecha2.Value, datoTipoOper);
                var etiquetasCargadas = entradasCargadas.Select(e => e.Etiqueta).ToList();
                lssGlobal = lssGlobal.Where(e => !etiquetasCargadas.Contains(e.bulto)).ToList();

                dtgSinAsignar.DataSource = lssGlobal;

             
            }
            catch (Exception)
            {
                throw;
            }
            finally { _isBussy = false; }
        }

       

        /*
        private async void rSd_CheckedChanged(object sender, EventArgs e)
        {

            LimpiaDatos();

            var radioButtonMapping = new Dictionary<RadioButton, string>
                {
        { rSd, "SD" },
        { rTj, "TJ" },
        { rCa, "CSL" },

                 };

            // Encontrar el RadioButton seleccionado y obtener su valor correspondiente
            sucursal = radioButtonMapping.FirstOrDefault(r => r.Key.Checked).Value;
           // await OperacionBoton();
           // await CargaEntradas();
        }
        */
        private void LimpiaDatos()
        {
            
            lssGlobal?.Clear();
            entradasCargadas?.Clear();
            listaBultos.Clear();
            dgvCargadas.DataSource = null;
            dtgSinAsignar.DataSource = null;
            dtgAsignados.DataSource = null;
            txbCarga.Text = default;
            tmCierre.Value = DateTime.Now;
            cbxOrdenes.DataSource = default;
            txbReferencia.Text = default;
        }

        private void dtgSinAsignar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = sender as DataGridView;

            // Comprueba si el clic fue en la columna "bulto"
            if (dataGridView.Columns[e.ColumnIndex].Name == "bulto")
            {
                string valorBulto = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string entradaEtiqueta = dataGridView.Rows[e.RowIndex].Cells["entrada"].Value.ToString();
                if (!listaBultos.Any(x => x.Etiqueta == valorBulto))
                {
                    listaBultos.Add(new vmEntradasEnCarga
                    {
                        Etiqueta = valorBulto,
                        Entrada = entradaEtiqueta,
                    });
                }

            }
            if (dataGridView.Columns[e.ColumnIndex].Name == "entrada")
            {
                try
                {
                    string valorEntrada = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        string bultoEtiqueta = row.Cells["bulto"].Value.ToString(); // reemplaza "bulto" con el nombre de tu columna de bulto
                        string entradaEtiqueta = row.Cells["entrada"].Value.ToString(); // reemplaza "Entrada" con el nombre de tu columna de entrada

                        if (entradaEtiqueta == valorEntrada && !listaBultos.Any(x => x.Etiqueta == bultoEtiqueta))
                        {
                            listaBultos.Add(new vmEntradasEnCarga
                            {
                                Etiqueta = bultoEtiqueta,
                                Entrada = entradaEtiqueta
                            });
                        }
                    }
                }
                catch (Exception)
                {

                   
                }
               

            }
            dtgAsignados.DataSource = null;
            dtgAsignados.DataSource = listaBultos;
            txbTotal.Text = dtgAsignados.Rows.Count.ToString();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            ActualizarProgreso(5);
            if (dtgAsignados.Rows.Count == 0)
            {
                ProgressRetro();
                return;

            }
            if (swBill.Checked == true)
            {
                cargaultbillRefuerzo();
            }
            else
            {

            }
            ActualizarProgreso(10);
            await EjecutaFuncionDeModifica();
            ActualizarProgreso(50);
            await OperacionBoton();
        }

        private async Task EjecutaFuncionDeModifica()
        {
            ActualizarProgreso(15);
            if (datoTipoOper == "")
            {
                MessageBox.Show("No se ha seleccionado una operación");
                ProgressRetro();
                return;
            }
            if (datoTipoOper == "BILL")
            {
                if (String.IsNullOrWhiteSpace(txbAliasAct.Text))
                {

                    if (MessageBox.Show("Al parecer no has asignado una dirección\n" + "¿Deseas continua?", "Cuidado", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        ProgressRetro();
                        return;
                    }
                }
                ActualizarProgreso(20);
                txbCarga.Text = "";
                _isBussy = true;
                btnGuardar.Enabled = false;

                DateTime datoFecha = regresafecha();
               
                string fechaHoy = datoFecha == null ? DateTime.Now.ToString("MM/dd/yyyy") : datoFecha.ToString("MM/dd/yyyy");
              
                Negocios.NGCarga.altasBDCarga get = new Negocios.NGCarga.altasBDCarga();
                bool st = crearBillkdm1();
                string b_so = sucursal;
                string b_car = _numeroBill;
                string b_billCompleto = b_so + "-UD5501-" + b_car;
                ActualizarProgreso(30);
                //  AltasBD bd = new AltasBD();
                AsignaDatosSireccion();
                
                if (st)
                {
                    ActualizarProgreso(35);
                    bool dato = await get.AsignarABill(listaBultos, b_billCompleto, fechaHoy, calle, colonia, estado, txbAliasAct.Text, zipp, numm, datoTipoOper);
                    if (dato == false)
                    {
                        MessageBox.Show("Ocurrio un error intente de nuevo");
                    }
                    else
                    {
                        MessageBox.Show("Documento " + _numeroBill + " creado con exito", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Notificacion(1, "El documento: " + _numeroBill + "\r\rSe asigno correctamente.", "Exito ");
                        Clipboard.SetText(_numeroBill);
                        ActualizarProgreso(40);
                        cargaImprime();
                        cargaultbill();
                        await OperacionBoton();
                    }
                }
                
            }
            else
            {
                if (String.IsNullOrWhiteSpace(txbCarga.Text))
                {
                    return;
                }
                if (txbCarga.Text == "")
            {
                MessageBox.Show("No hay ninguna Orden");
                return;
            }
            try
            {
                _isBussy = true;
                btnGuardar.Enabled = false;
                DateTime datoFecha = regresafecha();
                string fechaHoy = datoFecha == null ? DateTime.Now.ToString("MM/dd/yyyy") : datoFecha.ToString("MM/dd/yyyy");
                //DataGridViewRow selectedRow = dtgCargasFilter.Rows[dtgCargasFilter.SelectedCells[0].RowIndex];
                string c_so = sucursal;
                string c_car = txbCarga.Text.Trim();
                string c_cargacompleta = c_so + "-UD4001-" + c_car;

                // string e_eti = txbEntradaDetalle.Text.Trim();
                //string e_so = sucursal;
                Negocios.NGCarga.altasBDCarga get = new Negocios.NGCarga.altasBDCarga();
                bool dato = await get.AsignaCargaAEntradaEspesifica(listaBultos, c_cargacompleta, fechaHoy, datoTipoOper);
                //MessageBox.Show("La entrada: " + e_en + " fue asignada con exito a la carga " + c_cargacompleta, "Carga asignada", MessageBoxButtons.OK);
                if (dato == false)
                {
                    MessageBox.Show("Ocurrio un error");
                }
                else
                {
                    MessageBox.Show("Asignación Correcta");
                    await OperacionBoton();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                btnGuardar.Enabled = true;
                _isBussy = false;
            }
            }
        }
        private void AsignaDatosSireccion()
        {
            
            if (_infoDesdeAlias == false)
            {
                calle = txbPcalle.Text;
                colonia = txbPcolonia.Text;
                estado = txbPpoblacion.Text;
                zipp = txbPcp.Text;
                numm = txbTel.Text;
            }


        }
        private void cargaImprime()
        {
            using (frmConsultaBill bll = new frmConsultaBill())
            {
                bll.ShowDialog();
            }

        }
        private async void tipoOper_SelectedIndexChanged(object sender, EventArgs e)
        {

            LimpiaDatos();

            datoTipoOper = tipoOper.SelectedValue.ToString().Trim();
            ComboBox cmboBox = (ComboBox)sender;
            string valor = cmboBox.SelectedValue != null ? cmboBox.SelectedValue.ToString() : "000000000";
            if (valor == "09")
            {
                swBill.Enabled= true;
               // await OperacionBoton();
            }
            else
            {
                swBill.Enabled = false;
              //  await OperacionBoton();
            }

        }

        private void swBill_CheckedChanged(object sender, EventArgs e)
        {
            if (swBill.Checked == true)
            {

                _isBill = true;
                tipoOper.Enabled = false;
                datoTipoOper = "BILL";
                groupBox1.Enabled = false;
                cargaultbill();
                cargaultbillRefuerzo();
            }
            else
            {
                _isBill = false;
                tipoOper.Enabled = true;
                datoTipoOper = "";
                lblnBill.Text = "";
                groupBox1.Enabled = true;
            }

        }
        private void cargaultbillRefuerzo() //unicamente paso lo que esta en el Switch a aqui para ejecutarlo antes de darle click al boton de asignar
        {
            _isBill = true;
            tipoOper.Enabled = false;
            datoTipoOper = "BILL";
            groupBox1.Enabled = false;
            cargaultbill();
        }
            private void cargaultbill()
        {
            string dBill = "";

            GETcarga datos = new GETcarga();

            foreach (var i in datos.ultimaCarga(sucursal, 55)) //Bill
            {
                int numero = Convert.ToInt32(i.OrdenCarga);
                dBill = numero.ToString("D7");
            }
            // return 
            _numeroBill = dBill != "" || dBill == null ? dBill.ToString().Trim() : "";

            lblnBill.Text = _numeroBill;

        }

        private bool crearBillkdm1()
        {
            string datoSucIni = sucursal;
            DateTime datoFecha = regresafecha();
            DateTime datoFechaAlta;
            try { datoFechaAlta = datoFecha; } catch { datoFechaAlta = DateTime.Now; }
          
            string datoRefe = txbReferencia.Text.ToString();

            cargaultbill();
            BusquedaBill bd = new BusquedaBill();
            try
            {
                
                bool status = bd.AltaBillkdm1(datoSucIni,
                _numeroBill,
                datoFechaAlta,

                datoRefe

                );
                bd.ActualizaSqlIov(datoSucIni.Trim(), 55, _numeroBill);
                if (status)
                {
                    return true;
                }
                else
                {

                    return false;
                }

            }
            catch (DbEntityValidationException o)
            {
                bd.ActualizaSqlIov(datoSucIni.Trim(), 55, _numeroBill);
                Negocios.LOGs.ArsLogs.LogEdit(o.Message, "frmOrdenDeCarga.cs, Cuando se dio click al boton de asignar... " + _numeroBill + "");
                return false;
            }
            
            
        }
        private void Notificacion(int estatus, string Texto, string titulo, string cursor = null)
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

        private void gbxBill_Enter(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            VistaEntrada.BusquedasEnt buscador = new BusquedasEnt();
            buscador.label2.Text = "ALIASDIREC";
            buscador.pasado += new BusquedasEnt.pasar(moverinfo);
            buscador.ShowDialog();
        }
        public void moverinfo(string dato, string dato2, string dato3, string dato4, string dato5, string dato6, string dato7, string correoCliente, int bandera, string parentName ="", string parentId = "") //cambia los datos de los textbox alias y clientes, la bandera dependera de la manera en la que se haya abierto el frm buscar, 0 clientes 1 alias, ADEMAS tambien sirve para cambiar el campo de cord
        {
            _infoDesdeAlias = true;
            LimpiVar();
           // string nClien = txbNoCliente.Text.Trim();
            string oClien = dato7 != null ? dato7.Trim() : string.Empty;
          /*  if (nClien != oClien)
            {
                MessageBox.Show("Este alias no pertenece a este cliente");
                return;
            }*/
            if (bandera == 1)//alias
            {
                calle = dato4;
                colonia = dato5;
                estado = dato6;
                zipp = dato3;
                numm = correoCliente;
                txbAliasAct.Text = dato;
            }
        }
        private void LimpiVar()
        {
            calle = "";
            colonia = "";
            estado = "";
            txbAliasAct.Text = "";
            zipp = "";
            numm = "";
        }

        private void txbBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txbBusqueda.Text;

                if (string.IsNullOrWhiteSpace(searchValue))
                {
                   
                    MessageBox.Show("Por favor, introduce un valor de búsqueda válido.");
                    dtgSinAsignar.DataSource = lssGlobal;
                }
                else
                {
                    if (lssGlobal==null)
                    {
                        return;
                    }
                    var filteredData = lssGlobal.Where(item =>
    (item.entrada?.ToLower().Contains(searchValue) ?? false) ||
    (item.cliente?.ToLower().Contains(searchValue) ?? false) ||
    (item.noCli?.ToLower().Contains(searchValue) ?? false) ||
    (item.Cotizacion?.ToLower().Contains(searchValue) ?? false) ||
    (item.desc?.ToLower().Contains(searchValue) ?? false) ||
    (item.aliss?.ToLower().Contains(searchValue) ?? false)).ToList();


                    dtgSinAsignar.DataSource = filteredData;

                    if (!filteredData.Any())
                    {
                        MessageBox.Show("No se encontraron resultados para tu búsqueda.");
                    }
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnOrdenaName_Click(object sender, EventArgs e)
        {
            if (lssGlobal != null && lssGlobal.Any())
            {
                lssGlobal = lssGlobal.OrderBy(c => c.cliente).ToList();
                dtgSinAsignar.DataSource = null; // Limpiamos el DataSource
                dtgSinAsignar.DataSource = lssGlobal; // Establecemos la lista ordenada como nuevo DataSource
            }
        }

        private void cmbSucOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiaDatos();
            var name = cmbSucOrigen.SelectedValue?.ToString().Trim();

            if (String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("La sucursal Destino no puede esta bacia");
                return;
            }
            sucursal = name.Trim();
           
        }
    }
}
