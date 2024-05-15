using Datos.ViewModels.Carga;
using Datos.ViewModels.Coord.Clientes;
using mainVentana.VistaEntrada;
using Negocios.NGClientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaInicioCoordinadores
{
    public partial class frmAliasMain : Form
    {

        List<vmAliasInfo> lssGlobal = null;
        private bool _isBussy;

        public frmAliasMain()
        {
            InitializeComponent();
        }

        private void dungeonButtonRight2_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(txbClaveAlias.Text))
            {
                NoMoverinfo(txbClaveAlias.Text.Trim());
            }
            else
            {
                using (VistaEntrada.BusquedasEnt buscador = new BusquedasEnt())
                {
                    buscador.label2.Text = "CLIENTE";
                    buscador.pasado += new BusquedasEnt.pasar(moverinfo);
                    buscador.ShowDialog();
                    buscador.pasado -= new BusquedasEnt.pasar(moverinfo);
                }
            }
            lblEstatus.Text = "Consulta/Modifica";
        }
        public async void NoMoverinfo(string dato7)
        {
            dtgAlias.DataSource = null;
            try
            {

                AccesoClientes ac = new AccesoClientes();
               lssGlobal = ac.BuscaAliasenCliente(dato7);
                dtgAlias.DataSource = lssGlobal;
            }
            catch (Exception)
            {

                throw;
            }


        }

        
        public async void moverinfo(string dato, string dato2, string dato3, string dato4, string dato5, string dato6, string dato7, string correoCliente, int bandera, string parentName = "", string parentId = "") //cambia los datos de los textbox alias y clientes, la bandera dependera de la manera en la que se haya abierto el frm buscar, 0 clientes 1 alias, ADEMAS tambien sirve para cambiar el campo de cord
        {
            if (_isBussy) 
                return;
            _isBussy = true;
            dtgAlias.DataSource = null;
            try
            {
                string coreoClientes = correoCliente;
                if (bandera == 0) //clientes
                {
                    AccesoClientes ac = new AccesoClientes();
                   lssGlobal = ac.BuscaAliasenCliente(dato7);
                    dtgAlias.DataSource = lssGlobal;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally { _isBussy = false; }
            
        }

        private void CargaInfoEspecial(string alias)
        {
            try
            {

                AccesoClientes ac = new AccesoClientes();
                var dt = ac.BuscaInfoAlias(alias);
               
                txbNombre.Text = dt.C1;
                txbDireccion.Text = dt.C4;
                txbColonia.Text = dt.C5;
                txbPoblacion.Text = dt.C6;
                txbZip.Text = dt.C7;
                txbTel.Text = dt.C8;
                txbLatitud.Text = dt.C10;
                txbLongitud.Text = dt.C11;
                //txbEmail.Text = dt.C11;


            }
            catch (Exception)
            {

                throw;
            }

        }

        private void frmAliasMain_Load(object sender, EventArgs e)
        {
            NoMoverinfo(txbClaveAlias.Text.Trim());
            if (Negocios.Common.Cache.CacheLogin.rol=="ADMIN")
            {
                btnBuscar.Enabled = true;
            }
        }

        private void dtgAlias_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgAlias.Rows.Count > 0)
            {
                /*string nombrecolumna = gunaDataGridView1.Columns[e.ColumnIndex].HeaderText;
                if (nombrecolumna.Trim() != "Entrada")
                {
                    MessageBox.Show("Tienes que seleccionar la entrada.");
                    return;
                }*/

                string id = dtgAlias.Rows[e.RowIndex].Cells[0].Value.ToString();
               
                CargaInfoEspecial(id);
            }
            else
            {
                MessageBox.Show("No hay datos para buscar.");
            }
        }

        private void dungeonButtonRight1_Click(object sender, EventArgs e)
        {
            Limpia();
            txbNombre.ReadOnly = false;
            lblEstatus.Text = "Alta";
        }
        private void Limpia()
        {
            txbNombre.Text = default;
            txbDireccion.Text = default;
            txbColonia.Text = default;
            txbPoblacion.Text = default;
            txbZip.Text = default;
            txbTel.Text = default;
            txbLatitud.Text = default;
            txbLongitud.Text = default;
        }
        private int Vld()
        {
            int bnd = 0;
            if (String.IsNullOrWhiteSpace(txbNombre.Text) || String.IsNullOrWhiteSpace(txbLatitud.Text) || String.IsNullOrWhiteSpace(txbLongitud.Text))
            {
                bnd = 1;
            }
            return bnd;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            var bnd = Vld();
            if (bnd == 1)
            {
                MessageBox.Show("Error, la validacion no ha sido satisfactoria", "Revisar datos");
                return;
            }
            try
            {
                AltaClientes ac = new AltaClientes();
                if (lblEstatus.Text == "Alta")
                {

                    ac.CreaAlias(txbNombre.Text.Trim(),"",txbClaveAlias.Text.Trim(),txbDireccion.Text,txbColonia.Text,txbPoblacion.Text,txbZip.Text,txbTel.Text,txbLatitud.Text.Trim(),txbLongitud.Text.Trim());


                    MessageBox.Show("Alta correcta");
                }
                else
                {
                    ac.ModificaAlias(txbNombre.Text.Trim(), "", txbClaveAlias.Text.Trim(), txbDireccion.Text, txbColonia.Text, txbPoblacion.Text, txbZip.Text, txbTel.Text, txbLatitud.Text.Trim(), txbLongitud.Text.Trim());


                    MessageBox.Show("Modificación correcta");
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error, datos no gudardados");
                // throw;
            }
            Limpia();
            txbNombre.ReadOnly = true;
        }

        private void txbNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txbNombre.Text))
            {
                return;
            }

            



            if (e.KeyCode == Keys.Delete && e.Shift)
            {
                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar el Alias?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    AccesoClientes ac = new AccesoClientes();
                    var dt = ac.BorrarAliasPorCodigo(txbNombre.Text.Trim(), txbClaveAlias.Text.Trim());
                    if (dt == true)
                    {
                        MessageBox.Show("Borrado");
                        
                    }
                    else
                    {
                        MessageBox.Show("No se elimino");
                    }
                    this.Close();   
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Si el usuario decide no eliminar, puedes manejar esa situación aquí
                }
            }


        }

        private void txbBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txbBusqueda.Text.Trim().ToLower(); // Convertir a minúsculas y eliminar espacios

                if (string.IsNullOrWhiteSpace(searchValue))
                {
                    MessageBox.Show("Por favor, introduce un valor de búsqueda válido.");
                    dtgAlias.DataSource = lssGlobal;
                }
                else
                {
                    if (lssGlobal == null)
                    {
                        return;
                    }
                    var filteredData = lssGlobal.Where(item =>
                        (item.C1?.ToLower().Contains(searchValue) ?? false)).ToList(); // Comparación sin tener en cuenta mayúsculas/minúsculas

                    dtgAlias.DataSource = filteredData;

                    if (!filteredData.Any())
                    {
                        MessageBox.Show("No se encontraron resultados para tu búsqueda.");
                    }
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

       
    }
}
