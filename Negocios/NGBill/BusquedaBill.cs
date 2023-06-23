using Datos.Datosenti;
using Datos.ViewModels.Bill;
using Datos.ViewModels.Carga;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.NGBill
{
    public class BusquedaBill
    {

        public List<VMSalidasBill> SalidasOperacion(string dato, string fecha, string vehiculo)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var lista = from d in modelo.KDMENT.AsNoTracking()
                                join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                join a in modelo.KDUD on k.C10 equals a.C2
                                join c in modelo.KDM1COMEN on k.C6 equals c.C6
                                join v in modelo.KDUV on k.C12 equals v.C2
                                where d.C9 == dato
                                select new
                                {
                                    d,
                                    k,
                                    a,
                                    c,
                                    v
                                };

                    var resultadoPrimeraConsulta = lista.FirstOrDefault();

                    if (resultadoPrimeraConsulta != null)
                    {

                        try
                        {
                            string[] partes = resultadoPrimeraConsulta.k.C115 != null ? resultadoPrimeraConsulta.k.C115.Split('-') : null;

                          
                            string rCodigo = (partes != null && partes.Length >= 2) ? partes[1].Trim() : string.Empty;
                            string rSuc = (partes != null && partes.Length > 0) ? partes[0] : string.Empty;

                            var resultadoSegundaQuery = (from k in modelo.KDM1.AsNoTracking()
                                                         //join a in modelo.KDFEMTOCFD on k.C30 equals a.C2
                                                         where k.C4 == 34 && k.C6 == rCodigo && k.C1 == rSuc
                                                         select new { k.C16, k.C30, k.C40 }).FirstOrDefault();

                            if (resultadoSegundaQuery != null && partes != null)
                            {
                                return lista.ToList().Select(x => new VMSalidasBill
                                {
                                    ORIGEN = "",
                                    entrada = x.d.C1.Trim() + "-" + x.d.C6,
                                    etiqueta = x.d.C9,
                                    Direccion = x.d.C25.Trim() + ", " + x.d.C26.Trim() + ", " + x.d.C27.Trim(),
                                    NOMBREITEM = x.d.C42.Trim(),
                                    CANTIDAD = "1",
                                    fechamin = fecha,
                                    fechamax = fecha,
                                    idcontacto = x.k.C10,
                                    nomcotacto = x.k.C32,
                                    EMAIL = x.a.C11,
                                    Telefono = x.d.C29,
                                    VEHICULO = vehiculo,
                                    Pago = x.c.C13,
                                    Quote = x.k.C115,
                                    Bill = x.d.C34,
                                    Coordinador = x.v.C3,
                                    TServicio = x.k.C101,
                                    Tpago = string.IsNullOrWhiteSpace(resultadoSegundaQuery.C30) ? string.Empty : resultadoSegundaQuery.C30.ToString(),
                                    CantidaDlls = (decimal)(resultadoSegundaQuery.C16 != null ? resultadoSegundaQuery.C16 : 0),
                                    Paridad = (double)(resultadoSegundaQuery.C40 != null ? resultadoSegundaQuery.C40 : 0),
                                    Alias = string.IsNullOrWhiteSpace(x.d.C24) ? x.k.C112 : x.d.C24,

                                }).ToList();

                            }
                            else
                            {
                                return lista.ToList().Select(x => new VMSalidasBill
                                {
                                    ORIGEN = "",
                                    entrada = x.d.C1.Trim() + "-" + x.d.C6,
                                    etiqueta = x.d.C9,
                                    Direccion = x.d.C25.Trim() + ", " + x.d.C26.Trim() + ", " + x.d.C27.Trim(),
                                    NOMBREITEM = x.d.C42.Trim(),
                                    CANTIDAD = "1",
                                    fechamin = fecha,
                                    fechamax = fecha,
                                    idcontacto = x.k.C10,
                                    nomcotacto = x.k.C32,
                                    EMAIL = x.a.C11,
                                    Telefono = x.d.C29,
                                    VEHICULO = vehiculo,
                                    Pago = x.c.C13,
                                    Quote = x.k.C115,
                                    Bill = x.d.C34,
                                    Coordinador = x.v.C3,
                                    TServicio = x.k.C101,
                                    Tpago = "",
                                    CantidaDlls = 0,
                                    Paridad = 0,
                                    Alias = string.IsNullOrWhiteSpace(x.d.C24) ? x.k.C112 : x.d.C24,
                                }).ToList();
                            }

                        }
                        catch (Exception)
                        {

                            throw;
                        }
                       
                       
                    }
                    else
                    {
                        // Manejo de error si no se encuentra resultado en la primera consulta
                        return new List<VMSalidasBill>();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void RealizarConsultaSinSentido()
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    SalidasOperacion("SD-001235-1", "", "Test");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> ModificaKDMENTToBill(string etiqueta)
        {
            using (modelo2Entities modelo = new modelo2Entities())
            {
                try
                {
                    var d = (from fd in modelo.KDMENT
                             where fd.C9 == etiqueta.ToUpper().Trim()
                             select fd).FirstOrDefault();

                    if (d != null)
                    {
                        d.C46 = "BTRACKSALIDA";
                        d.C77 = DateTime.Now.ToString("MM/dd/yyyy");
                        await modelo.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        Negocios.LOGs.ArsLogs.LogEdit("No se encontró la etiqueta", "BILL sale de arsys a Beetrack" + etiqueta);
                        return false;
                    }
                }
                catch (Exception x)
                {
                    Negocios.LOGs.ArsLogs.LogEdit(x.Message, "BILL sale de arsys a Beetrack" + etiqueta);
                    return false;
                }
            }
        }


        public async Task<bool> ModificaKDMENTToBillBorra(string etiqueta)
        {


            //string sc = sDestino == "CSL" ? "PR" : "OC";
            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    List<Datos.Datosenti.KDMENT> kd = new List<Datos.Datosenti.KDMENT>();


                    //string uld = (string)ulDato.Trim().Clone();

                    try
                    {

                        var d = (from fd in modelo.KDMENT
                                 where fd.C9 == etiqueta.ToUpper().Trim()// 
                                 select fd).First();

                        d.C46 = "";
                        d.C77 = "";
                        kd.Add(d);


                    }
                    catch (Exception x)
                    {

                        Negocios.LOGs.ArsLogs.LogEdit(x.Message, "BILL sale de arsys a Beetrack" + etiqueta);



                    }
                    try
                    {
                        modelo.BulkUpdate(kd.ToList());
                    }
                    catch (Exception x)
                    {
                        Negocios.LOGs.ArsLogs.LogEdit(x.Message, "BILL sale de arsys a Beetrack" + etiqueta);


                    }


                }
            });




            return true;
        }




        public bool AltaBillkdm1(string datoSucIni,
           string datoBill,
           DateTime datoFechaAlta,
        //   string datoOperacion,
          // string datoSucDest,
        //   string datoMoneda,
           //double datoParidad,
           string datoRefe)
           //DateTime datoFCorte,
           //string datoHora)
        {

            using (modelo2Entities modelo = new modelo2Entities())
            {
                try
                {
                    var d = new KDM1();
                    d.C1 = datoSucIni;
                    d.C2 = "U";
                    d.C3 = "D";
                    d.C4 = 55;
                    d.C5 = 1;
                    d.C6 = datoBill;
                   // d.C7 = datoMoneda;
                    d.C8 = 1;
                    d.C9 = datoFechaAlta;
                    d.C11 = datoRefe;
                    d.C18 = datoFechaAlta;
                    d.C30 = "Bill";
                    //d.C40 = datoParidad;
                    d.C43 = "N";
                    d.C63 = "UD5501-";
                    d.C67 = Common.Cache.CacheLogin.username.ToString().Trim();
                    d.C68 = datoFechaAlta;
                    /*d.C101 = datoOperacion;
                    d.C103 = datoSucDest;
                    d.C111 = datoFCorte;
                    d.C112 = datoHora;*/
                    modelo.KDM1.Add(d);
                    modelo.SaveChanges();
                    return true;
                }
                catch (DbEntityValidationException ex)
                {
                    Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "altasBDCargas.cs, AltaOrdCarga()... " + datoBill + "");
                    return false;
                    
                }

            }


        }
        public void ActualizaSqlIov(string datoSucIni, int modo, string dato)
        {


            string br = "KFUD" + modo + "01." + datoSucIni;
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


        public List<vmBillEntradaDoc> EntradasEnBill(string datoSucIni, int carga, string modo = null)
        {
            string codigo = datoSucIni.Trim() + "-UD5501-" + carga.ToString("D7");

            try
            {
                var lst2 = new List<vmBillEntradaDoc>();

                using (modelo2Entities modelo = new modelo2Entities())

                {

                    var lista = (from d in modelo.KDMENT.AsNoTracking()
                                 join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                 where d.C34.Contains(codigo) && k.C4 ==  35 //&& d.C19 != sdestino 
                                 select new vmBillEntradaDoc
                                 {
                                     entrada = d.C6,
                                     etiqueta = d.C9,
                                     desc = d.C42,
                                     oper = k.C101
                                 }).ToList();

                    lst2 = lista.Select((d, index) => new vmBillEntradaDoc
                    {
                        entrada = d.entrada,
                        etiqueta = d.etiqueta,
                        desc = !String.IsNullOrWhiteSpace(d.desc) ? d.desc.Trim() : "",
                        oper = d.oper,
                        nItem = index + 1 // Agregar el número de fila sumando 1 al índice
                    }).ToList();


                }

                return lst2;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<vmInfoBill> InfoEnBill(string entBus, string modo = null)
        {
           // string codigo = datoSucIni.Trim() + "-UD5501-" + carga.ToString("D7");

            try
            {
                var dt = new vmInfoBill();

                using (modelo2Entities modelo = new modelo2Entities())

                {

                      var lista = (from d in modelo.KDMENT
                                    join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                    join a in modelo.KDUV on k.C12 equals a.C2
                                    //join u in modelo.KDUSUARIOS on a.C22 equals u.C1
                                    join s in modelo.KDUD on k.C10 equals s.C2
                                            
                                   

                                 where d.C9 == entBus && k.C4 == 35
                                 select new vmInfoBill
                                 {
                                     toNombre = d.C24,
                                     toCalle = d.C25,
                                     toColonia = d.C26,
                                     toLocalidad = d.C27,
                                     toZip = d.C28,
                                     fromNombre = s.C3,
                                     fromCalle = s.C4,
                                     fromColonia = s.C5,
                                     fromLocalidad = s.C6,
                                     fromZip = s.C27,
                                     telCliente = s.C7,
                                     coord = a.C3,
                                    
                                 });
                    dt = lista.FirstOrDefault();

                }

               return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }
        

    }


    
}
