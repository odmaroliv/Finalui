using Datos.ViewModels.Entradas;
using Guna.UI.WinForms;
using Negocios;
using Negocios.Odoo;
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

    // public event pasar2 pasado2;


    public partial class vistaBajaAgregaEntrada : Form
    {

        public delegate void pasar(string total);

        public event pasar pasado;
        private readonly OdooClient _odooClient;
        private List<vmEtiquetasInfo> datosLista;
        public string suOrigen;
        public string entrada;

        private string _etiquetaSeleccionada = "";
        private string _descripcionSeleccionada = "";



        public vistaBajaAgregaEntrada()
        {
            InitializeComponent();
            _odooClient = new OdooClient();
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            gbxAgrega.Enabled = false;
            gbxBorra.Enabled = true;
        }

        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            gbxAgrega.Enabled = true;
            gbxBorra.Enabled = false;
        }

        private void vistaBajaAgregaEntrada_Load(object sender, EventArgs e)
        {
            if (entrada == "00" || entrada == default)
            {
                lblEntrada.Text = "Error";
                return;
            }


            string _rol = Negocios.Common.Cache.CacheLogin.rol;
            if (_rol == "ADMIN" || _rol == "JALMA")
            {
                AddOrDeletePanel.Enabled = true;

            }
            else
            {
                AddOrDeletePanel.Enabled = false;
            }

            lblEntrada.Text = entrada;
            LlamaDatosEtiqueta();
        }

        private async void LlamaDatosEtiqueta()
        {
            Servicios get = new Servicios();
            try
            {
                datosLista = await get.CargaInfoEtiquetas(entrada, suOrigen);
                dtgEtiquetas.DataSource = datosLista;
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error, contacta al administrador.");
            }
            txbTotalEt.Text = dtgEtiquetas.Rows.Count == 0 ? "" : dtgEtiquetas.Rows.Count.ToString();
        }


        private async Task eliminaDatos()
        {

            int index = 1;
            long nFilas = nBorra.Value;
            if (nFilas == 0)
            {
                return;
            }

            List<string> listaNueva = new List<string>();
            foreach (var item in datosLista)
            {
                if (index <= nFilas)
                {
                    listaNueva.Add(item.Etiqueta);
                }
                else
                {
                    break;
                }
                index++;
            }
            try
            {
                BajaDB baja = new BajaDB();
                await baja.BorraEtiquitas(listaNueva);
                string nuevoTotal = (Convert.ToInt32(txbTotalEt.Text) - nFilas).ToString();

                await baja.ActualizaBultos(entrada, suOrigen, nuevoTotal);

                MessageBox.Show("Se han borrado las " + nFilas + " etiquetas satisfactoriamente \nIMPORTANTE \nVuelve a buscar la entrada para observar los resultados y poder imprimir", "successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error y no se han podido borrar las etiquetas");
                throw;
            }


            listaNueva.Clear();
        }
        private async Task agregaDatos()
        {

            MessageBox.Show("No cierre la ventana hasta que aparezca el mensaje de Exito o de Error\nDa click para iniciar el proceso");
            long nFilas = nAgrega.Value;
            if (nFilas == 0)
            {
                return;
            }

            List<string> listaNueva = new List<string>();
            foreach (var item in datosLista)
            {

                listaNueva.Add(item.Etiqueta);

            }




            try
            {
                int cantidadBultos = datosLista.Count + Convert.ToInt32(nFilas);
                BajaDB baja = new BajaDB();
                OdooClient od = new OdooClient();
                bool estus = await baja.BorraEtiquitas(listaNueva);
                if (estus == true)
                {
                    pasado(cantidadBultos.ToString());
                    await baja.ActualizaBultos(entrada, suOrigen, cantidadBultos.ToString());

                    MessageBox.Show("Se han agregado las " + nFilas + " etiquetas satisfactoriamente \nIMPORTANTE \nVuelve a buscar la entrada para observar los resultados y poder imprimir", "successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error y no se han podido agregar las etiquetas");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error y no se han podido agregar las etiquetas");
            }


        }

        private async void btnBorra_Click(object sender, EventArgs e)
        {
            await eliminaDatos();
            this.Dispose();
            this.Close();
        }

        private async void btnAgrega_Click(object sender, EventArgs e)
        {
            await agregaDatos();
            this.Dispose();
            this.Close();
        }



        private void dtgEtiquetas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgEtiquetas.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dtgEtiquetas.SelectedCells[1].RowIndex;
                    DataGridViewRow selectedRow = dtgEtiquetas.Rows[selectedrowindex];
                    _etiquetaSeleccionada = Convert.ToString(selectedRow?.Cells[1]?.Value ?? "").Trim();
                    _descripcionSeleccionada = Convert.ToString(selectedRow?.Cells[3]?.Value ?? "").Trim();
                    txbEntiquetaSeleccionada.Text = _etiquetaSeleccionada;
                    txbDescripcion.Text = _descripcionSeleccionada;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("El valor no puede ser 0 o un espacio vacio, esto esta apunto de generar un error interno, manten asi la apilacion, no la cierres y pide soporte de Sistemas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void buttonSaveDesc_Click(object sender, EventArgs e)
        {
            CalculaPesoVolumetrico();
        }


        private void CalculaPesoVolumetrico()
        {
            try
            {
                // Leer y validar los valores de los TextBox
                if (!decimal.TryParse(txbAnchura.Text, out decimal ancho) || ancho <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un valor numérico positivo válido para Ancho.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txbAltura.Text, out decimal alto) || alto <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un valor numérico positivo válido para Alto.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(tbxLongitud.Text, out decimal largo) || largo <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un valor numérico positivo válido para Largo.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txbPesoReal.Text, out decimal pesoReal) || pesoReal < 0)
                {
                    MessageBox.Show("Por favor, ingrese un valor numérico positivo válido para Peso Real.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Definir el factor volumétrico para libras
                const decimal factorVolumetrico = 166m;

                // Definir la altura de caja de tráiler estándar en pulgadas (por ejemplo, 100 pulgadas)
                const decimal alturaCajaTrailer = 100m;

                // Calcular el peso volumétrico
                decimal pesoVolumetrico = 0m;

                // Verificar si el ítem es estibable
                if (cbxEstibable.Checked)
                {
                    // Calcular el peso volumétrico en libras
                    pesoVolumetrico = (ancho * alto * largo) / factorVolumetrico;
                }
                else
                {
                    // Si no es estibable, usa la altura completa del tráiler para el cálculo
                    pesoVolumetrico = (ancho * alturaCajaTrailer * largo) / factorVolumetrico;
                }

                // Determinar el peso a usar: el mayor entre peso real y peso volumétrico
                decimal pesoFinal = Math.Max(pesoReal, pesoVolumetrico);

                // Establecer el valor en el TextBox de Volumetrico
                txbVolumetrico.Text = pesoFinal.ToString("F2"); // Formato con 2 decimales
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
