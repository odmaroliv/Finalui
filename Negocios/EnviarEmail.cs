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

        public async Task<int> EnviaMail(string Entrada, string Cliente, string Notraking, string Alias, string OrdCompra, string Noflete, string Proveedor, string Desc, List<string> Archivos, string correosClientes, string idCord = "")
        {
            int bandera = default;

            try
            {

                Negocios.Servicios ng = new Servicios();
                string correoCord = await ng.obtieneCorreoCord(idCord);

                await Task.Run(() =>
                {



                    MailMessage msg = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    msg.IsBodyHtml = true;
                    msg.From = new MailAddress("notificaciones@arnian.com");
                    msg.Subject = "Notificacion Arnian entrada: " + Entrada;
                    long pesoArch = 0;

                   /* foreach (var item in Fotos) //Attachment
                    {
                        msg.Attachments.Add(new Attachment(item));
                        FileInfo fileinfo = new FileInfo(item);
                        pesoArch = pesoArch + fileinfo.Length;
                    }*/
                    foreach (var item in Archivos) //Attachment
                    {
                        msg.Attachments.Add(new Attachment(item));
                        FileInfo fileinfo = new FileInfo(item);
                        pesoArch = pesoArch + fileinfo.Length;
                    }
                  
                    if (pesoArch >= 25000000)
                    {
                        bandera = 1;
                        
                    }
                    string plantilla = Properties.Resources.Arnian2022.ToString();
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

                    try
                    {
                        string[] toMail = correoCord == "" ? "sistemas@arnian.com".Split(',') : correoCord.Split(',');//textBox6.Text.Split(','); // llenar desde la bd con los datos del cliente 
                        foreach (string ToEmailId in toMail)
                        {
                            msg.To.Add(new MailAddress(ToEmailId));
                        }
                        if (correosClientes != "")
                        {
                            string[] toCC = correosClientes.Split(',')[0].Trim() == "" ? "sistemas@arnian.com".Split(',') : correosClientes.Split(',');
                            foreach (string ToCCId in toCC)
                            {
                                msg.CC.Add(new MailAddress(ToCCId));
                            }
                        }
                    }
                    catch (Exception x)
                    {
                        Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Podria esta vacia la cadena de Correo");
                        bandera = 2; 
                    }

                    



                    /*if (textBox4.Text != "")
                    {
                        string[] toBCC = textBox4.Text.Split(',');
                        foreach (string ToBCCId in toBCC)
                        {
                            msg.Bcc.Add(new MailAddress(ToBCCId));
                        }
                    }*/
                    try
                    {
                        smtp.Host = "smtp.gmail.com";//textBox8.Text;
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    NetworkCredential nc = new NetworkCredential(Common.Cache.CacheLogin.smtpemail, Common.Cache.CacheLogin.smatppss);
                    smtp.Credentials = nc;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                   
                        smtp.Send(msg);
                        msg.Attachments.Clear();
                        msg.Attachments.Dispose();
                        msg.Dispose();
                        msg = null;
                        smtp.Dispose();
                        smtp = null;
                        bandera = 3;
                    }
                    catch (Exception x)
                    {

                        bandera = 2;
                        Negocios.LOGs.ArsLogs.LogEdit(x.Message,"Correo, al hacer clic al boton de guardar o cualquier boton de que llame al corre, anteriormente este error se dio porque no se podia autenticar una cuenta, estaba bloqueada en el Administrador de dominio");
                        throw;
                    }


                });
                return bandera;
            }
            catch (Exception x)
            {
                Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Correo");
            }
            return bandera;
        }


    }


}
