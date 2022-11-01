using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;

using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using SpreadsheetLight;
using Ventana1.Entiti;
using Ventana1.LoadControl;
using Ventana1.MB;
using Ventana1.vm;
using System.Media;
using Negocios;
using Datos.Datosenti;
using KDMENT = Datos.Datosenti.KDMENT;
using System.Drawing;

namespace Ventana1
{
    public partial class frmSalidas : Form
    {
       
        string ulDato = "";
        string ulDatoSolo = "";
        string sOrigen = "";
        string sDestino = "";
        public frmSalidas()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }
        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.White;
            iconButton1.ForeColor = Color.White;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.Blue;
            iconButton1.ForeColor = Color.Black;
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            var bn = ValidacionesBExcel();
            if (bn == 1)
            {
                return;
            }
            ObtieneDatosDeExcel();



        }
        private int ValidacionesBExcel()
        {
            int error = 0;

            if (sOrigen == "")
            {
                MessageBox.Show("Es necesario selccionar una sucursal de Origen");
                error = 1;
            }
            if (sDestino == "")
            {
                MessageBox.Show("Es necesario selccionar una sucursal de Destino");
                error = 1;
            }
            if (sDestino == sOrigen)
            {
                MessageBox.Show("Las sucursales no pueden ser las mismas");
                error = 1;
            }

            return error;
        }
        private void GifLoading(int estado)//1 abre el el gif 2 detiene el gif
        {
            loadControl loadingPatoControl = new loadControl();
            if (estado == 1)
            {
                loadingPatoControl.Dock = DockStyle.Fill;
                pnImg.Controls.Add(loadingPatoControl);

            }
            if (estado == 2)
            {
                pnImg.Controls.Clear();

            }
        }

        private void LimpiaDatosEnVista()
        {

            dgvError.DataSource = null;
            dgvExito.DataSource = null;
            dgvInicial.DataSource = null;
            dgvDuplicados.DataSource = null;
            dgvRaw.DataSource = null;
            txbSubT.Text = "";
            txbTotal.Text = "";
            txbtEtiduplicadas.Text = "";
            txbNotas.Text = "";
            txbReferencia.Text = "";
            txbtError.Text = "";
            txbtCorrecto.Text = "";
        }
        private void ObtieneDatosDeExcel()
        {
            LimpiaDatosEnVista();

            openFileDialog1.InitialDirectory = @"C:\\";
            openFileDialog1.Filter = "Archivos de texto (*.xlsx)|*.xlsx";
            List<vm.Salidas_por_cotizacion> lst = new List<vm.Salidas_por_cotizacion>();

            // codigo para abrir el cuadro de dialogo
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                System.Data.DataTable dt = new System.Data.DataTable();
                SLDocument doc = new SLDocument(openFileDialog1.FileName);
                int IRow = 2;

                while (!string.IsNullOrEmpty(doc.GetCellValueAsString(IRow, 1)))
                {
                    vm.Salidas_por_cotizacion Odats = new vm.Salidas_por_cotizacion();

                    Odats.c2 = doc.GetCellValueAsString(IRow, 1).ToString().Replace("'", "-").Replace("’", "-").Replace(" ", "").ToUpper().Trim();

                    if (doc.GetCellValueAsString(IRow, 2).ToString().Trim() != "")
                    {
                        lblChofer.Text = doc.GetCellValueAsString(IRow, 2).ToString().Trim().Length >= 50 ? doc.GetCellValueAsString(IRow, 2).ToString().Trim().Substring(0, 50) : doc.GetCellValueAsString(IRow, 2).ToString().Trim();
                    }
                    if (doc.GetCellValueAsString(IRow, 3).ToString().Trim() != "")
                    {
                        lblPlacas.Text = doc.GetCellValueAsString(IRow, 3).ToString().Trim().Length >= 50 ? doc.GetCellValueAsString(IRow, 3).ToString().Trim().Substring(0, 50) : doc.GetCellValueAsString(IRow, 3).ToString().Trim();
                    }
                    if (doc.GetCellValueAsString(IRow, 4).ToString().Trim() != "")
                    {
                        lblTransportista.Text = doc.GetCellValueAsString(IRow, 4).ToString().Trim().Length >= 50 ? doc.GetCellValueAsString(IRow, 4).ToString().Trim().Substring(0, 50) : doc.GetCellValueAsString(IRow, 4).ToString().Trim();
                    }



                    lst.Add(Odats);

                    IRow++;
                }

            }

            var query = lst.GroupBy(x => x.c2)
              .Where(g => g.Count() > 1)
              .Select(y => new { Etiquetas = y.Key, No = y.Count() - 1 })
              .ToList();


            var listasinduplis = new HashSet<string>(lst.Select(d => d.c2).ToList()).ToList();

            dgvDuplicados.DataSource = query;

            dgvRaw.DataSource = lst.ToList();

            var nlst = lst.Select(d => d.c2).Distinct();
            List<Salidas_por_cotizacion> nls = new List<Salidas_por_cotizacion>();
            foreach (var q in nlst)
            {
                nls.Add(new Salidas_por_cotizacion { c2 = q.ToString() });
            }


            dgvInicial.DataSource = nls.ToList();



            txbSubT.Text = lst.Count().ToString();
            txbTotal.Text = listasinduplis.Count().ToString();



            int cantidadrep = 0;
            foreach (var i in query)
            {
                cantidadrep = cantidadrep + i.No;
            }
            txbtEtiduplicadas.Text = cantidadrep.ToString();



        }



        private void BuscaUltimaSalida(string suc)
        {

            //List<string> lista1 = new List<string>();
            Negocios.Acceso_Salida.AccesoSalidas sls = new Negocios.Acceso_Salida.AccesoSalidas();
            var lista1 = sls.BuscUltimaSalida(suc);


            foreach (var i in lista1)
            {
                int sl = Convert.ToInt32(i.ToString()) + 1;
                ulDato = sOrigen + "-UD4501-" + sl.ToString("D7");
                lblSalida.Text = ulDato;
                ulDatoSolo = sl.ToString("D7");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ciudadusr = Negocios.Common.Cache.CacheLogin.sucdefecto;

            if (ciudadusr.Trim() == "TJ")
            {
                rbOTJ.Checked = true;
            }

            if (ciudadusr.Trim() == "SD")
            {
                rbOSD.Checked = true;
            }

            if (ciudadusr.Trim() == "CSL")
            {
                rbOCSL.Checked = true;
            }
        }




        private void btnSubir_Click(object sender, EventArgs e)
        {

            if (pnImg.Controls.Count >= 1)
            {
                MessageBox.Show("Hay una operacion en marcha, espera a que esta finalice para poder cargar de nuevo");

                return;
            }
            int error = ValidacionesGenerales(); //1 error o normal


            if (error == 1)
            {
                return;
            }

            
            string msn = "Se creará la salida con los siguientes datos: \nOrigen: " + sOrigen+"\nDestino: "+sDestino;
            

            if (MessageBox.Show(msn, "importante, valida información antes de continuar", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
            {
                CreaSalidaEnKDM1();
            }
           


        }
        private int ValidacionesGenerales()
        {
            int error = 0;
            if (dgvInicial.Rows.Count <= 0)
            {
                MessageBox.Show("No hay ninguna etiqueta en la vista");
                error = 1;
            }
            if (sOrigen == "")
            {
                MessageBox.Show("Es necesario selccionar una sucursal de Origen");
                error = 1;
            }
            if (sDestino == "")
            {
                MessageBox.Show("Es necesario selccionar una sucursal de Destino");
                error = 1;
            }
            if (sDestino == sOrigen)
            {
                MessageBox.Show("Las sucursales no pueden ser las mismas");
                error = 1;
            }

            return error;
        }

        private async void CreaSalidaEnKDM1()
        {

            GifLoading(1);
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            BuscaUltimaSalida(sOrigen);
            Negocios.AltasBD at = new AltasBD();
            at.CSalidaEnKDM1(sOrigen
                , "U"
                , "D"
                , Convert.ToDecimal(45)
                , Convert.ToDecimal(1)
                , ulDatoSolo
                , Convert.ToDecimal(1)
                , DateTime.Now
                , txbReferencia.Text
                , 1
                , DateTime.Now
                , txbNotas.Text
                , "Ord"
                , "A"
                , "UD4501-"
                , Negocios.Common.Cache.CacheLogin.username.ToString()
                , DateTime.Now
                , lblTransportista.Text.Length >= 100 ? lblTransportista.Text.Substring(0, 100) : lblTransportista.Text
                , lblPlacas.Text.Length >= 50 ? lblPlacas.Text.Substring(0, 50) : lblPlacas.Text
                , lblChofer.Text.Length >= 100 ? lblChofer.Text.Substring(0, 100) : lblChofer.Text
                , sDestino);


            if (sDestino == "CSL" && sOrigen == "SD")
            {
                await ModificaKDMENTTOCABO();
            }

            if (sDestino == "TJ"  && sOrigen == "SD")
            {
                await ModificaKDMENTsd();
            }
            if (sDestino == "SD" && sOrigen == "TJ")
            {
                await ModificaKDMENTtj();
            }
            if (sDestino == "CSL" && sOrigen == "TJ")
            {

                await ModificaKDMENTtj();
            }
            if (sDestino == "TJ" || sDestino == "SD" && sOrigen == "CSL")
            {
                await ModificaKDMENTsd();
            }



            GifLoading(2);
            if (Convert.ToInt32(txbtError.Text) >= 1)
            {
                Notifica(2, ulDatoSolo);
            }
            if (Convert.ToInt32(txbtError.Text) < 1)
            {
                Notifica(1, ulDatoSolo);
            }
            MessageBox.Show("Proceso terminado \n\nSe ha creado la salida: " + ulDatoSolo + "\nCon destino a: " + sDestino, "Fin",MessageBoxButtons.OK,MessageBoxIcon.Information);
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            dgvInicial.DataSource = null;

            BuscaUltimaSalida(sOrigen);
        }
        
      
        //Sucursal destino cabo sucursal origen tijuana
        private async Task<bool> ModificaKDMENTtj()
        {
            int nm = 0;
            List<vmErroresScanSalidas> lserror = new List<vmErroresScanSalidas>();
            List<vmErroresScanSalidas> lsexito = new List<vmErroresScanSalidas>();
            string eti = "";
            string sc = sDestino == "CSL" && sOrigen == "TJ" ? "PR" : "OC";


            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    List<KDMENT> kd = new List<KDMENT>();
                    foreach (var q in dgvInicial.Rows)
                    {
                        string msn = dgvInicial.Rows[nm].Cells[0].Value.ToString();



                        string uld = (string)ulDato.Trim().Clone();

                        var etisuc = msn.Split(Convert.ToChar("-"))[0];

                        nm = nm + 1;

                        try
                        {
                            var d = (from fd in modelo.KDMENT
                                     where fd.C9 == msn.Trim()// 
                                     select fd).First();
                            //d.C17 = uld;
                            d.C19 = sOrigen;
                            d.C20 = sc;
                            d.C23 = "";
                            d.C55 = uld;
                            d.C56 = "";

                            d.C63 = uld;
                            d.C64 = uld;
                            d.C65 = "E";
                            d.C66 = "";
                            d.C67 = "";
                            d.C68 = "";
                            d.C75 = DateTime.Now.ToString("dd/MM/yyyy");
                            kd.Add(d);
                            eti = etisuc;
                            if (etisuc == sDestino)
                            {
                                lsexito.Add(new vmErroresScanSalidas { etiqueta = msn, error = "La etiqueta pertece a la sucursal de salida" });
                                
                                continue;
                            }
                           


                            //modelo.SaveChanges();
                            lsexito.Add(new vmErroresScanSalidas { etiqueta = msn, error = "Actualizada con sin detalles" });

                        }
                        catch (Exception J)
                        {

                            lserror.Add(new vmErroresScanSalidas { etiqueta = msn, error = J.Message.ToString() });

                            continue;

                        }




                    }
                    modelo.BulkUpdate(kd.ToList());

                }
            });


            dgvError.DataSource = lserror.ToList();

            dgvExito.DataSource = lsexito.ToList();

            txbtError.Text = lserror.Count().ToString();
            txbtCorrecto.Text = lsexito.Count().ToString();

            //----------------------------------------



            return true;

        }
        //Sucursal destino cabo o tjuana sucursal origen san diego
        private async Task<bool> ModificaKDMENTsd()
        {
            int nm = 0;
            List<vmErroresScanSalidas> lserror = new List<vmErroresScanSalidas>();
            List<vmErroresScanSalidas> lsexito = new List<vmErroresScanSalidas>();
            string eti = "";
            string sc = sDestino == "CSL" && sOrigen == "SD" ? "PR" : "OC";
            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    List<Datos.Datosenti.KDMENT> kd = new List<Datos.Datosenti.KDMENT>();
                    foreach (var q in dgvInicial.Rows)
                    {
                        string msn = dgvInicial.Rows[nm].Cells[0].Value.ToString();


                        string uld = (string)ulDato.Trim().Clone();

                        var etisuc = msn.Split(Convert.ToChar("-"))[0];

                        nm = nm + 1;
                        try
                        {



                            var d = (from fd in modelo.KDMENT
                                     where fd.C9 == msn.Trim()// 
                                     select fd).First();

                            d.C12 = "E";
                            d.C17 = uld;
                            d.C18 = "";
                            d.C19 = sOrigen;
                            d.C20 = sc;

                            d.C23 = "";
                            d.C55 = uld;
                            d.C56 = "";

                            d.C63 = "";
                            d.C64 = "";
                            d.C65 = "";
                            d.C66 = "";
                            d.C67 = "";
                            d.C68 = "";
                            d.C73 = DateTime.Now.ToString("dd/MM/yyyy");
                            d.C75 = "";
                            kd.Add(d);
                            //modelo.SaveChanges();
                            eti = etisuc;
                            if (etisuc == sDestino)
                            {
                                lsexito.Add(new vmErroresScanSalidas { etiqueta = msn, error = "La etiqueta pertece a la sucursal de salida" });

                                continue;
                            }
                            lsexito.Add(new vmErroresScanSalidas { etiqueta = msn, error = "Actualizada con con detalles" });

                        }
                        catch (Exception J)
                        {

                            lserror.Add(new vmErroresScanSalidas { etiqueta = msn, error = J.Message.ToString() });

                            continue;

                        }

                    }
                    modelo.BulkUpdate(kd.ToList());
                }
            });



            dgvError.DataSource = lserror.ToList();

            dgvExito.DataSource = lsexito.ToList();

            txbtError.Text = lserror.Count().ToString();
            txbtCorrecto.Text = lsexito.Count().ToString();

            return true;
        }

        private async Task<bool> ModificaKDMENTTOCABO()
        {
            int nm = 0;
            List<vmErroresScanSalidas> lserror = new List<vmErroresScanSalidas>();
            List<vmErroresScanSalidas> lsexito = new List<vmErroresScanSalidas>();
            string eti = "";
            //string sc = sDestino == "CSL" && sOrigen == "TJ" ? "PR" : "OC";


            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    List<KDMENT> kd = new List<KDMENT>();
                    foreach (var q in dgvInicial.Rows)
                    {
                        string msn = dgvInicial.Rows[nm].Cells[0].Value.ToString();



                        string uld = (string)ulDato.Trim().Clone();

                        var etisuc = msn.Split(Convert.ToChar("-"))[0];

                        nm = nm + 1;

                        try
                        {
                            var d = (from fd in modelo.KDMENT
                                     where fd.C9 == msn.Trim()// 
                                     select fd).First();
                            d.C12 = "E";
                            d.C17 = uld;
                            d.C18 = "";
                            d.C19 = sOrigen;
                            d.C20 = "PR";

                            d.C23 = "";
                            d.C55 = uld;
                            d.C56 = "";

                            d.C63 = "";
                            d.C64 = "";
                            d.C65 = "";
                            d.C66 = "";
                            d.C67 = "";
                            d.C68 = "";
                            d.C73 = DateTime.Now.ToString("dd/MM/yyyy");
                            d.C75 = "";
                            kd.Add(d);
                            eti = etisuc;
                            if (etisuc == sDestino)
                            {
                                lsexito.Add(new vmErroresScanSalidas { etiqueta = msn, error = "La etiqueta pertece a la sucursal de salida" });

                                continue;
                            }



                            //modelo.SaveChanges();
                            lsexito.Add(new vmErroresScanSalidas { etiqueta = msn, error = "Actualizada con sin detalles" });

                        }
                        catch (Exception J)
                        {

                            lserror.Add(new vmErroresScanSalidas { etiqueta = msn, error = J.Message.ToString() });

                            continue;

                        }




                    }
                    modelo.BulkUpdate(kd.ToList());

                }
            });


            dgvError.DataSource = lserror.ToList();

            dgvExito.DataSource = lsexito.ToList();

            txbtError.Text = lserror.Count().ToString();
            txbtCorrecto.Text = lsexito.Count().ToString();

            //----------------------------------------



            return true;

        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }


        private void ValidaOrigen(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Name == "rbOTJ")
            {
                sOrigen = "TJ";
                lblSalida.ForeColor = Color.Blue;

            }
            if (rb.Name == "rbOCSL")
            {
                sOrigen = "CSL";
                lblSalida.ForeColor = Color.DarkViolet;

            }
            if (rb.Name == "rbOSD")
            {
                sOrigen = "SD";
                lblSalida.ForeColor = Color.Red;

            }
            BuscaUltimaSalida(sOrigen);

        }
        private void ValidaDestino(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Name == "rbDTJ")
            {
                sDestino = "TJ";


            }
            if (rb.Name == "rbDCSL")
            {
                sDestino = "CSL";

            }
            if (rb.Name == "rbDSD")
            {
                sDestino = "SD";

            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pnImg.Controls.Count >= 1)
            {
                MessageBox.Show("Hay una operacion en marcha, espera a que esta finalice para poder cerrar");
                e.Cancel = true;
                return;
            }
            if (MessageBox.Show("Estas apunto de cerrar el programa \n\n\n¿Deseas Salir?", "Hey, cuidado!", MessageBoxButtons.YesNo) == DialogResult.No)
            {

                e.Cancel = true;
                return;
            }

            /*else
            {

                this.Dispose();
                this.Close();
            }*/
        }
        //--------------------------------------Notificacion-------------------------------


        private void Notifica(int nttipo, string nsalida)
        {
            /*
             2 = ERROR
             1 = EXITO
            */
            //string uld = (string)ulDato.Trim().Clone();

            if (nttipo == 1)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Text = nsalida + " CARGADA";
                notifyIcon1.BalloonTipTitle = "Sin Errores: Salida terminada " + nsalida;
                notifyIcon1.BalloonTipText = "Se ha cargado la salida: " + nsalida + " sin eerores\r\n";
                notifyIcon1.ShowBalloonTip(10000);


            }
            else if (nttipo == 2)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Text = nsalida + " ERROR: la salida contiene errores";
                notifyIcon1.BalloonTipTitle = "ERROR: no se han cargado todas las etiquetas " + nsalida;
                notifyIcon1.BalloonTipText = "algunas etiquetas no fueron cargadas en la salida: " + nsalida;
                notifyIcon1.ShowBalloonTip(10000);

            }

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nada = lblSalida.Text.Split(Convert.ToChar("-"))[0];

        }


        //---------------------------------------------------------------------------------





    }
}
