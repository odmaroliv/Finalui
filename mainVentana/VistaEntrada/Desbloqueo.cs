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
        private bool _isUsed = false;

        public Desbloqueo()
        {
            InitializeComponent();
           // this.FormClosing +=
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (gunaLineTextBox2.Text.Trim() == 1473698.ToString() || gunaLineTextBox2.Text.Trim() == 112233.ToString())
                {
                    _isUsed = true;
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
                cambiar(false);
               // throw;
            }
            finally
            {

                if (!_isUsed)
                {
                    cambiar(false);
                }
                else
                {
                    cambiar(true);
                }

            }

        }

        private void Desbloqueo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_isUsed)
            {
                cambiar(false);
            }
            
            this.Dispose();
            this.Close();
        }

        private void Desbloqueo_Load(object sender, EventArgs e)
        {

        }
    }
}
