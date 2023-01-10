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
using Negocios.Common.Cache;
using System.Threading;
using mainVentana.vistaReportes;
using mainVentana.VistaRecepcion;
using mainVentana.VistaOrdenCarga;
using System.Windows.Forms;
using System.Diagnostics;

namespace mainVentana
{
    public partial class Form1 : Form
    {
        Over frmOver = new Over(); // llama al formulario de Inicio
        
       
    


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmFechaHora.Enabled = true;
            AbrirFormEnPanel(frmOver);



            cargasatosUrs();
            validamenu();
            sucursales();

        }

        private void validamenu()
        {
            if (CacheLogin.rol.Trim() == "ADMIN" || CacheLogin.rol.Trim() == "JALMA")
            {
               
            }
            else if (CacheLogin.rol.Trim() == "OENTRA")
            {
                //Enables
                rbtnCargas.Enabled = false;
                rbtnSalida.Enabled = false;
                rbtnReportes.Enabled = false;
                rbtnRecepcion.Enabled = false;
                rbtnBill.Enabled = false;


                //Visibles
                rbtnCargas.Visible = false;
                rbtnSalida.Visible = false;
                rbtnReportes.Visible = false;
                rbtnRecepcion.Visible = false;
               


            }
            else if (CacheLogin.rol.Trim() == "CSERVI")
            {
                //Enables
                rbtnEntrada.Enabled = false;
                rbtnCargas.Enabled = false;
                rbtnSalida.Enabled = false;
                rbtnReportes.Enabled = false;
                rbtnRecepcion.Enabled = false;


                //Visibles
                rbtnEntrada.Visible = false;
                rbtnCargas.Visible = false;
                rbtnSalida.Visible = false;
                rbtnReportes.Visible = false;
                rbtnRecepcion.Visible = false;
              

            }
            else if (CacheLogin.rol.Trim() == "CONT" || CacheLogin.rol.Trim() == "REVISOR")
            {
                //Enables
                rbtnEntrada.Enabled = false;
                rbtnCargas.Enabled = false;
                rbtnSalida.Enabled = false;
                rbtnReportes.Enabled = false;
                rbtnRecepcion.Enabled = false;
                rbtnBill.Enabled = false;


                //Visibles
                rbtnEntrada.Visible = false;
                rbtnCargas.Visible = false;
                rbtnSalida.Visible = false;
                rbtnReportes.Visible = false;
                rbtnRecepcion.Visible = false;
                rbtnBill.Visible = false;
            }


            else
            {
                //Enables
                rbtnEntrada.Visible = false;
                rbtnCargas.Enabled = false;
                rbtnSalida.Enabled = false;
                rbtnReportes.Enabled = false;
                rbtnRecepcion.Enabled = false;
                rbtnBill.Enabled = false;

                //Visibles
                rbtnEntrada.Visible = false;
                rbtnCargas.Visible = false;
                rbtnSalida.Visible = false;
                rbtnReportes.Visible = false;
                rbtnRecepcion.Visible = false;
                rbtnBill.Visible = false;
            
                MessageBox.Show("El usuario con el que ingresaste pertenece a un rol que no es compatible con Arsys, te recomendamos contactar a Daniel para cambiar el rol de tu usuario");
            }


        }


        private void cargasatosUrs()
        {
            lblNombreUsr.Text = CacheLogin.nombre + " " + CacheLogin.apellido;
            lblRol.Text = CacheLogin.email;

        }
        
      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tmFechaHora_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }



       
        #region abrir paneles metodo


        //METODO PARA ABRIR FORM DENTRO DE PANEL----------------------------------------------------
        private void AbrirFormEnPanel(object formHijo)
        {
            

            if (this.panelContenedorForm.Controls.Count > 0)
                this.panelContenedorForm.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelContenedorForm.Controls.Add(fh);
            this.panelContenedorForm.Tag = fh;
            fh.Show();
        }



        #endregion


     

        private void iconButton1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(frmOver);
        }

      

        public delegate void Cierra();
        //public delegate void pasar2(string dato,string cliente, int bandera);
        public event Cierra Cerrado;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            liberarR();
        }
        private void liberarR()
        {
            tmFechaHora.Enabled = false;
            Cerrado();
            frmOver.Dispose();
            frmOver.Close();
            this.Dispose();
            this.Close();
        }

      

     

      
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            liberarR();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ribbonOrbRecentItem1_Click(object sender, EventArgs e)
        {
            liberarR();
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            string val = rcmbSucAct.SelectedValue;
            MessageBox.Show(val);
        }

        private void rbtnEntrada_Click(object sender, EventArgs e)
        {
            try
            {
                using (Entradas ent = new Entradas())
                {
                    if (rcmbSucAct.Value !="")
                    {
                        ent.sucursalGlobal = rcmbSucAct.Value;
                    }
                    ent.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbtnCargas_Click(object sender, EventArgs e)
        {
            if (Negocios.ConeccionRed.TestInternet() == 1)
            {
                MessageBox.Show("No tienes internet");
                return;
            }
            try
            {
                using (frmOrdenDeCarga ocar = new frmOrdenDeCarga())
                {
                    ocar.ShowDialog();
                }


            }
            catch (Exception)
            {



            }
        }

        private void rbtnSalida_Click(object sender, EventArgs e)
        {
            try
            {
                using (VistaOrSalida.frmOrdSalida salida = new VistaOrSalida.frmOrdSalida())
                {
                    salida.ShowDialog();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void rbtnRecepcion_Click(object sender, EventArgs e)
        {
            using (frmRecepcion frm = new frmRecepcion())
            {
                frm.ShowDialog();
            }
        }

        private void rbtnBill_Click(object sender, EventArgs e)
        {
            using (VistaBill.frmMBill frm = new VistaBill.frmMBill())
            {
                frm.ShowDialog();
            }
        }

        private void rbtnReportes_Click(object sender, EventArgs e)
        {
            using (frmMenuReportes frm = new frmMenuReportes())
            {
                frm.ShowDialog();

            }

        }

        private void ribbonLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("https://web.whatsapp.com/");
        }

        private void lblWebex_Click(object sender, EventArgs e)
        {
            Process.Start("https://signin.webex.com/");
        }

        private void lblGmail_Click(object sender, EventArgs e)
        {
            Process.Start("https://gmail.com/");
        }

        private void lblAmazon_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.amazon.com/");

        }

        private void sucursales()
        {

        
        }

        private void rcmbSucAct_DropDownItemClicked(object sender, RibbonItemEventArgs e)
        {
            Negocios.Common.Cache.CacheLogin.sucGlobal = rcmbSucAct.SelectedValue==default || rcmbSucAct.SelectedValue == "" ? "SD" : rcmbSucAct.SelectedValue;
            rlblSucGlobal.Text = rcmbSucAct.SelectedItem+" "+ Negocios.Common.Cache.CacheLogin.sucGlobal;
        }

        private void apiConfig_Click(object sender, EventArgs e)
        {
            
          

            using (mainVentana.vistaConfiguraciones.frmConfiguraraApi apiconfi = new vistaConfiguraciones.frmConfiguraraApi())
            {
                apiconfi.ShowDialog();

            }
        }
    }
}
