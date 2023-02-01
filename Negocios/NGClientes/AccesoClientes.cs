using Datos.Datosenti;
using Datos.ViewModels.Coord.Clientes;
using Datos.ViewModels.Entradas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.NGClientes
{
    public class AccesoClientes
    {


        public vmClientesInfo BuscaInfoCliente(string codigo)
        {
            
            try
            {
                var lst2 = new vmClientesInfo();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDUD
                                where d.C2.Contains(codigo) //&& d.C19 != sdestino 
                                select new vmClientesInfo
                                {
                                    C2 = d.C2,
                                    C3 = d.C3,
                                    C4 = d.C4,
                                    C5 = d.C5,
                                    C6 = d.C6,
                                    C7 = d.C7,
                                    C10 = d.C10,
                                    C11 = d.C11,
                                    C12 = d.C12,   
                                    C14 = d.C14,
                                    C27 = d.C27,
                                    C24 = d.C24,
                                    C32 = d.C32,

                                };
                    lst2 = lista.FirstOrDefault();

                }

                return lst2;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public vmAliasInfo BuscaInfoAlias(string codigo)
        {

            try
            {
                var lst2 = new vmAliasInfo();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDUDA
                                where d.C1.Contains(codigo) //&& d.C19 != sdestino 
                                select new vmAliasInfo
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


                                };
                    lst2 = lista.FirstOrDefault();

                }

                return lst2;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<vmAliasInfo> BuscaAliasenCliente(string codigo)
        {

            try
            {
                var lst2 = new List<vmAliasInfo>();

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDUDA
                                where d.C3.Contains(codigo) //&& d.C19 != sdestino 
                                select new vmAliasInfo
                                {
                                    C1 = d.C1,
                                   // C2 = d.C2,
                                    C3 = d.C3,
                                   /* C4 = d.C4,
                                    C5 = d.C5,
                                    C6 = d.C6,
                                    C7 = d.C7,
                                    C8 = d.C8,
                                    C9 = d.C9,
                                    C10 = d.C10,
                                    C11 = d.C11,*/


                                };
                    lst2 = lista.ToList();

                }

                return lst2;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<List<vmZonas>> LLenaZona()
        {

            try
            {
                var lst2 = new List<vmZonas>();
                await Task.Run(() =>
                {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDUK
                                    select new vmZonas
                                    {


                                        C1 = d.C2.Trim(),
                                        C2 = d.C1.Trim(),


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

        public string NumeroCliente()
        {
            try
            {
                string dto = "";
                using (var context = new modelo2Entities())
                {
                    var result = context.Database.SqlQuery<string>("select top 1 c2 from kdud where c2!='contado' and len(c2)=4 and c2!='9999' order by c2 desc").FirstOrDefault();
                    dto = ((Convert.ToInt32(result)) + 1).ToString();
                }
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
