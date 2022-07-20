using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios.NGReportes;
namespace mainVentana.VistaInicioCoordinadores
{
    public partial class frmInicioCoordinadores : Form
    {





        public frmInicioCoordinadores()
        {
            InitializeComponent();
        }

        public delegate Task pasar(string id);
        public event pasar pasado;

        public async Task ejecutaeveto(string id)
        {
           await pasado(id);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private async void frmInicioCoordinadores_Load(object sender, EventArgs e)
        {
            await CargaControles();
            await cargacontroldos();
        }

       

        public async Task CargaControles()
        {

            ngbdReportes rep = new ngbdReportes();



            var ls = await rep.CargaControl("CSL");
            if (ls.Count > 0)
            {
                ControlEntradaCoor[] lb = new ControlEntradaCoor[ls.Count];
                
                int con = 0;


                foreach (var i in ls)
                {
                    
                    lb[con] = new ControlEntradaCoor();
                    lb[con].pasado2 += new ControlEntradaCoor.pasar2(ejecutaeveto);
                    lb[con].Tag = i;

                    lb[con].button1.Text = i.etiqueta;
                    con = con + 1;

                }



                flowLayoutPanel1.Controls.AddRange(lb);

            }






        }

        public async Task cargacontroldos()
        {
            ngbdReportes rep = new ngbdReportes();
            var ls2 = await rep.CargaControl("TJ");

            if (ls2.Count > 0)
            {
            ControlEntradaCoor[] lb = new ControlEntradaCoor[ls2.Count];
            int con = 0;


            foreach (var i in ls2)
            {

                lb[con] = new ControlEntradaCoor();
                lb[con].Tag = i;
                lb[con].button1.Text = i.etiqueta;
                con = con + 1;


            }

            flowLayoutPanel2.Controls.AddRange(lb);

           
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ejecutaeveto("0008218");

        }
    }




}
