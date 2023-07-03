using Datos.Datosenti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ViewModels.Recepciones;
using mainVentana.VistaRecepcion;
using Datos.ViewModels.Salidas;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Negocios.AccesoRecepciones
{
    public class ngAccesoRecepciones
    {


        /// <summary>
        /// Buscamos los las ordenes de carga disponibles
        /// 2 tujuana (para tijuana busca recepciones en vez de ordenes de carga), 3 cabo, 4 san diego
        /// </summary>
        /// <param name="sucori"></param>
        /// <param name="doc"></param>
        /// <param name="sucursa"></param>
        /// <returns></returns>
        /// 

        public async Task<List<vmSalidaDocumentoONLY>> LlenaDGV(string sucori, string doc, int numerosuc, string envia)
        {
            sucori = sucori.Trim();

            try
            {
                string c20Value = sucori.Contains("TJ") ? "F" : "PR";
                string selectColumn = (sucori.Contains("TJ") || (envia == "SD" && sucori == "CSL")) ? "km.C17" : "km.C64";
                string condition = (sucori.Contains("TJ") || (envia == "SD" && sucori == "CSL")) ? $"km.c20 {(sucori.Contains("TJ") ? "!=" : "=")} '{c20Value}' AND (km.C34 IS NOT NULL OR km.C34 != '') AND (km.C18 IS NOT NULL OR km.C18 != '')" : "km.c20 != 'F' AND (km.C34 IS NOT NULL OR km.C34 != '') AND (km.C18 IS NULL OR km.C18 = '')";

                List<vmSalidaDocumentoONLY> result = null;

                using (modelo2Entities modelo = new modelo2Entities())
                {

                    modelo.Database.CommandTimeout = 300;
                    result = await Task.Run(() =>
                    {
                        return modelo.Database.SqlQuery<vmSalidaDocumentoONLY>($@"
                    SELECT salidaDoc = {selectColumn} 
                    FROM KDMENT km 
                    JOIN (
                        SELECT kd.C103, kd.C4,kd.C6 
                        FROM KDM1 kd 
                        WHERE kd.C1 = @envia and kd.C103 = @sucori and kd.C4 = 45
                    ) kd 
                    ON km.C55 like '%'+kd.C6+'%' and {condition}
                    GROUP BY {selectColumn}",
                            new SqlParameter("@envia", envia),
                            new SqlParameter("@sucori", sucori))
                            .ToList();
                    });
                }

                return result.OrderByDescending(x => x.salidaDoc).Take(200).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /* public async Task<List<vmSalidaDocumentoONLY>> LlenaDGV(string sucori, string doc, int numerosuc, string envia)
         {
             var lst2 = new List<vmSalidaDocumentoONLY>();
             int cha = sucori.Trim().ToString().Length;
             string sql = string.Empty;

             try
             {
                 await Task.Run(() =>
                 {
                     using (modelo2Entities modelo = new modelo2Entities())
                     {
                         if (sucori.Trim().Contains("TJ") || (envia == "SD" && sucori == "CSL"))
                         {
                             string c20Value = sucori.Trim().Contains("TJ") ? "F" : "PR";
                             sql = $"SELECT salidaDoc = km.C17 FROM KDMENT km JOIN (SELECT kd.C103, kd.C4,kd.C6 FROM KDM1 kd WHERE kd.C1 = '{envia}' and kd.C103 = '{sucori}' and kd.C4 = 45) kd ON km.C55 like '%'+kd.C6+'%' and km.c20 {(sucori.Trim().Contains("TJ") ? "!=" : "=")} '{c20Value}' AND (km.C34 IS NOT NULL OR km.C34 != '') AND (km.C18 IS NOT NULL OR km.C18 != '') GROUP BY km.C17";
                         }
                         else
                         {
                             sql = $"SELECT salidaDoc = km.C64 FROM KDMENT km JOIN (SELECT kd.C103, kd.C4,kd.C6 FROM KDM1 kd WHERE kd.C1 = '{envia}' and kd.C103 = '{sucori}' and kd.C4 = 45) kd ON km.C55 like '%'+kd.C6+'%' and km.c20 != 'F' AND (km.C34 IS NOT NULL OR km.C34 != '') AND (km.C18 IS NULL OR km.C18 = '') GROUP BY km.C64";
                         }

                         lst2 = modelo.Database.SqlQuery<vmSalidaDocumentoONLY>(sql).OrderByDescending(x => x.salidaDoc).Take(50).ToList();
                     }
                 });

                 return lst2;
             }
             catch (Exception)
             {
                 throw;
             }
         }*/



        public async Task<List<vmEntBySalida>> CargaEntBySalida(string id, string sOrigen, string sEnvia)
        {
            if (sOrigen.Contains("TJ"))
            {
                try
                {
                    var lst2 = new List<vmEntBySalida>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())

                        {
                            var lista = from d in modelo.KDMENT

                                        where d.C17.Equals(id) && String.IsNullOrEmpty(d.C34) && String.IsNullOrEmpty(d.C67) && d.C20 != "F"
                                        select new vmEntBySalida
                                        {
                                            Etiqueta = d.C9.Trim(),
                                            Salida = d.C17.Trim()
                                        };
                            lst2 = lista.ToList();

                        }
                    });

                    return lst2;
                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {

                if (sEnvia=="SD" && sOrigen=="CSL")
                {
                    try
                    {
                        var lst2 = new List<vmEntBySalida>();
                        await Task.Run(() =>
                        {
                            using (modelo2Entities modelo = new modelo2Entities())

                            {
                                var lista = from d in modelo.KDMENT

                                            where d.C17.Equals(id) && String.IsNullOrEmpty(d.C34) && String.IsNullOrEmpty(d.C67) && d.C20 == "PR"
                                            select new vmEntBySalida
                                            {
                                                Etiqueta = d.C9.Trim(),
                                                Salida = d.C17.Trim()
                                            };
                                lst2 = lista.ToList();

                            }
                        });

                        return lst2;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else
                {
                    try
                    {
                        var lst2 = new List<vmEntBySalida>();
                        await Task.Run(() =>
                        {
                            using (modelo2Entities modelo = new modelo2Entities())

                            {
                                var lista = from d in modelo.KDMENT

                                            where d.C64.Equals(id) && String.IsNullOrEmpty(d.C34) && /*String.IsNullOrEmpty(d.C18) &&*/ d.C20 != "F"
                                            select new vmEntBySalida
                                            {
                                                Etiqueta = d.C9,
                                                Salida = d.C64


                                            };
                                lst2 = lista.ToList();

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


        public List<vmNumeroDeRecepcion> UltimaRecepcion(string datoSucIni, int modo)
        {
            string br = "KFUD" + modo + "01." + datoSucIni;
            try
            {
                var lst2 = new List<vmNumeroDeRecepcion>();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.SqlIov
                                where d.C1.Contains(br) //&& d.C19 != sdestino 
                                select new vmNumeroDeRecepcion
                                {
                                    Recepcion = d.C4
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


        public async Task<List<vmCargaOrdenesDeRecepcion>> LlenaDGVRecepcion(string sucori, string doc, int numerosuc)
        {
            sucori = sucori.Trim();

            string estatuss = default;

            if (sucori == "TJ")
            {
                estatuss = "PRTJ";
            }
            else if (sucori == "SD")
            {
                estatuss = "PRSD";
            }
            else if (sucori == "CSL")
            {
                estatuss = "PRCSL";
            }

            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var baseQuery = modelo.KDMENT.AsQueryable().Join(modelo.KDM1,
                                        q => q.C56,
                                        k => sucori + "-UD5001-" + k.C6,
                                        (q, k) => new { Q = q, K = k });

                    if (sucori.Contains("TJ"))
                    {
                        baseQuery = baseQuery.Where(x => x.Q.C19.Contains(sucori) && x.K.C61.Contains(estatuss) && x.K.C4 == 50);
                    }
                    else
                    {
                        baseQuery = baseQuery.Where(x => x.Q.C18.Contains(sucori) && x.Q.C19.Contains(sucori) && x.K.C1.Contains(sucori) && x.K.C61.Contains(estatuss) && x.K.C4 == 50);
                    }

                    var documents = await baseQuery.GroupBy(x => sucori.Contains("TJ") ? x.Q.C67 : x.Q.C56)
                                                    .Select(g => new vmCargaOrdenesDeRecepcion
                                                    {
                                                        Documento = g.Key,
                                                        Referencia = g.Select(x => x.K.C11).FirstOrDefault(),
                                                        Fecha = g.Select(x => x.K.C9).FirstOrDefault().Value
                                                    })
                                                    .OrderByDescending(x => x.Documento)
                                                    .Take(30)
                                                    .ToListAsync();

                    return documents;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*public async Task<List<vmCargaOrdenesDeRecepcion>> LlenaDGVRecepcion(string sucori, string doc, int numerosuc)
        {
            string estatuss = default;

            if (sucori.Trim() == "TJ")
            {
                estatuss = "PRTJ";
            }
            if (sucori.Trim() == "SD")
            {
                estatuss = "PRSD";
            }
            if (sucori.Trim() == "CSL")
            {
                estatuss = "PRCSL";
            }

            int cha = sucori.Trim().ToString().Length;
            int cade = "-UD5001-".Length;
            if (sucori.Contains("TJ"))
            {
                try
                {
                    var lst2 = new List<vmCargaOrdenesDeRecepcion>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            var oDocument = (from q in modelo.KDMENT.AsQueryable()
                                             join k in modelo.KDM1 on q.C56 equals sucori.Trim() + "-UD5001-" + k.C6
                                             where q.C19.Contains(sucori) && k.C61.Contains(estatuss) && k.C4 == 50

                                             group k by q.C67 into g


                                             select new vmCargaOrdenesDeRecepcion
                                             {
                                                 Documento = g.Key,
                                                 Referencia = g.Select(x => x.C11).FirstOrDefault(),
                                                 Fecha = g.Select(x => x.C9).FirstOrDefault().Value

                                             }).OrderByDescending(x => x.Documento).Take(30).ToList();

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
            else
            {
                try
                {
                    var lst2 = new List<vmCargaOrdenesDeRecepcion>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            var oDocument = (from q in modelo.KDMENT.AsQueryable()
                                             join k in modelo.KDM1 on q.C56 equals sucori.Trim() + "-UD5001-" + k.C6
                                             where q.C18.Contains(sucori) && q.C19.Contains(sucori) && k.C1.Contains(sucori) && k.C61.Contains(estatuss) && k.C4 == 50

                                             group k by q.C56 into g


                                             select new vmCargaOrdenesDeRecepcion
                                             {
                                                 Documento = g.Key,
                                                 Referencia = g.Select(x => x.C11).FirstOrDefault(),
                                                 Fecha = g.Select(x => x.C9).FirstOrDefault().Value

                                             }).OrderByDescending(x => x.Documento).Take(30).ToList();

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

        }*/

        public async Task<List<vmCargaOrdenesDeRecepcion>> BuscEntradasEnRecepcion(string recepcion, string origen,string sEnvia)
        {
            if (origen.Contains("TJ"))
            {

                try
                {
                    var lst2 = new List<vmCargaOrdenesDeRecepcion>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            var oDocument = (from q in modelo.KDMENT
                                             join k in modelo.KDM1 on new { q.C1, q.C4, q.C6 } equals new { k.C1, k.C4, k.C6 }
                                             join a in modelo.KDUV on k.C12 equals a.C2
                                             join u in modelo.KDUSUARIOS on a.C22 equals u.C1
                                             where q.C56.Contains(recepcion)

                                             //group k by q.C55 into g


                                             select new vmCargaOrdenesDeRecepcion
                                             {
                                                 Documento = q.C9,
                                                 Referencia = q.C17,
                                                 correo = u.C9,
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
            else
            {
                if (sEnvia=="SD" && origen=="CSL")
                {
                    try
                    {
                        var lst2 = new List<vmCargaOrdenesDeRecepcion>();
                        await Task.Run(() =>
                        {
                            using (modelo2Entities modelo = new modelo2Entities())
                            {
                                lst2.Clear();
                                var oDocument = (from q in modelo.KDMENT
                                                 join k in modelo.KDM1 on new { q.C1, q.C4, q.C6 } equals new { k.C1, k.C4, k.C6 }
                                                 join a in modelo.KDUV on k.C12 equals a.C2
                                                 join u in modelo.KDUSUARIOS on a.C22 equals u.C1
                                                 where q.C56.Contains(recepcion)

                                                 //group k by q.C55 into g


                                                 select new vmCargaOrdenesDeRecepcion
                                                 {
                                                     Documento = q.C9,
                                                     Referencia = q.C17,
                                                     correo = u.C9,
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
                else
                {
                    try
                    {
                        var lst2 = new List<vmCargaOrdenesDeRecepcion>();
                        await Task.Run(() =>
                        {
                            using (modelo2Entities modelo = new modelo2Entities())
                            {
                                lst2.Clear();
                                var oDocument = (from q in modelo.KDMENT
                                                 join k in modelo.KDM1 on new { q.C1, q.C4, q.C6 } equals new { k.C1, k.C4, k.C6 }
                                                 join a in modelo.KDUV on k.C12 equals a.C2
                                                 join u in modelo.KDUSUARIOS on a.C22 equals u.C1
                                                 where q.C56.Contains(recepcion)

                                                 //group k by q.C55 into g


                                                 select new vmCargaOrdenesDeRecepcion
                                                 {
                                                     Documento = q.C9,
                                                     Referencia = q.C64,
                                                     correo = u.C9
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

        public async Task<List<vmCargaOrdenesDeRecepcion>> LlenaDGVpausadas(string recepausada)
        {

            try
            {
                var lst2 = new List<vmCargaOrdenesDeRecepcion>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        lst2.Clear();
                        var oDocument = (from q in modelo.KDM1

                                         where q.C45.Contains(recepausada)

                                         //group q.C54 by q.C54 into g
                                         select new vmCargaOrdenesDeRecepcion
                                         {
                                             //Origen= q.C9
                                             Documento = q.C6
                                         }).OrderByDescending(x => x.Documento).Take(30).ToList();

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

        public List<vmNoRecepcion> ultimaRecepcionsql(string datoSucIni, int modo)
        {
            string br = "KFUD" + modo + "01." + datoSucIni;
            try
            {
                var lst2 = new List<vmNoRecepcion>();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.SqlIov
                                where d.C1.Contains(br) //&& d.C19 != sdestino 
                                select new vmNoRecepcion
                                {
                                    recep = d.C4
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
        public async Task<List<vmGeneralesSalidas>> LlenaGeneralesRecepcion(string salidapausada, string sOrigen)
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

                                         where q.C6.Contains(salidapausada) && q.C4 == 50 && q.C1.Contains(sOrigen)

                                         //group q.C54 by q.C54 into g
                                         select new vmGeneralesSalidas
                                         {
                                             sDestino = q.C103,
                                             sOrigen = q.C1,
                                             Chofer = q.C24, // NOTAS 
                                             Placas = q.C47, //SUCURSAL QUE ENVIA
                                             Referencia = q.C11,
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


        public KDMENT VerificaEntrada(string recepausada)
        {

            try
            {
                var lst2 = new KDMENT();
               
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                       
                        var oDocument = (from q in modelo.KDMENT

                                         where q.C9.Contains(recepausada)

                                         //group q.C54 by q.C54 into g
                                         select q).FirstOrDefault();

                        lst2 = oDocument;
                    }
                
                return lst2;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        public List<string> BuscUltimaSalida(string suc)
        {

            List<string> lista1 = new List<string>();

            using (modelo2Entities db = new modelo2Entities())
            {
                var lst = from k in db.NumeroMAX(suc, "45")

                          select k;

                lista1 = lst.ToList();

            }


            return lista1;

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
            catch (Exception)
            {

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

                                         where q.C6.Contains(salidapausada) && q.C4 == 45 && q.C1.Contains(sOrigen)

                                         //group q.C54 by q.C54 into g
                                         select new vmGeneralesSalidas
                                         {
                                             sDestino = q.C103,
                                             sOrigen = q.C1,
                                             Chofer = q.C96,
                                             Placas = q.C95,
                                             Referencia = q.C11,
                                             Transportista = q.C94
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

        public vmAuxiliaresSalidas ObtieCorreo(string stiqueta)
        {
            char[] ch = "-".ToCharArray();
            string sori = stiqueta.Split(ch)[0];
            string ent = stiqueta.Split(ch)[1];
            try
            {
                var lst = new vmAuxiliaresSalidas();


                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = (from d in modelo.KDMENT
                                 join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                 join a in modelo.KDUV on k.C12 equals a.C2
                                 join u in modelo.KDUSUARIOS on a.C22 equals u.C1

                                 where d.C1.Contains(sori) && d.C4 == 35 && d.C9.Contains(stiqueta)

                                 select new vmAuxiliaresSalidas
                                 {

                                     Correo = u.C9,
                                     orden = d.C16,
                                     Etiqueta = d.C9


                                 }).Take(1).FirstOrDefault();
                    lst = lista;

                }

                return lst;
            }
            catch (Exception)
            {

                return new vmAuxiliaresSalidas { Etiqueta = "No se encontro esta etiquita", Correo = "", orden = "" };
            }
        }

        */

    }
}
