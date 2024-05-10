using Datos.Datosenti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.AccesoRecepciones
{
    public class altasRecepciones
    {
        public async Task CRecepcionEnKDM1(string c1, string c2, string c3, decimal c4, decimal c5, string c6, decimal c8, DateTime c9, string c11, decimal c16, DateTime c18, string c24
           , string c31, string c61, string c63, string c67, DateTime c68, string c47)
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
                d.C61 = c61;  //ES EL NUEVO CAMPO PARA ESTUS
                d.C63 = c63;
                d.C67 = c67;
                d.C68 = c68;
                d.C47 = c47;


                modelo.KDM1.Add(d);
                try
                {
                    await modelo.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }



        public async Task ModificaStatusRecepcionSDCSL(string sucursal , string numerosalida, string numerocarga)
        {


            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    List<KDM1> kd = new List<KDM1>();

                    var d = (from fd in modelo.KDM1
                             where /*fd.C103.Contains(sucursal) &&*/ fd.C4 == 45 && fd.C6 == numerocarga //borre la verificacion sobre la sucursal destino ya que aveces la sucursal destino no es deonde se da recepcion 5/10/2024
                             select fd).First();
                    d.C45 = numerosalida;
                    kd.Add(d);

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

        public async Task TerminaRecepcion(string numerosalida, string origen)

        {
            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    List<KDM1> kd = new List<KDM1>();

                    var d = (from fd in modelo.KDM1
                             where fd.C1.Equals(origen) && fd.C4 == 50 && fd.C6 == numerosalida
                             select fd).FirstOrDefault();



                    d.C43 = "A";
                    d.C61 = "";
                    kd.Add(d);

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

    }
}
