using Datos.ViewModels.Coord.Clientes;
using Datos.ViewModels.Entradas;
using Datos.ViewModels.Entradas.mvlistas;
using Datos.ViewModels.Odoo;
using Negocios;
using Negocios.NGClientes;
using Negocios.Odoo;
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

        public delegate void pasar(string alias, string cliente, string cord, string calle, string colonia, string ciudad, string codigocliente,string CorreosCliente, int bandera, string parentName = "", string parentId = "");
        //public delegate void pasar2(string dato,string cliente, int bandera);
        public event pasar pasado;
        // public event pasar2 pasado2;

        List<OdooClienteDto> listaClintes = new List<OdooClienteDto>();
        string calle;
        string colonia;
        string ciudad;
        string parent;
        string parentId;
        string zip;
        string num;
        string Codcliente;
        string CorreosCliente;


        public BusquedasEnt()
        {
            InitializeComponent();
        }

        private async void BusquedasEnt_Load(object sender, EventArgs e)
        {
            comboBox1.AutoCompleteCustomSource = await aliasList();
            if (listaClintes.Any())
            {
                comboBox1.Enabled = true;
                txbClave.Enabled = true;
                txbOBusqueda.Enabled = true;
                    
            }
            if (label2.Text == "CLIENTE")
            {
                txbClave.Visible = true;
            }
        }

        private void pasarinfo()
        {
            if (label2.Text == "CLIENTE")
            { pasado(gunaTextBox2.Text,"",gunaTextBox1.Text,calle,colonia,ciudad, Codcliente, CorreosCliente, 0,parent, parentId); }
            else if (label2.Text == "ALIAS")
            { pasado(gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox1.Text,calle,colonia,ciudad,Codcliente, CorreosCliente, 1, parent, parentId); }

            else if (label2.Text == "ALIASDIREC")
            {
                pasado(gunaTextBox2.Text, gunaTextBox3.Text, zip, calle, colonia, ciudad, Codcliente, num, 1, parent, parentId);
            }

        }

        private async Task<AutoCompleteStringCollection> aliasList()
        {
            AutoCompleteStringCollection List = new AutoCompleteStringCollection();
            Servicios datos = new Servicios();
            if (label2.Text == "ALIAS")
            {
                OdooClient od = new OdooClient();
                listaClintes = await od.GetAllClients();
               
                //var lst = await datos.llenaAlias();
                foreach (var p in listaClintes)
                {
                    List.Add($"{p.Name}");

                }
                
            }
            else if (label2.Text == "CLIENTE")
            {
                OdooClient od = new OdooClient();
                listaClintes = await od.GetAllClients();
               // var lst =  await datos.llenaClientes();
                foreach (var p in listaClintes)
                {
                    List.Add($"{p.Name}");

                }
               
            }
            else if (label2.Text == "ALIASDIREC")
            {
                var lst = await datos.llenaAlias();
                foreach (var p in lst)
                {
                    List.Add(p.c1);

                }

            }

            return List;



        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            

        }






        private void gunaTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void gunaGradientTileButton4_Click(object sender, EventArgs e)
        {
            Ejecuta();


        }

        private async void Ejecuta()
        {
            try
            {
                if (label2.Text == "ALIAS")
                {
                    Servicios datos = new Servicios();
                    //var lst = await datos.llenaAlias();
               


                    string comboBoxText = comboBox1.Text.Trim();
                    int bandera = 0;

                    foreach (var d in listaClintes)
                    {
                        if (comboBoxText != " " && d.Name.ToString().Trim() == comboBoxText)
                        {
                            bandera = 1;
                            gunaTextBox2.Text = string.IsNullOrEmpty(d.Name) ? "" : d.Name;
                            gunaTextBox3.Text = d.Id.ToString();
                            gunaTextBox1.Text = d.Id.ToString();
                            CorreosCliente = d.Email;
                            Codcliente = d.Id.ToString();
                            calle = "";
                            colonia ="";
                            parent = d.ParentName;
                            parentId = d.ParentId;
                            pasarinfo();
                            this.Close();
                            break;
                        }
                    }

                    /*  Servicios datos = new Servicios();
                      var lst = await datos.llenaAlias();
                      int bandera = 0;
                      foreach (var d in lst)
                      {
                          if (d.c1.ToString().Trim() == comboBox1.Text.Trim() && comboBox1.Text != " ")
                          {
                              bandera = 1;
                              gunaTextBox2.Text = string.IsNullOrEmpty(d.c1.ToString()) ? "" : d.c1.ToString().Trim();
                              gunaTextBox3.Text = validCli(d.c3.ToString())[0].ToString();
                              gunaTextBox1.Text = validCli(d.c3.ToString())[1].ToString();
                              CorreosCliente = validCli(d.c3.ToString())[2].ToString();
                              Codcliente = validCli(d.c3.ToString())[3].ToString();
                              calle = d.c4.ToString();
                              colonia = d.c5.ToString();
                              ciudad = d.c6.ToString();
                              pasarinfo();
                              this.Dispose();
                              this.Close();

                          }*/

                

                if (bandera == 0)
                    {
                        gunaTextBox2.Text = "";
                        MessageBox.Show("Dato incorrecto, el alias: " + comboBox1.Text + ", NO se encuentra en la base de datos ");

                    }

                }
                else if (label2.Text == "ALIASDIREC")
                {
                    Servicios datos = new Servicios();
                    var lst = await datos.llenaAlias();
                    string comboBoxText = comboBox1.Text.Trim();
                    int bandera = 0;

                    foreach (var d in lst)
                    {
                        if (comboBoxText != " " && d.c1.ToString().Trim() == comboBoxText)
                        {
                            bandera = 1;
                            gunaTextBox2.Text = string.IsNullOrEmpty(d.c1.ToString()) ? "" : d.c1.ToString().Trim();
                            gunaTextBox3.Text = validCli(d.c3.ToString())[0].ToString();
                            gunaTextBox1.Text = validCli(d.c3.ToString())[1].ToString();
                            zip = d.c7;
                            num = d.c8;
                            Codcliente = validCli(d.c3.ToString())[3].ToString();
                            calle = d.c4.ToString();
                            colonia = d.c5.ToString();
                            ciudad = d.c6.ToString();
                            //parent = d.ParentName;
                            pasarinfo();
                            this.Close();
                            break;
                        }
                    }

                    /*  Servicios datos = new Servicios();
                      var lst = await datos.llenaAlias();
                      int bandera = 0;
                      foreach (var d in lst)
                      {
                          if (d.c1.ToString().Trim() == comboBox1.Text.Trim() && comboBox1.Text != " ")
                          {
                              bandera = 1;
                              gunaTextBox2.Text = string.IsNullOrEmpty(d.c1.ToString()) ? "" : d.c1.ToString().Trim();
                              gunaTextBox3.Text = validCli(d.c3.ToString())[0].ToString();
                              gunaTextBox1.Text = validCli(d.c3.ToString())[1].ToString();
                              CorreosCliente = validCli(d.c3.ToString())[2].ToString();
                              Codcliente = validCli(d.c3.ToString())[3].ToString();
                              calle = d.c4.ToString();
                              colonia = d.c5.ToString();
                              ciudad = d.c6.ToString();
                              pasarinfo();
                              this.Dispose();
                              this.Close();

                          }*/



                    if (bandera == 0)
                    {
                        gunaTextBox2.Text = "";
                        MessageBox.Show("Dato incorrecto, el alias: " + comboBox1.Text + ", NO se encuentra en la base de datos ");

                    }

                }
                else if (label2.Text == "CLIENTE")
                {
                    Servicios datos = new Servicios();
                    //var lst = await datos.llenaClientes();

                 

                    int bandera = 0;
                    foreach (var d in listaClintes)
                    {
                        if (d.Name.ToString().Trim() == comboBox1.Text.Trim() && comboBox1.Text != " ")
                        {
                            bandera = 1;
                            gunaTextBox2.Text = string.IsNullOrEmpty(d.Name.ToString()) ? "" : d.Name.ToString().Trim();
                            gunaTextBox1.Text = string.IsNullOrEmpty(d.SalesUserId) ? "" : d.SalesUserId.ToString().Trim();
                            CorreosCliente = d.Email ?? d.Email.Trim();
                            calle = d.SalesUserName;
                            colonia = d.SalesUserId;
                            ciudad = "";
                            Codcliente = d.Id.ToString();
                            parent = d.ParentName;
                            parentId = d.ParentId;
                            //CorreosCliente = d.c11;
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
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error, buscando un alias o un cliente, lo mas comun es que el cliente o alias que intentas buscar tenga algun error en su informacion, trata de revizar que no sea asi.");
            }
           
        }



        private  List<string> validCli(string clave)//dado un alias busca un cliente para rellenarlo automaticamente
        {
           Servicios datos2 = new Servicios();
            var lst2 = datos2.llenaClientesValida(clave);
              string cliente = "";
             string cord = "";
            string codclient = "";
            List<string> lista = new List<string>();
            foreach (var d in lst2)
            {
                if (d.c2.ToString().Trim() == clave.Trim())
                {
                    lista.Add(cliente = d.c3.ToString().Trim());
                    lista.Add(cord = (d.c12.ToString().Trim()));
                    lista.Add(cord = (d.c11.ToString().Trim()));
                    lista.Add(codclient = (d.c2.ToString().Trim()));
                }

   
            }
            return lista.ToList();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Ejecuta();
            }
        }

        private void BusquedasEnt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            this.Close();
        }



        private void txbClave_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Servicios datos = new Servicios();
                AccesoClientes ac = new AccesoClientes();
                string _clave = "";
                if (!String.IsNullOrWhiteSpace(txbClave.Text))
                {
                    _clave = txbClave.Text.Trim();
                }
                var dt = listaClintes.Where(x => x.Id.ToString() == _clave).Select(x=>x.Name).FirstOrDefault();
                if (dt == null)
                {
                    MessageBox.Show("Error, puede ser que el dato que tratas de buscar no exista, ya se ha retornado un valor vacio.", "Error");
                    return;
                }
                comboBox1.Text = dt.Trim();

            }


        }



        private async void txbOBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               // var listaClientes = new List<vmClienteDinamicoBusqueda>();
                Servicios datos = new Servicios();
                try
                {
                   
                    

                    if (label2.Text == "CLIENTE")
                    {
                        //listaClientes = await datos.LlenaClientesInteractivo(txbOBusqueda.Text, 1);
                  
                        dgvBusqueda.DataSource = listaClintes.Where(x => x.Name.Contains(txbOBusqueda.Text)).ToList();
                    }
                    else if (label2.Text == "ALIAS")
                    {
                        //listaClientes = await datos.LlenaClientesInteractivo(txbOBusqueda.Text, 2);
                        dgvBusqueda.DataSource = listaClintes.Where(x => x.Name.Contains(txbOBusqueda.Text));

                    }

                    else if (label2.Text == "ALIASDIREC")
                    {
                        //listaClientes = await datos.LlenaClientesInteractivo(txbOBusqueda.Text, 2);
                        dgvBusqueda.DataSource = listaClintes.Where(x => x.Name.Contains(txbOBusqueda.Text));
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    datos = null;
                   // listaClientes.Clear();
                }


               

            }
        }

        private void dgvBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (label2.Text == "ALIAS")
                {

                    if (e.RowIndex >= 0 && e.RowIndex < dgvBusqueda.Rows.Count)
                    {
                        var valorCelda = dgvBusqueda.Rows[e.RowIndex].Cells[0].Value?.ToString()?.Trim();
                        if (!string.IsNullOrEmpty(valorCelda))
                        {
                            comboBox1.Text = valorCelda;
                        }
                    }

                }
                else if (label2.Text == "CLIENTE")
                {
                    if (e.RowIndex >= 0 && e.RowIndex < dgvBusqueda.Rows.Count)
                    {
                        var valorCelda = dgvBusqueda.Rows[e.RowIndex].Cells[0].Value?.ToString()?.Trim();
                        if (!string.IsNullOrEmpty(valorCelda))
                        {
                            comboBox1.Text = valorCelda;
                        }
                    }

                }
                else if (label2.Text == "ALIASDIREC")
                {
                    if (e.RowIndex >= 0 && e.RowIndex < dgvBusqueda.Rows.Count)
                    {
                        var valorCelda = dgvBusqueda.Rows[e.RowIndex].Cells[0].Value?.ToString()?.Trim();
                        if (!string.IsNullOrEmpty(valorCelda))
                        {
                            comboBox1.Text = valorCelda;
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
