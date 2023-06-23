using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Bill
{
    public class vmInfoBill
    {

        public string fromNombre { get; set; }
        public string fromCalle { get; set; }
        public string fromColonia { get; set; }
        public string fromLocalidad { get; set; }
        public string fromZip { get; set; }

        public string toNombre { get; set; }
        public string toCalle { get; set; }
        public string toColonia { get; set; }
        public string toLocalidad { get; set; }
        public string toZip { get; set; }
        public string telCliente { get; set; }
        public string coord { get; set; }
    }
}
