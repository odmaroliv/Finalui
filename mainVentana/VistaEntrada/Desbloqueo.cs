using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaEntrada
{
    public partial class Desbloqueo : Form
    {
        public delegate void cambio (bool check);
        public event cambio cambiar;
        public Desbloqueo()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (gunaLineTextBox2.Text.Trim() == 1473698.ToString() || gunaLineTextBox2.Text.Trim() == 112233.ToString())
                {
                    cambiar(true);
                    this.Dispose();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("LA CONTRASEÑA ES INCORRECTA");
                    gunaLineTextBox2.Text = "";
                    gunaLineTextBox2.Focus();
                }
            }
            catch (Exception)
            {
                cambiar(true);
               // throw;
            }
            finally {

                cambiar(false);

            }
           
        }

        private void Desbloqueo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void Desbloqueo_Load(object sender, EventArgs e)
        {

        }
    }
}
