using Datos.Datosenti;
using Datos.ViewModels.Recepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.NGRecepcion
{
    public class ngbdRecepcion
    {


        public List<vmRecepcionesVistaSalida> VisualizaciondeSalidas(string dato = null)
        {
           
            try
            {
                var lst = new List<vmRecepcionesVistaSalida> ();
                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var query = from a in modelo.KDMENT
                                join k in modelo.KDM1 on a.C17 equals k.C6
                                where  a.C20 != "F" && k.C4 == 45 && k.C1 == dato
                                select new vmRecepcionesVistaSalida
                                {
                                    salida = a.C17.Trim()
                                };



                   return query.ToList();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
