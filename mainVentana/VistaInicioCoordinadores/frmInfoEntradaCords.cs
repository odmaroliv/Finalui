using Datos.ViewModels.Carga;
using Datos.ViewModels.Servicios;
using Negocios;
using Newtonsoft.Json;
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
    public partial class frmInfoEntradaCords : Form
    {
        public frmInfoEntradaCords()
        {
            InitializeComponent();

        }

        


        private void btnEntrada_Click(object sender, EventArgs e)
        {

            //string entsp = txbEtiqueta.Text;
            //string sucsp = txbEtiqueta.Text;



            /* if (MessageBox.Show("Estas apunto de dar de baja na entrada " + entsp + " \nde: " + sucsp,"Alerta",MessageBoxButtons.OKCancel,MessageBoxIcon.Stop) ==DialogResult.OK)
             {
                 if (MessageBox.Show("De nuevo, esta entrada se eliminara de las tablas, quedado unicamente disponible para su consulta \nEntrada: " + entsp + " \nDe: " + sucsp, "Ultima Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
                 {

                 }
             }*/

        }
        DataTable datosGenerales = new DataTable();
        private void frmInfoEntradaCords_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            cargaDatos();

        }
        private void cargaDatos()
        {
            dtgCargasFilter.DataSource = null;

            Negocios.NGCarga.GETcarga get = new Negocios.NGCarga.GETcarga();
            var operacionV = get.ObtieneInfoparaCargasActivas(txbSucOrigenDetalle.Text, txbEntradaDetalle.Text);
            var valoresG = get.valoresObtiene(txbSucOrigenDetalle.Text, txbEntradaDetalle.Text);
            txbOperacionEnt.Text = operacionV.c2.ToString();
            txbFact.Text = valoresG.valFact;
            txbArnian.Text = valoresG.valArn;
            datosGenerales = VistaInicioCoordinadores.dataFilter.ConvierteADatatable2(get.ObtieneCargasActivas(txbSucOrigenDetalle.Text, operacionV.c1));
            dtgCargasFilter.DataSource = datosGenerales;

        }

        private DateTime regresafecha()
        {

            Servicio datos = new Servicio();
            string fecha1 = datos.retornafechaLapaz();

            FechaActual lst = JsonConvert.DeserializeObject<FechaActual>(fecha1);

            return lst.datetime;


        }

        private int congelaEntradasCargas()
        {
            int bandera = 1;
            DateTime datoFecha = regresafecha();
            string fechaHoy = datoFecha==null?DateTime.Now.ToString("MM/dd/yyyy") :datoFecha.ToString("MM/dd/yyyy");
            TimeSpan horaNow = datoFecha.TimeOfDay;
            var listaSinEcedenteHora = new vmCargaCordinadores();

            int selectedrowindex = dtgCargasFilter.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dtgCargasFilter.Rows[selectedrowindex];
            string fecha = Convert.ToDateTime(selectedRow.Cells[2].Value).ToString("MM/dd/yyyy");
            if (Convert.ToDateTime(fecha) < Convert.ToDateTime(fechaHoy))
            {
                bandera = 0;
                    MessageBox.Show("Esta Orden cerro por fecha");
            

            }
            if (fecha == fechaHoy)
             {
                    TimeSpan horaCierra = TimeSpan.Parse(Convert.ToDateTime(selectedRow.Cells[3].Value).ToString("HH:m:ss"));
                    if (horaNow> horaCierra)
                    {
                        MessageBox.Show("Esta Orden cerro por Hora");
                    bandera = 0;
                   
                }
             }
            return bandera;
        }

        private void dtgCargasFilter_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgCargasFilter.SelectedCells.Count > 0)
            {
                int selectedrowindex = dtgCargasFilter.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dtgCargasFilter.Rows[selectedrowindex];
                string so = Convert.ToString(selectedRow.Cells[0].Value);
                string en = Convert.ToString(selectedRow.Cells[1].Value);
               // await CargaLosValoresDeDetalle(so, en);
               // ngbdReportes rep = new ngbdReportes();
                //await rep.CargaControlid(so.Trim(), en.Trim());
            }
        }

        private void dtgCargasFilter_FilterStringChanged(object sender, EventArgs e)
        {
            using (BindingSource aada = new BindingSource())
            {
                aada.DataSource = datosGenerales;
                aada.Filter = dtgCargasFilter.FilterString;
            }
        }

        private void dtgCargasFilter_SortStringChanged(object sender, EventArgs e)
        {
            using (BindingSource aada = new BindingSource())
            {
                aada.DataSource = datosGenerales;
                aada.Sort = dtgCargasFilter.SortString;
            }
        }

        private async void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            if (congelaEntradasCargas()==0)
            {
                return;
            }
            if (txbCargaActual.Text.Trim()!="")
            {
                MessageBox.Show("Esta entrada "+ txbEntradaDetalle.Text.Trim()+" ya esta asignada a un orden de carga.");
                return;
            }
            try
            {
                DataGridViewRow selectedRow = dtgCargasFilter.Rows[dtgCargasFilter.SelectedCells[0].RowIndex];
                string c_so = Convert.ToString(selectedRow.Cells[0].Value).Trim();
                string c_car = Convert.ToString(selectedRow.Cells[1].Value).Trim();
                string c_cargacompleta = c_so + "-UD4001-" + c_car;

                string e_en = txbEntradaDetalle.Text.Trim();
                string e_so = txbSucOrigenDetalle.Text.Trim();
                Negocios.NGCarga.altasBDCarga get = new Negocios.NGCarga.altasBDCarga();
                await get.AsignaCargaAEntrada(e_so, e_en, c_cargacompleta);
                MessageBox.Show("La entrada: "+e_en+" fue asignada con exito a la carga "+c_cargacompleta,"Carga asignada",MessageBoxButtons.OK);
            }
            catch (Exception)
            {

                throw;
            }
            timer1.Enabled = false;
            this.Dispose();
            this.Close();
            
          
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cargaDatos();

        }

        private void frmInfoEntradaCords_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }
        private void AgregaEntradaOrden()
        {
            
        }
    }
}
