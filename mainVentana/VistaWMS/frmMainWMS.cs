using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaWMS
{
    public partial class frmMainWMS : Form
    {
        public frmMainWMS()
        {
            InitializeComponent();
        }

        private void btnRakA_Click(object sender, EventArgs e)
        {

            int columnCount = Convert.ToInt32(((Guna.UI.WinForms.GunaAdvenceTileButton)sender).Tag);
            dgvInfoRak.Columns.Clear();
            for (int i = 0; i < columnCount; i++)
            {
                if (i==0)
                {
                    dgvInfoRak.Columns.Add("Column" + (i + 1), "*");
                }
                dgvInfoRak.Columns.Add("Column" + (i + 1), "" + (i + 1));
            }

            //int rowCount = Convert.ToInt32(((Guna.UI.WinForms.GunaAdvenceTileButton)sender).Tag);
            dgvInfoRak.Rows.Clear();
          
            dgvInfoRak.Rows.Add();
            dgvInfoRak.Rows[0].Cells[0].Value = "E";
            dgvInfoRak.Rows.Add();
            dgvInfoRak.Rows[1].Cells[0].Value = "D";
            dgvInfoRak.Rows.Add();
            dgvInfoRak.Rows[2].Cells[0].Value = "C";
            dgvInfoRak.Rows.Add();
            dgvInfoRak.Rows[3].Cells[0].Value = "B";
            dgvInfoRak.Rows.Add();
            dgvInfoRak.Rows[4].Cells[0].Value = "A";

            lblRack.Text = ((Guna.UI.WinForms.GunaAdvenceTileButton)sender).Text;

        }

        private void dgvInfoRak_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    lblColumna.Text = dgvInfoRak.Columns[e.ColumnIndex].HeaderText;
                    lblFila.Text = dgvInfoRak.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
                catch (Exception)
                {

                  
                }
             
            }
        }

        private void dgvInfoRak_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > 0 && e.ColumnIndex % 2 == 0 && e.RowIndex != -1)
                {
                    e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.OutsetDouble;

                }
            }
            catch (Exception)
            {

                throw;
            }
           
            
        }
    
    }
}
