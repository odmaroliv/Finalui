using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Entrega
{
    public class vmReportDataEntrega
    {
        public string nArnian { get; set; }
        public string fechaEntrega { get; set; }
        public string recibio { get; set; }
        public string cordsEnt { get; set; }
        public byte[] imgSignature { get; set; }
    }
}
