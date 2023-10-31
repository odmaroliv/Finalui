using Negocios;
using Negocios.NGReportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace mainVentana.Reportes.Coords
{
    public partial class frmReporteClientesxCord : Form
    {
        public frmReporteClientesxCord()
        {
            InitializeComponent();
        }

        private async void frmReporteClientesxCord_Load(object sender, EventArgs e)
        {
            await inicia();
        }
        private async Task inicia()
        {
            Servicios datos = new Servicios();

            var lst1 = await datos.llenaCord();
            cord.ValueMember = "C2";
            cord.DisplayMember = "C3";
            cord.DataSource = lst1;
        }

        private async void btnAlta_Click(object sender, EventArgs e)
        {
            string datoNoCord = cord.SelectedValue.ToString();
            ngbdReportes rep = new ngbdReportes();
            dgvRep.DataSource = await rep.CargaReporteClientesXCord(datoNoCord);
        }
    }
}
