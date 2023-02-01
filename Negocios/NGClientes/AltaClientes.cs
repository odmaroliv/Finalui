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
            , string coord, string zona, string coment = null)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {


                    var d = new KDUD();

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
        

    }
}
