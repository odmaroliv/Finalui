using Datos.ViewModels.Carga;
using Datos.ViewModels.Coord;
using Datos.ViewModels.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainVentana.VistaInicioCoordinadores
{
    public static class dataFilter
    {

        public static DataTable ConvierteADatatable(List<vmInfoControlCors> lista)
        {
            DataTable tb = lista.ToDataTable(); // get your list
            return tb;
        }

        public static DataTable ConvierteADatatable2(List<vmCargaCordinadores> lista)
        {
            DataTable tb = lista.ToDataTable(); // get your list
            return tb;
        }

        public static DataTable ConvierteADatatable3(List<vmEntCordsCot> lista)
        {
            DataTable tb = lista.ToDataTable(); // get your list
            return tb;
        }


    }
}
