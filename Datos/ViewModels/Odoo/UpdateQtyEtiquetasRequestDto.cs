using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Odoo
{
    public class UpdateQtyEtiquetasRequestDto
    {
        public long ProductId { get; set; }
        public int Qty { get; set; }
    }
}
