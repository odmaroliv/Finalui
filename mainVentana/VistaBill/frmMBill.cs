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
    public partial class frmMBill : Form
    {
        public frmMBill()
        {
            InitializeComponent();
        }

        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel();


        }

        private void AbrirFormEnPanel()
        {
            frmOperSalidas frm = new frmOperSalidas();
            frm.ShowDialog();
            frm.Dispose();
        }

    }
}
