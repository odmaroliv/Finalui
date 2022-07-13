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

namespace mainVentana.VistaBill
{
    public partial class frmOperSalidas : Form
    {
        public frmOperSalidas()
        {
            InitializeComponent();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            string dia = dtpTiempo.Value.Date.ToString();
            BusquedaBill bd = new BusquedaBill();
           gunaDataGridView1.DataSource =  bd.SalidasOperacion(dia);
        }

        private void frmOperSalidas_Load(object sender, EventArgs e)
        {
            dtpTiempo.Value.ToLocalTime();
            
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            ExportExcel();

        }

        private void ExportExcel()
        {

            if (gunaDataGridView1.Rows.Count>0)
            {
            DataTable dt = new DataTable();
            

            foreach (DataGridViewColumn column in gunaDataGridView1.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }


            foreach (DataGridViewRow row in gunaDataGridView1.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value == null ? "" : cell.Value.ToString();
                }
            }

            //Exporting to Excel
            string path = null;
            

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
                string fullPath = path + "_" + hoy + ".xlsx";
                xlfile.Worksheets.Add(dt, "ParaBEE");
                xlfile.Table("ParaBEE").ShowAutoFilter = false;// Disable AutoFilter.
                xlfile.Table("ParaBEE").Theme = XLTableTheme.None;// Remove Theme.
                xlfile.SaveAs(fullPath);
                Process.Start(fullPath);
            }
            }
            else
            {
                MessageBox.Show("No hay datos para exportar");
                return;
            }
        }
    

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
            new DataColumn("Name", typeof(string)),
            new DataColumn("Country",typeof(string)) });
                dt.Rows.Add(1, "John Hammond", "United States");
                dt.Rows.Add(2, "Mudassar Khan", "India");
                dt.Rows.Add(3, "Suzanne Mathews", "France");
                dt.Rows.Add(4, "Robert Schidner", "Russia");
                this.gunaDataGridView1.DataSource = dt;
            
        }
    }
}
