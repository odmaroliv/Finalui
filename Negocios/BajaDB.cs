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

        public async Task<bool> BorraEtiquetas(List<string> lst)
        {
            bool b = true;
            try
            {
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        try
                        {
                            foreach (var i in lst)
                            {
                                // Selecciona el registro que cumple con la condición
                                var d = (from q in modelo.KDMENT
                                         where q.C9 == i && q.C4 == 35
                                         select q).FirstOrDefault();

                                if (d != null)
                                {
                                    // Elimina el registro del contexto
                                    modelo.KDMENT.Remove(d);
                                }
                            }

                            // Guarda los cambios en la base de datos para eliminar los registros
                            modelo.SaveChanges();
                            b = true;
                        }
                        catch (Exception)
                        {
                            b = false;
                        }
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }

            return b;
        }

        public async Task ActualizaBultos(string entrada, string sucursalIni, string bultos)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = (from q in modelo.KDM1
                             where q.C1 == sucursalIni && q.C6 == entrada && q.C4 == 35
                             select q).First();

                    d.C108 = bultos.Trim();
                    await modelo.SaveChangesAsync();

                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Ha ocurrido un error, no hemos podido actualizar el valor.");
            }

        }

       /* public async void BorraTodalaEntrada(List<string> lst)
        {

            try
            {

                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        List<KDMENT> kd = new List<KDMENT>();

                        foreach (var i in lst)
                        {
                            var d = (from q in modelo.KDMENT
                                     where q.C9 == i && q.C4 == 35
                                     select q).First();

                            kd.Add(d);

                        }
                        try
                        {
                            modelo.KDMENT.BulkDelete(kd);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        kd.Clear();


                    }
                });


            }
            catch (Exception)
            {

                throw;
            }

        }*/


    }
}
