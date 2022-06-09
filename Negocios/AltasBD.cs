using Datos.Datosenti;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ViewModels.Entradas;

namespace Negocios
{
    public class AltasBD
    {
       public void agregaKDM1(string sucInicial,string entrada, string Moneda, DateTime fecha, string noCliente, 
           string noCord, string valArn, string nomCliente, string calle,string colonia, string ciudadcodigozip, string valFact,
           string paridad,string noTrakin, string provedor, string orCompra,string noFlete, string noUnidades, string tipUnidad, string peso,
           string unidadMedida,string tipOperacion, string sucDestino, string bultos, string Alias, string nota, string referencia)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = new KDM1();
                    d.C1 = sucInicial.Trim();
                    d.C2 = "U";
                    d.C3 = "D";
                    d.C4 = 35;
                    d.C5 = 1;
                    d.C6 = entrada;
                    d.C7 = Moneda;
                    d.C8 = 1;//ALMACEN 
                    d.C9 = fecha;
                    d.C10 = noCliente;
                    d.C11 = referencia;
                    d.C12 = noCord;
                    d.C16 = valArn == "" ? 1 : Convert.ToDecimal(valArn);
                    d.C24 = nota;
                    d.C31 = "Ent";
                    d.C32 = nomCliente;
                    d.C33 = calle;
                    d.C34 = colonia;
                    d.C35 = ciudadcodigozip;
                    if (Moneda == "DLLS"){ d.C40 = paridad == "" ? 20 : Convert.ToDouble(paridad); }
                    d.C41 = fecha;
                    d.C42 = valArn == "" ? 1 : Convert.ToDecimal(valArn);
                    d.C43 = "N";
                    d.C63 = "UD3501-";
                    d.C67 = Common.Cache.CacheLogin.username.ToString().Trim();//Ultimo en modificar la entrada
                    d.C68 = fecha;//fecha de la ultima modificacion
                    d.C69 = fecha.Hour.ToString("HH:mm");//Hora de la ultima modificacion
                    d.C80 = noTrakin; //elaboro
                    d.C81 = Common.Cache.CacheLogin.username.ToString().Trim(); //elaboro
                    d.C92 = provedor;
                    d.C93 = orCompra;
                    d.C95 = noFlete;
                    d.C97 = Convert.ToDecimal(noUnidades);
                    d.C98 = tipUnidad;
                    d.C99 = Convert.ToDecimal(peso);
                    d.C100 = unidadMedida;
                    d.C101 = tipOperacion;
                    d.C102 = valFact;
                    d.C103 = sucDestino.Trim();
                    d.C108 = bultos;
                    d.C112 = Alias.Trim();
                    modelo.KDM1.Add(d);
                    modelo.SaveChanges();
                    
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

        public void agregaComentKDM1(string sucEntrada, string codEntrada, string moneda,DateTime fecha, string codCliente,string desc)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = new KDM1COMEN();
                    d.C1 = sucEntrada.Trim();
                    d.C2 = "U";
                    d.C3 = "D";
                    d.C4 = 35;
                    d.C5 = 1;
                    d.C6 = codEntrada.Trim();
                    d.C7 = moneda;
                    d.C8 = 1;
                    d.C9 = fecha;
                    d.C10 = codCliente.Trim();
                    d.C11 = desc;



                    modelo.KDM1COMEN.Add(d);
                    modelo.SaveChanges();

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

        public void agregaKDMENT(string sucInicio, string folEntrada, string numEtiqueta, string documento, string etiqueta, string sucDestino, string sucActual, string desc, string fecha, 
            int repEspecial, int modo, string proceso) 
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    modelo.AgregaKDMENT(
                        sucInicio,
                        "U",
                        "D",
                        "35",
                        "1",
                        folEntrada,
                        numEtiqueta,
                        documento,
                        etiqueta,
                        sucDestino,
                        sucActual,
                        desc,
                        fecha,
                        "E",
                        "E",
                        "E",
                        "ESPECIAL",
                        "ESPECIAL",
                        "ESPECIAL",
                        "F",
                        repEspecial,
                        modo,
                        proceso,
                        null,null,null,null,null,null,null,null,null,null,null,null,null

                        );
                   



                    
                    modelo.SaveChanges();

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

        public void agregarFotos(List<vmListaFotos> fotos)
        {
            
            try
            {
               
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        var d = new DSIMAGE();
                        foreach (var i in fotos)
                        {
                            d.ENTRADA = i.entrada;
                            d.NOMBRE = i.nombre;
                            d.REALNOMBRE = i.realnombre;
                            d.BYTEDOCUMENTO = i.bytedocumto;
                            d.EXTRA1 = i.sucursal.Trim();
                            d.EXTRA2 = i.tipo.Trim();
                            modelo.DSIMAGE.Add(d);
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

        public void UpdateKDM1(string id, string sucursaldestino, string cord, string notas, string referencia, string pagado, string tipooperacion, string valfact, string valarn)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = (from q in modelo.KDM1
                             where q.C6 == id
                             select q).First();
                    d.C103 = sucursaldestino.Trim();
                    d.C12 = cord.Trim();
                    d.C24 = notas.Trim();
                    d.C11 = referencia.Trim();
                    d.C44 = pagado.Trim();
                    d.C101 = tipooperacion.Trim();
                    d.C102 = valfact.Trim();
                    d.C16 = Convert.ToDecimal(valarn.Trim());
                    d.C42 = Convert.ToDecimal(valarn.Trim());
                    modelo.SaveChanges();
                    
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
