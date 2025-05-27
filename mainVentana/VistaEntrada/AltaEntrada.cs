using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.ViewModels.Entradas;
using Negocios;
using System.IO;
using System.Drawing.Printing;
using Datos.ViewModels;
using Datos.ViewModels.Servicios;
using Newtonsoft.Json;
using Negocios.Common.Cache;
using System.Diagnostics;
using Datos.ViewModels.Reportes;
using System.Net.Http;
using Datos.ViewModels.InicioFotoVisor;
using System.Net.Http.Headers;
using System.Net;
using mainVentana.Properties;
using System.Runtime.InteropServices;
using System.Globalization;
using FontAwesome.Sharp;
using DocumentFormat.OpenXml.Office2010.Excel;
using mainVentana.VistaEntrada.Proovedor;
using Datos.Datosenti;
using DocumentFormat.OpenXml.Office2013.Excel;
using Guna.UI.WinForms;
using System.Threading;
using static GMap.NET.Entity.OpenStreetMapGraphHopperRouteEntity;
using Negocios.Odoo;
using System.Data.SqlClient;
using System.Data.Entity.Validation;
using Negocios.LOGs;
using System.Text.RegularExpressions;
using System.Reflection.Emit;
using Negocios.NGClientes;

namespace mainVentana.VistaEntrada
{

    public partial class AltaEntrada : Form
    {
        //KunLibertad_DesktopControl Desk = new KunLibertad_DesktopControl();
        private static readonly HttpClient _client = new HttpClient();
        string entradaBusqueda;
        //int ventana;
        public int tipodeDocumento = 1;
        public string sucursalGlobal = Negocios.Common.Cache.CacheLogin.sucGlobal == default ? "SD":Negocios.Common.Cache.CacheLogin.sucGlobal;
        private string noEntGlobal = "";
        private string sbeArchivos = "";
        public int modoCord = 0;

        private readonly OdooClient _odooClient;

        string usernameapi = Settings.Default.apiFotosUs;
        string passwordapi = Settings.Default.apiFotosPs;
        public AltaEntrada( int modoCor = 0)
        {

            InitializeComponent();
            modoCord = modoCor;
            // Configurar la autenticación aquí
            var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{usernameapi}:{passwordapi}")));
            _client.DefaultRequestHeaders.Authorization = authValue;
            _odooClient = new OdooClient();
        }

        private void AltaEntrada_Load(object sender, EventArgs e)
        {

            if (tipodeDocumento == 1)
            {
                InicioEntrada();
                detalles.Enabled = true;
            }
            if (modoCord == 2)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                CambiaDocumento(2);
                //sucDestino.Enabled = false;
                groupBox3.Enabled = false;
                groupBox5.Enabled = false;
                //  groupBox6.Enabled = false;
                detalles.Enabled = false;
                gunaTileButton5.Enabled = false;
                txbReferencia.Enabled = false;
                groupBox4.Enabled = false;
                cmbMoneda.Enabled = false;
                txbValFact.Enabled = true;
                txbValArn.Enabled = true;
                

                //Especificos.Enabled = false; 
            }

        }


        private async void InicioEntrada()
        {
          //  btnReimp.Visible = false;
            unidades.Text = "";
            bultos.Text = "";
            peso.Text = "";

            txbValFact.Text = "1";
            txbValArn.Text = "1";


            dgvFotosModifi.Visible = false;
            dgvFotosModifi.Enabled = false;

            dgvDocs.Enabled = true;
            dgvDocs.Visible = true;
            mdfImg.Visible = false;

            //Desk.SpecialKeyButtons(false);
            llenaCampos();
            #region Autocompletar ref

            proveedor.AutoCompleteCustomSource = await proveeList();

            coloresSucursales();

            #endregion
        }


        private async void Guardar_Click(object sender, EventArgs e) //Click al boton guardar
        {
            string displayMember = cmbTipoEnt.DisplayMember;
            if (cmbTipoEnt.SelectedItem != null)
            {
                var selectedItem = cmbTipoEnt.SelectedItem;
                displayMember = selectedItem.GetType().GetProperty(cmbTipoEnt.DisplayMember).GetValue(selectedItem, null).ToString();               
            }

            if (validapsoemail() ==1)
            {
                return;
            }
            if (cbxDestinoModify.Checked == true)
            {

            }
            else
            {
                if (sucEntrada.SelectedValue == sucDestino.SelectedValue)
                {
                    MessageBox.Show("La sucursal de entrada y destino no pueden ser iguales.");
                    return;
                }
            }
           
            groupBox1.Enabled = false;
            if (MessageBox.Show("Entrada tipo: " + displayMember + "\n\nDe: " + sucEntrada.Text + "\n\nPara: "+ sucDestino.Text, "Verificación",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation)==DialogResult.Cancel)
            {
                groupBox1.Enabled = true;
                return;
            }

            
            try
            {
                if (cmbTipoEnt.SelectedItem == null)
                {
                    System.Windows.Forms.MessageBox.Show("El campo de tipo de entrada no puede estar vacio");
                    return;
                }
                ValidacionEntradas validacion = new ValidacionEntradas();
                if (tipodeDocumento == 1)
                {


                    if (validacion.validacampo(sucEntrada.Text, sucDestino.Text, tipoOper.Text, cord.Text, cliente.Text, proveedor.Text, ordenCompra.Text, numFlete.Text, unidades.Text, peso.Text, bultos.Text, detalles.Text) == true)
                    {
                        Guardar.Enabled = false;

                        if (txbValFact.Text.Trim() == "" || txbValFact.Text.Trim() == "0")
                        {
                            MessageBox.Show("Valor Vacio\nSe asignara 1");
                            txbValFact.Focus();
                            txbValFact.Text = "1";
                            return;
                        }
                        if (txbValArn.Text.Trim() == "" || txbValArn.Text.Trim() == "0")
                        {
                            MessageBox.Show("Valor Vacio\nSe asignara 1");
                            txbValArn.Focus();
                            txbValArn.Text = "1";
                            return;
                        }
                        //creaListadeFotos();
                        //AgregaArchivos();



                        int rsp = await altaKDM1();

                        if (rsp == 1 || rsp == 2 || rsp == 3)
                        {
                            MessageBox.Show("Se cancelo la operacion, esto puede ser  un problema, notifica al dep de Sistemas.");
                            return;
                        }

                        altaKDM1coment();

                        AgregaArchivos();
                        await SubeFotos();



                        await envEmail();

                        if (cbxIsRevisada.Checked == true)
                        {
                            if (string.IsNullOrWhiteSpace(lblNoOdoo.Text))
                            {
                                return;
                            }
                            await UpdateRevisado(lblNoOdoo?.Text.Trim());
                        }


                        SelectPrinter();
                        //barcode();
                        //Crea_codigo_de_barras(); desactivado por erri en drawin 
                        //llamareporte();
                        // CreaEriquetas();
                        //envEmail();



                        ReiniciaInfo(0);
                        Guardar.Enabled = true;
                        //cargaultent();
                    }
                }

                if (tipodeDocumento == 2)
                {
                    if (lblEntrada.Text == "")
                    {
                        return;
                    }
                    if (validacion.validacampo(sucEntrada.Text, sucDestino.Text, tipoOper.Text, cord.Text, cliente.Text, proveedor.Text, ordenCompra.Text, numFlete.Text, unidades.Text, peso.Text, bultos.Text, detalles.Text) == true)
                    {
                        Guardar.Enabled = false;

                       

                        if (txbValFact.Text.Trim() == "" || txbValFact.Text.Trim() == "0")
                        {
                            MessageBox.Show("Valor Vacio\nSe asignara 1");
                            txbValFact.Focus();
                            txbValFact.Text = "1";
                        }
                        if (txbValArn.Text.Trim() == "" || txbValArn.Text.Trim() == "0")
                        {
                            MessageBox.Show("Valor Vacio\nSe asignara 1");
                            txbValArn.Focus();
                            txbValArn.Text = "1";
                        }


                        if (lblEntrada.Text != "" || lblEntrada.Text != null)
                        {
                            string pagado = default;
                            if (rdbPagado.Checked == true)
                            {
                                pagado = "Pagado";
                            }
                            else
                            {
                                pagado = "NoPagado";
                            }

                            if (sbeArchivos == "SI")
                            {
                                AgregaArchivos();
                               await SubeFotos();
                            }
                            if (cbxNotif.Checked == true)
                            {
                                await ReenviaEnvEmail();
                                
                             
                            }
                            updateDatos(pagado);
                            if (cbxIsRevisada.Checked == true)
                            {
                                if (string.IsNullOrWhiteSpace(lblNoOdoo.Text))
                                {
                                    return;
                                }
                                await UpdateRevisado(lblNoOdoo?.Text.Trim());
                            }
                            
                            
                            SelectPrinter();

                            //llamareporte();


                            //Agregar aqui la impresion de etiquetas


                            MessageBox.Show("Se ha modificado el docimento " + lblEntrada.Text);
                            InicioModifica();
                            Guardar.Enabled = true;

                        }
                        else
                        {

                            MessageBox.Show("No se ha ingresado ninguna entrada!");
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio el siguente error: (Tomar Foto) \n" + ex);
                throw;
            }
            finally
            {
                groupBox1.Enabled = true;
                Guardar.Enabled = true; 
            }





        }

        private async Task UpdateRevisado(string odooId)
        {
            string odooRes = await _odooClient.UpdateReviewed(odooId);
           

        }


        string datoEntrada; //variable global de entrada cuando se click al boton de guardar ---------------------------------------
        private async Task<int> altaKDM1()
        {
            int bndra = 0;
            AltasBD bd = new AltasBD();

            string datoSucIni = sucEntrada.SelectedValue.ToString();
            datoEntrada = recuperUltimaent();
            string datoMoneda = cmbMoneda.GetItemText(cmbMoneda.SelectedItem).ToString();
            DateTime datoFecha = regresafecha();

            string datoNoCord = label24.Text;
            string datoValArn = txbValArn.Text;
            string datoNuCliente = lblCodCliente.Text;
            string datoNomCliente = String.IsNullOrWhiteSpace(lblParentName.Text) || lblParentName.Text == "false"? cliente.Text :lblParentName.Text;
            string datoParentId = String.IsNullOrWhiteSpace(lblParentId.Text) || lblParentId.Text == "false" ? "" : lblParentId.Text;

            string datoCalle = "";
            string datoColonia = "";
            string datoCiudadZip = lblZipCode.Text?.Trim() == "false" ? "NA" : lblZipCode.Text?.Trim();
            string datoProvedor = proveedor.SelectedValue.ToString();
            string datoValFact = txbValFact.Text;
            string datoParidad = lblParidad.Text;
            string datoNoTrakin = tbxRastreo.Text;
            string datoOrdCompra = ordenCompra.Text;
            string datoNoFlete = numFlete.Text;
            string datoNoUnidades = unidades.Text;
            string datoTipoUnidad = cmbUnidades.SelectedValue.ToString();
            string datoPeso = peso.Text;
            string datoUnidadMedida = cmbPeso.SelectedValue.ToString();
            string datoTipoOper = tipoOper.SelectedValue.ToString();
            string datoSucDestino = sucDestino.SelectedValue.ToString();
            string datoBultos = bultos.Text;
            string datosAlias = cliente.Text;
            string datoNota = txbNotas.Text;
            string datoReferencia = txbReferencia.Text;
            string isDanado = cbxDano.Checked ? "1" : "0";
            int tpoEntrada = Convert.ToInt32(cmbTipoEnt.SelectedValue);
            long idOdoo;
            string datoDetalles = detalles.Text;
            string odoosalesp = label23.Text;
           

            using (var context = new modelo2Entities()) // Asumiendo que modelo2Entities es tu DbContext
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // Crear entidad en Odoo
                       
                        if (!int.TryParse(datoNuCliente, out int parsedDatoNuCliente))
                        {
                            parsedDatoNuCliente = 2257;
                        }

                        if (!int.TryParse(datoNoCord, out int parsedDatoNoCord))
                        {
                            parsedDatoNoCord = 35;
                        }

                        

                        // Si llegas aquí, todos los parseos fueron exitosos, y puedes usar las variables parsed
                        idOdoo = await _odooClient.CreateEntInOdoo($"{datoSucIni.Trim()}-{datoEntrada.Trim()}", parsedDatoNuCliente, parsedDatoNoCord, 0, datoDetalles, false, datoSucIni, datoTipoOper, $"{datoSucIni.Trim()}-{datoEntrada.Trim()}", Convert.ToInt32(datoBultos));
                        if (idOdoo == -1)
                        {
                            await bd.ActualizaSqlIov(context, datoSucIni.Trim(), 35);
                            return 1;
                        }

                       

                        // Agregar KDM1
                        await bd.agregaKDM1(context, datoSucIni, datoEntrada, datoMoneda, datoFecha, parsedDatoNuCliente.ToString(), parsedDatoNoCord.ToString(), datoValArn, datoNomCliente, datoCalle, datoColonia, datoCiudadZip, datoValFact, datoParidad, datoNoTrakin, datoProvedor, datoOrdCompra, datoNoFlete, datoNoUnidades, datoTipoUnidad, datoPeso, datoUnidadMedida, datoTipoOper, datoSucDestino, datoBultos, datosAlias, datoNota, datoReferencia, isDanado, tpoEntrada, idOdoo, odoosalesp, datoParentId, cbxIsRevisada.Checked);

                        // Llamada para actualizar SQL
                        await bd.ActualizaSqlIov(context, datoSucIni.Trim(), 35);




                        await actualizaKDMENT(bd, context, datoSucIni, datoEntrada, datoBultos, datoSucDestino, datoFecha, idOdoo,label23.Text);

                        var errors = context.GetValidationErrors();
                        if (errors.Any())
                        {
                            foreach (var failure in errors)
                            {
                                foreach (var error in failure.ValidationErrors)
                                {
                                    Console.WriteLine($"Property: {error.PropertyName} Error: {error.ErrorMessage}");
                                }
                            }
                            // Puedes decidir no llamar a SaveChanges si hay errores
                        }
                        // Si llegas aquí, todos los SPs se ejecutaron sin error
                        await context.SaveChangesAsync();
                        dbContextTransaction.Commit(); // Confirma todas las operaciones
                        return 0; // Retorna 0 si todo fue exitoso
                    }
                    catch (Exception ex)
                    {
                     
                     
                    
                    dbContextTransaction.Rollback(); // Revierte todas las operaciones si algo falla
                        MessageBox.Show("Error en altaKDM1: " + ex.Message);
                        return 3; // Código de error genérico para fallo en la transacción
                    }
                }
            }
           
        }

        
        private async void ModificaEtiquetas(string bultos)
        {

            AltasBD bd = new AltasBD();
            string datoSucIni = sucEntrada.SelectedValue.ToString();
            string dtEntrada = lblEntrada.Text.Trim();
            string datoBultos = bultos.Trim();
            string datoSucDestino = sucDestino.SelectedValue.ToString();
            DateTime datoFecha = regresafecha();

            try
            {
                using (var context = new modelo2Entities()) // Asumiendo que modelo2Entities es tu DbContext
                {

                    if (!long.TryParse(lblNoOdoo.Text, out long parsedDatoNuodoo))
                    {
                        parsedDatoNuodoo = 0;
                    }
                    await actualizaKDMENT(bd, context, datoSucIni, dtEntrada, datoBultos, datoSucDestino, datoFecha, parsedDatoNuodoo, label23.Text);
                    
                }


            }
            catch (Exception ex)
            {
                Negocios.LOGs.ArsLogs.LogEdit(ex.Message, " ModificaEtiquetas(string bultos)");
                MessageBox.Show("Error:  ModificaEtiquetas(string bultos) " + ex.Message);
                //throw;
            }

        }

        private async void altaKDM1coment()
        {
            AltasBD bd = new AltasBD();

            string datoSucIni = sucEntrada.SelectedValue.ToString().Trim();
            string dtEntrada = datoEntrada.Trim();
            string datoMoneda = cmbMoneda.GetItemText(cmbMoneda.SelectedItem).ToString();
            DateTime datoFecha = regresafecha();
            string datoNuCliente = lblCodCliente.Text;
            string datoDetalles = detalles.Text;

            try
            {
                await Task.Run(() =>
                {
                    bd.agregaComentKDM1(datoSucIni, dtEntrada, datoMoneda, datoFecha, datoNuCliente, datoDetalles);
                });
                

            }
            catch (Exception ex)
            {
                Negocios.LOGs.ArsLogs.LogEdit(ex.Message, "altaKDM1coment()");
                MessageBox.Show("Error:  altaKDM1coment() " + ex.Message);
                //throw;
            }
          


        }


       
        private async Task actualizaKDMENT(AltasBD bd,modelo2Entities context,string datoSucIni, string datoEntrada, string datoBultos, string datoSucDestino, DateTime datoFecha, long odooProductId, string odooSalesP)
        {
            string datoDetalles = detalles.Text;
            
            for (int i = 1; i <= Convert.ToInt32(datoBultos); i++)
            {
                try
                {
             await  bd.agregaKDMENTOld(context, datoSucIni, datoEntrada, i.ToString(), datoSucIni.Trim() + "-UD3501-" + datoEntrada.Trim(), datoSucIni.Trim() + "-" + datoEntrada.Trim() + "-" + i.ToString(), datoSucDestino, datoSucIni.Trim(),
              datoDetalles.Length >= 100 ? datoDetalles.Substring(0, 100) : datoDetalles, datoFecha.ToString("MM/dd/yyyy HH:mm:ss"), 0, 0, "OE", odooProductId: odooProductId, odooSalesP: odooSalesP);

                }
                catch (Exception x)
                {
                    Negocios.LOGs.ArsLogs.LogEdit(x.Message, "Correo - lado de AltaEntrada");
                    MessageBox.Show("Ocurrio un error y no se pudo actualizar");
                   
                }


            }

            //bd.agregaKDMENT();
        }
        private async Task envEmail()
        {

            long cordCordinadorCMB = String.IsNullOrWhiteSpace(label24.Text) ? 0 : Convert.ToInt32(label24.Text);

            string doc = tipodeDocumento == 2 ? lblEntrada.Text.Trim() : noEntGlobal;
            EnviarEmail servicio = new EnviarEmail();

            List<string> archivos = new List<string>();
            if (dgvDocs.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDocs.Rows)
                {
                    archivos.Add(row.Cells[1].Value.ToString());

                }
            }
            try
            {

                string nmCliente = string.IsNullOrWhiteSpace(lblParentName?.Text.Trim()) || lblParentName?.Text.Trim() == "false" ? cliente.Text.Trim() : lblParentName?.Text.Trim();

                var respuesta = await servicio.EnviaMail(doc, nmCliente, tbxRastreo.Text, cliente.Text, ordenCompra.Text, numFlete.Text, proveedor.Text, detalles.Text, archivos, coreoClientes, cbxDano.Checked, cordCordinadorCMB);
                //var respuesta = await servicio.EnviaMailAmazonSES(doc, cliente.Text, tbxRastreo.Text, alias.Text, ordenCompra.Text, numFlete.Text, proveedor.Text, detalles.Text, archivos, coreoClientes, cordCordinadorCMB);

                if (respuesta == 1)
                {
                    MessageBox.Show("El correo NO SE ENVIÓ PORQUE supera el límite máximo de 25 MB en cada correo, intenta borrar documentos y reenvía la notificación", "CUIDADO EL CORREO NO SE ENVIO");
                    NotificaEmail(0, doc, cliente.Text + " / " + alias.Text);
                }
                else if (respuesta == 2)
                {
                    MessageBox.Show("El correo NO SE ENVIÓ (msg), pero la entrada si se dio de Alta", "CUIDADO EL CORREO NO SE ENVIO");
                    NotificaEmail(0, doc, cliente.Text + " / " + alias.Text);
                }
                else
                {
                    NotificaEmail(1, doc, cliente.Text + " / " + alias.Text);
                }

            }
            catch (Exception x)
            {
                Negocios.LOGs.ArsLogs.LogEdit(x.Message, doc + " Correo - lado de AltaEntrada");

            }
            finally
            {
                // Libera los recursos aquí

                archivos.Clear();
            }


        }

        private async Task ReenviaEnvEmail()
        {
            long cordCordinadorCMB =String.IsNullOrWhiteSpace(label24.Text)?0:Convert.ToInt32(label24.Text); //cord.SelectedValue.ToString().Trim();
            string doc = tipodeDocumento == 2 ? lblEntrada.Text.Trim() : noEntGlobal;
            EnviarEmail servicio = new EnviarEmail();

            List<string> archivos = new List<string>();

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string folder = path + "\\temp\\" + tbxRastreo.Text + "\\"; // Crear una carpeta específica para cada rastreo

            if (dgvFotosModifi.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvFotosModifi.Rows)
                {
                    try
                    {
                        string id = row.Cells[0].Value.ToString();
                        await DescargaDocsDesdeFolder(id, folder); // Descargar el archivo y guardarlo en la carpeta del rastreo
                        string fullFilePath = folder + id;
                        archivos.Add(fullFilePath); // Agregar la ruta completa del archivo a la lista
                    }
                    catch (Exception ex)
                    {
                        Negocios.LOGs.ArsLogs.LogEdit(ex.Message, doc + " Correo - problemas con el archivo");
                    }
                }
            }

            try
            {
                string nmCliente = string.IsNullOrWhiteSpace(lblParentName?.Text.Trim()) || lblParentName?.Text.Trim() == "false" ? cliente.Text.Trim() : lblParentName?.Text.Trim();

                var respuesta = await servicio.EnviaMail(doc, nmCliente, tbxRastreo.Text, cliente.Text, ordenCompra.Text, numFlete.Text, proveedor.Text, detalles.Text, archivos, coreoClientes, cbxDano.Checked, cordCordinadorCMB);

                if (respuesta == 1)
                {
                    MessageBox.Show("El correo NO SE ENVIÓ PORQUE supera el límite máximo de 25 MB en cada correo, intenta borrar documentos y reenvía la notificación", "CUIDADO EL CORREO NO SE ENVIO");
                    NotificaEmail(0, doc, cliente.Text + " / " + alias.Text);
                }
                else if (respuesta == 2)
                {
                    MessageBox.Show("El correo NO SE ENVIÓ (msg), pero la entrada si se dio de Alta", "CUIDADO EL CORREO NO SE ENVIO");
                    NotificaEmail(0, doc, cliente.Text + " / " + alias.Text);
                }
                else
                {
                    NotificaEmail(1, doc, cliente.Text + " / " + alias.Text);
                }
            }
            catch (Exception x)
            {
                Negocios.LOGs.ArsLogs.LogEdit(x.Message, doc + " Correo - lado de AltaEntrada");
            }
            finally
            {
               await  EliminaFolder(folder);

                // Limpiar los recursos
                archivos.Clear();
            }
        }

        private async Task EliminaFolder(string folder)
        {
           await Task.Run(() =>
            {
                Thread.Sleep(200);
                try
                {
                    if (Directory.Exists(folder))
                    {
                        Directory.Delete(folder, true);
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show("No se puedo borrar el folder de la entrada: " + folder);
                    Negocios.LOGs.ArsLogs.LogEdit(x.Message, "");
                }
            });
            
           
          

        }
        private async Task DescargaDocsDesdeFolder(string dato, string folder)
        {
            string nombreArchivo = dato.Trim();
            int tipoRespuesta = 2;
            string mensajeRespuesta = "";

            if (!string.IsNullOrWhiteSpace(nombreArchivo))
            {
                var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{usernameapi}:{passwordapi}")));

                _client.DefaultRequestHeaders.Authorization = authValue;

                try
                {
                    string url = "http://104.198.241.64:90/api/Archivo/?nombreArchivo=" + nombreArchivo;
                    using (HttpResponseMessage respuestaConsulta = await _client.GetAsync(url))
                    {
                        if (respuestaConsulta.IsSuccessStatusCode)
                        {
                            byte[] arrContenido = await respuestaConsulta.Content.ReadAsAsync<byte[]>();

                            string fullFilePath = folder + dato;

                            if (File.Exists(fullFilePath))
                                File.Delete(fullFilePath);

                            if (!Directory.Exists(folder))
                                Directory.CreateDirectory(folder);

                            File.WriteAllBytes(fullFilePath, arrContenido);

                            tipoRespuesta = 1;
                            // mensajeRespuesta = "Se descargó correctamente el archivo " + nombreArchivo;
                           // Process.Start(fullFilePath);
                        }
                        else
                        {
                            mensajeRespuesta = await respuestaConsulta.Content.ReadAsStringAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    tipoRespuesta = 3;
                    mensajeRespuesta = ex.Message;
                }
            }
        }


        private async Task SubeFotos()
        {
          await CargaPH();
        }
      
       /*
        private byte[] RedimencionaIMG(string path)
        {
            byte[] pic;
            using (MagickImage imk = new MagickImage(path))
            {
                imk.Resize(1000, 0);
                pic = imk.ToByteArray();

            }
            return pic;

        }
       */
        private void AltaEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private async void llenaCampos()
        {
            try
            {
                Servicios datos = new Servicios();

                var lst2 = await datos.llenaSuc();

                sucEntrada.DisplayMember = "C2";
                sucEntrada.ValueMember = "C1";
                sucEntrada.DataSource = lst2;
                foreach (var i in from Sucursales i in sucEntrada.Items
                                  where i.c1.Trim() == sucursalGlobal.Trim()
                                  select i)
                {
                    sucEntrada.SelectedValue = i.c1;
                    break;
                }

                var lstTiposEnt = await datos.LlenaTiposEnt();
                cmbTipoEnt.DisplayMember = "NombreTipoEntrada";
                cmbTipoEnt.ValueMember = "TipoEntradaID";
                cmbTipoEnt.DataSource = lstTiposEnt;
                
                cargaultent();

                lblUser.Text = CacheLogin.username;

                var lst1 = await datos.llenaCord();
                cord.ValueMember = "C2";
                cord.DisplayMember = "C3";
                cord.DataSource = lst1;



                List<Sucursales> lst3 = new List<Sucursales>(lst2); //clonamos la lista anterior para no volver a hacer la busqueda en la base de datos 

                //var lst3                = sucEntrada.DataSource;
                sucDestino.DisplayMember = "C2";
                sucDestino.ValueMember = "C1";
                sucDestino.DataSource = lst3;

                var lst4 = await datos.llenaProveedores();

                proveedor.DisplayMember = "C3";
                proveedor.ValueMember = "C2";
                proveedor.DataSource = lst4;

                var lst5 = await datos.llenaPieza();

                cmbUnidades.DisplayMember = "C2";
                cmbUnidades.ValueMember = "C1";
                cmbUnidades.DataSource = lst5;

                var lst6 = await datos.llenaPeso();

                cmbPeso.DisplayMember = "C2";
                cmbPeso.ValueMember = "C1";
                cmbPeso.DataSource = lst6;


                var lst7 = await datos.llenaOpera();

                tipoOper.DisplayMember = "C2";
                tipoOper.ValueMember = "C1";
                tipoOper.DataSource = lst7;

                //

                foreach (var i in await datos.generaRastreo())
                {
                    tbxRastreo.Text = i.c1.ToString();
                }

                


                Cargaparidad();
                cargafecha();
                Moneda();






            }
            catch (Exception)
            {

                throw;
            }

        }


        #region //funciones para autocompletar
        private async Task<AutoCompleteStringCollection> proveeList()
        {
            AutoCompleteStringCollection List = new AutoCompleteStringCollection();
            Servicios datos = new Servicios();
            var lst = await datos.llenaProveedores();

            foreach (var p in lst)
            {
                List.Add(p.c3);
            }


            return List;
        }



        #endregion



        private void gunaTileButton1_Click(object sender, EventArgs e) //abre el formulario de busqueda con datos de cliente
        {
            using (VistaEntrada.BusquedasEnt buscador = new BusquedasEnt())
            {
                buscador.label2.Text = "CLIENTE";
                buscador.pasado += new BusquedasEnt.pasar(moverinfo);
                buscador.ShowDialog();
                buscador.pasado -= new BusquedasEnt.pasar(moverinfo);
            }
            
           
        }
        string coreoClientes;
        public void moverinfo(string dato, string dato2, string dato3, string dato4, string dato5, string dato6, string dato7, string correoCliente, int bandera,string codigoPostal, string parentName, string parentId) //cambia los datos de los textbox alias y clientes, la bandera dependera de la manera en la que se haya abierto el frm buscar, 0 clientes 1 alias, ADEMAS tambien sirve para cambiar el campo de cord
        {
            label24.Text = "";
            label25.Text = "";
            coreoClientes = "";
            coreoClientes = correoCliente;
            lblParentName.Text = parentName;
            lblParentId.Text = parentId;
            lblZipCode.Text = codigoPostal;
            if (bandera == 0) //clientes
            {
                cliente.Text = dato;
                alias.Text = dato2;
                label23.Text = dato4;
                label24.Text = dato5;
                label25.Text = dato6;
                
                label26.Text = "SU";
                lblCodCliente.Text = dato7;

                cord.SelectedValue = dato4??"";

                /*foreach (vmCordinadores i in cord.Items)
                {
                    if (i.c2.Trim() == dato3)
                    {
                        cord.SelectedValue = i.c2;
                        break;
                    }
                }*/
            }

            else if (bandera == 1)//alias
            {
                alias.Text = dato;
                cliente.Text = dato2;
                label23.Text = dato4;
                label24.Text = dato5;
                label25.Text = dato6;
                label26.Text = "Dir Alias";
                lblCodCliente.Text = dato7;
                foreach (vmCordinadores i in cord.Items)
                {
                    if (i.c2.Trim() == dato3)
                    {
                        cord.SelectedValue = i.c2;
                        break;

                    }

                }
            }
        }


        private void gunaTileButton2_Click(object sender, EventArgs e) //abre el formulario de busqueda con datos de alias
        {
            VistaEntrada.BusquedasEnt buscador = new BusquedasEnt();
            buscador.label2.Text = "ALIAS";
            buscador.pasado += new BusquedasEnt.pasar(moverinfo);
            buscador.ShowDialog();
        }

        private void cliente_TextChanged(object sender, EventArgs e)
        {
          //  cord.Text = alias.Text;
        }

        private void proveedor_Leave(object sender, EventArgs e)
        {
            int bandera = 0;
            foreach (Proveedores d in proveedor.Items)
            {
                string dato = proveedor.Text.ToString().Trim();

                if (d.c3.Trim() == dato)
                {
                    bandera = 1;
                    break;
                }

            }
            if (bandera == 0)
            {
                MessageBox.Show("El proveedor que has ingresado es incorrecto por favor, busca y selecciona uno de los resultados.");
                proveedor.Focus();
            }
        }


        private void coloresSucursales()//cambia los coleres del control de seleccion de sucursales
        {

        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "@C:\\";
            openFileDialog1.Filter = "Solo documentos (PDF,WORD)|*.PDF;*.DOCX"; ;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string doc = openFileDialog1.FileName;
                    if (label27.Text == "")
                    {
                        label27.Text = doc;
                    }
                    else
                    {
                        label28.Text = doc;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        List<string> larch = new List<string>();
        private void AgregaArchivos()
        {
            larch.Clear();
            if (label27.Text != "")
            {
                larch.Add(label27.Text);
            }
            if (label28.Text != "")
            {
                larch.Add(label28.Text);
            }


        }

        public async void Cargaparidad()
        {/*
            Servicio datos = new Servicio();
            string paridad1 = await datos.GetParidad();
            var lst = JsonConvert.DeserializeObject<Root>(paridad1);

            //var lst = JsonConvert.DeserializeObject<List<Paridad>>(paridad1);
            //Paridad lst = JsonConvert.DeserializeObject<ListParidad>>(paridad1);

            var lista = from d in lst.ListaIndicadores.Where(c => c.codTipoIndicador == 158)

                        select new ListaIndicadore
                        {
                            valor = d.valor

                        };

            if (lista.Count() <= 0)
            {
                if (MessageBox.Show("No pudimos acceder a la paridad del Diario Oficial de la Federación \r(Si es fin de semana los servicios de DOF no funcionan )\rAl hacer click te redireccionare a la pagina oficial para establecerla manualmente", "No paridad automatica", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
                {
                    Process.Start("https://dof.gob.mx/indicadores.php");
                }
                lblParidad.Enabled = true;
                lblParidad.ReadOnly = false;
            }
            else
            {


                foreach (var i in lista.ToList())
                {
                    lblParidad.Text = i.valor.ToString();
                }
            }

            */

        }


        private async void cargafecha()
        {
            /* Servicio datos = new Servicio();
             string fecha1 = await datos.fechaLapaz();
             //List<FechaActual> lst = JsonConvert.DeserializeObject<List<FechaActual>>(paridad1);
             //var lst = JsonConvert.DeserializeObject<List<FechaActual>>(fecha1);
             FechaActual lst = JsonConvert.DeserializeObject<FechaActual>(fecha1);

             lblFecha.Text = lst.datetime.Date.ToString("MM/dd/yyyy");
            */
            Servicio datos = new Servicio();
            string fecha1 = await datos.fechaLapaz();
            DateTime fecha;
            if (!DateTime.TryParseExact(fecha1, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
            {
                fecha = DateTime.Now; // establecer la fecha del equipo en caso de que falle la conversión
            }
            lblFecha.Text = fecha.ToString("MM/dd/yyyy");

        }

        private DateTime regresafecha()
        {
            Servicio datos = new Servicio();
            try
            {
                string fecha1 =  datos.fechaLapazNoAsyc();
                FechaActual lst = JsonConvert.DeserializeObject<FechaActual>(fecha1);
                DateTime fechaActual = lst.datetime;
                return fechaActual;
            }
            catch (Exception ex)
            {
                // Si hay una excepción, devuelve la fecha actual del equipo
                return DateTime.Now;
            }
        }




        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbMoneda.SelectedValue) == 1)
            {
                lblParidad.Text = "";
            }
            else if (Convert.ToInt32(cmbMoneda.SelectedValue) == 2)
            {
                if (String.IsNullOrWhiteSpace(lblParidad.Text))
                {
                    Cargaparidad();
                }
                
            }
        }




        private void gunaMediumRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            rdbNoPagado.Enabled = false;
            rdbPagado.Enabled = true;
        }



        private void gunaMediumRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            rdbPagado.Enabled = false;
        }

        private void gunaTileButton3_Click(object sender, EventArgs e)
        {

            if (rdbNoPagado.Checked == true)
            {
                MessageBox.Show("Para liberar una entrada primero tiene que estar pagada");
                return;

            }
            VistaEntrada.Desbloqueo buscador = new Desbloqueo();

            buscador.cambiar += new Desbloqueo.cambio(deledesbloqueo);
            buscador.ShowDialog();
        }

        public void deledesbloqueo(bool dato)
        {
            if (dato == true)
            {
                rdbNoPagado.Enabled = true;
            }
            else
            {
                rdbNoPagado.Enabled = false;
            }

        }

        private void Moneda()
        {
            List<Moneda> mnd = new List<Moneda> {
                         new Moneda{id=2,moneda="DLLS"},
                         new Moneda{id=1,moneda="PESOS"}};

            var lista = from d in mnd
                        select new Moneda
                        {
                            id = d.id,
                            moneda = d.moneda

                        };
            lista = lista.ToList();

            cmbMoneda.DisplayMember = "moneda";
            cmbMoneda.ValueMember = "id";
            cmbMoneda.DataSource = lista;

        }

        private void sucEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (tipodeDocumento == 1)
            {
                cargaultent();
            }
            else
            {
                txbBuscarEnt.Text = "";
                lblEntrada.Text = "";
            }

        }
        private void cargaultent()
        {
            Servicios datos = new Servicios();

            foreach (var i in datos.NumeroEntrada(sucEntrada.SelectedValue.ToString(), 35))
            {
                int numero = Convert.ToInt32(i.entrada)/* + 1*/;
                lblEntrada.Text = numero.ToString("D7");
                noEntGlobal = numero.ToString("D7");
            }


        }
        private string recuperUltimaent()
        {
            Servicios datos = new Servicios();
            string dato = default;
            foreach (var i in datos.NumeroEntrada(sucEntrada.SelectedValue.ToString(), 35))
            {
                int numero = Convert.ToInt32(i.entrada)/* + 1*/;
                dato = numero.ToString("D7");
            }
            noEntGlobal = dato;
            lblEntrada.Text = noEntGlobal;
            return dato;
        }


        private void label27_DoubleClick(object sender, EventArgs e) //borra doc
        {
            System.Windows.Forms.Label pic = (System.Windows.Forms.Label)sender;
            if (tipodeDocumento == 1)
            {
                pic.Text = "";
            }
            else if (tipodeDocumento == 2)
            {


            }
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            regresafecha();
        }


        public void limpiaImg()
        {
            if (dgvDocs.Rows.Count>0)
            {
                dgvDocs.Rows.Clear();
                dgvDocs.Refresh();
            }


            if (dgvFotosModifi.Rows.Count>0)
            {

                dgvFotosModifi.DataSource = null;

            }

        }

        //
        // Notificaciones-------------------------------------------------------------------------------------------------------------------------------
        //

        private void NotificaEmail(int nttipo, string ntentrada, string ntcliente)
        {
            /*
             0 = ERROR
             1 = EXITO
            */

            if (nttipo == 1)
            {
                notifyIcon1.Icon = SystemIcons.Information;
                notifyIcon1.Visible = true;
                notifyIcon1.Text = ntentrada + " Enviado";
                notifyIcon1.BalloonTipTitle = "EXITO: Email Correcto " + ntentrada;
                notifyIcon1.BalloonTipText = "El email de la entrada " + ntentrada + " ha sido enviado correctamente\r\nCliente: " + ntcliente;
                notifyIcon1.ShowBalloonTip(10000);

            }
            else if (nttipo == 2)
            {
                notifyIcon1.Icon = SystemIcons.Warning;
                notifyIcon1.Visible = true;
                notifyIcon1.Text = ntentrada + " ERROR: El email NO se ha enviado";
                notifyIcon1.BalloonTipTitle = "ERROR: Email Correcto " + ntentrada;
                notifyIcon1.BalloonTipText = "El email de la entrada " + ntentrada + "NO ha sido enviado\r\nCliente: " + ntcliente;
                notifyIcon1.ShowBalloonTip(10000);

            }

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
        }

        //
        // Notificaciones-------------------------------------------------------------------------------------------------------------------------------
        //
        private void button1_Click_2(object sender, EventArgs e)
        {
            ReiniciaInfo(1);
            //abreModifica();

        }
        private async void GeneraRastreo()
        {
            Servicios datos = new Servicios();
            foreach (var i in await datos.generaRastreo())
            {
                tbxRastreo.Text = i.c1.ToString();
            }
        }

        public void ReiniciaInfo(int msn) // reinicia los valores para una nueva entrada
        {
            if (msn == 1) // 1 muestra mensaje
            {
                if (MessageBox.Show("Estas seguro de que deseas reiniciar todo los datos?", "Cuidado!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    // sucEntrada.SelectedIndex = 0;
                    //datoEntrada               = recuperUltimaent();
                    try
                    {
                        foreach (var i in from Sucursales i in sucEntrada.Items
                                          where i.c1.Trim() == sucursalGlobal.Trim()
                                          select i)
                        {
                            sucEntrada.SelectedValue = i.c1;
                            break;
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("No se pudo establecer la Suc Global");
                    }

                    cargaultent();
                    cmbMoneda.SelectedIndex = 0;
                    cmbTipoEnt.SelectedIndex = 0;
                    //regresafecha();
                    cargafecha();
                    lblTotalArchivos.Text = "...";
                    lblCodCliente.Text = default;
                    cord.SelectedIndex = 0;
                    txbValArn.Text = "1";
                    lblParentName.Text = default;
                    lblParentId.Text = default;
                    cliente.Text = default;
                    label23.Text = default;
                    label24.Text = default;
                    label25.Text = default;
                    txbValFact.Text = "1";
                    lblParidad.Text = default;
                    tbxRastreo.Text = default;
                    proveedor.SelectedIndex = 0;
                    ordenCompra.Text = default;
                    numFlete.Text = default;
                    unidades.Text = default;
                    cmbUnidades.SelectedIndex = 0;
                    peso.Text = default;
                    cmbPeso.SelectedIndex = 0;
                    tipoOper.SelectedIndex = 0;
                    sucDestino.SelectedIndex = 0;
                    bultos.Text = default;
                    alias.Text = default;
                    txbNotas.Text = default;
                    txbReferencia.Text = default;
                    label27.Text = default;
                    label28.Text = default;
                    detalles.Text = default;
                    lblUser.Text = CacheLogin.username;
                    mdfImg.Visible = false;
                    iconButton2.Enabled = true;
                    cbxDano.Enabled = true;
                    cbxIsRevisada.Checked = false;
                    lblZipCode.Text = default;

                    limpiaImg();
                    GeneraRastreo();
                    Cargaparidad();

                }
                return;

            }
            else if (msn == 0)
            {
               // sucEntrada.SelectedIndex = 0;
                foreach (var i in from Sucursales i in sucEntrada.Items
                                  where i.c1.Trim() == sucursalGlobal.Trim()
                                  select i)
                {
                    sucEntrada.SelectedValue = i.c1;
                    break;
                }
                //datoEntrada               = recuperUltimaent();
                cargaultent();
                cmbMoneda.SelectedIndex = 0;
                //regresafecha();
                cargafecha();
                lblCodCliente.Text = default;
                cord.SelectedIndex = 0;
                txbValArn.Text = "1";
                cliente.Text = default;
                label23.Text = default;
                label24.Text = default;
                label25.Text = default;
                txbValFact.Text = "1";
                lblParidad.Text = default;
                tbxRastreo.Text = default;
                proveedor.SelectedIndex = 0;
                ordenCompra.Text = default;
                numFlete.Text = default;
                unidades.Text = default;
                cmbUnidades.SelectedIndex = 0;
                peso.Text = default;
                cmbPeso.SelectedIndex = 0;
                tipoOper.SelectedIndex = 0;
                sucDestino.SelectedIndex = 0;
                bultos.Text = default;
                alias.Text = default;
                txbNotas.Text = default;
                txbReferencia.Text = default;
                label27.Text = default;
                label28.Text = default;
                detalles.Text = default;
                lblUser.Text = CacheLogin.username;
                cbxIsRevisada.Checked = false;
                limpiaImg();
                GeneraRastreo();
                Cargaparidad();
            }


        }

       
       
        #region INICIO DE MODIFICA ENTRAD__________________________________________________________________________________________________________________________________

        public void CambiaDocumento(int dato)
        {
            if (dato == 1)//Abre alta entrada
            {

                tipodeDocumento = dato;
                gunaTileButton5.Visible = false;
                btnBuscarEnt.Visible = false;
                txbBuscarEnt.Visible = false;
                lblBuscarEnt.Visible = false;
                btnAgregarBultos.Visible = false;

                dgvFotosModifi.Visible = false;
                dgvFotosModifi.Enabled = false;

                dgvDocs.Enabled = true;
                dgvDocs.Visible = true;


                abreModifica(true);
                ReiniciaInfo(1);
                limpiaImg();

            }
            if (dato == 2) //Modificacion
            {
                tipodeDocumento = dato;
                InicioModifica();
            }


        }
        private void InicioModifica()
        {
            lblZipCode.Text = default;
            cmbTipoEnt.SelectedIndex = 0;
            gunaTileButton5.Visible = true;
            txbBuscarEnt.Text = default;
            btnBuscarEnt.Visible = true;
            txbBuscarEnt.Visible = true;
            lblBuscarEnt.Visible = true;
            btnAgregarBultos.Visible = true;

            dgvFotosModifi.Visible = true;
            dgvFotosModifi.Enabled = true;

            dgvDocs.Enabled = false;
            dgvDocs.Visible = false;

            iconButton2.Enabled = false;
            sbeArchivos = "";
            mdfImg.Visible = true;
            cbxDestinoModify.Visible = true;
            cbxDestinoModify.Enable = true;
            sucDestino.Enabled = false;
            cbxDano.Checked = false;
            cbxIsRevisada.Checked = false;
            abreModifica(false);

            try
            {
                foreach (var i in from Sucursales i in sucEntrada.Items
                                  where i.c1.Trim() == sucursalGlobal.Trim()
                                  select i)
                {
                    sucEntrada.SelectedValue = i.c1;
                    break;
                }


            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo establecer la Suc Global");
            }
            limpiaImg();

        }

        private void abreModifica(bool estatus)
        {

            //tipodeDocumento = tipo;

            //if  (MessageBox.Show("Estas seguro de que deseas cambiar a la pestaña?", "Cuidado!", MessageBoxButtons.OKCancel) == DialogResult.OK)

            //{



            //sucEntrada.SelectedIndex = 0;
            //sucEntrada.Enabled      = estatus;

            //cmbMoneda.SelectedIndex = 1;
            //cmbMoneda.Enabled         = estatus;
            lblTotalArchivos.Text = "...";

            lblCodCliente.Text = default;
            lblCodCliente.Enabled = estatus;

            cord.SelectedIndex = 0;
            //cord.Enabled            = estatus;

            lblParentId.Text = default;
            lblParentName.Text = default;
            cliente.Text = default;
            cliente.Enabled = estatus;

            proveedor.SelectedIndex = 0;
            proveedor.Enabled = estatus;

            ordenCompra.Text = default;
            ordenCompra.Enabled = true;

            numFlete.Text = default;
            numFlete.Enabled = true;

            unidades.Text = default;
            unidades.Enabled = estatus;

            cmbUnidades.SelectedIndex = 0;
            cmbUnidades.Enabled = estatus;

            peso.Text = default;
            peso.Enabled = estatus;

            cmbPeso.SelectedIndex = 0;
            cmbPeso.Enabled = estatus;



            bultos.Text = default;
            bultos.Enabled = estatus;

            alias.Text = default;
            alias.Enabled = estatus;

            gunaTileButton1.Enabled = true;
            gunaTileButton2.Enabled = true;

            detalles.Enabled = estatus;
           


            if (estatus != true)
            {
                txbNotas.Text = default;
                txbReferencia.Text = default;
                txbValFact.Text = "1";
                txbValArn.Text = "1";
                tipoOper.SelectedIndex = 0;
                sucDestino.SelectedIndex = 0;
                detalles.Text = default;
                tbxRastreo.Text = default;

                lblParidad.Text = default;
                label23.Text = default;
                label24.Text = default;
                label25.Text = default;
                label27.Text = default;
                label28.Text = default;
                lblEntrada.Text = default;
                lblFecha.Text = default;

            }




            //}

        }
        private void btnBuscarEnt_Click(object sender, EventArgs e)
        {
            Funciones_para_Busqueda();

        }
        private void txbBuscarEnt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
 
                Funciones_para_Busqueda();

            }
        }
        private async void Funciones_para_Busqueda()
        {
            int valida = Validaciones_P_Busqueda();
            if (valida == 1)
            {
                cmbTipoEnt.SelectedIndex = 0;
                LimpiaIMG2();
                if (Busqueda_Entrada(txbBuscarEnt.Text.Trim(), sucEntrada.SelectedValue.ToString().Trim()) == 0)
                {
                    return;
                }
                
                SelectorFotos(sucEntrada.SelectedValue.ToString().Trim() + "-UD3501-" + txbBuscarEnt.Text.Trim());
                //CargaFotos(txbBuscarEnt.Text.Trim(), sucEntrada.SelectedValue.ToString().Trim());
                //CargaDocPDF();

                var dataClientes = await _odooClient.GetClientById(String.IsNullOrWhiteSpace(lblCodCliente.Text) ? "3558" : lblCodCliente.Text);
                coreoClientes = dataClientes.Email.Trim();
                label27.Text = "";
                label28.Text = "";
                lblZipCode.Text = dataClientes.Zip?.Trim();

                //  detalles.Enabled = false;

                detalles.Enabled = true;
                    detalles.ReadOnly = true;
                
            }

        }
        private int Validaciones_P_Busqueda() //Validacion primitiva antes de hacer la busqueda de entrada
        {
            if (txbBuscarEnt.Text == "")
            {
                MessageBox.Show("El campo de busqueda esta vacio!");
                return 2;
            }
            int datparseado;
            bool bent = Int32.TryParse(txbBuscarEnt.Text, out datparseado);
            if (bent == true)
            {
                txbBuscarEnt.Text = datparseado.ToString("D7");
                return 1;
            }
            else
            {
                MessageBox.Show("Las entradas tienen que ser un codigo numerico, y no pueden contener letras");
                return 2;
            }

        }

        //--------------------------------------------------------------*
        // Busqueda_Entrada(string id, string sucursal) 
        // Trae los valores de la bd y los asgina al frm
        //--------------------------------------------------------------*
        private int Busqueda_Entrada(string id, string sucursal)
        {
            Servicios datos = new Servicios();
            var lst = datos.LLenaEntradaByID(id, sucursal);
            int bandera = 0;
            if (lst.Count < 1)
            {
                MessageBox.Show("Entrada no encontrada", "Esta bien escrito todo?");
                return bandera = 0;
            }


            foreach (var q in lst)
            {
                //-------Sucursal inicia---------------
                foreach (Sucursales i in sucEntrada.Items)
                {
                    if (i.c1.Trim() == q.C1.Trim())
                    {
                        sucEntrada.SelectedValue = i.c1;
                        break;

                    }

                }
                //-----------------------------------

                //-------Tipo Entrada---------------
                foreach (vmTipoEntrada i in cmbTipoEnt.Items)
                {
                    if (i.TipoEntradaID == q.tipoEntrada)
                    {
                        cmbTipoEnt.SelectedValue = i.TipoEntradaID;
                        break;

                    }

                }
                //-----------------------------------
                entradaBusqueda = q.C6.Trim();
                lblEntrada.Text = q.C6.Trim();
                //cmbMoneda.Text = q.C7;
                cmbMoneda.Text = q.C7.Trim();
                lblFecha.Text = q.C9.Value.Date.ToString("MM/dd/yyyy");
                lblCodCliente.Text = q.C10.Trim();
                string vtxtref = q.C11 ?? "";
                txbReferencia.Text = vtxtref.Trim();

                //--------Coordinador asignado-------------------
                //foreach (vmCordinadores i in cord.Items)
                //{
                //    if (i.c2.Trim() == q.C12.Trim())
                //    {
                //        cord.SelectedValue = i.c2;
                //        break;

                //    }

                //}

                txbValArn.Text = q.C16.ToString().Trim();
                txbNotas.Text = q.C24?.Trim();
                cliente.Text = q.C112.Trim();
                //alias.Text = q.C112.Trim();
                lblParidad.Text = q.C40.ToString().Trim();
                tbxRastreo.Text = q.C80.Trim();
                lblUser.Text = q.C81.Trim();


                //------proveedores-------------------
                foreach (Proveedores i in proveedor.Items)
                {
                    if (i.c2.Trim() == q.C92.Trim())
                    {
                        proveedor.SelectedValue = i.c2;
                        break;

                    }

                }

                ordenCompra.Text = q.C93.Trim();
                numFlete.Text = q.C95.Trim();
                unidades.Text = Convert.ToInt32(q.C97).ToString().Trim();

                //------Tipo de unidad-----------
                foreach (vmPiezas i in cmbUnidades.Items)
                {
                    if (i.c1.Trim() == q.C98.Trim())
                    {
                        cmbUnidades.SelectedValue = i.c1;
                        break;

                    }

                }
                cbxDano.Checked = q.C27?.Contains("1") ?? false;
                cbxIsRevisada.Checked = q.isReviwed ?? false;

                peso.Text = q.C99.ToString();

                //------Peso-------------------
                foreach (vmPeso i in cmbPeso.Items)
                {
                    if (i.c1.Trim() == q.C100.Trim())
                    {
                        cmbPeso.SelectedValue = i.c1;
                        break;

                    }

                }

                foreach (vmTOperacion i in tipoOper.Items)
                {
                    if (i.c1.Trim() == q.C101.Trim())
                    {
                        tipoOper.SelectedValue = i.c1;
                        break;
                    }
                }
                
                tipoOper.Text = 
                txbValFact.Text = q.C102.Trim();

                //-------Sucursal destino---------------
                foreach (Sucursales i in sucDestino.Items)
                {
                    if (i.c1.Trim() == q.C103.Trim())
                    {
                        sucDestino.SelectedValue = i.c1;
                        break;

                    }

                }
                //-----------------------------------

                bultos.Text = Convert.ToInt32(q.C108).ToString().Trim();
                detalles.Text = q.descripcion.Trim();
                label24.Text = q.C12;
                label23.Text = q.odoosalesp;
                lblNoOdoo.Text = q.OdooId?.ToString() ?? "0";
                lblParentName.Text = q?.C32 ?? "";
                lblParentId.Text = q?.C17 ?? "";
                string rbt = q.C44 ?? "NoPagado";
                RDBpagar(rbt.Trim());
                bandera = 1;
                // alias.Text = q.C112;
            }
            return bandera;
        }

        //--------------------------------------------------------------*
        // RDBpagar(string dato)
        // Establece de acuerdo a los datos de la bd si los radio de pagado o no pagado deben de estar activos o no
        //--------------------------------------------------------------*
        private void RDBpagar(string dato)
        {
            if (dato == "Pagado")
            {
                rdbPagado.Checked = true;
                rdbNoPagado.Checked = false;
                rdbNoPagado.Enabled = false;
                rdbPagado.Enabled = false;
            }
            else if (dato == "NoPagado")
            {
                rdbPagado.Checked = false;
                rdbNoPagado.Checked = true;
                rdbNoPagado.Enabled = false;
                //rdbPagado.Enabled = false;
            }

        }

        //--------------------------------------------------------------*
        // updateDatos(string pagado)
        // Obtiene los datos a modificar y los manda a la funcion de UPDATEKDM1
        //--------------------------------------------------------------*
        private void updateDatos(string pagado)
        {
            string datoSucOrigen = sucEntrada.SelectedValue.ToString().Trim();
            string datoSucDestino = sucDestino.SelectedValue.ToString().Trim();
            string datoNoCord = label24.Text;
            string datoNota = txbNotas.Text.Trim();
            string datoReferencia = txbReferencia.Text.Trim();
            string datoTipoOper = tipoOper.SelectedValue.ToString().Trim();
            string datoValFact = txbValFact.Text.Trim();
            string datoValArn = txbValArn.Text.Trim() == ""? "1" : txbValArn.Text.Trim();
            string datoEntrada = lblEntrada.Text.Trim() == "" ? "1" : lblEntrada.Text.Trim();
            string datoDescripcion = detalles.Text.Trim();
            string datoNoFlete = numFlete.Text.Trim();
            string datoOrConpra = ordenCompra.Text.Trim();
            string datoParentId = String.IsNullOrWhiteSpace(lblParentId.Text) || lblParentId.Text == "false" ? "" : lblParentId.Text;


            string datoNuCliente = lblCodCliente.Text;
            string datoNomCliente = String.IsNullOrWhiteSpace(lblParentName.Text) || lblParentName.Text == "false" ? cliente.Text : lblParentName.Text;
            string datoCalle = label23.Text;
            string datoColonia = label24.Text;
            string datoCiudadZip = lblZipCode.Text;
            string datoProvedor = proveedor.SelectedValue.ToString();
            string datosAlias = cliente.Text;
            int tpoEntrada = Convert.ToInt32(cmbTipoEnt.SelectedValue);
            string isDanado = cbxDano.Checked == true ? "1" : "0"; //representa una entrada dañanada, se guarda por entrada completa, no por bulto en el campo 27 de kdm1 1 si esta dañada 0 si no lo esta
            string odoosalesp = label23.Text;

            DateTime datoFecha = regresafecha();

            if (ContainsUrl(datoDescripcion))
            {
                if (!ContainsOnlyGoogleDriveUrls(datoDescripcion))
                {
                    MessageBox.Show("Solo se permiten URLs de Google Drive. Por favor, revise la descripción.");
                    return; // Sale de la función si hay URLs no permitidas
                }
            }

            AltasBD bd = new AltasBD();
            try
            {
                bd.UpdateKDM1(datoEntrada, datoSucDestino, datoNoCord, datoNota, datoReferencia, pagado, datoTipoOper, datoValFact, datoValArn, datoSucOrigen, datoNoFlete, datoOrConpra,
                    datoNuCliente,datoNomCliente,datoCalle,datoColonia,datoCiudadZip,datoProvedor, datosAlias, datoFecha, tpoEntrada, isDanado, odoosalesp, datoParentId, cbxIsRevisada.Checked);
                if (detalles.Enabled == true)
                {
                    bd.UpdateKDM1Coment(datoEntrada, datoSucOrigen, datoDescripcion);
                }
                if (cbxDestinoModify.Checked == true)
                {
                    bd.UpdateKDMentSuc(datoEntrada, datoSucOrigen, datoSucDestino);
                }
                if (detalles.Enabled == true && detalles.ReadOnly == false)
                {
                    GeneralMovimientosLog.AddMovimientoConParametrosDirectos(datoEntrada, 35, "", 35, "", datoSucOrigen, datoSucDestino, datoNoCord, "Modifica", "", $"{Negocios.Common.Cache.CacheLogin.nombre} modifica la descripcion a: " + detalles.Text);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
           
        }

        private bool ContainsUrl(string text)
        {
            string urlPattern = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
            return Regex.IsMatch(text, urlPattern);
        }

        // Función auxiliar para verificar si todas las URLs son de Google Drive
        private bool ContainsOnlyGoogleDriveUrls(string text)
        {
            string urlPattern = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
            MatchCollection matches = Regex.Matches(text, urlPattern);

            foreach (Match match in matches)
            {
                string url = match.Value;
                if (!url.Contains("drive.google.com"))
                {
                    return false;
                }
            }

            return true;
        }



        //--------------------------------------------------------------*
        // LimpiaIMG2()
        // Establece como null las propiedades de Image e ImageLocation de los picturebox NO HACE DISPOSE.
        //--------------------------------------------------------------*
        public void LimpiaIMG2()
        {
            dgvFotosModifi.DataSource = null;
        }

        //Carga el nombre de los archivos en la taba
        private async void SelectorFotos(string entrada)
        {
            dgvFotosModifi.DataSource = null;

            string nombreArchivo = entrada;
            int tipoRespuesta = 2;
            string mensajeRespuesta = "";
            if (!string.IsNullOrWhiteSpace(nombreArchivo))
            {
                var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{usernameapi}:{passwordapi}")));
                using (var clientHandler = new HttpClientHandler { Credentials = new CredentialCache { { new Uri("http://104.198.241.64:90/"), "Basic", new NetworkCredential(usernameapi, passwordapi) } } })

                    try
                    {
                    using (HttpClient cliente = new HttpClient())
                    {
                        string url = "http://104.198.241.64:90/api/Archivo/getls/?nombreArchivo=" + nombreArchivo;
                            cliente.DefaultRequestHeaders.Authorization = authValue;
                            using (HttpResponseMessage respuestaConsulta = await cliente.GetAsync(url))
                        {
                            using (HttpContent cn = respuestaConsulta.Content)
                            {
                                  
                                    string contenido = await respuestaConsulta.Content.ReadAsStringAsync();
                                if (respuestaConsulta.IsSuccessStatusCode)
                                {
                                    List<FotoInicioVM> jds = JsonConvert.DeserializeObject<List<FotoInicioVM>>(contenido);

                                    dgvFotosModifi.DataSource = jds;
                                }
                            }
                        }
                    }
                }
                catch
                {

                }
            }
        }

        private void Abre()
        {

        }

        private async Task DescargaDocs(string dato)
        {
            string nombreArchivo = dato.Trim();
            int tipoRespuesta = 2;
            string mensajeRespuesta = "";

            if (!string.IsNullOrWhiteSpace(nombreArchivo))
            {
                var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{usernameapi}:{passwordapi}")));

                _client.DefaultRequestHeaders.Authorization = authValue;

                try
                {
                    string url = "http://104.198.241.64:90/api/Archivo/?nombreArchivo=" + nombreArchivo;
                    using (HttpResponseMessage respuestaConsulta = await _client.GetAsync(url)) // usar _client aquí
                    {
                        if (respuestaConsulta.IsSuccessStatusCode)
                        {
                            byte[] arrContenido = await respuestaConsulta.Content.ReadAsAsync<byte[]>();

                            string path = AppDomain.CurrentDomain.BaseDirectory;
                            string folder = path + "\\temp\\";
                            string fullFilePath = folder + dato;

                            if (File.Exists(fullFilePath))
                                File.Delete(fullFilePath);

                            if (!Directory.Exists(folder))
                                Directory.CreateDirectory(folder);

                            File.WriteAllBytes(fullFilePath, arrContenido);

                            tipoRespuesta = 1;
                            // mensajeRespuesta = "Se descargó correctamente el archivo " + nombreArchivo;
                            Process.Start(fullFilePath);
                        }
                        else
                        {
                            mensajeRespuesta = await respuestaConsulta.Content.ReadAsStringAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    tipoRespuesta = 3;
                    mensajeRespuesta = ex.Message;
                }
            }
        }


        private async Task CargaPH()
        {
            List<string> archivos = new List<string>();
            try
            {
               
                if (dgvDocs.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvDocs.Rows)
                    {
                        archivos.Add(row.Cells[1].Value.ToString());

                    }

                    foreach (var q in archivos)
                    {
                        string mensajeRespuesta = "";
                        int tipoRespuesta = 2;
                        string nombreCompletoArchivo = q;
                        byte[] arrContenido = null;

                        using (FileStream fs = new FileStream(nombreCompletoArchivo, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            arrContenido = new byte[fs.Length];
                            await fs.ReadAsync(arrContenido, 0, arrContenido.Length);
                        }
                        if (arrContenido == null) mensajeRespuesta = "Ocurrió un inconveniente al obtener el contenido del archivo " + nombreCompletoArchivo;
                        else
                        {
                            var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{usernameapi}:{passwordapi}")));
                            using (var clientHandler = new HttpClientHandler { Credentials = new CredentialCache { { new Uri("http://104.198.241.64:90/"), "Basic", new NetworkCredential(usernameapi, passwordapi) } } }) ;

                            string url = "http://104.198.241.64:90/api/Archivo";
                            using (HttpClient cliente = new HttpClient())
                            {
                                cliente.DefaultRequestHeaders.Authorization = authValue;
                                string nombreArchivo = sucEntrada.SelectedValue.ToString().Trim() + "-UD3501-" + lblEntrada.Text.Trim() + "_" + System.IO.Path.GetFileName(nombreCompletoArchivo);
                                MultipartFormDataContent frm = new MultipartFormDataContent();
                                frm.Add(new StringContent(nombreArchivo), "nombreArchivo");
                                frm.Add(new StringContent("1"), "idEstado");
                                frm.Add(new ByteArrayContent(arrContenido), "contenido", nombreArchivo);
                                using (HttpResponseMessage resultadoConsulta = await cliente.PostAsync(url, frm))
                                {
                                    mensajeRespuesta = await resultadoConsulta.Content.ReadAsStringAsync();
                                    if (resultadoConsulta.IsSuccessStatusCode)
                                        tipoRespuesta = 1;
                                    else
                                        tipoRespuesta = 2;
                                }
                            }
                        }

                        /* MessageBoxIcon iconoMensaje;
                         if (tipoRespuesta == 1)
                             iconoMensaje = MessageBoxIcon.Information;
                         else if (tipoRespuesta == 2)
                             iconoMensaje = MessageBoxIcon.Warning;
                         else
                             iconoMensaje = MessageBoxIcon.Error;
                         MessageBox.Show(mensajeRespuesta, "Carga de archivos", MessageBoxButtons.OK, iconoMensaje);
                        */
                    }



                }
            }
            catch (Exception x)
            {

                Negocios.LOGs.ArsLogs.LogEdit(x.Message," No se han cargados las fotos " + DateTime.Now.ToString());
            }
            finally
            {
                archivos.Clear();
            }
           
            
        }



        #endregion Fin de Modifica entrada__________________________________________________________________________________________________________________________________
        private void abreBaja()
        {

        }
        private void abreConsulta()
        {

        }
        /************************************************************
         Aqui cargo las iamgenes de loading, asi como el agregado al contenerdor 
         ************************************************************/
       

        private void iconButton1_Click(object sender, EventArgs e)
        {
            CargaPH();

            //PdfZPLcrea();
            /*
            Reportes.TestReport rp = new Reportes.TestReport();
            //rp.Entrada = lblEntrada.Text;
            //rp.sucursalIni = sucEntrada.SelectedValue.ToString();
            Servicios sv = new Servicios();

            var lst = new List<vmEtiquetasReporte>();
            lst = sv.LlenaEtiquetas(lblEntrada.Text.Trim(), sucEntrada.SelectedValue.ToString().Trim());

            foreach (var q in lst)
            {
                rp.repTOrigen = q.Origen;
                rp.repTdest = q.Destino;
                rp.repTCliente = q.Cliente;
                rp.repTEtiqueta = q.Etiqueta;
                rp.repTEntrada = q.Entrada;
                rp.repTFecha = q.Fecha.Value.Date.ToString();
                rp.repTAlias = q.Alias;
                rp.ShowDialog();
            }

            //string s = "^XA^LH30,30\n^FO20,10^ADN,90,50^AD^FDHello World^FS\n^XZ";
            string s = "^XA^\nFO40,50^GFA,7372,7372,38,,:::::::::::::::::::::::::::::::::W01FF,V03JF,U01KFC,U0MF,T03MF8,T0NFE,S03OF,S0PF8,R03NF7F8,R07NF7FC,Q01OF7FE,Q03OF7FE,Q0PF7FF,P01OFE7FF,P03OFE7FF8,P0PFEIF8,O01PFCIFC,O03PFCIFC,O07PFCIFC,O0QF8IFC,N01QF8IFE,N03QF1IFE,N07QF1IFE,N0RF1IFE,M01QFE9IFE,M03QFEBIFE,M03QFC3IFE,M07QFD3JF,M0RF93JF,L01RF87JF,L01RF07JF,L03RF07JF,L07QFE0JFE,:L0RFC0JFE,L0RF81JFE,K01RF81JFE,K03RF01FFE,K03RF03FF03IF8M03F8K07FCO07IF8N0FF8,K07QFE03FC7KF801IF0LF03IF007FFE007KF801IF03IF,K07QFC07F1LFE01IF1LF07IFC07FFE01LFE01IF0JF8,K0RF807E7MF01FFE3LF1JFC07FFE07MF01FFE3JFC,K0RF807CNF81FFE7FFDIF3JFE07FFC0NF83FFE7JFC,J01RF18F9NF83LF9IF7JFE0IFC1NFC3FFEKFE,J01QFE10F3NFC3LF9OF0IFC3NFC3NFE,J03QFC21F3NFC3LF1OF0IFC3NFC3NFE,J03QFC21E7IF81IFC3KFE1OF0IFC7IF81IFC3NFE,J03QF843EIFE007FFC3KFE3OF0IFC7FFE007FFC3OF,J07QF083CIFC007FFC3KFC3OF0IF8IFC007FFC7NFE,J07PFE083C0FF9007FFC7IFE003IFE0JF1IF80FF8007FFC7IFC1IFE,J0QFC107F8002007FFC7IF8003IF807IF1IF8L07FFC7IF80IFE,J0QF8007IFC601IFC7IF8003IF003IF1IF8K01IFC7IF007FFE,J0QFI0KF81JFC7IFI03IF003IF1IF8J01JFC7FFE007FFE,J0PFEI0JF01KFC7FFEI07FFE003FFE1IFJ01KFC7FFE007FFE,I01PFC001IF03LFCIFEI07FFE003FFE1IFI03LFCIFC007FFE,I01PF8003FFC7MF8IFCI07FFE007FFE3IF007MF8IFC007FFC,I01PFI03FF1NF8IFCI07FFC007FFE3IF01NF8IFC00IFC,I01OFEI07FE7NF8IFCI07FFC007FFE3IF07NF8IFC00IFC,I03OFCI07FDKF9IF8IFCI0IFC007FFE3FFE1KF8IF8IF800IFC,I03OFJ0FFBJF81IF8IF8I0IFC007FFC3FFE1JF81IF9IF800IFC,I03NFEJ0FF3IFC01IF1IF8I0IFC00IFC7FFE3IFC01IF9IF800IFC,I03NFCI01FE7IF001IF1IF8I0IF800IFC7FFE7IF001IF1IF801IF8,I03NF80403FE7FFE003IF1IF8I0IF800IFC7FFE7FFE003IF1IF801IF8,I03MFE00403FEIFC003IF1IF8I0IF800IFC7FFEIFC003IF1IF801IF8,I03MFC00807FCIFC007IF1IFI01IF800IF87FFCIFC007IF1IF001IF8,I03MF00100FFCIFC00JF1IFI01IF800IF87FFCIFC00JF3IF001IF8,I03LFE00300FFCIFC01IFE3IFI01IF801IF8IFCIFC01JF3IF001IF,I03LFC00601FFCIFE07IFE3IFI01IF001IF8IFCIFE07IFE3IF003IF,I03LFI0C01FFCOFE3IFI01IF001IF8IFCOFE3IF003IF,I03KFC001803FFCOFE3FFEI01IF001IF8IFCOFE3FFE003IF,I03KF8003007FFEOFE3FFEI03IF001IF0IF8OFE3FFE003IF,I03JFEL0IFE7KFBFFE7FFEI03IF001IF0IF87KFBFFE7FFE003IF,I03JF8L0JF3JFE3FFE7FFEI03FFE003IF1IF83JFE3FFE7FFE003FFE,I03JFL01JF9JFC3FFE7FFEI03FFE003IF1IF81JFC3FFE7FFE007FFE,I01IFCL03JFCIFE01FFE7FFEI03FFE003IF1IF80IFE01IF7FFE007FFE,I01IFM03JFE0FEgP0FE,I01FFCM07JFE,I01FFN0KFE,J0FCM01KFC,J0FN01KF8,J04N03KF,S07JFEgP07FC03FFC01FF00F01E1FFC,S0KF8gO01FFE03FFE03FF80F01E1FFE,N018001KFgP03IF07FFE07FFC0E01C3IF,N07I01JFEgP07C0F0780F0F83E0E01C3C0F,N0EI03JFCgP078078700F1F01E1E03C3C0F,M038I07JFgQ0F0020700F1E00E1E03C380F,M07J0JFEgQ0EJ0F01F3C00E1E03C780F,L01EI01JF8gQ0EJ0F03E3C00E1C038781E,L038I03JFgQ01E0FE0IFC3C00E1C0387FFE,L0FJ07IFCgQ01E0FF0IF83800E3C0787FFC,L04J0JFgR01C0FF0F7E03801E3C0787FF,Q0IFCgR01C0FF1E1E03801E3C078F,P03IFgS01E00E1E0F03803C38070F,P07FF8gS01E00E1E0703C07C380F0F,P07F8gU0F01E1C0783E0F83C1F0E,hN0FDFE1C0781FBF03FFE0E,hN07FFC3C03C0FFE01FFC1E,hN03FF03C03C07FC00FF81E,hO03O0CI018,,:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::^FS\n";
                s += "^FX Top section with logo, name and address.\n";
                s += "^CF0,60\n";
                s += "^FO350,50^FDArnian Group.^FS\n";
                s += "^CF0,30\n";
                s += "^FO350,115^FD9948 Via de la Amistad^FS\n";
                s += "^FO350,155^FDSan Diego, CA 92154^FS\n";
                s += "^FO350,195^FDUnited States(USA)^FS\n";
                s += "^FO50,250^GB700,3,3^FS\n";
                s += "\n";
                s += "^FX Second section with recipient address and permit information.\n";
                s += "^CF0,30";
                s += "^FO50,300^FDNombre Alias^FS\n";
                s += "^FO50,340^FDTESSST^FS\n";
                s += "^FO50,380^FDTEST^FS\n";
                s += "^FO50,420^FDTESTs^FS\n";
                s += "^CF0,40\n";
                s += "^FO550,300^GB150,150,3^FS\n";
                s += "^FO590,340^FDEntrada^FS\n";
                s += "^FO590,390^FD0008080^FS\n";
                s += "^FO50,500^GB700,3,3^FS\n";
                s += "\n";
                s += "^FX Third section with bar code.\n";
                s += "^BY3,2,270\n";
                s += "^FO100,550^BC^FDCSL-0008080-100^FS\n";
                s += "\n";
                s += "^FX Fourth section(the two boxes on the bottom).\n";
                s += "^FO50,900^GB700,250,3^FS\n";
                s += "^FO400,900^GB3,250,3^FS\n";
                s += "^CF0,40";
                s += "^FO100,960^FDCtr.X34B-1^FS\n";
                s += "^FO100,1010^FDREF1 F00B47^FS\n";
                s += "^FO100,1060^FDREF2 BL4H8^FS\n";
                s += "^CF0,190\n";
                s += "^FO470,955^FDCA^FS\n";
                s += "\n";
                s += "^XZ\n";

            Clipboard.SetText(s);

            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                PrintEtique.PrintEtiquetas1.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
            }
            */


        }

        private void llamareporte()
        {
            using (Reportes.TestReport rp = new Reportes.TestReport())
            {
                Servicios datos = new Servicios();
                var lst = datos.LLenaEntradaByID(txbBuscarEnt.Text.Trim(), sucEntrada.SelectedValue.ToString().Trim());


                foreach (var q in lst)
                {
                    rp.repTOrigen = q.C1;
                    rp.repTEntrada = q.C6.Trim();
                    rp.repTCliente = q.C32.Trim();
                    rp.repTFecha = q.C9.ToString();
                    rp.repProveedor = q.C92.Trim();
                    rp.repUnidades = q.C97.ToString();
                    rp.repTipoUnidades = q.C98.Trim();
                    rp.repNumFlete = q.C95.Trim();
                    rp.repOrdCompra = q.C93.Trim();
                    rp.repNumBultos = q.C108.Trim();
                    rp.repContMercancia = q.descripcion.Trim();
                    rp.repNotas = q.C24.Trim();

                }
                rp.ShowDialog();


            }


            //var lst = new List<vmEtiquetasReporte>();
            //lst = sv.LlenaEtiquetas(lblEntrada.Text.Trim(), sucEntrada.SelectedValue.ToString().Trim());
            // rp.lstrep = lst;





        }



        private void gunaTileButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = "@C:\\";
            fd.Filter = "Solo documentos (PDF, WORD, JPG, PNG, JPEG)|*.PDF;*.DOCX;*.PNG;*.JPG;*.JPEG";
            fd.Multiselect = true;



            if (fd.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in fd.FileNames)
                {
                    try
                    {
                        var onlyFileName = System.IO.Path.GetFileName(file);
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dgvDocs);
                        row.Cells[0].Value = onlyFileName;
                        row.Cells[1].Value = file;
                        DataGridViewButtonColumn btng = new DataGridViewButtonColumn();

                        btng.Text = "Borrar Archivo";
                        btng.HeaderText = "Borrar Archivo";
                        btng.Name = "btng";

                        btng.UseColumnTextForButtonValue = true;


                        row.Cells[2] = btng.CellTemplate;
                        dgvDocs.Rows.Add(row);

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Ha ocurrido un error");
                    }
                }


            }

            lblTotalArchivos.Text = dgvDocs.Rows.Count.ToString();

        }
        private int validapsoemail()
        {
            var bandera = 0;
            long pesoArch = 0;
            List<string> archivos = new List<string>();
            if (dgvDocs.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDocs.Rows)
                {
                    archivos.Add(row.Cells[1].Value.ToString());
                }

                foreach (var item in archivos) //Attachment
                {
                    var fileInfo = new FileInfo(item);
                    pesoArch += fileInfo.Length;
                }

                // Convertir a MB
                var pesoArchMB = pesoArch / 1024 / 1024;

                if (pesoArchMB >= 24)
                {
                    MessageBox.Show("Tus archivos superan el tamaño maximo permitido por Google, por favor elimina algun archivo.");
                    bandera = 1;
                }
            }
            return bandera;
        }


        private void dgvDocs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDocs_CellClick(object sender, DataGridViewCellEventArgs e) //Borra archivos sin cargar 
        {
            if (e.ColumnIndex == 2)
            {
                if (e.RowIndex == -1)
                {
                    return;
                }

                if (this.dgvDocs.Rows[e.RowIndex].Cells[0].Value == null)
                {
                    MessageBox.Show("Ningun archivo seleccionado");
                    return;
                }
                if (MessageBox.Show("Seguro que quieres borrar el archivo: " + this.dgvDocs.Rows[e.RowIndex].Cells[0].Value.ToString(), "Cuidado!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (this.dgvDocs.Rows.Count > 0)
                    {
                        dgvDocs.Rows.RemoveAt(this.dgvDocs.Rows[e.RowIndex].Index);
                        lblTotalArchivos.Text = dgvDocs.Rows.Count.ToString();
                    }
                }
            }
        }
        private void SelectPrinterWithRange()
        {
            // Obtener el ZIP desde el label
            string zipCode = lblZipCode.Text.Trim() == "false"?"NA": lblZipCode.Text.Trim();

            // Obtener solo el número de la zona
            (string ZonaNumero, string ZonaNombre) = ObtenerZonaPorCodigoPostal(zipCode);

            // Obtener el rango de etiquetas a imprimir
            int fromLabel = 0;
            int toLabel = 0;
            try
            {
                fromLabel = int.Parse(txbEn1.Text);
                toLabel = int.Parse(txbEn2.Text);
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese un número válido en ambos campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
            printDialog.PrinterSettings = new PrinterSettings();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                string printerName = printDialog.PrinterSettings.PrinterName;

                Servicio datos = new Servicio();

                Servicios sv = new Servicios();

                var lst = new List<vmEtiquetasReporte>();
                lst = sv.LlenaEtiquetas(lblEntrada.Text.Trim(), sucEntrada.SelectedValue.ToString().Trim());
                lst = lst.OrderBy(q => q.NEtiqueta).ToList();
                int neti = 1;
                string lstt = lst.Count.ToString();
                string zplToDoc = "";
                foreach (var q in lst)
                {
                    // Verificar si la etiqueta actual está dentro del rango especificado
                    int labelNum = int.Parse(q.NEtiqueta.ToString());
                    if (labelNum >= fromLabel && labelNum <= toLabel)
                    {
                        // Agregar el código ZPL para imprimir la etiqueta actual
                        try
                        {
                            string s = "^PW288\n";
                            s += "^XA^\r\nFO40,20^GFA,7372,7372,38,,:::::::::::::::::::::::::::::::::W01FF,V03JF,U01KFC,U0MF,T03MF8,T0NFE,S03OF,S0PF8,R03NF7F8,R07NF7FC,Q01OF7FE,Q03OF7FE,Q0PF7FF,P01OFE7FF,P03OFE7FF8,P0PFEIF8,O01PFCIFC,O03PFCIFC,O07PFCIFC,O0QF8IFC,N01QF8IFE,N03QF1IFE,N07QF1IFE,N0RF1IFE,M01QFE9IFE,M03QFEBIFE,M03QFC3IFE,M07QFD3JF,M0RF93JF,L01RF87JF,L01RF07JF,L03RF07JF,L07QFE0JFE,:L0RFC0JFE,L0RF81JFE,K01RF81JFE,K03RF01FFE,K03RF03FF03IF8M03F8K07FCO07IF8N0FF8,K07QFE03FC7KF801IF0LF03IF007FFE007KF801IF03IF,K07QFC07F1LFE01IF1LF07IFC07FFE01LFE01IF0JF8,K0RF807E7MF01FFE3LF1JFC07FFE07MF01FFE3JFC,K0RF807CNF81FFE7FFDIF3JFE07FFC0NF83FFE7JFC,J01RF18F9NF83LF9IF7JFE0IFC1NFC3FFEKFE,J01QFE10F3NFC3LF9OF0IFC3NFC3NFE,J03QFC21F3NFC3LF1OF0IFC3NFC3NFE,J03QFC21E7IF81IFC3KFE1OF0IFC7IF81IFC3NFE,J03QF843EIFE007FFC3KFE3OF0IFC7FFE007FFC3OF,J07QF083CIFC007FFC3KFC3OF0IF8IFC007FFC7NFE,J07PFE083C0FF9007FFC7IFE003IFE0JF1IF80FF8007FFC7IFC1IFE,J0QFC107F8002007FFC7IF8003IF807IF1IF8L07FFC7IF80IFE,J0QF8007IFC601IFC7IF8003IF003IF1IF8K01IFC7IF007FFE,J0QFI0KF81JFC7IFI03IF003IF1IF8J01JFC7FFE007FFE,J0PFEI0JF01KFC7FFEI07FFE003FFE1IFJ01KFC7FFE007FFE,I01PFC001IF03LFCIFEI07FFE003FFE1IFI03LFCIFC007FFE,I01PF8003FFC7MF8IFCI07FFE007FFE3IF007MF8IFC007FFC,I01PFI03FF1NF8IFCI07FFC007FFE3IF01NF8IFC00IFC,I01OFEI07FE7NF8IFCI07FFC007FFE3IF07NF8IFC00IFC,I03OFCI07FDKF9IF8IFCI0IFC007FFE3FFE1KF8IF8IF800IFC,I03OFJ0FFBJF81IF8IF8I0IFC007FFC3FFE1JF81IF9IF800IFC,I03NFEJ0FF3IFC01IF1IF8I0IFC00IFC7FFE3IFC01IF9IF800IFC,I03NFCI01FE7IF001IF1IF8I0IF800IFC7FFE7IF001IF1IF801IF8,I03NF80403FE7FFE003IF1IF8I0IF800IFC7FFE7FFE003IF1IF801IF8,I03MFE00403FEIFC003IF1IF8I0IF800IFC7FFEIFC003IF1IF801IF8,I03MFC00807FCIFC007IF1IFI01IF800IF87FFCIFC007IF1IF001IF8,I03MF00100FFCIFC00JF1IFI01IF800IF87FFCIFC00JF3IF001IF8,I03LFE00300FFCIFC01IFE3IFI01IF801IF8IFCIFC01JF3IF001IF,I03LFC00601FFCIFE07IFE3IFI01IF001IF8IFCIFE07IFE3IF003IF,I03LFI0C01FFCOFE3IFI01IF001IF8IFCOFE3IF003IF,I03KFC001803FFCOFE3FFEI01IF001IF8IFCOFE3FFE003IF,I03KF8003007FFEOFE3FFEI03IF001IF0IF8OFE3FFE003IF,I03JFEL0IFE7KFBFFE7FFEI03IF001IF0IF87KFBFFE7FFE003IF,I03JF8L0JF3JFE3FFE7FFEI03FFE003IF1IF83JFE3FFE7FFE003FFE,I03JFL01JF9JFC3FFE7FFEI03FFE003IF1IF81JFC3FFE7FFE007FFE,I01IFCL03JFCIFE01FFE7FFEI03FFE003IF1IF80IFE01IF7FFE007FFE,I01IFM03JFE0FEgP0FE,I01FFCM07JFE,I01FFN0KFE,J0FCM01KFC,J0FN01KF8,J04N03KF,S07JFEgP07FC03FFC01FF00F01E1FFC,S0KF8gO01FFE03FFE03FF80F01E1FFE,N018001KFgP03IF07FFE07FFC0E01C3IF,N07I01JFEgP07C0F0780F0F83E0E01C3C0F,N0EI03JFCgP078078700F1F01E1E03C3C0F,M038I07JFgQ0F0020700F1E00E1E03C380F,M07J0JFEgQ0EJ0F01F3C00E1E03C780F,L01EI01JF8gQ0EJ0F03E3C00E1C038781E,L038I03JFgQ01E0FE0IFC3C00E1C0387FFE,L0FJ07IFCgQ01E0FF0IF83800E3C0787FFC,L04J0JFgR01C0FF0F7E03801E3C0787FF,Q0IFCgR01C0FF1E1E03801E3C078F,P03IFgS01E00E1E0F03803C38070F,P07FF8gS01E00E1E0703C07C380F0F,P07F8gU0F01E1C0783E0F83C1F0E,hN0FDFE1C0781FBF03FFE0E,hN07FFC3C03C0FFE01FFC1E,hN03FF03C03C07FC00FF81E,hO03O0CI018,,:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::^FS\n";
                            s += "^FX Top section with logo, name and address.\n";
                            s += "^CF0,180\n";
                            s += string.Format("^FO380,40^FD: {0}^FS\n", q.nOdooCliente.Trim());
                            s += "^FO50,200^GB700,3,3^FS\n";
                            s += "\n";
                            s += "^FX Second section with recipient address and permit information.\n";
                            s += string.Format("^CF0,70^FO50,230^FDID: {0}^FS\n", q.Entrada.Trim());
                            s += "^CF0,32";
                            s += string.Format("^FO50,300^FDClient: {0}^FS\n", q.Cliente.Trim());
                            s += string.Format("^FO50,340^FDOrigin: {0}^FS\n", q.Origen.Trim());
                            s += string.Format("^FO50,380^FDDestination: {0}^FS\n", q.Destino.Trim());
                            s += string.Format("^FO50,420^FDAlias: {0}^FS\n", q.Alias == null ? "" : q.Alias.Trim());
                            s += "^CF0,40\n";
                            s += "^FO50,500^GB700,3,3^FS\n";
                            s += "\n";
                            s += "^FX Third section with bar code.\n";
                            s += "^BY3,2,260\n";
                            s += string.Format("^FO120,550^BC^FD{0}^FS\n", q.Etiqueta.Trim());
                            s += "\n";
                            s += "^FX Fourth section(the two boxes on the bottom).\n";
                            s += "^FO50,870^GB700,250,3^FS\n";
                            s += "^FO400,870^GB3,250,3^FS\n";
                            s += "^CF0,80";
                            s += string.Format("^FO100,900^FD{0} de {1}^FS\n", labelNum.ToString(), lstt);
                            s += "^CF0,40";
                            s += "^FO100,1010^FDDate:^FS\n";
                            s += string.Format("^FO100,1060^FD{0}^FS\n", q.Fecha.Value.Date.ToString("MM/dd/yyyy"));
                            s += "^CF0,190\n";
                            s += string.Format("^FO450,930^FD{0}^FS\n", ZonaNumero.ToString());
                            s += "\n";
                            s += "^CF0,30";
                            s += string.Format("^FO50,1140^FDZona: {0}^FS\n", ZonaNombre);
                            s += string.Format("^FO50,1175^FDCodigo Postal: {0}^FS\n", zipCode);
                            s += "\n";
                            s += "^XZ\n";
                            s += "\n";
                            zplToDoc += s;
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                        neti = neti + 1;
                    }
                }

                try
                {
                    using (MemoryStream lmemStream = new MemoryStream())
                    {
                        using (StreamWriter lstreamWriter = new StreamWriter(lmemStream))
                        {
                            lstreamWriter.Write(zplToDoc);

                            lstreamWriter.Flush();
                            lmemStream.Position = 0;

                            byte[] byteArray = lmemStream.ToArray();

                            IntPtr cpUnmanagedBytes = new IntPtr(0);
                            int cnLength = byteArray.Length;
                            cpUnmanagedBytes = Marshal.AllocCoTaskMem(cnLength);
                            Marshal.Copy(byteArray, 0, cpUnmanagedBytes, cnLength);

                            Negocios.PrintZebra.RawPrinterHelper.SendBytesToPrinter(printerName, cpUnmanagedBytes, cnLength);
                            Marshal.FreeCoTaskMem(cpUnmanagedBytes);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private (string ZonaNumero, string ZonaNombre) ObtenerZonaPorCodigoPostal(string zipCode)
        {
            if (!int.TryParse(zipCode, out var codigoPostal))
                return ("NA", "ZONA NO DEFINIDA");

            // —————– Baja California Sur —————–
            if (codigoPostal >= 23450 && codigoPostal <= 23499) return ("1", "CABO SAN LUCAS");
            if (codigoPostal >= 23400 && codigoPostal <= 23429) return ("2", "SAN JOSÉ CENTRO");
            if (codigoPostal >= 23430 && codigoPostal <= 23449) return ("4", "SAN JOSÉ COSTA");
            if (codigoPostal >= 23300 && codigoPostal <= 23305) return ("3", "TODOS SANTOS");
            if (codigoPostal >= 23330 && codigoPostal <= 23332) return ("5", "LOS BARRILES");
            if (codigoPostal >= 23000 && codigoPostal <= 23299) return ("6", "LA PAZ");
            if (codigoPostal >= 23880 && codigoPostal <= 23899) return ("7", "LORETO"); // Ejemplo: CP 23883 

            // —————– Baja California —————–
            if (codigoPostal >= 21400 && codigoPostal <= 21499) return ("8", "TECATE");             // CP 21420
            if (codigoPostal >= 21000 && codigoPostal <= 21999) return ("9", "MEXICALI");         // CP 21000
            if (codigoPostal >= 22000 && codigoPostal <= 22699) return ("10", "TIJUANA");         // CP 22000
            if (codigoPostal >= 22700 && codigoPostal <= 22799) return ("11", "PLAYAS DE ROSARITO"); // CP 22703
            if (codigoPostal >= 22800 && codigoPostal <= 22899) return ("12", "ENSENADA");        // CP 22800
            if (codigoPostal >= 22900 && codigoPostal <= 22999) return ("13", "SAN QUINTÍN");      // Ejemplo: CP 22930 

            // Zona no contemplada
            return ("NA", "ZONA NO DEFINIDA");
        }



        private void SelectPrinter()
        {
            // Obtener el ZIP desde el label
            string zipCode = lblZipCode.Text.Trim() == "false" ? "NA" : lblZipCode.Text.Trim();

            // Obtener solo el número de la zona
            (string ZonaNumero, string ZonaNombre) = ObtenerZonaPorCodigoPostal(zipCode);

            System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
            printDialog.PrinterSettings = new PrinterSettings();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
              

                string printerName = printDialog.PrinterSettings.PrinterName;

                Servicio datos = new Servicio();

                Servicios sv = new Servicios();

                var lst = new List<vmEtiquetasReporte>();
                lst = sv.LlenaEtiquetas(lblEntrada.Text.Trim(), sucEntrada.SelectedValue.ToString().Trim());
                lst = lst.OrderBy(q => q.NEtiqueta).ToList();
                int neti = 1;
                string lstt = lst.Count.ToString();
                string zplToDoc = "";
                foreach (var q in lst)
                {

                    try
                    {
                        string s = "^PW288\n";
                        s += "^XA^\r\nFO40,20^GFA,7372,7372,38,,:::::::::::::::::::::::::::::::::W01FF,V03JF,U01KFC,U0MF,T03MF8,T0NFE,S03OF,S0PF8,R03NF7F8,R07NF7FC,Q01OF7FE,Q03OF7FE,Q0PF7FF,P01OFE7FF,P03OFE7FF8,P0PFEIF8,O01PFCIFC,O03PFCIFC,O07PFCIFC,O0QF8IFC,N01QF8IFE,N03QF1IFE,N07QF1IFE,N0RF1IFE,M01QFE9IFE,M03QFEBIFE,M03QFC3IFE,M07QFD3JF,M0RF93JF,L01RF87JF,L01RF07JF,L03RF07JF,L07QFE0JFE,:L0RFC0JFE,L0RF81JFE,K01RF81JFE,K03RF01FFE,K03RF03FF03IF8M03F8K07FCO07IF8N0FF8,K07QFE03FC7KF801IF0LF03IF007FFE007KF801IF03IF,K07QFC07F1LFE01IF1LF07IFC07FFE01LFE01IF0JF8,K0RF807E7MF01FFE3LF1JFC07FFE07MF01FFE3JFC,K0RF807CNF81FFE7FFDIF3JFE07FFC0NF83FFE7JFC,J01RF18F9NF83LF9IF7JFE0IFC1NFC3FFEKFE,J01QFE10F3NFC3LF9OF0IFC3NFC3NFE,J03QFC21F3NFC3LF1OF0IFC3NFC3NFE,J03QFC21E7IF81IFC3KFE1OF0IFC7IF81IFC3NFE,J03QF843EIFE007FFC3KFE3OF0IFC7FFE007FFC3OF,J07QF083CIFC007FFC3KFC3OF0IF8IFC007FFC7NFE,J07PFE083C0FF9007FFC7IFE003IFE0JF1IF80FF8007FFC7IFC1IFE,J0QFC107F8002007FFC7IF8003IF807IF1IF8L07FFC7IF80IFE,J0QF8007IFC601IFC7IF8003IF003IF1IF8K01IFC7IF007FFE,J0QFI0KF81JFC7IFI03IF003IF1IF8J01JFC7FFE007FFE,J0PFEI0JF01KFC7FFEI07FFE003FFE1IFJ01KFC7FFE007FFE,I01PFC001IF03LFCIFEI07FFE003FFE1IFI03LFCIFC007FFE,I01PF8003FFC7MF8IFCI07FFE007FFE3IF007MF8IFC007FFC,I01PFI03FF1NF8IFCI07FFC007FFE3IF01NF8IFC00IFC,I01OFEI07FE7NF8IFCI07FFC007FFE3IF07NF8IFC00IFC,I03OFCI07FDKF9IF8IFCI0IFC007FFE3FFE1KF8IF8IF800IFC,I03OFJ0FFBJF81IF8IF8I0IFC007FFC3FFE1JF81IF9IF800IFC,I03NFEJ0FF3IFC01IF1IF8I0IFC00IFC7FFE3IFC01IF9IF800IFC,I03NFCI01FE7IF001IF1IF8I0IF800IFC7FFE7IF001IF1IF801IF8,I03NF80403FE7FFE003IF1IF8I0IF800IFC7FFE7FFE003IF1IF801IF8,I03MFE00403FEIFC003IF1IF8I0IF800IFC7FFEIFC003IF1IF801IF8,I03MFC00807FCIFC007IF1IFI01IF800IF87FFCIFC007IF1IF001IF8,I03MF00100FFCIFC00JF1IFI01IF800IF87FFCIFC00JF3IF001IF8,I03LFE00300FFCIFC01IFE3IFI01IF801IF8IFCIFC01JF3IF001IF,I03LFC00601FFCIFE07IFE3IFI01IF001IF8IFCIFE07IFE3IF003IF,I03LFI0C01FFCOFE3IFI01IF001IF8IFCOFE3IF003IF,I03KFC001803FFCOFE3FFEI01IF001IF8IFCOFE3FFE003IF,I03KF8003007FFEOFE3FFEI03IF001IF0IF8OFE3FFE003IF,I03JFEL0IFE7KFBFFE7FFEI03IF001IF0IF87KFBFFE7FFE003IF,I03JF8L0JF3JFE3FFE7FFEI03FFE003IF1IF83JFE3FFE7FFE003FFE,I03JFL01JF9JFC3FFE7FFEI03FFE003IF1IF81JFC3FFE7FFE007FFE,I01IFCL03JFCIFE01FFE7FFEI03FFE003IF1IF80IFE01IF7FFE007FFE,I01IFM03JFE0FEgP0FE,I01FFCM07JFE,I01FFN0KFE,J0FCM01KFC,J0FN01KF8,J04N03KF,S07JFEgP07FC03FFC01FF00F01E1FFC,S0KF8gO01FFE03FFE03FF80F01E1FFE,N018001KFgP03IF07FFE07FFC0E01C3IF,N07I01JFEgP07C0F0780F0F83E0E01C3C0F,N0EI03JFCgP078078700F1F01E1E03C3C0F,M038I07JFgQ0F0020700F1E00E1E03C380F,M07J0JFEgQ0EJ0F01F3C00E1E03C780F,L01EI01JF8gQ0EJ0F03E3C00E1C038781E,L038I03JFgQ01E0FE0IFC3C00E1C0387FFE,L0FJ07IFCgQ01E0FF0IF83800E3C0787FFC,L04J0JFgR01C0FF0F7E03801E3C0787FF,Q0IFCgR01C0FF1E1E03801E3C078F,P03IFgS01E00E1E0F03803C38070F,P07FF8gS01E00E1E0703C07C380F0F,P07F8gU0F01E1C0783E0F83C1F0E,hN0FDFE1C0781FBF03FFE0E,hN07FFC3C03C0FFE01FFC1E,hN03FF03C03C07FC00FF81E,hO03O0CI018,,:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::^FS\n";
                        s += "^FX Top section with logo, name and address.\n";

                        s += "^CF0,180\n";
                        s += string.Format("^FO380,40^FD: {0}^FS\n", q.nOdooCliente.Trim());

                        s += "^FO50,200^GB700,3,3^FS\n";
                        s += "\n";
                        s += "^FX Second section with recipient address and permit information.\n";
                        s += string.Format("^CF0,70^FO50,230^FDID: {0}^FS\n", q.Entrada.Trim());
                        s += "^CF0,32";
                        s += string.Format("^FO50,300^FDClient: {0}^FS\n", q.Cliente.Trim());
                        s += string.Format("^FO50,340^FDOrigin: {0}^FS\n", q.Origen.Trim());
                        s += string.Format("^FO50,380^FDDestination: {0}^FS\n", q.Destino.Trim());
                        s += string.Format("^FO50,420^FDAlias: {0}^FS\n", q.Alias == null ? "" : q.Alias.Trim());
                        s += "^CF0,40\n";
                        s += "^FO50,500^GB700,3,3^FS\n";
                        s += "\n";
                        s += "^FX Third section with bar code.\n";
                        s += "^BY3,2,260\n";
                        s += string.Format("^FO120,550^BC^FD{0}^FS\n", q.Etiqueta.Trim());
                        s += "\n";
                        s += "^FX Fourth section(the two boxes on the bottom).\n";
                        s += "^FO50,870^GB700,250,3^FS\n";
                        s += "^FO400,870^GB3,250,3^FS\n";
                        s += "^CF0,80";
                        s += string.Format("^FO100,900^FD{0} de {1}^FS\n", q.NEtiqueta.ToString(), lstt);
                        s += "^CF0,40";
                        s += "^FO100,1010^FDDate:^FS\n";
                        s += string.Format("^FO100,1060^FD{0}^FS\n", q.Fecha.Value.Date.ToString("MM/dd/yyyy"));
                        s += "^CF0,190\n";
                        s += string.Format("^FO450,930^FD{0}^FS\n", ZonaNumero.ToString());
                        s += "\n";
                        s += "^CF0,30";
                        s += string.Format("^FO50,1140^FDZona: {0}^FS\n", ZonaNombre);
                        s += string.Format("^FO50,1175^FDCodigo Postal: {0}^FS\n", zipCode);
                        s += "\n";
                        s += "^XZ\n";
                        s += "\n";
                        zplToDoc += s;
                    }
                    catch (Exception)
                    {

                        throw;
                    }


                    neti = neti + 1;
                }

                try
                {
                    using (MemoryStream lmemStream = new MemoryStream())
                    {
                        using (StreamWriter lstreamWriter = new StreamWriter(lmemStream))
                        {
                            lstreamWriter.Write(zplToDoc);

                            lstreamWriter.Flush();
                            lmemStream.Position = 0;

                            byte[] byteArray = lmemStream.ToArray();

                            IntPtr cpUnmanagedBytes = new IntPtr(0);
                            int cnLength = byteArray.Length;
                            cpUnmanagedBytes = Marshal.AllocCoTaskMem(cnLength);
                            Marshal.Copy(byteArray, 0, cpUnmanagedBytes, cnLength);

                            Negocios.PrintZebra.RawPrinterHelper.SendBytesToPrinter(printerName, cpUnmanagedBytes, cnLength);
                            Marshal.FreeCoTaskMem(cpUnmanagedBytes);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                

            }
        }

        
        private async Task PdfZPLcrea()
        {

            if (String.IsNullOrWhiteSpace(bultos.Text) && String.IsNullOrWhiteSpace(txbBuscarEnt.Text))
            {
                return;
            }

            MessageBox.Show("Solo se pueden imprimir menos de 50 etiquetas");

            saveFileDialog1.InitialDirectory = "@C:\\";
            saveFileDialog1.Filter = "Solo documentos (PDF)|*.PDF";

            string ruta ="";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.CheckPathExists)
            {
                try
                {
                    ruta = saveFileDialog1.FileName;
                }
                catch (Exception)
                {

                    throw;
                }
                Servicio datos = new Servicio();

                Servicios sv = new Servicios();

                var lst = new List<vmEtiquetasReporte>();
                lst = sv.LlenaEtiquetas(lblEntrada.Text.Trim(), sucEntrada.SelectedValue.ToString().Trim());
                int neti = 1;
                string lstt = lst.Count.ToString();
                string zplToDoc = "";
                foreach (var q in lst)
                {
                  
                    try
                    {
                        string s = "^PW288\n";
                        s += "^XA^\r\nFO40,20^GFA,7372,7372,38,,:::::::::::::::::::::::::::::::::W01FF,V03JF,U01KFC,U0MF,T03MF8,T0NFE,S03OF,S0PF8,R03NF7F8,R07NF7FC,Q01OF7FE,Q03OF7FE,Q0PF7FF,P01OFE7FF,P03OFE7FF8,P0PFEIF8,O01PFCIFC,O03PFCIFC,O07PFCIFC,O0QF8IFC,N01QF8IFE,N03QF1IFE,N07QF1IFE,N0RF1IFE,M01QFE9IFE,M03QFEBIFE,M03QFC3IFE,M07QFD3JF,M0RF93JF,L01RF87JF,L01RF07JF,L03RF07JF,L07QFE0JFE,:L0RFC0JFE,L0RF81JFE,K01RF81JFE,K03RF01FFE,K03RF03FF03IF8M03F8K07FCO07IF8N0FF8,K07QFE03FC7KF801IF0LF03IF007FFE007KF801IF03IF,K07QFC07F1LFE01IF1LF07IFC07FFE01LFE01IF0JF8,K0RF807E7MF01FFE3LF1JFC07FFE07MF01FFE3JFC,K0RF807CNF81FFE7FFDIF3JFE07FFC0NF83FFE7JFC,J01RF18F9NF83LF9IF7JFE0IFC1NFC3FFEKFE,J01QFE10F3NFC3LF9OF0IFC3NFC3NFE,J03QFC21F3NFC3LF1OF0IFC3NFC3NFE,J03QFC21E7IF81IFC3KFE1OF0IFC7IF81IFC3NFE,J03QF843EIFE007FFC3KFE3OF0IFC7FFE007FFC3OF,J07QF083CIFC007FFC3KFC3OF0IF8IFC007FFC7NFE,J07PFE083C0FF9007FFC7IFE003IFE0JF1IF80FF8007FFC7IFC1IFE,J0QFC107F8002007FFC7IF8003IF807IF1IF8L07FFC7IF80IFE,J0QF8007IFC601IFC7IF8003IF003IF1IF8K01IFC7IF007FFE,J0QFI0KF81JFC7IFI03IF003IF1IF8J01JFC7FFE007FFE,J0PFEI0JF01KFC7FFEI07FFE003FFE1IFJ01KFC7FFE007FFE,I01PFC001IF03LFCIFEI07FFE003FFE1IFI03LFCIFC007FFE,I01PF8003FFC7MF8IFCI07FFE007FFE3IF007MF8IFC007FFC,I01PFI03FF1NF8IFCI07FFC007FFE3IF01NF8IFC00IFC,I01OFEI07FE7NF8IFCI07FFC007FFE3IF07NF8IFC00IFC,I03OFCI07FDKF9IF8IFCI0IFC007FFE3FFE1KF8IF8IF800IFC,I03OFJ0FFBJF81IF8IF8I0IFC007FFC3FFE1JF81IF9IF800IFC,I03NFEJ0FF3IFC01IF1IF8I0IFC00IFC7FFE3IFC01IF9IF800IFC,I03NFCI01FE7IF001IF1IF8I0IF800IFC7FFE7IF001IF1IF801IF8,I03NF80403FE7FFE003IF1IF8I0IF800IFC7FFE7FFE003IF1IF801IF8,I03MFE00403FEIFC003IF1IF8I0IF800IFC7FFEIFC003IF1IF801IF8,I03MFC00807FCIFC007IF1IFI01IF800IF87FFCIFC007IF1IF001IF8,I03MF00100FFCIFC00JF1IFI01IF800IF87FFCIFC00JF3IF001IF8,I03LFE00300FFCIFC01IFE3IFI01IF801IF8IFCIFC01JF3IF001IF,I03LFC00601FFCIFE07IFE3IFI01IF001IF8IFCIFE07IFE3IF003IF,I03LFI0C01FFCOFE3IFI01IF001IF8IFCOFE3IF003IF,I03KFC001803FFCOFE3FFEI01IF001IF8IFCOFE3FFE003IF,I03KF8003007FFEOFE3FFEI03IF001IF0IF8OFE3FFE003IF,I03JFEL0IFE7KFBFFE7FFEI03IF001IF0IF87KFBFFE7FFE003IF,I03JF8L0JF3JFE3FFE7FFEI03FFE003IF1IF83JFE3FFE7FFE003FFE,I03JFL01JF9JFC3FFE7FFEI03FFE003IF1IF81JFC3FFE7FFE007FFE,I01IFCL03JFCIFE01FFE7FFEI03FFE003IF1IF80IFE01IF7FFE007FFE,I01IFM03JFE0FEgP0FE,I01FFCM07JFE,I01FFN0KFE,J0FCM01KFC,J0FN01KF8,J04N03KF,S07JFEgP07FC03FFC01FF00F01E1FFC,S0KF8gO01FFE03FFE03FF80F01E1FFE,N018001KFgP03IF07FFE07FFC0E01C3IF,N07I01JFEgP07C0F0780F0F83E0E01C3C0F,N0EI03JFCgP078078700F1F01E1E03C3C0F,M038I07JFgQ0F0020700F1E00E1E03C380F,M07J0JFEgQ0EJ0F01F3C00E1E03C780F,L01EI01JF8gQ0EJ0F03E3C00E1C038781E,L038I03JFgQ01E0FE0IFC3C00E1C0387FFE,L0FJ07IFCgQ01E0FF0IF83800E3C0787FFC,L04J0JFgR01C0FF0F7E03801E3C0787FF,Q0IFCgR01C0FF1E1E03801E3C078F,P03IFgS01E00E1E0F03803C38070F,P07FF8gS01E00E1E0703C07C380F0F,P07F8gU0F01E1C0783E0F83C1F0E,hN0FDFE1C0781FBF03FFE0E,hN07FFC3C03C0FFE01FFC1E,hN03FF03C03C07FC00FF81E,hO03O0CI018,,:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::^FS\n";
                        s += "^FX Top section with logo, name and address.\n";

                        s += "^FO50,200^GB700,3,3^FS\n";
                        s += "\n";
                        s += "^FX Second section with recipient address and permit information.\n";
                        s += string.Format("^CF0,70^FO50,230^FDID: {0}^FS\n", q.Entrada.Trim());
                        s += "^CF0,30";
                        s += string.Format("^FO50,300^FDClient: {0}^FS\n", q.Cliente.Trim());
                        s += string.Format("^FO50,340^FDOrigin: {0}^FS\n", q.Origen.Trim());
                        s += string.Format("^FO50,380^FDDestination: {0}^FS\n", q.Destino.Trim());
                        s += string.Format("^FO50,420^FDAlias: {0}^FS\n", q.Alias == null ? "" : q.Alias.Trim());
                        s += "^CF0,40\n";
                        s += "^FO50,500^GB700,3,3^FS\n";
                        s += "\n";
                        s += "^FX Third section with bar code.\n";
                        s += "^BY3,2,260\n";
                        s += string.Format("^FO120,550^BC^FD{0}^FS\n", q.Etiqueta.Trim());
                        s += "\n";
                        s += "^FX Fourth section(the two boxes on the bottom).\n";
                        s += "^FO50,870^GB700,250,3^FS\n";
                        s += "^FO400,870^GB3,250,3^FS\n";
                        s += "^CF0,80";
                        s += string.Format("^FO100,900^FD{0} de {1}^FS\n", q.NEtiqueta.ToString(), lstt);
                        s += "^CF0,40";
                        s += "^FO100,1010^FDDate:^FS\n";
                        s += string.Format("^FO100,1060^FD{0}^FS\n", q.Fecha.Value.Date.ToString("MM/dd/yyyy"));
                        s += "^CF0,190\n";
                        //s += string.Format("^FO470,930^FD{0}^FS\n", q.ZonaNumero.ToString().Trim());
                        s += "\n";
                        s += "^CF0,30";
                        //  s += string.Format("^FO50,1155^FDZona: {0}^FS\n", q.Zona.Trim());
                        s += "\n";
                        s += "^XZ\n";
                        s += "\n";
                        zplToDoc += s;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    
                    
                    neti = neti + 1;
                }




                byte[] zpl = Encoding.UTF8.GetBytes(zplToDoc);
               
                await datos.pdfZPL(zpl, ruta);

            }

        }

        private void dgvFotosModifi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
                if (dgvFotosModifi.Rows.Count > 0)
            {
                string id = dgvFotosModifi.Rows[e.RowIndex].Cells[0].Value.ToString();

                DescargaDocs(id);

            }
            else
            {
                MessageBox.Show("No hay datos para buscar.");
            }

        }

        private void AltaEntrada_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void gunaTileButton5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas modificar la descripcion? \nTen en cuenta que este texto se muestra en la notificacion al cliente; si la entrada ya tiene un proceso hacer esto puede generar problemas, es preferible que mejor se modifique la nota", "CUIDADO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                detalles.Enabled = true;
                detalles.ReadOnly = false;
            }
            
        }

        private void btnAgregarBultos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas modificar los bultos? \nTen en cuenta que este proceso alterara la entrada, y la cantidad de etiquetas\nademas no debe hacerse si la entrada ya tiene un proceso.", "CUIDADO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                using (vistaBajaAgregaEntrada vEnt = new vistaBajaAgregaEntrada())
                {
                    vEnt.suOrigen = sucEntrada.SelectedValue.ToString().Trim();
                    vEnt.entrada = entradaBusqueda == "" || entradaBusqueda == default ? "00" : entradaBusqueda.Trim();
                    vEnt.odooId = lblNoOdoo.Text == "" || lblNoOdoo.Text == default ? "00" : lblNoOdoo.Text.Trim();
                    vEnt.pasado += new vistaBajaAgregaEntrada.pasar(ModificaEtiquetas);
                    vEnt.ShowDialog();
                    vEnt.pasado -= new vistaBajaAgregaEntrada.pasar(ModificaEtiquetas);


                   
                }
            }
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            PdfZPLcrea();
            //SelectPrinter();
        }

        private void alias_TextChanged(object sender, EventArgs e)
        {

        }

        private void mdfImg_Click(object sender, EventArgs e)
        {
            dgvFotosModifi.Visible = false;
            dgvDocs.Visible = true;
            sbeArchivos = "SI";
            mdfImg.BackColor = System.Drawing.Color.Bisque;
            iconButton2.Enabled = true;
            //iconButton2.Visible = true;
        }

        private void btnExactaEtiqueta_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(lblEntrada.Text)&& txbBuscarEnt.Visible == true)
            {
                SelectPrinterWithRange();
            }
            else
            {
                MessageBox.Show("Primero consulta la entrada.");
            }
           
        }

        private void bntImpEntC_Click(object sender, EventArgs e)
        {
           
            if (!String.IsNullOrWhiteSpace(lblEntrada.Text) && txbBuscarEnt.Visible == true)
            {
                llamareporte();
            }
            else
            {
                MessageBox.Show("Primero consulta la entrada.");
            }

        }

        private async void btnAltaProvEnt_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmProovedorAdd ent = new frmProovedorAdd())
                {

                    ent.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            proveedor.AutoCompleteCustomSource = await proveeList();
           
        }

        private void cbxDestinoModify_CheckedChanged(object sender)
        {
            if (cbxDestinoModify.Checked == true)
            {
                sucDestino.Enabled = true;
            }
            else
            {
                sucDestino.Enabled = false;
            }
        }
    }
}
