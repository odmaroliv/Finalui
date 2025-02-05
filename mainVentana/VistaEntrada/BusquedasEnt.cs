using Datos.ViewModels;
using Datos.ViewModels.Coord.Clientes;
using Datos.ViewModels.Entradas;
using Datos.ViewModels.Entradas.mvlistas;
using Datos.ViewModels.Odoo;
using DocumentFormat.OpenXml.Drawing;
using Negocios;
using Negocios.NGClientes;
using Negocios.Odoo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaEntrada
{
    public partial class BusquedasEnt : Form
    {

        public delegate void pasar(string alias, string cliente, string cord, string calle, string colonia, string ciudad, string codigocliente,string CorreosCliente, int bandera,string codigoPostal, string parentName = "", string parentId = "");
        //public delegate void pasar2(string dato,string cliente, int bandera);
        public event pasar pasado;
        // public event pasar2 pasado2;
        private bool _isSearching = false;
        private bool _isUserTyping = false;
        private int _lastCursorPosition = 0;
        private bool _isFormReady = false;

        private bool _disposed = false;
        private readonly Timer _searchTimer;

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
            _searchTimer = new Timer { Interval = 300 };
            InitializeControls();

        }

       

        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (!_isUserTyping)
            {
                _lastCursorPosition = comboBox1.SelectionStart;
                _isUserTyping = true;
                _searchTimer.Stop();
                _searchTimer.Start();
            }
        }

        private void InitializeControls()
        {
            // Configuración básica del ComboBox
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox1.AutoCompleteMode = AutoCompleteMode.None;
            comboBox1.AutoCompleteSource = AutoCompleteSource.None;

            // Configurar timer para búsqueda
            _searchTimer.Tick += async (s, e) =>
            {
                _searchTimer.Stop();
                await SearchClients();
            };

            // Eventos del ComboBox
            comboBox1.TextChanged += ComboBox1_TextChanged;
   
            comboBox1.SelectionChangeCommitted += ComboBox1_SelectionChangeCommitted;
            comboBox1.LostFocus += ComboBox1_LostFocus;
            comboBox1.DropDown += ComboBox1_DropDown;
          

        }

        private async Task SearchClients()
        {
            if (_isSearching) return;

            try
            {
                _isSearching = true;
                string searchText = comboBox1.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    comboBox1.Items.Clear();
                    return;
                }

                var odoo = new OdooClient();
                var clients = await odoo.SearchClients(searchText);

                if (clients != null && clients.Any())
                {
                    comboBox1.BeginUpdate();
                    string currentText = comboBox1.Text;
                    int cursorPosition = comboBox1.SelectionStart;

                    try
                    {
                        comboBox1.Items.Clear();
                        foreach (var client in clients)
                        {
                            comboBox1.Items.Add(new ClienteComboItem
                            {
                                DisplayText = $"{client.Name} [{client.Id}]",
                                Cliente = client
                            });
                        }
                    }
                    finally
                    {
                        comboBox1.EndUpdate();
                    }

                    comboBox1.Text = currentText;
                    comboBox1.SelectionStart = cursorPosition;
                    comboBox1.SelectionLength = 0;

                    if (!comboBox1.DroppedDown)
                    {
                        comboBox1.DroppedDown = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar clientes: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isUserTyping = false;
                _isSearching = false;
            }
        }

        private void ValidateAndAccept(OdooClienteDto cliente = null)
        {
            try
            {
                if (cliente == null && comboBox1.SelectedItem is ClienteComboItem selectedItem)
                {
                    cliente = selectedItem.Cliente;
                }

                if (cliente != null)
                {
                    switch (label2.Text)
                    {
                        case "ALIAS":
                            gunaTextBox2.Text = cliente.Name ?? "";
                            gunaTextBox3.Text = cliente.Id.ToString();
                            gunaTextBox1.Text = cliente.Id.ToString();
                            CorreosCliente = cliente.Email;
                            Codcliente = cliente.Id.ToString();
                            calle = "";
                            colonia = "";
                            parent = cliente.ParentName;
                            parentId = cliente.ParentId;
                            zip = cliente.Zip;
                            pasarinfo();
                            this.Close();
                            break;

                        case "CLIENTE":
                            gunaTextBox2.Text = cliente.Name ?? "";
                            gunaTextBox1.Text = cliente.SalesUserId ?? "";
                            CorreosCliente = cliente.Email;
                            calle = cliente.SalesUserName;
                            colonia = cliente.SalesUserId;
                            ciudad = "";
                            Codcliente = cliente.Id.ToString();
                            parent = cliente.ParentName;
                            parentId = cliente.ParentId;
                            zip = cliente.Zip;
                            pasarinfo();
                            this.Close();
                            break;

                        case "ALIASDIREC":
                            gunaTextBox2.Text = cliente.Name ?? "";
                            gunaTextBox3.Text = cliente.Id.ToString();
                            gunaTextBox1.Text = cliente.Id.ToString();
                            num = cliente.Phone ?? "";
                            Codcliente = cliente.Id.ToString();
                            calle = "";
                            colonia = "";
                            ciudad = "";
                            pasarinfo();
                            this.Close();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show($"Cliente no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la selección: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is ClienteComboItem selectedItem)
            {
                ValidateAndAccept(selectedItem.Cliente);
            }
        }
        private void ComboBox1_DropDown(object sender, EventArgs e)
        {
            _lastCursorPosition = comboBox1.SelectionStart;
        }

        private void ComboBox1_LostFocus(object sender, EventArgs e)
        {
            _isUserTyping = false;
        }

        //-------------------

        private  void BusquedasEnt_Load(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;

            comboBox1.Enabled = true;
               txbClave.Enabled = true;
                
            //comboBox1.AutoCompleteCustomSource = await aliasList();
            //if (listaClintes.Any())
            //{
            //    comboBox1.Enabled = true;
            //    txbClave.Enabled = true;
            //    txbOBusqueda.Enabled = true;

            //}
            //if (label2.Text == "CLIENTE")
            //{
            //    txbClave.Visible = true;
            //}
        }

        private void pasarinfo()
        {
            if (label2.Text == "CLIENTE")
            { pasado(gunaTextBox2.Text,"",gunaTextBox1.Text,calle,colonia,ciudad, Codcliente, CorreosCliente, 0,zip,parent, parentId); }
            else if (label2.Text == "ALIAS")
            { pasado(gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox1.Text,calle,colonia,ciudad,Codcliente, CorreosCliente, 1,zip, parent, parentId); }

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
                // Obtener el cliente seleccionado del ComboBox
                var selectedItem = comboBox1.SelectedItem as ClienteComboItem;
                OdooClienteDto cliente = null;

                if (selectedItem != null)
                {
                    cliente = selectedItem.Cliente;
                }
                else
                {
                    // Si no hay selección, intentar extraer el ID del texto
                    string searchText = comboBox1.Text.Trim();
                    // Buscar el ID entre corchetes [xxxx]
                    var match = System.Text.RegularExpressions.Regex.Match(searchText, @"\[(\d+)\]");
                    if (match.Success)
                    {
                        string idStr = match.Groups[1].Value;
                        var odoo = new OdooClient();
                        var clients = await odoo.SearchClients(idStr);
                        cliente = clients.FirstOrDefault();
                    }
                    else
                    {
                        // Si no hay ID entre corchetes, intentar buscar por nombre completo
                        var odoo = new OdooClient();
                        var clients = await odoo.SearchClients(searchText);
                        cliente = clients.FirstOrDefault();
                    }
                }

                if (cliente != null)
                {
                    if (label2.Text == "ALIAS")
                    {
                        gunaTextBox2.Text = string.IsNullOrEmpty(cliente.Name) ? "" : cliente.Name;
                        gunaTextBox3.Text = cliente.Id.ToString();
                        gunaTextBox1.Text = cliente.Id.ToString();
                        CorreosCliente = cliente.Email;
                        Codcliente = cliente.Id.ToString();
                        calle = "";
                        colonia = "";
                        parent = cliente.ParentName;
                        parentId = cliente.ParentId;
                        zip = cliente.Zip;
                        pasarinfo();
                        this.Close();
                    }
                    else if (label2.Text == "CLIENTE")
                    {
                        gunaTextBox2.Text = string.IsNullOrEmpty(cliente.Name) ? "" : cliente.Name.Trim();
                        gunaTextBox1.Text = string.IsNullOrEmpty(cliente.SalesUserId) ? "" : cliente.SalesUserId.Trim();
                        CorreosCliente = cliente.Email ?? cliente.Email?.Trim();
                        calle = cliente.SalesUserName;
                        colonia = cliente.SalesUserId;
                        ciudad = "";
                        Codcliente = cliente.Id.ToString();
                        parent = cliente.ParentName;
                        parentId = cliente.ParentId;
                        zip = cliente.Zip;
                        pasarinfo();
                        this.Close();
                    }
                    else if (label2.Text == "ALIASDIREC")
                    {
                        // Mantener la lógica original para ALIASDIREC ya que requiere datos adicionales
                        Servicios datos = new Servicios();
                        var lst = await datos.llenaAlias();
                        var aliasMatch = lst.FirstOrDefault(d => d.c1.ToString().Trim() == cliente.Name.Trim());

                        if (aliasMatch != null)
                        {
                            gunaTextBox2.Text = string.IsNullOrEmpty(aliasMatch.c1.ToString()) ? "" : aliasMatch.c1.ToString().Trim();
                            gunaTextBox3.Text = validCli(aliasMatch.c3.ToString())[0].ToString();
                            gunaTextBox1.Text = validCli(aliasMatch.c3.ToString())[1].ToString();
                            num = aliasMatch.c8;
                            Codcliente = validCli(aliasMatch.c3.ToString())[3].ToString();
                            calle = aliasMatch.c4.ToString();
                            colonia = aliasMatch.c5.ToString();
                            ciudad = aliasMatch.c6.ToString();
                            pasarinfo();
                            this.Close();
                        }
                        else
                        {
                            gunaTextBox2.Text = "";
                            MessageBox.Show("Dato incorrecto, el alias: " + comboBox1.Text + ", NO se encuentra en la base de datos ");
                        }
                    }
                }
                else
                {
                    gunaTextBox2.Text = "";
                    MessageBox.Show($"Dato incorrecto, el {label2.Text.ToLower()}: {comboBox1.Text}, NO se encuentra en la base de datos ");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error buscando un alias o un cliente. Lo más común es que el cliente o alias que intentas buscar tenga algún error en su información.");
            }
        }

        private void HandleClientSelection(OdooClienteDto cliente)
        {
            if (cliente == null) return;

            try
            {
                switch (label2.Text)
                {
                    case "ALIAS":
                        gunaTextBox2.Text = cliente.Name ?? "";
                        gunaTextBox3.Text = cliente.Id.ToString();
                        gunaTextBox1.Text = cliente.Id.ToString();
                        CorreosCliente = cliente.Email;
                        Codcliente = cliente.Id.ToString();
                        calle = "";
                        colonia = "";
                        parent = cliente.ParentName;
                        parentId = cliente.ParentId;
                        zip = cliente.Zip;
                        pasarinfo();
                        this.Close();
                        break;

                    case "CLIENTE":
                        gunaTextBox2.Text = string.IsNullOrEmpty(cliente.Name) ? "" : cliente.Name.Trim();
                        gunaTextBox1.Text = string.IsNullOrEmpty(cliente.SalesUserId) ? "" : cliente.SalesUserId.Trim();
                        CorreosCliente = cliente.Email?.Trim() ?? "";
                        calle = cliente.SalesUserName;
                        colonia = cliente.SalesUserId;
                        ciudad = "";
                        Codcliente = cliente.Id.ToString();
                        parent = cliente.ParentName;
                        parentId = cliente.ParentId;
                        zip = cliente.Zip;
                        pasarinfo();
                        this.Close();
                        break;

                    case "ALIASDIREC":
                        gunaTextBox2.Text = cliente.Name ?? "";
                        gunaTextBox3.Text = cliente.Id.ToString();
                        gunaTextBox1.Text = cliente.Id.ToString();
                        num = cliente.Phone ?? "";
                        Codcliente = cliente.Id.ToString();
                        calle = "";
                        colonia = "";
                        ciudad = "";
                        pasarinfo();
                        this.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la selección: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(comboBox1.Text))
                {
                    comboBox1.SelectionStart = Math.Min(_lastCursorPosition, comboBox1.Text.Length);
                    comboBox1.SelectionLength = 0;
                }
            }
            catch (ArgumentOutOfRangeException) 
            {
                // Ignora el error sin hacer nada
            }
            catch (Exception)
            {
                
                throw; 
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
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    ValidateAndAccept();
                    break;

                case Keys.Up:
                case Keys.Down:
                    if (!comboBox1.DroppedDown)
                    {
                        comboBox1.DroppedDown = true;
                    }
                    break;
            }
        }

        private void BusquedasEnt_FormClosed(object sender, FormClosedEventArgs e)

        {
            // Limpiar recursos
            if (_searchTimer != null)
            {
                _searchTimer.Stop();
                _searchTimer.Dispose();
            }
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
                  
                        dgvBusqueda.DataSource = listaClintes.Where(x => x.Name.ToUpper().Contains(txbOBusqueda.Text.ToUpper())).ToList();
                    }
                    else if (label2.Text == "ALIAS")
                    {
                        //listaClientes = await datos.LlenaClientesInteractivo(txbOBusqueda.Text, 2);
                        dgvBusqueda.DataSource = listaClintes.Where(x => x.Name.ToUpper().Contains(txbOBusqueda.Text.ToUpper()));

                    }

                    else if (label2.Text == "ALIASDIREC")
                    {
                        //listaClientes = await datos.LlenaClientesInteractivo(txbOBusqueda.Text, 2);
                        dgvBusqueda.DataSource = listaClintes.Where(x => x.Name.ToUpper().Contains(txbOBusqueda.Text.ToUpper()));
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
