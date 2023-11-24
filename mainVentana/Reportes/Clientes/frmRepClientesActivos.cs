using Negocios;
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
    public partial class frmRepClientesActivos : Form
    {
        private bool _isBussy = false;

        public frmRepClientesActivos()
        {
            InitializeComponent();
        }

        private async void btnAlta_Click(object sender, EventArgs e)
        {
            _isBussy = true;
            progressBar1.Visible = true;
            try
            {
                dgvRep.DataSource = null;
                label4.Text = string.Empty;
                ngbdReportes rep = new ngbdReportes();
                var cordin = cord.SelectedValue.ToString();
                if (String.IsNullOrWhiteSpace(cordin))
                {
                    return;
                }
                var lista = await rep.CargaReporteClientesActivos(cordin, dtFecha1.Value, dtFecha2.Value);
                dgvRep.DataSource = lista;
                label4.Text = lista.Count.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _isBussy = false;
                progressBar1.Visible = false;
            }
            
        }

        private async void frmRepClientesActivos_Load(object sender, EventArgs e)
        {
            Servicios datos = new Servicios();

            var lst1 = await datos.llenaCord();
            cord.ValueMember = "C2";
            cord.DisplayMember = "C3";
            cord.DataSource = lst1;
            dtFecha1.Value = DateTime.Now;
            dtFecha2.Value = DateTime.Now;
        }

        private void frmRepClientesActivos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isBussy==true)
            {
                MessageBox.Show("Hay una operaci'on actual");
                return;
            }
        }
    }
}
