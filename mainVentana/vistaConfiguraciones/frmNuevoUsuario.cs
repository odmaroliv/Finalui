using Datos.Datosenti;
using Datos.ViewModels;
using Datos.ViewModels.Carga;
using Datos.ViewModels.Configuracion;
using Negocios;
using Negocios.NGReportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.vistaConfiguraciones
{
    public partial class frmNuevoUsuario : Form
    {
        public string sucursalGlobal = Negocios.Common.Cache.CacheLogin.sucGlobal == default ? "SD" : Negocios.Common.Cache.CacheLogin.sucGlobal;

        private string _modo = "B";
        List<KDUSUARIOS> lssGlobal = null;
        public frmNuevoUsuario()
        {
            InitializeComponent();
        }

        private void frmNuevoUsuario_Load(object sender, EventArgs e)
        {
            LlenaDatos();
        }

        private void LlenaDatos()
        {
         
        }

        private async void gunaTileButton1_Click(object sender, EventArgs e)
        {
            ngbdReportes bd = new ngbdReportes();
            lssGlobal = await bd.CargaUsuarios();
            dgvUsuarios.DataSource = lssGlobal;
        }

        private async void dgvUsuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string dato = dgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();
                ngbdReportes bd = new ngbdReportes();
                var dt = await bd.CargaUsuarioEsp(dato);
                txbUsuario.Text = dt.C1;
                txbNombre.Text = dt.C2;
                txbContrasena.Text = dt.C3;
                txbRol.Text = dt.C4;
                txbCorreo.Text = dt.C9;
                txbSucursal.Text = dt.C10;
                txbCliente.Text = dt.C12;
                txbTelefono.Text = dt.C13;
                txbMaster.Text = dt.C8;
                txbUid.Text = dt.C32;
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void gunaTileButton2_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Seguro que quieres convertir en vendedor este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Validar campos
                    if (ValidaCampos()==true)
                    {
                       
                    }
                    
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidaCampos()
        {
            if (string.IsNullOrWhiteSpace(txbUsuario.Text) ||
                        string.IsNullOrWhiteSpace(txbNombre.Text) ||
                        string.IsNullOrWhiteSpace(txbContrasena.Text) ||
                        string.IsNullOrWhiteSpace(txbRol.Text) 
                       // string.IsNullOrWhiteSpace(txbCorreo.Text)
                        
                       )
            {
                MessageBox.Show("Hay campos vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void gunaTileButton3_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Seguro que quieres guardar este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Validar campos
                    if (ValidaCampos() == true)
                    {
                        if (_modo == "N")
                        {
                            var dModelo = await CargaUsuarioEsp();
                            ngbdReportes bd = new ngbdReportes();
                            await bd.GuardarUsuario(dModelo);
                            MessageBox.Show("Guardado");
                            LimpiarCampos();
                        }
                        if (_modo == "M")
                        {
                            var dModelo = await CargaUsuarioEsp();
                            ngbdReportes bd = new ngbdReportes();
                            await bd.ActualizarUsuario(txbUsuario.Text.Trim(), dModelo);
                            MessageBox.Show("Modificado");
                            LimpiarCampos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                gbxNuser.Enabled = false;
            }
        }
        public async Task<UsuarioModelo> CargaUsuarioEsp()
        {
            try
            {
                UsuarioModelo lst = null;
                await Task.Run(() =>
                {
                    UsuarioModelo usuario = new UsuarioModelo
                    {
                        C1 = txbUsuario.Text,
                        C2 = txbNombre.Text,
                        C3 = txbContrasena.Text,
                        C4 = txbRol.Text,
                        C9 = txbCorreo.Text,
                        C10 = txbSucursal.Text,
                        C12 = txbCliente.Text,
                        C13 = txbTelefono.Text,
                        C8 = txbMaster.Text,
                        C32 = txbUid.Text,
                    };
                    lst = usuario;
                });
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LimpiarCampos()
        {
            txbUsuario.Text = string.Empty;
            txbNombre.Text = string.Empty;
            txbContrasena.Text = string.Empty;
            txbRol.Text = string.Empty;
            txbCorreo.Text = string.Empty;
            txbSucursal.Text = string.Empty;
            txbCliente.Text = string.Empty;
            txbTelefono.Text = string.Empty;
            txbMaster.Text = string.Empty;
            txbUid.Text = string.Empty;
        }


        private void gunaTileButton4_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarCampos();
                _modo = "N";
                gbxNuser.Enabled = true;
                txbUsuario.Enabled = true;
                txbUsuario.ReadOnly = false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
               
            }
            
        }

        private void gunaTileButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos() == true)
                {
                    _modo = "M";
                    gbxNuser.Enabled = true;
                }
                else
                {
                    return;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
               // gbxNuser.Enabled = false;
            }
        }

        private void txbBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txbBusqueda.Text;

                if (string.IsNullOrWhiteSpace(searchValue))
                {

                    MessageBox.Show("Por favor, introduce un valor de búsqueda válido.");
                    dgvUsuarios.DataSource = lssGlobal;
                }
                else
                {
                    if (lssGlobal == null)
                    {
                        return;
                    }
                    var filteredData = lssGlobal.Where(item =>
    (item.C1?.ToLower().Contains(searchValue) ?? false) ||
    (item.C2?.ToLower().Contains(searchValue) ?? false) ||
    (item.C9?.ToLower().Contains(searchValue) ?? false)).ToList();


                    dgvUsuarios.DataSource = filteredData;

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
