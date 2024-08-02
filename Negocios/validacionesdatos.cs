using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Datosenti;
using Datos.ViewModels;
using Datos.ViewModels.Carga;
using Datos.ViewModels.Coord.Clientes;
using Datos.ViewModels.Entradas;
using Datos.ViewModels.Reportes;
using Datos.ViewModels.Salidas;
using mainVentana.vmLogin;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Page;

namespace Negocios
{
    public class Servicios
    {


        //REFERENCIA A LA CONECCION DE BD

        public async Task<List<vmHistorialMovimientos>> BuscaHistorialDeMovimientosPorEtiqueta(string folio)
        {
            try
            {
                using (var modelo = new modelo2Entities())
                {
                    var lst = await (from d in modelo.HistorialMovimientos
                                     join t in modelo.TiposMovimiento on  d.CodigoTipoMovimiento equals  t.Codigo
                                     where d.Etiqueta == folio && d.TipoFolio == 35
                                     select new vmHistorialMovimientos
                                     {
                                         MovimientoID = d.MovimientoID,
                                         Folio = d.Etiqueta,
                                         CodigoTipoMovimiento = d.CodigoTipoMovimiento,
                                         Coordinador = d.Coordinador,
                                         DescripcionCorta = d.DescripcionCorta,
                                         Destino = d.Destino,
                                         DocumentoAnterior = d.DocumentoAnterior,
                                         Estado = d.Estado,
                                         Etiqueta = d.Etiqueta,
                                         FechaHoraMovimiento = (DateTime)d.FechaHoraMovimiento,
                                         UsuarioResponsable = d.UsuarioResponsable,
                                         Observaciones = d.Observaciones,
                                         Origen = d.Origen,
                                         TipoFolio = d.TipoFolio,
                                         NombreTipoMovimiento = t.Nombre,

                                     }).ToListAsync();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión a la base de datos: " + ex.Message);
                throw;
            }
        }
        public async Task<List<vmHistorialMovimientos>> BuscaHistorialDeMovimientosPorFolio(int folio, string sucursal)
        {
            try
            {
                using (var modelo = new modelo2Entities())
                {
                    var lst = await(from d in modelo.HistorialMovimientos
                                    join t in modelo.TiposMovimiento on d.CodigoTipoMovimiento equals t.Codigo
                                    where d.Folio == folio && d.TipoFolio == 35 && d.Origen == sucursal && String.IsNullOrEmpty(d.Etiqueta) 
                                    select new vmHistorialMovimientos
                                    {
                                        MovimientoID = d.MovimientoID,
                                        Folio = d.Etiqueta,
                                        CodigoTipoMovimiento = d.CodigoTipoMovimiento,
                                        Coordinador = d.Coordinador,
                                        DescripcionCorta = d.DescripcionCorta,
                                        Destino = d.Destino,
                                        DocumentoAnterior = d.DocumentoAnterior,
                                        Estado = d.Estado,
                                        Etiqueta = d.Etiqueta,
                                        FechaHoraMovimiento = (DateTime)d.FechaHoraMovimiento,
                                        UsuarioResponsable = d.UsuarioResponsable,
                                        Observaciones = d.Observaciones,
                                        Origen = d.Origen,
                                        TipoFolio = d.TipoFolio,
                                        NombreTipoMovimiento = t.Nombre,

                                    }).ToListAsync();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión a la base de datos: " + ex.Message);
                throw;
            }
        }

        public async Task<List<BusquedaInicial>> Cargabuscque(string id, string tipo, DateTime fecha1 = default, DateTime fecha2 = default)
        {
            List<BusquedaInicial> lst = new List<BusquedaInicial>();
            lst.Clear();
            if (tipo == "Ent")
            {
                try
                {
                    using (var modelo = new modelo2Entities())
                    {
                        lst = await (from d in modelo.KDMENT
                                     join k in modelo.KDM1 on new { d.C1, d.C6, d.C4 } equals new { k.C1, k.C6, k.C4 }
                                    // join c in modelo.KDUV on k.C12 equals c.C2
                                     where d.C6 == id
                                     orderby d.C6 descending, d.C7 descending
                                     select new BusquedaInicial
                                     {
                                         
                                         C6 = d.C6.Trim(),
                                         C9 = d.C9.Trim(),
                                         origen = d.C1.Trim(),
                                         C69 = k.C9.ToString(), // se cambia de c69 a k.c9 porque esta fallando la fecha de kdment
                                         C10 = d.C10.Trim(),
                                         C19 = d.C19.Trim(),
                                         cliente = k.C32.Trim(),
                                         cargaasig = d.C54.Trim(),
                                         cafecha = d.C71.Trim(),
                                         cargaapl = d.C16.Trim(),
                                         capfecha = d.C72.Trim(),
                                         osalida = d.C17.Trim(),
                                         osfecha = d.C73.Trim(),
                                        // receptran = d.C18.Trim(),
                                         //receptranfecha = d.C74.Trim(),
                                         receptran = d.C67.Trim(),
                                         receptranfecha = d.C76.Trim(),

                                         saltrans = d.C64.Trim(),
                                         saltransfehcha = d.C75.Trim(),
                                         //repfinal = d.C67.Trim(),
                                         //repfinalfecha = d.C76.Trim(),
                                         repfinal = d.C18.Trim(),
                                         repfinalfecha = d.C74.Trim(),
                                         bill = d.C34.Trim(),
                                         billfecha = d.C77.Trim(),
                                         C42 = d.C42.Trim(),//desc corta
                                         elaborado = k.C81.Trim(),
                                         coord = k.odoosalesp,
                                         link = d.C46,
                                         alias = k.C112,
                                         cot = k.C115,
                                         valArn = k.C16.ToString(),
                                         valFact = k.C102,
                                         tOper = k.C101,
                                         nFlete = k.C95,
                                         ultimamodifi = k.C67,
                                         ultimamodififecha = k.C68 != null ? k.C68.ToString() : null


                                     }).ToListAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión a la base de datos: " + ex.Message);
                    throw;
                }
            }
            else if (tipo == "Flete")
            {
                try
                {
                    using (var modelo = new modelo2Entities())
                    {
                        lst = await (from d in modelo.KDMENT
                                     join k in modelo.KDM1 on new { d.C1, d.C6, d.C4 } equals new { k.C1, k.C6, k.C4 }
                                    // join c in modelo.KDUV on k.C12 equals c.C2
                                     where k.C95.Contains(id)
                                     orderby d.C6 descending, d.C7 descending
                                     select new BusquedaInicial
                                     {
                                         C6 = d.C6.Trim(),
                                         C9 = d.C9.Trim(),
                                         origen = d.C1.Trim(),
                                         C69 = k.C9.ToString(),
                                         C10 = d.C10.Trim(),
                                         C19 = d.C19.Trim(),
                                         cliente = k.C32.Trim(),
                                         cargaasig = d.C54.Trim(),
                                         cafecha = d.C71.Trim(),
                                         cargaapl = d.C16.Trim(),
                                         capfecha = d.C72.Trim(),
                                         osalida = d.C17.Trim(),
                                         osfecha = d.C73.Trim(),
                                         receptran = d.C18.Trim(),
                                         receptranfecha = d.C74.Trim(),
                                         saltrans = d.C64.Trim(),
                                         saltransfehcha = d.C75.Trim(),
                                         repfinal = d.C67.Trim(),
                                         repfinalfecha = d.C76.Trim(),
                                         bill = d.C34.Trim(),
                                         billfecha = d.C77.Trim(),
                                         C42 = d.C42.Trim(),
                                         elaborado = k.C81.Trim(),
                                        // coord = c.C3.Trim(),
                                         link = d.C46,
                                         alias = k.C112,
                                         cot = k.C115,
                                         valArn = k.C16.ToString(),
                                         valFact = k.C102,
                                         tOper = k.C101,
                                         nFlete = k.C95,
                                         ultimamodifi = k.C67,
                                         ultimamodififecha = k.C68 != null ? k.C68.ToString() : null

                                     }).ToListAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión a la base de datos: " + ex.Message);
                    throw;
                }
            }
            else if (tipo == "Cliente")
            {
                try
                {
                    using (var modelo = new modelo2Entities())
                    {

                        lst = await (from d in modelo.KDMENT
                                     join k in modelo.KDM1 on new { d.C1, d.C6, d.C4 } equals new { k.C1, k.C6, k.C4 }
                                    // join c in modelo.KDUV on k.C12 equals c.C2
                                     where k.C9 <= fecha2 && k.C9 >= fecha1 && k.C10.Equals(id)
                                     orderby d.C6 descending, d.C7 descending
                                     select new BusquedaInicial
                                     {
                                         C6 = d.C6.Trim(),
                                         C9 = d.C9.Trim(),
                                         origen = d.C1.Trim(),
                                         C69 = k.C9.ToString(),
                                         C10 = d.C10.Trim(),
                                         C19 = d.C19.Trim(),
                                         cliente = k.C32.Trim(),
                                         cargaasig = d.C54.Trim(),
                                         cafecha = d.C71.Trim(),
                                         cargaapl = d.C16.Trim(),
                                         capfecha = d.C72.Trim(),
                                         osalida = d.C17.Trim(),
                                         osfecha = d.C73.Trim(),
                                         receptran = d.C18.Trim(),
                                         receptranfecha = d.C74.Trim(),
                                         saltrans = d.C64.Trim(),
                                         saltransfehcha = d.C75.Trim(),
                                         repfinal = d.C67.Trim(),
                                         repfinalfecha = d.C76.Trim(),
                                         bill = d.C34.Trim(),
                                         billfecha = d.C77.Trim(),
                                         C42 = d.C42.Trim(),
                                         elaborado = k.C81.Trim(),
                                        // coord = c.C3.Trim(),
                                         link = d.C46,
                                         alias = k.C112,
                                         cot = k.C115,
                                         valArn = k.C16.ToString(),
                                         valFact = k.C102,
                                         tOper = k.C101,
                                         nFlete = k.C95,
                                         ultimamodifi = k.C67,
                                         ultimamodififecha = k.C68 != null ? k.C68.ToString() : null

                                     }).ToListAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión a la base de datos: " + ex.Message);
                    throw;
                }
            }
            else if (tipo == "Usuario")
            {
                try
                {
                    using (var modelo = new modelo2Entities())
                    {
                        modelo.Database.CommandTimeout = 300;
                        lst = await (from d in modelo.KDMENT
                                     join k in modelo.KDM1 on new { d.C1, d.C6, d.C4 } equals new { k.C1, k.C6, k.C4 }
                                    // join c in modelo.KDUV on k.C12 equals c.C2
                                     where k.C9 <= fecha2 && k.C9 >= fecha1 && k.C12 == Common.Cache.CacheLogin.idusuario.ToString()
                                     orderby d.C6 descending, d.C7 descending
                                     select new BusquedaInicial
                                     {
                                         C6 = d.C6.Trim(),
                                         C9 = d.C9.Trim(),
                                         origen = d.C1.Trim(),
                                         C69 = k.C9.ToString(),
                                         C10 = d.C10.Trim(),
                                         C19 = d.C19.Trim(),
                                         cliente = k.C32.Trim(),
                                         cargaasig = d.C54.Trim(),
                                         cafecha = d.C71.Trim(),
                                         cargaapl = d.C16.Trim(),
                                         capfecha = d.C72.Trim(),
                                         osalida = d.C17.Trim(),
                                         osfecha = d.C73.Trim(),
                                         receptran = d.C18.Trim(),
                                         receptranfecha = d.C74.Trim(),
                                         saltrans = d.C64.Trim(),
                                         saltransfehcha = d.C75.Trim(),
                                         repfinal = d.C67.Trim(),
                                         repfinalfecha = d.C76.Trim(),
                                         bill = d.C34.Trim(),
                                         billfecha = d.C77.Trim(),
                                         C42 = d.C42.Trim(),
                                         elaborado = k.C81.Trim(),
                                      //   coord = c.C3.Trim(),
                                         link = d.C46,
                                         alias = k.C112,
                                         cot = k.C115,
                                         valArn = k.C16.ToString(),
                                         valFact = k.C102,
                                         tOper = k.C101,
                                         nFlete = k.C95,
                                         ultimamodifi = k.C67,
                                         ultimamodififecha = k.C68 != null ? k.C68.ToString() : null

                                     }).ToListAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión a la base de datos: " + ex.Message);
                    throw;
                }
            }
            else if (tipo == "SD" || tipo == "TJ" || tipo == "CSL")
            {
                try
                {
                    using (var modelo = new modelo2Entities())
                    {
                        modelo.Database.CommandTimeout = 300;
                        // Construcción base de la consulta
                        var baseQuery = from d in modelo.KDMENT
                                        join k in modelo.KDM1 on new { d.C1, d.C6, d.C4 } equals new { k.C1, k.C6, k.C4 }
                                       // join c in modelo.KDUV on k.C12 equals c.C2
                                        where k.C9 <= fecha2 && k.C9 >= fecha1 && d.C19 == tipo
                                        orderby d.C6 descending, d.C7 descending
                                        select new { d, k };

                        // Aplicar filtro adicional si master no es "1"
                        if (Common.Cache.CacheLogin.master != "1")
                        {
                            baseQuery = baseQuery.Where(item => item.k.C12 == Common.Cache.CacheLogin.idusuario.ToString());
                        }

                        // Seleccionar la proyección final
                        var finalQuery = from item in baseQuery
                                         select new BusquedaInicial
                                         {
                                             C6 = item.d.C6.Trim(),
                                             C9 = item.d.C9.Trim(),
                                             origen = item.d.C1.Trim(),
                                             C69 = item.k.C9.ToString(),
                                             C10 = item.d.C10.Trim(),
                                             C19 = item.d.C19.Trim(),
                                             cliente = item.k.C32.Trim(),
                                             cargaasig = item.d.C54.Trim(),
                                             cafecha = item.d.C71.Trim(),
                                             cargaapl = item.d.C16.Trim(),
                                             capfecha = item.d.C72.Trim(),
                                             osalida = item.d.C17.Trim(),
                                             osfecha = item.d.C73.Trim(),
                                             receptran = item.d.C18.Trim(),
                                             receptranfecha = item.d.C74.Trim(),
                                             saltrans = item.d.C64.Trim(),
                                             saltransfehcha = item.d.C75.Trim(),
                                             repfinal = item.d.C67.Trim(),
                                             repfinalfecha = item.d.C76.Trim(),
                                             bill = item.d.C34.Trim(),
                                             billfecha = item.d.C77.Trim(),
                                             C42 = item.d.C42.Trim(),
                                             elaborado = item.k.C81.Trim(),
                                           //  coord = item.c.C3.Trim(),
                                             link = item.d.C46,
                                             alias = item.k.C112,
                                             cot = item.k.C115,
                                             valArn = item.k.C16.ToString(),
                                             valFact = item.k.C102,
                                             tOper = item.k.C101,
                                             nFlete = item.k.C95,
                                             ultimamodifi = item.k.C67,
                                             ultimamodififecha = item.k.C68 != null ? item.k.C68.ToString() : null

                                         };


                        lst = await finalQuery.ToListAsync();
                       
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión a la base de datos: " + ex.Message);
                    throw;
                }

            }
            else if (tipo == "usrEnt")
            {
                try
                {
                    using (var modelo = new modelo2Entities())
                    {
                        modelo.Database.CommandTimeout = 300;
                        lst = await (from d in modelo.KDMENT
                                     join k in modelo.KDM1 on new { d.C1, d.C6, d.C4 } equals new { k.C1, k.C6, k.C4 }
                                    // join c in modelo.KDUV on k.C12 equals c.C2
                                     where k.C9 <= fecha2 && k.C9 >= fecha1 && (id == "ALL" || k.C81 == id)
                                     orderby d.C6 descending, d.C7 descending
                                     select new BusquedaInicial
                                     {
                                         C6 = d.C6.Trim(),
                                         C9 = d.C9.Trim(),
                                         origen = d.C1.Trim(),
                                         C69 = k.C9.ToString(),
                                         C10 = d.C10.Trim(),
                                         C19 = d.C19.Trim(),
                                         cliente = k.C32.Trim(),
                                         cargaasig = d.C54.Trim(),
                                         cafecha = d.C71.Trim(),
                                         cargaapl = d.C16.Trim(),
                                         capfecha = d.C72.Trim(),
                                         osalida = d.C17.Trim(),
                                         osfecha = d.C73.Trim(),
                                         receptran = d.C18.Trim(),
                                         receptranfecha = d.C74.Trim(),
                                         saltrans = d.C64.Trim(),
                                         saltransfehcha = d.C75.Trim(),
                                         repfinal = d.C67.Trim(),
                                         repfinalfecha = d.C76.Trim(),
                                         bill = d.C34.Trim(),
                                         billfecha = d.C77.Trim(),
                                         C42 = d.C42.Trim(),
                                         elaborado = k.C81.Trim(),
                                      //   coord = c.C3.Trim(),
                                         link = d.C46,
                                         alias = k.C112,
                                         cot = k.C115,
                                         valArn = k.C16.ToString(),
                                         valFact = k.C102,
                                         tOper = k.C101,
                                         nFlete = k.C95
                                     }).ToListAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión a la base de datos: " + ex.Message);
                    throw;
                }
            }
            else if(tipo == "Inventario")
            {
                int folio;
                if (!int.TryParse(id, out folio))
                {
                    // Manejar el caso en que la conversión falla
                    // Por ejemplo, asignar un valor predeterminado o mostrar un mensaje de error
                    folio = 0; // Valor predeterminado en caso de error
                };

                try
                {
                    using (var modelo = new modelo2Entities())
                    {
                        lst = await (from d in modelo.KDMENT
                                     join k in modelo.KDM1 on new { d.C1, d.C6, d.C4 } equals new { k.C1, k.C6, k.C4 }
                                     //join c in modelo.KDUV on k.C12 equals c.C2
                                     where d.IDinventario == folio
                                     orderby d.C6 descending, d.C7 descending
                                     select new BusquedaInicial
                                     {
                                         C6 = d.C6.Trim(),
                                         C9 = d.C9.Trim(),
                                         origen = d.C1.Trim(),
                                         C69 = k.C9.ToString(), // se cambia de c69 a k.c9 porque esta fallando la fecha de kdment
                                         C10 = d.C10.Trim(),
                                         C19 = d.C19.Trim(),
                                         cliente = k.C32.Trim(),
                                         cargaasig = d.C54.Trim(),
                                         cafecha = d.C71.Trim(),
                                         cargaapl = d.C16.Trim(),
                                         capfecha = d.C72.Trim(),
                                         osalida = d.C17.Trim(),
                                         osfecha = d.C73.Trim(),
                                         // receptran = d.C18.Trim(),
                                         //receptranfecha = d.C74.Trim(),
                                         receptran = d.C67.Trim(),
                                         receptranfecha = d.C76.Trim(),

                                         saltrans = d.C64.Trim(),
                                         saltransfehcha = d.C75.Trim(),
                                         //repfinal = d.C67.Trim(),
                                         //repfinalfecha = d.C76.Trim(),
                                         repfinal = d.C18.Trim(),
                                         repfinalfecha = d.C74.Trim(),
                                         bill = d.C34.Trim(),
                                         billfecha = d.C77.Trim(),
                                         C42 = d.C42.Trim(),//desc corta
                                         elaborado = k.C81.Trim(),
                                      //   coord = c.C3.Trim(),
                                         link = d.C46,
                                         alias = k.C112,
                                         cot = k.C115,
                                         valArn = k.C16.ToString(),
                                         valFact = k.C102,
                                         tOper = k.C101,
                                         nFlete = k.C95,
                                         ultimamodifi = k.C67,
                                         ultimamodififecha = k.C68 != null ? k.C68.ToString() : null


                                     }).ToListAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión a la base de datos: " + ex.Message);
                    throw;
                }
            }
            
            return lst;
        }


        public List<Cliente> autocompletar() //Autocomleta el campo de clientes
        {
            {

                try
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {

                        var lst = from d in modelo.KDUD
                                      //where d.C3.Equals(nombre)
                                      //orderby (d.C7)
                                  select new Cliente
                                  {
                                      C3 = d.C3.Trim(),

                                  };
                        return lst.ToList();

                    }

                }
                catch (Exception EX)
                {
                    MessageBox.Show("Error de coneccion a la base de datos, por favor toma captura de este alert y mandalo a Daniel Lo Antes posible _______________________________" + EX);

                    throw;
                }
            }
        }





        //-------------------------------------------Inicia la validacion de Red ---/>
        bool result = false;

        public async Task<bool> Test()
        {
            System.Uri Url = new System.Uri("http://www.google.com/");
            System.Net.WebRequest WebRequest;
            WebRequest = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse objResp;
            try
            {
                objResp = await WebRequest.GetResponseAsync();
                result = true;
                objResp.Close();
                WebRequest = null;
            }
            catch (Exception)
            {
                result = false;
                WebRequest = null;
            }
            return result;
        }



        //-------------------------------------------Finaliza la validacion de Red ---/>



        public async Task<List<vmCordinadores>> llenaCord()
        {

            try
            {
                var lst2 = new List<vmCordinadores>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDUV
                                    select new vmCordinadores
                                    {


                                        c3 = d.C3.Trim(),
                                        c2 = d.C2


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


        public async Task<List<vmEntradaReporteTotales>> llenaUserEntradas()
        {

            try
            {
                var lst2 = new List<vmEntradaReporteTotales>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDUSUARIOS
                                    where d.C4 == "JALMA" || d.C4 == "OENTRA"
                                    select new vmEntradaReporteTotales
                                    {
                                        usuario = d.C1.Trim(),
                                        nombre = d.C2.Trim(),
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


        public async Task<List<vmCordinadores>> llenaCordOLD()
        {

            try
            {
                var lst2 = new List<vmCordinadores>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDUV
                                    select new vmCordinadores
                                    {


                                        c3 = d.C3.Trim(),
                                        c2 = d.C22


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



        public List<Sucursales> llenaSuc()
        {

            try
            {

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDMS
                                select new Sucursales
                                {

                                    c1 = d.C1,
                                    c2 = d.C2,
                                   

                                };
                    return lista.ToList();
                }
            }

            catch (Exception)
            {

                throw;
            }




        }

        public List<vmTipoEntrada> LlenaTiposEnt()
        {

            try
            {

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.TiposDeEntrada
                                select new vmTipoEntrada
                                {
                                    TipoEntradaID = d.TipoEntradaID,
                                    NombreTipoEntrada = d.NombreTipoEntrada,
                                };
                                  
                                
                    return lista.ToList();
                }
            }

            catch (Exception)
            {

                throw;
            }




        }

        public List<SubSucursales> llenaSubSuc(bool esParametro, string suc = null)
        {
            try
            {
                
                int indexSuc = 0;
                if (esParametro)
                {
                    indexSuc = BuscaSucSelect(suc);
                }

                using (modelo2Entities modelo = new modelo2Entities())
                {
                    IQueryable<SubSucursales> query = from d in modelo.SubSucursales
                                                    select d;

                    if (esParametro)
                    {
                        query = query.Where(d => d.KDMSID == indexSuc);
                    }
                    
                    var nd = query.ToList();
                    
                    return nd;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int BuscaSucSelect(string suc)
        {
       

            try
            {

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDMS
                                where d.C1 == suc  
                                select d.IDNumerico;


                    return lista.FirstOrDefault();
              
                }
            }

            catch (Exception)
            {

                throw;
            }




        }

        public List<vmChoferes> llenaChofer()
        {

            try
            {

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDUDCHOF
                                select new vmChoferes
                                {

                                    C1 = d.C1,
                                    C2 = d.C3

                                };
                    return lista.ToList();
                }
            }

            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<Proveedores>> llenaProveedores()
        {

            try
            {
                var lst2 = new List<Proveedores>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDXD

                                    select new Proveedores
                                    {

                                        c2 = d.C2.Trim(),//clave
                                        c3 = d.C3.Trim()//nombre prov


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

        public async Task<List<Clientes>> llenaClientes()
        {
            try
            {
                var lst2 = new List<Clientes>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDUD

                                    select new Clientes
                                    {

                                        c2 = d.C2,
                                        c3 = d.C3.Trim(),
                                        c4 = d.C4.Trim(),
                                        c5 = d.C5.Trim(),
                                        c6 = d.C6.Trim(),
                                        c11 = d.C11.Trim(),
                                        c12 = d.C12.Trim()


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



        public async Task<List<vmClienteDinamicoBusqueda>> LlenaClientesInteractivo(string busqueda, int tipo)
        {
            // tipo 1 clientes, tipo 2 Alias

            var lss = new List<vmClienteDinamicoBusqueda>();
            lss.Clear();
            try
            {
                if (tipo == 1)
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        var lista = await Task.Run(() =>
                        {
                            return from d in modelo.KDUD
                                   where d.C3.Contains(busqueda) || d.C2.Contains(busqueda)
                                   select new vmClienteDinamicoBusqueda
                                   {
                                       C2 = d.C2,
                                       C3 = d.C3.Trim(),
                                       /*c4 = d.C4.Trim(),
                                       c5 = d.C5.Trim(),
                                       c6 = d.C6.Trim(),
                                       c11 = d.C11.Trim(),
                                       c12 = d.C12.Trim()*/
                                   };
                        });

                        lss= lista.ToList();
                    }
                }
                else if (tipo == 2)
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        var lista = await Task.Run(() =>
                        {
                            return from d in modelo.KDUDA
                                   where d.C3.Contains(busqueda) || d.C1.Contains(busqueda)
                                   select new vmClienteDinamicoBusqueda
                                   {
                                       C3 = d.C3.Trim(),
                                       C2 = d.C1,
                                    
                                       /*c4 = d.C4.Trim(),
                                       c5 = d.C5.Trim(),
                                       c6 = d.C6.Trim(),
                                       c11 = d.C11.Trim(),
                                       c12 = d.C12.Trim()*/
                                   };
                        });
                        lss = lista.ToList();

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return lss;
        }



        public async Task<string> BuscarC11(string valorC2)
        {
            if (string.IsNullOrEmpty(valorC2))
            {
              //  Negocios.LOGs.ArsLogs.LogEdit(new Exception x, valorC2);
                return "";
            }

            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var query = from d in modelo.KDUD
                                where d.C2 == valorC2 && !string.IsNullOrEmpty(d.C11)
                                select d.C11;

                    return await query.FirstOrDefaultAsync() ?? "";
                }
            }
            catch (Exception x)
            {
                Negocios.LOGs.ArsLogs.LogEdit(x.Message, valorC2);
                return "";
            }
        }


        public List<Clientes> llenaClientesValida(string numero)
        {
            try
            {

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDUD
                                where d.C2 == numero
                                select new Clientes
                                {

                                    c2 = d.C2,
                                    c3 = d.C3.Trim(),
                                    c4 = d.C4.Trim(),
                                    c5 = d.C5.Trim(),
                                    c6 = d.C6.Trim(),
                                    c11 = d.C11.Trim(),
                                    c12 = d.C12.Trim()


                                };

                    return lista.ToList();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> obtieneCorreoCord(string idUser)
        {
            try
            {
                if (idUser == "")
                {
                    return "";
                }
                if (idUser == "013") //clientes sin identificar
                {
                    return "arniansc@arnian.com";

                }


                string corre = default;
                // var lst2 = new List<Alias>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {

                        var nd = from d in modelo.KDUSUARIOS
                                 join c in modelo.KDUV on d.C1 equals c.C22
                                 where c.C2.Equals(idUser)
                                 select d.C9;

                        corre = nd.FirstOrDefault().ToString();
                    }
                });
                return corre;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Alias>> llenaAlias()
        {
            try
            {
                var lst2 = new List<Alias>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDUDA

                                    select new Alias
                                    {

                                        c1 = d.C1.Trim(),
                                        c3 = d.C3.Trim(),
                                        c4 = d.C4.Trim(),
                                        c5 = d.C5.Trim(),
                                        c6 = d.C6.Trim(),
                                        c7 = d.C7.Trim(),
                                        c8 = d.C8.Trim()


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

        public async Task<List<vmPiezas>> llenaPieza()
        {
            try
            {
                var lst2 = new List<vmPiezas>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDID

                                    select new vmPiezas
                                    {

                                        c1 = d.C1.Trim(),
                                        c2 = d.C2.Trim(),
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

        public async Task<List<vmPeso>> llenaPeso()
        {
            try
            {
                var lst2 = new List<vmPeso>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDIDP

                                    select new vmPeso
                                    {

                                        c1 = d.C1.Trim(),
                                        c2 = d.C2.Trim(),
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

        public async Task<List<vmTOperacion>> llenaOpera()
        {
            try
            {
                var lst2 = new List<vmTOperacion>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDIDO

                                    select new vmTOperacion
                                    {
                                        c1 = d.C1.Trim(),
                                        c2 = d.C2.Trim()
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
        public async Task<List<vmRastreo>> generaRastreo()
        {
            try
            {
                var lst2 = new List<vmRastreo>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.NO_RASTREO(1)

                                    select new vmRastreo
                                    {
                                        c1 = d.rand_number.Trim(),
                                        //c2 = (DateTime)d.fecha_creacion
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

        public async Task<List<vmAlmacenes>> llenaAlmacenes()
        {
            try
            {
                var lst2 = new List<vmAlmacenes>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDMS

                                    select new vmAlmacenes
                                    {
                                        c1 = d.C1.Trim(),
                                        c2 = d.C2.Trim()

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

        public List<vmNumeroEntrada> NumeroEntrada(string datoSucIni, int modo)
        {

            
                string br = "KFUD" + modo + "01." + datoSucIni;
                try
                {
                    var lst2 = new List<vmNumeroEntrada>();

                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.SqlIov
                                    where d.C1.Contains(br) //&& d.C19 != sdestino 
                                    select new vmNumeroEntrada
                                    {
                                        entrada = d.C4
                                    };
                        lst2 = lista.ToList();

                    }

                    return lst2;
                }
                catch (Exception)
                {

                    throw;
                }

            



            /* try
             {

                 using (modelo2Entities modelo = new modelo2Entities())

                 {
                     var lista = from d in modelo.NumeroEntradaMAX(dato, modo)

                                 select new vmNumeroEntrada
                                 {
                                     entrada = d
                                 };
                     return lista.ToList();

                 }


             }
             catch (Exception)
             {

                 throw;
             }*/
        }


        public bool cargalogin(string user, string pass)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var lista = from d in modelo.KDUSUARIOS
                                join v in modelo.KDUV on d.C1 equals v.C22 into fll
                                from fl in fll.DefaultIfEmpty()
                                where d.C1.Equals(user) && d.C3.Equals(pass)
                                select new vmLogin
                                {
                                    idusuario = fl.C2,
                                    username = d.C1.Trim(),
                                    nombre = d.C2.Trim(),
                                    email = d.C9,
                                    numero = d.C13,
                                    rol = d.C4,
                                    sucdefecto = d.C10,
                                    master = d.C8,
                                };
                    var item = lista.FirstOrDefault();
                    if (item != null)
                    {
                        Common.Cache.CacheLogin.username = item.username.Trim();
                        Common.Cache.CacheLogin.nombre = item.nombre.Trim();
                        Common.Cache.CacheLogin.email = item.email.Trim();
                        Common.Cache.CacheLogin.rol = item.rol.Trim();
                        Common.Cache.CacheLogin.sucdefecto = item.sucdefecto.Trim();
                        Common.Cache.CacheLogin.numero = item.numero.Trim();
                        Common.Cache.CacheLogin.idusuario = item.idusuario == null ? "" : item.idusuario.Trim();
                        Common.Cache.CacheLogin.master = item.master == "" ? "0" : item.master.Trim();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Acceso No Autorizado" + e);
                return false;
            }
        }


        public async Task<bool> ObtieneEmail()
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var lista = from d in modelo.SqlIov
                                where d.C1.Contains("EMAIL")
                                select new vmLogin
                                {
                                    smtpemail = d.C4,
                                    smatppss = d.C5,
                                };
                    var lst2 = lista.FirstOrDefault();
                    if (lst2 != null)
                    {
                        Common.Cache.CacheLogin.smtpemail = lst2.smtpemail.Trim();
                        Common.Cache.CacheLogin.smatppss = lst2.smatppss.Trim();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "No se han obtenido resultados para el smtp en la ventana de login");
                return false;
            }
        }

        public async Task<List<vmEntradaListaReporte>> ObtieneEntradasPorUsario(string usr, DateTime fIni, DateTime fFin)
        {
            List<vmEntradaListaReporte> totalList = new List<vmEntradaListaReporte>();
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    // Ajustar fIni para que comience a las 00:00:00
                    var inicio = fIni.Date; // El primer momento del día

                    // Ajustar fFin para incluir todo el último minuto del día
                    var fin = fFin.Date.AddDays(1).AddTicks(-1); // El último momento del día

                    // Consulta para obtener el total de entradas en el rango de fechas ajustado
                    var totalEntradas = await (from d in modelo.KDM1
                                               join d2 in modelo.KDMENT on new { d.C1, d.C4, d.C6 } equals new { d2.C1, d2.C4, d2.C6 }
                                               where d.C81 == usr && d.C9 >= inicio && d.C9 <= fin
                                               select d)
                                              .CountAsync();

                    totalList.Add(new vmEntradaListaReporte
                    {
                        nombre = usr,
                        total = totalEntradas
                    });
                }
                return totalList;
            }
            catch (Exception ex)
            {
                Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "No se han obtenido resultados para el smtp en la ventana de login");
                return totalList;
            }
        }


        public async Task<bool> RingCHook()
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    // Reemplaza la consulta LINQ con una consulta SQL raw
                    string sql = @"SELECT C16 AS rhook FROM SqlIov WHERE C1 LIKE '%RINGCOR%'";
                    var lista = modelo.Database.SqlQuery<vmLogin>(sql).ToList();

                    var lst2 = lista.FirstOrDefault();
                    if (lst2 != null)
                    {
                        Common.Cache.CacheLogin.rhook = lst2.rhook.Trim();
                    }
                    string sql2 = @"SELECT C5 AS bbud, C16 AS bbps FROM SqlIov WHERE C1 LIKE '%lastmillewh%'";
                    var lista2 = modelo.Database.SqlQuery<vmLogin>(sql2).ToList();

                    var lst3 = lista2.FirstOrDefault();
                    if (lst3 != null)
                    {
                        Common.Cache.CacheLogin.bbps = lst3.bbps.Trim();
                        Common.Cache.CacheLogin.bbud = lst3.bbud.Trim();
                    }



                }
                return true;
            }
            catch (Exception ex)
            {
                Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "No se han obtenido resultados para el hook en la ventana de login");
                return false;
            }
        }


        public List<vmEntradaById> LLenaEntradaByID(string id, string sucursal)
        {


            try
            {
                // var lst2 = new List<vmEntradaById>();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDM1
                                join d2 in modelo.KDM1COMEN on new { d.C1, d.C4, d.C6 } equals new { d2.C1, d2.C4, d2.C6 }
                                where d.C1.Equals(sucursal) && d.C4.Equals(35) && d.C6.Equals(id)
                                //orderby (d.C7)
                                select new vmEntradaById
                                {
                                    C1 = d.C1,
                                    C2 = d.C2,
                                    C3 = d.C3,
                                    C4 = d.C4,
                                    C5 = d.C5,
                                    C6 = d.C6,
                                    C7 = d.C7,
                                    C8 = d.C8,
                                    C9 = d.C9,
                                    C10 = d.C10,
                                    C11 = d.C11,
                                    C12 = d.C12,
                                    C16 = d.C16,
                                    C17 = d.C17, //nuevo cliente en odoo
                                    C24 = d.C24,
                                    C27 = d.C27,
                                    C31 = d.C31,
                                    C32 = d.C32,
                                    C33 = d.C33,
                                    C34 = d.C34,
                                    C35 = d.C35,
                                    C40 = d.C40,
                                    C41 = d.C41,
                                    C42 = d.C42,
                                    C43 = d.C43,
                                    C44 = d.C44,
                                    C63 = d.C64,
                                    C67 = d.C67,
                                    C68 = d.C68,
                                    C69 = d.C69,
                                    C80 = d.C80,
                                    C81 = d.C81,
                                    C92 = d.C92,
                                    C93 = d.C93,
                                    C95 = d.C95,
                                    C97 = d.C97,
                                    C98 = d.C98,
                                    C99 = d.C99,
                                    C100 = d.C100,
                                    C101 = d.C101,
                                    C102 = d.C102,
                                    C103 = d.C103,
                                    C108 = d.C108,
                                    C112 = d.C112,
                                    descripcion = d2.C11,
                                    tipoEntrada = d.TipoEntradaID,
                                    OdooId = d.odooidproduct,
                                   odoosalesp = d.odoosalesp


                                };
                    return lista.ToList();

                }


            }
            catch (Exception)
            {

                throw;
            }
        }




        public List<vmEtiquetasReporte> LlenaEtiquetas(string id, string sucursal)
        {


            try
            {

                var lst2 = new List<vmEtiquetasReporte>();
                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDM1
                                join d2 in modelo.KDMENT on new { d.C1, d.C4, d.C6 } equals new { d2.C1, d2.C4, d2.C6 }
                                //join t3 in modelo.KDUD on d.C10 equals t3.C2
                                // join t4 in modelo.KDUK on t3.C14 equals t4.C1
                                where d.C1.Equals(sucursal) && d.C4.Equals(35) && d.C6.Equals(id)
                                orderby (d.C5)
                                select new vmEtiquetasReporte
                                {
                                    Origen = d.C1,
                                    Destino = d.C103,
                                    Cliente = d.C32,
                                    Etiqueta = d2.C9,
                                    Entrada = d2.C6,
                                    Fecha = d.C9,
                                    Alias = d.C112,
                                    NEtiqueta = d2.C7,
                                    //barcode = ""//t3.BARCODE,
                                    Zona = "",//t4.C2,
                                    ZonaNumero = ""//t4.C1,

                                };
                    lst2 = lista.ToList();

                }
                return lst2;

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

                throw;
            }
        }


        public async Task<List<vmEntByCarga>> CargaEntByCarga(string id, string sOrigen)
        {
            if (sOrigen.Contains("TJ"))
            {
                try
                {
                    var lst2 = new List<vmEntByCarga>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())

                        {
                            var lista = from d in modelo.KDMENT

                                        where d.C67.Equals(id) && String.IsNullOrEmpty(d.C64) && d.C19.Contains(sOrigen)
                                        select new vmEntByCarga
                                        {
                                            Etiqueta = d.C9.Trim(),
                                            Carga = d.C67.Trim()

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
                    var lst2 = new List<vmEntByCarga>();
                    await Task.Run(() =>
                    {
                        using (modelo2Entities modelo = new modelo2Entities())

                        {
                            var lista = from d in modelo.KDMENT

                                        where d.C16.Equals(id) //&& String.IsNullOrEmpty(d.C18) && String.IsNullOrEmpty(d.C55)
                                        select new vmEntByCarga
                                        {
                                            Etiqueta = d.C9,
                                            Carga = d.C16


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

        public async Task<List<vmEntByCarga>> CargaEntBySalidaT(string id, string sOrigen, string sdestino)
        {

            try
            {
                var lst2 = new List<vmEntByCarga>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDMENT
                                    where d.C18.Contains(id) //&& d.C19 != sdestino 
                                    select new vmEntByCarga
                                    {
                                        Etiqueta = d.C9,
                                        Carga = d.C18

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

        public async Task<List<vmEtiquetasInfo>> CargaInfoEtiquetas(string id, string sOrigen)
        {

            try
            {
                var lst2 = new List<vmEtiquetasInfo>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDMENT
                                    where d.C6.Contains(id) && d.C4 == 35 && d.C1.Equals(sOrigen) //&& d.C19 != sdestino
                                    orderby d.C7 descending
                                    select new vmEtiquetasInfo
                                    {
                                        nEtiqueta = d.C7,
                                        Etiqueta = d.C9,
                                        Carga = d.C16,
                                        Descripcion = d.C42

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

        public List<Sucursales> LlenaTipoDePago()
        {

            try
            {

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDFEMTOCFD
                                select new Sucursales
                                {

                                    c1 = d.C1,
                                    c2 = d.C2


                                };
                    return lista.ToList();
                }
            }

            catch (Exception)
            {

                throw;
            }




        }


    }
}
