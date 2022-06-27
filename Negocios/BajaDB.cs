using Datos.Datosenti;
using Datos.ViewModels.Entradas;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class BajaDB
    {
        public void Elimina_FotoDoc(string nombre, string tDocto)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var ii = from d in modelo.DSIMAGE
                             where d.NOMBRE == nombre && d.EXTRA2 == tDocto 
                             select d;

                    if (ii.Count() > 0)
                    {
                        var ft = ii.First();
                        modelo.DSIMAGE.Remove(ft);
                        modelo.SaveChanges();
                    }
                   
                  

                }
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



    }
}
