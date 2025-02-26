using Datos.Datosenti;
using Datos.ViewModels;
using Datos.ViewModels.Inventario;
using mainVentana.reportes.vmreportes;
using Negocios;
using Negocios.accesoInventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.vistaInventario
{
    public partial class frmInventarioMain : Form
    {

        private string _sucursalInventario = "";
        private int _folio = -1;
        private bool _isBusy = false;
        private HashSet<vmEntradaInventario> _inventarioSet = new HashSet<vmEntradaInventario>();
        private ngAccesoInventario repository;
        private List<vmFolioPasado> _foliosAbiertos = new List<vmFolioPasado>();
        private Queue<vmEntradaInventario> colaEtiquetas = new Queue<vmEntradaInventario>();
        //private int _cantidad;

        private int _cantidad
        {
            
            get { return _inventarioSet.Count; }
           // set { _cantidad = value; }
        }

        public frmInventarioMain()
        {
            repository = new ngAccesoInventario();
            InitializeComponent();
        }

        private void frmInventarioMain_Load(object sender, EventArgs e)
        {
            CargaSOrigen();
            dgvEscaneados.DataSource = _inventarioSet;
        }
        private void CargaFoliosAnteriores()
        {
            _foliosAbiertos = repository.ObtieneFoliosAbiertos(sucursal: _sucursalInventario);
            dgvFoliosAbiertos.DataSource = _foliosAbiertos;
        }
        private async void CargaSOrigen()
        {
            Servicios datos = new Servicios();
            var lst2 = await datos.llenaSuc();

            this.Invoke(new Action(() =>
            {
                cmbSucOrigen.DisplayMember = "C2";
                cmbSucOrigen.ValueMember = "C1";
                cmbSucOrigen.DataSource = lst2;
                foreach (var i in from Sucursales i in cmbSucOrigen.Items select i)
                {
                    cmbSucOrigen.SelectedValue = i.c1;
                    break;
                }

            }));

            datos = null;
        }

        private void cmbSucOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            _sucursalInventario = cmbSucOrigen.SelectedValue?.ToString().Trim();
            lblSucursal.Text = cmbSucOrigen.Text;
            CargaFoliosAnteriores();
        }

        private void btnScanini_Click(object sender, EventArgs e)
        {
            if (_isBusy)
            {
                //MessageBox.Show("Hay un trabajo en proceso", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidaDatosParaIniciar())
                return;
           // dgvFoliosAbiertos.Enabled = false;
            ObtieneFolio();
            DesahabilitarControles();
            txbEscaneo.Focus();




        }
        private void ObtieneFolio()
        {
            var oInventario = new vmInventario
            {
                IDBodega = cmbSucOrigen.SelectedValue?.ToString().Trim(),
                SeccionInventario = txtSeccion.Text ?? "",
                TipoInventario = cmbTipoInventario.SelectedValue?.ToString().Trim(),
                Comentario = txbComentario.Text,
                //IDEstado = 1
            };

            _folio = repository.GeneraFolioInventario(oInventario);
            if (_folio >= 10)
            {
                lblFolio.Text = _folio.ToString();
                txbEscaneo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ya hay 3 inventarios abiertos en esta sucursal\n");

            }
        }
        private bool ValidaDatosParaIniciar()
        {
            if (_folio >= 10)
            {
                MessageBox.Show("Ya se ha cargado un folio");
                return false;
            }
            Action Error = () => MessageBox.Show("Este campo es obligatorio");
            if (String.IsNullOrWhiteSpace(cmbTipoInventario.Text))
            {
                cmbTipoInventario.Focus();
                Error();
                return false;
            }
            if (String.IsNullOrWhiteSpace(_sucursalInventario))
            {
                cmbSucOrigen.Focus();
                Error();
                return false;
            }
            return true;
        }

        private void frmInventarioMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            if (MessageBox.Show("Mantener activa esta ventana", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                e.Cancel = true;            
                return;
            }
            if (_isBusy)
            {
                MessageBox.Show("Hay un trabajo en proceso");
                return;
            }
            repository = null;


        }

        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            if (_isBusy)
            {
                MessageBox.Show("Hay un trabajo en proceso", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_folio < 10)
            {
                MessageBox.Show("No ha cargado un folio", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!_inventarioSet.Any())
            {
                MessageBox.Show("No se ha escaneado nada","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show($"Sucursal: {_sucursalInventario},\nNumero de inventario: {_folio.ToString()},\nCantidad: {_cantidad} ", "Validar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }
            var oInventario = new vmInventario
            {
                IDInventario = _folio,
                CantidadContada = (int)(_inventarioSet?.Count),
                Comentario = txbComentario.Text,
            };

            bool resultado = repository.CierraInventario(oInventario);
            if (resultado)
            {
                MessageBox.Show("Inventario cerrado satisfactoriamente");
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private async void txbEscaneo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;
          
            try
            {
                string itemScaneado = txbEscaneo.Text?.Trim()?.ToUpper()?.Replace("'", "-") ?? "";
                txbEscaneo.Text = "";
                if (String.IsNullOrWhiteSpace(itemScaneado))
                {
                    return;
                }
                var oItemScaneado = await  ObtieneInfoEtiquetaAsync(itemScaneado);
                /*var oItemScaneado = new vmEntradaInventario
                {
                    Etiqueta = itemScaneado,
                    Timestamp = DateTime.Now,
                    Folio = _folio
                };*/

                var isAgregated = _inventarioSet.Add(oItemScaneado);
                if (isAgregated)
                {
                    colaEtiquetas.Enqueue(oItemScaneado);
                    await ProcesadoColaEtiquetasAsync();
                }

                var listaDatos = _inventarioSet.OrderByDescending(d => d.Timestamp).ToList();
                dgvEscaneados.DataSource = listaDatos;
                lblConteo.Text = _cantidad.ToString();
            }
            catch (Exception)
            {

                throw;
            }


        }

        private async Task ProcesadoColaEtiquetasAsync()
        {
            while (colaEtiquetas.Count > 0)
            {
                var etiqueta = colaEtiquetas.Dequeue();

                var agregada = await Task.Run(() => CargaEtiquetasEnInventario(etiqueta));
                if (!agregada)
                {
                    _inventarioSet.Remove(etiqueta);
                }
            }
        }
        private async Task<vmEntradaInventario> ObtieneInfoEtiquetaAsync(string etiqueta)
        {
                return await Task.Run(() => repository.ObtieneEtiquetaInfo(etiqueta, _folio));
        }

        private bool CargaEtiquetasEnInventario(vmEntradaInventario etiqueta)
        {
            _isBusy = true;
            try
            {
                bool resultado = repository.CargaFolioEnEtiqueta(etiqueta,_sucursalInventario);
                return resultado;
            }
            catch (Exception ex)
            {
                Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "Error al cargar un folio de iunventario a una etiqueta");
                return false;
            }
            finally
            {
                _isBusy = false;
            }
        }

        private void CalculaFinal(vmEntradaInventario etiqueta)
        {
            //if
        }

        private async void dgvFoliosAbiertos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_isBusy)
            {
                return;
            }
            _isBusy = true;
            pgbar.Visible = true;
            try
            {
                var selectedCell = dgvFoliosAbiertos.SelectedCells[0];
                string folioSeleccionado = selectedCell.Value?.ToString().Trim();
                _folio = Convert.ToInt32(folioSeleccionado);
                lblFolio.Text = _folio.ToString();
                DesahabilitarControles();
                await ObtenerEntradasPorFolio();
                lblConteo.Text = _cantidad.ToString();
                txbEscaneo.Enabled = true;
                txbEscaneo.Focus();
            }
            catch (Exception)
            {

                throw;
            }
            finally { _isBusy = false; pgbar.Visible = false; }    
        }
        private async Task ObtenerEntradasPorFolio()
        {
             var  resultado =await  Task.Run(() => repository.ObtieneEntradasPorFolio(_folio));
            _inventarioSet.UnionWith(resultado);
            dgvEscaneados.DataSource = _inventarioSet.ToList();
        }

        private void DesahabilitarControles()
        {
            dgvFoliosAbiertos.Enabled = false;
            btnScanini.Enabled = false;
            gbGeneral.Enabled = false;
        }

        private void txbEscaneo_Leave(object sender, EventArgs e)
        {
            if (MessageBox.Show("para dejar de scannear dá click en CANCELAR", "Cuidado", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                txbEscaneo.Focus();
            }
        }
    }
}
