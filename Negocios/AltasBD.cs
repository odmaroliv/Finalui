using Datos.Datosenti;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ViewModels.Entradas;
using Ventana1.vm;

namespace Negocios
{
    public class AltasBD
    {
        public void agregaKDM1(string sucInicial, string entrada, string Moneda, DateTime fecha, string noCliente,
            string noCord, string valArn, string nomCliente, string calle, string colonia, string ciudadcodigozip, string valFact,
            string paridad, string noTrakin, string provedor, string orCompra, string noFlete, string noUnidades, string tipUnidad, string peso,
            string unidadMedida, string tipOperacion, string sucDestino, string bultos, string Alias, string nota, string referencia)
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
                    if (Moneda == "DLLS") { d.C40 = paridad == "" ? 20 : Convert.ToDouble(paridad); }
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

        public void agregaComentKDM1(string sucEntrada, string codEntrada, string moneda, DateTime fecha, string codCliente, string desc)
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
                        null, null, null, null, null, null, null, null, null, null, null, null, null

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


        public void codeBar(string origen, string entrada, string etiqueta, byte[] barcode)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = new DSBARCODE();

                    d.C1 = origen.Trim();
                    d.C6 = entrada.Trim();
                    d.C9 = etiqueta.Trim();
                    d.BARCODE = barcode;


                    modelo.DSBARCODE.Add(d);

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


        //----------------------------------------------Salidas--------------------------------------------------------------------------


        public async void CSalidaEnKDM1(string c1, string c2, string c3, decimal c4, decimal c5, string c6, decimal c8, DateTime c9, string c11, decimal c16, DateTime c18, string c24
            , string c31, string c43, string c63, string c67, DateTime c68, string c94, string c95, string c96)
        {



            using (modelo2Entities modelo = new modelo2Entities())
            {


                var d = new KDM1();

                d.C1 = c1;
                d.C2 = c2;
                d.C3 = c3;
                d.C4 = c4;
                d.C5 = c5;
                d.C6 = c6;
                d.C8 = c8;
                d.C9 = c9;
                d.C11 = c11;
                d.C16 = c16;
                d.C18 = c18;
                d.C24 = c24;
                d.C31 = c31;
                d.C43 = c43;
                d.C63 = c63;
                d.C67 = c67;
                d.C68 = c68;
                d.C94 = c94;
                d.C95 = c95;
                d.C96 = c96;


                modelo.KDM1.Add(d);
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
        
       /*public async Task<List<List<vmErroresScanSalidas>>> ModifiKDMENTtj(int nrows,string etiq, string salida, string c19, string c20, string c23, string c55, string, string c56, 
           string c63, string c64, string c65, string c66, string c67, string c68, string c75)
        {
            int nm = 0;
            List<vmErroresScanSalidas> lserror = new List<vmErroresScanSalidas>();
            List<vmErroresScanSalidas> lsexito = new List<vmErroresScanSalidas>();
            List<List<vmErroresScanSalidas>> listfinal = new List<List<vmErroresScanSalidas>>();
            await Task.Run(() =>
            {

                using (modelo2Entities modelo = new modelo2Entities())
                {

                    List<KDMENT> kd = new List<KDMENT>();
                    foreach (var q in dgvInicial.Rows)
                    {
                        string msn = dgvInicial.Rows[nm].Cells[0].Value.ToString();



                        string uld = (string)ulDato.Trim().Clone();
                        nm = nm + 1;

                        try
                        {
                            var d = (from fd in modelo.KDMENT
                                     where fd.C9 == msn.Trim()// 
                                     select fd).First();

                            d.C19 = sOrigen;
                            d.C20 = "PR";
                            d.C23 = "";
                            d.C55 = uld;
                            d.C56 = "";

                            d.C63 = uld;
                            d.C64 = uld;
                            d.C65 = "E";
                            d.C66 = "";
                            d.C67 = "";
                            d.C68 = "";
                            d.C75 = DateTime.Now.ToString("dd/MM/yyyy");
                            kd.Add(d);



                            //modelo.SaveChanges();
                            lsexito.Add(new vmErroresScanSalidas { etiqueta = msn, error = "Actualizada con Exito" });

                        }
                        catch (Exception J)
                        {

                            lserror.Add(new vmErroresScanSalidas { etiqueta = msn, error = J.Message.ToString() });

                            continue;

                        }
                        
                       
                    }
                    modelo.BulkUpdate(kd.ToList());
                }
            });

            listfinal.Add(lsexito);
            listfinal.Add(lserror);
            return listfinal.ToList();
        }*/

        
    }





}
