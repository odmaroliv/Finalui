using Datos.ViewModels.Coord.oldCot;
using Guna.UI.WinForms;
using mainVentana.VistaEntrada;
using Negocios;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventana1.LoadControl;

namespace mainVentana.Reportes.Cotizaciones.Antiguas
{
    public partial class frmOldCotPorCliente : Form
    {

        private int datparseado;
        private string _nCotD7 = "";
        private string _oper = "Cliente";
        private string _iva= "";

        public frmOldCotPorCliente()
        {
            InitializeComponent();
        }






        public async Task refresh(string id)
        {

            //txbComent.Text = "";
            string sucursal = default;



            if (rSd.Checked == true)
            {
                sucursal = "SD";
            }
            if (rTj.Checked == true)
            {
                sucursal = "TJ";
            }
            if (rCa.Checked == true)
            {
                sucursal = "CSL";
            }

            Negocios.NGCotizacion.accesoCotizaciones dt = new Negocios.NGCotizacion.accesoCotizaciones();
            gunaDataGridView1.DataSource = null;
            var lls = await dt.BuscarCitizacionPorId(id, sucursal);
            gunaDataGridView1.DataSource = lls;
            if (gunaDataGridView1.RowCount <= 0)
            {
                MessageBox.Show("No se encontraron datos");
                return;
            }
        }

        private async void gunaTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               ValidabPrincipal();
                string id = gunaTextBox2.Text;
                await refresh(_nCotD7);
               // await Task.Run(() => { Thread.Sleep(1000); });

                e.SuppressKeyPress = true;
            }
        }
        private void ValidabPrincipal()
        {
            if (gunaTextBox2.Text == "")
            {
                MessageBox.Show("El campo de busqueda esta vacio!");
                return;
            }

            bool bent = Int32.TryParse(gunaTextBox2.Text, out datparseado);
            if (bent == true)
            {
                gunaTextBox2.Text = datparseado.ToString("D7");
                _nCotD7 = datparseado.ToString("D7");
            }
            else
            {
                MessageBox.Show("Las entradas tienen que ser un codigo numerico, y no pueden contener letras");
                return;
            }
        }

        private void gunaTileButton1_Click(object sender, EventArgs e)
        {

            using (VistaEntrada.BusquedasEnt buscador = new BusquedasEnt())
            {
                buscador.label2.Text = "CLIENTE";
                buscador.pasado += new BusquedasEnt.pasar(moverinfo);
                buscador.ShowDialog();
                buscador.pasado -= new BusquedasEnt.pasar(moverinfo);
            }

        }
        public void moverinfo(string dato, string dato2, string dato3, string dato4, string dato5, string dato6, string dato7, string correoCliente, int bandera) //cambia los datos de los textbox alias y clientes, la bandera dependera de la manera en la que se haya abierto el frm buscar, 0 clientes 1 alias, ADEMAS tambien sirve para cambiar el campo de cord
        {
            //coreoClientes = correoCliente;
            if (bandera == 0) //clientes
            {
                cliente.Text = dato;
                //alias.Text = dato2;
                label23.Text = dato4;
                label24.Text = dato5;
                label25.Text = dato6;
                label26.Text = "Dir Cliente";
                lblCodCliente.Text = dato7;


            }

        }

        private async void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton btn = (System.Windows.Forms.RadioButton)sender;
            _oper = btn.Tag.ToString();
            Servicios datos = new Servicios();
            var lst1 = await datos.llenaCordOLD();
            cord.ValueMember = "C2";
            cord.DisplayMember = "C3";
            cord.DataSource = lst1;
        }

        private async void gunaTileButton2_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(_iva))
            {
                MessageBox.Show("Seleccion una opcion para IVA /o Cliente");
                return;
            }
            loadControl1.Visible = true;
            gunaTileButton2.Enabled = false;
            bigLabel1.Visible = true;
            Negocios.NGCotizacion.accesoCotizaciones dt = new Negocios.NGCotizacion.accesoCotizaciones();
            gunaDataGridView1.DataSource = null;

            var lls = new List<vmOldBusquedaCot>();

            if (_oper =="Cliente")
            {
                string sucursal = default;


                if (rSd.Checked == true)
                {
                    sucursal = "SD";
                }
                if (rTj.Checked == true)
                {
                    sucursal = "TJ";
                }
                if (rCa.Checked == true)
                {
                    sucursal = "CSL";
                }

                //var ivanci = Convert.ToInt32(_iva).ToString("D7");
              

                lls = await dt.BuscarCitizacionPorClienteOld(lblCodCliente.Text, sucursal, _iva, dtFecha1.Value.Date, dtFecha2.Value.Date);
                
                loadControl1.Visible = false;
                gunaTileButton2.Enabled = true;
                bigLabel1.Visible = false;
            }
            if (_oper == "Coor")
            {
                



                string sucursal = default;

                var co = cord.SelectedValue.ToString();

                if (rSd.Checked == true)
                {
                    sucursal = "SD";
                }
                if (rTj.Checked == true)
                {
                    sucursal = "TJ";
                }
                if (rCa.Checked == true)
                {
                    sucursal = "CSL";
                }
                lls = await dt.BuscarCitizacionPorCoordOld( co, sucursal);
              
            }

            foreach (var item in lls)
            {
                try
                {
                    if (item.C16.HasValue && item.C40.HasValue)
                    {
                        // Multiply C16 and C40 and store the result in a new property
                        item.C93 = (item.C16.Value * (decimal)item.C40.Value).ToString();
                    }
                    else
                    {
                        // Handle null values for C16 or C40
                        item.C93 = null;
                    }
                }
                catch (Exception)
                {
                    item.C93 = null;
                }
            }
            gunaDataGridView1.DataSource = lls;


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void rbIva0_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton btnRd = (System.Windows.Forms.RadioButton)sender;
            _iva = "";
            _iva = btnRd.Tag.ToString();
        }

        private void frmOldCotPorCliente_Load(object sender, EventArgs e)
        {
            dtFecha1.Value = DateTime.Now;
            dtFecha2.Value = DateTime.Now;
            dtFecha1.MinDate = DateTime.Now.AddDays(-366);
            dtFecha1.MaxDate = DateTime.Now.AddDays(1);
            dtFecha2.MinDate = DateTime.Now.AddDays(-366);
            dtFecha2.MaxDate = DateTime.Now.AddDays(1);
        }
    }
}
