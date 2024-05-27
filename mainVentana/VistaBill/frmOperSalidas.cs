using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios.NGBill;
using ClosedXML.Excel;
using System.Reflection;
using System.Diagnostics;
using Datos.ViewModels.Bill;
using mainVentana.Reportes.rbill;
using Datos.ViewModels.Reportes.Bill;
using Negocios.Odoo;
using DocumentFormat.OpenXml.Office2016.Drawing.Charts;
using Negocios;
using System.Windows.Interop;

namespace mainVentana.VistaBill
{
    public partial class frmOperSalidas : Form
    {

        string fullPath;
        string path;
        private Queue<string> taskQueue = new Queue<string>();
        private bool isBussy = false;
        private string uniqueId;
        private readonly OdooClient _odooCliente;
        public frmOperSalidas()
        {
            InitializeComponent();
            _odooCliente = new OdooClient();
            uniqueId = Guid.NewGuid().ToString();
            lblUniqueId.Text = uniqueId;
        }

        /* private void gunaAdvenceButton1_Click(object sender, EventArgs e)
         {
             string dia = dtpTiempo.Value.Date.ToString();
             BusquedaBill bd = new BusquedaBill();
            gunaDataGridView1.DataSource =  bd.SalidasOperacion(dia);
         }*/

        private void frmOperSalidas_Load(object sender, EventArgs e)
        {
            dtpTiempo.Value.ToLocalTime();
            BusquedaBill bd = new BusquedaBill();
            bd.RealizarConsultaSinSentido();

        }

        private async void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            if (isBussy)
            {
                labelAlert.Text = "Aun hay trabajos pendientes;";
                panelAlert.BackColor = Color.Red;
                return;
            }

            if (cmbVehuculo.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecciona un Vehiculo");
                return;
            }
            ExportExcel();
            if (MessageBox.Show("Quieres enviar un correo al cliente con los dumentos a entregar?","Notificar",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cbxNotificar.Checked = true;
            }
            else
            {
                cbxNotificar.Checked = false;
            }
            if (cbxNotificar.Checked)
            {
                string correoCliente = ObtenerCorreoCliente(listaeti);
                if (!string.IsNullOrEmpty(correoCliente))
                {
                    EnviarEmail servicio = new EnviarEmail();
                    string encabezado = $"Salida de ruta {DateTime.Now}";
                    string cuerpo = "Lista de Entradas a entregar";
                    //string archivo = "Ruta del archivo"; // Asigna la ruta del archivo exportado
                    await servicio.EnviaMailSencillo(encabezado, cuerpo, fullPath, correoCliente);

                }
                else
                {
                    MessageBox.Show("No se encontró un correo válido en las filas.");
                }
            }
            if (!string.IsNullOrWhiteSpace(fullPath))
            {
                string folderPath = Path.GetDirectoryName(fullPath);
                Process.Start("explorer.exe", folderPath);
                // Process.Start(fullPath);
            }

        }

        private string ObtenerCorreoCliente(List<VMSalidasBill> lista)
        {
            foreach (var item in lista)
            {
                if (!string.IsNullOrEmpty(item.EMAIL) && IsValidEmail(item.EMAIL))
                {
                    return item.EMAIL;
                }
            }
            return null;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ExportExcel()
        {
            try
            {
                string vehiculo = cmbVehuculo.SelectedItem.ToString();

                if (gunaDataGridView1.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();



                    foreach (DataGridViewColumn column in gunaDataGridView1.Columns)
                    {
                        dt.Columns.Add(column.HeaderText, column.ValueType);
                    }

                    //dt.Columns.Add("VEHICULO", typeof(string));

                    foreach (DataGridViewRow row in gunaDataGridView1.Rows)
                    {
                        dt.Rows.Add();
                        // Asignar el valor de la variable "vehiculo" a la nueva columna en cada fila
                        // dt.Rows[dt.Rows.Count - 1]["VEHICULO"] = vehiculo;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value == null ? "" : cell.Value.ToString();
                        }
                    }

                    //Exporting to Excel
                     path = null;


                    saveFileDialog1.InitialDirectory = @"C\:";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        path = saveFileDialog1.FileName;
                    }
                    else
                    {
                        return;
                    }

                    /*if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }*/
                    using (XLWorkbook xlfile = new XLWorkbook())
                    {

                        string hoy = DateTime.Now.ToString("dd-MM-yyyy");
                        fullPath = path + "_" + hoy + ".xlsx";
                        xlfile.Worksheets.Add(dt, "ParaBEE");
                        xlfile.Table("ParaBEE").ShowAutoFilter = false;// Disable AutoFilter.
                        xlfile.Table("ParaBEE").Theme = XLTableTheme.None;// Remove Theme.
                        xlfile.SaveAs(fullPath);
                       
                    }
                }
                else
                {
                    MessageBox.Show("No hay datos para exportar");
                    return;
                }

            }
            catch (Exception)
            {

                throw;
            }
           
        }


        List<VMSalidasBill> listaeti = new List<VMSalidasBill>();
        private async void txbEtiqueta_KeyDown(object sender, KeyEventArgs e)
        {
           
            try
            {
                isBussy = true;
                if (cmbVehuculo.SelectedItem == null)
                {
                    MessageBox.Show("Por favor selecciona un Vehiculo");
                    return;
                }

                if (e.KeyCode != Keys.Enter)
                    return;

                e.Handled = true;
                e.SuppressKeyPress = true;

                string eti = txbEtiqueta.Text.Replace("'", "-");
                if (Verifica(eti) == 1)
                    return;

                // Añade la tarea a la cola.
                taskQueue.Enqueue(eti);
                txbEtiqueta.Text = "";
                // Actualiza lblQueueCount.
                lblQueueCount.Text = $"Tareas en cola: {taskQueue.Count}";

                // Si no hay otras tareas en proceso, comienza a procesar la cola.
                if (taskQueue.Count == 1)
                {
                    await ProcessQueue();
                }
                lblQueueCount.Text = $"Tareas en cola: {taskQueue.Count}";
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                isBussy = false;
            }
           
        }

        private async Task ProcessQueue()
        {
            if (taskQueue.Count > 0)
            {
                string eti = taskQueue.Dequeue();

                // Actualiza lblQueueCount.
               // lblQueueCount.Text = $"Tareas en cola: {taskQueue.Count}";

                // Aquí va tu código de procesamiento de etiquetas.
                string fecha = dtpTiempo.Value.ToString("dd/MM/yyyy");
                string vehiculo = cmbVehuculo.SelectedItem.ToString();

                BusquedaBill bd = new BusquedaBill();

                try
                {
                    var ss = await Task.Run(() => bd.SalidasOperacion(_odooCliente,eti, fecha, vehiculo));

                    if (ss.Any())
                    {
                       
                        listaeti.Insert(0, ss[0]);

                        // listaeti.Add(ss[0]);
                        await Task.Run(() => bd.ModificaKDMENTToBill(eti, uniqueId));  // Convertir en método asíncrono y usar await.

                    }
                    else
                    {
                        labelAlert.Text = "No Se encontro";
                        panelAlert.BackColor = Color.Red;
                        //txbEtiqueta.Text = "";
                        return;
                    }

                    panelAlert.BackColor = Color.Green;
                    labelAlert.Text = "Agregada";

                    // Actualiza la interfaz de usuario solo una vez, en lugar de varias veces.
                    //txbEtiqueta.Text = "";
                    try
                    {
                        gunaDataGridView1.DataSource = null;
                        gunaDataGridView1.DataSource = listaeti;
                        gunaDataGridView1.Rows[gunaDataGridView1.RowCount - 1].Selected = true;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                   
                }
                catch (Exception x)
                {
                    Negocios.LOGs.ArsLogs.LogEdit(x.Message, "BILL sale de arsys a Beetrack" + eti);
                }

                // Llama a ProcessQueue de nuevo para procesar la siguiente tarea.
                await ProcessQueue();
            }
        }



        private int Verifica(string dato)
        {
            int band = 0;
            for (int i = 0; i < gunaDataGridView1.Rows.Count; i++)
            {
                if (dato.Trim().ToUpper() == gunaDataGridView1.Rows[i].Cells[6].Value.ToString().Trim().ToUpper())
                {
                    panelAlert.BackColor = Color.Red;
                    labelAlert.Text = "Duplicada";
                    txbEtiqueta.Text = "";
                    band = 1;
                }
            }
            return band;
        }

        private void txbEtiqueta_Leave(object sender, EventArgs e)
        {
            if (MessageBox.Show("Saliendo de scanear?", "Cuidado", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                txbEtiqueta.Focus();
            }

        }


        

        private void gunaDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          /*  if (gunaDataGridView1.CurrentRow.Cells[6].Value.ToString().Trim().ToUpper() == null)
                return;
            
            listaeti.RemoveAll(c => c.etiqueta == gunaDataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
            gunaDataGridView1.DataSource = null;
            gunaDataGridView1.DataSource = listaeti;
            //gunaDataGridView1.Rows[gunaDataGridView1.RowCount - 1].Selected = true;*/

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            LlamaReporte();
        }


        private void LlamaReporte()
        {
            /*using (frmBillVisorImp bill = new frmBillVisorImp())
            {
                bill.from = "Cliente";
                bill.fromCalle = "Hola";
                bill.fromDir1 = "Call1";
                bill.fromDir2 = "Call2";
                bill.Coordinador = "Coordinador";
                bill.Note = "Notas";
                bill.Cellphone = "6656665644";
                bill.to = "Para";
                bill.toCalle = "Callw";
                bill.toDir1 = "ToDir1";
                bill.toDir2 = "Calle 2";
                bill.ShipDate = "12-12-12";
                bill.totalCases = "2";

                var lst = new List<vmBillOfTable>();

                for (int i = 0; i < 500; i++)
                {
                    lst.Add(new vmBillOfTable { Description = "Helloooo " + i.ToString(), id = i.ToString() }); ;
                }

                bill.lst = lst;
                bill.ShowDialog();
            }*/

        }

        private async void gunaDataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Comprueba si la columna seleccionada es la columna 3
            if (e.ColumnIndex == 4)
            {
                try
                {
                    BusquedaBill bd = new BusquedaBill();
                    // Obtén el valor de la celda seleccionada
                    string value = gunaDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    // Busca el elemento en la lista y lo elimina
                    listaeti.Remove(listaeti.Where(x => x.etiqueta == value).First());
                    gunaDataGridView1.DataSource = null;
                    gunaDataGridView1.DataSource = listaeti;
                    await bd.ModificaKDMENTToBillBorra(value);
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
        }
    }
}
