using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Bill
{
    public class VMSalidasBill
    {
        [DisplayName("N° DOCUMENTO")]
        public string entrada { get; set; }

        [DisplayName("VEHICULO")]
        public string VEHICULO { get; set; }


        [DisplayName("NOMBRE ITEM")]
        public string NOMBREITEM { get; set; }


        public string CANTIDAD { get; set; }


        [DisplayName("CODIGO ITEM")]
        public string etiqueta { get; set; }



        [DisplayName("IDENTIFICADOR CONTACTO")]
        public string idcontacto { get; set; }


        [DisplayName("NOMBRE CONTACTO")]
        public string nomcotacto { get; set; }

        [DisplayName("TELEFONO")]
        public string Telefono { get; set; }

        [DisplayName("EMAIL CONTACTO")]
        public string EMAIL { get; set; }


        [DisplayName("DIRECCION")]
        public string Direccion { get; set; }

        public string LATITUD { get; set; }
        public string LONGITUD { get; set; }


        [DisplayName("FECHA MIN ENTREGA")]
        public string fechamin { get; set; }

        [DisplayName("FECHA MAX ENTREGA")]
        public string fechamax { get; set; }


        /*  [DisplayName("MIN VENTANA HORARIA 1")]
          public string horamin { get; set; }

          [DisplayName("MAX VENTANA HORARIA 1")]
          public string horamax { get; set; }

          [DisplayName("MIN VENTANA HORARIA 2")]
          public string horaminn { get; set; }

          [DisplayName("MAX VENTANA HORARIA 2")]
          public string horamaxx { get; set; }

          [DisplayName("COSTO ITEM")]
          public string costoitem { get; set; }

          [DisplayName("CAPACIDAD UNO")]
          public string capacidad { get; set; }

          [DisplayName("CAPACIDAD DOS")]
          public string capacidadd { get; set; }

          [DisplayName("SERVICE TIME")]
          public string servicetime { get; set; }

          [DisplayName("IMPORTANCIA")]
          public string importancia { get; set; }




          */

        [DisplayName("CT ORIGEN")]
        public string ORIGEN { get; set; }



        /// <summary>
        /// otros
        /// </summary>

        [DisplayName("Comentario")]
        public string Pago { get; set; }
        [DisplayName("COTIZACION")]
        public string Quote { get; set; }
        [DisplayName("Bill")]
        public string Bill { get; set; }
        [DisplayName("Tipo Servicio")]
        public string TServicio { get; set; }
        [DisplayName("Coordinador")]
        public string Coordinador { get; set; }
        [DisplayName("Tipo de pago")]
        public string Tpago { get; set; }
        [DisplayName("Cantidad DLLS")]
        public decimal CantidaDlls { get; set; }

        [DisplayName("Parida")]
        public double Paridad { get; set; }

        [DisplayName("Alias")]
        public string Alias { get; set; }


        /*    [DisplayName("VEHICULO")]
            public string vehiculo { get; set; } 



            */








        /*
                [DisplayName("MIN VENTANA HORARIA 1")]
                public string ventamahora1 { get; set; }

                [DisplayName("MAX VENTANA HORARIA 1")]
                public string ventanahora2 { get; set; }

                [DisplayName("MIN VENTANA HORARIA 2")]
                public string ventanahorados1 { get; set; }

                [DisplayName("MAX VENTANA HORARIA 2")]
                public string ventanahorados2 { get; set; }

                [DisplayName("COSTO ITEM")]
                public string costitem { get; set; }

                [DisplayName("CAPACIDAD UNO")]
                public string capacidaduno { get; set; }

                [DisplayName("CAPACIDAD DOS")]
                public string capacidaddos { get; set; }

                [DisplayName("SERVICE TIME")]
                public string servtime { get; set; }

                [DisplayName("IMPORTANCIA")]
                public string importancia { get; set; }


                */










    }
}
