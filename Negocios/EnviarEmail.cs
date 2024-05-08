using Negocios.Odoo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
//using Amazon.Runtime;

namespace Negocios
{
    public class EnviarEmail
    {

        public async Task<int> EnviaMail(string Entrada, string Cliente, string Notraking, string Alias, string OrdCompra, string Noflete, string Proveedor, string Desc, List<string> Archivos, string correosClientes, bool isDano, long idCord = 0)
        {
            int bandera = default;

            try
            {
               OdooClient ng = new OdooClient();
                var correoCord = await ng.GetUserById(idCord);

                await Task.Run(() =>
                {
                    MailMessage msg = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    msg.IsBodyHtml = true;
                    msg.From = new MailAddress("notificaciones@arnian.com");
                    msg.Subject = "Notificacion Arnian entrada: " + Entrada;
                    long pesoArch = 0;

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
                    if (isDano)
                    {
                        plantilla = plantilla.Replace("@DANADO", "Contiene mercancía dañada.");
                        msg.Subject = "[Dañado] Notificacion Arnian entrada: " + Entrada;
                    }
                    else
                    {
                        plantilla = plantilla.Replace("@DANADO", "");
                    }


                    using (StringReader sr = new StringReader(plantilla))
                    {
                        msg.Body = sr.ReadToEnd().ToString();
                    }

                    try
                    {
                        string[] toMail = correoCord == "" ? "sistemas@arnian.com".Split(',') : correoCord.Split(',');
                        foreach (string ToEmailId in toMail)
                        {
                            msg.To.Add(new MailAddress(ToEmailId));
                        }

                        if (!string.IsNullOrWhiteSpace(correosClientes))
                        {
                            string[] toCC = correosClientes.Split(',');
                            foreach (string ToCCId in toCC)
                            {
                                msg.CC.Add(new MailAddress(ToCCId));
                            }
                        }

                        msg.CC.Add(new MailAddress("sistemas@arnian.com"));
                    }
                    catch (Exception x)
                    {
                        Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Podria esta vacia la cadena de Correo");
                        bandera = 2;
                    }

                    try
                    {
                        smtp.Host = "smtp.gmail.com";
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
                        Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Correo, al hacer clic al boton de guardar o cualquier boton de que llame al corre, anteriormente este error se dio porque no se podia autenticar una cuenta, estaba bloqueada en el Administrador de dominio");
                        throw;
                    }

                });
                return bandera;
            }
            catch (Exception x)
            {
                Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Correo SMTP NORMAL " + Entrada);
            }
            return bandera;
        }



        /*
            public async Task<int> EnviaMailAmazonSES(string Entrada, string Cliente, string Notraking, string Alias, string OrdCompra, string Noflete, string Proveedor, string Desc, List<string> attachmentPaths, string correosClientes, string idCord = "")
        {
            string subject = "Notificacion Arnian entrada: " + Entrada;
            string bodyHtml = ConstruirCuerpoDelCorreo(Entrada, Cliente, Notraking, Alias, OrdCompra, Noflete, Proveedor, Desc);
            Negocios.Servicios ng = new Servicios();
            string correoCord = await ng.obtieneCorreoCord(idCord);
            List<string> toAddresses = ObtenerToAddresses(correosClientes);
            List<string> ccAddresses = ObtenerToAddresses(correoCord);
            List<string> bccAddresses = ObtenerToAddresses("sistemas@arnian.com");
            string senderAddress = "notificaciones@arnian.com";

            int respueta =  await SendEmailAsync(toAddresses, ccAddresses, bccAddresses, bodyHtml, subject, senderAddress, attachmentPaths);
            return respueta;
        }


        public async Task<int> SendEmailAsync(List<string> toAddresses, List<string> ccAddresses, List<string> bccAddresses, string bodyHtml, string subject, string senderAddress, List<string> attachmentPaths = null)
        {
            var messageId = 0;
            try
            {
                var awsCredentials = new Amazon.Runtime.BasicAWSCredentials("", "");
               
                using (var client = new AmazonSimpleEmailServiceClient(awsCredentials, Amazon.RegionEndpoint.USEast2))
                {
                    var message = new StringBuilder();
                    message.AppendLine("From: " + senderAddress);
                    message.AppendLine("To: " + string.Join(",", toAddresses));
                    if (ccAddresses != null && ccAddresses.Any())
                    {
                        message.AppendLine("Cc: " + string.Join(",", ccAddresses));
                    }
                    if (bccAddresses != null && bccAddresses.Any())
                    {
                        message.AppendLine("Bcc: " + string.Join(",", bccAddresses));
                    }
                    message.AppendLine("Subject: " + subject);
                    message.AppendLine("MIME-Version: 1.0");
                    message.AppendLine("Content-Type: multipart/mixed; boundary=\"boundary_\"");
                    message.AppendLine();
                    message.AppendLine("--boundary_");
                    message.AppendLine("Content-Type: text/html; charset=utf-8");
                    message.AppendLine();
                    message.AppendLine(bodyHtml);

                    if (attachmentPaths != null && attachmentPaths.Any())
                    {
                        foreach (var attachmentPath in attachmentPaths)
                        {
                            var filename = Path.GetFileName(attachmentPath);
                            var contentType = MimeMapping.GetMimeMapping(filename);
                            var fileContent = Convert.ToBase64String(File.ReadAllBytes(attachmentPath));

                            message.AppendLine("--boundary_");
                            message.AppendLine($"Content-Type: {contentType}");
                            message.AppendLine($"Content-Disposition: attachment; filename=\"{filename}\"");
                            message.AppendLine($"Content-Transfer-Encoding: base64");
                            message.AppendLine();
                            message.AppendLine(fileContent);
                        }
                    }
                    message.AppendLine("--boundary_--");

                    var sendEmailRequest = new SendRawEmailRequest
                    {
                        RawMessage = new RawMessage
                        {
                            Data = new MemoryStream(Encoding.UTF8.GetBytes(message.ToString()))
                        },

                        Source = senderAddress,
                        Destinations = toAddresses.Concat(ccAddresses ?? new List<string>()).Concat(bccAddresses ?? new List<string>()).ToList()
                    };

                    try
                    {
                        var response = await client.SendRawEmailAsync(sendEmailRequest);
                        messageId = 3;
                    }
                    catch (AmazonSimpleEmailServiceException ex)
                    {
                        if (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
                        {
                            messageId = 1;
                        }
                        else
                        {
                            messageId = 2;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendEmailAsync failed with exception: " + ex.Message);
                Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "Correo AMAZON ");
                messageId = 2;

                
            }

            return messageId;
        }
        */


        private string ConstruirCuerpoDelCorreo(string entrada, string cliente, string notraking, string alias, string ordCompra, string noflete, string proveedor, string desc)
        {
            string plantilla = Properties.Resources.Arnian2022.ToString();
            plantilla = plantilla.Replace("@ENTRADA", entrada);
            plantilla = plantilla.Replace("@CLIENTE", cliente);
            plantilla = plantilla.Replace("@TRAKING", notraking);
            plantilla = plantilla.Replace("@ALIAS", alias);
            plantilla = plantilla.Replace("@ORDCOMPRA", ordCompra);
            plantilla = plantilla.Replace("@NOFLETE", noflete);
            plantilla = plantilla.Replace("@PROVEEDOR", proveedor);
            plantilla = plantilla.Replace("@CUERPO", desc);

            return plantilla;
        }


        private static MemoryStream ConvertToMemoryStream(string filePath)
        {
            MemoryStream memoryStream = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memoryStream);
            }
            return memoryStream;
        }

        public List<string> ObtenerToAddresses(string correosDestinatarios)
        {
            List<string> toAddresses = new List<string>();
            if (!string.IsNullOrEmpty(correosDestinatarios))
            {
                string[] correos = correosDestinatarios.Split(',');
                foreach (string correo in correos)
                {
                    toAddresses.Add(correo.Trim());
                }
            }
            return toAddresses;
        }

    }


}
