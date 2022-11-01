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

namespace mainVentana
{
    public partial class Form1 : Form
    {
        Over frm = new Over(); // llama al formulario de Inicio

        Entradas Entradas = new Entradas(); // se llama al formulario de entrada
        Login Login = new Login();


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AbrirFormEnPanel(frm);



            cargasatosUrs();
            validamenu();


        }

        private void validamenu()
        {
            if (CacheLogin.rol.Trim() == "ADMIN" || CacheLogin.rol.Trim() == "JALMA")
            {
                btnSalida.Visible = true;
                btnOrCarga.Visible = true;
                btnEntrada.Visible = true;
                btnRecep.Visible = true;
                btnTraking.Visible = true;
                btnReportes.Visible = true;
                btnAjustes.Visible = true;
                btnBill.Visible = true;
            }
            else if (CacheLogin.rol.Trim() == "OENTRA")
            {
                btnOrCarga.Visible = false;
                btnRecep.Visible = false;
                btnSalida.Visible = false;
            }
            else if (CacheLogin.rol.Trim() == "CSERVI")
            {
                btnSalida.Visible = false; 
                btnOrCarga.Visible = false;
                btnEntrada.Visible = false;
                btnRecep.Visible = false; 
            }
            else if (CacheLogin.rol.Trim() == "CONT" || CacheLogin.rol.Trim() == "REVISOR")
            {
                btnSalida.Visible = false;
                btnOrCarga.Visible = false;
                btnEntrada.Visible = false;
                btnRecep.Visible = false;
                btnAjustes.Visible = false;
                btnBill.Visible=false;

            }


            else
            {
                btnSalida.Visible = false;
                btnOrCarga.Visible = false;
                btnEntrada.Visible = false;
                btnRecep.Visible = false;
                btnTraking.Visible = false;
                btnReportes.Visible = false;
                btnAjustes.Visible = false;
                btnBill.Visible = false;
                MessageBox.Show("El usuario con el que ingresaste pertenece a un rol que no es compatible con Arsys, te recomendamos contactar a Daniel para cambiar el rol de tu usuario");
            }


        }


        private void cargasatosUrs()
        {
            lblNombreUsr.Text = CacheLogin.nombre + " " + CacheLogin.apellido;
            lblRol.Text = CacheLogin.email;

        }

        #region Enter y Leave de Muse
        //Inicio
        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {

            iconButton1.ForeColor = Color.FromArgb(193, 193, 193);
            iconButton1.IconColor = Color.FromArgb(193, 193, 193);

        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.ForeColor = Color.FromArgb(255, 255, 255);
            iconButton1.IconColor = Color.FromArgb(255, 255, 255);
        }
        //Entrada
        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {

            btnEntrada.ForeColor = Color.FromArgb(193, 193, 193);
            btnEntrada.IconColor = Color.FromArgb(193, 193, 193);

        }

        private void iconButton2_MouseEnter(object sender, EventArgs e)
        {
            btnEntrada.ForeColor = Color.FromArgb(255, 255, 255);
            btnEntrada.IconColor = Color.FromArgb(255, 255, 255);
        }
        //Carga
        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {

            btnOrCarga.ForeColor = Color.FromArgb(193, 193, 193);
            btnOrCarga.IconColor = Color.FromArgb(193, 193, 193);

        }

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            btnOrCarga.ForeColor = Color.FromArgb(255, 255, 255);
            btnOrCarga.IconColor = Color.FromArgb(255, 255, 255);
        }
        //Salida
        private void iconButton4_MouseLeave(object sender, EventArgs e)
        {

            btnSalida.ForeColor = Color.FromArgb(193, 193, 193);
            btnSalida.IconColor = Color.FromArgb(193, 193, 193);

        }

        private void iconButton4_MouseEnter(object sender, EventArgs e)
        {
            btnSalida.ForeColor = Color.FromArgb(255, 255, 255);
            btnSalida.IconColor = Color.FromArgb(255, 255, 255);
        }
        //Recepcion
        private void iconButton5_MouseLeave(object sender, EventArgs e)
        {

            btnRecep.ForeColor = Color.FromArgb(193, 193, 193);
            btnRecep.IconColor = Color.FromArgb(193, 193, 193);

        }

        private void iconButton5_MouseEnter(object sender, EventArgs e)
        {
            btnRecep.ForeColor = Color.FromArgb(255, 255, 255);
            btnRecep.IconColor = Color.FromArgb(255, 255, 255);
        }
        //Bill
        private void iconButton6_MouseLeave(object sender, EventArgs e)
        {

            btnBill.ForeColor = Color.FromArgb(193, 193, 193);
            btnBill.IconColor = Color.FromArgb(193, 193, 193);

        }

        private void iconButton6_MouseEnter(object sender, EventArgs e)
        {
            btnBill.ForeColor = Color.FromArgb(255, 255, 255);
            btnBill.IconColor = Color.FromArgb(255, 255, 255);
        }
        //Traking
        private void iconButton7_MouseLeave(object sender, EventArgs e)
        {

            btnTraking.ForeColor = Color.FromArgb(193, 193, 193);
            btnTraking.IconColor = Color.FromArgb(193, 193, 193);

        }

        private void iconButton7_MouseEnter(object sender, EventArgs e)
        {
            btnTraking.ForeColor = Color.FromArgb(255, 255, 255);
            btnTraking.IconColor = Color.FromArgb(255, 255, 255);
        }

        //Reportes
        private void btnReportes_MouseLeave(object sender, EventArgs e)
        {
            btnReportes.ForeColor = Color.FromArgb(193, 193, 193);
            btnReportes.IconColor = Color.FromArgb(193, 193, 193);
        }
        private void btnReportes_MouseEnter(object sender, EventArgs e)
        {
            btnReportes.ForeColor = Color.FromArgb(255, 255, 255);
            btnReportes.IconColor = Color.FromArgb(255, 255, 255);

        }

        //Ajustes
        private void btnAjustes_MouseLeave(object sender, EventArgs e)
        {
            btnAjustes.ForeColor = Color.FromArgb(193, 193, 193);
            btnAjustes.IconColor = Color.FromArgb(193, 193, 193);
        }
        private void btnAjustes_MouseEnter(object sender, EventArgs e)
        {
            btnAjustes.ForeColor = Color.FromArgb(255, 255, 255);
            btnAjustes.IconColor = Color.FromArgb(255, 255, 255);
        }


        #endregion
        
      

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
            AbrirFormEnPanel(frm);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Entradas ent = new Entradas();
                ent.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Close();
            form1.Dispose();
            Login.Show();

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            try
            {
                VistaOrSalida.frmOrdSalida salida = new VistaOrSalida.frmOrdSalida();
                salida.ShowDialog();
                salida.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            VistaBill.frmMBill frm = new VistaBill.frmMBill();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            frmMenuReportes frm = new frmMenuReportes();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnRecep_Click(object sender, EventArgs e)
        {
            frmRecepcion frm = new frmRecepcion();
            frm.ShowDialog();
            frm.Dispose();
        }




    }
}
