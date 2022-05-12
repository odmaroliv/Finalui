using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Datosenti;
using Datos.ViewModels;
using Datos.ViewModels.Entradas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Page;

namespace Negocios
{
    public class validacionesdatos
    {


        PruebasEntities modelo = new PruebasEntities(); //REFERENCIA A LA CONECCION DE BD




        public List<BusquedaInicial> Cargabuscque(string id) //BUSQUEDA RAPIDA POR ENTRADA <Funciona en la pantalla principal Form1>
        {

            try
            {
                using (modelo)
                {

                    var lst = from d in modelo.KDMENT
                              where d.C6.Equals(id)
                              orderby (d.C7)
                              select new BusquedaInicial
                              {
                                  C9 = d.C9.Trim(),
                                  C6 = d.C6.Trim(),
                                  C69 = d.C69.Trim(),
                                  C10 = d.C10.Trim(),
                                  C19 = d.C19.Trim(),
                                  C42 = d.C42.Trim()
                              };
                    return lst.ToList();

                }

            }
            catch (Exception EX)
            {
                MessageBox.Show("Error de coneccion a la base de datos, por favor toma captura de este alert y mandalo a Daniel Lo Antes posible _______________________________" + EX);

                throw;
            }
        }
        public List<Cliente> autocompletar() //Autocomleta el campo de clientes
        {
            {

                try
                {
                    using (modelo)
                    {

                        var lst = from d in modelo.KDUD
                                      //where d.C3.Equals(nombre)
                                      //orderby (d.C7)
                                  select new Cliente
                                  {
                                      C3 = d.C3.Trim(),

                                  };
                        return lst.ToList();

                    }

                }
                catch (Exception EX)
                {
                    MessageBox.Show("Error de coneccion a la base de datos, por favor toma captura de este alert y mandalo a Daniel Lo Antes posible _______________________________" + EX);

                    throw;
                }
            }
        }





        //-------------------------------------------Inicia la validacion de Red ---/>
        bool result = false;

        public bool Test()
        {
            System.Uri Url = new System.Uri("http://www.google.com/");
            System.Net.WebRequest WebRequest;
            WebRequest = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse objResp;
            try
            {
                objResp = WebRequest.GetResponse();
                result = true;
                objResp.Close();
                WebRequest = null;
            }
            catch (Exception)
            {
                result = false;
                WebRequest = null;
            }
            return result;
        }

        //-------------------------------------------Finaliza la validacion de Red ---/>



        public List<vmCordinadores> llenaCord()
        {

            using (modelo)

            {
                var lista = from d in modelo.KDUV
                            select new vmCordinadores
                            {


                                c3 = d.C3


                            };
                return lista.ToList();

            }


        }


        public List<Sucursales> llenaSuc()
        {

            try
            {
                using (PruebasEntities modelo = new PruebasEntities())

                {
                    var lista = from d in modelo.KDMS
                                select new Sucursales
                                {

                                    c1 = d.C1,
                                    c2 = d.C2


                                };
                    return lista.ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            


        }

        public List<Proveedores> llenaProveedores()
        {

            try
            {
                using (PruebasEntities modelo = new PruebasEntities())

                {
                    var lista = from d in modelo.KDXD

                                select new Proveedores
                                {

                                    c2 = d.C2.Trim(),
                                    c3 = d.C3.Trim()


                                };
                    return lista.ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Clientes> llenaClientes()
        {
            try
            {
                using (PruebasEntities modelo = new PruebasEntities())

                {
                    var lista = from d in modelo.KDUD

                                select new Clientes
                                {

                                    c2 = d.C2,
                                    c3 = d.C3.Trim()


                                };
                    return lista.ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Alias> llenaAlias()
        {
            try
            {
                using (PruebasEntities modelo = new PruebasEntities())

                {
                    var lista = from d in modelo.KDUDA

                                select new Alias
                                {

                                    c1 = d.C1.Trim(),
                                    c3 = d.C3


                                };
                    return lista.ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }




    }
}
