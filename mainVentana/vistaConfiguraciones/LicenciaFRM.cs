
using Negocios.Common;
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
            CryptoHelper.SaveEncryptedCredential("MyAppUK", txbUs.Text.Trim());
            CryptoHelper.SaveEncryptedCredential("MyAppPK", txbPs.Text.Trim());

            MessageBox.Show("Actualizado correctamente");
        }
    }
}
