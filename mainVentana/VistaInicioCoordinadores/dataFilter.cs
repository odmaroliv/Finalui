using Datos.ViewModels.Carga;
using Datos.ViewModels.Coord;
using Datos.ViewModels.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Reflection;
using Datos.ViewModels.CXC;

namespace mainVentana.VistaInicioCoordinadores
{
    public static class dataFilter
    {

        public static DataTable ConvierteADatatable(List<vmInfoControlCors> lista)
        {
            /* DataTable tb = lista.ToDataTable(); // get your list
             return tb;*/

            DataTable tb = new DataTable();
            //Add columns
            var properties = typeof(vmInfoControlCors).GetProperties();
            foreach (var property in properties)
            {
                var display = property.GetCustomAttribute<DisplayNameAttribute>();
                if (display != null)
                    tb.Columns.Add(display.DisplayName);
                else
                    tb.Columns.Add(property.Name);
            }
            //Add rows
            foreach (var item in lista)
            {
                var row = tb.NewRow();
                foreach (var property in properties)
                {
                    var value = property.GetValue(item);
                    var display = property.GetCustomAttribute<DisplayNameAttribute>();
                    if (display != null)
                        row[display.DisplayName] = value;
                    else
                        row[property.Name] = value;
                }
                tb.Rows.Add(row);
            }
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
        public static DataTable ConvierteADatatableCXC(List<vmInicioCXC> lista)
        {
            DataTable tb = lista.ToDataTable(); // get your list
            return tb;
        }


    }
}
