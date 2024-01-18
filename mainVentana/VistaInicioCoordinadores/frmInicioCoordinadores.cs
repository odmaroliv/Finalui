using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.ViewModels.Reportes;
using Negocios;
using mainVentana.VistaInicioCoordinadores;
using Negocios.NGReportes;
using mainVentana.VistaInicioFoto;
using mainVentana.VistaEntrada;
using Datos.ViewModels.Entradas;
using FontAwesome.Sharp;
using DocumentFormat.OpenXml.Office.Word;
using iTextSharp.tool.xml.css;
using ADGV;
using mainVentana.Helpers;
using Datos.ViewModels;

namespace mainVentana.VistaInicioCoordinadores

{
    public partial class frmInicioCoordinadores : Form
    {
        private string sActualCord;

        private string calle;
        private string colonia;
        private string estado;
        private string zipp;
        private string numm;

        private bool _isBusy = false;

        //Almacenan el filtrado
        private string currentFilter = string.Empty;
        private string currentSort = string.Empty;


        public frmInicioCoordinadores()
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
            int currentIndex = dtgEnts.FirstDisplayedScrollingRowIndex;
            int maxIndex = dtgEnts.Rows.Count - dtgEnts.DisplayedRowCount(false);

            if (e.Delta > 0 && currentIndex > 0)
            {
                dtgEnts.FirstDisplayedScrollingRowIndex--;
            }
            else if (e.Delta < 0 && currentIndex < maxIndex)
            {
                dtgEnts.FirstDisplayedScrollingRowIndex++;
            }
        }



        public delegate Task pasar(string id = null);
        public event pasar pasado;

        public async Task ejecutaeveto(string id)
        {
            await pasado(id);
        }

     

        public async Task ejecutaeveto2()
        {
            try
            {
                iconButton6.Enabled = false;
                dtgEnts.DataSource = null;
                bool nada = await CargaControles();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                iconButton6.Enabled = true;
            }
          
           
        }

        private async void frmInicioCoordinadores_Load(object sender, EventArgs e)
        {
            if (Negocios.Common.Cache.CacheLogin.rol == "ADMIN")
            {
                iconButton1.Enabled = true;
            }

            dtgEnts.EnableHeadersVisualStyles = false;
            //dtgEnts.dou = false;

            dtFecha1.Value = DateTime.Now.AddDays(-1);
            dtFecha2.Value = DateTime.Now.AddDays(1);
            dtFecha1.MinDate = DateTime.Now.AddDays(-460);
            dtFecha1.MaxDate = DateTime.Now.AddDays(1);
            dtFecha2.MinDate = DateTime.Now.AddDays(-460);
            dtFecha2.MaxDate = DateTime.Now.AddDays(1);
            nudValArn.Controls[0].Enabled = false;
            nudValFac.Controls[0].Enabled = false;

            await ejecutaeveto2();
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

        private string sucursal = "";
        DataTable DatosDataTable = null;
        List<vmInfoControlCors> dtgDatos = new List<vmInfoControlCors>();
       private List<vmInfoControlCors> lss = new List<vmInfoControlCors>();

        public async Task<bool> CargaControles()
        {
            if (lss?.Count >0)
            {
                lss.Clear();
            }
           
            /*
            // Utilizar un diccionario para mapear los RadioButton a sus valores correspondientes
            var radioButtonMapping = new Dictionary<RadioButton, string>
                {
        { rSd, "SD" },
        { rTj, "TJ" },
        { rCa, "CSL" },
        { rdId, "9999" }
                 };

            // Encontrar el RadioButton seleccionado y obtener su valor correspondiente
            sucursal = radioButtonMapping.FirstOrDefault(r => r.Key.Checked).Value;
            */

            ngbdReportes rep = new ngbdReportes();
            //var lss = new List<vmInfoControlCors>();
            if (sucursal == "9999")
            {
                lss = await rep.CargaControlSinId(sucursal, dtFecha1.Value, dtFecha2.Value);
            }
            else
            {
                lss = await rep.CargaControl(sucursal, dtFecha1.Value, dtFecha2.Value);
            }
            if (lss ==null)
            {
                return false;
            }
            foreach (var item in lss)
            {
                PropertyInfo[] properties = item.GetType().GetProperties();
                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        string value = (string)property.GetValue(item);
                        if (value != null)
                        {
                            // Realizar validaciones adicionales aquí
                            value = value.Trim();

                            // Ejemplo de validación para establecer un valor predeterminado si es nulo o vacío
                            if (string.IsNullOrEmpty(value))
                            {
                                value = "";
                            }

                            // Ejemplo de validación para ignorar espacios en blanco adicionales
                            if (string.IsNullOrWhiteSpace(value))
                            {
                                continue; // Ignorar propiedad y pasar a la siguiente iteración del bucle
                            }

                            property.SetValue(item, value);
                        }
                    }
                }
            }




            if (dtgDatos != null)
            {
                dtgDatos.Clear();
            }

            // Utilizar LINQ para eliminar duplicados basados en el atributo 'entrada'
            var uniqueLss = lss.GroupBy(x => x.entrada.Trim()).Select(x => x.First()).ToList();

            // Agregar elementos únicos a dtgDatos
            dtgDatos.AddRange(uniqueLss);

            if (dtgDatos.Count > 0)
            {
                DataTable tb = VistaInicioCoordinadores.dataFilter.ConvierteADatatable(dtgDatos);

                DatosDataTable = tb;
                dtgEnts.DataSource = DatosDataTable;
                lblCTotal.Text = dtgDatos.Count.ToString();
            }
            else
            {
                dtgEnts.DataSource = null;
            }
            string previousFilter = currentFilter;
            string previousSort = currentSort;
            using (BindingSource aada = new BindingSource())
            {
                aada.DataSource = DatosDataTable;
                aada.Filter = previousFilter;
                aada.Sort = previousSort;
                // Resto del código para configurar el control AdvancedDataGridView con el BindingSource
            }

            return true;
        }
        public async Task<bool> CargaControlesSinId()
        {
           
            ngbdReportes rep = new ngbdReportes();
            var lss = await rep.CargaControl(sucursal, dtFecha1.Value, dtFecha2.Value);

            if (dtgDatos != null)
            {
                dtgDatos.Clear();
            }

            // Utilizar LINQ para eliminar duplicados basados en el atributo 'entrada'
            var uniqueLss = lss.GroupBy(x => x.entrada.Trim()).Select(x => x.First()).ToList();

            // Agregar elementos únicos a dtgDatos
            dtgDatos.AddRange(uniqueLss);

            if (dtgDatos.Count > 0)
            {
                DataTable tb = VistaInicioCoordinadores.dataFilter.ConvierteADatatable(dtgDatos);

                DatosDataTable = tb;
                dtgEnts.DataSource = DatosDataTable;
                lblCTotal.Text = dtgDatos.Count.ToString();
            }
            else
            {
                dtgEnts.DataSource = null;
            }

            return true;
        }

        private void pnlEntradasDetalle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private async void dtgEnts_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgEnts.SelectedCells.Count > 0)
            {
                try
                {
                    int selectedrowindex = dtgEnts.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dtgEnts.Rows[selectedrowindex];
                    string so = Convert.ToString(selectedRow.Cells[0].Value);
                    string en = Convert.ToString(selectedRow.Cells[1].Value); 
                    //string edesc = Convert.ToString(selectedRow.Cells[11].Value);
                    string noCliente = Convert.ToString(selectedRow.Cells[4].Value);
                   // string al = Convert.ToString(selectedRow.Cells[12].Value);
                    await CargaLosValoresDeDetalle(so, en, noCliente);
                    //ngbdReportes rep = new ngbdReportes();
                    //await rep.CargaControlid(so.Trim(), en.Trim());
                }
                catch (Exception)
                {
                    MessageBox.Show("El valor no puede ser 0 o un espacio vacio, esto esta apunto de generar un error interno, manten asi la apilacion, no la cierres y pide soporte de Sistemas.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                }
               
            }
        }
        private async Task CargaLosValoresDeDetalle(string so, string en, string ncliente)
        {
            txbAliasAct.Text = "";
            txbNoCliente.Text = "";
            ngbdReportes rep = new ngbdReportes();
            vmInfoControlCors dt = await rep.CargaControlid(so, en);
            txbEntradaDetalle.Text = dt.entrada.Trim();
            nudValArn.Value = String.IsNullOrEmpty(dt.valArn) ? default: Convert.ToDecimal(dt.valArn);
            nudValFac.Value = String.IsNullOrWhiteSpace(dt.valFact) ? default : Convert.ToDecimal(dt.valFact);
            txbNoCliente.Text = ncliente;
            gtxbOrdenCargaDetalle.Text = dt.ordcarga;
            gtxbOrdenSalidaDetalle.Text = dt.desc;//dt.salida;
            txbAliasAct.Text = dt.aliss.Trim();
            txbFecha.Text = dt.fechaentrada;
            txbSucOrigenDetalle.Text = dt.SucursalInicio.Trim();
            txbCordUsr.Text = dt.Cotizacion.Trim();
            txbPcalle.Text = String.IsNullOrWhiteSpace(dt.calle) ? "" : dt.calle.Trim(); 
            txbPcolonia.Text = String.IsNullOrWhiteSpace(dt.colonia) ? "" : dt.colonia.Trim();
            txbPpoblacion.Text = String.IsNullOrWhiteSpace(dt.poblacio) ? "" : dt.poblacio.Trim();
            txbPcp.Text = String.IsNullOrWhiteSpace(dt.zipcode) ? "" : dt.zipcode.Trim();

        }

        private async void iconButton6_Click(object sender, EventArgs e)
        {
            iconButton6.Enabled = false;
            _isBusy = true;
            try
            {

                bool ts = await CargaControles();
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

        private void AsignaDatosSireccion()
        {
            if (String.IsNullOrWhiteSpace(txbAliasAct.Text))
            {
                calle = txbPcalle.Text;
                colonia = txbPcolonia.Text;
                estado = txbPpoblacion.Text;
                zipp = txbPcp.Text;
            }

            
        }

        private async void iconButton5_Click(object sender, EventArgs e)
        {
            AsignaDatosSireccion();
            AltasBD bd = new AltasBD();
            try
            {
                iconButton5.Enabled = false;
                dtgEnts.Enabled = false;
                await bd.ActualizaValores(txbEntradaDetalle.Text, txbSucOrigenDetalle.Text, nudValFac.Value.ToString(), nudValArn.Value.ToString());
                if (String.IsNullOrWhiteSpace(calle))
                {
                    await CargaControles();
                    SeleccionRow(txbEntradaDetalle.Text);
                    Notificacion(1, txbEntradaDetalle.Text + " Los datos se han actualizado Correctamente", "Valores Actualizados", txbEntradaDetalle.Text + " Actualizada");
                    MessageBox.Show("Se han modificado los valores, pero no la dirección de entrega.0");
                    iconButton5.Enabled = true;
                    LimpiVar();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txbPcalle.Text))
                {
                    if (MessageBox.Show("La direccion que estas agregando esta en blanco, si esta enta entrada ya tenian una dirección asignada se borrara\nQuieres guardar la direccion en blanco?.", "Direccion en blanco", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        await CargaControles();
                        SeleccionRow(txbEntradaDetalle.Text);
                        Notificacion(1, txbEntradaDetalle.Text + " Los datos se han actualizado Correctamente", "Valores Actualizados", txbEntradaDetalle.Text + " Actualizada");
                        MessageBox.Show("Se han modificado los valores, pero no la dirección de entrega.1");
                        iconButton5.Enabled = true;
                        LimpiVar();
                        return;
                    }
                }
                await bd.ActualizaValoresEntrega(txbEntradaDetalle.Text, txbSucOrigenDetalle.Text, calle, colonia, estado, txbAliasAct.Text, zipp, numm);
                await CargaControles();
                SeleccionRow(txbEntradaDetalle.Text);
                iconButton5.Enabled = true;
                Notificacion(1, txbEntradaDetalle.Text + " Los datos se han actualizado Correctamente", "Valores Actualizados", txbEntradaDetalle.Text + " Actualizada");
                LimpiVar();
            }
            catch (Exception)
            {

                Notificacion(2, txbEntradaDetalle.Text + " No se han Actualizado los valores", "Error", "Error");
                iconButton5.Enabled = true;

            }
            finally
            {
                dtgEnts.Enabled = true;
            }
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


        /*
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
        */

        private void dtgEnts_FilterStringChanged(object sender, EventArgs e)
        {

           
            using (BindingSource aada = new BindingSource())
            {
                aada.DataSource = DatosDataTable;
                aada.Filter = dtgEnts.FilterString;
            }
            currentFilter = dtgEnts.FilterString;
        }

        private void dtgEnts_SortStringChanged(object sender, EventArgs e)
        {
            using (BindingSource aada = new BindingSource())
            {
                aada.DataSource = DatosDataTable;
                aada.Sort = dtgEnts.SortString;
            }
            currentSort = dtgEnts.SortString;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private bool ValidaNumericUpDown()
        {
            if (nudValArn.Value == 0 || nudValArn.Value == 1 || nudValFac.Value == 0 || nudValFac.Value == 1)
            {
                return false;
            }
            return true;
        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            if (!ValidaNumericUpDown())
            {
                MessageBox.Show("Los valores de ValArn y ValFac deben ser diferentes de 0 o 1.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Código original
            using (frmInfoEntradaCords frm = new frmInfoEntradaCords())
            {
                frm.txbSucOrigenDetalle.Text = txbSucOrigenDetalle.Text;
                frm.txbEntradaDetalle.Text = txbEntradaDetalle.Text;
                frm.txbCargaActual.Text = gtxbOrdenCargaDetalle.Text;
                frm.ShowDialog();
            }

            await CargaControles();
        }

        private bool ValidaCotizacion()
        {
            Negocios.NGCotizacion.accesoCotizaciones dt = new Negocios.NGCotizacion.accesoCotizaciones();
            var lst = dt.ValidaEntradaConCot(txbSucOrigenDetalle.Text, txbEntradaDetalle.Text);

            if (!string.IsNullOrWhiteSpace(lst.noCot))
            {
                return true;
            }
            return false;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            string e_so = txbSucOrigenDetalle.Text.Trim();
           string e_ent = txbEntradaDetalle.Text.Trim();
            using (frmSelectorFotos frm = new frmSelectorFotos())
            {
                frm.txbEntrada.Text = e_so + "-UD3501-" + e_ent;
                frm.ShowDialog();
              

            }
           
            
        }

    
        private async void rSd_CheckedChanged(object sender, EventArgs e)
        {
            iconButton6.Enabled = false;
            _isBusy = true;
            try
            {

                bool ts = await CargaControles();
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

        private void iconButton3_Click(object sender, EventArgs e)
        {
            VistaEntrada.BusquedasEnt buscador = new BusquedasEnt();
            buscador.label2.Text = "ALIASDIREC";
            buscador.pasado += new BusquedasEnt.pasar(moverinfo);
            buscador.ShowDialog();
        }
        public void moverinfo(string dato, string dato2, string dato3, string dato4, string dato5, string dato6, string dato7, string correoCliente, int bandera) //cambia los datos de los textbox alias y clientes, la bandera dependera de la manera en la que se haya abierto el frm buscar, 0 clientes 1 alias, ADEMAS tambien sirve para cambiar el campo de cord
        {
            LimpiVar();
            string nClien = txbNoCliente.Text.Trim();
            string oClien = dato7 != null ? dato7.Trim() : string.Empty;
            if (nClien != oClien)
            {
                MessageBox.Show("Este alias no pertenece a este cliente");
                return;
            }
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

        private async void rdId_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txbCordUsr_DoubleClick(object sender, EventArgs e)
        {
            using (AltaEntrada nt =new AltaEntrada(2))
            {
                nt.ShowDialog();
                //nt.modoCord = 2;
            }
        }
        private bool _abriendo = false;
        private void txbCordUsr_KeyDown(object sender, KeyEventArgs e)
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

        private async void cmbSucOrigen_SelectedIndexChanged(object sender, EventArgs e)
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
                sucursal = cbxSinId.Checked == false? name.Trim(): "9999"; //9999 si es sin ID
                bool ts = await CargaControles();
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
