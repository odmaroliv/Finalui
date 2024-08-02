using Datos.ViewModels.Entradas;
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

namespace mainVentana.VistaEntrada.ReportesEntradas
{
    public partial class frmReporteEntradas : Form
    {

       List<vmEntradaReporteTotales> listaUsuario = new List<vmEntradaReporteTotales>();
        string usuarioSeleccionado = string.Empty;

        public frmReporteEntradas()
        {
            InitializeComponent();
        }

        private void frmReporteEntradas_Load(object sender, EventArgs e)
        {
            GetUser();


            dtFecha1.Value = DateTime.Now.AddDays(-30);
            dtFecha2.Value = DateTime.Now.AddDays(1);

        }



        private async Task GetUser()
        {
            Servicios dataUser = new Servicios();

           listaUsuario = await dataUser.llenaUserEntradas();



            cmbUsers.ValueMember = "usuario";
            cmbUsers.DisplayMember = "nombre";
            cmbUsers.DataSource = listaUsuario;
            dataUser = null;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            Servicios dataUser = new Servicios();
            dgvData.DataSource = null;
            var data = await dataUser.ObtieneEntradasPorUsario(usuarioSeleccionado, dtFecha1.Value, dtFecha2.Value);
            dgvData.DataSource = data;
        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
        usuarioSeleccionado = cmbUsers.SelectedValue.ToString();
            dgvData.DataSource = null;
        }
    }
}
