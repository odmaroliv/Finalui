using mainVentana.VistaEntrada;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios.NGClientes;
using Datos.ViewModels.Entradas;
using Negocios;
using Datos.ViewModels.Coord.Clientes;

namespace mainVentana.VistaInicioCoordinadores
{
    public partial class frmClientesMain : Form
    {
        public frmClientesMain()
        {
            InitializeComponent();
        }

        private void frmClientesMain_Load(object sender, EventArgs e)
        {

        }

        private void dungeonButtonRight2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txbClave.Text))
            {
                NoMoverinfo(txbClave.Text.Trim());
            }
            else
            {
                using (VistaEntrada.BusquedasEnt buscador = new BusquedasEnt())
                {
                    buscador.label2.Text = "CLIENTE";
                    buscador.pasado += new BusquedasEnt.pasar(moverinfo);
                    buscador.ShowDialog();
                    buscador.pasado -= new BusquedasEnt.pasar(moverinfo);
                }
            }
            btnGuardar.Enabled = false;
        }
        public async void NoMoverinfo(string dato7)
        {
            try
            {
                Servicios datos = new Servicios();
                AccesoClientes ac = new AccesoClientes();
                var dt = ac.BuscaInfoCliente(dato7);
                if (dt == null)
                {
                    MessageBox.Show("Error, puede ser que el dato que tratas de buscar no exista, ya se ha retornado un valor vacio.", "Error");
                    return;
                }
                txbClave.Text = dt.C2;
                txbNombre.Text = dt.C3;
                txbDireccion.Text = dt.C4;
                txbColonia.Text = dt.C5;
                txbPoblacion.Text = dt.C6;
                txbTel.Text = dt.C7;
                txbRfc.Text = dt.C10;
                txbEmail.Text = dt.C11;
                //c12 ejecutivo
                // c14 zona
                txbZip.Text = dt.C27;



                cmbCor.DataSource = null;
                var lst1 = await datos.llenaCord();
                cmbCor.ValueMember = "C2";
                cmbCor.DisplayMember = "C3";
                cmbCor.DataSource = lst1;

                if (dt.C12 != null)
                {
                    foreach (vmCordinadores i in cmbCor.Items)
                    {
                        if (i.c2.Trim() == dt.C12.Trim())
                        {
                            cmbCor.SelectedValue = i.c2;
                            break;
                        }
                    }
                }


                cmbZona.DataSource = null;
                if (dt.C14 != null && String.IsNullOrWhiteSpace(dt.C14))
                {
                    var lst2 = await ac.LLenaZona();
                    cmbZona.ValueMember = "C2";
                    cmbZona.DisplayMember = "C1";
                    cmbZona.DataSource = lst2;

                    foreach (vmZonas i in cmbZona.Items)
                    {
                        if (i.C2.Trim() == dt.C14.Trim())
                        {
                            cmbZona.SelectedValue = i.C2;
                            break;
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            
        }


        public async void moverinfo(string dato, string dato2, string dato3, string dato4, string dato5, string dato6, string dato7, string correoCliente, int bandera) //cambia los datos de los textbox alias y clientes, la bandera dependera de la manera en la que se haya abierto el frm buscar, 0 clientes 1 alias, ADEMAS tambien sirve para cambiar el campo de cord
        {
            string coreoClientes = correoCliente;
            if (bandera == 0) //clientes
            {
                Servicios datos = new Servicios();
                AccesoClientes ac = new AccesoClientes();
                var dt = ac.BuscaInfoCliente(dato7);
                txbClave.Text = dt.C2;
                txbNombre.Text = dt.C3;
                txbDireccion.Text = dt.C4;
                txbColonia.Text = dt.C5;
                txbPoblacion.Text = dt.C6;
                txbTel.Text = dt.C7;
                txbRfc.Text = dt.C10;
                txbEmail.Text = dt.C11;
                //c12 ejecutivo
                // c14 zona
                txbZip.Text = dt.C27;



                cmbCor.DataSource = null;
                var lst1 = await datos.llenaCord();
                cmbCor.ValueMember = "C2";
                cmbCor.DisplayMember = "C3";
                cmbCor.DataSource = lst1;

                if (dt.C12 != null)
                {
                    foreach (vmCordinadores i in cmbCor.Items)
                    {
                        if (i.c2.Trim() == dt.C12.Trim())
                        {
                            cmbCor.SelectedValue = i.c2;
                            break;
                        }
                    }
                }


                cmbZona.DataSource = null;
                if (dt.C14 != null && String.IsNullOrWhiteSpace(dt.C14))
                {
                    var lst2 = await ac.LLenaZona();
                    cmbZona.ValueMember = "C2";
                    cmbZona.DisplayMember = "C1";
                    cmbZona.DataSource = lst2;

                    foreach (vmZonas i in cmbZona.Items)
                    {
                        if (i.C2.Trim() == dt.C14.Trim())
                        {
                            cmbZona.SelectedValue = i.C2;
                            break;
                        }
                    }

                }




            }

        }


        private void buscaCliente()
        {

        }

        private void dungeonButtonRight1_Click(object sender, EventArgs e)
        {
            ReiniciaValores();
            btnGuardar.Enabled = true;
            txbClave.Enabled = false;
        }
        private void ReiniciaValores()
        {
            AccesoClientes ac = new AccesoClientes();
            txbClave.Text = default;
            txbNombre.Text = default;
            txbDireccion.Text = default;
            txbColonia.Text = default;
            txbPoblacion.Text = default;
            txbTel.Text = default;
            txbRfc.Text = default;
            txbEmail.Text = default;

            txbZip.Text = default ;



            cmbCor.DataSource = null;

            cmbZona.DataSource = null;
            var clv = ac.NumeroCliente();
            txbClave.Text = clv;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var bnd = Vld();
            if (bnd == 1)
            {
                MessageBox.Show("Error, la validacion no ha sido satisfactoria", "Revisar datos");
                return;
            }
            try
            {
                AltaClientes ac = new AltaClientes();
                ac.CreaCliente(txbClave.Text,
                txbNombre.Text,
                txbDireccion.Text,
                txbColonia.Text,
                txbPoblacion.Text,
                 txbZip.Text,
                txbTel.Text,
                txbRfc.Text,
                txbEmail.Text,
               cmbCor.SelectedValue.ToString(),
               cmbZona.SelectedValue.ToString()
                );


                MessageBox.Show("Alta correcta");

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private int Vld()
        {
            int bnd = 0;
            if (String.IsNullOrWhiteSpace(txbClave.Text) || String.IsNullOrWhiteSpace(txbNombre.Text) || String.IsNullOrWhiteSpace(txbDireccion.Text))
            {
                bnd = 1;
            }
            return bnd;
        }
    }
}
