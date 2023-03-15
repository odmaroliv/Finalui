using Datos.Datosenti;
using Datos.ViewModels;
using Datos.ViewModels.Coord;
using Datos.ViewModels.CXC;
using Datos.ViewModels.Entradas;
using Datos.ViewModels.Reportes;
using Datos.ViewModels.Salidas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Negocios.NGReportes
{
    public class ngbdReportes
    {
        /// <summary>
        /// Busca en todo el almacen SD las entradas que aun no han salido y que se pueden indentificar con un coordinador, se interpreta como el inventario actual de SD
        /// </summary>
        public async Task<List<vmSd1Reporte>> sd1(string dato = null)
        {

            try
            {
                var lst = new List<vmSd1Reporte>();
                await Task.Run(() =>
                {

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
                await Task.Run(() =>
                {

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
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        var lista = modelo.KDMENT
                        .Join(modelo.KDM1, d => new { d.C1, d.C4, d.C6 }, k => new { k.C1, k.C4, k.C6 }, (d, k) => new { d, k })
                        .Join(modelo.KDM1COMEN, dk => new { dk.k.C1, dk.k.C4, dk.k.C6 }, a => new { a.C1, a.C4, a.C6 }, (dk, a) => new { dk.d, dk.k, a })
                        .Where(dka => dka.k.C9 <= Hoy && dka.k.C9 >= fc && dka.d.C1.Contains(dato) && dka.d.C19.Contains(dato) && dka.d.C34 == "" && dka.k.C12 == Common.Cache.CacheLogin.idusuario.ToString())
                        .OrderByDescending(dka => dka.d.C6)
                        .Select(dka => new vmInfoControlCors
                        {
                            entrada = dka.d.C6,
                            fechaentrada = dka.d.C69,
                            ordcarga = dka.d.C54,
                            cliente = dka.k.C32,
                            noCli = dka.k.C10,
                            Cotizacion = dka.k.C115,
                            ordapli = dka.d.C16,
                            salida = dka.d.C17,
                            SucursalInicio = dka.d.C1,
                            valFact = dka.k.C102,
                            valArn = dka.k.C16.ToString(),
                            desc = dka.a.C11,
                            aliss = dka.d.C24,
                        })
                        .ToList();
                        lst = lista;
                    }
                });
                /*await Task.Run(() =>
                {

                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = (from d in modelo.KDMENT
                                     join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                     join a in modelo.KDM1COMEN on new { k.C1, k.C4, k.C6 } equals new { a.C1, a.C4, a.C6 }
                                     //join u in modelo.KDUSUARIOS on a.C22 equals u.C1

                                     where (k.C9 <= Hoy && k.C9 >= fc) && d.C1.Contains(dato) && d.C19.Contains(dato) && d.C34 == "" && k.C12.Contains(Common.Cache.CacheLogin.idusuario.ToString())
                                     orderby d.C6 descending

                                     select new vmInfoControlCors
                                     {
                                         entrada = d.C6 != null ? d.C6.Trim() : string.Empty,
                                         fechaentrada = d.C69 != null ? d.C69.Trim() : string.Empty,
                                         ordcarga = d.C54 != null ? d.C54.Trim() : string.Empty,
                                         cliente = k.C32 != null ? k.C32.Trim() : string.Empty,
                                         noCli = k.C10 != null ? k.C10.Trim() : string.Empty,
                                         Cotizacion = k.C116 != null ? k.C116.Trim() : string.Empty,
                                         ordapli = d.C16 != null ? d.C16.Trim() : string.Empty,
                                         salida = d.C17 != null ? d.C17.Trim() : string.Empty,
                                         SucursalInicio = d.C1 != null ? d.C1.Trim() : string.Empty,
                                         //etiqueta = d.C9 != null ? d.C9.Trim() : string.Empty,
                                         valFact = k.C102 != null ? k.C102.Trim() : string.Empty,
                                         valArn = k.C16 != null ? k.C16.ToString().Trim() : string.Empty,
                                         desc = a.C11 != null ? a.C11.Trim() : string.Empty,
                                         aliss = d.C24 != null ? d.C24.Trim() : string.Empty,
                                     });
                        lst = lista.ToList();
                    }
                });*/
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<vmEntCordsCot>> CargaEntToCot(string dato, string nuCliente) //dato = sucursal de origen
        {
            DateTime Hoy = DateTime.Now;
            DateTime fc = fecharestada();



            try
            {
                var lst = new List<vmEntCordsCot>();
                await Task.Run(() =>
                {

                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = (from d in modelo.KDMENT
                                     join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                     //join a in modelo.KDUV on k.C12 equals a.C2
                                     //join u in modelo.KDUSUARIOS on a.C22 equals u.C1

                                     where d.C1.Contains(dato) && d.C19.Contains(dato) && k.C10 == nuCliente && d.C34 == "" && k.C12.Contains(Common.Cache.CacheLogin.idusuario.ToString())
                                     orderby d.C6 descending

                                     select new vmEntCordsCot
                                     {
                                         entrada = d.C6.Trim(),
                                         // fechaentrada = d.C69.Trim(),
                                         //ordcarga = d.C54.Trim(),
                                         //cliente = k.C32.Trim(),
                                         //ordapli = d.C16.Trim(),
                                         //salida = d.C17.Trim(),
                                         Origen = d.C1,
                                         //etiqueta = d.C9,
                                         valFact = k.C102,
                                         valArn = k.C16.ToString(),

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


        /// <summary>
        /// (SD TO CSL) Reporte Inicial a la hora de entrar al sistema, funciona por coordinador 
        /// </summary>
        public async Task<vmInfoControlCors> CargaControlid(string sOrigen, string entrada)
        {
            DateTime Hoy = DateTime.Now;
            DateTime fc = fecharestada();



            try
            {
                var lst = new vmInfoControlCors();
                await Task.Run(() =>
                {

                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = (from d in modelo.KDMENT
                                     join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                     //join a in modelo.KDUV on k.C12 equals a.C2
                                     //join u in modelo.KDUSUARIOS on a.C22 equals u.C1

                                     where d.C1.Contains(sOrigen) && d.C6.Contains(entrada)
                                     orderby d.C6 descending

                                     select new vmInfoControlCors
                                     {
                                         entrada = d.C6.Trim(),
                                         fechaentrada = d.C69.Trim(),
                                         ordcarga = d.C54.Trim(),
                                         cliente = k.C32.Trim(),
                                         ordapli = d.C16.Trim(),
                                         salida = d.C17.Trim(),
                                         SucursalInicio = d.C1,
                                         //etiqueta = d.C9,
                                         valFact = k.C102,
                                         valArn = k.C16.ToString(),

                                     });
                        lst = lista.FirstOrDefault();
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
            int NumeroDias = 800;
            DateTime Hoy = DateTime.Now;
            DateTime FechaRestada = Hoy.AddDays(-NumeroDias);
            return FechaRestada;
        }


        public async Task<List<vmInicioCXCBd>> CargaControlCXC(string Suc,DateTime f1, DateTime f2)
        {

           
            try
            {
                var lst = new List<vmInicioCXCBd>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        try
                        {
                            //var result = modelo.DatosCXC(f1, f2, Suc).ToList(); // Ejecutar la consulta y convertirla a una lista
                            //var result = modelo.Database.SqlQuery<dynamic>("EXEC DatosCXC @FECHA1, @FECHA2, @SUC", new SqlParameter("@FECHA1", f1), new SqlParameter("@FECHA2", f2), new SqlParameter("@SUC", Suc)).ToList(); // Ejecutar la consulta SQL y convertirla a una lista de objetos dinámicos


                                var query = @"SELECT m.C6 AS Entrada,
                                            MAX(m.C9) AS FechaEntrada,
                                            MAX(m.C1) AS SucursalOrigen,
                                            MAX(m.C115) AS Cotizacion,
                                            MAX(m.C32) AS Cliente,
                                            MAX(m.C112) AS Alias,
                                            MAX(v.C3) AS Cordinador,
                                            MAX(m.C102) AS ValorFactura,
                                            MAX(m.C16) AS ValorArnian,
                                            MAX(k.C34) AS BOL,
                                            MAX(K.C16) AS Carga,
                                            MAX(k.C17) AS Salida,
                                            MAX(k.C46) AS Estatus,
                                            MAX(m.C44) AS EstatusPago,
                                            MAX(c.C13) AS Comentario
                                        FROM KDM1 m
                                        INNER JOIN KDMENT k ON m.C1 = k.C1 AND m.C6 = k.C6 AND m.C4 = k.C4
                                        INNER JOIN KDM1COMEN c ON c.C1 = m.C1 AND c.C6 = m.C6 AND c.C4 = m.C4
                                        INNER JOIN KDUV v ON m.C12 = v.C2
                                        WHERE m.C1 = @SUC AND m.C9 >= @FECHA1 AND m.C9 <= @FECHA2
                                        GROUP BY m.C6
                                        ORDER BY m.C6 DESC";

                            var result = modelo.Database.SqlQuery<vmInicioCXCBd>(
                                                query,
                                                new SqlParameter("@FECHA1", f1),
                                                new SqlParameter("@FECHA2", f2),
                                                new SqlParameter("@SUC", Suc)
                                             
                                            ).ToList();





                            lst = result;
                            /*

                            if (true)
                            {
                                lst = result.Select(r => new vmInicioCXC
                                {
                                    Entrada = r.Entrada,
                                    FechaEnrtada = (DateTime)r.FechaEntrada,
                                    Sucursal = r.SucursalOrigen,
                                    Cotizacion = r.Cotizacion,
                                    Cliente = r.Cliente,
                                    Alias = r.Alias,
                                    Coordinador = r.Cordinador,
                                    ValorFactura = r.ValorFactura.ToString(),
                                    ValorArnia = r.ValorArnian.ToString(),
                                    BOL = r.BOL,
                                    Carga = r.Carga,
                                    Salida = r.Salida,
                                    EstatusAlmacen = r.Estatus,
                                    EstatusPago = r.EstatusPago,
                                    //Comentario = r.Comentario,
                                    
                                  
                                }
                                
                                ).ToList(); // Seleccionar y crear una lista de objetos vmInicioCXC
                        
                            }
                             */
                        }
                        catch (Exception)
                        {
                            System.Windows.Forms.MessageBox.Show("Ha Ocurrido un error, datos faltantes o incorrectos.");
                        }
                    }

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
