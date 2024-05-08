using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
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
        public async Task<List<vmCargaOrdenesDeCarga>> LlenaDGV(string sucori, string sudest, string doc, int numerosuc)
        {
            if (sucori.Trim().Contains("TJ"))//Para la sucursal de tijuana no se levantan ordenes de carga, por lo que mandamos las ordenes de recepcion directamente
            {
                int cha = sucori.Trim().ToString().Length;
                try
                {
                    var lst2 = new List<vmCargaOrdenesDeCarga>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            modelo.Database.CommandTimeout = 300;
                            lst2.Clear();

                            /*
                                                        string query = "SELECT DISTINCT q.C67 as Documento, MAX(k.C11) as Referencia, MAX(k.C9) as Fecha " +
                                                        "FROM KDMENT q " +
                                                        //"INNER JOIN KDM1 k ON q.C55 = CONCAT(TRIM({0}),'-UD4501-',k.C6) " +
                                                        "WHERE q.C19 LIKE '%' + {0} + '%' AND q.C20 = 'R' AND q.C18 <> 'ESPECIAL' AND q.C67 IS NOT NULL" +
                                                        "GROUP BY q.C67 " +
                                                        "ORDER BY q.C67 DESC";

                                                        var result = modelo.Database.SqlQuery<vmCargaOrdenesDeCarga>(query, "TJ").ToList();

                                                        lst2 = result;*/


                            var oDocument = (from q in modelo.KDMENT
                                                 //join k in modelo.KDM1 on q.C55 equals sucori.Trim() + "-UD4501-" + k.C6
                                                 //where string.IsNullOrEmpty(q.C18) && !string.IsNullOrEmpty(q.C16) && q.C54.Contains(sucori) && q.C19.Contains(sucori) && q.C20.Trim() != "F"

                                             where q.C19.Contains("TJ") && q.C20 == "R" && q.C46 != "BTRACKSALIDA" && q.C18 != "ESPECIAL" && !string.IsNullOrEmpty(q.C67)

                                             group q.C67 by q.C67 into g
                                             select new vmCargaOrdenesDeCarga
                                             {
                                                 //Origen= q.C9
                                                 Documento = g.Key
                                             }).OrderByDescending(x => x.Documento).ToList();

                            lst2 = oDocument;
                        }
                    });
                    return lst2;
                }
                catch (Exception ex)
                {
                    if (ex is DbEntityValidationException entityValidationEx)
                    {
                        foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                        {
                            // Acceder a los Entity Validation Errors
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                var propertyName = validationError.PropertyName;
                                var errorMessage = validationError.ErrorMessage;
                                Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalida.LlenaDGV().. ");
                            }
                        }
                    }
                    throw;
                }

            }
            else
            {
                int cha = sucori.Trim().ToString().Length;
                try
                {
                    var lst2 = new List<vmCargaOrdenesDeCarga>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            string query = "SELECT DISTINCT q.C54 as Documento " +
                                            "FROM KDMENT q " +
                                            // "INNER JOIN KDM1 k ON q.C54 = CONCAT(TRIM({0}),'-UD4001-',k.C6) " +
                                            "WHERE q.c46 !='BTRACKSALIDA'  AND ( C16 IS NOT NULL AND C16 != '')  AND q.C54 LIKE '%' + {0} + '%' AND q.C19 = {0}  AND (q.C20 <> 'F' or q.C20 IS NULL)" +
                                            "GROUP BY q.C54 " +
                                            "ORDER BY q.C54 DESC ";


                            var result = modelo.Database.SqlQuery<vmCargaOrdenesDeCarga>(query, sucori).ToList();
                            lst2 = result;
                            /*var oDocument = (from q in modelo.KDMENT
                                             //join k in modelo.KDM1 on q.C55 equals sucori.Trim() + "-UD4501-" + k.C6
                                             //where string.IsNullOrEmpty(q.C18) && !string.IsNullOrEmpty(q.C16) && q.C54.Contains(sucori) && q.C19.Contains(sucori) && q.C20.Trim() != "F"

                                             where string.IsNullOrEmpty(q.C17) && string.IsNullOrEmpty(q.C55) && !string.IsNullOrEmpty(q.C16) && q.C54.Contains(sucori) && q.C19.Contains(sucori) && q.C20.Trim() != "F"

                                             group q.C54 by q.C54 into g
                                             select new vmCargaOrdenesDeCarga
                                             {
                                                 
                                                 Documento = g.Key,
                                                 
                                             }).OrderByDescending(x => x.Documento).Take(30).ToList();*/

                            //lst2 = oDocument;
                        }
                    });
                    return lst2;
                }
                catch (Exception ex)
                {
                    if (ex is DbEntityValidationException entityValidationEx)
                    {
                        foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                        {
                            // Acceder a los Entity Validation Errors
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                var propertyName = validationError.PropertyName;
                                var errorMessage = validationError.ErrorMessage;
                                Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalida.LlenaDGV().. ");
                            }
                        }
                    }
                    throw;
                }
            }

        }

        public async Task<List<vmCargaOrdenesDeSalida>> LlenaDGVSalidas(string sucori, string doc, int numerosuc)
        {
            
            string estatuss = default;
            estatuss = "PS" + sucori.Trim();
            /*if (sucori.Trim() == "TJ")
            {
                estatuss = "PSTJ";
            }
            if (sucori.Trim() == "SD")
            {
                estatuss = "PSSD";
            }
            if (sucori.Trim() == "CSL")
            {
                estatuss = "PSCSL";
            }*/

            int cha = sucori.Trim().ToString().Length;
            int cade = "-UD4501-".Length;
            if (sucori.Contains("TJ"))
            {
                try
                {
                    var lst2 = new List<vmCargaOrdenesDeSalida>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            modelo.Database.CommandTimeout = 300;
                            lst2.Clear();
                            string query = "WITH CTE AS (SELECT DISTINCT q.C55 as Documento, MAX(k.C11) as Referencia, MAX(k.C9) as Fecha " +
                                  "FROM KDMENT q " +
                                  "INNER JOIN KDM1 k ON q.C55 = CONCAT(TRIM({0}),'-UD4501-',k.C6) " +
                                  "WHERE q.C19 = {0} AND k.C61 = {1} AND k.C4 = {2} AND q.c46 !='BTRACKSALIDA'" +
                                  "GROUP BY q.C55) " +
                                  "SELECT Documento, Referencia, Fecha FROM CTE ORDER BY Documento DESC OFFSET 0 ROWS FETCH NEXT {3} ROWS ONLY";

                            var result = modelo.Database.SqlQuery<vmCargaOrdenesDeSalida>(query, sucori, estatuss, 45, 30).ToList();
                            lst2 = result;
                        }
                    });
                    return lst2;
                }
                catch (Exception ex)
                {
                    if (ex is DbEntityValidationException entityValidationEx)
                    {
                        foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                        {
                            // Acceder a los Entity Validation Errors
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                var propertyName = validationError.PropertyName;
                                var errorMessage = validationError.ErrorMessage;
                                Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalida.LlenaDGVSalidas().. ");
                            }
                        }
                    }
                    throw;
                }
            }
            else
            {
                try
                {
                    var lst2 = new List<vmCargaOrdenesDeSalida>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            /*  var oDocument = (from q in modelo.KDMENT.AsQueryable()
                                               join k in modelo.KDM1 on q.C55 equals sucori.Trim() + "-UD4501-" + k.C6
                                               where string.IsNullOrEmpty(q.C18) && q.C55.Contains(sucori) && q.C19.Contains(sucori) && k.C43.Contains("P") && k.C4 == 45

                                               group k by q.C55 into g


                                               select new vmCargaOrdenesDeSalida
                                               {
                                                   Documento = g.Key,
                                                   Referencia = g.Select(x => x.C11).FirstOrDefault(),
                                                   Fecha = g.Select(x => x.C9).FirstOrDefault().Value

                                               }).OrderByDescending(x => x.Documento).Take(30).ToList();*/

                            string query = "WITH CTE AS (SELECT DISTINCT q.C55 as Documento, MAX(k.C11) as Referencia, MAX(k.C9) as Fecha " +
                                 "FROM KDMENT q " +
                                 "INNER JOIN KDM1 k ON q.C55 = CONCAT(TRIM({0}),'-UD4501-',k.C6) " +
                                 "WHERE (q.C18 = '' OR q.C18 IS NULL) AND q.C19 = {0} AND k.C61 = {1} AND k.C4 = {2} AND q.c46 !='BTRACKSALIDA' " +
                                 "GROUP BY q.C55) " +
                                 "SELECT Documento, Referencia, Fecha FROM CTE ORDER BY Documento DESC OFFSET 0 ROWS FETCH NEXT {3} ROWS ONLY";

                            var result = modelo.Database.SqlQuery<vmCargaOrdenesDeSalida>(query, sucori, estatuss, 45, 30).ToList();

                            lst2 = result;
                        }
                    });
                    return lst2;
                }
                catch (Exception ex)
                {
                    if (ex is DbEntityValidationException entityValidationEx)
                    {
                        foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                        {
                            // Acceder a los Entity Validation Errors
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                var propertyName = validationError.PropertyName;
                                var errorMessage = validationError.ErrorMessage;
                                Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalida.LlenaDGVSalidas().. ");
                            }
                        }
                    }
                    throw;
                }
            }

        }

        /*  public List<string> BuscUltimaSalida(string suc)
          {

              List<string> lista1 = new List<string>();

              using (modelo2Entities db = new modelo2Entities())
              {
                  var lst = from k in db.NumeroMAX(suc, "45")

                            select k;

                  lista1 = lst.ToList();

              }


              return lista1;

          }*/
        public List<vnNoSalida> BuscUltimaSalida(string datoSucIni, int modo)
        {
            string br = "KFUD" + modo + "01." + datoSucIni;
            try
            {
                var lst2 = new List<vnNoSalida>();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.SqlIov
                                where d.C1.Contains(br) //&& d.C19 != sdestino 
                                select new vnNoSalida
                                {
                                    salida = d.C4
                                };
                    lst2 = lista.ToList();

                }

                return lst2;
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        // Acceder a los Entity Validation Errors
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalida.BuscUltimaSalida().. ");
                        }
                    }
                }
                throw;
            }

        }

        public async void AltaSalidaUPU()
        {
            try
            {

                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {

                    }
                });

            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        // Acceder a los Entity Validation Errors
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalida.AltaSalidaUPU().. ");
                        }
                    }
                }
                throw;
            }
        }

        public async Task<List<vmCargaOrdenesDeSalida>> BuscEntradasEnSalida(string salida, string origen)
        {
            if (origen.Contains("TJ"))
            {

                try
                {
                    var lst2 = new List<vmCargaOrdenesDeSalida>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            var oDocument = (from q in modelo.KDMENT
                                             //join k in modelo.KDM1 on new { q.C1, q.C4, q.C6 } equals new { k.C1, k.C4, k.C6 }
                                             //join a in modelo.KDUV on k.C12 equals a.C2
                                             where q.C64.Contains(salida)

                                             //group k by q.C55 into g


                                             select new vmCargaOrdenesDeSalida
                                             {
                                                 Documento = q.C9,
                                                 Referencia = q.C67,
                                                 //correo = u.C9,
                                             }).ToList();

                            lst2 = oDocument;
                        }
                    });
                    return lst2;
                }
                catch (Exception ex)
                {
                    if (ex is DbEntityValidationException entityValidationEx)
                    {
                        foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                        {
                            // Acceder a los Entity Validation Errors
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                var propertyName = validationError.PropertyName;
                                var errorMessage = validationError.ErrorMessage;
                                Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalida.BuscEntradasEnSalida().. ");
                            }
                        }
                    }
                    throw;
                }
            }
            else
            {
                try
                {
                    var lst2 = new List<vmCargaOrdenesDeSalida>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            var oDocument = (from q in modelo.KDMENT
                                             join k in modelo.KDM1 on new { q.C1, q.C4, q.C6 } equals new { k.C1, k.C4, k.C6 }
                                             //join a in modelo.KDUV on k.C12 equals a.C2
                                             //join u in modelo.KDUSUARIOS on a.C22 equals u.C1
                                             where q.C55.Contains(salida)

                                             //group k by q.C55 into g


                                             select new vmCargaOrdenesDeSalida
                                             {
                                                 Documento = q.C9,
                                                 Referencia = q.C54,
                                                // correo = u.C9
                                             }).ToList();

                            lst2 = oDocument;
                        }
                    });
                    return lst2;
                }
                catch (Exception ex)
                {
                    if (ex is DbEntityValidationException entityValidationEx)
                    {
                        foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                        {
                            // Acceder a los Entity Validation Errors
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                var propertyName = validationError.PropertyName;
                                var errorMessage = validationError.ErrorMessage;
                                Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalida.BuscEntradasEnSalida().. ");
                            }
                        }
                    }

                    throw;
                }

            }

        }
        public async Task<List<vmCargaOrdenesDeCarga>> LlenaDGVpausadas(string salidapausada)
        {

            try
            {
                var lst2 = new List<vmCargaOrdenesDeCarga>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        lst2.Clear();
                        var oDocument = (from q in modelo.KDM1

                                         where q.C44.Contains(salidapausada)

                                         //group q.C54 by q.C54 into g
                                         select new vmCargaOrdenesDeCarga
                                         {
                                             //Origen= q.C9
                                             Documento = q.C6
                                         }).OrderByDescending(x => x.Documento).Take(30).ToList();

                        lst2 = oDocument;
                    }
                });
                return lst2;
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        // Acceder a los Entity Validation Errors
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalidas.LlenaDGVpausadas().. ");
                        }
                    }
                }
                throw;
            }
        }
        public async Task<List<vmGeneralesSalidas>> LlenaGeneralesSalida(string salidapausada, string sOrigen)
        {

            try
            {
                var lst2 = new List<vmGeneralesSalidas>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        lst2.Clear();
                        var oDocument = (from q in modelo.KDM1

                                         where q.C6.Contains(salidapausada) && q.C4 == 45 && q.C1.Equals(sOrigen)

                                         //group q.C54 by q.C54 into g
                                         select new vmGeneralesSalidas
                                         {
                                             sDestino = q.C103,
                                             sOrigen = q.C1,
                                             Transportista = q.C94,
                                             Chofer = q.C96,
                                             Placas = q.C95,
                                             Referencia = q.C11,
                                         }).ToList();

                        lst2 = oDocument;
                    }
                });
                return lst2;
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        // Acceder a los Entity Validation Errors
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalidas.LlenaGeneralesSalida().. ");
                        }
                    }
                }
                throw;
            }
        }

        public vmAuxiliaresSalidas ObtieCorreo(string stiqueta, string sorigen = null)
        {

            try
            {

                var ch = new[] { '-' };
                var etiquetaSplit = stiqueta.Split(ch);
                var sori = etiquetaSplit[0];
                var ent = etiquetaSplit[1];

                using (var modelo = new modelo2Entities())
                {
                     var query = modelo.KDMENT.AsNoTracking()
                .Join(
                    modelo.KDM1,                    // La tabla con la que quieres hacer join
                    kdment => new { kdment.C1, kdment.C6 },  // Claves de la primera tabla
                    kdm1 => new { kdm1.C1, kdm1.C6 },        // Claves de la segunda tabla
                    (kdment, kdm1) => new { KDMENT = kdment, KDM1 = kdm1 }  // Resultado del join
                )
                .Where(joined => joined.KDMENT.C1.StartsWith(sori) && joined.KDMENT.C4 == 35 && joined.KDMENT.C9.StartsWith(stiqueta))
                .Select(joined => new vmAuxiliaresSalidas
                {
                    orden = sorigen == "TJ" ? joined.KDMENT.C67 : joined.KDMENT.C16,
                    Etiqueta = joined.KDMENT.C9,
                    Correo = "",  // Aquí puedes usar algún campo de joined.KDM1 si es necesario
                    OdooIdProductos = (long)joined.KDM1.odooidproduct  // Asumiendo que hay un campo OdooId en KDM1
                });



                    var lst = query.FirstOrDefault();

                    return lst ?? new vmAuxiliaresSalidas { Etiqueta = "No se encontro esta etiquita", Correo = "", orden = "" };
                }
            }
            catch (Exception)
            {
                return new vmAuxiliaresSalidas { Etiqueta = "No se encontro esta etiquita", Correo = "", orden = "" };
            }
        }


        /* public List<string> ObtieneCorreos(List<string> nda)
         {

             List<string> lista1 = new List<string>();

             using (modelo2Entities db = new modelo2Entities())
             {

                 var lista = from d in modelo.KDM1
                             join d2 in modelo.KDM1COMEN on new { d.C1, d.C4, d.C6 } equals new { d2.C1, d2.C4, d2.C6 }
                             where d.C1.Equals(sucursal) && d.C4.Equals(35) && d.C6.Equals(id)
                             //orderby (d.C7)
                             select new vmEntradaById
                             {
                                 C1 = d.C1,
                                 C2 = d.C2,
                             }


             return lista1;
             }

         }
        */

        public async Task<List<vmCargaOrdenesDeCarga>> LlenaDGVEntrega(string sucori, string sudest, string doc, int numerosuc)
        {
            int cha = sucori.Trim().ToString().Length;
            try
            {
                var lst2 = new List<vmCargaOrdenesDeCarga>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        lst2.Clear();



                        var oDocument = (from q in modelo.KDMENT
                                         join k in modelo.KDM1 on new { q.C1, q.C4, q.C6 } equals new { k.C1, k.C4, k.C6 }
                                         where q.C19.Contains("CSL") && q.C20 == "F" && q.C46 != "BTRACKSALIDA" && q.C18 != "ESPECIAL" && !string.IsNullOrEmpty(k.C116)

                                         group k.C116 by k.C116 into g
                                         select new vmCargaOrdenesDeCarga
                                         {
                                             //Origen= q.C9
                                             Documento = g.Key
                                         }).OrderByDescending(x => x.Documento).ToList();

                        lst2 = oDocument;
                    }
                });
                return lst2;
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        // Acceder a los Entity Validation Errors
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalidas.LlenaDGVEntrega().. ");
                        }
                    }
                }
                throw;
            }


        }





        public async Task<List<vmSalidaReporte>> BuscEntradasSalidaReporte(string salida, string origen, DateTime dateFrom, DateTime to)
        {
            if (!String.IsNullOrWhiteSpace(salida) && salida != "0000000")
            {
                try
                {
                    var lst2 = new List<vmSalidaReporte>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            var oDocument = (
                                             from k in modelo.KDM1
                                             where k.C6.Equals(salida) && k.C1 == origen && k.C4 == 45
                                             orderby k.C9 descending
                                             select new vmSalidaReporte
                                             {
                                                 salida = k.C6,
                                                 referencia = k.C11,
                                                 fecha = k.C9,
                                                 elaboro = k.C67,
                                                 destino = k.C103,  
                                             }).ToList();

                            lst2 = oDocument;
                        }
                    });
                    return lst2;
                }
                catch (Exception ex)
                {
                    if (ex is DbEntityValidationException entityValidationEx)
                    {
                        foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                        {
                            // Acceder a los Entity Validation Errors
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                var propertyName = validationError.PropertyName;
                                var errorMessage = validationError.ErrorMessage;
                                Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalidas.BuscEntradasSalidaReporte().. ");
                            }
                        }
                    }
                    throw;
                }
            }
            else
            {
                try
                {
                    var lst2 = new List<vmSalidaReporte>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            var oDocument = (
                                             from k in modelo.KDM1
                                             where k.C1 == origen && k.C4 == 45 && k.C9 <= to && k.C9 >= dateFrom
                                             orderby k.C9 descending
                                             select new vmSalidaReporte
                                             {
                                                 salida = k.C6,
                                                 referencia = k.C11,
                                                 fecha = k.C9,
                                                 elaboro = k.C67,
                                                 destino = k.C103,
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
        public async Task<List<vmSalidaReporteEntradas>> BuscEntradasSalidaReporteYtreaeEntradas(string salida, string origen)
        {
            string datoCompleto = origen.Trim() + "-UD4501-" + salida.Trim();
            if (origen.Contains("TJ"))
            {

                try
                {
                    var lst2 = new List<vmSalidaReporteEntradas>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            var oDocument = (from q in modelo.KDMENT
                                             join k in modelo.KDM1 on new { q.C1, q.C4, q.C6 } equals new { k.C1, k.C4, k.C6 }
                                             //join a in modelo.KDUV on k.C12 equals a.C2
                                             // join u in modelo.KDUSUARIOS on a.C22 equals u.C1
                                             where q.C64.Contains(datoCompleto)

                                             //group k by q.C55 into g


                                             select new vmSalidaReporteEntradas
                                             {
                                                 Etiqueta = q.C9,
                                                 Entrada = q.C6,
                                                 Alias = k.C112,
                                                 Cliente = k.C32,
                                                 Descripcion = q.C42,
                                                // destino = k.C103,


                                                 //Carga = q.C67,
                                                 //  correo = u.C9,
                                             }).ToList();

                            lst2 = oDocument;
                        }
                    });
                    return lst2;
                }
                catch (Exception ex)
                {
                    if (ex is DbEntityValidationException entityValidationEx)
                    {
                        foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                        {
                            // Acceder a los Entity Validation Errors
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                var propertyName = validationError.PropertyName;
                                var errorMessage = validationError.ErrorMessage;
                                Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalida.BuscEntradasSalidaReporteYtreaeEntradas().. ");
                            }
                        }
                    }
                    throw;
                }
            }
            else
            {
                try
                {
                    var lst2 = new List<vmSalidaReporteEntradas>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            var oDocument = (from q in modelo.KDMENT
                                             join k in modelo.KDM1 on new { q.C1, q.C4, q.C6 } equals new { k.C1, k.C4, k.C6 }
                                             //  join a in modelo.KDUV on k.C12 equals a.C2
                                             // join u in modelo.KDUSUARIOS on a.C22 equals u.C1
                                             where q.C55.Contains(datoCompleto)

                                             //group k by q.C55 into g


                                             select new vmSalidaReporteEntradas
                                             {
                                                 Etiqueta = q.C9,
                                                 Entrada = q.C6,
                                                 Alias = k.C112,
                                                 Cliente = k.C32,
                                                 Descripcion = q.C42,
                                                 //  Referencia = q.C54,

                                             }).ToList();

                            lst2 = oDocument;
                        }
                    });
                    return lst2;
                }
                catch (Exception ex)
                {
                    if (ex is DbEntityValidationException entityValidationEx)
                    {
                        foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                        {
                            // Acceder a los Entity Validation Errors
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                var propertyName = validationError.PropertyName;
                                var errorMessage = validationError.ErrorMessage;
                                Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalida.BuscEntradasSalidaReporteYtreaeEntradas().. ");
                            }
                        }
                    }

                    throw;
                }

            }

        }
        public async Task<List<vmSalidaReporte>> CalculaValorDeLasSalidasPorEntrada(List<vmSalidaReporte> salidas, string origen)
        {
            try
            {
                List<vmSalidaReporte> result = new List<vmSalidaReporte>();

                using (modelo2Entities modelo = new modelo2Entities())
                {
                    foreach (var salida in salidas)
                    {
                        decimal? totalArnian = 0;

                        string datoCompleto = $"{origen.Trim()}-UD4501-{salida.salida}";

                        var oDocument = await modelo.KDMENT
                            .Join(modelo.KDM1, q => new { q.C1, q.C4, q.C6 }, k => new { k.C1, k.C4, k.C6 }, (q, k) => new { q, k })
                            .Where(x => (origen.Equals("TJ") ? x.q.C64 : x.q.C55).Equals(datoCompleto))
                            .GroupBy(x => new { x.q.C6 })
                            .Select(g => g.FirstOrDefault().k.C42)
                            .ToListAsync();

                        totalArnian += oDocument.Sum();

                        vmSalidaReporte singleResult = new vmSalidaReporte
                        {
                            salida = salida.salida,
                            referencia = salida.referencia,
                            fecha = salida.fecha,
                            totalArnian = totalArnian,
                            elaboro = salida.elaboro
                        };

                        result.Add(singleResult);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        // Acceder a los Entity Validation Errors
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AccesoSalida.CalculaValorDeLasSalidasPorEntrada().. ");
                        }
                    }
                }
                throw;
            }
        }





    }
}
