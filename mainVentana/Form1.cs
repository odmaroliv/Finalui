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
            
            string voi = "";
            frm.refresh(voi);
            cargasatosUrs();



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

            iconButton2.ForeColor = Color.FromArgb(193, 193, 193);
            iconButton2.IconColor = Color.FromArgb(193, 193, 193);

        }

        private void iconButton2_MouseEnter(object sender, EventArgs e)
        {
            iconButton2.ForeColor = Color.FromArgb(255, 255, 255);
            iconButton2.IconColor = Color.FromArgb(255, 255, 255);
        }
        //Carga
        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {

            iconButton3.ForeColor = Color.FromArgb(193, 193, 193);
            iconButton3.IconColor = Color.FromArgb(193, 193, 193);

        }

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            iconButton3.ForeColor = Color.FromArgb(255, 255, 255);
            iconButton3.IconColor = Color.FromArgb(255, 255, 255);
        }
        //Salida
        private void iconButton4_MouseLeave(object sender, EventArgs e)
        {

            iconButton4.ForeColor = Color.FromArgb(193, 193, 193);
            iconButton4.IconColor = Color.FromArgb(193, 193, 193);

        }

        private void iconButton4_MouseEnter(object sender, EventArgs e)
        {
            iconButton4.ForeColor = Color.FromArgb(255, 255, 255);
            iconButton4.IconColor = Color.FromArgb(255, 255, 255);
        }
        //Recepcion
        private void iconButton5_MouseLeave(object sender, EventArgs e)
        {

            iconButton5.ForeColor = Color.FromArgb(193, 193, 193);
            iconButton5.IconColor = Color.FromArgb(193, 193, 193);

        }

        private void iconButton5_MouseEnter(object sender, EventArgs e)
        {
            iconButton5.ForeColor = Color.FromArgb(255, 255, 255);
            iconButton5.IconColor = Color.FromArgb(255, 255, 255);
        }
        //Bill
        private void iconButton6_MouseLeave(object sender, EventArgs e)
        {

            iconButton6.ForeColor = Color.FromArgb(193, 193, 193);
            iconButton6.IconColor = Color.FromArgb(193, 193, 193);

        }

        private void iconButton6_MouseEnter(object sender, EventArgs e)
        {
            iconButton6.ForeColor = Color.FromArgb(255, 255, 255);
            iconButton6.IconColor = Color.FromArgb(255, 255, 255);
        }
        //Traking
        private void iconButton7_MouseLeave(object sender, EventArgs e)
        {

            iconButton7.ForeColor = Color.FromArgb(193, 193, 193);
            iconButton7.IconColor = Color.FromArgb(193, 193, 193);

        }

        private void iconButton7_MouseEnter(object sender, EventArgs e)
        {
            iconButton7.ForeColor = Color.FromArgb(255, 255, 255);
            iconButton7.IconColor = Color.FromArgb(255, 255, 255);
        }
        #endregion
        //--------------texbox de busqueda placeholder------
        #region placehold buscar
        private void gunaTextBox1_MouseEnter(object sender, EventArgs e)
        {
            if (gunaTextBox1.Text == "Busqueda rapida de entrada :)")
            {
                gunaTextBox1.Text = "";

            }


        }
        private void gunaTextBox1_MouseLeave(object sender, EventArgs e)
        {

            label4.Text = "Busqueda rapida de entrada :)";
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



        private void iconButton9_MouseEnter(object sender, EventArgs e)
        {
            
            iconButton9.IconColor = Color.FromArgb(0, 0, 0);
        }

        private void iconButton9_MouseLeave(object sender, EventArgs e)
        {
            iconButton9.IconColor = Color.FromArgb(104, 183, 255);
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            iconButton9.IconColor = Color.Tomato;
            string id = gunaTextBox1.Text;
            ValidabPrincipal();
            frm.refresh(id);
            AbrirFormEnPanel(frm);

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


        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaTextBox1_KeyUp(object sender, KeyEventArgs e)
        {



            //Cargabuscque(gunaTextBox1.Text.ToString());
        }



        private void gunaTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                ValidabPrincipal();
                string id = gunaTextBox1.Text;
                frm.refresh(id);

                e.SuppressKeyPress = true;




            }
        }
        private void ValidabPrincipal()
        {
            if (gunaTextBox1.Text == "")
            {
                MessageBox.Show("El campo de busqueda esta vacio!");
                return;
            }
            int datparseado;
            bool bent = Int32.TryParse(gunaTextBox1.Text, out datparseado);
            if (bent == true)
            {
                gunaTextBox1.Text = datparseado.ToString("D7");
            }
            else
            {
                MessageBox.Show("Las entradas tienen que ser un codigo numerico, y no pueden contener letras");
                return;
            }
        }


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
        //Maximize & Restore "Event"


    }
}
