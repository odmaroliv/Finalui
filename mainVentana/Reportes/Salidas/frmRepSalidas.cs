using Datos.ViewModels;
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

namespace mainVentana.Reportes.Salidas
{
    public partial class frmRepSalidas : Form
    {

        public string sucursalGlobal = Negocios.Common.Cache.CacheLogin.sucGlobal == default ? "SD" : Negocios.Common.Cache.CacheLogin.sucGlobal;
        private string sucursal = "SD";
        private int _salidaBuscada;
        public frmRepSalidas()
        {
            InitializeComponent();
        }

        private void rSd_CheckedChanged(object sender, EventArgs e)
        {

            var radioButtonMapping = new Dictionary<RadioButton, string>
                {
        { rSd, "SD" },
        { rTj, "TJ" },
        { rCa, "CSL" },

                 };

            // Encontrar el RadioButton seleccionado y obtener su valor correspondiente
            sucursal = radioButtonMapping.FirstOrDefault(r => r.Key.Checked).Value;
        }

        private void gunaTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrWhiteSpace(txbBusqueda.Text))
                {
                    return;
                }
                try
                {
                    e.Handled = true;
                    _salidaBuscada = Convert.ToInt32(txbBusqueda.Text);

                    buscaSalida();
                }
                catch (Exception)
                {
                    MessageBox.Show("Solo se permiten numeros");
                }
            }
        }
        private async void buscaSalida()
        {
            AccesoSalidas sld = new AccesoSalidas();
            dgvSalidas.DataSource =  await sld.BuscEntradasSalidaReporte(_salidaBuscada.ToString(),sucursal);

        }
    }
}
