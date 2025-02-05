using Datos.Datosenti;
using Datos.ViewModels;
using Datos.ViewModels.Entradas;
using DocumentFormat.OpenXml.Presentation;
using Guna.UI.WinForms;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.TraspasoMercancias
{
    public partial class MovimientoMercanciaView : Form
    {
        public string sucursalGlobal = Negocios.Common.Cache.CacheLogin.sucGlobal == default ? "SD" : Negocios.Common.Cache.CacheLogin.sucGlobal;
        private Servicios datos = new Servicios();
        private string _chekado = default;
        private bool isLoadSubSucCalled = false;
        public MovimientoMercanciaView()
        {
            InitializeComponent();
        }

        private void MovimientoMercanciaView_Load(object sender, EventArgs e)
        {
           // llenaCampos();
        }


        private async void llenaCampos()
        {
            try
            {
        
            }
            catch(Exception ex)
            {
                if (ex is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        // Acceder a los Entity Validation Errors
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "MovimientoMercancia.LlenaCampos().. ");
                        }
                    }
                }
                throw;
            }
        }


        private void LlenarComboBoxSucursales(IEnumerable<object> listaSucursales)
        {
            cmbSucOrigen.SelectedIndexChanged -= cmbSucOrigen_SelectedIndexChanged;
            // Comprobamos si la lista está vacía
            if (!listaSucursales.Any()) return;

            // Obtenemos el primer objeto de la lista
            var primerObjeto = listaSucursales.First();

            // Configuramos la fuente de datos
            cmbSucOrigen.DataSource = listaSucursales;

            // Verificamos si el primer objeto es de tipo Sucursales
            if (primerObjeto is Sucursales)
            {
                cmbSucOrigen.DisplayMember = "C2";
                cmbSucOrigen.ValueMember = "C1";
            }
            // Verificamos si el primer objeto es de tipo SubSucursal
            else if (primerObjeto is SubSucursales)
            {
                cmbSucOrigen.DisplayMember = "SubSucursal";
                cmbSucOrigen.ValueMember = "SubID";
            }
            cmbSucOrigen.SelectedIndexChanged += cmbSucOrigen_SelectedIndexChanged;

        }


        /// <summary>
        /// Modo 1 = busca sucursales padre
        /// Modo 0 = busca sub=sucursales 
        /// </summary>
        /// <param name="modo"></param>
        private async Task LoadSubSuc(int modo)
        {
            if (modo == 0)
            {
                if (!radioButton1.Checked && !radioButton2.Checked)
                {
                    return;
                }
                if (isLoadSubSucCalled) return;
                string datoSucIni = cmbSucOrigen.SelectedValue?.ToString()?.Trim();
                if (String.IsNullOrWhiteSpace(datoSucIni)) return;
                var lstSubs = await datos.llenaSubSuc(true, datoSucIni);
                if (lstSubs.Count <= 0) { cmbSucDestino.DataSource = null; return; }
                cmbSucDestino.DataSource = lstSubs;
                cmbSucDestino.DisplayMember = "SubSucursal";
                cmbSucDestino.ValueMember = "SubID";

                isLoadSubSucCalled = true;
            }
            else if (modo == 1)
            {
                if (!radioButton1.Checked && !radioButton2.Checked)
                {
                    return;
                }
                if (isLoadSubSucCalled) return;
                string datoSucIni = cmbSucOrigen.SelectedValue?.ToString()?.Trim();
                if (String.IsNullOrWhiteSpace(datoSucIni)) return;
                var lstSubs = await datos.llenaSuc();
                if (lstSubs.Count <= 0) 
                { cmbSucDestino.DataSource = null; return; }
                cmbSucDestino.DataSource = lstSubs;
                cmbSucDestino.DisplayMember = "c2";
                cmbSucDestino.ValueMember = "C1";
                
                isLoadSubSucCalled = true;

            }
           

        }
       

        private void cmbSucOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            isLoadSubSucCalled = false;
            if (radioButton1.Checked)
            {
                LoadSubSuc(0);
            }
            else
            {
                LoadSubSuc(1);

            }
            
        }

        /// <summary>
        /// Funcion que evalua que tipo de movimiento sera, 0 a 1 o 1 a 0
        /// 0 = Principal a Sub
        /// 1 = Sub a Principal
        /// </summary>
        /// <param name="sender">Es el objeto con sus propiedades accesibles como el Tag</param>
        /// <param name="e"></param>
        private async void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            cmbSucDestino.DataSource = null;
            cmbSucOrigen.DataSource = null; 
            isLoadSubSucCalled = false;
            RadioButton chk = (RadioButton)sender;
            if (_chekado == chk.Tag.ToString())
            {
                return;
            }
            _chekado = chk.Tag.ToString();
           
            //if (chk.Checked == false) return;

            if (chk.Tag.ToString()=="0")
            {
                cmbSucDestino.DataSource = null;
                var lst2 = await datos.llenaSuc();
                LlenarComboBoxSucursales(lst2);
            }
            else
            {
                var lst2 = await datos.llenaSubSuc(false);
                LlenarComboBoxSucursales(lst2);
                LoadSubSuc(0);
            }
            
        }

        private void btnScanini_Click(object sender, EventArgs e)
        {
            int error = ValidacionesGenerales(); //1 error o 0 normal



            if (error == 1)
            {
                return;
            }

            if (MessageBox.Show("Estas apunto de iniciar el Scaneo", "Atencion", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                cmbSucOrigen.Enabled = false; 
                cmbSucDestino.Enabled = false;
                gunaGroupBox3.Enabled = false;
                txbEscaneo.Enabled = true;
                txbEscaneo.Focus();

            }
        }

       
        private int ValidacionesGenerales()
        {
            int error = 0;
           
         
            if (String.IsNullOrWhiteSpace(cmbSucOrigen.SelectedValue?.ToString()?.Trim()) || String.IsNullOrWhiteSpace(cmbSucDestino.SelectedValue?.ToString()?.Trim()) ) 
            {
                MessageBox.Show("Primero tienes que llenar las sucursales");
                error = 1;
            }
            return error;
        }

        private void btnIniciaSalida_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciaSalida_Click_1(object sender, EventArgs e)
        {
            int error = ValidacionesGenerales(); //1 error o 0 normal



            if (error == 1)
            {
                return;
            }
        }
    }
}


