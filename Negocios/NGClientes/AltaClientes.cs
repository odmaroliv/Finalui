using Datos.Datosenti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.NGClientes
{
    public class AltaClientes
    {
        public void CreaCliente(string clave, string nombre, string direccion, string colonia, string poblacion, string zip, string tel, string rfc, string email
            , string coord, string zona, string mailb, string coment = null)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {


                    var d = new KDUD();
                    d.C1 = "01";
                    d.C2 = clave;
                    d.C3 = nombre;
                    d.C4 = direccion;
                    d.C5 = colonia;
                    d.C6 = poblacion;
                    d.C7 = tel;

                    d.C10 = rfc;
                    d.C11 = email;
                    d.C12 = coord;
                    d.C14 = zona;
                    d.C27 = zip;
                    d.C24 = coment;
                    d.C32 = mailb;

                    modelo.KDUD.Add(d);
                    try
                    {
                        modelo.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            catch (Exception e)
            {


                throw;
            }
        }
        public void ModificaCliente(string clave, string nombre, string direccion, string colonia, string poblacion, string zip, string tel, string rfc, string email
              , string coord, string zona, string mailb, string coment = null)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = (from q in modelo.KDUD
                             where q.C2 == clave
                             select q).FirstOrDefault();

                    d.C3 = nombre?.Length > 60 ? nombre.Substring(0, 60).Trim() : nombre?.Trim();
                    d.C4 = direccion?.Length > 40 ? direccion.Substring(0, 40).Trim() : direccion?.Trim();
                    d.C5 = colonia?.Length > 40 ? colonia.Substring(0, 40).Trim() : colonia?.Trim();
                    d.C6 = poblacion?.Length > 40 ? poblacion.Substring(0, 40).Trim() : poblacion?.Trim();
                    d.C7 = tel?.Length > 14 ? tel.Substring(0, 14).Trim() : tel?.Trim();
                    d.C10 = rfc?.Length > 40 ? rfc.Substring(0, 40).Trim() : rfc?.Trim();
                    d.C11 = email?.Length > 450 ? email.Substring(0, 450).Trim() : email?.Trim();
                    d.C12 = coord?.Length > 5 ? coord.Substring(0, 5).Trim() : coord?.Trim();
                    d.C14 = zona?.Length > 5 ? zona.Substring(0, 5).Trim() : zona?.Trim();
                    d.C27 = zip?.Length > 10 ? zip.Substring(0, 10).Trim() : zip?.Trim();
                    d.C24 = coment?.Length > 40 ? coment.Substring(0, 40).Trim() : coment?.Trim();
                    d.C32 = mailb?.Length > 2 ? mailb.Substring(0, 2).Trim() : mailb?.Trim();

                    try
                    {
                        modelo.SaveChanges();
                    }
                    catch (Exception)
                    {
                        //throw;
                    }
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool EliminaCliente(string clave)
        {
            bool eliminado = false;
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = (from q in modelo.KDUD
                             where q.C2 == clave
                             select q).FirstOrDefault();

                    if (d != null)
                    {
                        modelo.KDUD.Remove(d);
                        try
                        {
                            modelo.SaveChanges();
                            eliminado = true;
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                    else
                    {
                        eliminado = false;
                        // El cliente con esa clave no se encontró, maneja este caso como lo desees.
                    }
                }
            }
            catch (Exception e)
            {
                eliminado = false;
                throw;
            }
            return eliminado;
        }


        //---------------------
        public void CreaAlias(string nombre, string keplerCoordenadas, string codigoCliente, string calle, string colonia, string ciudadPais, string zip,
              string nTel, string latitud, string longitud)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = new KDUDA();
                    d.C1 = nombre?.Length > 30 ? nombre.Substring(0, 30) : nombre;
                    d.C3 = codigoCliente?.Length > 20 ? codigoCliente.Substring(0, 20) : codigoCliente;
                    d.C4 = calle?.Length > 100 ? calle.Substring(0, 100) : calle;
                    d.C5 = colonia?.Length > 100 ? colonia.Substring(0, 100) : colonia;
                    d.C6 = ciudadPais?.Length > 100 ? ciudadPais.Substring(0, 100) : ciudadPais;
                    d.C7 = zip?.Length > 20 ? zip.Substring(0, 20) : zip;
                    d.C8 = nTel?.Length > 40 ? nTel.Substring(0, 40) : nTel;
                    d.C10 = latitud?.Length > 30 ? latitud.Substring(0, 30) : latitud;
                    d.C11 = longitud?.Length > 30 ? longitud.Substring(0, 30) : longitud;

                    modelo.KDUDA.Add(d);
                    try
                    {
                        modelo.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void ModificaAlias(string nombre, string keplerCoordenadas, string codigoCliente, string calle, string colonia, string ciudadPais, string zip,
            string nTel, string latitud, string longitud)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {


                    var d = (from q in modelo.KDUDA
                             where q.C1 == nombre && q.C3 == codigoCliente
                             select q).FirstOrDefault();

                   // d.C1 = nombre;
                    //d.C2 = clave;
                    //d.C3 = codigoCliente;
                    d.C4 = calle;
                    d.C5 = colonia;
                    d.C6 = ciudadPais;
                    d.C7 = zip;

                    d.C8 = nTel;
                    d.C10 = latitud;
                    d.C11 = longitud;


                    try
                    {
                        modelo.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            catch (Exception e)
            {


                throw;
            }
        }


    }
}
