using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Coord
{
    public class vmBusquedaCot
    {

        [DisplayName("Elaborada Para")]
        public string C1 { get; set; }
        [DisplayName("No. Cotizacion")]
        public string C6 { get; set; }


        [DisplayName("Total A pagar Arnian")]
        public decimal? C16 { get; set; }


        [DisplayName("Topo de cambio")]
        public double? C40 { get; set; }
        [DisplayName("Sub Total USD")]
        public decimal? C42 { get; set; }
        [DisplayName("Sub Total Pesos")]
        public string C93 { get; set; }
        [DisplayName("Valor solo Taxes")]
        public string C94 { get; set; }
        [DisplayName("Valor solo Services and Fees")]
        public string C89 { get; set; }
        [DisplayName("Valor mercancia USD")]
        public string C83 { get; set; }
        [DisplayName("Valor mercancia MXN")]
        public string C84 { get; set; }
        [DisplayName("Tipo de Pago")]
        public string C30 { get; set; }
        [DisplayName("Valor IVA")]
        public decimal? C14 { get; set; }
        [DisplayName("No. Cliente")]
        public string C10 { get; set; }
        [DisplayName("Cliente")]
        public string C32 { get; set; }
        [DisplayName("Calle")]
        public string C33 { get; set; }
        [DisplayName("Colonia")]
        public string C34 { get; set; }
        [DisplayName("ZIP")]
        public string C35 { get; set; }
        [DisplayName("Moneda")]
        public string C7 { get; set; }
        [DisplayName("Fecha de elaboración")]
        public DateTime? C9 { get; set; }

        [DisplayName("Descuentos")]
        public decimal? C13 { get; set; }
        [DisplayName("Elaboro")]
        public string C67 { get; set; }

        [DisplayName("Referencia")]
        public string C86 { get; set; }

        [DisplayName("Comentario")]
        public string C24 { get; set; }

    }
}
