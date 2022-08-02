using Negocios.NGRecepcion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaRecepcion
{
    public partial class frmListaSalidasRecep : Form
    {
        public frmListaSalidasRecep()
        {
            InitializeComponent();
        }

        private void frmListaSalidasRecep_Load(object sender, EventArgs e)
        {
            ngbdRecepcion bd = new ngbdRecepcion();
            dgvSalidasSelect.DataSource = bd.VisualizaciondeSalidas(lblSucOrigen.Text.Trim());
        }
    }
}
