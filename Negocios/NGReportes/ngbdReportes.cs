using Datos.Datosenti;
using Datos.ViewModels;
using Datos.ViewModels.Carga;
using Datos.ViewModels.Configuracion;
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
        public async Task<List<vmInfoControlCors>> CargaControl(string dato, DateTime dateFrom, DateTime to)
        {

            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    IQueryable<vmInfoControlCors> query = null;
                    if (Common.Cache.CacheLogin.master == "1")
                    {
                        query = from d in modelo.KDMENT
                                join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                join a in modelo.KDM1COMEN on new { k.C1, k.C4, k.C6 } equals new { a.C1, a.C4, a.C6 }
                                where k.C9 <= to && k.C9 >= dateFrom && d.C1.Contains(dato) && d.C19.Contains(dato) && d.C34 == "" && k.C4 == 35
                                orderby d.C6 descending
                                select new vmInfoControlCors
                                {
                                    entrada = d.C6,
                                    fechaentrada = d.C69,
                                    ordcarga = d.C54,
                                    cliente = k.C32,
                                    noCli = k.C10,
                                    Cotizacion = k.C115,
                                    ordapli = d.C16,
                                    salida = d.C17,
                                    SucursalInicio = d.C1,
                                    valFact = k.C102,
                                    valArn = k.C16.ToString(),
                                    //desc = a.C11,
                                    aliss = k.C112,
                                };
                    }
                    else
                    {
                        query = from d in modelo.KDMENT
                                join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                join a in modelo.KDM1COMEN on new { k.C1, k.C4, k.C6 } equals new { a.C1, a.C4, a.C6 }
                                where k.C9 <= to && k.C9 >= dateFrom && d.C1.Contains(dato) && d.C19.Contains(dato) && d.C34 == "" && k.C12 == Common.Cache.CacheLogin.idusuario.ToString() && k.C4 == 35
                                orderby d.C6 descending
                                select new vmInfoControlCors
                                {
                                    entrada = d.C6,
                                    fechaentrada = d.C69,
                                    ordcarga = d.C54,
                                    cliente = k.C32,
                                    noCli = k.C10,
                                    Cotizacion = k.C115,
                                    ordapli = d.C16,
                                    salida = d.C17,
                                    SucursalInicio = d.C1,
                                    valFact = k.C102,
                                    valArn = k.C16.ToString(),
                                    desc = a.C11,
                                    aliss = k.C112,
                                };
                    }
                     

                    var result = await query.AsNoTracking().ToListAsync();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// (SD TO CSL) Reporte Inicial a la hora de entrar al sistema, funciona por coordinador 
        /// </summary>
        public async Task<List<CargaCordsGeneral>> CargaEntradasParaAsignarACarga(string dato, DateTime dateFrom, DateTime to, string oper)
        {

            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    IQueryable<CargaCordsGeneral> query = null;
                    if (oper == "09")
                    {

                        if (Common.Cache.CacheLogin.master == "1")
                        {
                            query = from d in modelo.KDMENT
                                    join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                    join a in modelo.KDM1COMEN on new { k.C1, k.C4, k.C6 } equals new { a.C1, a.C4, a.C6 }
                                    where k.C9 <= to && k.C9 >= dateFrom  && d.C19.Contains(dato) && d.C10.Contains(dato) && d.C20 == "F"  && k.C4 == 35 && (k.C115 != "" && k.C115 != null) && (d.C45 == "" || d.C45 == null)
                                    orderby d.C6 descending
                                    select new CargaCordsGeneral
                                    {
                                        bulto = d.C9,
                                        entrada = d.C6,
                                        fechaentrada = d.C69,

                                        cliente = k.C32,
                                        noCli = k.C10,
                                        Cotizacion = k.C115,

                                        SucursalInicio = d.C1,
                                        valFact = k.C102,
                                        valArn = k.C16.ToString(),
                                        desc = a.C11,
                                        aliss = k.C112,
                                    };
                        }
                        else
                        {
                            query = from d in modelo.KDMENT
                                    join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                    join a in modelo.KDM1COMEN on new { k.C1, k.C4, k.C6 } equals new { a.C1, a.C4, a.C6 }
                                    where k.C9 <= to && k.C9 >= dateFrom &&  d.C19.Contains(dato) && d.C10.Contains(dato) && d.C20 == "F" && k.C4 == 35 && (k.C115 != "" && k.C115 != null) && (d.C45 == "" || d.C45 == null) && k.C12 == Common.Cache.CacheLogin.idusuario.ToString() 
                                    orderby d.C6 descending
                                    select new CargaCordsGeneral
                                    {
                                        bulto = d.C9,
                                        entrada = d.C6,
                                        fechaentrada = d.C69,

                                        cliente = k.C32,
                                        noCli = k.C10,
                                        Cotizacion = k.C115,

                                        SucursalInicio = d.C1,
                                        valFact = k.C102,
                                        valArn = k.C16.ToString(),
                                        desc = a.C11,
                                        aliss = k.C112,
                                    };
                        }
                    }
                    else
                    {
                        if (Common.Cache.CacheLogin.master == "1")
                        {
                            query = from d in modelo.KDMENT
                                    join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                    join a in modelo.KDM1COMEN on new { k.C1, k.C4, k.C6 } equals new { a.C1, a.C4, a.C6 }
                                    where k.C9 <= to && k.C9 >= dateFrom && d.C1.Contains(dato) && d.C19.Contains(dato) && d.C34 == "" && k.C4 == 35 && k.C101.Contains(oper) && (d.C16 == "" || d.C16 == null) && (d.C54 == "" || d.C54 == null)
                                    orderby d.C6 descending
                                    select new CargaCordsGeneral
                                    {
                                        bulto = d.C9,
                                        entrada = d.C6,
                                        fechaentrada = d.C69,

                                        cliente = k.C32,
                                        noCli = k.C10,
                                        Cotizacion = k.C115,

                                        SucursalInicio = d.C1,
                                        valFact = k.C102,
                                        valArn = k.C16.ToString(),
                                        desc = a.C11,
                                        aliss = k.C112,
                                    };
                        }
                        else
                        {
                            query = from d in modelo.KDMENT
                                    join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                    join a in modelo.KDM1COMEN on new { k.C1, k.C4, k.C6 } equals new { a.C1, a.C4, a.C6 }
                                    where k.C9 <= to && k.C9 >= dateFrom && d.C1.Contains(dato) && d.C19.Contains(dato) && d.C34 == "" && k.C12 == Common.Cache.CacheLogin.idusuario.ToString() && k.C4 == 35 && k.C101.Contains(oper) && (d.C16 == "" || d.C16 == null) && (d.C54 == "" || d.C54 == null)
                                    orderby d.C6 descending
                                    select new CargaCordsGeneral
                                    {
                                        bulto = d.C9,
                                        entrada = d.C6,
                                        fechaentrada = d.C69,

                                        cliente = k.C32,
                                        noCli = k.C10,
                                        Cotizacion = k.C115,

                                        SucursalInicio = d.C1,
                                        valFact = k.C102,
                                        valArn = k.C16.ToString(),
                                        desc = a.C11,
                                        aliss = k.C112,
                                    };
                        }
                    }
                    


                    var result = await query.AsNoTracking().ToListAsync();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Carga clientes sin Id 
        /// </summary>
        public async Task<List<vmInfoControlCors>> CargaControlSinId(string dato, DateTime dateFrom, DateTime to)
        {

            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var query = from d in modelo.KDMENT
                                join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                join a in modelo.KDM1COMEN on new { k.C1, k.C4, k.C6 } equals new { a.C1, a.C4, a.C6 }
                                where k.C9 <= to && k.C9 >= dateFrom && d.C34 == "" && k.C10 == "9999" && k.C4 == 35
                                orderby d.C6 descending
                                select new vmInfoControlCors
                                {
                                    entrada = d.C6,
                                    fechaentrada = d.C69,
                                    ordcarga = d.C54,
                                    cliente = k.C32,
                                    noCli = k.C10,
                                    Cotizacion = k.C115,
                                    ordapli = d.C16,
                                    salida = d.C17,
                                    SucursalInicio = d.C1,
                                    valFact = k.C102,
                                    valArn = k.C16.ToString(),
                                    desc = a.C11,
                                    aliss = d.C24,
                                };

                    var result = await query.AsNoTracking().ToListAsync();
                    return result;
                }
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
                        var lista = (from d in modelo.KDMENT.AsNoTracking()
                                     join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                     //join a in modelo.KDUV on k.C12 equals a.C2
                                     //join u in modelo.KDUSUARIOS on a.C22 equals u.C1

                                     where d.C1.Contains(dato) && k.C10 == nuCliente && d.C34 == "" && k.C12.Contains(Common.Cache.CacheLogin.idusuario.ToString()) && (k.C115 == "" || k.C115 == null)
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

                                     }); ;
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
                                     join a in modelo.KDM1COMEN on new { k.C1, k.C4, k.C6 } equals new { a.C1, a.C4, a.C6 }
                                     //join a in modelo.KDUV on k.C12 equals a.C2
                                     //join u in modelo.KDUSUARIOS on a.C22 equals u.C1
                                     join c in modelo.KDUV on k.C12 equals c.C2
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
                                         aliss = d.C24,
                                         Cotizacion = c.C3,
                                         desc = a.C11,
                                         calle = d.C25,
                                         colonia = d.C26,
                                         poblacio = d.C27,
                                         zipcode = d.C28,
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


        public async Task<List<vmInicioCXCBd>> CargaControlCXC(string Suc, DateTime f1, DateTime f2)
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

                            modelo.Database.CommandTimeout = 500;
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
                                            MAX(c.C13) AS Comentario,
                                            MAX(d.C2) AS Operacion
                                        FROM KDM1 m
                                        INNER JOIN KDMENT k ON m.C1 = k.C1 AND m.C6 = k.C6 AND m.C4 = k.C4
                                        INNER JOIN KDM1COMEN c ON c.C1 = m.C1 AND c.C6 = m.C6 AND c.C4 = m.C4
                                        INNER JOIN KDUV v ON m.C12 = v.C2
                                        INNER JOIN KDIDO d ON m.C101 = d.C1
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
        public async Task<object> CargaControlCXCSubconsulta(string sOrigen, decimal dato, string coti)
        {
            try
            {
                object lst = null;
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        var lista = (from d in modelo.KDM1
                                     where d.C1.Contains(sOrigen) && d.C4 == 34 && d.C5 == dato && d.C6.Contains(coti)
                                     select d.C40).FirstOrDefault();
                        lst = lista;
                    }
                });
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<List<KDUSUARIOS>> CargaUsuarios()
        {
            try
            {
                List<KDUSUARIOS> lst = null;
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        var lista = (from d in modelo.KDUSUARIOS
                                         // where d.C1.Contains(sOrigen) && d.C4 == 34 && d.C5 == dato && d.C6.Contains(coti)
                                     select d);
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

        public async Task<UsuarioModelo> CargaUsuarioEsp(string usu)
        {
            try
            {
                UsuarioModelo lst = null;
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        var lista = (from d in modelo.KDUSUARIOS
                                     where d.C1.Contains(usu)
                                     select new UsuarioModelo
                                     {
                                         C1 = d.C1,//usuario
                                         C2 = d.C2,//nombre
                                         C3 = d.C3, //contra
                                         C4 = d.C4,//rol
                                         C9 = d.C9,//correo
                                         C10 = d.C10,//Suc
                                         C12 = d.C12,//cliente
                                         C13 = d.C13, // telefono
                                         C8 = d.C8 // usuario tipo master
                                     }).FirstOrDefault();
                        lst = lista;
                    }
                });
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task GuardarUsuario(UsuarioModelo usuario)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        // Crear una nueva instancia de KDUSUARIOS y asignar los valores del objeto UsuarioModelo
                        var nuevoUsuario = new KDUSUARIOS
                        {
                            C1 = usuario.C1,   // usuario
                            C2 = usuario.C2,   // nombre
                            C3 = usuario.C3,   // contra
                            C4 = usuario.C4,   // rol
                            C9 = usuario.C9,   // correo
                            C10 = usuario.C10, // Suc
                            C12 = usuario.C12, // cliente
                            C13 = usuario.C13, // telefono
                            C8 = usuario.C8    // Master
                    };

                        // Agregar el nuevo usuario a la base de datos
                        modelo.KDUSUARIOS.Add(nuevoUsuario);
                        modelo.SaveChanges();
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task ActualizarUsuario(string codigoUsuario, UsuarioModelo usuario)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        // Buscar el usuario en la base de datos por el código
                       // var usuarioExistente = modelo.KDUSUARIOS.Where(d => d.C1 == codigoUsuario).FirstOrDefault();
                        var usuarioExistente = (from d in modelo.KDUSUARIOS
                                     where d.C1.Contains(codigoUsuario)
                                     select  d).FirstOrDefault();
                        if (usuarioExistente != null)
                        {
                            // Actualizar los valores del usuario existente con los nuevos valores
                            usuarioExistente.C2 = usuario.C2;   // nombre
                            usuarioExistente.C3 = usuario.C3;   // contra
                            usuarioExistente.C4 = usuario.C4;   // rol
                            usuarioExistente.C9 = usuario.C9;   // correo
                            usuarioExistente.C10 = usuario.C10; // Suc
                            usuarioExistente.C12 = usuario.C12; // cliente
                            usuarioExistente.C13 = usuario.C13; // telefono
                            usuarioExistente.C8 = usuario.C8; // Master

                            modelo.SaveChanges();
                        }
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
