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

        private void gunaTextBox2_MouseEnter(object sender, EventArgs e)
        {
            if (gunaTextBox2.Text == "No.Cot :)")
            {
                gunaTextBox2.Text = "";

            }
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

            Negocios.NGCotizacion.accesoCotizaciones dt = new Negocios.NGCotizacion.accesoCotizaciones();
            gunaDataGridView1.DataSource = null;
            var lls = await dt.BuscarCitizacionPorId(id, sucursal);
            gunaDataGridView1.DataSource = lls;
            if (gunaDataGridView1.RowCount <= 0)
            {
                MessageBox.Show("No se encontraron datos");
                return;
            }
            
            dtgDetalle.DataSource = await dt.BuscaInfoTablaCotizacionPorId(id, sucursal); 
            dgvEntsCot.DataSource = await dt.BuscaEntsEnCot(_nCotD7);
            foreach (var item in lls)
            {
                txbComent.Text = String.IsNullOrWhiteSpace(item.C24)?"": item.C24.Trim();
            }

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
    }
}
