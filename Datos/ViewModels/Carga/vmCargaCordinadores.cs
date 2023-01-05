using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Carga
{
    public class vmCargaCordinadores
    {
        [DisplayName("Origen.")]
        public string sucursalOrigen { get; set; }
        [DisplayName("N. Carga.")]
        public string numeroCarga { get; set; }
        [DisplayName("Fecha Cierre.")]
        public DateTime? fechaCierre { get; set; }
        [DisplayName("Hora Cierre.")]
        public string horaCierre { get; set; }
        [DisplayName("Tipo de Oper")]
        public string destino { get; set; }

    }
}
