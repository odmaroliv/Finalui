using mainVentana.VistaOrdenCarga;
using mainVentana.VistaRecepcion;
using Negocios;
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
        public string sucursalGlobal = Negocios.Common.Cache.CacheLogin.sucGlobal == default ? "SD" : Negocios.Common.Cache.CacheLogin.sucGlobal;
        private List<Form> openForms = new List<Form>();
        public tstflirk()
        {
            InitializeComponent();
        }

        private async void gunaGradientTileButton5_Click(object sender, EventArgs e)
        {

            try
            {
                VistaOrSalida.frmOrdSalida salida = new VistaOrSalida.frmOrdSalida();
                openForms.Add(salida);
                salida.FormClosed += frm_FormClosed_Libera;
                salida.Show();
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
        private void frm_FormClosed_Libera(object sender, FormClosedEventArgs e)
        {
            Form form = sender as Form;
            if (form != null)
            {
                openForms.Remove(form);
                form.Dispose();
            }
        }

        private void tstflirk_Load(object sender, EventArgs e)
        {
            validamenu();
        }

        private async void btnEntrada_Click(object sender, EventArgs e)
        {
            
            try
            {
                Entradas ent = new Entradas(); // Crear una nueva instancia del formulario
                if (sucursalGlobal != "")
                {
                    ent.sucursalGlobal = sucursalGlobal;
                }
                openForms.Add(ent);
                ent.FormClosed += frm_FormClosed_Libera;
                ent.Show();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCargas_Click(object sender, EventArgs e)
        {
            int result = await ConeccionRed.TestInternet();

            if (result == 1)
            {
                MessageBox.Show("No tienes internet");
                return;
            }
            try
            {
                frmOrdenDeCarga ocar = new frmOrdenDeCarga();
                openForms.Add(ocar);
                ocar.FormClosed += frm_FormClosed_Libera;
                ocar.Show();

            }
            catch (Exception)
            {

            }
        }

        private async void btnRecep_Click(object sender, EventArgs e)
        {
            try
            {
                frmRecepcion frm = new frmRecepcion();
                openForms.Add(frm);
                frm.FormClosed += frm_FormClosed_Libera;
                frm.Show();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
