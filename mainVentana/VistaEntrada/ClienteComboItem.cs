using Datos.ViewModels.Odoo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainVentana.VistaEntrada
{
    public class ClienteComboItem
    {
        public string DisplayText { get; set; }
        public OdooClienteDto Cliente { get; set; }

        public override string ToString() => DisplayText;
    }
}
