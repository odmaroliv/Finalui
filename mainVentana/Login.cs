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
        
        private async void Login_Load(object sender, EventArgs e)
        {

            Negocios.psisarn psisarn = new Negocios.psisarn();
            psisarn.CS(Negocios.MB.mbsecurity.SN, Negocios.MB.mbsecurity.CSN);

            Servicios vld = new Servicios();

            bool internet = await vld.Test();
            if (internet == true)
            {
            }
            else
            {
                MessageBox.Show("Nececitas una coneccion a internet para poder accesar", "Sin coneccion");
                return;
            }

        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            
            Inicio();

        }
        private void Inicio()
        {
            //--------------------validamos si hay coneccion, de lo contrario no ejecuta el showD />
            Servicios vld = new Servicios();

            
            //-------------------------Fin de la validacion />
            bool valida = vld.cargalogin(txbUsr.Text.Trim(), txbPass.Text.Trim());
            if (valida == true)
            {
                Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
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

        private void txbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Validaciones_P_Busqueda();
            }
        }
        private void Validaciones_P_Busqueda()
        {
            if (txbPass.Text     == "")
            {
                MessageBox.Show("El campo de Contraseña esta vacio!");
                return;
            }
            else if (txbUsr.Text == "")
            {
                MessageBox.Show("El campo de Usuario esta vacio!");
                return ;
            }
            Inicio();
        }

        private void txbUsr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Validaciones_P_Busqueda();
            }
        }
    }
}
