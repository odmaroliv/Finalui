using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Entradas
{
    public class vmListaFotos
    {
        public int id { get; set; }
        public string entrada { get; set; }
        public string documento { get; set; }
        public string nombre { get; set; }
        public string realnombre { get; set; }
        public byte[] bytedocumto { get; set; }
        public string sucursal { get; set; }
    }
}
