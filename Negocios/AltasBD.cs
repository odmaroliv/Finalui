using Datos.Datosenti;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ViewModels.Entradas;
using Ventana1.vm;
using System.Windows.Forms;

using Datos.ViewModels.Coord;
using Negocios.LOGs;

namespace Negocios
{
    public class AltasBD
    {
        public void agregaKDM1(string sucInicial, string entrada, string Moneda, DateTime fecha, string noCliente,
            string noCord, string valArn, string nomCliente, string calle, string colonia, string ciudadcodigozip, string valFact,
            string paridad, string noTrakin, string provedor, string orCompra, string noFlete, string noUnidades, string tipUnidad, string peso,
            string unidadMedida, string tipOperacion, string sucDestino, string bultos, string Alias, string nota, string referencia, string isDano, int tpoEntrada)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = new KDM1();
                    d.C1 = sucInicial.Trim();
                    d.C2 = "U";
                    d.C3 = "D";
                    d.C4 = 35;
                    d.C5 = 1;
                    d.C6 = entrada;
                    d.C7 = Moneda;
                    d.C8 = 1;//ALMACEN 
                    d.C9 = fecha;
                    d.C10 = noCliente;
                    d.C11 = referencia;
                    d.C12 = noCord;
                    d.C16 = valArn == "" ? 1 : Convert.ToDecimal(valArn);
                    d.C24 = nota;
                    d.C27 = isDano;
                    d.C31 = "Ent";
                    d.C32 = nomCliente;
                    d.C33 = calle;
                    d.C34 = colonia;
                    d.C35 = ciudadcodigozip;
                    if (Moneda == "DLLS") { d.C40 = paridad == "" ? 0 : Convert.ToDouble(paridad); }
                    d.C41 = fecha;
                    d.C42 = valArn == "" ? 1 : Convert.ToDecimal(valArn);
                    d.C43 = "N";
                    d.C63 = "UD3501-";
                    d.C67 = d.C67 = Common.Cache.CacheLogin.username.ToString().Trim().Substring(0, Math.Min(Common.Cache.CacheLogin.username.ToString().Trim().Length, 22));//Ultimo en modificar la entrada
                    d.C68 = fecha;//fecha de la ultima modificacion
                    d.C69 = fecha.Hour.ToString();//Hora de la ultima modificacion
                    d.C80 = noTrakin; //elaboro
                    d.C81 = Common.Cache.CacheLogin.username.ToString().Trim(); //elaboro
                    d.C92 = provedor;
                    d.C93 = orCompra;
                    d.C95 = noFlete?.Substring(0, Math.Min(noFlete.Length, 50));
                    d.C97 = Convert.ToDecimal(noUnidades);
                    d.C98 = tipUnidad.Substring(0, Math.Min(tipUnidad.Length, 5));
                    d.C99 = Convert.ToDecimal(peso);
                    d.C100 = unidadMedida;
                    d.C101 = tipOperacion;
                    d.C102 = valFact == "" ? "0" : valFact; //este valor lo usamos en los reportes
                    d.C103 = sucDestino.Trim();
                    d.C108 = bultos;
                    d.C112 = Alias.Trim();
                    d.TipoEntradaID = tpoEntrada;
                    modelo.KDM1.Add(d);
                    modelo.SaveChanges();

                }
            }
            catch (DbEntityValidationException e)
            {

                Negocios.LOGs.ArsLogs.LogEdit(e.Message, " agregaKDM1() " + entrada);


                if (e is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        // Acceder a los Entity Validation Errors
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "altasBD.cs,  agregaKDM1())..." + entrada + "    ");
                        }
                    }
                }

                throw;
            }

        }
        public void ActualizaSqlIov(string datoSucIni, int modo, string dato = null)
        {


            string br = "KFUD" + modo + "01." + datoSucIni;
            using (modelo2Entities modelo = new modelo2Entities())
            {

                try
                {
                    modelo.aumentaSQLint(br, modo.ToString().Trim());
                }
                catch (Exception ex)
                {
                    Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "AltasBD.ActualizaSqlIov() " + modo);
                    System.Windows.Forms.MessageBox.Show("Ha Ocurrido un error, datos faltantes o incorrectos.");
                    throw;
                }
            }
        }

        public void agregaComentKDM1(string sucEntrada, string codEntrada, string moneda, DateTime fecha, string codCliente, string desc)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = new KDM1COMEN();
                    d.C1 = sucEntrada.Trim();
                    d.C2 = "U";
                    d.C3 = "D";
                    d.C4 = 35;
                    d.C5 = 1;
                    d.C6 = codEntrada.Trim();
                    d.C7 = moneda;
                    d.C8 = 1;
                    d.C9 = fecha;
                    d.C10 = codCliente.Trim();
                    d.C11 = desc;



                    modelo.KDM1COMEN.Add(d);
                    modelo.SaveChanges();

                }
            }
            catch (DbEntityValidationException e)
            {
                Negocios.LOGs.ArsLogs.LogEdit(e.Message, "AltasBD.agregaComentKDM1() " + codEntrada);
                throw;
            }

        }

        public void agregaKDMENT(string sucInicio, string folEntrada, string numEtiqueta, string documento, string etiqueta, string sucDestino, string sucActual, string desc, string fecha,
            int repEspecial, int modo, string proceso)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    modelo.AgregaKDMENT(
                        sucInicio,
                        "U",
                        "D",
                        "35",
                        "1",
                        folEntrada,
                        numEtiqueta,
                        documento,
                        etiqueta,
                        sucDestino,
                        sucActual,
                        desc,
                        fecha,
                        "E",
                        "E",
                        "E",
                        "ESPECIAL",
                        "ESPECIAL",
                        "ESPECIAL",
                        "F",
                        repEspecial,
                        modo,
                        proceso,
                        null, null, null, null, null, null, null, null, null, null, null, null, null

                        );

                    modelo.SaveChanges();

                }
            }
            catch (DbEntityValidationException e)
            {
                Negocios.LOGs.ArsLogs.LogEdit(e.Message, "AltasBD.agregaKDMENT() " + etiqueta);
                if (e is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        // Acceder a los Entity Validation Errors
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AltasBD.agregaKDMENT()..." + etiqueta + "    ");
                        }
                    }
                }
                throw;
            }
        }

        public void UpdateKDM1(string id, string sucursaldestino, string cord, string notas, string referencia, string pagado, string tipooperacion, string valfact, string valarn, string sucursalOrigen,string noFlete, string datoOrConpra,
            string datoNuCliente,string datoNomCliente,string datoCalle,string datoColonia,string datoCiudadZip,string datoProvedor, string datoAlias, DateTime fecha, int tpoEnrtada)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = (from q in modelo.KDM1
                             where q.C6 == id && q.C4 == 35 && q.C1 == sucursalOrigen
                             select q).FirstOrDefault();

                    if (!string.IsNullOrEmpty(sucursaldestino))
                    {
                        d.C103 = sucursaldestino.Trim();
                    }

                    if (!string.IsNullOrEmpty(cord))
                    {
                        d.C12 = cord.Trim();
                    }

                    if (!string.IsNullOrEmpty(notas))
                    {
                        d.C24 = notas.Trim();
                    }

                    if (!string.IsNullOrEmpty(referencia))
                    {
                        d.C11 = referencia.Trim();
                    }

                    if (!string.IsNullOrEmpty(pagado))
                    {
                        d.C44 = pagado.Trim();
                    }

                    if (!string.IsNullOrEmpty(tipooperacion))
                    {
                        d.C101 = tipooperacion.Trim();
                    }

                    if (!string.IsNullOrEmpty(valfact))
                    {
                        d.C102 = valfact.Trim();
                    }

                    if (!string.IsNullOrEmpty(valarn))
                    {
                        d.C16 = Convert.ToDecimal(valarn.Trim());
                        d.C42 = Convert.ToDecimal(valarn.Trim());
                    }

                    d.C93 = datoOrConpra;
                    d.C95 = noFlete;

                    if (!string.IsNullOrEmpty(datoNuCliente))
                    {
                        d.C10 = datoNuCliente.Trim();
                    }
                    d.TipoEntradaID = tpoEnrtada;
                    d.C32 = datoNomCliente;
                    d.C33 = datoCalle;
                    d.C34 = datoColonia;
                    d.C35 = datoCiudadZip;
                    d.C92 = datoProvedor;
                    d.C112 = datoAlias;
                    d.C67 = d.C67 = Common.Cache.CacheLogin.username.ToString().Trim().Substring(0, Math.Min(Common.Cache.CacheLogin.username.ToString().Trim().Length, 22));//Ultimo en modificar la entrada
                    d.C68 = fecha;//fecha de la ultima modificacion
                    d.C69 = fecha.Hour.ToString();//Hora de la ultima modificacion
                    try
                    {
                        modelo.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ocurrio un error" + ex.Message.ToString());
                        if (ex is DbEntityValidationException entityValidationEx)
                        {
                            foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                            {
                            
                                foreach (var validationError in entityValidationError.ValidationErrors)
                                {
                                    var propertyName = validationError.PropertyName;
                                    var errorMessage = validationError.ErrorMessage;
                                    Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "AltasBD.UpdateKDM1()..." + id + "    ");
                                }
                            }
                        }
                        //throw;
                    }
                    StringBuilder descripcionCambios = new StringBuilder();

                    // Sucursal destino
                    if (!string.IsNullOrEmpty(sucursaldestino))
                    {
                        descripcionCambios.AppendLine($"Sucursal destino: {sucursaldestino.Trim()} | ");
                    }

                    // Cord
                    if (!string.IsNullOrEmpty(cord))
                    {
                        descripcionCambios.AppendLine($"Cord: {cord.Trim()} | ");
                    }

                    // Notas
                    if (!string.IsNullOrEmpty(notas))
                    {
                        descripcionCambios.AppendLine($"Notas: {notas.Trim()} | ");
                    }

                    // Referencia
                    if (!string.IsNullOrEmpty(referencia))
                    {
                        descripcionCambios.AppendLine($"Referencia: {referencia.Trim()} | ");
                    }

                    // Tipo de operación
                    if (!string.IsNullOrEmpty(tipooperacion))
                    {
                        descripcionCambios.AppendLine($"Tipo de operación: {tipooperacion.Trim()} | ");
                    }

                    // Valor factura
                    if (!string.IsNullOrEmpty(valfact))
                    {
                        descripcionCambios.AppendLine($"Valor Fact: {valfact.Trim()} | ");
                    }

                    // Valor ARN
                    if (!string.IsNullOrEmpty(valarn))
                    {
                        descripcionCambios.AppendLine($"Valor ARN: {valarn.Trim()} | ");
                    }

                    // Número de flete
                    descripcionCambios.AppendLine($"flete: {noFlete} | ");

                    // Número de cliente
                    if (!string.IsNullOrEmpty(datoNuCliente))
                    {
                        descripcionCambios.AppendLine($"No. cliente: {datoNuCliente.Trim()} | ");
                    }
                    // Nombre del cliente
                    if (!string.IsNullOrEmpty(datoNomCliente))
                    {
                        descripcionCambios.AppendLine($"cliente: {datoNomCliente} | ");
                    }
                    // Calle
                    if (!string.IsNullOrEmpty(datoCalle))
                    {
                        descripcionCambios.AppendLine($"Calle: {datoCalle} | ");
                    }

                    // Colonia
                    if (!string.IsNullOrEmpty(datoColonia))
                    {
                        descripcionCambios.AppendLine($"Colonia: {datoColonia} | ");
                    }

                    // Ciudad/ZIP
                    if (!string.IsNullOrEmpty(datoCiudadZip))
                    {
                        descripcionCambios.AppendLine($"Ciudad/ZIP: {datoCiudadZip} | ");
                    }

                    // Proveedor
                    if (!string.IsNullOrEmpty(datoProvedor))
                    {
                        descripcionCambios.AppendLine($"Proveedor: {datoProvedor} | ");
                    }

                    // Alias
                    if (!string.IsNullOrEmpty(datoAlias))
                    {
                        descripcionCambios.AppendLine($"Alias: {datoAlias} | ");
                    }
                    
                    // Limita la descripción a 500 caracteres
                    string descripcionCorta = descripcionCambios.ToString().Substring(0, Math.Min(950, descripcionCambios.Length));

                    

                    GeneralMovimientosLog.AddMovimientoConParametrosDirectos(id, 35, "", 35, "", sucursalOrigen, sucursaldestino, cord, "Modifica", "", "Se modifica "+ descripcionCorta, "", datoAlias, "", Convert.ToDecimal(valarn.Trim()), Convert.ToDecimal(valfact.Trim()));
                }

            }
            catch (DbEntityValidationException e)
            {
                Negocios.LOGs.ArsLogs.LogEdit(e.Message, "AltasBD.UpdateKDM1() " + id);
                System.Windows.Forms.MessageBox.Show("Hubo un problema al actualizar, no se pudo actualizar este codigo");
            }

        }
        public void UpdateKDM1Coment(string id, string sucursalOrigen, string descripcion)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = (from q in modelo.KDM1COMEN
                             where q.C6 == id && q.C1 == sucursalOrigen
                             select q).FirstOrDefault();

                    d.C11 = descripcion;
                    modelo.SaveChanges();

                }
            }
            catch (DbEntityValidationException e)
            {
                Negocios.LOGs.ArsLogs.LogEdit(e.Message, "AltasBD.UpdateKDM1Coment() " + id);
                System.Windows.Forms.MessageBox.Show("Hubo un problema al actualizar, no se pudo actualizar este codigo");
            }

        }

        public void UpdateKDMentSuc(string id, string sucursalOrigen, string destino)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var data = (from q in modelo.KDMENT
                                where q.C6 == id && q.C1 == sucursalOrigen
                                select q);

                    foreach (var item in data)
                    {
                        item.C10 = destino;
                        if (sucursalOrigen == destino)
                        {
                            item.C20 = "F";
                        }
                    }


                    modelo.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                Negocios.LOGs.ArsLogs.LogEdit(e.Message, "AltasBD.UpdateKDMentSuc() " + id);
                System.Windows.Forms.MessageBox.Show("Hubo un problema al actualizar, no se pudo actualizar este código");
            }
        }




        //----------------------------------------------Salidas--------------------------------------------------------------------------


        public async Task<bool> CSalidaEnKDM1(string c1, string c2, string c3, decimal c4, decimal c5, string c6, decimal c8, DateTime c9, string c11, decimal c16, DateTime c18, string c24
            , string c31, string c61, string c63, string c67, DateTime c68, string c94, string c95, string c96, string c103)
        {

            bool status = true;

            using (modelo2Entities modelo = new modelo2Entities())
            {


                var d = new KDM1();

                d.C1 = c1;
                d.C2 = c2;
                d.C3 = c3;
                d.C4 = c4;
                d.C5 = c5;
                d.C6 = c6;
                d.C8 = c8;
                d.C9 = c9;
                d.C11 = c11;
                d.C16 = c16;
                d.C18 = c18;
                d.C24 = c24;
                d.C31 = c31;
                d.C61 = c61; //ESTATUS DE PAUSA POR EJEMPLO PSTJ O PSSD
                d.C63 = c63;
                d.C67 = c67.Substring(0, Math.Min(c67.Length, 22)); //Elaboro
                d.C68 = c68;
                d.C94 = c94;
                d.C95 = c95;
                d.C96 = c96;
                d.C103 = c103;

                modelo.KDM1.Add(d);
                try
                {
                    modelo.SaveChanges();
                }
                catch (Exception ex)
                {
                    Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "AltasBD.UCSalidaEnKDM1() " + c6);
                    status = false;
                }
                return status;
            }
        }

        public async Task ModificaStatusSalida(string sucursal, string numerosalida, string numerocarga)
        {


            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    List<KDM1> kd = new List<KDM1>();

                    //   int datoNumeroDocumento = sucursal == "TJ" ? 50 : 40 ;


                    if (sucursal == "TJ")
                    {

                        var d = (from fd in modelo.KDM1
                                 where fd.C1.Equals(sucursal) && fd.C4 == 50 && fd.C6 == numerocarga
                                 select fd).First();

                        d.C44 = numerosalida;
                        kd.Add(d);

                        try
                        {
                            modelo.BulkUpdate(kd.ToList());
                        }
                        catch (Exception ex)
                        {
                            Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "AltasBD.ModificaStatusSalida() " + numerosalida);
                            throw;
                        }
                    }
                    else
                    {

                        var d = (from fd in modelo.KDM1
                                 where fd.C1.Equals(sucursal) && fd.C4 == 40 && fd.C6 == numerocarga
                                 select fd).First();

                        d.C44 = numerosalida;
                        kd.Add(d);

                        try
                        {
                            modelo.BulkUpdate(kd.ToList());
                        }
                        catch (Exception ex)
                        {
                            Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "AltasBD.ModificaStatusSalida() " + numerosalida);
                            throw;
                        }
                    }


                }
            });
        }
        public async Task TerminaSalida(string numerosalida, string origen)

        {
            await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    List<KDM1> kd = new List<KDM1>();

                    var d = (from fd in modelo.KDM1
                             where fd.C1.Equals(origen) && fd.C4 == 45 && fd.C6 == numerosalida
                             select fd).FirstOrDefault();


                    d.C43 = "A";
                    d.C61 = "";
                    kd.Add(d);

                    try
                    {
                        modelo.BulkUpdate(kd.ToList());
                    }
                    catch (Exception ex)
                    {
                        Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "AltasBD.TerminaSalida() " + numerosalida);
                        
                        throw;
                    }
                }
            });
        }

        //--------------------carga--------------------------------

        public async Task ActualizaValores(string entrada, string sucursalIni, string valfact, string valarn)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = (from q in modelo.KDM1
                             where q.C1 == sucursalIni && q.C6 == entrada && q.C4 == 35
                             select q).First();

                    d.C102 = valfact.Trim();
                    d.C16 = Convert.ToDecimal(valarn.Trim());
                    d.C42 = Convert.ToDecimal(valarn.Trim());
                    await modelo.SaveChangesAsync();
                    GeneralMovimientosLog.AddMovimientoConParametrosDirectos(entrada, 35, "", 35, "", sucursalIni, "", "", "Entrada", "", $"Se modifican los valores: Valor Arnian: {valarn}, Valor Factura {valfact}");
                }
            }
            catch (Exception ex)
            {
                Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "AltasBD.TActualizaValores() " + entrada);
                System.Windows.Forms.MessageBox.Show("Ha ocurrido un error, no hemos podido actualizar el valor.");
            }

        }

        public async Task ActualizaValoresEntrega(string entrada, string sucursalIni, string calle, string colonia, string estado, string aliass, string zip, string num)
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var filas = from q in modelo.KDMENT
                                where q.C1 == sucursalIni && q.C6 == entrada && q.C4 == 35
                                select q;

                    foreach (var fila in filas)
                    {
                        fila.C24 = aliass;
                        fila.C25 = calle;
                        fila.C26 = colonia;
                        fila.C27 = estado;
                        fila.C28 = zip;
                        fila.C29 = num;
                    }

                    await modelo.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "AltasBD.ActualizaValoresEntrega() " + entrada);
                System.Windows.Forms.MessageBox.Show("Ha ocurrido un error, no hemos podido actualizar el valor.");
            }

        }



        /*
         Cuentas Por Cobrar CXC
         
         */
        public async Task ActualizaPagoPorEntrada(string entrada, string sucursalIni, string pago, string comentario)
        {

            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = (from q in modelo.KDM1
                             where q.C1 == sucursalIni && q.C6 == entrada && q.C4 == 35
                             select q).First();

                    d.C44 = pago;

                    await modelo.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ha ocurrido un error, no hemos podido actualizar el valor.");
                Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "AltasBD.ActualizaPagoPorEntrada() " + entrada);
            }
            if (!String.IsNullOrWhiteSpace(comentario))
            {
                //Actualiza comentarios
                try
                {
                    using (modelo2Entities modelo = new modelo2Entities())
                    {
                        var d = (from q in modelo.KDM1COMEN
                                 where q.C1 == sucursalIni && q.C6 == entrada && q.C4 == 35
                                 select q).First();

                        d.C13 = comentario;

                        await modelo.SaveChangesAsync();

                    }
                }
                catch (Exception ex)
                {
                    Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "AltasBD.ActualizaPagoPorEntrada() " + entrada);
                    System.Windows.Forms.MessageBox.Show("Ha ocurrido un error, no hemos podido actualizar el valor.");
                }

            }


        }



        public async Task AgregarProovedor(string clave, string nombre, string calle, string colonia, string poblacion, string rfc)
        {

            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    var d = new KDXD();
                    d.C2 = clave;
                    d.C3 = nombre;
                    d.C4 = calle;
                    d.C5 = colonia;
                    d.C6 = poblacion;
                    d.C10 = rfc;
                   

                    modelo.KDXD.Add(d);
                    try
                    {
                        modelo.SaveChanges();
                        MessageBox.Show("Agregado");
                    }
                    catch (Exception ex)
                    {
                        Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "AltasBD.AgregarProovedor() " + clave +" ; "+ nombre);
                        throw;
                    }
                }
            }


            catch (Exception ex)
            {
                Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "AltasBD.AgregarProovedor() " + clave + " ; " + nombre);
                System.Windows.Forms.MessageBox.Show("Ha ocurrido un error, no hemos podido crear el valor (Proovedor) posiblemente por codigo repedito.");
            }
            
        }
    }

}
