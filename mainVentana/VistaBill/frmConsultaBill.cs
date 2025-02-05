using Datos.ViewModels;
using Datos.ViewModels.Bill;
using Datos.ViewModels.Reportes.Bill;
using mainVentana.Reportes.rbill;
using Negocios;
using Negocios.NGBill;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaBill
{
    public partial class frmConsultaBill : Form
    {
        public string sucursalGlobal = Negocios.Common.Cache.CacheLogin.sucGlobal == default ? "SD" : Negocios.Common.Cache.CacheLogin.sucGlobal;
        private string sucursal = "SD";
        private int _billBuscado;
        private vmInfoBill _infoBill;
        private List<vmBillEntradaDoc> lstEntsBill;
        private object sucursalBusqueda;

        public frmConsultaBill()
        {
            InitializeComponent();
        }

      

        private void gunaTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrWhiteSpace(txbBuscaBill.Text))
                {
                    return;
                }
                try
                {
                    e.Handled = true;
                    _billBuscado = Convert.ToInt32(txbBuscaBill.Text);
                    buscaEntradasEnBill();

                }
                catch (Exception)
                {
                    MessageBox.Show("Solo se permiten numeros");
                }
            }

          
          

        }

        private void CargaSOrigen()
        {
            Servicios datos = new Servicios();
            var lst2 = datos.llenaSuc();


            // Utilizamos Invoke para actualizar la UI de manera segura desde un hilo secundario
            this.Invoke(new Action(() =>
            {
                cmbSucEntrada.DisplayMember = "C2";
                cmbSucEntrada.ValueMember = "C1";
                cmbSucEntrada.DataSource = lst2;
                foreach (var i in from Sucursales i in cmbSucEntrada.Items select i)
                {
                    cmbSucEntrada.SelectedValue = i.c1;
                    break;
                }

            }));

            datos = null;
        }

        private async Task buscaEntradasEnBill()
        {
            BusquedaBill bs = new BusquedaBill();
            lstEntsBill = bs.EntradasEnBill(sucursal, _billBuscado);

            if (lstEntsBill.Any())
            {
                string entrada = lstEntsBill[0].etiqueta.Trim();
                _infoBill = await bs.InfoEnBill(entrada);
                dgvEntEnCarga.DataSource = lstEntsBill;
                lblFromNombre.Text = _infoBill?.fromNombre ?? "";
                lblFromCalle.Text = _infoBill?.fromCalle ?? "";
                lblFromColonia.Text = _infoBill?.fromColonia ?? "";
                lblFromLocalidad.Text = _infoBill?.fromLocalidad ?? "";
                lblFromZip.Text = _infoBill?.fromZip ?? "" ;
                lblToNombre.Text = _infoBill?.toNombre ?? "";
                lblToCalle.Text = _infoBill?.toCalle ?? "";
                lblToColonia.Text = _infoBill?.toColonia ??"";
                lblToLocalidad.Text = _infoBill?.toLocalidad??"";
                lblToZip.Text = _infoBill?.toZip??"";
                lblTel.Text = _infoBill?.telCliente ??"";
                lblCantida.Text = lstEntsBill.Count().ToString();

            }
            else
            {
                dgvEntEnCarga.DataSource = null;
                lblFromNombre.Text = null;
                lblFromCalle.Text = null;
                lblFromColonia.Text = null;
                lblFromLocalidad.Text = null;
                lblFromZip.Text = null;
                lblToNombre.Text = null;
                lblToCalle.Text = null;
                lblToColonia.Text = null;
                lblToLocalidad.Text = null;
                lblToZip.Text = null;
            }


            //dgvEntEnCarga.DataSource = lstEntsBill;

        }

        private void LlamaReporte()
        {
            using (frmBillVisorImp bill = new frmBillVisorImp())
            {
                try
                {
                    bill.from = _infoBill?.fromNombre ?? "";
                    bill.fromCalle = _infoBill?.fromCalle ?? "";
                    bill.fromDir1 = _infoBill?.fromCalle ?? "";
                    bill.fromDir2 = _infoBill?.fromColonia ??"";
                    bill.Coordinador = _infoBill?.coord??"";
                    bill.Note = "";
                    bill.Cellphone = _infoBill?.telCliente ?? "";
                    bill.to = _infoBill?.toNombre ??"";
                    bill.toCalle = _infoBill?.toCalle??"";
                    bill.toDir1 = _infoBill?.toColonia??"";
                    bill.toDir2 = _infoBill?.toLocalidad ?? "";
                    bill.ShipDate = DateTime.Now.ToString();
                    bill.totalCases = lstEntsBill.Count().ToString();
                    bill.numeroBill = _billBuscado.ToString();




                    bill.lst = lstEntsBill;
                    bill.ShowDialog();
                }
                catch (Exception)
                {

                    throw;
                }
               
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (_billBuscado <1)
            {
                return;
            }
            else
            {
                LlamaReporte();
            }
           
        }

        private void cmbSucEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = cmbSucEntrada.SelectedValue?.ToString().Trim();

            if (String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("La sucursal Destino no puede esta bacia");
                return;
            }
            sucursal = name.Trim();
        }

        private void frmConsultaBill_Load(object sender, EventArgs e)
        {
            Task.Run(() => CargaSOrigen());
        }
    }
}
