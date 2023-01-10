using mainVentana.Properties;
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
    public partial class frmConfiguraraApi : Form
    {

        public frmConfiguraraApi()
        {
            InitializeComponent();
            if (Settings.Default.apiFotosUs.Length > 10)
            {
                txbUs.Text = "123456";
            }
            if (Settings.Default.apiFotosPs.Length > 10)
            {
                txbPs.Text = "123456";
            }
        }

        private void foreverButton1_Click(object sender, EventArgs e)
        {
            Settings.Default.apiFotosUs = txbUs.Text.Trim();
            Settings.Default.apiFotosPs = txbPs.Text.Trim();
            try
            {
                Settings.Default.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
           
            MessageBox.Show("Actualizado correctamente");
        }
    }
}
