using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Odoo
{
    public class ProductUpdateRequest
    {
        public long ProductId { get; set; }
        public string NewLocation { get; set; }
        public string OutputNumber { get; set; }
        public long NewIdClient { get; set; }
        public long NewIdSalesUser { get; set; }
        public int NewQtyEtiquetas { get; set; }
        public int NewTOperacion { get; set; }
        public bool IsReadyForBill { get; set; }
        public bool IsFinished { get; set; }
    }
}
