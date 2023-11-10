using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Reportes
{
    public class vmHistorialMovimientos
    {
        public int MovimientoID { get; set; }
        public string Folio { get; set; }
        public int TipoFolio { get; set; }
        public string Etiqueta { get; set; }
        public int CodigoTipoMovimiento { get; set; }
        public string NombreTipoMovimiento { get; set; }
        public string DocumentoAnterior { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaHoraMovimiento { get; set; }
        public string UsuarioResponsable { get; set; }
        public string Coordinador { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
        public string IP { get; set; }
        public string DescripcionCorta { get; set; }
    }
}
