using Datos.Datosenti;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

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
                catch (Exception)
                {

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
                    throw;
                }

            }


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
