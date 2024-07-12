using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Odoo
{
    public class OdooToBeeModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string description_sale { get; set; }
        public string tipoPago { get; set; }
        public int idContacto { get; set; }
        public int idProducto { get; set; }
        public string comment { get; set; }
        public string defaultCoordinates { get; set; }
        public string contactAddress { get; set; }
        public string salesUserName { get; set; }
        public string current_quote { get; set; }

    }
}
