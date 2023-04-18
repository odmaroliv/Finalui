using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public partial class ConeccionRed
    {
        //Test de internet
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static async Task<int> TestInternet()
        {
            int error = 0; // 0 no error | 1 error 
            int desc;

            await Task.Run(() =>
            {
                if (InternetGetConnectedState(out desc, 0) == true)
                {
                }
                else
                {
                    error = 1;
                }
            });

            return error;
        }
    }
}
