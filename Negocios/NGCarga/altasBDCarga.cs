using Datos.Datosenti;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using Datos.ViewModels.Carga;
using System.Collections.ObjectModel;
using Datos.ViewModels.Entradas;

namespace Negocios.NGCarga
{
    public class altasBDCarga
    {
        public void AltaOrdCarga(string datoSucIni,
            string datoOrdCarga,
            DateTime datoFechaAlta,
            string datoOperacion,
            string datoSucDest,
            string datoMoneda,
            double datoParidad,
            string datoRefe,
            DateTime datoFCorte,
            string datoHora)
        {

            using (modelo2Entities modelo = new modelo2Entities())
            {
                try
                {
                    var d = new KDM1();
                    d.C1 = datoSucIni;
                    d.C2 = "U";
                    d.C3 = "D";
                    d.C4 = 40;
                    d.C5 = 1;
                    d.C6 = datoOrdCarga;
                    d.C7 = datoMoneda;
                    d.C8 = 1;
                    d.C9 = datoFechaAlta;
                    d.C11 = datoRefe;
                    d.C18 = datoFechaAlta;
                    d.C30 = "Ord";
                    d.C40 = datoParidad;
                    d.C43 = "N";
                    d.C63 = "PD-";
                    d.C67 = Common.Cache.CacheLogin.username.ToString().Trim();
                    d.C68 = datoFechaAlta;
                    d.C101 = datoOperacion;
                    d.C103 = datoSucDest;
                    d.C111 = datoFCorte;
                    d.C112 = datoHora;
                    modelo.KDM1.Add(d);
                    modelo.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "altasBDCargas.cs, AltaOrdCarga()... " + datoOrdCarga + "");
                    throw;
                }

            }
        }





        public void ModificaOrdCarga(string datoSucIni,
            string datoOrdCarga,
            DateTime datoFechaAlta,
            string datoOperacion,
            string datoSucDest,
            string datoMoneda,
            double datoParidad,
            string datoRefe,
            DateTime datoFCorte,
            string datoHora)
        {

            using (modelo2Entities modelo = new modelo2Entities())
            {
                try
                {
                    var d = (from q in modelo.KDM1
                             where q.C1.Contains(datoSucIni) && q.C6.Contains(datoOrdCarga) && q.C4 == 40
                             select q).First();


                    d.C7 = datoMoneda;


                    d.C11 = datoRefe;


                    d.C40 = datoParidad;

                    d.C67 = Common.Cache.CacheLogin.username.ToString().Trim();

                    d.C101 = datoOperacion;
                    d.C103 = datoSucDest;
                    d.C111 = datoFCorte;
                    d.C112 = datoHora;
                    modelo.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }

                    throw;
                }

            }
        }



        public void CerrarCarga(string datoSucIni,
           string datoOrdCarga)
        {

            using (modelo2Entities modelo = new modelo2Entities())
            {
                try
                {
                    var d = (from q in modelo.KDM1
                             where q.C1.Contains(datoSucIni) && q.C6.Contains(datoOrdCarga) && q.C4 == 40
                             select q).First();


                    d.C43 = "A";

                    modelo.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }

                    throw;
                }

            }


        }

        public async Task CerrarCargaKdment(string etiqueta, string carga)
        {

            using (modelo2Entities modelo = new modelo2Entities())
            {
                try
                {


                    var d = (from q in modelo.KDMENT
                             where q.C9.Contains(etiqueta) && q.C4 == 35
                             select q);

                    foreach (var item in d)
                    {
                        item.C16 = carga;
                    }


                    await modelo.SaveChangesAsync();
                }
                catch (DbEntityValidationException e)
                {
                    throw;
                }

            }


        }

        public void ActualizaSqlIov(string datoSucIni, int modo, string dato)
        {


            string br = "KFUD" + modo + "01." + datoSucIni;
            using (modelo2Entities modelo = new modelo2Entities())
            {

                try
                {
                    modelo.aumentaSQLint(br, modo.ToString().Trim());
                }
                catch (Exception ex)
                {
                    Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "altasBDCargas.cs, ActualizaSqlIov()... " + dato + "");
                    System.Windows.Forms.MessageBox.Show("Ha Ocurrido un error, datos faltantes o incorrectos.");
                }
            }
        }

        public async Task AsignaCargaAEntrada(string datoSucIni, string datoEntrada, string carga,string fecha)
        {

            using (modelo2Entities modelo = new modelo2Entities())
            {
                try
                {
                    var d = (from q in modelo.KDMENT
                             where q.C1.Contains(datoSucIni) && q.C6.Contains(datoEntrada) && q.C4 == 35
                             select q);

                    foreach (var item in d)
                    {
                        item.C54 = carga;
                        item.C71 = fecha;
                    }


                    await modelo.SaveChangesAsync();
                }
                catch (DbEntityValidationException e)
                {
                    Negocios.LOGs.ArsLogs.LogEdit(e.Message, "altasBDCargas.cs, AsignaCargaAEntrada()... " + datoEntrada + "");
                    throw;
                }

            }


        }

        public async Task<bool> AsignaCargaAEntradaEspesifica(List<vmEntradasEnCarga> lista, string carga, string fecha, string tipo = null)
        {
            bool te = true;
            await Task.Run(() =>
            {
            using (modelo2Entities modelo = new modelo2Entities())
            {

                    if (tipo=="09")
                    {
                        foreach (var item in lista)
                        {
                            if (String.IsNullOrWhiteSpace(carga))
                            {
                                return;
                            }
                            try
                            {
                                var dato = (from q in modelo.KDMENT
                                            where q.C9.Contains(item.Etiqueta) && q.C4 == 35
                                            select q).FirstOrDefault();




                                dato.C45 = carga;
                                dato.C61 = fecha;
                                

                                modelo.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "altasBDCargas.cs, AsignaCargaAEntradaEspesifica()... " + item.Etiqueta + "");
                                te = false;
                            }

                        }
                    }
                    else
                    {
                        foreach (var item in lista)
                        {
                            if (String.IsNullOrWhiteSpace(carga))
                            {
                                return;
                            }
                            try
                            {
                                var dato = (from q in modelo.KDMENT
                                            where q.C9.Contains(item.Etiqueta) && q.C4 == 35
                                            select q).FirstOrDefault();




                                dato.C54 = carga;
                                dato.C71 = fecha;
                                /*
                                 foreach (var item in d)
                                 {
                                     item.C54 = carga;
                                     item.C71 = fecha;
                                 }
                                */

                                modelo.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "altasBDCargas.cs, AsignaCargaAEntradaEspesifica()... " + item.Etiqueta + "");
                                te = false;
                            }

                        }

                    }
                       
                        
                        

                }
            });

            return te;


        }


        public async Task<bool> AsignarABill(List<vmEntradasEnCarga> lista, string nBill, string fecha, string aliass, string calle, string colonia, string estado, string zip, string num, string tipo = null)
        {
            bool te = true;
            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {

                    foreach (var item in lista)
                    {
                        if (String.IsNullOrWhiteSpace(nBill))
                        {
                            return;
                        }
                        try
                        {
                            var dato = (from q in modelo.KDMENT
                                        where q.C9.Contains(item.Etiqueta) && q.C4 == 35
                                        select q).FirstOrDefault();




                            dato.C34 = nBill;
                            dato.C77 = fecha;
                            // Uso de la función auxiliar para limitar la longitud de los valores

                            dato.C24 = LimitarLongitud(aliass, 30);
                            dato.C25 = LimitarLongitud(calle, 100);
                            dato.C26 = LimitarLongitud(colonia, 50);
                            dato.C27 = LimitarLongitud(estado, 50);
                            dato.C28 = LimitarLongitud(zip, 10);
                            dato.C29 = LimitarLongitud(num, 20);

                            modelo.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "altasBDCargas.cs, AsignarABill()... " + item.Etiqueta + "    ");



                            if (ex is DbEntityValidationException entityValidationEx)
                            {
                                foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                                {
                                    // Acceder a los Entity Validation Errors
                                    foreach (var validationError in entityValidationError.ValidationErrors)
                                    {
                                        var propertyName = validationError.PropertyName;
                                        var errorMessage = validationError.ErrorMessage;
                                        Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "altasBDCargas.cs, AsignarABill()..." + item.Etiqueta + "    ");
                                    }
                                }
                            }

                            te = false;
                        }

                    }


                }
            });

            return te;


        }
        // Función auxiliar para limitar la longitud de una cadena
        private string LimitarLongitud(string valor, int longitudMaxima)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return valor;
            }

            if (valor.Length > longitudMaxima)
            {
                return valor.Substring(0, longitudMaxima);
            }

            return valor;
        }





        public async Task<bool> LiberaEntradaDeCarga(string dtSucInicio, string dtEntrada, string dtCargaAsignada)
        {
            bool terminado = true;

            if (string.IsNullOrEmpty(dtSucInicio) || string.IsNullOrEmpty(dtEntrada) || string.IsNullOrEmpty(dtCargaAsignada))
            {
                terminado = false;
                return terminado;
            }

            using (modelo2Entities modelo = new modelo2Entities())
            {
                try
                {
                    var entradas = modelo.KDMENT.Where(q => q.C1.Contains(dtSucInicio) && q.C6.Contains(dtEntrada) && q.C54 == dtCargaAsignada);

                    if (entradas.Any())
                    {
                        foreach (var entrada in entradas)
                        {
                            entrada.C54 = null;
                        }

                        await modelo.SaveChangesAsync();
                    }
                }
                catch (DbEntityValidationException e)
                {
                    terminado = false;
                    throw;
                }
            }

            return terminado;
        }



    }
}
