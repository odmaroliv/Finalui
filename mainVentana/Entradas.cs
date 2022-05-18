using mainVentana.VistaEntrada;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using DesktopControl;

namespace mainVentana
{
    public partial class Entradas : Form
    {
        //KunLibertad_DesktopControl Desk = new KunLibertad_DesktopControl();
        AltaEntrada altaEntrada = new AltaEntrada();
        public Entradas()
        {
            InitializeComponent();
        }

        private void Entradas_Load(object sender, EventArgs e)
        {
            AbrirFormEnPanel(altaEntrada);
            //Desk.SpecialKeyButtons(false); bloquea teclas de wn
            cerrartabs(0);

        }
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

        private void gunaShadowPanel2_DoubleClick(object sender, EventArgs e)
        {
            AltaEntrada entradas = new AltaEntrada();
            if (MessageBox.Show("Cuidado, se borrara todo lo que no hayas guardado en esta ventana, deseas continuar?", "Cuidado", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                entradas.pictureBox2.Image = null;
                entradas.pictureBox3.Image = null;
                entradas.pictureBox4.Image = null;
                entradas.pictureBox5.Image = null;
                entradas.pictureBox6.Image = null;
                entradas.pictureBox7.Image = null;
                entradas.pictureBox8.Image = null;
                entradas.pictureBox9.Image = null;
                entradas.pictureBox10.Image = null;
                entradas.pictureBox11.Image = null;
                entradas.pictureBox12.Image = null;
                entradas.pictureBox13.Image = null;
                entradas.pictureBox14.Image = null;
                entradas.pictureBox15.Image = null;
                cerrartabs(0);
            }
            else
            {
                MessageBox.Show("Okay Nos quedamos aqui");
            }

        }

        private void Entradas_FormClosing(object sender, FormClosingEventArgs e)

        {
            if (MessageBox.Show("Estas apunto de cerrar la ventada de Entradas, si no has guardado da click en cancelar y guarda, de lo contrario da click en SI para salir al menu principal\n\n\n¿Deseas Sali?", "Hey, cuidado!", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                
                e.Cancel = true;
                return;
            }
            else
            {
                
                this.Dispose();
            }
           
        }

      
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


        private void cerrartabs(int dato)
        {

            if (dato == 0)
            {

                if (tabPage1.Parent == null) // 0 Alta de entrada
                {
                    // 0 es el index por la primera pestana
                    tabControl1.TabPages.Insert(0, tabPage1);


                }
               
                // Desconectar otras tabPage de TabControl para 'esconderlos'
                tabPage2.Parent = null;
                tabPage3.Parent = null;
            }
           else if (dato == 1)
            {

                if (tabPage2.Parent == null) // 1 modica entrada
                {
                   
                    tabControl1.TabPages.Insert(0, tabPage2);


                 }   
                tabPage1.Parent = null;
                tabPage3.Parent = null;
            }
            else if (dato == 2) // 2 Consulta entrada
            {
                if (tabPage3.Parent == null)
                {       
                    tabControl1.TabPages.Insert(0, tabPage3);
                }
                tabPage2.Parent = null;
                tabPage1.Parent = null;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            cerrartabs(1);
        }


        private void gunaShadowPanel3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cerrartabs(1);
        }

        private void gunaShadowPanel4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cerrartabs(2);
        }

        private void gunaGradientTileButton3_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradientTileButton3_Click_1(object sender, EventArgs e)
        {
            if (gunaShadowPanel1.Visible == false)
            {

                gunaShadowPanel1.Visible=true;
            }
            else
            {
                gunaShadowPanel1.Visible=false;
            }
        }

       

       
        private void btnAlta_DoubleClick(object sender, EventArgs e)
        {
            gunaShadowPanel1.ShadowColor = Color.FromArgb(250, 95, 73);  
        }

        private void btnModifica_DoubleClick(object sender, EventArgs e)
        {
            gunaShadowPanel1.ShadowColor = Color.FromArgb(245, 217, 181);
        }

        private void btnBaja_DoubleClick(object sender, EventArgs e)
        {
            gunaShadowPanel1.ShadowColor = Color.FromArgb(50, 202, 206);
            
        }

        private void btnConsulta_DoubleClick(object sender, EventArgs e)
        {
            gunaShadowPanel1.ShadowColor = Color.FromArgb(114, 91, 121);
        }
    }
}
