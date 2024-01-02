using Datos.Datosenti;
using Datos.ViewModels.Entradas;
using Datos.ViewModels.Inventario;
using Datos.ViewModels.Recepciones;
using Negocios.LOGs;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.accesoInventario
{
    public class ngAccesoInventario
    {


        public int GeneraFolioInventario(vmInventario dtaInv)
        {
            if (dtaInv == null)
                return 0;
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    Inventario nuevoInventario = new Inventario
                    {
                        IDBodega = dtaInv.IDBodega,
                        RealizadoPor = Common.Cache.CacheLogin.username,
                        FechaInicioInventario = DateTime.Now,
                        SeccionInventario = dtaInv.SeccionInventario,
                        TipoInventario = dtaInv.TipoInventario,
                        Comentario = dtaInv.Comentario,
                        IDEstado = 1,
                    };
                    modelo.Inventario.Add(nuevoInventario);
                    modelo.SaveChanges();
                    GeneralMovimientosLog.AddMovimientoConParametrosDirectos(dtaInv.IDInventario,33,"",33,"",dtaInv.IDBodega,"","","Inicio","","Se inicia el inventario","","","",0,0,"");
                    return nuevoInventario.IDInventario; // IDInventario es el campo autoincrementable
                }
            }
            catch (Exception x) //se retorna 0 en caso de problemas 
            {
                Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Error al intentar generar un nuevo registro para obtener un folio de inventario");
                if (x is DbUnexpectedValidationException dbEntityValidationException)
                {

                }
                if (x is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "ngAccesoInventario, GeneraFolioInventario()...");
                        }
                    }
                }
                return 1;
            }

        }



        public bool CierraInventario(vmInventario dtaInv)
        {
            if (dtaInv == null)
                return false;
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {


                    var d = (from q in modelo.Inventario
                             where q.IDInventario == dtaInv.IDInventario
                             select q).FirstOrDefault();
                    d.CantidadContada = dtaInv.CantidadContada;
                    d.IDResponsableVerificacion = Common.Cache.CacheLogin.username;
                    d.FechaFinalInventario = DateTime.Now;
                    d.Comentario = dtaInv.Comentario;
                    d.IDEstado = 2;

                    modelo.SaveChanges();
                    GeneralMovimientosLog.AddMovimientoConParametrosDirectos(dtaInv.IDInventario, 33, "", 33, "", dtaInv.IDBodega, "", "", "Cierra", "", "Se cierra el inventario", "", "", "", 0, 0, "");

                    return true;
                    //return nuevoInventario.IDInventario; // IDInventario es el campo autoincrementable
                }
            }
            catch (Exception x) //se retorna 0 en caso de problemas 
            {
                Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Error al intentar generar un nuevo registro para obtener un folio de inventario");
                if (x is DbUnexpectedValidationException dbEntityValidationException)
                {

                }
                if (x is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", $"ngAccesoInventario, GeneraFolioInventario()...");
                        }
                    }
                }
                return false;
            }

        }

        public bool CargaFolioEnEtiqueta(vmEntradaInventario entrada, string sucursalInventario)
        {
            if (entrada == null)
                return false;
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {


                    var d = (from q in modelo.KDMENT
                             where q.C9 == entrada.Etiqueta
                             select q).FirstOrDefault();
                    if (d != null)
                    {
                        d.C20 = entrada.ScursalFinal?.Trim() == sucursalInventario ? "F" : "OC";
                        d.IDinventario = entrada.Folio;
                        d.C19 = sucursalInventario;
                        modelo.SaveChanges();
                        GeneralMovimientosLog.AddMovimientoConParametrosDirectos(entrada.Folio, 35, entrada.Etiqueta, 33, "", sucursalInventario, "", "", "Scanea", "", $"Se scanea en el inventario {entrada.Folio}", "", "", "", 0, 0, "");
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception x) //se retorna 0 en caso de problemas 
            {
                Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Error al intentar agregar el folio de inventario a una etiqueta");
                if (x is DbUnexpectedValidationException dbEntityValidationException)
                {

                }
                if (x is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", $"ngAccesoInventario, {nameof(CargaFolioEnEtiqueta)}...");
                        }
                    }
                }
                return false;
            }

        }

        public List<vmFolioPasado> ObtieneFoliosAbiertos(string sucursal)
        {
            var lista = new List<vmFolioPasado>();
            if (String.IsNullOrWhiteSpace(sucursal))
                return lista;
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {


                    var d = (from q in modelo.Inventario
                             where q.IDBodega == sucursal && q.IDEstado == 1
                             select new vmFolioPasado
                             {
                                 Comentario = q.Comentario,
                                 Fecha = q.FechaInicioInventario,
                                 Folio = q.IDInventario
                             });

                    lista = d.ToList();
                    return lista;
                    //return nuevoInventario.IDInventario; // IDInventario es el campo autoincrementable
                }
            }
            catch (Exception x) //se retorna 0 en caso de problemas 
            {
                Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Error al intentar generar un nuevo registro para obtener un folio de inventario");
                if (x is DbUnexpectedValidationException dbEntityValidationException)
                {

                }
                if (x is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", $"ngAccesoInventario, GeneraFolioInventario()...");
                        }
                    }
                }
                return lista;
            }

        }

        public List<vmEntradaInventario> ObtieneEntradasPorFolio(int idInventario)
        {
            var lista = new List<vmEntradaInventario>();

            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {


                    var d = (from q in modelo.KDMENT
                                 //join i in modelo.Inventario on q.IDinventario equals i.IDInventario
                             where q.IDinventario == idInventario
                             select new vmEntradaInventario
                             {
                                 Etiqueta = q.C9,
                                 Folio = q.IDinventario,
                                 ScursalActual = q.C19,
                                 ScursalFinal = q.C10,
                                 
                             });

                    lista = d.ToList();
                    return lista;
                    //return nuevoInventario.IDInventario; // IDInventario es el campo autoincrementable
                }
            }
            catch (Exception x) //se retorna 0 en caso de problemas 
            {
                Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Error al intentar obtener entradas por folio");
                if (x is DbUnexpectedValidationException dbEntityValidationException)
                {

                }
                if (x is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", $"ngAccesoInventario, GeneraFolioInventario()...");
                        }
                    }
                }
                return lista;
            }

        }
        public vmEntradaInventario ObtieneEtiquetaInfo(string etiqueta, int folio)
        {
            var obj = new vmEntradaInventario();

            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {


                    var d = (from q in modelo.KDMENT
                             where q.C9 == etiqueta
                             select new vmEntradaInventario
                             {
                                 Etiqueta = q.C9,
                                 Folio = folio,
                                 ScursalActual = q.C19,
                                 ScursalFinal  = q.C10,
                                 Timestamp = DateTime.Now,

                             });

                    obj = d.FirstOrDefault();
                    return obj;
                    //return nuevoInventario.IDInventario; // IDInventario es el campo autoincrementable
                }
            }
            catch (Exception x) //se retorna 0 en caso de problemas 
            {
                Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Error al intentar obtener informacion de una etiqueta (Inventario)");
                if (x is DbUnexpectedValidationException dbEntityValidationException)
                {

                }
                if (x is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", $"ngAccesoInventario, GeneraFolioInventario()...");
                        }
                    }
                }
                return obj;
            }

        }


    }
}
