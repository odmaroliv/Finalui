﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Reportes
{
    public class vmInfoControlCors
    {
        [DisplayName("Origen")]
        public string SucursalInicio { get; set; }
        [DisplayName("Entrada")]
        public string entrada { get; set; }
        [DisplayName("F. Entrada")]
        public string fechaentrada { get; set; }
        [DisplayName("Cliente")]
        public string cliente { get; set; }
        [DisplayName("No Cli")]
        public string noCli { get; set; }
        [DisplayName("No. Cotización")]
        public string Cotizacion { get; set; }
        [DisplayName("Ord.Carga")]
        public string ordcarga { get; set; }
        [DisplayName("Ord.Carga.Aplicada")]
        public string ordapli { get; set; }
        [DisplayName("Salida")]
        public string salida { get; set; }
        //  public string numeroent { get; set; }
        [DisplayName("Val.Factura")]
        public string valFact { get; set; }
        [DisplayName("Val.Arnian")]
        public string valArn { get; set; }

        [DisplayName("Descripcion")]
        public string desc { get; set; }
        [DisplayName("Alias")]
        public string aliss { get; set; }
        [DisplayName("Calle")]
        public string calle { get; set; }
        [DisplayName("Colonia")]
        public string colonia { get; set; }
        [DisplayName("Población")]
        public string poblacio { get; set; }
        [DisplayName("ZIP")]
        public string zipcode { get; set; }
    }
}
