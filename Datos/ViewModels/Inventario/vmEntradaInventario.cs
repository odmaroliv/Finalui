using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Inventario
{
    public class vmEntradaInventario
    {
        public string Etiqueta { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public int? Folio { get; set; }
        public string ScursalActual { get; set; }
        public string ScursalFinal { get; set; }

        public override bool Equals(object obj)
        {
            return obj is vmEntradaInventario inventario &&
                   Etiqueta == inventario.Etiqueta;
        }

        public override int GetHashCode()
        {
            return Etiqueta.GetHashCode();
        }
    }
}
