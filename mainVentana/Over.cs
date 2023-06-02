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
using mainVentana.VistaInicioFoto;
using mainVentana.VistaInicioCoordinadores;
using mainVentana.vistaReportes;
using mainVentana.VistaCreditoCobranza;

namespace mainVentana
{
    public partial class Over : Form
    {
        Servicios vd = new Servicios(); // Indxa la clase de validcaiones 

        frmInicioCoordinadores frm = new frmInicioCoordinadores();
        private string _tipoBusqueda = "Ent";
        public Over()
        {
            InitializeComponent();
            
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        
        private void Over_Load(object sender, EventArgs e)
        {
            if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "CSERVI")
            {

                frm.pasado += new frmInicioCoordinadores.pasar(refrescatabla);
                AbrirFormEnPanel(frm);
            }
            else if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "CXC")
            {
                VistaCXC ts = new VistaCXC();
                AbrirFormEnPanel(ts);
                btnCordAdmin.Visible = true;
                btnCordAdmin.Enabled = true;
            }
            else if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "ADMIN")
            {
                btnAdminAdmin.Enabled = true;
                btnCordAdmin.Enabled = true;
                btnArtu.Enabled = true;
                btnAdminAdmin.Visible = true;
                btnCordAdmin.Visible = true;
                btnArtu.Visible = true;
                btnCxcp.Visible = true;
            }

            else
            {
            tstflirk ts   = new tstflirk();
            AbrirFormEnPanel(ts);

            }
            
            // gunaDataGridView1.CurrentCell = null;
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


        #endregion


        private void AbrirFormEnPanel(object formHijo)
        {


            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fh);
            this.panel1.Tag = fh;
            fh.Show();
        }

//        public delegate void pasado (string id) 


        public async Task refresh(string id, string tipo)
        {
           
            Negocios.Servicios vld = new Negocios.Servicios();
            gunaDataGridView1.DataSource = null;

            gunaDataGridView1.DataSource = await vld.Cargabuscque(id,tipo);
            
            vld = null;
        }

        

        private void gunaDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


        }


        private void formatodeceldas()
        {
            int filas = gunaDataGridView1.Rows.Count;
            for (int i = 0; i < filas; i++)
            {



                DateTime fechaactual = DateTime.Now;
                DateTime fechaent;
                DateTime dt;
                if (gunaDataGridView1.Rows[i].Cells[2].Value==null || gunaDataGridView1.Rows[i].Cells[2].Value.ToString() == "")
                {
                    fechaent = DateTime.Parse("7/6/2021 12:16:02 PM");
                }
                else
                {
                    fechaent = DateTime.TryParse(gunaDataGridView1.Rows[i].Cells[2].Value.ToString().Trim(),out dt) == false ? DateTime.Parse("7/6/2021 12:16:02 PM") : dt;
                }



                TimeSpan tiempo = fechaactual - fechaent;

                if (gunaDataGridView1.Rows[i].Cells[4].Value.ToString() == gunaDataGridView1.Rows[i].Cells[5].Value.ToString() && gunaDataGridView1.Rows[i].Cells[19].Value.ToString().Trim() != "")
                {//cuando la surusal origen es igual a la destino 
                    gunaDataGridView1.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(68, 183, 255);
                    gunaDataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.FromArgb(255, 255, 255); 
                }
                else if (gunaDataGridView1.Rows[i].Cells[4].Value.ToString() == gunaDataGridView1.Rows[i].Cells[5].Value.ToString() && gunaDataGridView1.Rows[i].Cells[19].Value.ToString().Trim() == "")
                {//cuando la surusal origen es igual a la destino y no tienen bill 
                    gunaDataGridView1.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(248, 44, 155);
                    gunaDataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.FromArgb(255, 255, 255);
                }
                else if (gunaDataGridView1.Rows[i].Cells[4].Value.ToString() != gunaDataGridView1.Rows[i].Cells[3].Value.ToString() && gunaDataGridView1.Rows[i].Cells[4].Value.ToString() != gunaDataGridView1.Rows[i].Cells[5].Value.ToString())
                { //Cuando la sucursal origen es diferente de la sucursal destino y la sucursal actual es diferente de la sucursal origen
                    gunaDataGridView1.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(252, 173, 5);
                    gunaDataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.FromArgb(255, 255, 255);
                }
                /*else if (gunaDataGridView1.Rows[i].Cells[4].Value.ToString() != gunaDataGridView1.Rows[i].Cells[5].Value.ToString())
                {//cuando la sucursal actual es diferente de la sucursal final 
                    gunaDataGridView1.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(156, 19, 18);
                    gunaDataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.FromArgb(255, 255, 255);
                }*/



                if (tiempo > TimeSpan.Parse("15.00:00:0.0") && gunaDataGridView1.Rows[i].Cells[5].Value.ToString() == gunaDataGridView1.Rows[i].Cells[3].Value.ToString() && gunaDataGridView1.Rows[i].Cells[19].Value != null)
                { //cuando un item tiene mas de 30 dias en el almacen y la sursal actual es igual a la sucursal origen
                    gunaDataGridView1.Rows[i].Cells[2].Style.BackColor = Color.FromArgb(156, 19, 18);
                    gunaDataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.FromArgb(255, 255, 255);
                    gunaDataGridView1.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(156, 19, 18);
                    gunaDataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.FromArgb(255, 255, 255);
                }

                if (tiempo < TimeSpan.Parse("15.00:00:0.0") && gunaDataGridView1.Rows[i].Cells[5].Value.ToString() == gunaDataGridView1.Rows[i].Cells[3].Value.ToString() && gunaDataGridView1.Rows[i].Cells[19].Value != null)
                { //cuando la sucursal actual es la sucursal de origen y tiene menos de 15 dias
                    gunaDataGridView1.Rows[i].Cells[2].Style.BackColor = Color.FromArgb(19, 156, 18);
                    gunaDataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.FromArgb(255, 255, 255);
                    gunaDataGridView1.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(19, 156, 18);
                    gunaDataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.FromArgb(255, 255, 255);
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
            try
            {
                using (VistaOrSalida.frmOrdSalida salida = new VistaOrSalida.frmOrdSalida())
                {
                    salida.ShowDialog();
                }
                
             
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void gunaTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadControl1.Visible = true;
                bool esTecleado = false;
                string id = "";
                try
                {
                    switch (_tipoBusqueda)
                    {
                        case "Ent":
                            if (esTecleado) return;
                            esTecleado = true;
                            ValidabPrincipal();
                            id = gunaTextBox2.Text;
                            await refresh(id, _tipoBusqueda);
                            if (gunaDataGridView1.RowCount <= 0)
                            {
                                MessageBox.Show("No se encontraron datos");
                                return;
                            }
                            await Task.Run(() => { Thread.Sleep(1000); });
                            formatodeceldas();
                            e.Handled = true;
                            break;
                        case "Flete":
                            if (esTecleado) return;
                            esTecleado = true;
                            id = gunaTextBox2.Text;
                            if (id == "" || id.Length <4)
                            {
                                MessageBox.Show("El campo de busqueda esta vacio!");
                                return;
                            }
                            await refresh(id, _tipoBusqueda);
                            if (gunaDataGridView1.RowCount <= 0)
                            {
                                MessageBox.Show("No se encontraron datos");
                                return;
                            }
                            await Task.Run(() => { Thread.Sleep(1000); });
                            formatodeceldas();
                            e.Handled = true;
                            break;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    esTecleado = false;
                    loadControl1.Visible = false;
                }
            }
        }


        public async Task refrescatabla( string id)
        {
            gunaTextBox2.Text = id;
            await refresh(id,_tipoBusqueda);
            await Task.Run(() => { Thread.Sleep(1000); });
            formatodeceldas();
            
        }

        private void ValidabPrincipal()
        {
            if (gunaTextBox2.Text == "")
            {
                MessageBox.Show("El campo de busqueda esta vacio!");
                return;
            }
            int datparseado;
            bool bent = Int32.TryParse(gunaTextBox2.Text, out datparseado);
            if (bent == true)
            {
                gunaTextBox2.Text = datparseado.ToString("D7");
            }
            else
            {
                MessageBox.Show("Las entradas tienen que ser un codigo numerico, y no pueden contener letras");
                return;
            }
        }

        private void gunaTextBox2_MouseEnter(object sender, EventArgs e)
        {
            if (gunaTextBox2.Text == "Busqueda rapida de entrada :)")
            {
                gunaTextBox2.Text = "";

            }
        }

        private void gunaTextBox2_MouseLeave(object sender, EventArgs e)
        {
            //label4.Text = "Busqueda rapida de entrada :)";
        }

        private void gunaDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gunaDataGridView1.Rows.Count > 0)
            {
                string nombrecolumna = gunaDataGridView1.Columns[e.ColumnIndex].HeaderText;

                
                if (nombrecolumna.Trim() == "Link" && gunaDataGridView1.Rows[e.RowIndex].Cells[26].Value.ToString().Contains("BTRACKSALIDA") )
                {
                    string valorEnt = gunaDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string ValorSuc = gunaDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string url = string.Format("https://app.beetrack.com/search/{0}", ValorSuc.Trim() + "-" + valorEnt.Trim()) ;
                    System.Diagnostics.Process.Start(url);
                    return;
                }
               
                string id = gunaDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string orig = gunaDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();


               

                string valorPrimerCelda = gunaDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                frmSelectorFotos frm = new frmSelectorFotos();
                frm.txbEntrada.Text = orig + "-UD3501-"+id;
                frm.ShowDialog();
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("No hay datos para buscar.");
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            frmInicioCoordinadores frm = new frmInicioCoordinadores();
            frm.ShowDialog();

        }

        private void Over_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm.Dispose();
            frm.Close();
            this.Dispose();
            this.Close();
        }

        private void skyButton1_Click(object sender, EventArgs e)
        {

            if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "ADMIN")
            {
               
                frm.pasado += new frmInicioCoordinadores.pasar(refrescatabla);
                AbrirFormEnPanel(frm);
            }
          

        }

        private void skyButton2_Click(object sender, EventArgs e)
        {
            if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "ADMIN")
            {
             
                tstflirk ts = new tstflirk();
                AbrirFormEnPanel(ts);
            }

        }

        private void skyButton1_Click_1(object sender, EventArgs e)
        {
            if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "ADMIN")
            {

                frmVentaPequeña ts = new frmVentaPequeña();
                AbrirFormEnPanel(ts);
            }
        }

        private void skyButton1_Click_2(object sender, EventArgs e)
        {
            if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "ADMIN")
            {

                VistaCXC ts = new VistaCXC();
                AbrirFormEnPanel(ts);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton rd = (RadioButton)sender;


            _tipoBusqueda = rd.Tag.ToString();
        }





        //--------------grafuca

    }
}
