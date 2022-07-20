using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaInicioCoordinadores
{
    public partial class frmInfoEntradaCords : Form
    {
        public frmInfoEntradaCords()
        {
            InitializeComponent();

        }

        


        private void btnEntrada_Click(object sender, EventArgs e)
        {
            char[] c = "-".ToCharArray();
            string entsp = txbEtiqueta.Text.Split(c)[1];
            string sucsp = txbEtiqueta.Text.Split(c)[0];

        

            /*if (MessageBox.Show("Estas apunto de dar de baja na entrada " + entsp + " \nde: " + sucsp,"Alerta",MessageBoxButtons.OKCancel,MessageBoxIcon.Stop) ==DialogResult.OK)
            {
                if (MessageBox.Show("De nuevo, esta entrada se eliminara de las tablas, quedado unicamente disponible para su consulta \nEntrada: " + entsp + " \nDe: " + sucsp, "Ultima Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
                {

                }
            }*/
            
        }
    }
}
