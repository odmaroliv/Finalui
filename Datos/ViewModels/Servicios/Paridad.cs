using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Servicios
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ListaIndicadore
    {
        public int codIndicador { get; set; }
        public int codTipoIndicador { get; set; }
        public string fecha { get; set; }
        public string valor { get; set; }
    }

    public class Root
    {
        public int messageCode { get; set; }
        public string response { get; set; }
        public List<ListaIndicadore> ListaIndicadores { get; set; }
    }


}
