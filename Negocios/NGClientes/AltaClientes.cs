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
        public void CreaAlias(string nombre, string keplerCoordenadas, string codigoCliente, string calle, string colonia, string ciudadPais,string zip, 
            string nTel, string latitud, string longitud)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {


                    var d = new KDUDA();
                    d.C1 = nombre;
                    //d.C2 = clave;
                    d.C3 = codigoCliente;
                    d.C4 = calle;
                    d.C5 = colonia;
                    d.C6 = ciudadPais;
                    d.C7 = zip;

                    d.C8 = nTel;
                    d.C10 = latitud;
                    d.C11 = longitud;
                  

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
