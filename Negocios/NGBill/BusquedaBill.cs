using Datos.Datosenti;
using Datos.ViewModels.Bill;
using Datos.ViewModels.Carga;
using Datos.ViewModels.Odoo;
using Negocios.LOGs;
using Negocios.Odoo;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Negocios.NGBill
{
    public class BusquedaBill
    {

        public async Task<List<VMSalidasBill>> SalidasOperacion(
     OdooClient cliente,
     string dato,
     string fecha,
     string vehiculo)
        {
            try
            {
                using (var modelo = new modelo2Entities())
                {
                    // 1) Traer los datos base de EF
                    var query = from d in modelo.KDMENT.AsNoTracking()
                                join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 }
                                                       equals new { k.C1, k.C4, k.C6 }
                                where d.C9 == dato
                                select new { d, k };

                    var primerResultado = query.FirstOrDefault();
                    if (primerResultado == null)
                        return new List<VMSalidasBill>();

                    // 2) Llamada a Odoo
                    OdooToBeeModel odooInfo = await cliente
                        .GetProductToBeetrackById(primerResultado.k.odooidproduct ?? 0);

                    // 3) Parsear coordenadas por defecto
                    var defaultCoord = new OdooCoordenadas();
                    if (!string.IsNullOrWhiteSpace(odooInfo.defaultCoordinates))
                        defaultCoord = ParseCoordenada(odooInfo.defaultCoordinates);

                    // 4) Proyección con manejo de errores específico
                    try
                    {
                        return query
                            .Where(x => x.d != null)
                            .AsEnumerable()  // para que ToString() y demás no se traduzcan a SQL
                            .Select(x =>
                            {
                                var d = x.d;
                                var quote = (odooInfo.current_quote ?? string.Empty).Trim();

                                return new VMSalidasBill
                                {
                                    ORIGEN = string.Empty,
                                    entrada = $"{(d.C1 ?? string.Empty).Trim()}-{(d.C6 ?? string.Empty)}",
                                    etiqueta = d.C9 ?? string.Empty,
                                    Direccion = odooInfo.contactAddress ?? string.Empty,
                                    NOMBREITEM = (d.C42 ?? string.Empty).Trim(),
                                    CANTIDAD = "1",
                                    fechamin = fecha,
                                    fechamax = fecha,
                                    idcontacto = odooInfo.idContacto.ToString(),
                                    nomcotacto = odooInfo.name ?? string.Empty,
                                    EMAIL = odooInfo.email ?? string.Empty,
                                    Telefono = odooInfo.phone ?? string.Empty,
                                    VEHICULO = vehiculo,
                                    LATITUD = defaultCoord.Latitud ?? string.Empty,
                                    LONGITUD = defaultCoord.Longitud ?? string.Empty,
                                    Quote = $"https://app.arniangroup.com/#/quotationseach/{quote}",
                                    NumCot = quote,
                                    Coordinador = odooInfo.salesUserName ?? string.Empty,
                                    Tpago = odooInfo.tipoPago ?? string.Empty,
                                    OdooId = odooInfo.idProducto.ToString(),
                                    Nota = odooInfo.description_sale ?? string.Empty
                                };
                            })
                            .ToList();
                    }
                    catch (Exception ex)
                    {
                        // Logging de excepción genérica
                        Negocios.LOGs.ArsLogs.LogEdit(
                            ex.Message,
                            $"BusquedaBill.cs SalidasOperacion() dato={dato}"
                        );

                        // Si es validación de EF, loggear cada error
                        if (ex is DbEntityValidationException valEx)
                        {
                            foreach (var entErr in valEx.EntityValidationErrors)
                                foreach (var ve in entErr.ValidationErrors)
                                {
                                    Negocios.LOGs.ArsLogs.LogEdit(
                                        $"Entity Validation Error - Prop: {ve.PropertyName}, Msg: {ve.ErrorMessage}",
                                        $"BusquedaBill.cs SalidasOperacion() dato={dato}"
                                    );
                                }
                        }

                        throw;  // relanzar para que el caller lo maneje
                    }
                }
            }
            catch
            {
                // Aquí podrías agregar logging global si lo deseas
                throw;
            }
        }

        public static OdooCoordenadas ParseCoordenada(string input)
        {
           
            try
            {
               
                // Limpiar la cadena de entrada removiendo espacios y caracteres no deseados
                string cleanedInput = new string(Array.FindAll<char>(input.ToCharArray(), (c => (char.IsDigit(c) || c == '.' || c == ',' || c == '-'))));

                // Dividir la cadena en base a la coma
                string[] parts = cleanedInput.Split(',');

                if (parts.Length != 2)
                {
                    throw new ArgumentException("Formato de entrada no válido. Debe ser 'latitud, longitud'");
                }


                return new OdooCoordenadas { Latitud = parts[0].Trim(), Longitud = parts[1].Trim() };
            }
            catch (Exception)
            {

                return new OdooCoordenadas();
            }
           
        }

        public void RealizarConsultaSinSentido()
        {
            try
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    OdooClient odooClient = new OdooClient();
                    SalidasOperacion(odooClient,"SD-001235-1", "", "Test");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> ModificaKDMENTToBill(string etiqueta, string guid)
        {
            using (modelo2Entities modelo = new modelo2Entities())
            {
                try
                {
                    var d = (from fd in modelo.KDMENT
                             where fd.C9 == etiqueta.ToUpper().Trim()
                             select fd).FirstOrDefault();

                    if (d != null)
                    {
                        d.C46 =!String.IsNullOrWhiteSpace(guid)? guid : "BTRACKSALIDA";
                        d.C77 = DateTime.Now.ToString("MM/dd/yyyy");
                        await modelo.SaveChangesAsync();
                        GeneralMovimientosLog.AddMovimientoConParametrosDirectos(GeneralMovimientosLog.ObtenerFolioDesdeEtiqueta(etiqueta), 35, etiqueta, 60, "BTRACKSALIDA", "", "", "", "Scanea");
                        return true;
                    }
                    else
                    {
                        Negocios.LOGs.ArsLogs.LogEdit("No se encontró la etiqueta", "BILL sale de arsys a Beetrack" + etiqueta);
                        return false;
                    }
                }
                catch (Exception x)
                {
                    Negocios.LOGs.ArsLogs.LogEdit(x.Message, "BILL sale de arsys a Beetrack" + etiqueta);
                    if (x is DbEntityValidationException entityValidationEx)
                    {
                        foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                        {
                            // Acceder a los Entity Validation Errors
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                var propertyName = validationError.PropertyName;
                                var errorMessage = validationError.ErrorMessage;
                                Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "BusquedaBill.cs, ModificaKDMENTToBill()..." + etiqueta + "    ");
                            }
                        }
                    }
                    return false;
                }
            }
        }


        public async Task<bool> ModificaKDMENTToBillBorra(string etiqueta)
        {
            return await Task.Run(() =>
            {
                using (modelo2Entities modelo = new modelo2Entities())
                {
                    try
                    {
                        // Selecciona el registro que cumple con la condición
                        var d = (from fd in modelo.KDMENT
                                 where fd.C9 == etiqueta.ToUpper().Trim()
                                 select fd).FirstOrDefault();

                        if (d != null)
                        {
                            // Actualiza los campos necesarios
                            d.C46 = "";
                            d.C77 = "";

                            // Guarda los cambios en la base de datos
                            modelo.SaveChanges();

                            // Registra el movimiento en el log
                            GeneralMovimientosLog.AddMovimientoConParametrosDirectos(
                                GeneralMovimientosLog.ObtenerFolioDesdeEtiqueta(etiqueta),
                                35,
                                etiqueta,
                                60,
                                "BTRACKSALIDA",
                                "",
                                "",
                                "",
                                "Baja"
                            );

                            return true; // Devuelve true si la actualización es exitosa
                        }
                        else
                        {
                            // Registra un error si no se encuentra el registro
                            Negocios.LOGs.ArsLogs.LogEdit("Etiqueta no encontrada: " + etiqueta, "BILL sale de arsys a Beetrack");
                            return false;
                        }
                    }
                    catch (Exception x)
                    {
                        // Registra el error y maneja las excepciones de validación de entidad
                        Negocios.LOGs.ArsLogs.LogEdit(x.Message, "BILL sale de arsys a Beetrack " + etiqueta);
                        if (x is DbEntityValidationException entityValidationEx)
                        {
                            foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                            {
                                foreach (var validationError in entityValidationError.ValidationErrors)
                                {
                                    var propertyName = validationError.PropertyName;
                                    var errorMessage = validationError.ErrorMessage;
                                    Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "BusquedaBill.cs, ModificaKDMENTToBillBorra()... " + etiqueta);
                                }
                            }
                        }
                        return false;
                    }
                }
            });
        }





        public bool AltaBillkdm1(string datoSucIni,
           string datoBill,
           DateTime datoFechaAlta,
           //   string datoOperacion,
           // string datoSucDest,
           //   string datoMoneda,
           //double datoParidad,
           string datoRefe)
        //DateTime datoFCorte,
        //string datoHora)
        {

            using (modelo2Entities modelo = new modelo2Entities())
            {
                try
                {
                    var d = new KDM1();
                    d.C1 = datoSucIni;
                    d.C2 = "U";
                    d.C3 = "D";
                    d.C4 = 55;
                    d.C5 = 1;
                    d.C6 = datoBill;
                    // d.C7 = datoMoneda;
                    d.C8 = 1;
                    d.C9 = datoFechaAlta;
                    d.C11 = datoRefe;
                    d.C18 = datoFechaAlta;
                    d.C30 = "Bill";
                    //d.C40 = datoParidad;
                    d.C43 = "N";
                    d.C63 = "UD5501-";
                    d.C67 = Common.Cache.CacheLogin.username.ToString().Trim();
                    d.C68 = datoFechaAlta;
                    /*d.C101 = datoOperacion;
                    d.C103 = datoSucDest;
                    d.C111 = datoFCorte;
                    d.C112 = datoHora;*/
                    modelo.KDM1.Add(d);
                    modelo.SaveChanges();
                    GeneralMovimientosLog.AddMovimientoConParametrosDirectos(datoBill, 55, "", 55, "", datoSucIni, "","","Alta");
                    return true;
                }
                catch (DbEntityValidationException ex)
                {
                    Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "BusquedaBill.cs, AltaBillkdm1()... " + datoBill + "");
                    if (ex is DbEntityValidationException entityValidationEx)
                    {
                        foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                        {
                            // Acceder a los Entity Validation Errors
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                var propertyName = validationError.PropertyName;
                                var errorMessage = validationError.ErrorMessage;
                                Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "BusquedaBill.cs, AltaBillkdm1()..." + datoBill + "    ");
                            }
                        }
                    }
                    return false;

                }

            }


        }
        public void ActualizaSqlIov(string datoSucIni, int modo, string dato)
        {


            string br = "KFUD" + modo + "01." + datoSucIni;
            using (modelo2Entities modelo = new modelo2Entities())
            {

                try
                {
                    modelo.aumentaSQLint(br, modo.ToString().Trim());
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Ha Ocurrido un error, datos faltantes o incorrectos.");
                }
            }
        }


        public List<vmBillEntradaDoc> EntradasEnBill(string datoSucIni, int carga, string modo = null)
        {
            string codigo = datoSucIni.Trim() + "-UD5501-" + carga.ToString("D7");

            try
            {
                var lst2 = new List<vmBillEntradaDoc>();

                using (modelo2Entities modelo = new modelo2Entities())

                {

                    var lista = (from d in modelo.KDMENT.AsNoTracking()
                                 join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                 where d.C34.Contains(codigo) && k.C4 == 35 //&& d.C19 != sdestino 
                                 select new vmBillEntradaDoc
                                 {
                                     entrada = d.C6,
                                     etiqueta = d.C9,
                                     desc = d.C42,
                                     oper = k.C101,
                                     alias = k.C112,
                                     alias2 = d.C24
                                 }).ToList();

                    foreach (var item in lista)
                    {
                        if (string.IsNullOrWhiteSpace(item.alias))
                        {
                            item.alias = item.alias2;
                        }
                    }

                    lst2 = lista.Select((d, index) => new vmBillEntradaDoc
                    {
                        entrada = d.entrada,
                        etiqueta = d.etiqueta,
                        desc = !String.IsNullOrWhiteSpace(d.desc) ? d.desc.Trim() : "",
                        oper = d.oper,
                        nItem = index + 1, // Agregar el número de fila sumando 1 al índice
                        alias = d.alias,
                    }).ToList();


                }

                return lst2;
            }
            catch (Exception ex)
            {
                Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "BusquedaBill.cs, EntradasEnBill()... " + codigo + "    ");



                if (ex is DbEntityValidationException entityValidationEx)
                {
                    foreach (var entityValidationError in entityValidationEx.EntityValidationErrors)
                    {
                        // Acceder a los Entity Validation Errors
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            var propertyName = validationError.PropertyName;
                            var errorMessage = validationError.ErrorMessage;
                            Negocios.LOGs.ArsLogs.LogEdit($"Entity Validation Error - Property: {propertyName}, Message: {errorMessage}", "BusquedaBill.cs, EntradasEnBill()..." + codigo + "    ");
                        }
                    }
                }
                throw;
            }

        }

        public async Task<vmInfoBill> InfoEnBill(string entBus, string modo = null)
        {
            // string codigo = datoSucIni.Trim() + "-UD5501-" + carga.ToString("D7");

            try
            {
                var dt = new vmInfoBill();

                using (modelo2Entities modelo = new modelo2Entities())

                {

                    var lista = (from d in modelo.KDMENT
                                 join k in modelo.KDM1 on new { d.C1, d.C4, d.C6 } equals new { k.C1, k.C4, k.C6 }
                                 join a in modelo.KDUV on k.C12 equals a.C2
                                 //join u in modelo.KDUSUARIOS on a.C22 equals u.C1
                                 join s in modelo.KDUD on k.C10 equals s.C2



                                 where d.C9 == entBus && k.C4 == 35
                                 select new vmInfoBill
                                 {
                                     toNombre = d.C24,
                                     toCalle = d.C25,
                                     toColonia = d.C26,
                                     toLocalidad = d.C27,
                                     toZip = d.C28,
                                     fromNombre = s.C3,
                                     fromCalle = s.C4,
                                     fromColonia = s.C5,
                                     fromLocalidad = s.C6,
                                     fromZip = s.C27,
                                     telCliente = s.C7 +", "+ d.C29,
                                     coord = a.C3,

                                 });
                    dt = lista.FirstOrDefault();

                }

                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<string> BeetrackCode()
        {
            // string codigo = datoSucIni.Trim() + "-UD5501-" + carga.ToString("D7");

            try
            {
                string dt = "";

                using (modelo2Entities modelo = new modelo2Entities())

                {

                    var lista = (from d in modelo.SqlIov
                                 where d.C1 == "Bee"
                                 select d.C16);
                               
                    dt = lista.FirstOrDefault();

                }

                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }





    }



}
