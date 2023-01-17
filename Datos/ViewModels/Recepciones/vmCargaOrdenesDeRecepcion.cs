using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Recepciones
{
    public class vmCargaOrdenesDeRecepcion
    {
        public string Referencia { get; set; }
        public string Documento { get; set; } //EJEMPLO CSL-UD4501-0008053
        public DateTime Fecha { get; set; }
        public string correo { get; set; }
    }
}
