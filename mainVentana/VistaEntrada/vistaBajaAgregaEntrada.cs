using Datos.ViewModels.Entradas;
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
            if (entrada=="00" || entrada == default)
            {
                lblEntrada.Text = "Error";
                return;
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
            txbTotalEt.Text = dtgEtiquetas.Rows.Count == 0?"": dtgEtiquetas.Rows.Count.ToString();
        }


        private async Task eliminaDatos()
        {
           
            int index = 1;
            long nFilas = nBorra.Value;
            if (nFilas==0)
            {
                return;
            }

            List<string> listaNueva = new List<string>();
            foreach (var item in datosLista)
            {
                if (index<=nFilas)
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
                OdooClient od= new OdooClient();
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
    }
}
