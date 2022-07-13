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
        [DisplayName("NÚMERO GUÍA")]
        public string entrada { get; set; }

        [DisplayName("VEHICULO")]
        public string vehiculo { get; set; } 
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

        [DisplayName("DIRECCIÓN")]
        public string Direccion { get; set; }

        public string LATITUD { get; set; }
        public string LONGITUD { get; set; }

        [DisplayName("FECHA MIN ENTREGA")]
        public string fechamin { get; set; }

        [DisplayName("FECHA MAX ENTREGA")]
        public string fechamax { get; set; }


        [DisplayName("CT ORIGEN")]
        public string ORIGEN { get; set; }





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
