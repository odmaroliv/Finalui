using Datos.Datosenti;
using Datos.ViewModels.Coord;
using Datos.ViewModels.Coord.oldCot;
using Datos.ViewModels.Salidas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Negocios.NGCotizacion
{
    public class accesoCotizaciones
    {
        public List<vmNoCot> UltimaCotizacion(string datoSucIni, int modo)
        {
            string br = "KFUD" + modo + "04." + datoSucIni;
            try
            {
                var lst2 = new List<vmNoCot>();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.SqlIov
                                where d.C1.Contains(br) //&& d.C19 != sdestino 
                                select new vmNoCot
                                {
                                    noCot = d.C4
                                };
                    lst2 = lista.ToList();

                }

                return lst2;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<vmBusquedaCot>> BuscarCitizacionPorId(string id, string origen) //BUSQUEDA RAPIDA POR ENTRADA <Funciona en la pantalla principal Form1>
        {

            try
            {
                var lst2 = new List<vmBusquedaCot>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {

                        var lst = from d in modelo.KDM1
                                  where d.C6.Equals(id) && d.C4 == 34 && d.C1 == origen
                                  orderby (d.C7)
                                  select new vmBusquedaCot
                                  {

                                      C1 = d.C1,

                                      C6 = d.C6,
                                      C82 = d.C82,
                                      C16 = d.C16,
                                      C40 = d.C40,
                                      C42 = d.C42,
                                      C93 = d.C93,
                                      C94 = d.C94,
                                      C83 = d.C83,
                                      C84 = d.C84,
                                      C89 = d.C89,
                                      C30 = d.C30,
                                      C14 = d.C14,
                                      C10 = d.C10,
                                      C32 = d.C32,
                                      C33 = d.C33,
                                      C34 = d.C34,
                                      C35 = d.C35,


                                      C7 = d.C7,

                                      C9 = d.C9,

                                      C13 = d.C13,


                                      C67 = d.C67,


                                      C86 = d.C86,
                                      C24 = d.C24,
                                      C43 = d.C43,
                                      C44 = d.C44,
                                      C27 = d.C27,
                                      C113 = d.C113

                                  };
                        lst2 = lst.ToList();

                    }

                });
                return lst2;

            }
            catch (Exception EX)
            {
                throw;
            }
        }


        public async Task<List<vmOldBusquedaCot>> BuscarCitizacionPorClienteOld(string id, string origen, string ivaPor, DateTime fh1, DateTime fh2) //BUSQUEDA RAPIDA POR ENTRADA <Funciona en la pantalla principal Form1>
        {
            // string cadenaCodigo = origen + "-UD340" + ivaPor + "-"+ id;
            try
            {
                var lst2 = new List<vmOldBusquedaCot>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        /*   var lst = from d in modelo.KDM1
                                     where d.C10.Contains(id) && d.C4 == 34 && d.C1 == origen
                                     orderby (d.C6)
                                     select new vmOldBusquedaCot
                                     {
                                         C1 = d.C1,
                                         C6 = d.C6,
                                         C16 = d.C16,
                                         C40 = d.C40,
                                         C42 = d.C42,
                                         C93 = d.C93,
                                         C94 = d.C94,
                                         C83 = d.C83,
                                         C84 = d.C84,
                                         C89 = d.C89,
                                         C30 = d.C30,
                                         C14 = d.C14,
                                         C10 = d.C10,
                                         C32 = d.C32,
                                         C33 = d.C33,
                                         C34 = d.C34,
                                         C35 = d.C35,
                                         C7 = d.C7,
                                         C9 = d.C9,
                                         C13 = d.C13,
                                         C67 = d.C67,
                                         C81 = "",
                                         C86 = d.C86,
                                         C24 = d.C24,
                                     };

                           lst2 = lst.ToList();

                           foreach (var item in lst2)
                           {
                               item.C81 = String.Join(",", modelo.KDM1.Where(s => s.C115 == origen + "-UD340" + ivaPor + "-" + item.C6)
                                                                        .Select(s => s.C6));
                           }*/


                        string sqlQuery = @"
                        SELECT d.C1, d.C6, d.C16, d.C40, d.C42, d.C93, d.C94, d.C83, d.C84, d.C89, 
                            d.C30, d.C14, d.C10, d.C32, d.C33, d.C34, d.C35, d.C7, d.C9, d.C13, d.C67, 
                            C81 = '',
                            d.C86, d.C24
                        FROM KDM1 d
                            
                        WHERE d.C10 LIKE @id AND d.C4 = 34 AND d.C1 = @origen AND  d.C43 !='C'  AND (d.C9 >= @FECHA1 AND d.C9 <= @FECHA2)
                        ORDER BY d.C6
                                        ";

                        List<SqlParameter> parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@id", $"%{id}%"),
                        new SqlParameter("@origen", origen),
                        new SqlParameter("@C115", $"{origen}-UD340{ivaPor}-" + "d.C6"),
                         new SqlParameter("@FECHA1", fh1),
                         new SqlParameter("@FECHA2", fh2)
                    };
                        var results = modelo.Database.SqlQuery<vmOldBusquedaCot>(sqlQuery, parameters.ToArray()).ToList();
                        lst2 = results;


                        foreach (var item in results)
                        {

                            var all = $"{origen}-UD340{ivaPor}-{item.C6}"; // Set the value of @C115 for the current item
                         
                            item.C81 = modelo.Database.SqlQuery<string>(@"
                      SELECT STUFF((SELECT ',' + s.C6
                      FROM KDM1 s
                      WHERE s.C115 = @all AND C4=35
                      FOR XML PATH('')), 1, 1, '')
                     ", new SqlParameter("@all", all)).FirstOrDefault();
                        }


                        // var result = modelo.Database.SqlQuery<vmCargaOrdenesDeSalida>(query, sucori, estatuss, 45, 30).ToList();


                    }

                });
                return lst2;

            }
            catch (Exception EX)
            {
                throw;
            }
        }

        public async Task<List<vmOldBusquedaCot>> BuscarCitizacionPorCoordOld(string id, string origen) //BUSQUEDA RAPIDA POR ENTRADA <Funciona en la pantalla principal Form1>
        {

            try
            {
                var lst2 = new List<vmOldBusquedaCot>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {

                        var lst = from d in modelo.KDM1
                                  where d.C67.Contains(id) && d.C4 == 34 && d.C1 == origen
                                  orderby (d.C6)
                                  select new vmOldBusquedaCot
                                  {

                                      C1 = d.C1,

                                      C6 = d.C6,
                                      C16 = d.C16,
                                      C40 = d.C40,
                                      C42 = d.C42,
                                      C93 = d.C93,
                                      C94 = d.C94,
                                      C83 = d.C83,
                                      C84 = d.C84,
                                      C89 = d.C89,
                                      C30 = d.C30,
                                      C14 = d.C14,
                                      C10 = d.C10,
                                      C32 = d.C32,
                                      C33 = d.C33,
                                      C34 = d.C34,
                                      C35 = d.C35,


                                      C7 = d.C7,

                                      C9 = d.C9,

                                      C13 = d.C13,


                                      C67 = d.C67,

                                      C81 = d.C81,
                                      C86 = d.C86,
                                      C24 = d.C24,




                                  };
                        lst2 = lst.ToList();

                    }

                });
                return lst2;

            }
            catch (Exception EX)
            {
                throw;
            }
        }
        public async Task<List<vmInfoTablaCot>> BuscaInfoTablaCotizacionPorId(string id, string origen) //BUSQUEDA RAPIDA POR ENTRADA <Funciona en la pantalla principal Form1>
        {

            try
            {
                var lst2 = new List<vmInfoTablaCot>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {

                        var lst = from d in modelo.KDM2
                                  where d.C6.Equals(id) && d.C4 == 34 && d.C1 == origen
                                  orderby (d.C7)
                                  select new vmInfoTablaCot
                                  {
                                      C7 = d.C7,

                                      C10 = d.C10,
                                      C39 = d.C39,
                                      C13 = d.C13,
                                      C12 = d.C12,
                                      //C17 = d.C17,
                                      C36 = d.C36,



                                  };
                        lst2 = lst.ToList();

                    }

                });
                return lst2;

            }
            catch (Exception EX)
            {
                throw;
            }
        }

        public async Task<List<vmEntCot>> BuscaEntsEnCot(string nCot, string suc) //BUSQUEDA RAPIDA POR ENTRADA <Funciona en la pantalla principal Form1>
        {

            try
            {
                var lst2 = new List<vmEntCot>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {

                        var lst = from d in modelo.KDM1
                                  where d.C115.Equals(suc+"-"+nCot) && d.C4 == 35 
                                  orderby (d.C6)
                                  select new vmEntCot
                                  {
                                      Entrada = d.C6,
                                      sucursal = d.C1,
                                  };
                        lst2 = lst.ToList();

                    }

                });
                return lst2;

            }
            catch (Exception EX)
            {
                throw;
            }
        }

        public vmNoCot ValidaEntradaConCot(string datoSucIni, string Ent)
        {

            try
            {
                var lst2 = new vmNoCot();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDM1
                                where d.C1.Contains(datoSucIni) && d.C6 == Ent
                                select new vmNoCot
                                {
                                    noCot = d.C115
                                };
                    lst2 = (vmNoCot)lista.FirstOrDefault();

                }

                return lst2;
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
