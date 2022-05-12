using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels
{
    public class BusquedaInicial
    {
        /// <summary>
        /// Esto es de KDM1
        /// </summary>      
        [DisplayName ("Etiqueta") ]
        public string C9 { get; set; }

        [DisplayName("Entrada")]
        public string C6 { get; set; }

        [DisplayName("Fecha de entrada")]
        public string C69 { get; set; }
        [DisplayName("Descipcion corta")]
        public string C42 { get; set; }
        [DisplayName("Sucursal actual")]
        public string C19 { get; set; }
        [DisplayName("Sucursal Final")]
        public string C10 { get; set; }
        

        //public string Estatus { get; set; }


    }
}
