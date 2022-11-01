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
        public string sucsdest;
        public string documento;
        public int numerosuc;


        public delegate void pasar(string dato1);
        public event pasar pasado;

        public delegate void cerrar();
        public event cerrar cerrado;

        public frmBuscarOrdCarga()
        {
            InitializeComponent();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private async void frmBuscarOrdCarga_Load(object sender, EventArgs e)
        {
         gunaDataGridView1.DataSource = null;
         AccesoSalidas sv = new AccesoSalidas();
         gunaDataGridView1.DataSource =  await sv.LlenaDGV(sorigen,sucsdest,documento, numerosuc);
        }

        private void gunaDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gunaDataGridView1.Rows.Count > 0)
            {
           
                string carga = gunaDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                pasado(carga);
            }
            else
            {
                MessageBox.Show("No hay datos para buscar.");
            }
        }

        private void frmBuscarOrdCarga_FormClosed(object sender, FormClosedEventArgs e)
        {
            cerrado();
        }
    }
}
