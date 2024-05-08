using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Entradas
{
    public class KDMEntry
    {
        public string SucInicio { get; set; }
        public string FolEntrada { get; set; }
        public string NumEtiqueta { get; set; }
        public string Documento { get; set; }
        public string Etiqueta { get; set; }
        public string SucDestino { get; set; }
        public string SucActual { get; set; }
        public string Desc { get; set; }
        public DateTime Fecha { get; set; }
        public int RepEspecial { get; set; }
        public int Modo { get; set; }
        public string Proceso { get; set; }
    }

}
