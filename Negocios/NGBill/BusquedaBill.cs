using Datos.Datosenti;
using Datos.ViewModels.Bill;
using System;
using System.Collections.Generic;
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

                           
                            string rCodigo = (partes != null && partes.Length > 2) ? partes[2] : string.Empty;
                            string rSuc = (partes != null && partes.Length > 0) ? partes[0] : string.Empty;

                            var resultadoSegundaQuery = (from k in modelo.KDM1
                                                         join a in modelo.KDFEMTOCFD on k.C110 equals a.C1
                                                         where k.C4 == 34 && k.C6 == rCodigo && k.C1 == rSuc
                                                         select new { k.C16, a.C2, k.C40 }).FirstOrDefault();

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
                                    idcontacto = x.d.C24,
                                    nomcotacto = x.k.C112,
                                    EMAIL = x.a.C11,
                                    Telefono = x.d.C29,
                                    VEHICULO = vehiculo,
                                    Pago = x.c.C13,
                                    Quote = x.k.C115,
                                    Bill = x.d.C34,
                                    Coordinador = x.v.C3,
                                    TServicio = x.k.C101,
                                    Tpago = string.IsNullOrWhiteSpace(resultadoSegundaQuery.C2) ? string.Empty : resultadoSegundaQuery.C2.ToString(),
                                    CantidaDlls = resultadoSegundaQuery.C16 != null ? resultadoSegundaQuery.C16 : 0,
                                    Paridad = resultadoSegundaQuery.C40 != null ? resultadoSegundaQuery.C40 : 0,
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
                                    idcontacto = x.d.C24,
                                    nomcotacto = x.k.C112,
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

    }


    
}
