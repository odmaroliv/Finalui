using Negocios.Odoo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
//using Amazon.Runtime;

namespace Negocios
{
    public class EnviarEmail
    {
       
        const long TAMANO_MAXIMO_TOTAL_POR_CORREO = 15000000; // 15MB como límite por correo
        const long TAMANO_MAXIMO_ARCHIVO = 7000000; // 7MB por archivo individual
        const int TIMEOUT_SMTP = 300000; // 5 minutos
        const int MAXIMO_ARCHIVOS_POR_CORREO = 10; // Máximo número de archivos por correo

        public async Task<int> EnviaMail(string Entrada, string Cliente, string Notraking, string Alias, string OrdCompra, string Noflete, string Proveedor, string Desc, List<string> Archivos, string correosClientes, bool isDano, long idCord = 0)
        {

            int bandera = default;
            try
            {
                OdooClient ng = new OdooClient();
                var correoCord = await ng.GetUserById(idCord);

                // Lista para almacenar información sobre los archivos validados
                List<(string Ruta, long Tamano)> archivosValidos = new List<(string, long)>();

                // Pre-procesar y validar todos los archivos
                foreach (var rutaArchivo in Archivos)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(rutaArchivo) || !File.Exists(rutaArchivo))
                        {
                            Negocios.LOGs.ArsLogs.LogEdit($"Archivo no encontrado o ruta vacía: {rutaArchivo}", "Archivo no válido");
                            continue;
                        }

                        // Verificar tamaño del archivo individual
                        FileInfo fileInfo = new FileInfo(rutaArchivo);
                        if (fileInfo.Length > TAMANO_MAXIMO_ARCHIVO)
                        {
                            Negocios.LOGs.ArsLogs.LogEdit($"Archivo demasiado grande: {rutaArchivo}, tamaño: {fileInfo.Length} bytes", "Archivo excede límite individual");
                            continue;
                        }

                        // Agregar a la lista de archivos válidos con su tamaño
                        archivosValidos.Add((rutaArchivo, fileInfo.Length));
                    }
                    catch (Exception ex)
                    {
                        Negocios.LOGs.ArsLogs.LogEdit($"Error al procesar archivo {rutaArchivo}: {ex.Message}", "Error validación adjunto");
                    }
                }

                // Si no hay archivos válidos pero se esperaban adjuntos
                if (Archivos.Count > 0 && archivosValidos.Count == 0)
                {
                    Negocios.LOGs.ArsLogs.LogEdit("Ninguno de los archivos pudo ser procesado", "Sin adjuntos válidos");
                    bandera = 4;
                }

                // Dividir los archivos en lotes que respeten el tamaño máximo total
                List<List<string>> lotesDeArchivos = new List<List<string>>();
                List<string> loteActual = new List<string>();
                long tamanoLoteActual = 0;
                int contadorArchivosLote = 0;

                foreach (var (rutaArchivo, tamanoArchivo) in archivosValidos)
                {
                    // Si agregar este archivo excedería el límite o el número máximo de archivos, crear nuevo lote
                    if (tamanoLoteActual + tamanoArchivo > TAMANO_MAXIMO_TOTAL_POR_CORREO ||
                        contadorArchivosLote >= MAXIMO_ARCHIVOS_POR_CORREO)
            {
                        if (loteActual.Count > 0)
                        {
                            lotesDeArchivos.Add(new List<string>(loteActual));
                            loteActual.Clear();
                            tamanoLoteActual = 0;
                            contadorArchivosLote = 0;
                        }
                    }

                    // Agregar archivo al lote actual
                    loteActual.Add(rutaArchivo);
                    tamanoLoteActual += tamanoArchivo;
                    contadorArchivosLote++;
                }

                // Agregar el último lote si contiene archivos
                if (loteActual.Count > 0)
                {
                    lotesDeArchivos.Add(loteActual);
                }

                Negocios.LOGs.ArsLogs.LogEdit($"Distribución de archivos: {archivosValidos.Count} archivos divididos en {lotesDeArchivos.Count} lotes", "Información de distribución");

                // Enviar cada lote como un correo separado
                int resultadoFinal = 0;
                int lotesExitosos = 0;

                for (int i = 0; i < lotesDeArchivos.Count; i++)
                {
                    var lote = lotesDeArchivos[i];

                    // Modificar el asunto para lotes múltiples
                    string asuntoLote = lotesDeArchivos.Count > 1
                        ? $"{(isDano ? "[Dañado] " : "")}Notificacion Arnian entrada: {Entrada} (Parte {i + 1} de {lotesDeArchivos.Count})"
                        : $"{(isDano ? "[Dañado] " : "")}Notificacion Arnian entrada: {Entrada}";

                    int resultado = await EnviarLoteDeArchivos(
                        lote,
                        asuntoLote,
                        Entrada, Cliente, Notraking, Alias, OrdCompra, Noflete, Proveedor, Desc,
                        correosClientes, isDano, correoCord, i, lotesDeArchivos.Count);

                    if (resultado == 3)
                        lotesExitosos++;

                    // Guardar el primer resultado no exitoso o el último exitoso
                    if (resultadoFinal != 2 || resultado == 3)
                        resultadoFinal = resultado;

                    // Si algún lote falla, registrarlo pero continuar con los demás
                    if (resultado != 3)
                    {
                        Negocios.LOGs.ArsLogs.LogEdit($"El lote {i + 1} falló con código: {resultado}", "Fallo en lote");
                    }

                    // Pequeña pausa entre lotes para no sobrecargar el servidor SMTP
                    if (i < lotesDeArchivos.Count - 1)
                        await Task.Delay(2000);
                }

                // Si al menos un lote fue exitoso pero no todos, usar código especial
                if (lotesExitosos > 0 && lotesExitosos < lotesDeArchivos.Count)
                {
                    bandera = 6; // Código especial: algunos lotes enviados exitosamente
                    Negocios.LOGs.ArsLogs.LogEdit($"Envío parcial: {lotesExitosos} de {lotesDeArchivos.Count} lotes enviados correctamente", "Envío parcial");
                }
                else
                {
                    bandera = resultadoFinal;
                }

                return bandera;
            }
            catch (Exception x)
            {
                Negocios.
        LOGs.ArsLogs.LogEdit($"Excepción en el método EnviaMail: {x.Message}", $"Correo SMTP NORMAL {Entrada}");
                return 2;
            } 
        }

            // Método interno para enviar un lote de archivos
            async Task<int> EnviarLoteDeArchivos(
                List<string> archivosLote,
                string asunto,
                string Entrada, string Cliente, string Notraking, string Alias,
                string OrdCompra, string Noflete, string Proveedor, string Desc,
                string correosClientes, bool isDano, string correoCord,
                int numeroLote, int totalLotes)
            {
                return await Task.Run<int>(() =>
                {
                    try
                    {
                        using (MailMessage msg = new MailMessage())
                        using (SmtpClient smtp = new SmtpClient())
                        {
                            // Configuración básica del mensaje
                            msg.IsBodyHtml = true;
                            msg.From = new MailAddress("notificaciones@arnian.com");
                            msg.Subject = asunto;

                            // Establecer prioridad
                            msg.Priority = isDano ? MailPriority.High : MailPriority.Normal;

                            // Adjuntar archivos del lote
                            foreach (var archivo in archivosLote)
                            {
                                try
                                {
                                    msg.Attachments.Add(new Attachment(archivo));
                                }
                                catch (Exception ex)
                                {
                                    Negocios.LOGs.ArsLogs.LogEdit($"Error al adjuntar {archivo}: {ex.Message}", "Error adjuntando en lote");
                                }
                            }

                            // Preparar el cuerpo del mensaje
                            string plantilla = Properties.Resources.Arnian2022.ToString();
                            plantilla = plantilla.Replace("@ENTRADA", Entrada);
                            plantilla = plantilla.Replace("@CLIENTE", Cliente);
                            plantilla = plantilla.Replace("@TRAKING", Notraking);
                            plantilla = plantilla.Replace("@ALIAS", Alias);
                            plantilla = plantilla.Replace("@ORDCOMPRA", OrdCompra);
                            plantilla = plantilla.Replace("@NOFLETE", Noflete);
                            plantilla = plantilla.Replace("@PROVEEDOR", Proveedor);
                            plantilla = plantilla.Replace("@CUERPO", Desc);

                            // Agregar información sobre el lote si hay múltiples
                            if (totalLotes > 1)
                            {
                                string notaLotes = $"<p><strong>Nota:</strong> Este correo es la parte {numeroLote + 1} de {totalLotes} " +
                                    $"debido al tamaño total de los archivos adjuntos. Por favor, espere a recibir todos los correos.</p>";
                                plantilla = plantilla.Replace("@DANADO", isDano ? "Contiene mercancía dañada. " + notaLotes : notaLotes);

                            }
                            else
                            {
                                plantilla = plantilla.Replace("@DANADO", isDano ? "Contiene mercancía dañada." : "");
                            }

                            using (StringReader sr = new StringReader(plantilla))
                            {
                                msg.Body = sr.ReadToEnd().ToString();
                            }

                            // Agregar destinatarios
                            try
                            {
                                string[] toMail = correoCord == ""
                                    ? "sistemas@arnian.com".Split(',')
                                    : correoCord.Split(',');

                                foreach (string ToEmailId in toMail)
                                {
                                    if (!string.IsNullOrWhiteSpace(ToEmailId.Trim()))
                                    {
                                        msg.To.Add(new MailAddress(ToEmailId.Trim()));
                                    }
                                }

                                if (!string.IsNullOrWhiteSpace(correosClientes))
                                {
                                    string[] toCC = correosClientes.Split(',');
                                    foreach (string ToCCId in toCC)
                                    {
                                        if (!string.IsNullOrWhiteSpace(ToCCId.Trim()))
                                        {
                                            msg.CC.Add(new MailAddress(ToCCId.Trim()));
                                        }
                                    }
                                }

                                // Asegurarse de que sistemas siempre reciba copia
                                if (!msg.CC.Any(cc => cc.Address.Equals("sistemas@arnian.com", StringComparison.OrdinalIgnoreCase)))
                                {
                                    msg.CC.Add(new MailAddress("sistemas@arnian.com"));
                                }
                            }
                            catch (Exception ex)
                            {
                                Negocios.LOGs.ArsLogs.LogEdit($"Error al agregar destinatarios en lote {numeroLote + 1}: {ex.Message}", "Error de destinatarios");
                                return 2;
                            }

                            try
                            {
                                // Configurar cliente SMTP con valores robustos
                                smtp.Host = "smtp.gmail.com";
                                smtp.Port = 587;
                                smtp.EnableSsl = true;
                                smtp.UseDefaultCredentials = false;
                                smtp.Timeout = TIMEOUT_SMTP;
                                NetworkCredential nc = new NetworkCredential(Common.Cache.CacheLogin.smtpemail, Common.Cache.CacheLogin.smatppss);
                                smtp.Credentials = nc;
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                                // Verificar conexión antes de enviar
                                bool conexionExitosa = false;

                                using (var tcpClient = new TcpClient())
                                {
                                    try
                                    {
                                        var result = tcpClient.BeginConnect(smtp.Host, smtp.Port, null, null);
                                        conexionExitosa = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(10));
                                    }
                                    catch
                                    {
                                        conexionExitosa = false;
                                    }
                                }

                                if (!conexionExitosa)
                                {
                                    Negocios.LOGs.ArsLogs.LogEdit($"No se pudo conectar al servidor SMTP para lote {numeroLote + 1}", "Error de conexión");
                                    return 2;
                                }

                                // Estrategia de reintento
                                int intentos = 0;
                                const int maxIntentos = 2;

                                while (intentos < maxIntentos)
                                {
                                    try
                                    {
                                        // Enviar el correo
                                        smtp.Send(msg);
                                        Negocios.LOGs.ArsLogs.LogEdit($"Lote {numeroLote + 1} enviado exitosamente con {archivosLote.Count} archivos", "Envío exitoso");
                                        return 3; // Éxito
                                    }
                                    catch (SmtpException smtpEx) when (
                                        smtpEx.Message.Contains("tiempo de espera") ||
                                        smtpEx.Message.Contains("timeout") ||
                                        smtpEx.Message.Contains("timed out") ||
                                        smtpEx.StatusCode == SmtpStatusCode.ServiceNotAvailable)
                                    {
                                        intentos++;
                                        Negocios.LOGs.ArsLogs.LogEdit($"Intento {intentos}: Timeout en lote {numeroLote + 1}: {smtpEx.Message}", "Error de timeout");

                                        if (intentos >= maxIntentos)
                                        {
                                            Negocios.LOGs.ArsLogs.LogEdit($"Agotados los intentos para el lote {numeroLote + 1}", "Fallo definitivo");
                                            return 2;
                                        }

                                        // Esperar antes de reintentar
                                        Thread.Sleep(5000);
                                    }
                                    catch (Exception ex)
                                    {
                                        Negocios.LOGs.ArsLogs.LogEdit($"Error al enviar lote {numeroLote + 1}: {ex.Message}", "Error de envío");
                                        return 2;
                                    }
                                }


                                return 2; // Si llega aquí, falló todos los intentos
                            }
                            catch (Exception ex)
                            {
                                Negocios.LOGs.ArsLogs.LogEdit($"Error de configuración SMTP para lote {numeroLote + 1}: {ex.Message}", "Error de configuración");
                                return 2;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Negocios.LOGs.ArsLogs.LogEdit($"Error general en lote {numeroLote + 1}: {ex.Message}", "Error general");
                        return 2;
                    }
                });
            }
        

        public async Task<int> EnviaMailSencillo(string encabezado, string body, string archivo, string correosClientes)
        {
            int bandera = default;

            try
            {
             
                await Task.Run(() =>
                {
                    MailMessage msg = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    msg.IsBodyHtml = true;
                    msg.From = new MailAddress("notificaciones@arnian.com");
                    msg.Subject = encabezado;
                    long pesoArch = 0;

                    
                        msg.Attachments.Add(new Attachment(archivo));
                        FileInfo fileinfo = new FileInfo(archivo);
                        pesoArch = pesoArch + fileinfo.Length;
                    

                    if (pesoArch >= 25000000)
                    {
                        bandera = 1;
                    }

                    

                        msg.Body = body;
                    

                    try
                    {
                        

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
                Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Correo SMTP NORMAL " + encabezado);
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
