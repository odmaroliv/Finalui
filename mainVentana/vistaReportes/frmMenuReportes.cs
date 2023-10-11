using ClosedXML.Excel;
using Datos.ViewModels.Reportes;
using mainVentana.Email;
using Negocios.NGReportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Ventana1.LoadControl;

namespace mainVentana.vistaReportes
{
    public partial class frmMenuReportes : Form
    {
        private bool _isBusy;

        public frmMenuReportes()
        {
            InitializeComponent();
        }

        private async void sd1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 10;
            dgvRepos.DataSource = null;
            ngbdReportes rep = new ngbdReportes();
            progressBar1.Value = 40;
            var lst = await rep.sd1();
            dgvRepos.DataSource = lst;

            txbTotal.Text = lst.Count.ToString();
            progressBar1.Value = 60;
            await Task.Run(() => { Thread.Sleep(1000); });
            progressBar1.Value = 80;
            formatodeceldas();
            progressBar1.Value = 100;
            label2.Text = $"+ de {numericUpDown1.Value} dias en almacen:";
            label3.Text = $"- de {numericUpDown1.Value} dias en almacen:";
        
            progressBar1.Visible = false;
            
        }



        private void formatodeceldas()
        {
            int ma = 0;
            int me = 0;

            DateTime fechaActual = DateTime.Now.Date;
            DateTime fechaInicio = fechaActual.AddDays(-Convert.ToDouble(numericUpDown1.Value) + 1); // Ajustado para incluir la fecha de inicio.

            foreach (DataGridViewRow row in dgvRepos.Rows)
            {
                if (DateTime.TryParse(row.Cells[2].Value.ToString().Trim(), out DateTime fechaEntrada))
                {
                    fechaEntrada = fechaEntrada.Date; // Obtiene solo la fecha sin el tiempo.

                    if (fechaEntrada >= fechaInicio && fechaEntrada <= fechaActual)
                    {
                        // Pinta de verde.
                        PintarCelda(row.Cells[2], Color.FromArgb(19, 156, 18));
                        PintarCelda(row.Cells[0], Color.FromArgb(19, 156, 18));
                        me++;
                    }
                    else
                    {
                        // Pinta de rojo.
                        PintarCelda(row.Cells[2], Color.FromArgb(156, 19, 18));
                        PintarCelda(row.Cells[0], Color.FromArgb(156, 19, 18));
                        ma++;
                    }
                }
            }

            txbMa.Text = ma.ToString();
            txbMe.Text = me.ToString();
        }


        private void PintarCelda(DataGridViewCell celda, Color colorFondo)
        {
            celda.Style.BackColor = colorFondo;
            celda.Style.ForeColor = Color.FromArgb(255, 255, 255);
        }




        private async void sd2_Click(object sender, EventArgs e)
        {


            dgvRepos.DataSource = null;
            ngbdReportes rep = new ngbdReportes();

            var lst = await rep.sd2();
            dgvRepos.DataSource = lst;

            txbTotal.Text = lst.Count.ToString();

            await Task.Run(() => { Thread.Sleep(1000); });
            formatodeceldas();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
           
            if (dgvRepos.Rows.Count <= 0)
            {
                MessageBox.Show("No hay datos para Enviar");
             
                return;
            }

            List<vmCorreoInforma> list = new List<vmCorreoInforma>();
            int filas = dgvRepos.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
               
                DateTime fechaactual = DateTime.Now;
                DateTime fechaent;
                DateTime dt;
                if (dgvRepos.Rows[i].Cells[2].Value.ToString().Trim() == "")
                {
                    fechaent = DateTime.Parse("7/6/2021 12:16:02 PM");
                }
                else
                {
                    fechaent = DateTime.TryParse(dgvRepos.Rows[i].Cells[2].Value.ToString().Trim(), out dt) == false ? DateTime.Parse("7/6/2021 12:16:02 PM") : dt;
                }



                TimeSpan tiempo = fechaactual - fechaent;



                if (tiempo > TimeSpan.Parse("3.00:00:0.0"))
                { //cuando un item tiene mas de 15 dias en el almacen y la sursal actual es igual a la sucursal origen

                    list.Add(new vmCorreoInforma
                    {
                        Entrada = dgvRepos.Rows[i].Cells[0].Value.ToString().Trim(),
                        Fechadeentrada = dgvRepos.Rows[i].Cells[2].Value.ToString().Trim(),
                        correo = dgvRepos.Rows[i].Cells[4].Value.ToString().Trim(),
                        Descipcion = dgvRepos.Rows[i].Cells[6].Value.ToString().Trim(),
                        eti = dgvRepos.Rows[i].Cells[1].Value.ToString().Trim()
                    });
                }
            }
            GeneraCorreo(list);

        }

        private void ExportExcel()
        {

            if (dgvRepos.Rows.Count > 0)
            {
                DataTable dt = new DataTable();


                foreach (DataGridViewColumn column in dgvRepos.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }


                foreach (DataGridViewRow row in dgvRepos.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value == null ? "" : cell.Value.ToString();
                    }
                }

                //Exporting to Excel
                string path = null;


                saveFileDialog1.InitialDirectory = @"C\:";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;
                }
                else
                {
                    return;
                }

                /*if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }*/
                using (XLWorkbook xlfile = new XLWorkbook())
                {
                    string hoy = DateTime.Now.ToString("dd-MM-yyyy");
                    string fullPath = path + "_" + hoy + ".xlsx";
                    xlfile.Worksheets.Add(dt, "Reporte");
                    xlfile.Table("Reporte").ShowAutoFilter = false;// Disable AutoFilter.
                    xlfile.Table("Reporte").Theme = XLTableTheme.None;// Remove Theme.
                    xlfile.SaveAs(fullPath);
                    Process.Start(fullPath);
                }
            }
            else
            {
                MessageBox.Show("No hay datos para exportar");
                return;
            }
        }

        private async void GeneraCorreo(List<vmCorreoInforma> dato)
        {


            var correos = new HashSet<string>(dato.Select(d => d.correo).ToList()).ToList();


            List<vmCorreoInforma> lss = new List<vmCorreoInforma>();
            string mensaje = String.Format(@"<html>
                       <body>
                       <p>Las siguientes entradas cuentan con más de <b>3 días en almacén San Diego</b>  <br></p>
                       <p>Es probable que la mayoría ya hayan salido, de manera aérea, especial, o sean un error, favor de revisarlas.<br><br><br></p>
                       <p>Este reporte se ha enviado de forma automática. Cualquier error favor de comunicarlo al departamento de Sistemas.<br><br></p>
                       <p><b>Reporte Generado Por:</b> <br>{0}<br></p>
                        <p>Desde:<br><b>Arsys</b> , Sistema Arnian<br></p>
                       <p>--------------------------------------</p>
                       </body>
                       </html>", Negocios.Common.Cache.CacheLogin.nombre.Trim());

            foreach (var q in correos)
            {
                lss.Clear();
                foreach (var d in dato)
                {
                    if (q.Equals(d.correo.Trim()))
                    {
                        lss.Add(new vmCorreoInforma { eti = d.eti, Entrada = d.Entrada, Fechadeentrada = d.Fechadeentrada, Descipcion = d.Descipcion, correo = d.correo });
                    }
                }

                string path = AppDomain.CurrentDomain.BaseDirectory;
                string folder = path + "\\temp\\";
                string hoy = DateTime.Now.ToString("dd-MM-yyyy");
                string fullPath = folder + hoy + ".xlsx";

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                new frmMenuReportes().Export<vmCorreoInforma>(lss, fullPath, "Reporte");
                await llamasmtp(mensaje, q, fullPath);
               
            }


        }
        public bool Export<T>(List<T> list, string file, string nombre)
        {
            bool exportado = false;
            using (XLWorkbook xlfile = new XLWorkbook())
            {
                xlfile.AddWorksheet(nombre).FirstCell().InsertTable<T>(list, false);
                xlfile.SaveAs(file);
                exportado = true;

            }
            return exportado;
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }


        private async Task llamasmtp(string body, string correo, string path)
        {
            

            using (MailMessage msg = new MailMessage())
            {
                SmtpClient smtp = new SmtpClient();
                msg.IsBodyHtml = true;
                msg.From = new MailAddress(Negocios.Common.Cache.CacheLogin.smtpemail);
                msg.Subject = "Entradas con mas de 3 dias en almacen SD";


                msg.IsBodyHtml = true;

                msg.Body = body;





                msg.To.Add(new MailAddress(correo));
                //msg.CC.Add(new MailAddress("meliza.garcia@arnian.com"));
                msg.CC.Add(new MailAddress("sistemas@arnian.com"));
                msg.CC.Add(new MailAddress("operaciones@arnian.com"));
               // msg.CC.Add(new MailAddress("marcos.martinez@arnian.com "));

                long pesoArch = 0;

                FileInfo fileinfo = new FileInfo(path);
                pesoArch = pesoArch + fileinfo.Length;



                if (pesoArch >= 25000000)
                {
                    MessageBox.Show("El peso de los archivos excede los 25MB que Google admite, por favor reduce el peso eliminando archivos innecesarios.");
                    return;
                }
                msg.Attachments.Add(new Attachment(path));



                /*
                if (textBox5.Text != "")
                {
                    string[] toCC = textBox5.Text.Split(',');
                    foreach (string ToCCId in toCC)
                    {
                        msg.CC.Add(new MailAddress(ToCCId));
                    }
                }
                if (textBox4.Text != "")
                {
                    string[] toBCC = textBox4.Text.Split(',');
                    foreach (string ToBCCId in toBCC)
                    {
                        msg.Bcc.Add(new MailAddress(ToBCCId));
                    }
                }*/
                smtp.Host = "smtp.gmail.com";//textBox8.Text;
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                NetworkCredential nc = new NetworkCredential(Negocios.Common.Cache.CacheLogin.smtpemail, Negocios.Common.Cache.CacheLogin.smatppss);
                smtp.Credentials = nc;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                try
                {
                    await smtp.SendMailAsync(msg);
                }
                catch (Exception)
                {

                    throw;
                }

                

            }
       

        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }
        
        private void frmMenuReportes_Load(object sender, EventArgs e)
        {
            if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "ADMIN" || Negocios.Common.Cache.CacheLogin.rol.Trim() == "JALMA")
            {
                gunaAdvenceButton1.Visible = true;
            }
            else
            {
                gunaAdvenceButton1.Visible = false;
            }
           
        }

        private void numericUpDown1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (_isBusy == false && numericUpDown1.Value!=1)
                {
                    _isBusy = true;
                    formatodeceldas();
                    label2.Text = $"+ de {numericUpDown1.Value} dias en almacen:";
                    label3.Text = $"- de {numericUpDown1.Value} dias en almacen:";
                    _isBusy = false;

                }
            }
        }
    }
}
