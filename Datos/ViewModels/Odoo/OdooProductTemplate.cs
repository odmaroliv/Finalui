using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Odoo
{
    public class OdooProductTemplate
    {
        public string Name { get; set; }
        public int RelatedPartnerId { get; set; }
        public int RelatedAgentId { get; set; }
        public decimal ListPrice { get; set; }
        public string DescriptionSale { get; set; }
        public bool PurchaseOk { get; set; }
        public string CurrentLocation { get; set; }
        public string TOperacion { get; set; }
        public string DefaultCode { get; set; }
        public int InitialStock { get; set; }
    }
}
