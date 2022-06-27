using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios.Acceso_Salida;

namespace mainVentana.VistaOrSalida
{
    public partial class frmBuscarOrdCarga : Form
    {


        public string sorigen;
        public string documento;
        public int numerosuc;
        public frmBuscarOrdCarga()
        {
            InitializeComponent();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private async void frmBuscarOrdCarga_Load(object sender, EventArgs e)
        {
          AccesoSalidas sv = new AccesoSalidas();
           gunaDataGridView1.DataSource =  await sv.LlenaDGV(sorigen,documento,numerosuc);
        }
    }
}
