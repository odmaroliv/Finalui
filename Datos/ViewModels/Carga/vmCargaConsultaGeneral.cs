using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Carga
{
    public class vmCargaConsultaGeneral
    {
        public string errormsg { get; set; }
        public string  sucursalOrigen{ get; set; }
        public string numeroCarga { get; set; }
        public DateTime? fechaAlta { get; set; }
        public string tipoOperacion { get; set; }
        public string sucursalDestino { get; set; }
        public string moneda { get; set; }
        public Double? paridad { get; set; }
        public string referencia { get; set; }
        public DateTime? fechaCierre { get; set; }
        public string horaCierre { get; set; }
        public string estatus { get; set; }

    }
}
