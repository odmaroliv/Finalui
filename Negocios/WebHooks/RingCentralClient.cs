using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Datos.ViewModels.hooks;
using System.Windows.Forms;

namespace Negocios.WebHooks
{
    public class RingCentralClient
    {
        //private readonly string webhookUrl;


        public async Task SendMessageAsync(string Salida, string fechaSalida,string usuario, string ordenesCarga, string etiquetasNoEscaneadas, string refe)
        {
            var message = new
            {
                activity = "SALIDA ARNIAN: "+Salida,
                iconUri = "https://arniangroup.com/wp-content/uploads/2023/03/Dor_To_Dor_Arnian-683x1024.webp",
                title = "Referencia: " +refe,
                attachments = new[]
         {
            new
            {
                type = "Card",
                fallback = "Salida No. " + Salida,
                color = "#00ff2a",
                
                author = new
                {
                    name = "By: "+usuario,
                    
                    iconUri = "https://arniangroup.com/wp-content/uploads/2023/03/Paqueteria_Arnian-1024x1024.webp"
                },
                intro = fechaSalida,
                title = "La salida No:\n" + Salida +"\nFue creada esxitosamente",
                body = "Enviado desde Arsys. " + fechaSalida,
                fields = new[]
                {
                    new { title = "Ordenes Asignadas", value = ordenesCarga, style = "Short" },
                    new { title = "Etiquetas faltantes", value = etiquetasNoEscaneadas, style = "Short" }
                    //new { title = "Etiquetas faltantes", value = etiquetasNoEscaneadas, style = "Short" }
                }
            }
        }
            };
             string webhookUrl = Common.Cache.CacheLogin.rhook;

           
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(webhookUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Webhook enviado exitosamente");
                }
                else
                {
                    MessageBox.Show($"Error al enviar el webhook: {response.StatusCode}");
                }
            }
        }
    }
}

