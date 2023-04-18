using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Datosenti;
using mainVentana.Loading;
using mainVentana.Properties;
using mainVentana.vistaConfiguraciones;
using Negocios;

namespace mainVentana
{
    public partial class Login : Form
    {
        private bool _prueba;
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public Login()
        {
            InitializeComponent();
        }
        
        private async void Login_Load(object sender, EventArgs e)
        {
            
            await obtain();
            txbPass2.UseSystemPasswordChar = true;
            Negocios.psisarn psisarn = new Negocios.psisarn();
            psisarn.CS(Negocios.MB.mbsecurity.SN, Negocios.MB.mbsecurity.CSN, Settings.Default.Catalogo);

            //Servicios vld = new Servicios();
            //bool internet = await vld.Test();
            int desc;
            txbUsr.Text = Settings.Default.usuarioRecurrente;
            ModoEjecuta();
            if (InternetGetConnectedState(out desc, 0) == true)
            {
            }
            else
            {
                MessageBox.Show("Nececitas una coneccion a internet para poder accesar", "Sin coneccion");
                
            }
           
        }

        private void ModoEjecuta()
        {
           // Negocios.psisarn psisarn = new Negocios.psisarn();
           // string mod = psisarn.modo();

            if (Settings.Default.Catalogo == "KEPLER_PRUEBAS")
            {
                lblModoPruebas.Visible = true;
                _prueba = true;
            }

        }



        private async Task<int> obtain()
        {
            //int estatus = 1; // 1 identificado 0 Error
            //Negocios.Properties.Settings.Default.apiUs = null;
            //Negocios.Properties.Settings.Default.apiPs = null;
            if (!String.IsNullOrWhiteSpace(Negocios.Common.Cache.AccesData.uso))
            {
                return 1;
            }

            Negocios.accesCommon.NgAccesData dt = new Negocios.accesCommon.NgAccesData();

            await  dt.ObtenerCredenciales();

            string Us = Negocios.Common.Cache.AccesData.uso;
            


            if (String.IsNullOrWhiteSpace(Us))
            {
                MessageBox.Show("No se ha activado este producto, requieres una Licencia de Arsys Arnian System WMS", "Producto no activado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnActivate.Visible = true;
                return 0;
            }
        
            return 1;
            
        }


        


        private async void iconButton1_Click(object sender, EventArgs e)
        {
            int result = await ConeccionRed.TestInternet();
            if (result == 1)
            {
                MessageBox.Show("No tienes internet");
                return;
            }
            else
            {
                if (_prueba==true)
                {
                    if (MessageBox.Show("Estas igresando al entorno de PRUEBAS, ten cuidado.\nNada de lo que hagas aqui sera guardado para su uso real", "Estas seguro?", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.Cancel)
                    {
                        return;
                    }

                }
                Validaciones_P_Busqueda();
                
            }


        }

        private async void loadinggg(int estado)
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


        private async Task Inicio()
        {
            int result = await ConeccionRed.TestInternet();

            // Verificar la conexión a internet
            if (result != 0)
            {
                MessageBox.Show("No hay conexión a internet.");
                return;
            }

            // Validar credenciales de inicio de sesión
            Servicios vld = new Servicios();
            if (!vld.cargalogin(txbUsr.Text.Trim(), txbPass2.Text.Trim()))
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
                return;
            }

            // Obtener configuraciones de correo electrónico
            bool smtp = await vld.ObtieneEmail();

            // Mostrar formulario
            using (Form1 frm1 = new Form1())
            {
                frm1.Cerrado += new Form1.Cierra(ActivaElForm);
                this.Hide();
                frm1.ShowDialog();
            }
        }


        private void ActivaElForm()
        {
            this.txbPass2.Text = "";
            this.Show();
        }
        private void BorrarCarpetaTemporal(string carpetaTemporal)
        {
            if (Directory.Exists(carpetaTemporal))
            {
                Directory.Delete(carpetaTemporal, true);
            }
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string carpetaTemporal = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
                lblBorrarArch.Text = "Borrando Archivos Temporales, Espere...";
                BorrarCarpetaTemporal(carpetaTemporal);
            }
            catch (Exception)
            {

                throw;
            }
           

            Application.Exit(); // cierra la aplicacion completamente

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Cierra el formulario
            this.Dispose();
            this.Close();
        }

        private async void txbPass_KeyDown(object sender, KeyEventArgs e)
        {
            int result = await ConeccionRed.TestInternet();
            if (e.KeyCode == Keys.Return)
            {
                if (result == 1)
                {
                    MessageBox.Show("No tienes internet");
                    return;
                }
                loadinggg(1);

                if (_prueba == true)
                {
                    if (MessageBox.Show("Estas igresando al entorno de PRUEBAS, ten cuidado.\nNada de lo que hagas aqui sera guardado para su uso real", "Estas seguro?", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.Cancel)
                    {
                        return;
                    }

                }

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

           await Inicio();

            loadinggg(0);
        }

        private async void txbUsr_KeyDown(object sender, KeyEventArgs e)
        {
            int result = await ConeccionRed.TestInternet();

            if (e.KeyCode == Keys.Return)
            {
                if (result == 1)
                {
                    MessageBox.Show("No tienes internet");
                    return;
                }
                loadinggg(1);
                if (_prueba == true)
                {
                    if (MessageBox.Show("Estas igresando al entorno de PRUEBAS, ten cuidado.\nNada de lo que hagas aqui sera guardado para su uso real", "Estas seguro?", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.Cancel)
                    {
                        return;
                    }

                }
                Validaciones_P_Busqueda();


            }

            if (e.KeyCode == Keys.P && e.Shift)
            {
                if (cmbServerSelect.Visible == true)
                {
                    cmbServerSelect.Visible = false;
                }
                else
                {
                    cmbServerSelect.Visible = true;
                }
               
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

        private void btnActivate_Click(object sender, EventArgs e)
        {
            using (LicenciaFRM frm = new LicenciaFRM())
            {
                frm.ShowDialog();
            }
        }

        private void cmbServerSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Negocios.psisarn psisarn = new Negocios.psisarn();
            Settings.Default.Catalogo = cmbServerSelect.SelectedItem.ToString();
            Settings.Default.Save();
            psisarn.CS(Negocios.MB.mbsecurity.SN, Negocios.MB.mbsecurity.CSN, Settings.Default.Catalogo);
           
        }
    }
}
