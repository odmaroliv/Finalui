using Negocios.NGClientes;
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

namespace mainVentana.Reportes.Clientes
{
    public partial class frmRepClientexZona : Form
    {
        public frmRepClientexZona()
        {
            InitializeComponent();
        }

        private async void frmRepClientexZona_Load(object sender, EventArgs e)
        {
            await CargaInformacionInicial();
        }

        private async Task CargaInformacionInicial()
        {
            AccesoClientes ac = new AccesoClientes();

            cmbZona.DataSource = null;

            var lst2 = await ac.LLenaZona();
            cmbZona.ValueMember = "C2";
            cmbZona.DisplayMember = "C1";
            cmbZona.DataSource = lst2;

        }

        private async void btnAlta_Click(object sender, EventArgs e)
        {
            await FuncionBoton();
        }
        private async Task FuncionBoton()
        {
            try
            {
                label4.Text = "";
                string datoNoZona = cmbZona.SelectedValue.ToString();
                ngbdReportes rep = new ngbdReportes();
                var datosRepuesta = await rep.CargaReporteClientesXZona(datoNoZona);
                dgvRep.DataSource = datosRepuesta;
                label4.Text = datosRepuesta.Count.ToString();
            }
            catch (Exception)
            {

                throw;
            }
         
        }
    }
}
