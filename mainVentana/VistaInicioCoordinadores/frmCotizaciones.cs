using Datos.ViewModels.Coord;
using Datos.ViewModels.Entradas;
using Datos.ViewModels.Servicios;
using mainVentana.VistaEntrada;
using Negocios;
using Negocios.NGReportes;
using Newtonsoft.Json;
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

namespace mainVentana.VistaInicioCoordinadores
{

    public partial class frmCotizaciones : Form
    {

        private List<vmEntCordsCot> listaEntsEnCotizacion = new List<vmEntCordsCot>();

        public frmCotizaciones()
        {
            InitializeComponent();
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
        string coreoClientes;
        public void moverinfo(string dato, string dato2, string dato3, string dato4, string dato5, string dato6, string dato7, string correoCliente, int bandera) //cambia los datos de los textbox alias y clientes, la bandera dependera de la manera en la que se haya abierto el frm buscar, 0 clientes 1 alias, ADEMAS tambien sirve para cambiar el campo de cord
        {
            coreoClientes = correoCliente;
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

        public async Task<bool> CargaControles()
        {
            string sucursal = default;
            DataTable DatosDataTable = null;
            List<vmEntCordsCot> dtgDatos = new List<vmEntCordsCot>();

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

            List<vmEntCordsCot> lss = new List<vmEntCordsCot>();
            lss.Clear();
            ngbdReportes rep = new ngbdReportes();
            lss = await rep.CargaEntToCot(sucursal, lblCodCliente.Text.Trim());

            if (dtgDatos != null)
            {
                dtgDatos.Clear();
            }



            var listanoduplies = new HashSet<string>(lss.Select(s => s.entrada)).ToList();
            foreach (var q in listanoduplies)
            {
                foreach (var w in lss)
                {
                    if (w.entrada.Trim() == q.Trim())
                    {
                        dtgDatos.Add(new vmEntCordsCot
                        {
                            entrada = w.entrada,
                            valArn = w.valArn,
                            valFact = w.valFact,
                        });

                        break;
                    }
                    else
                    {

                    }

                }

            }



            if (dtgDatos.Count > 0)
            {
                DataTable tb = VistaInicioCoordinadores.dataFilter.ConvierteADatatable3(dtgDatos);

                DatosDataTable = tb;
                dtgEnts.DataSource = DatosDataTable;


            }
            else
            {
                dtgEnts.DataSource = null;
            }

            return true;




        }
        public async Task ejecutaeveto2()
        {
            dtgEnts.DataSource = null;
            bool nada = await CargaControles();

        }


        private async void gunaTileButton2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(lblCodCliente.Text))
            {
                MessageBox.Show("Primero busca el cliente");
            }
            else
            {
                await ejecutaeveto2();
            }

        }

        private void dtgEnts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                string ent = this.dtgEnts.Rows[e.RowIndex].Cells[1].Value.ToString();
                string valF = this.dtgEnts.Rows[e.RowIndex].Cells[2].Value.ToString();
                string valA = this.dtgEnts.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (this.dtgEnts.Rows[e.RowIndex].Cells[1].Value == null)
                {
                    MessageBox.Show("Ningun archivo seleccionado");
                    return;
                }
                if (MessageBox.Show("Seguro que quieres agregar la entrada: " + this.dtgEnts.Rows[e.RowIndex].Cells[1].Value.ToString(), "Cuidado!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (this.dtgEnts.Rows.Count > 0)
                    {
                        if (!listaEntsEnCotizacion.Any(x => x.entrada.Trim() == ent.Trim()))
                        {
                            listaEntsEnCotizacion.Add(new vmEntCordsCot { entrada = ent, valFact = valF, valArn = valA });
                            if (String.IsNullOrEmpty(txbEntradaACot.Text))
                            {
                                txbEntradaACot.Text = ent;
                            }
                            else
                            {
                                txbEntradaACot.Text += ", " + ent;
                            }

                        }
                        else
                        {
                            MessageBox.Show("La entrada ya existe en la lista");
                        }
                        suma(listaEntsEnCotizacion);
                    }
                }


            }

        }

        private void suma(List<vmEntCordsCot> lista)
        {
            decimal suma = 0;
            foreach (var i in lista)
            {
                decimal numVal = Convert.ToDecimal(String.IsNullOrWhiteSpace(i.valFact) ? "0" : i.valFact);
                suma = suma + numVal;
            }


            txbGoodUsd.Text = suma.ToString();

            decimal vMercanciaUSD = decimal.Parse(String.IsNullOrWhiteSpace(suma.ToString()) ? "0" : suma.ToString());
            decimal vParidad = decimal.Parse(String.IsNullOrWhiteSpace(txbParidad.Text) ? "0" : txbParidad.Text.ToString().Trim());

            decimal res = vMercanciaUSD * vParidad;
            txbGoodMnx.Text = Math.Round(res,2).ToString(); 

        }

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbMoneda.SelectedValue) == 1)
            {
                txbParidad.Text = "";
            }
            else if (Convert.ToInt32(cmbMoneda.SelectedValue) == 2)
            {
                try
                {
                    Cargaparidad();
                }
                catch (Exception)
                {

                    MessageBox.Show("la paridad no pudo se encontrada en el diario oficial de la federacion por favor agregela manualmente");
                    txbParidad.Enabled = true;
                }

            }
        }
        public async void Cargaparidad()
        {
            Servicio datos = new Servicio();
            string paridad1 = await datos.GetParidad();
            var lst = JsonConvert.DeserializeObject<Root>(paridad1);

            //var lst = JsonConvert.DeserializeObject<List<Paridad>>(paridad1);
            //Paridad lst = JsonConvert.DeserializeObject<ListParidad>>(paridad1);

            var lista = from d in lst.ListaIndicadores.Where(c => c.codTipoIndicador == 158)

                        select new ListaIndicadore
                        {
                            valor = d.valor

                        };

            if (lista.Count() <= 0)
            {
                if (MessageBox.Show("No pudimos acceder a la paridad del Diario Oficial de la Federación \r(Si es fin de semana los servicios de DOF no funcionan )\rAl hacer click te redireccionare a la pagina oficial para establecerla manualmente", "No paridad automatica", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
                {
                    Process.Start("https://dof.gob.mx/indicadores.php");
                }
                txbParidad.Enabled = true;
            }
            else
            {


                foreach (var i in lista.ToList())
                {
                    txbParidad.Text = i.valor.ToString();
                }
            }



        }
        private void Moneda()
        {
            List<Moneda> mnd = new List<Moneda> {
                         new Moneda{id=2,moneda="DLLS"},
                         new Moneda{id=1,moneda="PESOS"}};

            var lista = from d in mnd
                        select new Moneda
                        {
                            id = d.id,
                            moneda = d.moneda

                        };
            lista = lista.ToList();

            cmbMoneda.DisplayMember = "moneda";
            cmbMoneda.ValueMember = "id";
            cmbMoneda.DataSource = lista;

        }


        private void AgregaDatosDGV()
        {
            

            DataGridViewRow nuevaFila = new DataGridViewRow();
            nuevaFila.CreateCells(dgvEntradasACotizar);
            nuevaFila.Cells[0].Value = "Arnian Fees";
            nuevaFila.Cells[1].Value = "0";
            nuevaFila.Height = 50;
            dgvEntradasACotizar.Rows.Add(nuevaFila);

            DataGridViewRow nuevaFila2 = new DataGridViewRow();
            nuevaFila2.CreateCells(dgvEntradasACotizar);
            nuevaFila2.Cells[0].Value = "License and permits Fees";
            nuevaFila2.Cells[1].Value = "0";
            nuevaFila2.Height = 50;
            dgvEntradasACotizar.Rows.Add(nuevaFila2);

            DataGridViewRow nuevaFila3 = new DataGridViewRow();
            nuevaFila3.CreateCells(dgvEntradasACotizar);
            nuevaFila3.Cells[0].Value = "Freight Insurance";
            nuevaFila3.Cells[1].Value = "0";
            nuevaFila3.Height = 50;
            dgvEntradasACotizar.Rows.Add(nuevaFila3);


        }

        private void frmCotizaciones_Load(object sender, EventArgs e)
        {
            Moneda();
            Cargaparidad();
            AgregaDatosDGV();
        
            }

        private void gunaGoogleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            Guna.UI.WinForms.GunaGoogleSwitch sw = (Guna.UI.WinForms.GunaGoogleSwitch)sender;
            if (sw.Checked == true)
            {
                DataGridViewRow nf = new DataGridViewRow();
                nf.CreateCells(dgvEntradasACotizar);
                nf.Cells[0].Value = sw.Tag.ToString();
                nf.Cells[1].Value = "0";
                nf.Height = 50;
                dgvEntradasACotizar.Rows.Add(nf);
            }
            if (sw.Checked == false)
            {
                for (int i = 0; i < dgvEntradasACotizar.Rows.Count; i++)
                {
                    if (dgvEntradasACotizar.Rows[i].Cells[0].Value.ToString() == sw.Tag.ToString())
                    {
                        dgvEntradasACotizar.Rows.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void dgvEntradasACotizar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txbGoodUsd.Text))
            {
                if (e.ColumnIndex == 1)
                {
                    DataGridViewRow currentRow = dgvEntradasACotizar.Rows[e.RowIndex];

                    decimal valorColumna1 = decimal.Parse(String.IsNullOrWhiteSpace(currentRow.Cells[1].Value.ToString()) ? "0" : currentRow.Cells[1].Value.ToString());
                    decimal vMercanciaUSD = decimal.Parse(String.IsNullOrWhiteSpace(txbGoodUsd.Text) ? "0" : txbGoodUsd.Text);

                    decimal porcentaje = (valorColumna1 * vMercanciaUSD) / 100;
                    currentRow.Cells[2].Value = porcentaje;

                    decimal sumatoria = 0;
                    for (int i = 0; i < dgvEntradasACotizar.Rows.Count; i++)
                    {
                        sumatoria += decimal.Parse(dgvEntradasACotizar.Rows[i].Cells[2].Value == null ? "0" : dgvEntradasACotizar.Rows[i].Cells[2].Value.ToString());
                    }
                    txbSubTo.Text = sumatoria.ToString();

                    decimal vParidad = decimal.Parse(String.IsNullOrWhiteSpace(txbParidad.Text) ? "0" : txbParidad.Text.ToString().Trim());

                    txbSubTomxn.Text = Math.Round((sumatoria * vParidad), 2).ToString(); 

                }
                //Hacer la sumatoria de la columna 3 y establecer el valor en txbSubTo.Text

            }

        }
    }
}
