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

namespace mainVentana.VistaEntrada.Proovedor
{
    public partial class frmProovedorAdd : Form
    {
        public frmProovedorAdd()
        {
            InitializeComponent();
        }

        private void frmProovedorAdd_Load(object sender, EventArgs e)
        {

        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que los campos requeridos estén llenos
            if (string.IsNullOrWhiteSpace(txbClave.Text) || string.IsNullOrWhiteSpace(txbNombreProvedor.Text))
            {
                MessageBox.Show("Por favor, llenar los campos requeridos.");
                return;
            }
            AltasBD bd = new AltasBD();
          //  bd.ActualizaSqlIov(txbClave.Text.Trim(), 35);
            await bd.AgregarProovedor(txbClave.Text,txbNombreProvedor.Text,txbCalle.Text,txbColonia.Text,txbPoblacion.Text,txbRfc.Text);

          

        }
    }
}
