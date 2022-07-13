using Negocios.Common.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana
{
    public partial class tstflirk : Form
    {
        public tstflirk()
        {
            InitializeComponent();
        }

        private void gunaGradientTileButton5_Click(object sender, EventArgs e)
        {
            try
            {
                VistaOrSalida.frmOrdSalida salida = new VistaOrSalida.frmOrdSalida();
                salida.ShowDialog();
                salida.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void validamenu()
        {
            if (CacheLogin.rol.Trim() == "ADMIN" || CacheLogin.rol.Trim() == "JALMA")
            {
                btnEntrada.Enabled = true;
                btnSalida.Enabled = true;
                btnRecep.Enabled = true;
                btnCargas.Enabled = true;
            }
            else if (CacheLogin.rol.Trim() == "OENTRA")
            {
                btnEntrada.Enabled = true;
                btnSalida.Enabled = false;
                btnRecep.Enabled = false;
                btnCargas.Enabled = false;
            }
            else if (CacheLogin.rol.Trim() == "CSERVI")
            {
                btnEntrada.Enabled = false;
                btnSalida.Enabled = false;
                btnRecep.Enabled = false;
                btnCargas.Enabled = false;

            }
            else if (CacheLogin.rol.Trim() == "CONT" || CacheLogin.rol.Trim() == "REVISOR")
            {
                btnEntrada.Enabled = false;
                btnSalida.Enabled = false;
                btnRecep.Enabled = false;
                btnCargas.Enabled = false;

            }



            else
            {
                btnEntrada.Enabled = false;
                btnSalida.Enabled = false;
                btnRecep.Enabled = false;
                btnCargas.Enabled = false;
                MessageBox.Show("El usuario con el que ingresaste pertenece a un rol que no es compatible con Arsys, te recomendamos contactar a Daniel para cambiar el rol de tu usuario");
            }


        }

        private void tstflirk_Load(object sender, EventArgs e)
        {
            validamenu();
        }
    }
}
