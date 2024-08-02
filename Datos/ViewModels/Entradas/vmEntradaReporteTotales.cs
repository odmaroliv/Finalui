using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Entradas
{
    public class vmEntradaReporteTotales
    {
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        
        [DisplayName("Usuario")]
        public string usuario { get; set; }
    }
}
