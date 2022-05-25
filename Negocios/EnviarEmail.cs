using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class EnviarEmail
    {
        public int EnviaMail(string Entrada, string Cliente, string Notraking, string Alias, string OrdCompra, string Noflete, string Proveedor, string Desc,List<string> Fotos, List<string> Archivos)
        {
            int bandera = default;
            try
            {
                MailMessage msg = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                msg.IsBodyHtml = true;
                msg.From = new MailAddress("smtpdniell@gmail.com");
                msg.Subject = "Notificacion Arnian entrada: "+Entrada;
                long pesoArch = 0;

                foreach (var item in Fotos) //Attachment
                {
                    msg.Attachments.Add(new Attachment(item));
                    FileInfo fileinfo = new FileInfo(item);
                    pesoArch = pesoArch + fileinfo.Length;
                }
                foreach (var item in Archivos) //Attachment
                {
                    msg.Attachments.Add(new Attachment(item));
                    FileInfo fileinfo = new FileInfo(item);
                    pesoArch = pesoArch + fileinfo.Length;
                }
                
                if (pesoArch >= 25000000)
                {
                    bandera = 1;
                    return bandera;
                }
                string plantilla = Properties.Resources.correoskepler.ToString();
                plantilla = plantilla.Replace("@ENTRADA", Entrada);
                plantilla = plantilla.Replace("@CLIENTE", Cliente);
                plantilla = plantilla.Replace("@TRAKING", Notraking);
                plantilla = plantilla.Replace("@ALIAS", Alias);
                plantilla = plantilla.Replace("@ORDCOMPRA", OrdCompra);
                plantilla = plantilla.Replace("@NOFLETE", Noflete);
                plantilla = plantilla.Replace("@PROVEEDOR", Proveedor);
                plantilla = plantilla.Replace("@CUERPO", Desc);
                using (StringReader sr = new StringReader(plantilla))
                {
                    msg.Body = sr.ReadToEnd().ToString();
                }




                string[] toMail = "sistemas@arnian.com".Split(',');//textBox6.Text.Split(','); // llenar desde la bd con los datos del cliente 
                foreach (string ToEmailId in toMail)
                {
                    msg.To.Add(new MailAddress(ToEmailId));
                }
                /*if (textBox5.Text != "")
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
                NetworkCredential nc = new NetworkCredential("smtpdniell@gmail.com", "uukcdonkhscscxwt");
                smtp.Credentials = nc;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;


                smtp.Send(msg);
                msg.Attachments.Clear();
                msg.Attachments.Dispose();
                msg.Dispose();
                return bandera = 2;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
