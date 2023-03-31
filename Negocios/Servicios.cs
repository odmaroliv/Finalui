using Datos.ViewModels.Servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocios
{
    public class Servicio
    {
         public async Task<string> GetParidad()//obtiene la paridad diaria del diario oficial de la federacion 
        {
            try
            {
                string urlDollar = "https://sidofqa.segob.gob.mx/dof/sidof/indicadores/";
                WebRequest oRequest = WebRequest.Create(urlDollar);
                WebResponse oResponse = oRequest.GetResponse();
                StreamReader sr = new StreamReader(oResponse.GetResponseStream());
                return await sr.ReadToEndAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<string> fechaLapaz()//obtiene la paridad diaria del diario oficial de la federacion 
        {
            /*try
            {
                string urlFecha = "https://worldtimeapi.org/api/timezone/America/la_paz/";
                WebRequest oRequest = WebRequest.Create(urlFecha);
                WebResponse oResponse = oRequest.GetResponse();
                StreamReader sr = new StreamReader(oResponse.GetResponseStream());
                return await sr.ReadToEndAsync();
            }
            catch (Exception)
            {

                throw;
            }*/

            try
            {
                string urlFecha = "https://worldtimeapi.org/api/timezone/America/la_paz/";
                WebRequest oRequest = WebRequest.Create(urlFecha);
                WebResponse oResponse = oRequest.GetResponse();
                StreamReader sr = new StreamReader(oResponse.GetResponseStream());
                string fecha = await sr.ReadToEndAsync();
                return JsonConvert.DeserializeObject<FechaActual>(fecha).datetime.Date.ToString("MM/dd/yyyy");
            }
            catch (Exception)
            {
                // Si se produce una excepción, establecer la fecha en DateTime.Now
                DateTime fechaActual = DateTime.Now;
                return fechaActual.ToString("MM/dd/yyyy");
            }

        }

        public string retornafechaLapaz()//obtiene la paridad diaria del diario oficial de la federacion 
        {
            string urlFecha = "https://worldtimeapi.org/api/timezone/America/la_paz/";
            WebRequest oRequest = WebRequest.Create(urlFecha);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return sr.ReadToEnd();
        }

        public async Task pdfZPL(byte[] zpl,string pathlbl)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://api.labelary.com/v1/printers/8dpmm/labels/4x6/");
            request.Method = "POST";
            request.Accept = "application/pdf"; // omit this line to get PNG images back
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = zpl.Length;

            var requestStream = request.GetRequestStream();
            requestStream.Write(zpl, 0, zpl.Length);
            requestStream.Close();

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseStream = response.GetResponseStream();

               
                string fullFilePath = pathlbl;

                if (File.Exists(fullFilePath))
                    File.Delete(fullFilePath);

                
                var fileStream = File.Create(fullFilePath); // change file name for PNG images
                responseStream.CopyTo(fileStream);
                responseStream.Close();
                fileStream.Close();

                Clipboard.SetText(fullFilePath);
            }
            catch (WebException e)
            {
                Console.WriteLine("Error: {0}", e.Status);
            }
        }



    }
}
