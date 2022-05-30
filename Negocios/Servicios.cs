using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Servicio
    {
         public async Task<string> GetParidad()//obtiene la paridad diaria del diario oficial de la federacion 
        {
            string urlDollar = "https://sidofqa.segob.gob.mx/dof/sidof/indicadores/";
            WebRequest oRequest = WebRequest.Create(urlDollar);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

       
        public async Task<string> fechaLapaz()//obtiene la paridad diaria del diario oficial de la federacion 
        {
            string urlFecha = "http://worldtimeapi.org/api/timezone/America/la_paz/";
            WebRequest oRequest = WebRequest.Create(urlFecha);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public string retornafechaLapaz()//obtiene la paridad diaria del diario oficial de la federacion 
        {
            string urlFecha = "http://worldtimeapi.org/api/timezone/America/la_paz/";
            WebRequest oRequest = WebRequest.Create(urlFecha);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return sr.ReadToEnd();
        }
    }
}
