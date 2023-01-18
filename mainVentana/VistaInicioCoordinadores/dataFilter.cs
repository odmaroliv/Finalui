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

namespace mainVentana.VistaInicioCoordinadores
{
    public static class dataFilter
    {

        public static DataTable ConvierteADatatable(List<vmInfoControlCors> lista)
        {
            /*DataTable tb = lista.ToDataTable(); // get your list
            return tb;*/
            DataTable tb = new DataTable();
                List<vmInfoControlCorsAux> listAux = new List<vmInfoControlCorsAux>();
                foreach (var item in lista)
                {
                    vmInfoControlCorsAux aux = new vmInfoControlCorsAux();
                    aux.SucursalInicio = item.SucursalInicio;
                    aux.entrada = item.entrada;
                    aux.fechaentrada = item.fechaentrada;
                    aux.cliente = item.cliente;
                    aux.Cotizacion = item.Cotizacion;
                    aux.ordcarga = item.ordcarga;
                    aux.ordapli = item.ordapli;
                    aux.salida = item.salida;
                    aux.valFact = item.valFact;
                    aux.valArn = item.valArn;
                    listAux.Add(aux);
                }
                tb = listAux.ToDataTable();
                var displayName = typeof(vmInfoControlCorsAux).GetProperties()
                .Where(p => p.IsDefined(typeof(DisplayNameAttribute), false))
                .Select(p => new {
                    Name = p.Name,
                DisplayName = ((DisplayNameAttribute)p.GetCustomAttributes(typeof(DisplayNameAttribute), false)[0]).DisplayName
                     });
            foreach (var item in displayName)
            {
                tb.Columns[item.Name].Caption = item.DisplayName;
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


    }
}
