using Datos.ViewModels;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.vistaConfiguraciones
{
    public partial class frmNuevoUsuario : Form
    {
        public string sucursalGlobal = Negocios.Common.Cache.CacheLogin.sucGlobal == default ? "SD" : Negocios.Common.Cache.CacheLogin.sucGlobal;
        public frmNuevoUsuario()
        {
            InitializeComponent();
        }

        private void frmNuevoUsuario_Load(object sender, EventArgs e)
        {
            LlenaDatos();
        }

        private void LlenaDatos()
        {
            Servicios datos = new Servicios();

            //LLenado de los CoboBox de las sucursales
            var lst2 = datos.llenaSuc();
            var lst2_2 = new List<Sucursales>(lst2);

            cmbSucOrigen.DisplayMember = "C2";
            cmbSucOrigen.ValueMember = "C1";
            cmbSucOrigen.DataSource = lst2;
            foreach (var i in from Sucursales i in cmbSucOrigen.Items
                              where i.c1.Trim() == sucursalGlobal.Trim()
                              select i)
            {
                cmbSucOrigen.SelectedValue = i.c1;
                break;
            }
        }

    }
}
