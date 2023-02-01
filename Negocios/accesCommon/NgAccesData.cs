using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using Negocios.Properties;

namespace Negocios.accesCommon
{
    public  class NgAccesData
    {
        string usernameapi = Settings.Default.apiUs;
        string passwordapi = Settings.Default.apiPs;

        public async Task ObtenerCredenciales()
        {
            var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{usernameapi}:{passwordapi}")));

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = authValue;
                    var response = await client.GetAsync("http://104.198.241.64:90/api/arsauth/gc");

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var credenciales = JsonConvert.DeserializeObject<dynamic>(json);
                        Common.Cache.AccesData.uso = credenciales.usue;
                        Common.Cache.AccesData.psd = credenciales.asso;
                    }
                }
            }
            catch
            {
            }
        }





    }
}
