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
                //DateTime time = Convert.ToDateTime(dato);
                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDMENT
                                join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                join a in modelo.KDUD on k.C10 equals a.C2
                                where /*d.C10 == "CSL" && d.C23 == "T" &&*/ d.C9 == dato
                                select new VMSalidasBill
                                {
                                    ORIGEN = "",
                                    entrada = d.C1.Trim()+"-"+d.C6,
                                    etiqueta = d.C9,
                                    //DireccionEntrega = d.C24,
                                    Direccion = d.C25.Trim() + ", " + d.C26.Trim() + ", " + d.C27.Trim(),
                                    NOMBREITEM = d.C42.Trim(),
                                    CANTIDAD = "1",
                                    fechamin = fecha,
                                    fechamax = fecha,
                                    //horamin = "08:00",
                                    //  horamax = "17:00",
                                    //  capacidad = "1",
                                    //  servicetime = "20",
                                   
                                    idcontacto = d.C24,
                                    nomcotacto = k.C112,
                                    EMAIL = a.C11,

                                    Telefono = d.C29,
                                    VEHICULO = vehiculo,
                                    

                                };
                    return lista.ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ModificaKDMENTToBill(string etiqueta)
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

                        d.C46 = "BTRACKSALIDA";
                        d.C77 = DateTime.Now.ToString("MM/dd/yyyy");
                       
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
