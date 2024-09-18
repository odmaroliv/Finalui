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
    public class OdooClient
    {
        private readonly HttpClient _client;

        public OdooClient()
        {
            _client = new HttpClient();
            // Configura aquí tus credenciales de autenticación básica
            var authToken = Encoding.ASCII.GetBytes(Common.Cache.CacheLogin.bbud + ":" + Common.Cache.CacheLogin.bbps);
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

        public async Task<string> GetUserById(long idUser)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"api/OdooClient/GetUserById?userId={idUser}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var clients = JsonConvert.DeserializeObject<OdooUserModel>(content);
                    if (clients == null || clients.email == "")
                        return "";


                    return clients.email;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public async Task<string> GetClientById(string clientId)
        {
            try
            {
                var idLong = Convert.ToInt64(clientId);
                HttpResponseMessage response = await _client.GetAsync($"api/OdooClient/GetClientById?clientId={idLong}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var clients = JsonConvert.DeserializeObject<OdooClienteDto>(content);
                    if (clients == null)
                        return null;


                    return clients.Email;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<string> UpdateReviewed(string odooId)
        {
            try
            {
                var idLong = Convert.ToInt64(odooId);
                HttpResponseMessage response = await _client.GetAsync($"api/OdooClient/UpdateProducteviewedAsync?id={idLong}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var clients = JsonConvert.DeserializeObject<string>(content);
                    if (clients == null)
                        return null;


                    return clients;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<OdooToBeeModel> GetProductToBeetrackById(long productId)
        {
            OdooToBeeModel retu = new OdooToBeeModel();
            try
            {
                
                HttpResponseMessage response = await _client.GetAsync($"api/OdooClient/GetProductTemplanteById?productId={productId}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var client = JsonConvert.DeserializeObject<OdooToBeeModel>(content);
                    if (client == null)
                        return retu;


                    return client;
                }
                else
                {
                    return retu;
                }
            }
            catch (Exception ex)
            {
                return retu;
            }
        }

        public async Task<long> CreateEntInOdoo(string name, int relatedPartnerId, int relatedAgentId, decimal listPrice, string descriptionSale, bool purchaseOk, string currentLocation, string tOperacion, string defaultCode, int initialStock)
        {
            OdooProductTemplate productTemplate = new OdooProductTemplate
            {
                Name = name,
                RelatedPartnerId = relatedPartnerId,
                RelatedAgentId = relatedAgentId,
                ListPrice = listPrice,
                DescriptionSale = descriptionSale,
                PurchaseOk = purchaseOk,
                CurrentLocation = currentLocation.Trim(),
                TOperacion = tOperacion,
                DefaultCode = defaultCode,
                InitialStock = initialStock
            };

            try
            {
                var json = JsonConvert.SerializeObject(productTemplate);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync("api/OdooClient/CreateProductTemplate", data);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    // Deserializar el JSON para obtener el productId
                    var responseJson = JsonConvert.DeserializeObject<Dictionary<string, long>>(result);
                    if (responseJson != null && responseJson.ContainsKey("productId"))
                    {
                        return responseJson["productId"];
                    }
                    else
                    {
                        // No se encontró el productId en la respuesta
                        return -1;
                    }
                }
                else
                {
                    // Manejar error, posiblemente lanzar una excepción o devolver un código específico
                    return -1;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción, loguear error, etc.
                return -1;
            }
        }

        public async Task UpdateCurrentSuc(long productId, string newLocation, bool isReadyForBill = default)
        {


            try
            {
                var updateRequest = new ProductUpdateRequest
                {
                    ProductId = productId,
                    NewLocation = newLocation,
                    NewIdClient = default,
                    NewIdSalesUser = default,
                    NewQtyEtiquetas = default,
                    OutputNumber = default,
                    NewTOperacion = default,
                    IsReadyForBill = isReadyForBill,
                    IsFinished = default
                };

                // Convertir el objeto a JSON
                var json = JsonConvert.SerializeObject(updateRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = $"api/OdooClient/UpdateCurrentSucOrClientOrQtyEtiquetasOrOperationOrReadyBillOrFinishedOrOutput?productId={productId}&newLocation={Uri.EscapeDataString(newLocation)}";
                if (isReadyForBill)
                {
                    url += "&isReadyForBill=true"; // Añadir el parámetro solo si es true
                }

                HttpResponseMessage response = await _client.PutAsync(url, content);
                if (response.IsSuccessStatusCode) { 

                }
                else
                {
                    // Manejar error, posiblemente lanzar una excepción o devolver un código específico
                    return;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción, loguear error, etc.
                return;
            }
        }

        public async Task UpdateQtyEtiquetas(long productId, string NewQtyEtiquetas)
        {


            try
            {
                var updateRequest = new ProductUpdateRequest
                {
                    ProductId = productId,
                  
                };

                // Convertir el objeto a JSON
                var json = JsonConvert.SerializeObject(updateRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = $"api/OdooClient/UpdateCurrentSucOrClientOrQtyEtiquetasOrOperationOrReadyBillOrFinishedOrOutput?productId={productId}&newQtyEtiquetas={NewQtyEtiquetas}";
               
                HttpResponseMessage response = await _client.PutAsync(url, content);
                if (response.IsSuccessStatusCode)
                {

                }
                else
                {
                    // Manejar error, posiblemente lanzar una excepción o devolver un código específico
                    return;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción, loguear error, etc.
                return;
            }
        }
        public async Task UpdateCurrentSalida(long productId, string salida)
        {


            try
            {
                var updateRequest = new ProductUpdateRequest
                {
                    ProductId = productId,
                    NewLocation = default,
                    NewIdClient = default,
                    NewIdSalesUser = default,
                    NewQtyEtiquetas = default,
                    OutputNumber = salida,
                    NewTOperacion = default,
                    IsReadyForBill = default,
                    IsFinished = default
                };

                // Convertir el objeto a JSON
                var json = JsonConvert.SerializeObject(updateRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = $"api/OdooClient/UpdateCurrentSucOrClientOrQtyEtiquetasOrOperationOrReadyBillOrFinishedOrOutput?productId={productId}&output={Uri.EscapeDataString(salida)}";

                HttpResponseMessage response = await _client.PutAsync(url, content);
                if (response.IsSuccessStatusCode)
                {

                }
                else
                {
                    // Manejar error, posiblemente lanzar una excepción o devolver un código específico
                    return;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción, loguear error, etc.
                return;
            }
        }

    }
}
