using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Datos.ViewModels.Odoo;
using Newtonsoft.Json;

namespace Negocios.Odoo
{
    internal class OdooClient
    {
        private readonly HttpClient _client;

        public OdooClient()
        {
            _client = new HttpClient();
            // Configura aquí tus credenciales de autenticación básica
            var authToken = Encoding.ASCII.GetBytes(Common.Cache.CacheLogin.bbud+":"+Common.Cache.CacheLogin.bbps);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
            _client.BaseAddress = new Uri("https://apimb.arnian.com:6961/");
        }

        public async Task<bool> CreateOdooEntry(OdooProductTemplate productTemplate)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(productTemplate);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _client.PostAsync("api/OdooClient/CreateProductTemplate", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Producto creado con éxito.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al crear el producto: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción al enviar la solicitud: {ex.Message}");
                return false;
            }
        }


        //TODO: Cambiar por este metodo el actual para la busqueda de clientes

        public async Task<List<OdooClienteDto>> GetAllClients()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("api/OdooClient/GetAllClients");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var clients = JsonConvert.DeserializeObject<List<OdooClienteDto>>(content);
                    if (clients == null || clients.Count == 0)
                        return new List<OdooClienteDto>();

                    return new List<OdooClienteDto>(clients);
                }
                else
                {
                    return new List<OdooClienteDto>();
                }
            }
            catch (Exception ex)
            {
                return new List<OdooClienteDto>();
            }
        }

    }
}
