using Datos.Datosenti;
using Datos.ViewModels.Coord;
using Datos.ViewModels.Coord.oldCot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                  where d.C6.Equals(id) && d.C4==34 && d.C1 == origen
                                  orderby (d.C7)
                                  select new vmBusquedaCot
                                  {
                                      
                                      C1  = d.C1  , 
                                     
                                      C6  = d.C6  ,
                                      C16 = d.C16,
                                      C40 = d.C40,
                                      C42 = d.C42,
                                      C93 = d.C93 ,
                                      C94 = d.C94 ,
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


                                      C7 = d.C7  , 
                                     
                                      C9  = d.C9  , 
                                   
                                      C13 = d.C13 , 
                                   
                                     
                                      C67 = d.C67 , 
                                 
                                  
                                      C86 = d.C86 , 
                                      C24= d.C24,
                                      C43 = d.C43,
                                      C44 = d.C44,




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


        public async Task<List<vmOldBusquedaCot>> BuscarCitizacionPorClienteOld(string id, string origen) //BUSQUEDA RAPIDA POR ENTRADA <Funciona en la pantalla principal Form1>
        {

            try
            {
                var lst2 = new List<vmOldBusquedaCot>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {

                        var lst = from d in modelo.KDM1
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
                                      C17 = d.C17,
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

        public async Task<List<vmEntCot>> BuscaEntsEnCot(string nCot) //BUSQUEDA RAPIDA POR ENTRADA <Funciona en la pantalla principal Form1>
        {

            try
            {
                var lst2 = new List<vmEntCot>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {

                        var lst = from d in modelo.KDM1
                                  where d.C116.Equals(nCot) && d.C4 == 35
                                  orderby (d.C6)
                                  select new vmEntCot
                                  {
                                      Entrada = d.C6,
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
                                    noCot = d.C116
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
