using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaOrSalida
{
    public partial class frmOrdSalida : Form
    {
        public frmOrdSalida()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            frmBuscarOrdCarga oc = new frmBuscarOrdCarga();
            oc.ShowDialog();
        }
    }
}
