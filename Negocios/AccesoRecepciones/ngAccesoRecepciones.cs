﻿using Datos.Datosenti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ViewModels.Recepciones;

namespace Negocios.AccesoRecepciones
{
    public class ngAccesoRecepciones
    {


        /// <summary>
        /// Buscamos los las ordenes de carga disponibles
        /// 2 tujuana, 3 cabo, 4 san diego
        /// </summary>
        /// <param name="sucori"></param>
        /// <param name="doc"></param>
        /// <param name="sucursa"></param>
        /// <returns></returns>
        public async Task<List<vmSalidaDocumentoONLY>> LlenaDGV(string sucori, string sudest, string doc, int numerosuc)
        {
            if (sucori.Trim().Contains("TJ"))//Para la sucursal de tijuana no se levantan ordenes de carga, por lo que mandamos las ordenes de Salida directamente
            {
                int cha = sucori.Trim().ToString().Length;
                try
                {
                    var lst2 = new List<vmSalidaDocumentoONLY>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            var oDocument = (from q in modelo.KDMENT
                                                 //join k in modelo.KDM1 on q.C55 equals sucori.Trim() + "-UD4501-" + k.C6
                                                 /*where string.IsNullOrEmpty(q.C18) && !string.IsNullOrEmpty(q.C16) && q.C54.Contains(sucori) && q.C19.Contains(sucori) && q.C20.Trim() != "F"*/

                                             where  q.C20 != "F" && String.IsNullOrEmpty(q.C67)  && !string.IsNullOrEmpty(q.C64) && String.IsNullOrEmpty(q.C34) && q.C64.Contains(sucori)

                                             group q.C64 by q.C64 into g
                                             select new vmSalidaDocumentoONLY
                                             {
                                                 //Origen= q.C9
                                                 salidaDoc = g.Key
                                             }).OrderByDescending(x => x.salidaDoc).Take(30).ToList();

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
                int cha = sucori.Trim().ToString().Length;
                try
                {
                    var lst2 = new List<vmSalidaDocumentoONLY>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            var oDocument = (from q in modelo.KDMENT

                                                 /*where string.IsNullOrEmpty(q.C18) && !string.IsNullOrEmpty(q.C16) && q.C54.Contains(sucori) && q.C19.Contains(sucori) && q.C20.Trim() != "F"*/

                                             where string.IsNullOrEmpty(q.C18) && string.IsNullOrEmpty(q.C64) && String.IsNullOrEmpty(q.C67) && q.C17.Contains(sucori) && q.C20 != "F" && String.IsNullOrEmpty(q.C34) && !string.IsNullOrEmpty(q.C17)

                                             group q.C17 by q.C17 into g
                                             select new vmSalidaDocumentoONLY
                                             {
                                                 salidaDoc = g.Key,

                                             }).OrderByDescending(x => x.salidaDoc).Take(30).ToList();

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



        public async Task<List<vmEntBySalida>> CargaEntBySalida(string id, string sorigen)
        {
            if (sorigen.Contains("TJ"))
            {
                try
                {
                    var lst2 = new List<vmEntBySalida>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())

                        {
                            var lista = from d in modelo.KDMENT

                                        where d.C64.Equals(id) && String.IsNullOrEmpty(d.C34) && String.IsNullOrEmpty(d.C67) && d.C20 !="F"
                                        select new vmEntBySalida
                                        {
                                            Etiqueta = d.C9.Trim(),
                                            Salida = d.C64.Trim()


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

                                        where d.C17.Equals(id) && String.IsNullOrEmpty(d.C34) && String.IsNullOrEmpty(d.C18) && d.C20 != "F"
                                        select new vmEntBySalida
                                        {
                                            Etiqueta = d.C9,
                                            Salida = d.C17


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

        /*
        public async Task<List<vmCargaOrdenesDeSalida>> LlenaDGVSalidas(string sucori, string doc, int numerosuc)
        {
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
                            lst2.Clear();
                            var oDocument = (from q in modelo.KDMENT.AsQueryable()
                                             join k in modelo.KDM1 on q.C55 equals sucori.Trim() + "-UD4501-" + k.C6
                                             where q.C19.Contains(sucori) && k.C43.Contains("P")

                                             group k by q.C55 into g


                                             select new vmCargaOrdenesDeSalida
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
                    var lst2 = new List<vmCargaOrdenesDeSalida>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            var oDocument = (from q in modelo.KDMENT.AsQueryable()
                                             join k in modelo.KDM1 on q.C55 equals sucori.Trim() + "-UD4501-" + k.C6
                                             where string.IsNullOrEmpty(q.C18) && q.C55.Contains(sucori) && q.C19.Contains(sucori) && k.C43.Contains("P")

                                             group k by q.C55 into g


                                             select new vmCargaOrdenesDeSalida
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

        }

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
                                             join k in modelo.KDM1 on new { q.C1, q.C4, q.C6 } equals new { k.C1, k.C4, k.C6 }
                                             join a in modelo.KDUV on k.C12 equals a.C2
                                             join u in modelo.KDUSUARIOS on a.C22 equals u.C1
                                             where q.C64.Contains(salida)

                                             //group k by q.C55 into g


                                             select new vmCargaOrdenesDeSalida
                                             {
                                                 Documento = q.C9,
                                                 Referencia = q.C18,
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
                    var lst2 = new List<vmCargaOrdenesDeSalida>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())
                        {
                            lst2.Clear();
                            var oDocument = (from q in modelo.KDMENT
                                             join k in modelo.KDM1 on new { q.C1, q.C4, q.C6 } equals new { k.C1, k.C4, k.C6 }
                                             join a in modelo.KDUV on k.C12 equals a.C2
                                             join u in modelo.KDUSUARIOS on a.C22 equals u.C1
                                             where q.C55.Contains(salida)

                                             //group k by q.C55 into g


                                             select new vmCargaOrdenesDeSalida
                                             {
                                                 Documento = q.C9,
                                                 Referencia = q.C54,
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
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<vmGeneralesSalidas>> LlenaGeneralesSalida(string salidapausada, string sorigen)
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

                                         where q.C6.Contains(salidapausada) && q.C4 == 45 && q.C1.Contains(sorigen)

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