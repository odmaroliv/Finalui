using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocios
{
    public class ValidacionEntradas
    {
        #region VALIDA CAMPOS DE ALTA DE ENTRADA
        public bool validacampo(string sucEntrada, string sucDestino, string tipoOper, string cord, string cliente, string proveedor,string ordenCompra, string numFlete, string unidades, string peso,string bultos, string detalles)
        {
            if( sucEntrada == null || sucEntrada == "")
            {
                System.Windows.Forms.MessageBox.Show("El campo de Sucursal Entrada no puede estar vacio", "Error");
                return false; 
            }
            if( sucDestino == null || sucDestino == "" )
            {
                System.Windows.Forms.MessageBox.Show("El capo Sucursal Destino no puede esta vacio", "Error");
                return false;
            }
            if(tipoOper == null || tipoOper == "")
            {
                System.Windows.Forms.MessageBox.Show("El campo de Tipo de operacion no puede estar vacio", "Error");
                return false;
            }
            if( cord == null || cord == "")
            {
                System.Windows.Forms.MessageBox.Show("La entrada no puede quedar sin un coordinador, es necesario se le asigne uno, ya que de lo contrario no se podra dar salida de esta mercancia","Falta Asignar Coordinador");
                return false;
            }
            if(cliente == null || cliente == "")
            {
                System.Windows.Forms.MessageBox.Show("El campo cliente no puede esta vacio", "Falta el campo cliente");
                return false;
            }
            if (proveedor == null || proveedor == "")
            {
                System.Windows.Forms.MessageBox.Show("El campo proveedor no puede estar vacio", "Campo proveedor vacio");
                return false;
            }
            if (ordenCompra == null || ordenCompra == "")
            {
                System.Windows.Forms.MessageBox.Show("El campo Orden de compra no puede estar vacio","campo orden de compra vacio");
                return false;
            }
            if(numFlete == null || numFlete == "")
            {
                System.Windows.Forms.MessageBox.Show("El campo Numero de flete no puede estar vacio","Error");
                return false;
            }
            if(unidades == null || unidades == "0" || unidades == "" || int.TryParse(unidades, out int a) == false)
            {
                System.Windows.Forms.MessageBox.Show("El campo de Unidades no puede ser menor a 0, no puede estar vacio y no puede ser una cadena de texto", "Error campo Unidades en 0");
                return false;
            }
            if (peso == null || peso == "0" || peso == "" || int.TryParse(peso, out int b) == false)
            {
                System.Windows.Forms.MessageBox.Show("El campo de Peso no puede ser menor a 0, no puede estar vacio y no puede ser una cadena de texto", "Error campo Peso en 0");
                return false;
            }
            if (bultos == null || bultos == "0" || bultos == "" || int.TryParse(bultos,out int c) == false)
            {
                System.Windows.Forms.MessageBox.Show("El campo de Bultos no puede ser menor a 0, no puede estar vacio y no puede ser una cadena de texto","Error campo Bultos en 0");
                return false;
            }
            if (detalles == null || detalles == "")
            {
                System.Windows.Forms.MessageBox.Show("El campo de detalles debe de contener una descripcio'n corta de la mercacia");
                return false;
            }
           

            return true;
            

        }
        #endregion // Funcion para validar que no haya campos vacios o con datos incorrectos a la hora de hacer la entrada


        


    }







}
