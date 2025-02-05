using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Datos.ViewModels.Odoo
{
    public class OdooClienteDto
    {

       // [JsonProperty("name")]
        public string Name { get; set; }

       // [JsonProperty("parent_name")]
        public string ParentName { get; set; }
        public string ParentId { get; set; }

        // [JsonProperty("email")]
        public string Email { get; set; }

      //  [JsonProperty("phone")]
        public string Phone { get; set; }
       // [JsonProperty("type")]
        public string Type { get; set; }

      //  [JsonProperty("user_id")]
        public string SalesUserId { get; set; }
        // [JsonProperty("user_name")]
        public string SalesUserName { get; set; }

        public string Zip { get; set; }

        // [JsonProperty("id")]
        public long Id { get; set; }

    }
}
