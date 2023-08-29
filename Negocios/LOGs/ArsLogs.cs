using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocios.LOGs
{
    static public class ArsLogs
    {
        static public void LogEdit(string exception, string nota)
        {
            string fecha = DateTime.Now.ToString("dd/MMM/yyy");
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string logPath = Path.Combine(docPath, "LogArsys");

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            string logFile = Path.Combine(logPath, "log.txt");

            // Crear o agregar al archivo de registro
            using (StreamWriter w = File.AppendText(logFile))
            {
                w.WriteLine(fecha + "[ " + nota + " ]" + " : " + exception);
            }

        }

        static public void RutePaht()
        {
          
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string logPath = Path.Combine(docPath, "LogArsys");

            string logFile = Path.Combine(logPath, "log.txt");
            Clipboard.SetText(logFile);

        }

    }
}
