using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Bill
{
    public class vmBillEntradaDoc
    {
        [DisplayName("N°")]
        public int nItem { get; set; }

        [DisplayName("Receipt ID")]
        public string entrada { get; set; }

        [DisplayName("Item No.")]
        public string etiqueta { get; set; }

        [DisplayName("Description")]
        public string desc { get; set; }

        [DisplayName("Type Ope")]
        public string oper { get; set; }

        [DisplayName("Alias")]
        public string alias { get; set; }
        [DisplayName("Alias 2")]
        public string alias2 { get; set; }

    }
}
