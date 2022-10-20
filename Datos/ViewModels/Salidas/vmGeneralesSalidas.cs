using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Salidas
{
    public class vmGeneralesSalidas
    {
       // [DisplayName("N° DOCUMENTO")]
        public string sOrigen { get; set; }
        public string sDestino { get; set; }
        public string Transportista { get; set; }
        public string Placas { get; set; }
        public string Chofer { get; set; }
        public string Referencia { get; set; }


    }
}
