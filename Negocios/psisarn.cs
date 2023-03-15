using Negocios.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public partial class psisarn
    {

        public void CS(string SN, string CSN, string BD)
        {
            if (String.IsNullOrWhiteSpace(BD))
            {
                BD = "KEPLER4";
            }


            string conn = ConfigurationManager.ConnectionStrings["modelo2Entities"].ConnectionString;

            //string cadema = "metadata=res://*/Datosenti.modeloPrueba.csdl|res://*/Datosenti.modeloPrueba.ssdl|res://*/Datosenti.modeloPrueba.msl;provider=System.Data.SqlClient;provider connection string=';data source=104.198.241.64;initial catalog=KEPLER_PRUEBAS;user id=" + SN + ";password=" + CSN + ";multipleactiveresultsets=True;application name=EntityFramework';";

            string cadema = "metadata=res://*/Datosenti.modeloPrueba.csdl|res://*/Datosenti.modeloPrueba.ssdl|res://*/Datosenti.modeloPrueba.msl;provider=System.Data.SqlClient;provider connection string=';data source=104.198.241.64;initial catalog="+ BD +";user id=" + Negocios.Common.Cache.AccesData.uso + ";password=" + Negocios.Common.Cache.AccesData.psd + ";multipleactiveresultsets=True;application name=EntityFramework';";


            AddOrUpdateAppConnectionStrings("modelo2Entities", cadema);
            

           // conn = ConfigurationManager.ConnectionStrings["modelo2Entities"].ConnectionString;
        }
        public void AddOrUpdateAppConnectionStrings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.ConnectionStrings.ConnectionStrings;
                if (settings[key] == null)
                {
                    settings.Add(new ConnectionStringSettings(key, value));
                }
                else
                {
                    settings[key].ConnectionString = value;
                    settings[key].ProviderName = "System.Data.EntityClient";

                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.ConnectionStrings.SectionInformation.Name);
                Properties.Settings.Default.Reload();
                
                    //propietys
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error al edt el app settings");
            }
        }


        public string modo()
        {
            string connString = ConfigurationManager.ConnectionStrings["modelo2Entities"].ConnectionString;
            int index = connString.IndexOf("initial catalog=") + "initial catalog=".Length;
            string initialCatalog = connString.Substring(index).Split(';')[0];
            return initialCatalog;
        }

    }
}
