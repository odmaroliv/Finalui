using Datos.ViewModels.Coord;
using mainVentana.Reportes.Cotizaciones.cotToPDF;
using mainVentana.VistaEntrada;
using Negocios.NGCotizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaInicioCoordinadores
{
    public partial class frmBuscarCotizacion : Form
    {
        private int datparseado;
        private string _nCotD7 = "";
        public frmBuscarCotizacion()
        {
            InitializeComponent();
        }

        private async void gunaTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidabPrincipal();
                string id = gunaTextBox2.Text;
                await refresh(_nCotD7);
                await Task.Run(() => { Thread.Sleep(1000); });

                e.SuppressKeyPress = true;
            }
        }

        //Listas para pasar a los reportes
        List<vmBusquedaCot> listaGeneralCot = new List<vmBusquedaCot>();

        List<vmInfoTablaCot> listaInfoEnCot = new List<vmInfoTablaCot>();
        
        List<vmEntCot> listaEntEnCot = new List<vmEntCot>();

        public async Task refresh(string id)
        {

            txbComent.Text = "";
           string sucursal = default;

            

            if (rSd.Checked == true)
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

            listaGeneralCot.Clear();
            listaInfoEnCot.Clear();
            listaEntEnCot.Clear();

            Negocios.NGCotizacion.accesoCotizaciones dt = new Negocios.NGCotizacion.accesoCotizaciones();
            gunaDataGridView1.DataSource = null;
            listaGeneralCot = await dt.BuscarCitizacionPorId(id, sucursal);
            try
            {
                gunaDataGridView1.DataSource = listaGeneralCot;
            }
            catch (Exception)
            {

            }
           
            if (gunaDataGridView1.RowCount <= 0)
            {
                MessageBox.Show("No se encontraron datos");
                dtgDetalle.DataSource = null;
                dgvEntsCot.DataSource = null;
                return;
            }
            string ests = "";
            string rbt = "";

            listaInfoEnCot = await dt.BuscaInfoTablaCotizacionPorId(id, sucursal);
            dtgDetalle.DataSource = listaInfoEnCot;
            listaEntEnCot = await dt.BuscaEntsEnCot(_nCotD7.Trim(), sucursal.Trim());

            dgvEntsCot.DataSource = listaEntEnCot;
            foreach (var item in listaGeneralCot)
            {
                txbComent.Text = String.IsNullOrWhiteSpace(item.C24) ? "" : item.C24.Trim();
                ests = String.IsNullOrWhiteSpace(item.C43) ? "" : item.C43.Trim();
                rbt = item.C44 ?? "NoPagado";
            }

            if (ests == "C")
            {
                ests = "CANCELADO";

            }
            else
            {
                ests = "";
            }

            try
            {
                RDBPpagar(rbt.Trim());
            }
            catch (Exception)
            {

                MessageBox.Show("Hubo un error al cargar el estado del pago, por favor, avisar ala departamento de sistemas y no imprimir informacion, ya que esta corrupta","Alerta");
            }
           

            lblEstatus.Text = ests;
            dt = null;
        }
        private void ValidabPrincipal()
        {
            if (gunaTextBox2.Text == "")
            {
                MessageBox.Show("El campo de busqueda esta vacio!");
                return;
            }
          
            bool bent = Int32.TryParse(gunaTextBox2.Text, out datparseado);
            if (bent == true)
            {
                gunaTextBox2.Text = datparseado.ToString("D7");
                _nCotD7 = datparseado.ToString("D7");
            }
            else
            {
                MessageBox.Show("Las entradas tienen que ser un codigo numerico, y no pueden contener letras");
                return;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (gunaDataGridView1.RowCount < 1)
            {
                return;
            }
            VistaEntrada.Desbloqueo buscador = new Desbloqueo();

            buscador.cambiar += new Desbloqueo.cambio(CancelaCotizacionChechk);
            buscador.ShowDialog();


          

        }

        public async void CancelaCotizacionChechk(bool dato)
        {
            if (dato == true)
            {
                if (MessageBox.Show("Seguro que quieres Cancelar esta cotización?", "Cuidado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (gunaDataGridView1.Rows.Count > 0)
                        {
                            string value1 = gunaDataGridView1.Rows[0].Cells[0].Value?.ToString().Trim() ?? string.Empty;
                            string value2 = gunaDataGridView1.Rows[0].Cells[1].Value?.ToString().Trim() ?? string.Empty;

                            if (!string.IsNullOrEmpty(value1) && !string.IsNullOrEmpty(value2))
                            {

                                try
                                {
                                    AltasCotizacion alta = new AltasCotizacion();

                                    string entradas = string.Join(",", listaEntEnCot.Select(x => x.Entrada.ToString().Trim()));
                                    string su = string.Join(",", listaEntEnCot.Select(x => x.sucursal.ToString().Trim()));
                                    await alta.CancelaCotEnEntradas(listaEntEnCot);
                                    alta.CancelarCotizacion(value1, value2);
                                    MessageBox.Show("Listo");
                                    await refresh(_nCotD7);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Ha ocurrido un error");
                                    throw;
                                }

                            }
                        }

                    }
                    catch (Exception)
                    {
                        throw;
                    }


                }
            }
            else
            {
                MessageBox.Show("No puedes cancelar esta Cotización");
            }

        }

        private void rdbPagado_CheckedChanged(object sender, EventArgs e)
        {
            Guna.UI.WinForms.GunaMediumRadioButton btn = (Guna.UI.WinForms.GunaMediumRadioButton)sender;

            if (btn.Checked == true && btn.Name == "rdbPagado")
            {
                
                    
                    rdbNoPagado.Enabled = false;
                
                
            }
            else if (btn.Name == "rdbNoPagado")
            {
                rdbNoPagado.Enabled = false;
                rdbPagado.Enabled = true;
             
            }
            else
            {
                rdbNoPagado.Checked = true;
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

        private void RDBpagar(string dato)
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

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quieres modificar esta cotización?", "Cuidado", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                try
                {
                    if (gunaDataGridView1.Rows.Count > 0)
                    {
                        string value1 = gunaDataGridView1.Rows[0].Cells[0].Value?.ToString().Trim() ?? string.Empty;
                        string value2 = gunaDataGridView1.Rows[0].Cells[1].Value?.ToString().Trim() ?? string.Empty;

                        if (!string.IsNullOrEmpty(value1) && !string.IsNullOrEmpty(value2))
                        {

                            try
                            {
                                AltasCotizacion alta = new AltasCotizacion();
                               
                               

                                string pagado = default;
                                if (rdbPagado.Checked == true)
                                {
                                    pagado = "Pagado";
                                }
                                else
                                {
                                    pagado = "NoPagado";
                                }
                                alta.PagoCotizacion(value1, value2,pagado);

                                MessageBox.Show("Se actualizo el pago de: "+value1+value2);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Ha ocurrido un error");
                                throw;
                            }

                        }
                    }


                }
                catch (Exception)
                {
                    throw;
                }


            }
           
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

            if (dgvEntsCot.RowCount < 1)
            {
                return;
            }

                string tipoImp = gunaDataGridView1.Rows[0].Cells[26].Value?.ToString().Trim() ?? string.Empty;
            
                using (frmToRepCot frm = new frmToRepCot())
                {
                    string sucursal = gunaDataGridView1.Rows[0].Cells[0].Value?.ToString().Trim() ?? string.Empty;
                    string noCot = gunaDataGridView1.Rows[0].Cells[1].Value?.ToString().Trim() ?? string.Empty;
                    string pedimento = gunaDataGridView1.Rows[0].Cells[2].Value?.ToString().Trim() ?? string.Empty;

                    string cliente = gunaDataGridView1.Rows[0].Cells[14].Value?.ToString().Trim() ?? string.Empty;

                    string fechaElabora = gunaDataGridView1.Rows[0].Cells[19].Value?.ToString().Trim() ?? string.Empty;

                    string valoeMercaUsa = gunaDataGridView1.Rows[0].Cells[9].Value?.ToString().Trim() ?? string.Empty;
                    string valoeMercaMx = gunaDataGridView1.Rows[0].Cells[9].Value?.ToString().Trim() ?? string.Empty;
                    string subTotal = gunaDataGridView1.Rows[0].Cells[5].Value?.ToString().Trim() ?? string.Empty;
                    string iva = gunaDataGridView1.Rows[0].Cells[12].Value?.ToString().Trim() ?? string.Empty;
                    string payArn = gunaDataGridView1.Rows[0].Cells[3].Value?.ToString().Trim() ?? string.Empty;
                    string payArnMXN = gunaDataGridView1.Rows[0].Cells[6].Value?.ToString().Trim() ?? string.Empty;
                    string referencia = gunaDataGridView1.Rows[0].Cells[22].Value?.ToString().Trim() ?? string.Empty;
                    string User = gunaDataGridView1.Rows[0].Cells[21].Value?.ToString().Trim() ?? string.Empty;
                    string formPayment = gunaDataGridView1.Rows[0].Cells[11].Value?.ToString().Trim() ?? string.Empty;

                    string dDescuento = gunaDataGridView1.Rows[0].Cells[27].Value?.ToString().Trim() ?? string.Empty;



                string paridad = Math.Round(float.Parse(gunaDataGridView1.Rows[0].Cells[4].Value.ToString()), 2).ToString() ?? string.Empty;




                    string entradas = string.Join(",", listaEntEnCot.Select(x => x.Entrada.ToString()));

                    frm.cliente = cliente;
                    frm.sucursal = sucursal;
                    frm.quote = noCot;
                    frm.pedimento = pedimento;
                    frm.date = fechaElabora;
                    frm.paridad = paridad;
                    frm.entradas = entradas;
                    frm.vGod = valoeMercaUsa;
                    frm.subTotal = subTotal;
                    frm.iva = iva;
                    frm.toPayArn = payArn;
                    frm.totalPesos = payArnMXN;
                    frm.referencia = referencia;
                    frm.User = User;
                    frm.payment = formPayment;
                    frm.pDescuento = dDescuento;

                frm.lst = listaInfoEnCot;
                if (tipoImp == "IMP")
                {
                    frm.tImprecionRep = false;
                }
                else
                {
                    frm.tImprecionRep = true;
                }


                    frm.ShowDialog();
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quieres modificar esta cotización?", "Cuidado", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                try
                {
                    if (gunaDataGridView1.Rows.Count > 0)
                    {
                        string value1 = gunaDataGridView1.Rows[0].Cells[0].Value?.ToString().Trim() ?? string.Empty;
                        string value2 = gunaDataGridView1.Rows[0].Cells[1].Value?.ToString().Trim() ?? string.Empty;

                        if (!string.IsNullOrEmpty(value1) && !string.IsNullOrEmpty(value2))
                        {

                            try
                            {
                                AltasCotizacion alta = new AltasCotizacion();
                               
                               

                                string pagado = default;
                                if (rdbPagado.Checked == true)
                                {
                                    pagado = "Pagado";
                                }
                                else
                                {
                                    pagado = "NoPagado";
                                }
                                alta.PagoCotizacion(value1, value2,pagado);

                                MessageBox.Show("Se actualizo el pago de: "+value1+value2);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Ha ocurrido un error");
                                throw;
                            }

                        }
                    }


                }
                catch (Exception)
                {
                    throw;
                }


            }
           
        }

        private void frmBuscarCotizacion_Load(object sender, EventArgs e)
        {

        }
    }
}
