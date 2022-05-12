using Negocios;
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
    public partial class BusquedasEnt : Form
    {

        public delegate void pasar(string dato, int bandera);
        public event pasar pasado;
        public BusquedasEnt()
        {
            InitializeComponent();
        }

        private void BusquedasEnt_Load(object sender, EventArgs e)
        {
            comboBox1.AutoCompleteCustomSource = aliasList();
            validacionesdatos datos = new validacionesdatos();



        }

        private void pasarinfo()
        {
            if (label2.Text == "CLIENTE")
            { pasado(gunaTextBox2.Text,0); }
            else if (label2.Text == "ALIAS")
            { pasado(gunaTextBox2.Text, 1); }


        }

        private AutoCompleteStringCollection aliasList()
        {
            AutoCompleteStringCollection List = new AutoCompleteStringCollection();
            validacionesdatos datos = new validacionesdatos();
            if (label2.Text == "ALIAS")
            {
                
                var lst = datos.llenaAlias();
                foreach (var p in lst)
                {
                    List.Add(p.c1);
                    
                }
                
            }
            else if (label2.Text == "CLIENTE")
            {
                var lst = datos.llenaClientes();
                foreach (var p in lst)
                {
                    List.Add(p.c3);
                    
                }
               
            }

            return List;



        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                MessageBox.Show("dacaaaaa");
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                /*validacionesdatos datos = new validacionesdatos();
                var lst = datos.llenaAlias();
                foreach (var d in lst)
                {
                    if (d.ToString() == comboBox1.Text)
                    {
                        MessageBox.Show("Dato correcto" + comboBox1.Text);

                    }
                    else
                    {
                        MessageBox.Show("Dato incorrecto" + comboBox1.Text);
                    }
                    MessageBox.Show(d.ToString());



                }
            */
                MessageBox.Show("dacaaaaa");
            }




        }






        private void gunaTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaGradientTileButton4_Click(object sender, EventArgs e)
        {
            if (label2.Text == "ALIAS")
            {
                validacionesdatos datos = new validacionesdatos();
                var lst = datos.llenaAlias();
                int bandera = 0;
                foreach (var d in lst)
                {
                    if (d.c1.ToString().Trim() == comboBox1.Text.Trim() && comboBox1.Text != " ")
                    {
                        bandera = 1;
                        gunaTextBox2.Text = d.c1.ToString().Trim();
                        pasarinfo();
                        this.Dispose();
                        this.Close();

                    }

                }

                if (bandera == 0)
                {
                    gunaTextBox2.Text = "";
                    MessageBox.Show("Dato incorrecto, el alias: " + comboBox1.Text + ", NO se encuentra en la base de datos ");

                }

            }
            else if (label2.Text == "CLIENTE")
            {
                validacionesdatos datos = new validacionesdatos();
                var lst = datos.llenaClientes();
                int bandera = 0;
                foreach (var d in lst)
                {
                    if (d.c3.ToString().Trim() == comboBox1.Text.Trim() && comboBox1.Text != " ")
                    {
                        bandera = 1;
                        gunaTextBox2.Text = d.c3.ToString().Trim();
                        pasarinfo();
                        this.Dispose();
                        this.Close();

                    }

                }

                if (bandera == 0)
                {
                    gunaTextBox2.Text = "";
                    MessageBox.Show("Dato incorrecto, el cliente: " + comboBox1.Text + ", NO se encuentra en la base de datos ");

                }
            }
            
        }



    }
}
