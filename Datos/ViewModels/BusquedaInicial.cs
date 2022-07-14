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
        /// Esta clase se utiliza para la busqueda inicial en la pantalla principal
        /// </summary>      
        /// 

        [DisplayName("Entrada")] //c6
        public string C6 { get; set; }

        [DisplayName ("Etiqueta") ] //c9
        public string C9 { get; set; }

        [DisplayName("Fecha de entrada")] //c69
        public string C69 { get; set; }

        

        [DisplayName("Origen")] //c1
        public string origen { get; set; }

        [DisplayName("Sucursal Final")] //c10
        public string C10 { get; set; }

        [DisplayName("Sucursal actual")] //c19
        public string C19 { get; set; }

        [DisplayName("Cliente")]//c32
        public string cliente { get; set; }

        [DisplayName("Orden de carga Asignada")]//c54
        public string cargaasig { get; set; }

        [DisplayName("Fecha Carga Asignada")] //c71
        public string cafecha { get; set; }

        [DisplayName("Carga Aplicada")] //c16
        public string cargaapl { get; set; }

        [DisplayName("Fecha Carga Aplicada")]//c72
        public string capfecha { get; set; }

        [DisplayName("Orden Salida")]//c17
        public string osalida { get; set; }

        [DisplayName("Salida Fecha")]//c73
        public string osfecha { get; set; }

        [DisplayName("Recepcion Transito")]//c18
        public string receptran { get; set; }

        [DisplayName("Fecha Recepcion Transito")]//c74
        public string receptranfecha { get; set; }

        [DisplayName("Salida Transito")]//c64
        public string saltrans { get; set; }

        [DisplayName("Fecha Salida Transito")]//c75
        public string saltransfehcha { get; set; }

        [DisplayName("Recepcion Final")]//c67
        public string repfinal { get; set; }

        [DisplayName("Recepcion Final Fecha")]//c76
        public string repfinalfecha { get; set; }

        [DisplayName("Bill Of Landing")] // c34
        public string bill { get; set; }

        [DisplayName("Fecha Bill")]//c77
        public string billfecha { get; set; }

        [DisplayName("Descipcion corta")] //c42
        public string C42 { get; set; }

        [DisplayName("Elaborado Por")]//c81
        public string elaborado { get; set; }

        [DisplayName("Coordinador")]//kduv
        public string coord { get; set; }

        [DisplayName("Ultima modificacion")]
        public string ultimamodifi { get; set; }

        [DisplayName("Ultima modificacion")]
        public string ultimamodififecha { get; set; }

        //public string Estatus { get; set; }


    }
}
