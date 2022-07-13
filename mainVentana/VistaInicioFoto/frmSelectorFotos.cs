using Datos.ViewModels.InicioFotoVisor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaInicioFoto
{
    public partial class frmSelectorFotos : Form
    {
        public frmSelectorFotos()
        {
            InitializeComponent();
        }

        private async void frmSelectorFotos_Load(object sender, EventArgs e)
        {
            gunaDataGridView1.DataSource = null;

            string nombreArchivo = txbEntrada.Text;
            int tipoRespuesta = 2;
            string mensajeRespuesta = "";
            if (!string.IsNullOrWhiteSpace(nombreArchivo))
            {

                try
                {
                    using (HttpClient cliente = new HttpClient())
                    {
                        string url = "http://104.198.241.64:90/api/Archivo/getls/?nombreArchivo=" + nombreArchivo;
                        using (HttpResponseMessage respuestaConsulta = await cliente.GetAsync(url))
                        {
                            using (HttpContent cn = respuestaConsulta.Content)
                            {
                                string contenido = await respuestaConsulta.Content.ReadAsStringAsync();
                                if (respuestaConsulta.IsSuccessStatusCode)
                                {
                                    List<FotoInicioVM> jds = JsonConvert.DeserializeObject<List<FotoInicioVM>>(contenido);

                                    gunaDataGridView1.DataSource = jds;


                                }
                            }

                        }
                    }
                }
                catch
                {

                }
            }
        }

        private void Abre()
        {
            
        }

        private async void DescargaDocs(string dato)
        {
            string nombreArchivo = dato.Trim();
            int tipoRespuesta = 2;
            string mensajeRespuesta = "";
            if (!string.IsNullOrWhiteSpace(nombreArchivo))
            {

                try
                {
                    using (HttpClient cliente = new HttpClient())
                    {
                        string url = "http://104.198.241.64:90/api/Archivo/?nombreArchivo=" + nombreArchivo;
                        using (HttpResponseMessage respuestaConsulta = await cliente.GetAsync(url))
                        {
                            if (respuestaConsulta.IsSuccessStatusCode)
                            {
                                byte[] arrContenido = await respuestaConsulta.Content.ReadAsAsync<byte[]>();
                          

                                string path = AppDomain.CurrentDomain.BaseDirectory;
                                string folder = path + "\\temp\\";
                                string fullFilePath = folder + dato;

                                if (File.Exists(fullFilePath))
                                    File.Delete(fullFilePath);

                                if (!Directory.Exists(folder))
                                    Directory.CreateDirectory(folder);

                                File.WriteAllBytes(fullFilePath, arrContenido);
                                
                                tipoRespuesta = 1;
                               // mensajeRespuesta = "Se descargó correctamente el archivo " + nombreArchivo;
                                Process.Start(fullFilePath);
                            }
                            else
                            {
                                mensajeRespuesta = await respuestaConsulta.Content.ReadAsStringAsync();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    tipoRespuesta = 3;
                    mensajeRespuesta = ex.Message;
                }

            }

           /* MessageBoxIcon iconoMensaje;
            if (tipoRespuesta == 1)
                iconoMensaje = MessageBoxIcon.Information;
            else if (tipoRespuesta == 2)
                iconoMensaje = MessageBoxIcon.Warning;
            else
                iconoMensaje = MessageBoxIcon.Error;
            MessageBox.Show(mensajeRespuesta, "Descarga de archivos", MessageBoxButtons.OK, iconoMensaje);*/
        }

        private  void gunaDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (gunaDataGridView1.Rows.Count > 0)
            {
                string id = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                DescargaDocs(id);
                
            }
            else
            {
                MessageBox.Show("No hay datos para buscar.");
            }
        }
    }
}
