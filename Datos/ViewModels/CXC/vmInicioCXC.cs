﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.CXC
{
    public class vmInicioCXC
    {
        public DateTime FechaEnrtada { get; set; }
        public string Entrada { get; set; }
        public string Sucursal { get; set; }
        public string Cotizacion { get; set; }

        public string Cliente { get; set; }
        public string Alias { get; set; }
        public string Coordinador { get; set; }

        public string ValorFactura { get; set; }
        public decimal? ValorArnia { get; set; }
        public string BOL { get; set; }
        public string Carga { get; set; }
        public string Salida { get; set; }

        public string EstatusAlmacen { get; set; }
        public string EstatusPago { get; set; }
        public string Comentario { get; set; }
        public string Operacion { get; set; }

    }
}