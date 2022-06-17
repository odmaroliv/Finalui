using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Reportes
{
    public class vmEtiquetasReporte
    {
        public string ZonaNumero { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Cliente { get; set; }
        public string Etiqueta { get; set; }
        public string Entrada { get; set; }
        public DateTime? Fecha { get; set; }
        public string Alias { get; set; }

        public string Zona { get; set; }
        public byte[] barcode { get; set; }

    }
}
