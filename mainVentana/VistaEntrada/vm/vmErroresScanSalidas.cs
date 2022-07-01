using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventana1.vm
{
    public class vmErroresScanSalidas
    {
        [DisplayName("Etiquetas")]
        public string etiqueta { get; set; }
        [DisplayName("Observacion")]
        public string error { get; set; }
    }
}
