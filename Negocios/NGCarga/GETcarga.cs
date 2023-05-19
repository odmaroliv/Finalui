using Datos.Datosenti;
using Datos.ViewModels.Carga;
using Datos.ViewModels.Entradas;
using Datos.ViewModels.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.NGCarga
{
    public class GETcarga
    {

        public List<vmNoOrCarga> ultimaCarga(string datoSucIni, int modo)
        {
            string br = "KFUD" + modo + "01." + datoSucIni;
            try
            {
                var lst2 = new List<vmNoOrCarga>();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.SqlIov
                                where d.C1.Contains(br) //&& d.C19 != sdestino 
                                select new vmNoOrCarga
                                {
                                    OrdenCarga = d.C4
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

        //
        /// <summary>
        /// true = Orden de carga y todos sus campos, false = ERROR
        /// </summary>
        /// <param name="datoSucIni"></param>
        /// <param name="ordendecarga"></param>
        /// <returns>campos</returns>
        //
        public vmCargaConsultaGeneral ObtieneOrdenDeCargaPorIdYSucursal(string datoSucIni, string ordendecarga)
        {
            //var lst2 = new List<vmCargaConsultaGeneral>();
            string dSucursalInicio = !String.IsNullOrEmpty(datoSucIni.Trim()) ? datoSucIni : "";
            string dOrdenDeCarga = !String.IsNullOrEmpty(ordendecarga.Trim()) ? ordendecarga : "";
            if (dSucursalInicio == "" || dOrdenDeCarga == "")
            {
                return new vmCargaConsultaGeneral { errormsg = "ERROR" };

            }
            else
            {
                try
                {

                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDM1
                                    where d.C1.Contains(dSucursalInicio) && d.C6.Contains(dOrdenDeCarga) && d.C4 == 40//&& d.C19 != sdestino 
                                    select new vmCargaConsultaGeneral
                                    {
                                        sucursalOrigen = d.C1,
                                        numeroCarga = d.C6,
                                        fechaAlta = d.C9,
                                        tipoOperacion = d.C101,
                                        sucursalDestino = d.C103,
                                        moneda = d.C7,
                                        paridad = d.C40,
                                        referencia = d.C11,
                                        fechaCierre = d.C111,
                                        horaCierre = d.C112,
                                        estatus = d.C43,
                                    };
                        return (vmCargaConsultaGeneral)lista.FirstOrDefault();


                    }

                    //return lst2;
                }
                catch (Exception)
                {

                    throw;
                }
            }


        }
        public List<vmEntradasEnCarga> EntradasEnCarga(string datoSucIni, int carga)
        {
            string codigo = datoSucIni.Trim() + "-UD4001-" + carga.ToString("D7");
            try
            {
                var lst2 = new List<vmEntradasEnCarga>();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDMENT
                                join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                where d.C54.Contains(codigo) //&& d.C19 != sdestino 
                                select new vmEntradasEnCarga
                                {
                                    Entrada = d.C6,
                                    Etiqueta = d.C9,
                                    Unidad = k.C98,
                                    Cliente = k.C32,
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


        public List<vmCargaCordinadores> ObtieneCargasActivas(string datoSucIni, string oper)
        {
            //string codigo = datoSucIni.Trim() + "-UD4001-" + carga.ToString("D7");
            DateTime hoy = DateTime.Now;
            int hora = DateTime.Now.Hour;

            try
            {
                var lst2 = new List<vmCargaCordinadores>();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDM1
                                    // join k in modelo.KDIDO on d.C101 equals k.C1
                                where d.C1.Contains(datoSucIni) && d.C4 == 40 && d.C43 == "N" /*&& (d.C111 <= hoy)*/ && d.C101.Contains(oper) //&& d.C19 != sdestino 
                                orderby (d.C6) descending
                                select new vmCargaCordinadores
                                {
                                    numeroCarga = d.C6,
                                    sucursalOrigen = d.C1,
                                    fechaCierre = d.C111,
                                    horaCierre = d.C112,
                                    destino = d.C103,
                                    referencia = d.C11

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

        public vmTOperacion ObtieneInfoparaCargasActivas(string datoSucIni, string entrada)
        {
            //string codigo = datoSucIni.Trim() + "-UD4001-" + carga.ToString("D7");
            DateTime hoy = DateTime.Now;
            try
            {
                var lst2 = new vmTOperacion();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDM1
                                join k in modelo.KDIDO on d.C101 equals k.C1
                                where d.C1.Contains(datoSucIni) && d.C4 == 35 && d.C6 == entrada
                                orderby (d.C6) descending
                                select new vmTOperacion
                                {
                                    c1 = k.C1,
                                    c2 = k.C2,


                                };
                    lst2 = lista.FirstOrDefault();
                }

                return lst2;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Obtiene algunos datos para la ventada de coordinadores
        /// </summary>
        public vmInfoControlCors valoresObtiene(string origen, string entrada)
        {
            DateTime Hoy = DateTime.Now;
            DateTime fc = fecharestada();



            try
            {
                var lst = new vmInfoControlCors();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = (from d in modelo.KDM1
                                     //join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                     //join a in modelo.KDUV on k.C12 equals a.C2
                                     //join u in modelo.KDUSUARIOS on a.C22 equals u.C1

                                 where d.C1.Contains(origen) && d.C6.Contains(entrada)


                                 select new vmInfoControlCors
                                 {

                                     valFact = d.C102,
                                     valArn = d.C16.ToString(),

                                 });
                    lst = lista.FirstOrDefault();
                }

                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }




        private DateTime fecharestada()
        {
            int NumeroDias = 800;
            DateTime Hoy = DateTime.Now;
            DateTime FechaRestada = Hoy.AddDays(-NumeroDias);
            return FechaRestada;
        }

        public List<vmCargaCordinadores> ObtieneCargasDeEntrega(string datoSucIni, string oper)
        {
            //string codigo = datoSucIni.Trim() + "-UD4001-" + carga.ToString("D7");
            DateTime hoy = DateTime.Now;
            int hora = DateTime.Now.Hour;

            try
            {
                var lst2 = new List<vmCargaCordinadores>();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDM1
                                   
                                where d.C1.Contains(datoSucIni) && d.C4 == 40 && d.C43 == "N"  && d.C101.Contains(oper) 
                                orderby (d.C6) descending
                                select new vmCargaCordinadores
                                {
                                    numeroCarga = d.C6,
                                    sucursalOrigen = d.C1,
                                    fechaCierre = d.C111,
                                    horaCierre = d.C112,
                                    destino = d.C103,
                                    referencia = d.C11

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

    }
}
