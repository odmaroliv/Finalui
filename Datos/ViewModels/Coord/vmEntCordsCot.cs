using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Coord
{
    public class vmEntCordsCot
    {
      
            [DisplayName("Entrada")]
            public string entrada { get; set; }
        
            [DisplayName("Val.Factura")]
            public string valFact { get; set; }
            [DisplayName("Val.Arnian")]
            public string valArn { get; set; }
        // public string etiqueta { get; set; }
            public string Origen { get; set; }


    }
}
