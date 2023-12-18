using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Salidas
{
    public class vmSalidaReporte
    {
        public string salida { get; set; }
        public string referencia { get; set; }
        public DateTime? fecha { get; set; }
        public decimal? totalArnian { get; set; }
        public string elaboro { get; set; }
        public string destino { get; set; }
    }
}
