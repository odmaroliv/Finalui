using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Reportes
{

    public class vmSd1Reporte
    {
        [DisplayName("Entrada")]
        public string entrada { get; set; }

        [DisplayName("Etiqueta")]
        public string etiqueta { get; set; }

        [DisplayName("Fecha de entrada")]
        public string FechEntrada { get; set; }

        

        [DisplayName("Coordinador")]
        public string cord { get; set; }

        [DisplayName("Correo Cord")]
        public string correoCord { get; set; }

        [DisplayName("Orden de carga asigana")]
        public string ordCar { get; set; }

        [DisplayName("Descripcion corta")]
        public string des { get; set; }


    }
}
