using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static Negocios.NGReportes.Arturo.NgReportesDashboard;

namespace mainVentana.vistaReportes
{
    public partial class frmVentaPequeña : Form
    {
        public frmVentaPequeña()
        {
            InitializeComponent();
        }

        private async void frmVentaPequeña_Load(object sender, EventArgs e)
        {
            await CargaOper();
           
        }

        private async Task CargaOper()
        {
            Servicios datos = new Servicios();
            var lst7 = await datos.llenaOpera();

            tipoOper.DisplayMember = "C2";
            tipoOper.ValueMember = "C1";
            tipoOper.DataSource = lst7;
        }

        private async void tipoOper_SelectedIndexChanged(object sender, EventArgs e)
        {
            await SucVal();
            await CordsValores();
            
        }
        private async Task SucVal()
        {
            try
            {
                ClreaSeries(chart1);
                string datoTipoOper = tipoOper.SelectedValue.ToString();
                ValorARnTOtal3sucs dt = new ValorARnTOtal3sucs();
                var lst = await dt.TotalArnDashboard(datoTipoOper);
                if (lst.Count <=0)
                {
                    MessageBox.Show("No hay Datos");
                    return;
                }
                int va = 0;
                var colores = new Color[] { Color.Red, Color.Blue, Color.Green };
                int indexColor = 0;
                foreach (var i in lst)
                {

                    CultureInfo cultura = new CultureInfo("es-MX");
                    decimal valor = (decimal)i.ValorTotalArn;
                    NumberFormatInfo formatoMoneda = cultura.NumberFormat;
                    formatoMoneda.CurrencySymbol = "$";
                    string valorFormateado = String.Format("{0}{1:N2}", formatoMoneda.CurrencySymbol, valor);

                    chart1.Series[va].Points.AddXY(i.sucursal, Convert.ToDecimal(i.ValorTotalArn.ToString()));

                    chart1.Series[va].Points.Last().Label = valorFormateado;

                    //chart1.Series[va].Points.Last().Label = i.ValorTotalArn.ToString("C", cultura);
                    chart1.Series[va].Points.Last().AxisLabel = i.sucursal; // Agrega el nombre de la sucursal al eje x
                    chart1.Series[va].Points.Last().Color = colores[indexColor];
                    indexColor++;
                    //va++;
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Algo salio mal: " + x.Message);
            }

        }


    

        private async Task CordsValores()
        {
            try
            {
                ClreaSeries(chart2);
                string datoTipoOper = tipoOper.SelectedValue.ToString();
                ValorARnTOtal3sucs dt = new ValorARnTOtal3sucs();
                
                //var lst = await dt.TotalArnDashboard();
                var lst = await dt.ValorXCord(datoTipoOper);
                var colores = new List<Color>();
                var random = new Random();

                foreach (var i in lst)
                {
                    int val = lst.Count; // Asignar valor correspondiente
                    while (val >= colores.Count) // Mientras el valor sea mayor que la cantidad de colores existentes
                    {
                        colores.Add(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256))); // Agregar un color aleatorio
                    }
                    var color = colores[val];
                    // Resto del código...
                }

                int va = 0;

                

                int indexColor = 0;
                chart2.ChartAreas[0].AxisX.CustomLabels.Clear();
                foreach (var i in lst)
                {
                    
                   
                    CultureInfo cultura = new CultureInfo("es-MX");
                    decimal valor = (decimal)i.ValorTotalArn;
                    NumberFormatInfo formatoMoneda = cultura.NumberFormat;
                    formatoMoneda.CurrencySymbol = "$";
                    string valorFormateado = String.Format("{0}{1:N2}", formatoMoneda.CurrencySymbol, valor);

                    chart2.Series[va].Points.AddXY(i.sucursal, Convert.ToDecimal(i.ValorTotalArn.ToString()));

                    chart2.Series[va].Points.Last().Label = valorFormateado;

                  
                    chart2.Series[va].Points.Last().Color = colores[indexColor];


                    // Agregar etiqueta para la barra actual
                    CustomLabel labelc = new CustomLabel();
                    labelc.FromPosition = indexColor + 0.9;
                    labelc.ToPosition = indexColor + 1;
                    labelc.Text = i.sucursal;
                    chart2.ChartAreas[0].AxisX.CustomLabels.Add(labelc);
                    

                    // Incrementar el índice de color
                    indexColor++;
                }

                // Personalizar la apariencia de las etiquetas
                chart2.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                chart2.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;

            }
            catch (Exception x)
            {
                MessageBox.Show("Algo salio mal: " + x.Message);
            }


        }


        private void ClreaSeries(Chart ch)
        {
            ch.Series["SD"].Points.Clear();
            ch.Series["TJ"].Points.Clear();
            ch.Series["CSL"].Points.Clear();
        }
    }
}
