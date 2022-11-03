using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Salidas
{
    public class vmEnviodeNotificacion
    {
        public string OrdenSalidaAplicada { get; set; }
        public string Etiqueta { get; set; }
        public string Pertenece { get; set; }
        public string notas { get; set; }
        public string NoCargadas { get; set; }
        
        public string Correo { get; set; }
    }
}
