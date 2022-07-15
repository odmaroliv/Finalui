using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Reportes
{
    public class vmCorreoInforma
    {
        [DisplayName("Entrada")]
        public string Entrada { get; set; }
        [DisplayName("Fecha de Entrada")]
        public string Fechadeentrada { get; set; }
        [DisplayName("Correo")]
        public string correo { get; set; }
        [DisplayName("Descipcion")]
        public string Descipcion { get; set; }
        [DisplayName("Etiqueta")]
        public string eti { get; set; }
    }
}
