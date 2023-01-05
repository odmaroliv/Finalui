using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mainVentana.Loading;
using mainVentana.Properties;
using Negocios;

namespace mainVentana
{
    public partial class Login : Form
    {

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public Login()
        {
            InitializeComponent();
        }
        
        private async void Login_Load(object sender, EventArgs e)
        {
            txbPass2.UseSystemPasswordChar = true;
            Negocios.psisarn psisarn = new Negocios.psisarn();
            psisarn.CS(Negocios.MB.mbsecurity.SN, Negocios.MB.mbsecurity.CSN);

            //Servicios vld = new Servicios();
              //bool internet = await vld.Test();
            int desc;
         
            if (InternetGetConnectedState(out desc, 0) == true)
            {
            }
            else
            {
                MessageBox.Show("Nececitas una coneccion a internet para poder accesar", "Sin coneccion");
                
            }
            txbUsr.Text = Settings.Default.usuarioRecurrente;
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (Negocios.ConeccionRed.TestInternet() == 1)
            {
                MessageBox.Show("No tienes internet");
                return;
            }
            else
            {
                Validaciones_P_Busqueda();
            }

           
        }

        private void loadinggg(int estado)
        {
            
            LoadingPatoControl loadingPatoControl = new LoadingPatoControl();
                if (estado == 1)
                {
                    loadingPatoControl.Dock = DockStyle.Fill;
                    pnlImg.Controls.Add(loadingPatoControl);
                }
                if (estado == 0)
                {
                pnlImg.Controls.Clear();
                }
            


        }
        

        private void Inicio()
        {
            //--------------------validamos si hay coneccion, de lo contrario no ejecuta el showD />
            Servicios vld = new Servicios();

            //-------------------------Fin de la validacion />


            bool valida = vld.cargalogin(txbUsr.Text.Trim(), txbPass2.Text.Trim());
            if (valida == true)
            {
                Form1 frm1 = new Form1();

                frm1.Cerrado += new Form1.Cierra(ActivaElForm);
                this.Hide();
                frm1.ShowDialog();
                
                frm1.Dispose();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
               
            }
        }

        private void ActivaElForm()
        {
            this.txbPass2.Text = "";
            this.Show();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit(); // cierra la aplicacion completamente

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Cierra el formulario
            this.Dispose();
            this.Close();
        }

        private void txbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (Negocios.ConeccionRed.TestInternet() == 1)
                {
                    MessageBox.Show("No tienes internet");
                    return;
                }
                loadinggg(1); 
                Validaciones_P_Busqueda();
               
            }
        }
        private async void Validaciones_P_Busqueda()
        {
            
            if (txbPass2.Text     == "")
            {
                MessageBox.Show("El campo de Contraseña esta vacio!");
                loadinggg(0);
                return;
               
            }
            else if (txbUsr.Text == "")
            {
                MessageBox.Show("El campo de Usuario esta vacio!");
                loadinggg(0);
                return;

            }
            try
            {
                Settings.Default.usuarioRecurrente = txbUsr.Text.Trim();
                Settings.Default.Save();
            }
            catch (Exception)
            {

                
            }
            Inicio(); 
            loadinggg(0);
        }

        private void txbUsr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (Negocios.ConeccionRed.TestInternet() == 1)
                {
                    MessageBox.Show("No tienes internet");
                    return;
                }
                loadinggg(1);

                Validaciones_P_Busqueda(); 
               
               
            }
        }

        private void cbxPass_CheckedChanged(object sender, EventArgs e)
        {
           
            if (cbxPass.Checked)
            {
                txbPass2.UseSystemPasswordChar = false;
              

            }
            else
            {
                txbPass2.UseSystemPasswordChar = true;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            txbPass2.UseSystemPasswordChar = false;
        }
    }
}
