using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;
using Negocios.Common.Cache;
using System.Threading;
using mainVentana.vistaReportes;
using mainVentana.VistaRecepcion;
using mainVentana.VistaOrdenCarga;
using System.Diagnostics;
using mainVentana.VistaInicioCoordinadores;
using mainVentana.VistaWMS;
using mainVentana.Reportes.Cotizaciones.Antiguas;
using mainVentana.VistaEntrada.Proovedor;
using Vanara.PInvoke;
using mainVentana.vistaConfiguraciones;
using mainVentana.VistaBill;
using mainVentana.Reportes.Salidas;

namespace mainVentana
{
    public partial class Form1 : Form
    {
        Over frmOver = new Over(); // llama al formulario de Inicio

        private List<Form> openForms = new List<Form>();



        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmFechaHora.Enabled = true;
            AbrirFormEnPanel(frmOver);



            cargasatosUrs();
            validamenu();
            sucursales();

        }

        private void validamenu()
        {
            if (CacheLogin.rol.Trim() == "ADMIN")
            {
                rbtnAjustes.Enabled = true;
            }
            else if (CacheLogin.rol.Trim() == "JALMA")
            {

            }
            else if (CacheLogin.rol.Trim() == "OENTRA")
            {
                //Enables
                rbtnCargas.Enabled = false;
                rbtnSalida.Enabled = false;
                rbtnReportes.Enabled = false;
                rbtnRecepcion.Enabled = false;
                rbtnBill.Enabled = false;
                rbtnCord.Enabled = false;


                //Visibles
                rbtnCargas.Visible = false;
                rbtnSalida.Visible = false;
                rbtnReportes.Visible = false;
                rbtnRecepcion.Visible = false;
                rbtnCord.Visible = false;



            }
            else if (CacheLogin.rol.Trim() == "CSERVI")
            {
                //Enables
                rbtnEntrada.Enabled = false;
                rbtnCargas.Enabled = false;
                rbtnSalida.Enabled = false;
                rbtnReportes.Enabled = false;
                rbtnRecepcion.Enabled = false;
                


                //Visibles
                rbtnEntrada.Visible = false;
                rbtnCargas.Visible = false;
                rbtnSalida.Visible = false;
                rbtnReportes.Visible = false;
                rbtnRecepcion.Visible = false;
              

            }
            else if (CacheLogin.rol.Trim() == "CONT" || CacheLogin.rol.Trim() == "REVISOR")
            {
                //Enables
                rbtnEntrada.Enabled = false;
                rbtnCargas.Enabled = false;
                rbtnSalida.Enabled = false;
                rbtnReportes.Enabled = false;
                rbtnRecepcion.Enabled = false;
                rbtnBill.Enabled = false;
                rbtnCord.Enabled = false;


                //Visibles
                rbtnEntrada.Visible = false;
                rbtnCargas.Visible = false;
                rbtnSalida.Visible = false;
                rbtnReportes.Visible = false;
                rbtnRecepcion.Visible = false;
                rbtnBill.Visible = false;
                rbtnCord.Visible = false;
            }
              else if (CacheLogin.rol.Trim() == "CXC")
            {
                //Enables
                rbtnEntrada.Enabled = false;
                rbtnCargas.Enabled = false;
                rbtnSalida.Enabled = false;
                rbtnReportes.Enabled = true;
                rbtnRecepcion.Enabled = false;
                rbtnBill.Enabled = false;
                rbtnCord.Enabled = true;


                //Visibles
                rbtnEntrada.Visible = false;
                rbtnCargas.Visible = false;
                rbtnSalida.Visible = false;
                rbtnReportes.Visible = true;
                rbtnRecepcion.Visible = false;
                rbtnBill.Visible = false;
                rbtnCord.Visible = true;
            }

            else
            {
                //Enables
                rbtnEntrada.Visible = false;
                rbtnCargas.Enabled = false;
                rbtnSalida.Enabled = false;
                rbtnReportes.Enabled = false;
                rbtnRecepcion.Enabled = false;
                rbtnBill.Enabled = false;
                rbtnCord.Enabled = false;

                //Visibles
                rbtnEntrada.Visible = false;
                rbtnCargas.Visible = false;
                rbtnSalida.Visible = false;
                rbtnReportes.Visible = false;
                rbtnRecepcion.Visible = false;
                rbtnBill.Visible = false;
                rbtnCord.Visible = false;

                MessageBox.Show("El usuario con el que ingresaste pertenece a un rol que no es compatible con Arsys, te recomendamos contactar a Daniel para cambiar el rol de tu usuario");
            }


        }


        private void cargasatosUrs()
        {
            lblNombreUsr.Text = CacheLogin.nombre + " " + CacheLogin.apellido;
            lblRol.Text = CacheLogin.email;

        }
        
      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tmFechaHora_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }



       
        #region abrir paneles metodo


        //METODO PARA ABRIR FORM DENTRO DE PANEL----------------------------------------------------
        private void AbrirFormEnPanel(object formHijo)
        {
            

            if (this.panelContenedorForm.Controls.Count > 0)
                this.panelContenedorForm.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelContenedorForm.Controls.Add(fh);
            this.panelContenedorForm.Tag = fh;
            fh.Show();
        }



        #endregion


     

        private void iconButton1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(frmOver);
        }

      

        public delegate void Cierra();
        //public delegate void pasar2(string dato,string cliente, int bandera);
        public event Cierra Cerrado;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Liberar recursos adicionales si es necesario
            liberarR();

            // Cerrar la aplicación
           
        }

        private void liberarR()
        {
            tmFechaHora.Enabled = false; // Detener un posible temporizador activo
          //  Cerrado(); // Realizar cualquier acción personalizada antes del cierre
        }







        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            liberarR();
            Application.Exit();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ribbonOrbRecentItem1_Click(object sender, EventArgs e)
        {
            liberarR();
        }

        private async void ribbonButton1_Click(object sender, EventArgs e)
        {
            Negocios.LOGs.ArsLogs.RutePaht();
            //string val = rcmbSucAct.SelectedValue;
            MessageBox.Show("Copiado");
        }

        private async void rbtnEntrada_Click(object sender, EventArgs e)
        {
            try
            {
                Entradas ent = new Entradas(); // Crear una nueva instancia del formulario
                if (rcmbSucAct.Value != "")
                {
                    ent.sucursalGlobal = rcmbSucAct.Value;
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


        private async void rbtnCargas_Click(object sender, EventArgs e)
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

        private async void rbtnSalida_Click(object sender, EventArgs e)
        {
            int result = await ConeccionRed.TestInternet();

            if (result == 1)
            {
                MessageBox.Show("No tienes internet");
                return;
            }
            try
            {
                VistaOrSalida.frmOrdSalida salida = new VistaOrSalida.frmOrdSalida();
                openForms.Add(salida);
                salida.FormClosed += frm_FormClosed_Libera;
                salida.Show();
            }
            catch (Exception ex)
            {
                
            }
        }


        private async void rbtnRecepcion_Click(object sender, EventArgs e)
        {
            int result = await ConeccionRed.TestInternet();

            if (result == 1)
            {
                MessageBox.Show("No tienes internet");
                return;
            }
            frmRecepcion frm = new frmRecepcion();
            openForms.Add(frm);
            frm.FormClosed += frm_FormClosed_Libera;
            frm.Show();
        }

        private async void rbtnBill_Click(object sender, EventArgs e)
        {
            int result = await ConeccionRed.TestInternet();

            if (result == 1)
            {
                MessageBox.Show("No tienes internet");
                return;
            }
            VistaBill.frmMBill frm = new VistaBill.frmMBill();
            openForms.Add(frm);
            frm.FormClosed += frm_FormClosed_Libera;
            frm.Show();
        }

        private async void rbtnReportes_Click(object sender, EventArgs e)
        {
            int result = await ConeccionRed.TestInternet();

            if (result == 1)
            {
                MessageBox.Show("No tienes internet");
                return;
            }
            frmMenuReportes frm = new frmMenuReportes();
            openForms.Add(frm);
            frm.FormClosed += frm_FormClosed_Libera;
            frm.Show();

        }

        private void ribbonLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("https://web.whatsapp.com/");
        }

        private void lblWebex_Click(object sender, EventArgs e)
        {
            Process.Start("https://app.ringcentral.com/");
        }

        private void lblGmail_Click(object sender, EventArgs e)
        {
            Process.Start("https://gmail.com/");
        }

        private void lblAmazon_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.amazon.com/");

        }

        private void sucursales()
        {

        }

        private void rcmbSucAct_DropDownItemClicked(object sender, RibbonItemEventArgs e)
        {
            Negocios.Common.Cache.CacheLogin.sucGlobal = rcmbSucAct.SelectedValue==default || rcmbSucAct.SelectedValue == "" ? "SD" : rcmbSucAct.SelectedValue;
            //rlblSucGlobal.Text = rcmbSucAct.SelectedItem+" "+ Negocios.Common.Cache.CacheLogin.sucGlobal;
        }

        private void apiConfig_Click(object sender, EventArgs e)
        {
            
            using (mainVentana.vistaConfiguraciones.frmConfiguraraApi apiconfi = new vistaConfiguraciones.frmConfiguraraApi())
            {
                apiconfi.ShowDialog();

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void vbtnCotizacion_Click(object sender, EventArgs e)
        {

            frmCotizaciones cot = new frmCotizaciones();
            openForms.Add(cot);
            cot.FormClosed += frm_FormClosed_Libera;
            cot.sGlobal = Negocios.Common.Cache.CacheLogin.sucGlobal;
            cot.Show();
        }

       

        private void rCordbtnBuscaCot_Click(object sender, EventArgs e)
        {
            frmBuscarCotizacion cot = new frmBuscarCotizacion();
            openForms.Add(cot);
            cot.FormClosed += frm_FormClosed_Libera;
            cot.Show();
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

        private void ribbonButton4_Click(object sender, EventArgs e)
        {
            using (frmMainWMS wms = new frmMainWMS())
            {
                wms.ShowDialog();
            }
        }

        private void vbtnClientes_Click(object sender, EventArgs e)
        {
            using (frmClientesMain clts = new frmClientesMain())
            {
                clts.ShowDialog();
            }
        }

        private void oldrpKepler_Click(object sender, EventArgs e)
        {
            using (frmOldCotPorCliente frm = new frmOldCotPorCliente())
            {
                frm.ShowDialog();
            }
        }

        private void ribbonButton5_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmProovedorAdd ent = new frmProovedorAdd())
                {
                    
                    ent.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCargaTo_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmAddToCarga ent = new frmAddToCarga())
                {

                    ent.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void rbAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmNuevoUsuario usr = new frmNuevoUsuario())
                {

                    usr.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void consultaBill_Click(object sender, EventArgs e)
        {
            frmConsultaBill bll = new frmConsultaBill();
            openForms.Add(bll);
            bll.FormClosed += frm_FormClosed_Libera;
            bll.Show();
        }

        private void rbtnEntregasPruebas_Click(object sender, EventArgs e)
        {
            frmEvidenciasEntrega Evide = new frmEvidenciasEntrega();
            openForms.Add(Evide);
            Evide.FormClosed += frm_FormClosed_Libera;
            Evide.Show();
        }

        private void rbtnCord_Click(object sender, EventArgs e)
        {
        }

        private void rbtnConsultaCargaCord_Click(object sender, EventArgs e)
        {

            try
            {
                frmModificaCarga ent = new frmModificaCarga();
                ent.Text = "Consulta";
                ent.modoForm = "Consulta";

                ent.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbReporteSalida_Click(object sender, EventArgs e)
        {

            frmRepSalidas Evide = new frmRepSalidas();
            openForms.Add(Evide);
            Evide.FormClosed += frm_FormClosed_Libera;
            Evide.Show();
        }
    }
}
