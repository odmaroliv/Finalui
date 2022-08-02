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
    public partial class frmRecepcion : Form
    {
        public frmRecepcion()
        {
            InitializeComponent();
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            frmListaSalidasRecep frm = new frmListaSalidasRecep();
            frm.lblSucOrigen.Text = cmbSucEnvia.Text;
            frm.ShowDialog();
            frm.Dispose();
        }
    }
}
