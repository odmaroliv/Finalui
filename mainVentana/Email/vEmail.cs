using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.ViewModels.Email;

namespace mainVentana.Email
{
    public partial class vEmail : Form
    {
        
        public vEmail()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            
            
            MailMessage msg = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            msg.IsBodyHtml = true;
            msg.From = new MailAddress("smtpdniell@gmail.com");
            msg.Subject = textBox3.Text;
            long pesoArch = 0;
            
            foreach (var item in mnd) //Attachment
            {
                msg.Attachments.Add(new Attachment(item));
                FileInfo fileinfo = new FileInfo(item);
                pesoArch = pesoArch + fileinfo.Length;
                MessageBox.Show(item+" peso "+pesoArch.ToString());
                
            }
            
            if (pesoArch >= 25000000)
            {
                MessageBox.Show("El peso de los archivos excede los 25MB que Google admite, por favor reduce el peso eliminando archivos innecesarios.");
                return;
            }
            string plantilla = Properties.Resources.correoskepler.ToString();
            plantilla = plantilla.Replace("@CUERPO", textBox7.Text);
            using (StringReader sr = new StringReader(plantilla))
            {
                msg.Body = sr.ReadToEnd().ToString();
            }



            
            string[] toMail = textBox6.Text.Split(',');
            foreach (string ToEmailId in toMail)
            {
                msg.To.Add(new MailAddress(ToEmailId));
            }
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
            }
            smtp.Host = "smtp.gmail.com";//textBox8.Text;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential("smtpdniell@gmail.com", "uukcdonkhscscxwt");
            smtp.Credentials = nc;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;


            smtp.Send(msg);
            msg.Attachments.Clear();
            msg.Attachments.Dispose();
            msg.Dispose();
        }

        List<string> mnd = new List<string>();
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "@C:\\";
            openFileDialog1.Filter = "Selecciona los archivos (JPG,PNG,PDF,WORD)|*.JPG;*.PNG;*.GIF;*.PDF;*.DOCX";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Selector de archivos";
            
            
            mnd.Clear();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] imagen = openFileDialog1.FileNames;
                    foreach (var i in imagen)
                    {
                        mnd.Add(i.ToString());
                    }
                 
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void vEmail_Load(object sender, EventArgs e)
        {

        }
        
        public void EnviaMail(string Entrada, string Cliente, string Notraking, string Alias, string OrdCompra, string Noflete, string Proveedor, string Desc)
        {
            try
            {
                MailMessage msg = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                msg.IsBodyHtml = true;
                msg.From = new MailAddress("smtpdniell@gmail.com");
                msg.Subject = textBox3.Text;
                long pesoArch = 0;

                foreach (var item in mnd) //Attachment
                {
                    msg.Attachments.Add(new Attachment(item));
                    FileInfo fileinfo = new FileInfo(item);
                    pesoArch = pesoArch + fileinfo.Length;
                    MessageBox.Show(item + " peso " + pesoArch.ToString());

                }

                if (pesoArch >= 25000000)
                {
                    MessageBox.Show("El peso de los archivos excede los 25MB que Google admite, por favor reduce el peso eliminando archivos innecesarios.");
                    return;
                }
                string plantilla = Properties.Resources.correoskepler.ToString();
                plantilla = plantilla.Replace("@ENTRADA", Desc);
                plantilla = plantilla.Replace("@CLIENTE", Desc);
                plantilla = plantilla.Replace("@TRAKING", Desc);
                plantilla = plantilla.Replace("@ALIAS", Desc);
                plantilla = plantilla.Replace("@ORDCOMPRA", Desc);
                plantilla = plantilla.Replace("@NOFLETE", Desc);
                plantilla = plantilla.Replace("@PROVEEDOR", Desc);
                plantilla = plantilla.Replace("@CUERPO", Desc);
                using (StringReader sr = new StringReader(plantilla))
                {
                    msg.Body = sr.ReadToEnd().ToString();
                }




                string[] toMail = textBox6.Text.Split(',');
                foreach (string ToEmailId in toMail)
                {
                    msg.To.Add(new MailAddress(ToEmailId));
                }
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
                }
                smtp.Host = "smtp.gmail.com";//textBox8.Text;
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                NetworkCredential nc = new NetworkCredential("smtpdniell@gmail.com", "uukcdonkhscscxwt");
                smtp.Credentials = nc;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;


                smtp.Send(msg);
                msg.Attachments.Clear();
                msg.Attachments.Dispose();
                msg.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            foreach (var i in mnd)
            {
                //MessageBox.Show(i.Ruta.ToString());
            } 
        }
    }
}
