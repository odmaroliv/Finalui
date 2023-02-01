using Datos.Datosenti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mainVentana.Reportes.DashBoardArturo;

namespace Negocios.NGReportes.Arturo
{
    public class NgReportesDashboard
    {
        public class ValorARnTOtal3sucs
        {
            /// <summary>
            /// Devuelve valores totales de valor arnian por sucursal
            /// </summary>
            /// 

            public async Task<List<VMsucursalesValorArn>> TotalArnDashboard(string operacion = null)
            {

                try
                {
                    var lst = new List<VMsucursalesValorArn>();
                    await Task.Run(() =>
                    {

                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            var lista = from d in modelo.KDMENT
                                        join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                        //join a in modelo.KDUV on k.C12 equals a.C2
                                        //join u in modelo.KDUSUARIOS on a.C22 equals u.C1
                                        where (d.C19 == "CSL" || d.C19 == "SD" || d.C19 == "TJ") && d.C4 == 35 && k.C101 == operacion && k.C43 != "C" && d.C23 != "T"
                                        group k by d.C19 into g
                                        select new VMsucursalesValorArn
                                        {
                                            sucursal = g.Key,
                                            ValorTotalArn = g.Sum(x => x.C16)
                                        };
                            lst = lista.ToList();
                        }
                    });
                    return lst;

                }
                catch (Exception)
                {

                    throw;
                }
            }



            /// <summary>
            /// Devuelve valores totales de valor arnian por coordinador
            /// </summary>
            /// 
            public async Task<List<VMsucursalesValorArn>> ValorXCord(string operacion = null)
            {
                try
                {
                    var lst = new List<VMsucursalesValorArn>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            var sqlQuery = "SELECT KDUV.C3 AS sucursal, SUM(KDM1.C16) AS ValorTotalArn " +
                 "FROM KDMENT " +
                 "INNER JOIN KDM1 ON KDMENT.C1 = KDM1.C1 AND KDMENT.C4 = KDM1.C4 AND KDMENT.C6 = KDM1.C6 " +
                 "INNER JOIN KDUV ON KDM1.C12 = KDUV.C2 " +
                 "WHERE (KDMENT.C19 = 'CSL' OR KDMENT.C19 = 'SD' OR KDMENT.C19 = 'TJ') " +
                 "AND KDM1.C101 = @operacion " +
                 "AND KDMENT.C4 = 35 " +
                 "AND KDM1.C43 <> 'C' " +
                 "AND KDMENT.C23 <> 'T' " +
                 "GROUP BY KDUV.C3";

                            var lst2 = modelo.Database.SqlQuery<VMsucursalesValorArn>(sqlQuery, new System.Data.SqlClient.SqlParameter("operacion", operacion)).ToList();
                        
                            lst = lst2.ToList();
                        }
                        /*
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            var lista = from d in modelo.KDMENT
                                        join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                        join a in modelo.KDUV on k.C12 equals a.C2
                                        //join u in modelo.KDUSUARIOS on a.C22 equals u.C1
                                        where (d.C19 == "CSL" || d.C19 == "SD" || d.C19 == "TJ") && k.C101 == operacion && d.C4 == 35 && k.C43 != "C" && d.C23 != "T"
                                        group k by a.C3 into g
                                        select new VMsucursalesValorArn
                                        {
                                            sucursal = g.Key,
                                            ValorTotalArn = g.Sum(x => x.C16)
                                        };
                            lst = lista.ToList();
                        }*/
                    });
                    return lst;

                }
                catch (Exception)
                {

                    throw;
                }
            }


        }

    }
}

