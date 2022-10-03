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

        public List<VMSalidasBill> SalidasOperacion(string dato, string fecha)
        {

            try
            {
                //DateTime time = Convert.ToDateTime(dato);
                using (modelo2Entities modelo = new modelo2Entities())

                {
                    var lista = from d in modelo.KDMENT
                                join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                join a in modelo.KDUD on k.C10 equals a.C2
                                where d.C10 == "CSL" && d.C23 == "T" && d.C9 == dato
                                select new VMSalidasBill
                                {
                                    entrada = d.C1.Trim()+"-"+d.C6,
                                    etiqueta = d.C9,
                                    //DireccionEntrega = d.C24,
                                    Direccion = d.C25.Trim() + ", " + d.C26.Trim() + ", " + d.C27.Trim(),
                                    NOMBREITEM = d.C42.Trim(),
                                    CANTIDAD = "1",
                                    fechamin = fecha,
                                    fechamax = fecha,
                                    horamin = "08:00",
                                    horamax = "17:00",
                                    capacidad = "1",
                                    servicetime = "10",
                                   
                                    idcontacto = d.C24,
                                    nomcotacto = "Cliente",
                                    EMAIL = a.C11,

                                    Telefono = d.C29,
                                    ORIGEN = d.C10

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
