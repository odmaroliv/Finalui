using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
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

                                         where string.IsNullOrEmpty(q.C18) && !string.IsNullOrEmpty(q.C16) && q.C54.Contains(sucori) && q.C19.Contains(sucori) && q.C20.Trim() != "F"

                                         group q.C54 by q.C54 into g
                                         select new vmCargaOrdenesDeCarga
                                         {
                                             //Origen= q.C9
                                             Documento = g.Key
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

        public async Task<List<vmCargaOrdenesDeSalida>> LlenaDGVSalidas(string sucori, string doc, int numerosuc)
        {
            int cha = sucori.Trim().ToString().Length;
            int cade = "-UD4501-".Length;
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
                                             Referencia = g.Select(x=>x.C11).FirstOrDefault(),
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

        public async Task<List<vmCargaOrdenesDeSalida>> BuscEntradasEnSalida(string salida)
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
                                         
                                         where q.C55.Contains(salida)

                                         //group k by q.C55 into g


                                         select new vmCargaOrdenesDeSalida
                                         {
                                             Documento = q.C9
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
        public async Task<List<vmGeneralesSalidas>> LlenaGeneralesSalida(string salidapausada)
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

                                         where q.C6.Contains(salidapausada) && q.C4 == 45

                                         //group q.C54 by q.C54 into g
                                         select new vmGeneralesSalidas
                                         {
                                             sDestino = q.C103,
                                             sOrigen = q.C1,
                                             Chofer = q.C96,
                                             Placas = q.C95,
                                             Referencia = q.C11 ,
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
        
    }
}
