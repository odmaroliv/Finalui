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
           
            await context.KDMENT.FirstOrDefaultAsync();
            await context.KDM1.FirstOrDefaultAsync();
            await context.KDM1COMEN.FirstOrDefaultAsync();

            // Agrega más consultas para precargar las demás tablas 
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
