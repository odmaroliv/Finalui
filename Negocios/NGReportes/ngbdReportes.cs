using Datos.Datosenti;
using Datos.ViewModels.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.NGReportes
{
    public class ngbdReportes
    {
        /// <summary>
        /// Busca en todo el almacen SD las entradas que aun no han salido y que se pueden indentificar con un coordinador, se interpreta como el inventario actual de SD
        /// </summary>
        public async Task<List<vmSd1Reporte>> sd1(string dato=null)
        {

            try
            {
                var lst = new List<vmSd1Reporte>();
               await Task.Run(() => {
               
                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDMENT
                                join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                join a in modelo.KDUV on k.C12 equals a.C2
                                join u in modelo.KDUSUARIOS on a.C22 equals u.C1

                                where d.C19 == "SD" && d.C23 != "T"
                                orderby d.C6 descending
                                select new vmSd1Reporte
                                {
                                    entrada = d.C6.Trim(),
                                    etiqueta = d.C9.Trim(),
                                    FechEntrada = d.C69,
                                    ordCar = d.C16.Trim(),
                                    cord = a.C3.Trim(),
                                    correoCord = u.C9.Trim(),
                                    des = d.C42.Trim()
                                    
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
        /// Busca en todo el almacen SD las entradas que aun no han salido sin importar campos como cliente, o coordinador asignado, se interpreta como el inventario actual de SD
        /// </summary>
        public async Task<List<vmSd1Reporte>> sd2(string dato = null)
        {

            try
            {
                var lst = new List<vmSd1Reporte>();
                await Task.Run(() => {
                    
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDMENT
                                    

                                    where d.C19 == "SD" && d.C23 != "T"
                                    orderby d.C6 descending
                                    select new vmSd1Reporte
                                    {
                                        entrada = d.C6.Trim(),
                                        etiqueta = d.C9.Trim(),
                                        FechEntrada = d.C69,
                                        ordCar = d.C16.Trim(),
                                        
                                        des = d.C42.Trim()

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
        /// (SD TO CSL) Reporte Inicial a la hora de entrar al sistema, funciona por coordinador 
        /// </summary>
        public async Task<List<vmInfoControlCors>> CargaControl(string dato)
        {
            DateTime Hoy = DateTime.Now;
            DateTime fc = fecharestada();
            try
            {
                var lst = new List<vmInfoControlCors>();
                await Task.Run(() => {

                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = (from d in modelo.KDMENT
                                    join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                    //join a in modelo.KDUV on k.C12 equals a.C2
                                    //join u in modelo.KDUSUARIOS on a.C22 equals u.C1

                                    where k.C9 <= Hoy && k.C9 >=fc && d.C19 == "SD" && d.C10 == dato.Trim() && k.C12 == Common.Cache.CacheLogin.idusuario.ToString().Trim() && d.C34 ==""
                                    orderby d.C6 descending
                                   
                                    select new vmInfoControlCors 
                                    {
                                        
                                        entrada = d.C6.Trim(),
                                        fechaentrada = d.C69.Trim(),
                                        ordcarga = d.C54.Trim(),
                                        cliente = k.C32.Trim(),
                                        ordapli = d.C16.Trim(),
                                        salida = d.C17.Trim()

                                    });
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
        private DateTime fecharestada()
        {
            int NumeroDias = 62;
            DateTime Hoy = DateTime.Now;
            DateTime FechaRestada = Hoy.AddDays(-NumeroDias);
            return FechaRestada;
        }




    }   
}
