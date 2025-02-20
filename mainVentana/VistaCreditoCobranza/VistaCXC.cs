﻿using Datos.ViewModels.Reportes;
using Datos.ViewModels;
using Negocios.NGReportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.ViewModels.CXC;
using Negocios;
using mainVentana.VistaEntrada;
using Datos.ViewModels.Salidas;
using ClosedXML.Excel;
using mainVentana.VistaOrSalida;
using System.IO;
using Datos.Datosenti;
using System.Reflection;

namespace mainVentana.VistaCreditoCobranza
{
    public partial class VistaCXC : Form
    {
        private bool _abriendo = false;

        private List<DatosCXC_Result7> _data;
        private int _currentPage = 1;
        private int _pageSize = 10;




        public VistaCXC()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
            this.dtgEnts.MouseWheel += dtgEnts_MouseWheek;
            EnableDoubleBuffering(dtgEnts);
        }

        private void EnableDoubleBuffering(Control control)
        {
            // Obtener el tipo del control
            Type dgvType = control.GetType();

            // Obtener el campo "DoubleBuffered" y establecerlo en true
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(control, true, null);

        }


        private void dtgEnts_MouseWheek(object sender, MouseEventArgs e)
        {
            try
            {
                if (dtgEnts.Rows.Count >= 1)
                {
                    if (e.Delta > 0 && dtgEnts.FirstDisplayedScrollingRowIndex > 0)
                    {
                        dtgEnts.FirstDisplayedScrollingRowIndex--;
                    }
                    else if (e.Delta < 0)
                    {
                        dtgEnts.FirstDisplayedScrollingRowIndex++;
                    }

                }
            }
            catch (Exception)
            {

            }
            

           
        }


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void VistaCXC_Load(object sender, EventArgs e)
        {
            dtgEnts.EnableHeadersVisualStyles = false;
            dtFecha1.Value = DateTime.Now;
            dtFecha2.Value = DateTime.Now.AddDays(1);
            dtFecha1.MinDate = DateTime.Now.AddDays(-800);
            dtFecha1.MaxDate = DateTime.Now.AddDays(1);
            dtFecha2.MinDate = DateTime.Now.AddDays(-90);
            dtFecha2.MaxDate = DateTime.Now.AddDays(1);
            // await ejecutaeveto2();
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

        public async Task ejecutaeveto2()
        {
            dtgEnts.DataSource = null;
            bool nada = await CargaControles();

        }

        private string sucursal = "";
        DataTable DatosDataTable = null;
        List<vmInicioCXC> dtgDatos = new List<vmInicioCXC>();
        private bool _isBusy = false;

        public async Task<bool> CargaControles()
        {
            loadControl1.Visible = true;
           

            List<vmInicioCXCBd> lss = new List<vmInicioCXCBd>();
            // List<DatosCXC_Result7> dtt = new List<DatosCXC_Result7>();
            if (lss!=null)
            {
                lss.Clear();

            }
           
            ngbdReportes rep = new ngbdReportes();
            lss = await rep.CargaControlCXC(sucursal, dtFecha1.Value.Date, dtFecha2.Value.Date);

           /* for (int i = 0; i < lss.Count; i++)
            {
                var c = lss[i];
                if (!string.IsNullOrWhiteSpace(c.Cotizacion))
                {
                    try
                    {
                        var cSuc = c.Cotizacion.Split('-')[0];
                        var cTi = c.Cotizacion.Split('-')[1];
                        var cTipo = cTi.Substring(cTi.Length - 1);
                        var cot = c.Cotizacion.Split('-')[2];
                        var nuevoDato = await rep.CargaControlCXCSubconsulta(cSuc, Convert.ToDecimal(cTipo), cot);
                        if (nuevoDato != null)
                        {
                            // Modify the existing element with the new data
                            lss[i] = new vmInicioCXCBd { ParidadCot = nuevoDato.ToString() };
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }*/


            if (dtgDatos != null)
            {
                dtgDatos.Clear();
            }



            foreach (var w in lss)
            {
                dtgDatos.Add(new vmInicioCXC
                {
                    Salida = w.Salida?.Trim(),
                    Alias = w.Alias?.Trim(),
                    BOL = w.BOL?.Trim(),
                    Carga = w.Carga?.Trim(),
                    Cliente = w.Cliente?.Trim(),
                    Coordinador = w.Cordinador?.Trim(),
                    Cotizacion = w.Cotizacion?.Trim(),
                    Entrada = w.Entrada?.Trim(),
                    EstatusAlmacen = w.Estatus?.Trim(),
                    EstatusPago = w.EstatusPago?.Trim(),
                    FechaEnrtada = (DateTime)w.FechaEntrada,
                    Sucursal = w.SucursalOrigen?.Trim(),
                    ValorArnia = w.ValorArnian,
                    ValorFactura = w.ValorFactura,
                    Comentario = w.Comentario?.Trim(),
                    Operacion = w.Operacion?.Trim(),
                    sucActual = w.sucActual?.Trim(),
                    Nota =  w.Nota?.Trim(),
                    Link = String.IsNullOrWhiteSpace(w.Link)?"": string.Format("https://arniangroup.dispatchtrack.com/search/{0}", w.SucursalOrigen?.Trim() + "-" + w.Entrada?.Trim()),
                    FechaCarga = w.FechaCarga?.Trim(),
                    FechaRepFinal = w.FechaRepFinal?.Trim(),
                    FechaBol = w.FechaBol?.Trim(),
                    DescCorta = w.DescCorta?.Trim(),
                    TpEntrada = w.TpEntrada,
                    isDanado = w.isDanado == "1" ? "Si" : "No",

                });


            }


            if (dtgDatos.Count > 0)
            {

                lblTotalResult.Text = dtgDatos.Count.ToString();
                DataTable tb = VistaInicioCoordinadores.dataFilter.ConvierteADatatableCXC(dtgDatos);

                DatosDataTable = tb;
                dtgEnts.DataSource = DatosDataTable;


            }
            else
            {
                dtgEnts.DataSource = null;
            }
            loadControl1.Visible = false;
            return true;




        }

        private void dtgEnts_FilterStringChanged(object sender, EventArgs e)
        {

            using (BindingSource aada = new BindingSource())
            {
                aada.DataSource = DatosDataTable;
                aada.Filter = dtgEnts.FilterString;
            }
        }

        private void dtgEnts_SortStringChanged(object sender, EventArgs e)
        {
            using (BindingSource aada = new BindingSource())
            {
                aada.DataSource = DatosDataTable;
                aada.Sort = dtgEnts.SortString;
            }
        }


        private async void iconButton6_Click(object sender, EventArgs e)
        {
            bool ts = await CargaControles();
            SeleccionRow(txbEntradaDetalle.Text);

        }

        private async void dtgEnts_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgEnts.SelectedCells.Count > 0)
            {
                try
                {
                    int selectedrowindex = dtgEnts.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dtgEnts.Rows[selectedrowindex];
                    string so = Convert.ToString(selectedRow.Cells[2].Value);
                    string en = Convert.ToString(selectedRow.Cells[1].Value);
                    string pagado = Convert.ToString(selectedRow.Cells[13].Value);
                    string comen = Convert.ToString(selectedRow.Cells[14].Value);

                    await CargaLosValoresDeDetalle(so, en, pagado, comen);


                   
                    try
                    {
                        RDBPpagar(pagado.Trim());
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Hubo un error al cargar el estado del pago, por favor, avisar ala departamento de sistemas y no imprimir informacion, ya que esta corrupta", "Alerta");
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("El valor no puede ser 0 o un espacio vacio, esto esta apunto de generar un error interno, manten asi la apilacion, no la cierres y pide soporte de Sistemas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }

        }

        private void RDBPpagar(string dato)
        {
            if (dato == "Pagado")
            {
                rdbPagado.Checked = true;
                rdbNoPagado.Checked = false;
                rdbNoPagado.Enabled = false;
                rdbPagado.Enabled = false;
            }
            else if (dato == "NoPagado" || dato == "")
            {
                rdbPagado.Checked = false;
                rdbNoPagado.Checked = true;
                rdbNoPagado.Enabled = false;
                rdbPagado.Enabled = true;
            }

        }


        private async Task CargaLosValoresDeDetalle(string so, string en, string desc, string comentario)
        {

            //vmInfoControlCors dt = await rep.CargaControlid(so, en);
            txbEntradaDetalle.Text = en;



            gtbComentarios.Text = desc;//dt.salida;

            //txbFecha.Text = dt.fechaentrada;
            txbSucOrigenDetalle.Text = so;

            gtbComentarios.Text = comentario;

        }

        private void SeleccionRow(string Entrada)
        {
            try
            {
                dtgEnts.ClearSelection();
                DataGridViewRow nRowIndex = dtgEnts.Rows
             .OfType<DataGridViewRow>()
             .Where(x => (string)x.Cells[1].Value == Entrada)
             .First();
                //.Selected = true;

                dtgEnts.Rows[nRowIndex.Index].Selected = true;
                dtgEnts.Rows[nRowIndex.Index].Cells[0].Selected = true;
                // dtgEnts.CurrentCell.Selected = true;
            }
            catch (Exception)
            {


            }

        }

        private async void iconButton5_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txbEntradaDetalle.Text))
            {
                return;
            }

            string pago = "";
            if (rdbPagado.Checked)
            {
                pago = "Pagado";
            }
            else
            {
                pago = "NoPagado";
            }

            AltasBD bd = new AltasBD();
            try
            {
                await bd.ActualizaPagoPorEntrada(txbEntradaDetalle.Text.Trim(), txbSucOrigenDetalle.Text.Trim(), pago, gtbComentarios.Text);
                Notificacion(1, txbEntradaDetalle.Text + " Los datos se han actualizado Correctamente", "Valores Actualizados", txbEntradaDetalle.Text + " Actualizada");


            }
            catch (Exception)
            {
                Notificacion(2, txbEntradaDetalle.Text + " No se han Actualizado los valores", "Error", "Error");
                throw;
            }

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

        private void gunaTileButton3_Click(object sender, EventArgs e)
        {
            if (rdbNoPagado.Checked == true)
            {
                MessageBox.Show("Para liberar una Cotización primero tiene que estar pagada");
                return;

            }
            VistaEntrada.Desbloqueo buscador = new Desbloqueo();

            buscador.cambiar += new Desbloqueo.cambio(deledesbloqueo);
            buscador.ShowDialog();
        }

        private void Notificacion(int estatus, string Texto, string titulo, string cursor = null)
        {
            /*
             2 = ERROR
             1 = EXITO
            */

            if (estatus == 1)
            {
                try
                {
                    notifyIcon1.Icon = SystemIcons.Information;

                    notifyIcon1.Visible = true;
                    notifyIcon1.Text = cursor;
                    notifyIcon1.BalloonTipTitle = titulo;
                    notifyIcon1.BalloonTipText = Texto;
                    notifyIcon1.ShowBalloonTip(10000);




                }
                catch (Exception)
                {

                }

            }
            else if (estatus == 2)
            {
                try
                {
                    notifyIcon1.Icon = SystemIcons.Warning;
                    notifyIcon1.Visible = true;
                    notifyIcon1.Text = "Error";
                    notifyIcon1.BalloonTipTitle = titulo;
                    notifyIcon1.BalloonTipText = Texto;
                    notifyIcon1.ShowBalloonTip(10000);

                }
                catch (Exception)
                {


                }

            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
        }


        private async Task GeneraExcel()
        {
            btnToExcel.Enabled = false;
            loadControl1.Visible = true;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Guardar archivo de Excel";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string nm = saveFileDialog.FileName;
            await Task.Run(() =>
            {
              
               
             
                try
                {
                    if (dtgDatos.Count() <= 0)
                    {
                        MessageBox.Show("No hay datos para Enviar");

                        return;
                    }

                    // Mostrar el diálogo para seleccionar la ubicación y el nombre del archivo


                    string fullPath = nm;
                    new VistaCXC().Export<vmInicioCXC>(dtgDatos, fullPath, "salida");
                    MessageBox.Show("El documento se creó satisfactoriamente", "Creado");
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error", "Error");
                   
                    throw;
                }
                finally
                {
                    loadControl1.Invoke(new Action(() => { loadControl1.Visible = false; }));
                    btnToExcel.Invoke(new Action(() => { btnToExcel.Enabled = true; }));
                }
            });


        }

        public bool Export<T>(List<T> list, string file, string nombre)
        {
            bool exportado = false;
            using (XLWorkbook xlfile = new XLWorkbook())
            {
                var worksheet = xlfile.AddWorksheet(nombre);
                worksheet.FirstCell().InsertTable<T>(list, false);

                // Establecer un alto fijo para todas las filas del worksheet
                var altoFijo = 15; // Este es el alto fijo para las filas, puedes ajustarlo según tus necesidades
                worksheet.RowHeight = altoFijo; // Aplica el alto fijo a todas las filas
                worksheet.Style.Alignment.WrapText = false; // Desactiva el ajuste de texto para todo el worksheet

                xlfile.SaveAs(file);
                exportado = true;
            }
            return exportado;
        }


        private async void iconButton1_Click(object sender, EventArgs e)
        {
            await GeneraExcel();
        }

        private void txbEntradaDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (_abriendo == true)
            {
                return;
            }
            try
            {
                _abriendo = true;
                if (e.KeyCode == Keys.ControlKey)
                {
                    using (AltaEntrada nt = new AltaEntrada(2))
                    {
                        nt.ShowDialog();
                        //nt.modoCord = 2;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { _abriendo = false; }


        }

        private void cmbSucOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            iconButton6.Enabled = false;
            _isBusy = true;
            try
            {
                var name = cmbSucOrigen.SelectedValue?.ToString().Trim();

                if (String.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("La sucursal no puede esta bacia");
                    return;
                }
                sucursal = name.Trim();
                //bool ts = await CargaControles();
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                iconButton6.Enabled = true;
                _isBusy = false;
            }
        }
    }
}
