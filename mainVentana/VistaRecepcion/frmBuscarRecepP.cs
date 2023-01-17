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
    public partial class frmBuscarRecepP : Form
    {
        public frmBuscarRecepP()
        {
            InitializeComponent();
        }
        public string sOrigen;
        public string documento;
        public int numerosuc;


        public delegate void pasarS(string dato1);
        public event pasarS pasadoS;

        

        private async void frmBuscarOrdSalida_Load(object sender, EventArgs e)
        {

            gunaDataGridView1.DataSource = null;
            Negocios.AccesoRecepciones.ngAccesoRecepciones sv = new Negocios.AccesoRecepciones.ngAccesoRecepciones();
            gunaDataGridView1.DataSource = await sv.LlenaDGVRecepcion(sOrigen, documento, numerosuc);
        }

        private void gunaDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gunaDataGridView1.Rows.Count > 0)
            {

                string salida = gunaDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                pasadoS(salida);
                //this.Close();
                //this.Dispose();
                // Clipboard.SetText(carga);
            }
            else
            {
                MessageBox.Show("No hay datos para buscar.");
            }
        }
    }
}
