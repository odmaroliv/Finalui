using Datos.Datosenti;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainVentana.Helpers
{
    public static class DbContextHelper
    {
        public static async Task PreloadContextAsync(modelo2Entities context)
        {
            try
            {
                await context.KDMENT.FirstOrDefaultAsync();
                await context.KDM1.FirstOrDefaultAsync();
                await context.KDM1COMEN.FirstOrDefaultAsync();
            }
            catch (Exception)
            {

               
            }
           

        
        }


        public static async Task OpenConnectionAsync(modelo2Entities context)
        {
            var connection = context.Database.Connection;
            if (connection.State == ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }
        }
    }
}
