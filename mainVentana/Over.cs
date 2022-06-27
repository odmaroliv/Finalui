using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Datosenti;
using Negocios;
using System.Threading;

namespace mainVentana
{
    public partial class Over : Form
    {   
        Servicios vd = new Servicios(); // Indxa la clase de validcaiones 
        public Over()
        {
            InitializeComponent();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void Over_Load(object sender, EventArgs e)
        {
            
        }
        public void busquedamain()
        {
            using (prueba1Entities modelo = new prueba1Entities())
            {
                //gunaDataGridView1.DataSource = vd.Cargabuscque();
                //MessageBox.Show(vd.Cargabuscque().ToString());
                // tb.id = gunaDataGridView1.CurrentCell.Value;
            }
        }

#region hovers colores
        //-----botones inicio
        private void gunaShadowPanel2_MouseEnter(object sender, EventArgs e)
        {
            gunaShadowPanel2.BaseColor   = Color.FromArgb(59, 43, 255);
        }

        private void gunaShadowPanel2_MouseLeave(object sender, EventArgs e)
        {
            gunaShadowPanel2.BaseColor = Color.FromArgb(106, 90, 205);
        }

        private void gunaShadowPanel3_MouseEnter(object sender, EventArgs e)
        {
            gunaShadowPanel3.BaseColor = Color.Red;
        }
       

        private void gunaShadowPanel3_MouseLeave(object sender, EventArgs e)
        {
            gunaShadowPanel3.BaseColor = Color.Tomato;
        }
        
        private void gunaShadowPanel4_MouseEnter(object sender, EventArgs e)
        {
            gunaShadowPanel4.BaseColor = Color.FromArgb(0, 255, 88); 
        }

        private void gunaShadowPanel4_MouseLeave(object sender, EventArgs e)
        {
            gunaShadowPanel4.BaseColor = Color.SpringGreen; 

        }

        #endregion


        public async void refresh(string id)
        {
            Negocios.Servicios vld = new Negocios.Servicios();
            
            gunaDataGridView1.DataSource =  await vld.Cargabuscque(id);
            if(gunaDataGridView1.RowCount <= 0)
            {
                MessageBox.Show("No se encontraron datos");
            }
        }

        private void gunaDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
           
                int filas = gunaDataGridView1.Rows.Count;
                for (int i = 0; i < filas; i++)
                {
                    if (gunaDataGridView1.Rows[i].Cells[4].Value.ToString() == gunaDataGridView1.Rows[i].Cells[5].Value.ToString())
                    {
                        gunaDataGridView1.Rows[i].Cells[4].Style.BackColor = Color.FromArgb(104, 183, 255);
                    }
                    else if (gunaDataGridView1.Rows[i].Cells[4].Value.ToString() != gunaDataGridView1.Rows[i].Cells[5].Value.ToString())
                    {
                        gunaDataGridView1.Rows[i].Cells[4].Style.BackColor = Color.FromArgb(250, 95, 73);
                        gunaDataGridView1.Rows[i].Cells[4].Style.ForeColor = Color.FromArgb(255, 255, 255);
                }
                }
             

           
        }

        private void gunaShadowPanel2_Click(object sender, EventArgs e)
        {
            Process calc = new Process { StartInfo = { FileName = @"calc.exe" } };
            calc.Start();

            //calc.WaitForExit();
        }

        private void gunaShadowPanel3_Click(object sender, EventArgs e)
        {
            if (ValidaTxt(gunaDataGridView1) == 1)
            {
                string entrada = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Process.Start("https://mail.google.com/mail/?ui=2&view=cm&fs=1&tf=1&to=sistemas@arnian.com&su=Info%20sobre%20entrada:" + entrada + "&body=" + entrada);
            }
                
        }

        private void gunaShadowPanel4_Click(object sender, EventArgs e)
        {
            if (ValidaTxt(gunaDataGridView1) == 1)
            {
                string entrada = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Process.Start("https://api.whatsapp.com/send?phone=5216643850871&text=" + entrada);

            }

        }

        //----------------- campo en blanco------
        public int ValidaTxt(DataGridView tb)
        { //retorna 1 si el campo contien informacion retorna 0 si esta vacio
            
            if (tb == null || tb.Rows.Count == 0)
            {
                Convert.ToInt32(MessageBox.Show("El campo Buscar Entrada no puede estar vacio", "EROR", MessageBoxButtons.OK));
                return 0;
            }
            else
            {
                return 1;

            }
            
        }

        private void gunaGradientTileButton5_Click(object sender, EventArgs e)
        {
           
        }




        //--------------grafuca

    }
}
