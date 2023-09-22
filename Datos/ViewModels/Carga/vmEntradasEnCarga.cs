using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Carga
{
    public class vmEntradasEnCarga
    {
        [DisplayName("Entrada.")]
        public string Entrada { get; set; }

        [DisplayName("Etiqueta.")]
        public string Etiqueta { get; set; }
        [DisplayName("Unidad.")]
        public string Unidad { get; set; }
        [DisplayName("Cliente.")]
        public string Cliente { get; set; }

        [DisplayName("Cliente.")]
        public string valArn { get; set; }
        [DisplayName("Cliente.")]
        public string valFact { get; set; }


    }
}
