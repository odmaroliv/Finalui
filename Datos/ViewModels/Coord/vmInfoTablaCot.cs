using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Coord
{
    public class vmInfoTablaCot
    {
        [DisplayName("Fila")]
        
       public decimal? C7   {get; set;}
        [DisplayName("Feed/Tax/Service/Etc")]
        public string C10  {get; set;}
        [DisplayName("Porcentaje")]
        public string C39 { get; set; }
        [DisplayName("Charges USD")]
        public decimal? C13  {get; set;}

        [DisplayName("IVA %")]
        public string C17  {get; set;}
        
        [DisplayName("Moneda")]
        public string C36  {get; set;}

    }
}
