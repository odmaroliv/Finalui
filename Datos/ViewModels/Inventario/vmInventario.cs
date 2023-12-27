using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Inventario
{
    public class vmInventario
    {
        public int IDInventario { get; set; }
       // public DateTime FechaInicioInventario { get; set; }
        public DateTime? FechaFinalInventario { get; set; } // Nullable si la fecha final puede ser nula
        public string IDBodega { get; set; } // Asumiendo que es un string de 5 caracteres
        public string RealizadoPor { get; set; } // Asumiendo que es un ID de empleado o usuario
        public string SeccionInventario { get; set; }
        public string TipoInventario { get; set; }
        public string Comentario { get; set; }
        public int IDEstado { get; set; } // Asumiendo que es un ID de estado
        public int CantidadContada { get; set; }
        public int IDResponsableVerificacion { get; set; }
    }
}
