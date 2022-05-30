using Datos.ViewModels.Entradas.mvlistas;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaEntrada
{
    public partial class BusquedasEnt : Form
    {

        public delegate void pasar(string alias, string cliente, string cord, string calle, string colonia, string ciudad, string codigocliente, int bandera);
        //public delegate void pasar2(string dato,string cliente, int bandera);
        public event pasar pasado;
       // public event pasar2 pasado2;
        public BusquedasEnt()
        {
            InitializeComponent();
        }

        private void BusquedasEnt_Load(object sender, EventArgs e)
        {
            comboBox1.AutoCompleteCustomSource = aliasList();
 
        }

        private void pasarinfo()
        {
            if (label2.Text == "CLIENTE")
            { pasado(gunaTextBox2.Text,"",gunaTextBox1.Text,calle,colonia,ciudad, Codcliente, 0); }
            else if (label2.Text == "ALIAS")
            { pasado(gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox1.Text,calle,colonia,ciudad,"", 1); }
        }

        private AutoCompleteStringCollection aliasList()
        {
            AutoCompleteStringCollection List = new AutoCompleteStringCollection();
            Servicios datos = new Servicios();
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
        string calle;
        string colonia;
        string ciudad;
        string Codcliente;
        private void gunaGradientTileButton4_Click(object sender, EventArgs e)
        {
            if (label2.Text == "ALIAS")
            {
                Servicios datos = new Servicios();
                var lst = datos.llenaAlias();
                int bandera = 0;
                foreach (var d in lst)
                {
                    if (d.c1.ToString().Trim() == comboBox1.Text.Trim() && comboBox1.Text != " ")
                    {
                        bandera = 1;
                        gunaTextBox2.Text = d.c1.ToString().Trim();
                        gunaTextBox3.Text = validCli(d.c3.ToString())[0].ToString();
                        gunaTextBox1.Text = validCli(d.c3.ToString())[1].ToString();
                        calle = d.c4.ToString();
                        colonia = d.c5.ToString();
                        ciudad = d.c6.ToString();
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
                Servicios datos = new Servicios();
                var lst = datos.llenaClientes();
                int bandera = 0;
                foreach (var d in lst)
                {
                    if (d.c3.ToString().Trim() == comboBox1.Text.Trim() && comboBox1.Text != " ")
                    {
                        bandera = 1;
                        gunaTextBox2.Text = d.c3.ToString().Trim();
                        gunaTextBox1.Text = d.c12.ToString().Trim();
                        calle = d.c4.ToString();
                        colonia = d.c5.ToString();
                        ciudad = d.c6.ToString();
                        Codcliente = d.c2.Trim();
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

        private List<string> validCli(string clave)//dado un alias busca un cliente para rellenarlo automaticamente
        {
          
            
           
            Servicios datos2 = new Servicios();
            var lst2 = datos2.llenaClientes();
              string cliente = "";
             string cord = "";
            List<string> lista = new List<string>();
            foreach (var d in lst2)
            {
                if (d.c2.ToString().Trim() == clave.Trim())
                {

                    lista.Add(cliente = d.c3.ToString().Trim());
                    lista.Add(cord = (d.c12.ToString().Trim()));



                }






                
            }
            return lista.ToList();
        }

        

    }
}
