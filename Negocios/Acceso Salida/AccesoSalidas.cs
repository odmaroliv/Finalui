using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Datosenti;
using Datos.ViewModels.Salidas;


namespace Negocios.Acceso_Salida
{
    public class AccesoSalidas
    {


        /// <summary>
        /// Buscamos los las ordenes de carga disponibles
        /// 2 tujuana, 3 cabo, 4 san diego
        /// </summary>
        /// <param name="sucori"></param>
        /// <param name="doc"></param>
        /// <param name="sucursa"></param>
        /// <returns></returns>
        public async Task<List<vmCargaOrdenesDeCarga>> LlenaDGV(string sucori, string doc, int numerosuc)
        {
            try
            {
                var lst2 = new List<vmCargaOrdenesDeCarga>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        lst2.Clear();
                        var oDocument = (from q in modelo.KDMENT
                                         where q.C19 == "TJ" && q.C20 == "E" && q.C18.Length>0 &&q.C18 != "ESPECIAL"
                                         group q.C18 by q.C18 into g
                                         select new vmCargaOrdenesDeCarga
                                         {
                                           Documento = g.Key
                                         }).ToList();

                        lst2 = oDocument;
                    }
                });
                return lst2;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
