
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
    public partial class LicenciaFRM : Form
    {
        public LicenciaFRM()
        {
            InitializeComponent();
        }

        private void foreverButton1_Click(object sender, EventArgs e)
        {
            mainVentana.Properties.Settings.Default.apiFotosUs = txbUs.Text.Trim();
            mainVentana.Properties.Settings.Default.apiFotosPs = txbPs.Text.Trim();


            try
            {
                mainVentana.Properties.Settings.Default.Save();
            }

            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

           Negocios.Properties.Settings.Default.apiUs = txbUs.Text.Trim(); 
           Negocios.Properties.Settings.Default.apiPs = txbPs.Text.Trim(); 

            try
            {
                Negocios.Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

            MessageBox.Show("Actualizado correctamente");
        }
    }
}
