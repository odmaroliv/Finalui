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



        public frmInicioCoordinadores()
        {
            InitializeComponent();
            this.dtgEnts.MouseWheel += dtgEnts_MouseWheek;
        }

        private void dtgEnts_MouseWheek(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && dtgEnts.FirstDisplayedScrollingRowIndex > 0)
            {
                dtgEnts.FirstDisplayedScrollingRowIndex --;
            }
            else if (e.Delta < 0)
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
            dtgEnts.DataSource = null;
           bool nada = await CargaControles();
           
        }

        private async void frmInicioCoordinadores_Load(object sender, EventArgs e)
        {
            nudValArn.Controls[0].Visible = false;
            nudValFac.Controls[0].Visible = false;

            await ejecutaeveto2();
          
        }

        private string sucursal = "";
        DataTable DatosDataTable = null;
        List<vmInfoControlCors> dtgDatos = new List<vmInfoControlCors>();
        public async Task<bool> CargaControles()
        {
           
            if (rSd.Checked==true)
            {
                sucursal = "SD";
            }
            if (rTj.Checked == true)
            {
                sucursal = "TJ";
            }
            if (rCa.Checked == true)
            {
                sucursal = "CSL";
            }
            List<vmInfoControlCors> lss = new List<vmInfoControlCors>();
            lss.Clear();
            ngbdReportes rep = new ngbdReportes();
           lss = await rep.CargaControl(sucursal);

            if (dtgDatos!=null)
            {
                dtgDatos.Clear();
            }
           
         

            var listanoduplies = new HashSet<string>(lss.Select(s => s.entrada)).ToList();
            foreach (var q in listanoduplies)
            {
                foreach (var w in lss)
                {
                    if (w.entrada.Trim() == q.Trim())
                    {
                        dtgDatos.Add( new vmInfoControlCors
                        {
                            entrada = w.entrada,
                            cliente = w.cliente,
                            noCli = w.noCli,
                            fechaentrada = w.fechaentrada,
                            Cotizacion = w.Cotizacion,
                            ordcarga = w.ordcarga,
                            ordapli = w.ordapli,
                            salida = w.salida,
                            SucursalInicio = w.SucursalInicio,
                            valArn=w.valArn,
                            valFact = w.valFact,
                            desc = w.desc,
                            aliss  =    w.aliss,
                        });

                        break;
                    }
                    else
                    {
                       
                    }

                }

            }
          
            

            if (dtgDatos.Count > 0)
            {
                DataTable tb = VistaInicioCoordinadores.dataFilter.ConvierteADatatable(dtgDatos);

                DatosDataTable = tb;
                dtgEnts.DataSource = DatosDataTable;
               

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
                    string edesc = Convert.ToString(selectedRow.Cells[11].Value);
                    string noCliente = Convert.ToString(selectedRow.Cells[4].Value);
                    string al = Convert.ToString(selectedRow.Cells[12].Value);
                    await CargaLosValoresDeDetalle(so, en, edesc, noCliente, al);
                    ngbdReportes rep = new ngbdReportes();
                    await rep.CargaControlid(so.Trim(), en.Trim());
                }
                catch (Exception)
                {
                    MessageBox.Show("El valor no puede ser 0 o un espacio vacio, esto esta apunto de generar un error interno, manten asi la apilacion, no la cierres y pide soporte de Sistemas.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                }
               
            }
        }
        private async Task CargaLosValoresDeDetalle(string so, string en, string desc, string ncliente, string aliasDato)
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
            gtxbOrdenSalidaDetalle.Text = desc;//dt.salida;
            txbAliasAct.Text = aliasDato;
            txbFecha.Text = dt.fechaentrada;
            txbSucOrigenDetalle.Text = dt.SucursalInicio.Trim();

        }

        private async void iconButton6_Click(object sender, EventArgs e)
        {
           bool ts = await CargaControles();
        }

        private async void iconButton5_Click(object sender, EventArgs e)
        {
            AltasBD bd = new AltasBD();
            try
            {
                iconButton5.Enabled = false;
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
                if (String.IsNullOrWhiteSpace(txbAliasAct.Text))
                {
                    if (MessageBox.Show("La direccion que estas agregando esta en blanco, si esta enta entrada ya tenian una dirección asignada se borrara\nQuieres guardar la direccion en blanco?.", "Direccion en blanco", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.No)
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
                Notificacion(1, txbEntradaDetalle.Text+" Los datos se han actualizado Correctamente", "Valores Actualizados", txbEntradaDetalle.Text +" Actualizada");
                LimpiVar();
            }
            catch (Exception)
            {

                Notificacion(2, txbEntradaDetalle.Text+" No se han Actualizado los valores", "Error","Error");
                iconButton5.Enabled = true;

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

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            //   string tex = txbEntradaDetalle.Text;
            if (ValidaCotizacion()==false)
            {
                MessageBox.Show("Parece que esta entrada aun no ha sido asignada correctamente a una cotización","Alto",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
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

        private void iconButton7_Click(object sender, EventArgs e)
        {
            using (frmCotizaciones cot = new frmCotizaciones())
            {
                cot.sGlobal = Negocios.Common.Cache.CacheLogin.sucGlobal;
                cot.ShowDialog();
            }
        }

        private async void rSd_CheckedChanged(object sender, EventArgs e)
        {
            bool ts = await CargaControles();
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

    }

}
