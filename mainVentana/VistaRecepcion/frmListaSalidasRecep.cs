using Negocios.AccesoRecepciones;
using Negocios.NGRecepcion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaRecepcion
{
    public partial class frmListaSalidasRecep : Form
    {
        public frmListaSalidasRecep()
        {
            InitializeComponent();
        }


        public string sOrigen;
        public string sEnvia;

        public string documento;
        public int numerosuc;


        public delegate void pasar(string dato1);
        public event pasar pasado;

        public delegate void cerrar();
        public event cerrar cerrado;

      

      

        private void gunaDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gunaDataGridView1.Rows.Count > 0)
            {

                string carga = gunaDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
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

        private async void frmListaSalidasRecep_Load(object sender, EventArgs e)
        {
            gunaDataGridView1.DataSource = null;
            ngAccesoRecepciones sv = new ngAccesoRecepciones();
            gunaDataGridView1.DataSource = await sv.LlenaDGV(sOrigen, documento, numerosuc,sEnvia);
        }
    }
}
