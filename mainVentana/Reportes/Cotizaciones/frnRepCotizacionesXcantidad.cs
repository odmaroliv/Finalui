using Datos.ViewModels.Coord;
using Guna.UI.WinForms;
using Negocios;
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

namespace mainVentana.Reportes.Cotizaciones
{
    public partial class frnRepCotizacionesXcantidad : Form
    {
        private bool _isBusy = false;
        private string _idBusqueda;
        private List<vmBusquedaCot> _lst = new List<vmBusquedaCot>();
        public frnRepCotizacionesXcantidad()
        {
            InitializeComponent();
        }

        private async void frnRepCotizacionesXcantidad_Load(object sender, EventArgs e)
        {

            await inicia();
        }
        private async Task inicia()
        {
           
        }

        private async void btnAlta_Click(object sender, EventArgs e)
        {
         buscarCotizacion();
        }
        private async void buscarCotizacion()
        {
            if (_isBusy)
                return;

            _isBusy = true;
            try
            {
                _idBusqueda = txbBusqueda.Text;
                Negocios.NGCotizacion.accesoCotizaciones dt = new Negocios.NGCotizacion.accesoCotizaciones();
                dgvRep.DataSource = null;
                _lst.Clear();
                decimal dato;
                bool esValido = decimal.TryParse(txbBusqueda.Text, out dato);

                if (esValido)
                    _lst = await dt.BuscarCotizacionPorCantidad(valorArnian: dato);
                if (_lst.Any())
                    dgvRep.DataSource = _lst;


                
             
            }
            catch (Exception)
            {

                MessageBox.Show("e r r o r");
            }
           finally
            { _isBusy = false; }

           


        }

        private async void txbBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarCotizacion();


               // await Task.Run(() => { Thread.Sleep(1000); });

                e.SuppressKeyPress = true;
            }
        }

        private void frnRepCotizacionesXcantidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isBusy)
            {
                MessageBox.Show("Hay un trabajo");
                e.Cancel = true;
            }
        }
    }
}
