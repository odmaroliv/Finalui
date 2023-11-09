using Datos.ViewModels;
using Datos.ViewModels.Coord;
using Datos.ViewModels.Entradas;
using Datos.ViewModels.Servicios;
using mainVentana.VistaBill;
using mainVentana.VistaEntrada;
using Negocios;
using Negocios.NGCotizacion;
using Negocios.NGReportes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        private bool _tipoImpresion = false;
        private string sucursalBusqueda;
        public string sGlobal;
        private List<vmEntCordsCot> listaEntsEnCotizacion = new List<vmEntCordsCot>();
        private string nCotizacionG = default;
        private string TaxAFees = default;
        private string totalPesos = default;
        private bool _valAgregarEntradas = false;
        public frmCotizaciones()
        {
            InitializeComponent();
            _valAgregarEntradas = true;
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
        DataTable DatosDataTable = null;
        public async Task<bool> CargaControles()
        {
            string sucursal = sucursalBusqueda;

            List<vmEntCordsCot> dtgDatos = new List<vmEntCordsCot>();

           

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
                            Origen = w.Origen,
                            tOper = w.tOper,
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
        private void EstableceSucursal()
        {
            var name = cmbSucEntrada.SelectedValue?.ToString().Trim();

            if (String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("La sucursal Destino no puede esta bacia");
                return;
            }
            sucursalBusqueda = name.Trim();
        }
        public async Task ejecutaeveto2()
        {
            dtgEnts.DataSource = null;
            bool nada = await CargaControles();

        }

        private bool _isBussy = false;
        private async void gunaTileButton2_Click(object sender, EventArgs e)
        {
            _isBussy = true;
            EstableceSucursal();
            try
            {
                gunaTileButton2.Enabled = false;
                string val = cmbIVA.SelectedItem?.ToString() ?? "";
                if (val == "")
                {
                    MessageBox.Show("Seleccione el IVA");
                    return;
                }
                if (String.IsNullOrEmpty(lblCodCliente.Text))
                {
                    MessageBox.Show("Primero busca el cliente");
                    return;
                }
                else
                {
                    await ejecutaeveto2();
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            { 
                _isBussy = false;
                gunaTileButton2.Enabled = true;
            }


        }

        private void dtgEnts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_valAgregarEntradas == false)
            {
                MessageBox.Show("Ya has comenzado a cotizar\nYa no puedes agregar");
                return;
            }
            if (e.ColumnIndex == 0)
            {
                try
                {
                    string ent = this.dtgEnts.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string valF = this.dtgEnts.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string valA = this.dtgEnts.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string valO = this.dtgEnts.Rows[e.RowIndex].Cells[4].Value.ToString();
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
                                listaEntsEnCotizacion.Add(new vmEntCordsCot { entrada = ent, valFact = valF, valArn = valA, Origen = valO });
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
                                MessageBox.Show("La entrada ya existe en la lista. Se eliminará.");
                                var entryToRemove = listaEntsEnCotizacion.FirstOrDefault(x => x.entrada.Trim() == ent.Trim());
                                listaEntsEnCotizacion.Remove(entryToRemove);
                                txbEntradaACot.Text = string.Join(", ", listaEntsEnCotizacion.Select(x => x.entrada));
                            }
                            suma(listaEntsEnCotizacion);
                            operacion();
                            operacion();
                        }
                    }

                }
                catch (Exception)
                {

                   
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
            txbGoodMnx.Text = res.ToString("F2");


        }

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbMoneda.SelectedValue) == 1)
            {
                try
                {
                    dgvEntradasACotizar.Columns[3].ReadOnly = false;
                    dgvEntradasACotizar.Columns[2].ReadOnly = true;
                    Cargaparidad();
                }
                catch (Exception)
                {

                    MessageBox.Show("la paridad no pudo se encontrada en el diario oficial de la federacion por favor agregela manualmente");
                    txbParidad.Enabled = true;
                }
            }
            else if (Convert.ToInt32(cmbMoneda.SelectedValue) == 2)
            {
                try
                {
                    dgvEntradasACotizar.Columns[3].ReadOnly = true;
                    dgvEntradasACotizar.Columns[2].ReadOnly = false;
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
            if (paridad1 == "ERROR")
            {
                string paridad2 = await datos.GetParidadOtro();
                var paridadJson = JsonConvert.DeserializeObject<JObject>(paridad2);

                if (paridadJson.ContainsKey("rates") && paridadJson["rates"].Type == JTokenType.Object)
                {
                    var rates = paridadJson["rates"].ToObject<JObject>();
                    if (rates.ContainsKey("MXN") && rates["MXN"].Type == JTokenType.Float)
                    {
                        double valorMXN = rates["MXN"].ToObject<double>();
                        vParidad = Convert.ToDecimal(Math.Truncate(valorMXN * 100) / 100); // Limitar a dos decimales sin redondear
                        txbParidad.Text = !string.IsNullOrEmpty(vParidad.ToString()) ? decimal.Parse(vParidad.ToString()).ToString("N2") : string.Empty; ; 
                        return;
                    }
                }

                if (MessageBox.Show("No pudimos acceder a la paridad del Diario Oficial de la Federación \r(Si es fin de semana los servicios de DOF no funcionan )\rAl hacer click te redireccionare a la pagina oficial para establecerla manualmente", "No paridad automatica", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
                {
                    Process.Start("https://dof.gob.mx/indicadores.php");
                }
                txbParidad.Enabled = true;
            }
            else
            {
                var lst = JsonConvert.DeserializeObject<Root>(paridad1);

                var lista = from d in lst.ListaIndicadores.Where(c => c.codTipoIndicador == 158)
                            select new ListaIndicadore
                            {
                                valor = d.valor
                            };

                if (lista.Count() <= 0)
                {
                    string paridad2 = await datos.GetParidadOtro();
                    var paridadJson = JsonConvert.DeserializeObject<JObject>(paridad2);

                    if (paridadJson.ContainsKey("rates") && paridadJson["rates"].Type == JTokenType.Object)
                    {
                        var rates = paridadJson["rates"].ToObject<JObject>();
                        if (rates.ContainsKey("MXN") && rates["MXN"].Type == JTokenType.Float)
                        {
                            double valorMXN = rates["MXN"].ToObject<double>();
                            vParidad = Convert.ToDecimal(Math.Truncate(valorMXN * 100) / 100); // Limitar a dos decimales sin redondear
                            txbParidad.Text = !string.IsNullOrEmpty(vParidad.ToString()) ? decimal.Parse(vParidad.ToString()).ToString("N2") : string.Empty; ;
                            return;
                        }
                    }

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
                        vParidad = Convert.ToDecimal(Math.Truncate(Convert.ToDouble(i.valor) * 100) / 100); // Limitar a dos decimales sin redondear
                        txbParidad.Text = !string.IsNullOrEmpty(vParidad.ToString()) ? decimal.Parse(vParidad.ToString()).ToString("N2") : string.Empty;
                    }
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

            /*DataGridViewRow nuevaFila2 = new DataGridViewRow();
            nuevaFila2.CreateCells(dgvEntradasACotizar);
            nuevaFila2.Cells[0].Value = "License and permits Fees";
            nuevaFila2.Cells[1].Value = "0";
            nuevaFila2.Height = 50;
            dgvEntradasACotizar.Rows.Add(nuevaFila2);*/

            DataGridViewRow nuevaFila3 = new DataGridViewRow();
            nuevaFila3.CreateCells(dgvEntradasACotizar);
            nuevaFila3.Cells[0].Value = "Freight Insurance";
            nuevaFila3.Cells[1].Value = "0";
            nuevaFila3.Height = 50;
            dgvEntradasACotizar.Rows.Add(nuevaFila3);


        }

        private void frmCotizaciones_Load(object sender, EventArgs e)
        {
            lblTipoImp.Text = "AD";
            if (String.IsNullOrWhiteSpace(sGlobal))
            {
                MessageBox.Show("No se establecio una Sucursal Global");
                this.Dispose();
                this.Close();
            }
            else
            {
                lblSuc.Text = sGlobal;
                lblNoCot.Text = CargaUltCot();
                lblFechaHoy.Text = DateTime.Now.ToString("MM/dd/yyyy");
                Moneda();
                Cargaparidad();
                AgregaDatosDGV();
                LlenaTipoDePago();
            }
            try
            {
                vParidad = String.IsNullOrWhiteSpace(txbParidad.Text) ? 0 : decimal.Parse(txbParidad.Text.Trim());
                vParidad = decimal.Truncate(vParidad * 100) / 100;

            }
            catch (Exception)
            {

                MessageBox.Show("Hay un probla al obtener la paridad");
                txbParidad.Enabled = true;
            }
            finally
            {
                if (vParidad > 90)
                {
                    MessageBox.Show("La paridad parece estar mal, habilitaremos el campo de manera manual\nIntroduce solo 2 decimales separados por PUNTO, ejemplo:\n19.50");
                    txbParidad.Enabled = true;
                }
            }
             Task.Run(() => CargaSOrigen()); 


        }
        private void CargaSOrigen()
        {
            Servicios datos = new Servicios();
            var lst2 = datos.llenaSuc();


            // Utilizamos Invoke para actualizar la UI de manera segura desde un hilo secundario
            this.Invoke(new Action(() =>
            {
                cmbSucEntrada.DisplayMember = "C2";
                cmbSucEntrada.ValueMember = "C1";
                cmbSucEntrada.DataSource = lst2;
                foreach (var i in from Sucursales i in cmbSucEntrada.Items select i)
                {
                    cmbSucEntrada.SelectedValue = i.c1;
                    break;
                }

            }));

            datos = null;
        }
        private void LlenaTipoDePago()
        {
            Servicios datos = new Servicios();

            var lst2 = datos.LlenaTipoDePago();
            cmbTipoPago.DisplayMember = "C2";
            cmbTipoPago.ValueMember = "C1";
            cmbTipoPago.DataSource = lst2;
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
            operacion();
            operacion();
        }

        private decimal vMercanciaUSD;
        private decimal vParidad;

        private void dgvEntradasACotizar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
            if (_isBussy == false)
            {
              
                try
                {
                    vMercanciaUSD = String.IsNullOrWhiteSpace(txbGoodUsd.Text) ? 0 : decimal.Parse(txbGoodUsd.Text);



                    if (_valAgregarEntradas == true)
                    {
                        if (MessageBox.Show("Comenzaremos a cotizar\nYa no agregaras mas entradas?", "Validar", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            _valAgregarEntradas = false;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(txbGoodUsd.Text))
                    {
                        try
                        {
                            _isBussy = true;
                            if (e.ColumnIndex == 1)
                            {
                                DataGridViewRow currentRow = dgvEntradasACotizar.Rows[e.RowIndex];
                                decimal valorColumna1 = decimal.Parse(currentRow.Cells[1].Value == null ? "0" : currentRow.Cells[1].Value.ToString());

                                decimal porcentaje = (valorColumna1 * vMercanciaUSD) / 100;
                                currentRow.Cells[2].Value = !string.IsNullOrEmpty(porcentaje.ToString()) ? decimal.Parse(porcentaje.ToString()).ToString("N2") : string.Empty;  
                                decimal dtoPorPorPari = (porcentaje * vParidad);
                                currentRow.Cells[3].Value = !string.IsNullOrEmpty(dtoPorPorPari.ToString()) ? decimal.Parse(dtoPorPorPari.ToString()).ToString("N2") : string.Empty; 

                                operacion();
                                operacion();
                                //return;
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        finally
                        {
                            _isBussy = false;
                        }
                        try
                        {
                            _isBussy = true;
                            if (e.ColumnIndex == 2)
                            {
                                DataGridViewRow currentRow = dgvEntradasACotizar.Rows[e.RowIndex];
                                decimal valorColumna2 = decimal.Parse(currentRow.Cells[2].Value == null ? "0" : currentRow.Cells[2].Value.ToString());

                                decimal porcentaje = (valorColumna2 * vParidad);
                                currentRow.Cells[1].Value = "0";
                                currentRow.Cells[3].Value = !string.IsNullOrEmpty(porcentaje.ToString()) ? decimal.Parse(porcentaje.ToString()).ToString("N2") : string.Empty;  ;
                                operacion();
                                operacion();
                                //   return;
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        finally
                        {
                            _isBussy = false;
                        }
                        try
                        {
                            _isBussy = true;
                            if (e.ColumnIndex == 3)
                            {
                                DataGridViewRow currentRow = dgvEntradasACotizar.Rows[e.RowIndex];
                                decimal valorColumna2 = decimal.Parse(currentRow.Cells[3].Value == null ? "0" : currentRow.Cells[3].Value.ToString());

                                decimal porcentaje = (valorColumna2 / vParidad);
                                currentRow.Cells[1].Value = "0";
                                currentRow.Cells[2].Value = porcentaje.ToString("N2");
                                operacion();
                                operacion();
                                //   return;
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        finally
                        {
                            _isBussy = false;
                        }

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Algo salio mal, verifica los datos ingresados");
                }
                finally
                {
                    _isBussy = false;
                }
            }

        }

        private void operacion()
        {
            try
            {
                decimal sumatoria = 0;
                for (int i = 0; i < dgvEntradasACotizar.Rows.Count; i++)
                {
                    sumatoria += decimal.Parse(dgvEntradasACotizar.Rows[i].Cells[2].Value == null ? "0" : dgvEntradasACotizar.Rows[i].Cells[2].Value.ToString());
                }
               
                decimal submenosdesc = sumatoria - descuentoGlobal;
                txbSubTo.Text = !string.IsNullOrEmpty(submenosdesc.ToString()) ? decimal.Parse(submenosdesc.ToString()).ToString("N2") : string.Empty; 
                string datoGuardaSubT = (submenosdesc * vParidad).ToString("F2");
                txbSubTomxn.Text = !string.IsNullOrEmpty(datoGuardaSubT) ? decimal.Parse(datoGuardaSubT).ToString("N2") : string.Empty;

                TaxesCalc();
                GrandCalc();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error, es problable que la paridad/tipo de cambio este incorrecta o vacia.");
                txbParidad.Enabled = true;
                txbParidad.Focus();
            }
        }

        private void GrandCalc()
        {
            try
            {
                decimal vIva = (decimal.Parse(String.IsNullOrWhiteSpace(txbIva.Text) ? "0" : txbIva.Text.ToString()));
                decimal vSerTax = (decimal.Parse(String.IsNullOrWhiteSpace(txbSubTo.Text) ? "0" : txbSubTo.Text.ToString()));
               // decimal vDescuento = decimal.Parse(String.IsNullOrWhiteSpace(txbDescuento.Text) ? "0" : txbDescuento.Text.ToString().Trim());
               
                decimal resultPayArn = (vIva + vSerTax);
                txbTotalArn.Text = !string.IsNullOrEmpty(resultPayArn.ToString()) ? decimal.Parse(resultPayArn.ToString()).ToString("N2") : string.Empty; 
                decimal resul = vMercanciaUSD + vIva + vSerTax;
                txbSubServAndFees.Text = !string.IsNullOrEmpty(resul.ToString()) ? decimal.Parse(resul.ToString()).ToString("N2") : string.Empty; 

                CalcIva(vSerTax);
                decimal resultPayArnMX = resultPayArn * vParidad;
                string totalPesos = !string.IsNullOrEmpty(resultPayArnMX.ToString()) ? decimal.Parse(resultPayArnMX.ToString()).ToString("N2") : string.Empty;

                txbTotalArnMXN.Text = !string.IsNullOrEmpty(totalPesos.ToString()) ? decimal.Parse(totalPesos.ToString()).ToString("N2") : string.Empty; ;
                
            }
            catch (Exception)
            {
                MessageBox.Show("Algo salió mal durante el cálculo del total, verifica los datos ingresados.");
            }
        }

        private void CalcIva(decimal subTotal)
        {
            try
            {
                decimal vIva = (decimal.Parse(cmbIVA.SelectedItem == null ? "0" : cmbIVA.SelectedItem.ToString()) / 100);
                decimal oper = vIva * subTotal;
                txbIva.Text = !string.IsNullOrEmpty(oper.ToString()) ? decimal.Parse(oper.ToString()).ToString("N2") : string.Empty; ;
            }
            catch (Exception)
            {
                MessageBox.Show("Algo salió mal durante el cálculo del IVA, verifica los datos ingresados.");
            }
        }

        private void TaxesCalc()
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txbEntradaACot.Text))
                {
                    List<decimal> lst = new List<decimal>();
                    decimal sumatoriaTaxes = 0;
                    decimal sumatoriaFees = 0;
                    foreach (DataGridViewRow item in dgvEntradasACotizar.Rows)
                    {
                        string valorNombre = dgvEntradasACotizar.Rows[item.Index].Cells[0].Value.ToString();
                        decimal valorDato = dgvEntradasACotizar.Rows[item.Index].Cells[2].Value == null ? 0 : decimal.Parse(dgvEntradasACotizar.Rows[item.Index].Cells[2].Value.ToString());
                        if (valorNombre.Contains("IGI") || valorNombre.Contains("DTA") || valorNombre.Contains("PREV") || valorNombre.Contains("CNT") || valorNombre.Contains("Others TAXES"))
                        {
                            sumatoriaTaxes += valorDato;
                        }
                        else
                        {
                            sumatoriaFees += valorDato;
                        }
                    }
                    decimal sumatoriaTaxesRound = sumatoriaTaxes;
                    decimal sumatoriaFeesRound = sumatoriaFees;
                    txbSumOTax.Text = sumatoriaTaxesRound.ToString("F2");
                    txbSerFee.Text = sumatoriaFeesRound.ToString("F2");
                    TaxAFees = sumatoriaTaxesRound.ToString("F2");
                }
                else
                {
                    MessageBox.Show("No has agregado entradas a la cotizacion");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Algo salió mal durante el cálculo de los impuestos, verifica los datos ingresados.");
            }
        }








        private void dtgEnts_FilterStringChanged(object sender, EventArgs e)
        {
            
                using (BindingSource aada = new BindingSource())
                {
                    aada.DataSource = DatosDataTable;
                    aada.Filter = dtgEnts.FilterString;
                }

            
        }

        private void dtgEnts_SortStringChanged(object sender, EventArgs e)
        {
            using (BindingSource aada = new BindingSource())
            {
                aada.DataSource = DatosDataTable;
                aada.Sort = dtgEnts.SortString;
            }
        }

        private async void aloneButton1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(lblCodCliente.Text))
            {
                if (!String.IsNullOrWhiteSpace(txbEntradaACot.Text) || SwitchAlmacenaje.Checked == true)
                {
                    if (!String.IsNullOrWhiteSpace(txbParidad.Text))
                    {
                        await AltaKDM1();
                        using (frmBuscarCotizacion cot = new frmBuscarCotizacion())
                        {
                            //cot.sGlobal = Negocios.Common.Cache.CacheLogin.sucGlobal;
                            cot.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay ninguna entrada seleccionada");
                }
            }
            else
            {
                MessageBox.Show("No hay ningun cliente seleccionado");
            }
        }
        private string CargaUltCot()
        {
            string cotizacion = "";
            string datoSucIni = sGlobal;
            accesoCotizaciones datos = new accesoCotizaciones();

            foreach (var i in datos.UltimaCotizacion(datoSucIni, 34))
            {
                int numero = Convert.ToInt32(i.noCot);
                cotizacion = numero.ToString("D7");
            }
            nCotizacionG = cotizacion.ToString().Trim();
            return cotizacion != "" || cotizacion == null ? cotizacion.ToString().Trim() : "";
        }
        private async Task AltaKDM1()
        {
            try
            {
                CargaUltCot();
                 AltasCotizacion alta = new AltasCotizacion();

            bool dtAlt = await alta.CreaCotizacionKDM1(sGlobal, nCotizacionG, DateTime.Now, lblCodCliente.Text.Trim(),
                    0, decimal.Parse(txbIva.Text), decimal.Parse(txbTotalArn.Text), DateTime.Now, cmbTipoPago.GetItemText(cmbTipoPago.SelectedItem).ToString(), cliente.Text.Trim(), "", "", "", float.Parse(txbParidad.Text.Trim()),
                    decimal.Parse(txbSubTo.Text), "N", Negocios.Common.Cache.CacheLogin.nombre, DateTime.Now, txbGoodUsd.Text, txbGoodMnx.Text, txbReferencia.Text, txbTotalArn.Text, txbSerFee.Text, txbTotalArnMXN.Text, TaxAFees, txbComent.Text, txbPedimento.Text, lblTipoImp.Text, descuentoGlobal.ToString());
                alta.ActualizaSqlIov(sGlobal, 34, nCotizacionG);

                if (dtAlt == false)
                {
                    MessageBox.Show("Al parecer hubo un problema, vuelve a intentarlo, si ya lo hiciste y aun continuas sin lograr crear la cotización, cominicate con el dep. de Sistemas.");
                    CargaUltCot();
                    return;
                }
                
                await AltaKDMENT();
                AltaKDM2();
                Clipboard.SetText(nCotizacionG);
                MessageBox.Show("La Cotizacion " + nCotizacionG + " se ha realizado con exito, se ha copiado el numero en el porta papeles, CTRL V", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Dispose();
                this.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error, por favor verifica que la tabla no tenga filas que no se usan","Ocurrio un error");
                Clipboard.SetText(e.Message);
            }

        }


        private async void AltaKDM2()
        {
            AltasCotizacion alta = new AltasCotizacion();

            var rows = RecuperaData();
            foreach (var i in rows)
            {
                decimal mxn = !string.IsNullOrEmpty(i.MXN) ? decimal.Parse(i.MXN) : 0;
                decimal usCharges = !string.IsNullOrEmpty(i.usCharges) ? decimal.Parse(i.usCharges) : 0;
                await alta.CreaCotizacionKDM2(sGlobal, nCotizacionG, i.Fila, i.Descripción, mxn, usCharges, cmbIVA.SelectedItem == null ? "0": cmbIVA.SelectedItem.ToString(), lblCodCliente.Text.Trim(), DateTime.Now, i.Porcentaje);
            }

        }
        private async Task AltaKDMENT()
        {
            AltasCotizacion alta = new AltasCotizacion();
            string cotCompleta = lblSuc.Text.Trim() +"-"+ nCotizacionG;
           bool rs = await alta.ModificaKDM1Cotiza(listaEntsEnCotizacion, cotCompleta);
            if (!rs)
            {
                MessageBox.Show("La cotización no se creo, no podras imprimirla, solamente se guardo sin entradas, por favor avisa a Sistemas");
                return;
            }

        }

        private List<vmTablaCotizacion> RecuperaData()
        {
            List<vmTablaCotizacion> lista = new List<vmTablaCotizacion>();
            int noFila = 1;
            foreach (DataGridViewRow fila in dgvEntradasACotizar.Rows)
            {

                lista.Add(new vmTablaCotizacion
                {
                    Fila = noFila,
                    Descripción = fila.Cells[0].Value != null ? fila.Cells[0].Value.ToString() : "",
                    Porcentaje = fila.Cells[1].Value != null ? fila.Cells[1].Value.ToString() : "",
                    usCharges = fila.Cells[2].Value != null ? fila.Cells[2].Value.ToString() : "",
                    MXN = fila.Cells[3].Value != null ? fila.Cells[3].Value.ToString() : "",
                });
                noFila = noFila + 1;
            }
            return lista;
        }

        private void cmbIVA_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIVA.Enabled = false;
            operacion();
            operacion();
        }


        private void SwitchAdd_CheckedChanged(object sender, EventArgs e)
        {

            if (SwitchAdd.Checked == false)
            {
                _tipoImpresion = false;
                lblTipoImp.Text = "AD";
                txbParidad.Enabled = false;
            }
            else
            {
                _tipoImpresion = true;
                lblTipoImp.Text = "IMP";
                txbParidad.Enabled = true;
            }
        }


        decimal descuentoGlobal = 0;
        private void txbDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                decimal vDescuento = decimal.Parse(String.IsNullOrWhiteSpace(txbDescuento.Text) ? "0" : txbDescuento.Text.ToString().Trim());
                descuentoGlobal = vDescuento;
                operacion();
                operacion();

            }
        }

        private void txbParidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                { 
                    vParidad = String.IsNullOrWhiteSpace(txbParidad.Text) ? 0 : decimal.Parse(txbParidad.Text.Trim());
                    vParidad = decimal.Truncate(vParidad * 100) / 100;
                    MessageBox.Show("Tipo de cambio modificado");
                }
                catch (Exception)
                {

                    throw;
                }
               


            }
        }

        private void SwitchAlmacenaje_CheckedChanged(object sender, EventArgs e)
        {
            if (SwitchAlmacenaje.Checked == false)
            {
                //_tipoImpresion = false;
                lblTipoImp.Text = "AD";
                SwitchAdd.Checked = false;
                SwitchAdd.Enabled = true;
                //  txbParidad.Enabled = false;
            }
            else
            {
                // _tipoImpresion = true;
                lblTipoImp.Text = "ALM";
                SwitchAdd.Enabled = false;
                txbGoodMnx.Text = "0";
                txbGoodUsd.Text = "0";
                // txbParidad.Enabled = true;
            }
        }
    }
}
