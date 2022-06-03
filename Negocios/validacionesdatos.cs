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
using mainVentana.vmLogin;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Page;

namespace Negocios
{
    public class Servicios
    {


        modelo2Entities modelo = new modelo2Entities(); //REFERENCIA A LA CONECCION DE BD




        public async Task<List<BusquedaInicial>> Cargabuscque(string id) //BUSQUEDA RAPIDA POR ENTRADA <Funciona en la pantalla principal Form1>
        {

            try
            {
                var lst2 = new List<BusquedaInicial>();
                await Task.Run(() => {
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
                        lst2 = lst.ToList();

                    }

                });
                return lst2;

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



        public async Task<List<vmCordinadores>>  llenaCord()
        {

            try
            {
                var lst2 = new List<vmCordinadores>();
                await Task.Run(() => {
                    using (modelo)

                    {
                        var lista = from d in modelo.KDUV
                                    select new vmCordinadores
                                    {


                                        c3 = d.C3,
                                        c2 = d.C2


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


        public List<Sucursales> llenaSuc()
        {

            try
            {

                using (modelo2Entities modelo = new modelo2Entities())

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
                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDXD

                                select new Proveedores
                                {

                                    c2 = d.C2.Trim(),//clave
                                    c3 = d.C3.Trim()//nombre prov


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
                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDUD

                                select new Clientes
                                {

                                    c2 = d.C2,
                                    c3 = d.C3.Trim(),
                                    c4 = d.C4.Trim(),
                                    c5 = d.C5.Trim(),
                                    c6 = d.C6.Trim(),
                                    c11 = d.C11.Trim(),
                                    c12 = d.C12.Trim()


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
                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDUDA

                                select new Alias
                                {

                                    c1 = d.C1.Trim(),
                                    c3 = d.C3.Trim(),
                                    c4 = d.C4.Trim(),
                                    c5 = d.C5.Trim(), 
                                    c6 = d.C6.Trim(),
                                    c7 = d.C7.Trim(),
                                    c8 = d.C8.Trim()


                                };
                    return lista.ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<vmPiezas>> llenaPieza()
        {
            try
            {
                var lst2 = new List<vmPiezas>();
                await Task.Run(() => {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDID

                                    select new vmPiezas
                                    {

                                        c1 = d.C1.Trim(),
                                        c2 = d.C2.Trim(),
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

        public async Task<List<vmPeso>> llenaPeso()
        {
            try
            {
                var lst2 = new List<vmPeso>();
                await Task.Run(() => {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDIDP

                                    select new vmPeso
                                    {

                                        c1 = d.C1.Trim(),
                                        c2 = d.C2.Trim(),
                                    };
                        lst2= lista.ToList();

                    }
                });
                return lst2;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<vmTOperacion>> llenaOpera()
        {
            try
            {
                var lst2 = new List<vmTOperacion>();
                await Task.Run(() => {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDIDO

                                    select new vmTOperacion
                                    {
                                        c1 = d.C1.Trim(),
                                        c2 = d.C2.Trim()
                                    };
                        lst2= lista.ToList();

                    }
                });
                return lst2;

            }
            catch (Exception)
            {

                throw;
            }


        }
        public async Task<List<vmRastreo>> generaRastreo()
        {
            try
            {
                var lst2 = new List<vmRastreo>();
                await Task.Run(() => {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.NO_RASTREO(1)

                                    select new vmRastreo
                                    {
                                        c1 = d.rand_number.Trim(),
                                        //c2 = (DateTime)d.fecha_creacion
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

        public async Task<List<vmAlmacenes>>  llenaAlmacenes()
        {
            try
            {
                var lst2 = new List<vmAlmacenes>();
                await Task.Run(() => {
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.KDMS

                                    select new vmAlmacenes
                                    {
                                        c1 = d.C1.Trim(),
                                        c2 = d.C2.Trim()

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

        public List<vmNumeroEntrada> NumeroEntrada(string dato)
        {
            try
            {
                
                    using (modelo2Entities modelo = new modelo2Entities())

                    {
                        var lista = from d in modelo.NumeroEntradaMAX(dato)

                                    select new vmNumeroEntrada
                                    {
                                        entrada = d
                                    };
                        return lista.ToList();

                    }
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        
        public bool cargalogin(string user, string pass)
        {
            try
            {

                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.DSUSER
                                where d.LoginName.Equals(user) && d.Password.Equals(pass)
                                select new vmLogin
                                {
                                    //idusuario = d.IdUsuario,
                                    username = d.LoginName.Trim(),
                                    //password = d.Password,
                                    nombre = d.Nombre.Trim(),
                                    apellido = d.Apellido.Trim(),
                                    email = d.Email,
                                    numero = d.Numero,
                                    rol = d.IdRol,
                                    estatus = d.Activo

                                };
                    foreach (var i in lista.ToList())
                    {
                        
                        Common.Cache.CacheLogin.username = i.username;
                        Common.Cache.CacheLogin.nombre = i.nombre;
                        Common.Cache.CacheLogin.apellido = i.apellido;
                        Common.Cache.CacheLogin.email = i.email;
                        Common.Cache.CacheLogin.rol = i.rol;
                        Common.Cache.CacheLogin.estatus = i.estatus;    
                        Common.Cache.CacheLogin.numero = i.numero;
                    }

                    if (lista.ToList().Count() <= 0)
                    {
                        return false; // Query results were empty
                    }
                    else
                    {
                        return true;
                    }



                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
