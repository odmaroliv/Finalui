using Datos.Datosenti;
using Datos.ViewModels.Coord;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.NGCotizacion
{
    public class AltasCotizacion
    {

        public async Task<bool> CreaCotizacionKDM1(string c1, string c6, DateTime c9, string c10, decimal c13, decimal c14, decimal c16, DateTime c18, string c30
            , string c32, string c33, string c34, string c35, float c40, decimal c42, string c43,
            string c67, DateTime c68, string c83, string c84, string c86, string c88, string c89, string c93, string c94, string c24, string pedimento, string tImpresion, String dDescuento)
        {



            using (modelo2Entities modelo = new modelo2Entities())
            {


                var d = new KDM1();

                d.C1  = c1;
                d.C2  = "U";
                d.C3  = "D";
                d.C4  = 34;
                d.C5  = 1; //Tipo de documento [PORCENJATE IVA 16 = 1, 8 = 2, 4 = 3, 0 = 4, ETC]
                d.C6  = c6;
                d.C7  = "DLLS"; //Tipo de moneda
                d.C8  = 1;
                d.C9  = c9;
                d.C10 = c10; //Numero cliente
                d.C13 = c13; //Descuentos   
                d.C14 = c14; //IVA
                d.C16 = c16; //total a pagar arnian
                d.C18 = c18; //fecha alta
                d.C30 = c30; //Tipo de pago /  condicion de pago
                d.C31 = "Cot"; // documento = Cot
                d.C32 = c32; //Nombre cliente
                d.C33 = c33; //Calle cliente
                d.C34 = c34; //Clonia
                d.C35 = c35; //Zip Code
                d.C40 = c40; //Paridad
                d.C42 = c42; //SubTotal
                d.C43 = c43; //Estatus

                d.C67 = c67; // Elaboro
                d.C68 = c68;// fecha de captura
                d.C82 = pedimento;
                d.C83 = c83; //Valor mercancia USD  
                d.C84 = c84; //Valor mercancia MXN
                d.C86 = c86; //Referemcias
                d.C88 = c88; //Valor factura usd mismo c83
                d.C89 = c89; //Valor arnian sin iva ni agregados
                d.C93 = c93;//Total Pesos COMPLETO
                d.C94 = c94;//Total Only taxes


                d.C24 = c24; //Comentarios 

                d.C27 = tImpresion; //Tipo de documento a imprimir
                d.C113 = dDescuento; // descuento


                modelo.KDM1.Add(d);
                try
                {
                    modelo.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "AltasCotizacion.CreaCotizacionKDM1" + c6);

                    if (ex is DbEntityValidationException entityValidationEx)
                    {
                        foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                        {
                            // Acceder a los Entity Validation Errors
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                var propertyName = validationError.PropertyName;
                                var errorMessage = validationError.ErrorMessage;
                                Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AltasCotizacion.CreaCotizacionKDM1" + c6);
                            }
                        }
                    }

                    return false;
                }
            }
        }

        public async Task CreaCotizacionKDM2(string c1, string c6, decimal c7, string c10, decimal c12, decimal c13, string c17, string c25, DateTime c32, string c39)
        {



            using (modelo2Entities modelo = new modelo2Entities())
            {


                var d = new KDM2();

                d.C1  = c1;
                d.C2  = "U";
                d.C3  = "D";
                d.C4  = 34;
                d.C5  = 1;
                d.C6  = c6;
                d.C7  = c7; //Numero de fila
                d.C10 = c10; //Nombre fila
                d.C12 = c12; //Charges MXN 
                d.C13 = c13; //Charges USD  
                d.C17 = c17; //Iva Porcentaje  
                d.C25 = c25; //Clave Cliente 
                d.C32 = c32; //Fecha
                d.C36 = "DLLS"; //Tipo Moneda
                d.C39 = c39; //Porcentaje

                modelo.KDM2.Add(d);
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

        public void ActualizaSqlIov(string datoSucIni, int modo, string dato)
        {


            string br = "KFUD" + modo + "04." + datoSucIni;
            using (modelo2Entities modelo = new modelo2Entities())
            {

                try
                {
                    modelo.aumentaSQLint(br, modo.ToString().Trim());
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Ha Ocurrido un error, datos faltantes o incorrectos.");
                }
            }
        }
        public async Task ModificaKDM1Cotiza(List<vmEntCordsCot> lst, string nCot)
        {


            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    List<KDM1> kd = new List<KDM1>();
                    foreach (var i in lst)
                    {
                        var d = (from fd in modelo.KDM1
                                 where fd.C1.Contains(i.Origen) && fd.C4 == 35 && fd.C6.Contains(i.entrada)
                                 select fd).First();

                        d.C115 = nCot;
                        kd.Add(d);

                    }
                   

                    try
                    {
                        modelo.BulkUpdate(kd.ToList());
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            });
        }
        public void CancelarCotizacion(string SucCoti,
          string NoCotizacion)
        {

            using (modelo2Entities modelo = new modelo2Entities())
            {

                try
                {
                    var d = (from q in modelo.KDM1
                             where q.C1.Contains(SucCoti) && q.C6.Contains(NoCotizacion) && q.C4 == 34
                             select q).First();


                    d.C43 = "C";

                    modelo.SaveChanges();
                }
                catch (Exception e)
                {

                    throw;
                }

            }


        }
        public async Task CancelaCotEnEntradas(List<vmEntCot> lst)
        {


            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    List<KDM1> kd = new List<KDM1>();
                    foreach (var i in lst)
                    {
                        var d = (from fd in modelo.KDM1
                                 where fd.C1.Contains(i.sucursal) && fd.C4 == 35 && fd.C6.Contains(i.Entrada)
                                 select fd).First();

                        d.C115 = "";
                        kd.Add(d);

                    }


                    try
                    {
                        modelo.BulkUpdate(kd.ToList());
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            });
        }
        public void PagoCotizacion(string SucCoti,
         string NoCotizacion, string stado)
        {

            using (modelo2Entities modelo = new modelo2Entities())
            {
                try
                {
                    var d = (from q in modelo.KDM1
                             where q.C1.Contains(SucCoti) && q.C6.Contains(NoCotizacion) && q.C4 == 34
                             select q).First();


                    d.C44 = stado;

                    modelo.SaveChanges();
                }
                catch (Exception e)
                {

                    throw;
                }

            }


        }
    }
}
