using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.ViewModels.Reportes;
using Negocios.NGReportes;
namespace mainVentana.VistaInicioCoordinadores
{
    public partial class frmInicioCoordinadores : Form
    {





        public frmInicioCoordinadores()
        {
            InitializeComponent();
        }

        public delegate Task pasar(string id = null);
        public event pasar pasado;

        public async Task ejecutaeveto(string id)
        {
            await pasado(id);
        }

     

        public async Task ejecutaeveto2()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            await Task.Run(() => { Thread.Sleep(1000); });
            await CargaControles();
            await cargacontroldos();
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
            List<vmInfoControlCors> lss = new List<vmInfoControlCors>();

            //lss = ls.Distinct(k).ToList();

            var listanoduplies = new HashSet<string>(ls.Select(s => s.entrada)).ToList();
            foreach (var q in listanoduplies)
            {
                foreach (var w in ls)
                {
                    if (w.entrada.Trim() == q.Trim())
                    {
                        lss.Add( new vmInfoControlCors
                        {
                            entrada = w.entrada,
                            cliente = w.cliente,
                            fechaentrada = w.fechaentrada,
                            ordcarga = w.ordcarga,
                            ordapli = w.ordapli,
                            salida = w.salida
                        });
                        break;
                    }
                    else
                    {

                    }

                }

            }

            

            if (lss.Count > 0)
            {
                ControlEntradaCoor[] lb = new ControlEntradaCoor[lss.Count];

                int con = 0;


                foreach (var i in lss.OrderByDescending(x => x.entrada))
                {

                    lb[con] = new ControlEntradaCoor();
                    
                    lb[con].refrescado += new ControlEntradaCoor.refrescarcord(ejecutaeveto2);
                    lb[con].pasado2 += new ControlEntradaCoor.pasar2(ejecutaeveto);
                    lb[con].Tag = i;

                    lb[con].button1.Text = i.entrada;
                    lb[con].lblCarga.Text = i.ordcarga;
                    lb[con].lblCliente.Text = i.cliente;
                    lb[con].lblFentrada.Text = i.fechaentrada;
                    lb[con].lblFilaNum.Text = (con+1).ToString();

                    string vOrdAs = i.ordcarga == null ? "" : i.ordcarga.Trim();
                    string vOrdApl = i.ordapli == null ? "" : i.ordapli.Trim();
                    string vSalida = i.salida == null ? "" : i.salida.Trim();


                    if (vOrdAs == "")
                    {
                        lb[con].button1.BaseColor = Color.Red;
                        lb[con].tbar.Value = 0;
                        lb[con].tbar.TrackColor = Color.Red;
                    }
                    if (vOrdAs != "")
                    {
                        lb[con].button1.BaseColor = Color.Blue;
                        lb[con].tbar.Value = 33;
                        lb[con].tbar.TrackColor = Color.Blue;
                    }
                    if (vOrdApl != "" && vSalida == "")
                    {
                        lb[con].button1.BaseColor = Color.Violet;
                        lb[con].tbar.Value = 66;
                        lb[con].tbar.TrackColor = Color.Violet;
                    }
                    if (vSalida != "")
                    {
                        lb[con].button1.BaseColor = Color.LimeGreen;
                        lb[con].tbar.Value = 100;
                        lb[con].tbar.TrackColor = Color.LimeGreen;
                    }


                    con = con + 1;

                }

                flowLayoutPanel1.Controls.AddRange(lb);
                ls = null;
                lb = null;
            }






        }

        public async Task cargacontroldos()
        {
            ngbdReportes rep = new ngbdReportes();
            var ls2 = await rep.CargaControl("TJ");
            List<vmInfoControlCors> lss = new List<vmInfoControlCors>();

            //lss = ls.Distinct(k).ToList();

            var listanoduplies = new HashSet<string>(ls2.Select(s => s.entrada)).ToList();
            foreach (var q in listanoduplies)
            {
                foreach (var w in ls2)
                {
                    if (w.entrada.Trim() == q.Trim())
                    {
                        lss.Add(new vmInfoControlCors
                        {
                            entrada = w.entrada,
                            cliente = w.cliente,
                            fechaentrada = w.fechaentrada,
                            ordcarga = w.ordcarga,
                            ordapli = w.ordapli,
                            salida = w.salida
                        });
                        break;
                    }
                    else
                    {

                    }

                }

            }



            if (lss.Count > 0)
            {

                ControlEntradaCoor[] lb = new ControlEntradaCoor[lss.Count];
                int con = 0;


                foreach (var i in lss.OrderByDescending(x => x.entrada))
                {

                    lb[con] = new ControlEntradaCoor();
                    lb[con].refrescado += new ControlEntradaCoor.refrescarcord(ejecutaeveto2);
                    lb[con].pasado2 += new ControlEntradaCoor.pasar2(ejecutaeveto);
                    lb[con].Tag = i;
                    


                    lb[con].button1.Text = i.entrada;
                    lb[con].lblCarga.Text = i.ordcarga;
                    lb[con].lblCliente.Text = i.cliente;
                    lb[con].lblFentrada.Text = i.fechaentrada;
                    lb[con].lblFilaNum.Text = (con + 1).ToString();

                    string vOrdAs = i.ordcarga == null ? "" : i.ordcarga.Trim();
                    string vOrdApl = i.ordapli == null ? "" : i.ordapli.Trim();
                    string vSalida = i.salida == null ? "" : i.salida.Trim();

                    if (vOrdAs == "")
                    {
                        lb[con].button1.BaseColor = Color.Red;
                        lb[con].tbar.Value = 0;
                        lb[con].tbar.TrackColor = Color.Red;
                    }
                    if (vOrdAs != "")
                    {
                        lb[con].button1.BaseColor = Color.Blue;
                        lb[con].tbar.Value =33;
                        lb[con].tbar.TrackColor = Color.Blue;
                    }
                    if (vOrdApl != "" && vSalida == "")
                    {
                        lb[con].button1.BaseColor = Color.Violet;
                        lb[con].tbar.Value = 66;
                        lb[con].tbar.TrackColor = Color.Violet;
                    }
                    if (vSalida != "")
                    {
                        lb[con].button1.BaseColor = Color.LimeGreen;
                        lb[con].tbar.Value = 100;
                        lb[con].tbar.TrackColor = Color.LimeGreen;
                    }





                    con = con + 1;


                }
                
                flowLayoutPanel2.Controls.AddRange(lb);
                ls2 = null;
                lb = null;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
    }




}
