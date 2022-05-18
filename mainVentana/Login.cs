using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;

namespace mainVentana
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void iconButton1_Click(object sender, EventArgs e)
        {   
            //--------------------validamos si hay coneccion, de lo contrario no ejecuta el showD />
            Servicios vld = new Servicios();

            bool internet = vld.Test();
            if (internet == true)
            {
            }
            else
            {
                MessageBox.Show("Nececitas una coneccion a internet para poder accesar","Sin coneccion");
                return;
            }
            //-------------------------Fin de la validacion />

            Form1 frm1 = new Form1();

            frm1.Show();
            this.Hide();
            
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit(); // cierra la aplicacion completamente

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login lg = new Login(); // Cierra el formulario
            lg.Dispose();
            lg.Close();
        }
    }
}
