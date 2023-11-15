using ClosedXML.Excel;
using Datos.ViewModels;
using Datos.ViewModels.Salidas;
using Negocios;
using Negocios.Acceso_Salida;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.Reportes.Salidas
{
    public partial class frmRepSalidas : Form
    {

        public string sucursalGlobal = Negocios.Common.Cache.CacheLogin.sucGlobal == default ? "SD" : Negocios.Common.Cache.CacheLogin.sucGlobal;
        private string sucursal = "SD";
        private int _salidaBuscada;
        private bool _isBusy =false;

        public frmRepSalidas()
        {
            InitializeComponent();
            dtFecha1.Value = DateTime.Now.AddDays(-15);
            dtFecha2.Value = DateTime.Now.AddDays(1);
            dtFecha1.MinDate = DateTime.Now.AddDays(-80);
            dtFecha1.MaxDate = DateTime.Now.AddDays(90);
            dtFecha2.MinDate = DateTime.Now.AddDays(-80);
            dtFecha2.MaxDate = DateTime.Now.AddDays(90);
        }

        private void rSd_CheckedChanged(object sender, EventArgs e)
        {
            /*
            var radioButtonMapping = new Dictionary<RadioButton, string>
                {
        { rSd, "SD" },
        { rTj, "TJ" },
        { rCa, "CSL" },

                 };

            // Encontrar el RadioButton seleccionado y obtener su valor correspondiente
            sucursal = radioButtonMapping.FirstOrDefault(r => r.Key.Checked).Value;
            */
        }

        private void gunaTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrWhiteSpace(txbBusqueda.Text))
                {
                    return;
                }
                try
                {
                    e.Handled = true;
                    _salidaBuscada = Convert.ToInt32(txbBusqueda.Text);
                    loadControl1.Visible = true;
                    buscaSalida();
                }
                catch (Exception)
                {
                    MessageBox.Show("Solo se permiten numeros");
                }
                finally
                {

                    loadControl1.Visible = false;
                }
            }
        }

       List<vmSalidaReporte> listaSalidas = new List<vmSalidaReporte>();
        private async void buscaSalida()
        {
            if (_isBusy == true)
            {
                return;
            }
            _isBusy = true;
            AccesoSalidas sld = new AccesoSalidas();
            listaSalidas.Clear();
            if (swTipo.Checked==true)
            {
               
                dgvSalidas.DataSource = await sld.BuscEntradasSalidaReporteYtreaeEntradas(_salidaBuscada.ToString("D7"),sucursal);
            }
            else
            {
                
                listaSalidas = await sld.BuscEntradasSalidaReporte(_salidaBuscada.ToString("D7"), sucursal, dtFecha1.Value, dtFecha2.Value);
                dgvSalidas.DataSource = listaSalidas;

            }
            _isBusy = false;

        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            try
            {
               
                loadControl1.Visible = true;
                buscaSalida();
            }
            catch (Exception)
            {
               
            }
            finally
            {

                loadControl1.Visible = false;
            }
         
        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            if (listaSalidas.Count ==0)
            {
                return;
            }
            if (swTipo.Checked == false)
            {
                AccesoSalidas sld = new AccesoSalidas();
                try
                {
                   // listaSalidas.Clear();
                    loadControl1.Visible = true;
                    listaSalidas = await sld.CalculaValorDeLasSalidasPorEntrada(listaSalidas, sucursal);
                    dgvSalidas.DataSource = listaSalidas;
                }
                catch (Exception)
                {

                }
                finally
                {

                    loadControl1.Visible = false;
                }
                
              
            }
        }

        private async void btnImprimir_Click(object sender, EventArgs e)
        {
            if (listaSalidas.Count == 0)
            {
                return;
            }
            await GeneraExcel();
        }
        private async Task GeneraExcel()
        {
            btnToExcel.Enabled = false;
            loadControl1.Visible = true;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Guardar archivo de Excel";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string nm = saveFileDialog.FileName;
            await Task.Run(() =>
            {



                try
                {
                    if (listaSalidas.Count() <= 0)
                    {
                        MessageBox.Show("No hay datos para Enviar");

                        return;
                    }

                    // Mostrar el diálogo para seleccionar la ubicación y el nombre del archivo


                    string fullPath = nm;
                    new frmRepSalidas().Export<vmSalidaReporte>(listaSalidas, fullPath, "salida");
                    MessageBox.Show("El documento se creó satisfactoriamente", "Creado");

                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error", "Error");

                    throw;
                }
                finally
                {
                    loadControl1.Invoke(new Action(() => { loadControl1.Visible = false; }));
                    btnToExcel.Invoke(new Action(() => { btnToExcel.Enabled = true; }));
                }
            });


        }

        public bool Export<T>(List<T> list, string file, string nombre)
        {
            bool exportado = false;
            using (XLWorkbook xlfile = new XLWorkbook())
            {
                xlfile.AddWorksheet(nombre).FirstCell().InsertTable<T>(list, false);
                //xlfile.Worksheets.Add("Reporte");
                //xlfile.Table("Reporte").ShowAutoFilter = false;// Disable AutoFilter.
                //xlfile.Table(nombre).Theme = XLTableTheme.TableStyleDark5;// Remove Theme.
                xlfile.SaveAs(file);
                exportado = true;

            }
            return exportado;
        }

        private void frmRepSalidas_Load(object sender, EventArgs e)
        {
            Task.Run(() => CargaSOrigen());

        }
        private void CargaSOrigen()
        {
            Servicios datos = new Servicios();
            var lst2 = datos.llenaSuc();


            // Utilizamos Invoke para actualizar la UI de manera segura desde un hilo secundario
            this.Invoke(new Action(() =>
            {
                cmbSucEntrada.DisplayMember = "C2";
                cmbSucEntrada.ValueMember = "C1";
                cmbSucEntrada.DataSource = lst2;
                foreach (var i in from Sucursales i in cmbSucEntrada.Items select i)
                {
                    cmbSucEntrada.SelectedValue = i.c1;
                    break;
                }

            }));

            datos = null;
        }

        private void cmbSucEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            sucursal = cmbSucEntrada.SelectedValue?.ToString();

        }
    }
}
