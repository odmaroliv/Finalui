using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Datosenti;
using Negocios;
using System.Threading;
using mainVentana.VistaInicioFoto;
using mainVentana.VistaInicioCoordinadores;
using mainVentana.vistaReportes;
using mainVentana.VistaCreditoCobranza;
using Datos.ViewModels;
using Datos.ViewModels.CXC;
using ClosedXML.Excel;
using Datos.ViewModels.Reportes;

namespace mainVentana
{
    public partial class Over : Form
    {
        Servicios vd = new Servicios(); // Indxa la clase de validcaiones 

        frmInicioCoordinadores frm = new frmInicioCoordinadores();
        private string _tipoBusqueda = "Ent";
        private bool _isBusy = false;
        private bool _isGunaBusy = false;
        private ImageList imgList = new ImageList();

        public Over()
        {
            InitializeComponent();
          
           
        }
        
        private async void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedCell = gunaDataGridView1.SelectedCells[0];
                if (selectedCell.ColumnIndex == gunaDataGridView1.Columns["C6"].Index)
                {
                    string ValorSuc = gunaDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string folioSeleccionado = selectedCell.Value.ToString();
                    await CargarMovimientosEnTreeView(folioSeleccionado, modo: 1, ValorSuc);
                }
                if (selectedCell.ColumnIndex == gunaDataGridView1.Columns["C9"].Index)
                {
                    string folioSeleccionado = selectedCell.Value.ToString();
                    await CargarMovimientosEnTreeView(folioSeleccionado,modo: 0);
                }
            }
            catch 
            {

              //  throw;
            }
          
           
        }
        
        
        private void Over_Load(object sender, EventArgs e)
        {
            if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "CSERVI")
            {

                frm.pasado += new frmInicioCoordinadores.pasar(refrescatabla);
                AbrirFormEnPanel(frm);
            }
            else if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "CXC")
            {
                VistaCXC ts = new VistaCXC();
                AbrirFormEnPanel(ts);
                btnCordAdmin.Visible = true;
                btnCordAdmin.Enabled = true;
            }
            else if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "ADMIN")
            {
                btnAdminAdmin.Enabled = true;
                btnCordAdmin.Enabled = true;
                btnArtu.Enabled = true;
                btnAdminAdmin.Visible = true;
                btnCordAdmin.Visible = true;
                btnArtu.Visible = true;
                btnCxcp.Visible = true;
            }

            else
            {
            tstflirk ts   = new tstflirk();
            AbrirFormEnPanel(ts);

            }
            CargaFecha();
            InitializeTreeViewWithImageList();
            // gunaDataGridView1.CurrentCell = null;
        }

        private void InitializeTreeViewWithImageList()
        {
            // Crear una nueva instancia de ImageList
           
            imgList.ImageSize = new Size(16, 16); // El tamaño de tus íconos
            imgList.ColorDepth = ColorDepth.Depth32Bit;

           
            imgList.Images.Add("tipoMovimiento", Properties.Resources.ver_mas);
            imgList.Images.Add("alert", Properties.Resources.clave);
            imgList.Images.Add("Carga", Properties.Resources.boxes);
            imgList.Images.Add("Salida", Properties.Resources.delivery_truck);
            imgList.Images.Add("Milla", Properties.Resources.clave);
            imgList.Images.Add("BILL", Properties.Resources.staff_picks);
            imgList.Images.Add("Cotización", Properties.Resources.delivery);
            imgList.Images.Add("Entrada", Properties.Resources.log_in);
            imgList.Images.Add("Recepción", Properties.Resources.warehouse);
            // Continúa agregando todas las imágenes que necesites

            // Asignar el ImageList al TreeView
            treeViewHistorial.ImageList = imgList;
        }
        private void CargaFecha()
        {
            dtFecha1.Value = DateTime.Now.AddDays(-30);
            dtFecha2.Value = DateTime.Now.AddDays(1);
            dtFecha1.MinDate = DateTime.Now.AddDays(-460);
            dtFecha1.MaxDate = DateTime.Now.AddDays(1);
            dtFecha2.MinDate = DateTime.Now.AddDays(-460);
            dtFecha2.MaxDate = DateTime.Now.AddDays(1);
        }
        public void busquedamain()
        {
            using (prueba1Entities modelo = new prueba1Entities())
            {
                //gunaDataGridView1.DataSource = vd.Cargabuscque();
                //MessageBox.Show(vd.Cargabuscque().ToString());
                // tb.id = gunaDataGridView1.CurrentCell.Value;
            }
        }

        #region hovers colores
        //-----botones inicio


        #endregion


        private void AbrirFormEnPanel(object formHijo)
        {


            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fh);
            this.panel1.Tag = fh;
            fh.Show();
        }

//        public delegate void pasado (string id) 


        public async Task refresh(string id, string tipo)
        {
           
            Negocios.Servicios vld = new Negocios.Servicios();
            gunaDataGridView1.DataSource = null;
            dtgDatos = await vld.Cargabuscque(id, tipo, dtFecha1.Value, dtFecha2.Value);
            gunaDataGridView1.DataSource = dtgDatos;
            
            vld = null;
        }

        

        private void gunaDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


        }


        private void formatodeceldas()
        {
            int filas = gunaDataGridView1.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                DateTime fechaactual = DateTime.Now;
                DateTime fechaent;

                
                if (!DateTime.TryParse(gunaDataGridView1.Rows[i].Cells[2].Value?.ToString().Trim(), out fechaent))
                {
                    fechaent = new DateTime(2021, 7, 6, 12, 16, 2); // Fecha por defecto
                }

                int tiempoEnDias = (fechaactual - fechaent).Days;

                
                string valorCelda4 = gunaDataGridView1.Rows[i].Cells[4].Value?.ToString().Trim().ToLower();
                string valorCelda5 = gunaDataGridView1.Rows[i].Cells[5].Value?.ToString().Trim().ToLower();
                string valorCelda3 = gunaDataGridView1.Rows[i].Cells[3].Value?.ToString().Trim().ToLower();
                string valorCelda19 = gunaDataGridView1.Rows[i].Cells[19].Value?.ToString().Trim();
                string valorCelda26 = gunaDataGridView1.Rows[i].Cells[26].Value?.ToString().Trim();

                // p String.Equals  no distinguen mayúsculas y minúsculas
                if (String.Equals(valorCelda4, valorCelda5, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(valorCelda19))
                {
                    gunaDataGridView1.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(68, 183, 255);
                    gunaDataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.FromArgb(255, 255, 255);
                }
                else if (String.Equals(valorCelda4, valorCelda5, StringComparison.OrdinalIgnoreCase) && string.IsNullOrWhiteSpace(valorCelda19))
                {
                    gunaDataGridView1.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(248, 44, 155);
                    gunaDataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.FromArgb(255, 255, 255);
                }
                else if (!String.Equals(valorCelda4, valorCelda3, StringComparison.OrdinalIgnoreCase) && !String.Equals(valorCelda3, valorCelda5, StringComparison.OrdinalIgnoreCase))
                {
                    gunaDataGridView1.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(252, 173, 5);
                    gunaDataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.FromArgb(255, 255, 255);
                }

                if (!String.IsNullOrWhiteSpace(valorCelda26))
                {
                    gunaDataGridView1.Rows[i].Cells[2].Style.BackColor = Color.FromArgb(192, 64, 0);
                    gunaDataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.FromArgb(255, 255, 255);
                    gunaDataGridView1.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(192, 64, 0);
                    gunaDataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.FromArgb(255, 255, 255);
                }

                if (tiempoEnDias >= 10 && String.Equals(valorCelda5, valorCelda3, StringComparison.OrdinalIgnoreCase) && String.IsNullOrWhiteSpace(valorCelda19))
                {
                    gunaDataGridView1.Rows[i].Cells[2].Style.BackColor = Color.FromArgb(156, 19, 18);
                    gunaDataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.FromArgb(255, 255, 255);
                    gunaDataGridView1.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(156, 19, 18);
                    gunaDataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.FromArgb(255, 255, 255);
                }

                if (tiempoEnDias < 10 && String.Equals(valorCelda5, valorCelda3, StringComparison.OrdinalIgnoreCase) && String.IsNullOrWhiteSpace(valorCelda19))
                {
                    gunaDataGridView1.Rows[i].Cells[2].Style.BackColor = Color.FromArgb(19, 156, 18);
                    gunaDataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.FromArgb(255, 255, 255);
                    gunaDataGridView1.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(19, 156, 18);
                    gunaDataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.FromArgb(255, 255, 255);
                }
            }
        }



        private void gunaShadowPanel2_Click(object sender, EventArgs e)
        {
            Process calc = new Process { StartInfo = { FileName = @"calc.exe" } };
            calc.Start();

            //calc.WaitForExit();
        }

        private void gunaShadowPanel3_Click(object sender, EventArgs e)
        {
            if (ValidaTxt(gunaDataGridView1) == 1)
            {
                string entrada = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Process.Start("https://mail.google.com/mail/?ui=2&view=cm&fs=1&tf=1&to=sistemas@arnian.com&su=Info%20sobre%20entrada:" + entrada + "&body=" + entrada);
            }

        }

        private void gunaShadowPanel4_Click(object sender, EventArgs e)
        {
            if (ValidaTxt(gunaDataGridView1) == 1)
            {
                string entrada = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Process.Start("https://api.whatsapp.com/send?phone=5216643850871&text=" + entrada);

            }

        }

        //----------------- campo en blanco------
        public int ValidaTxt(DataGridView tb)
        { //retorna 1 si el campo contien informacion retorna 0 si esta vacio

            if (tb == null || tb.Rows.Count == 0)
            {
                Convert.ToInt32(MessageBox.Show("El campo Buscar Entrada no puede estar vacio", "EROR", MessageBoxButtons.OK));
                return 0;
            }
            else
            {
                return 1;

            }

        }

      
        private void gunaGradientTileButton5_Click(object sender, EventArgs e)
        {
            try
            {
                using (VistaOrSalida.frmOrdSalida salida = new VistaOrSalida.frmOrdSalida())
                {
                    salida.ShowDialog();
                }
                
             
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async Task CargarMovimientosEnTreeView(string etiquetaSeleccionada, int modo, string sucursalOr = null)
        {
            if (_isGunaBusy)
            {
                return;
            }
            _isGunaBusy = true;

            Negocios.Servicios vld = new Negocios.Servicios();
            List<vmHistorialMovimientos> movimientos;

            if (modo == 0)
            {
                movimientos = (await vld.BuscaHistorialDeMovimientosPorEtiqueta(etiquetaSeleccionada))
                    .OrderByDescending(m => m.FechaHoraMovimiento)
                    .ToList();
            }
            else
            {
                movimientos = (await vld.BuscaHistorialDeMovimientosPorFolio(Convert.ToInt32(etiquetaSeleccionada), sucursalOr))
                    .OrderByDescending(m => m.FechaHoraMovimiento)
                    .ToList();
            }
            Font regularFont = new Font("Consolas", 9.75F, FontStyle.Regular);
            Font boldFont = new Font("Consolas", 9.75F, FontStyle.Bold);

            treeViewHistorial.Font = regularFont;
            treeViewHistorial.Nodes.Clear();
            string[] titulos = new string[] { "ALERT:", "DOC:", "ORIGEN:", "DESTINO:", "FECHA:", "RESPONS:", "TRIGGER:" };
            int maxLength = titulos.Max(t => t.Length);
           

            treeViewHistorial.ImageList = imgList;
            if (!movimientos.Any())
            {
                _isGunaBusy = false; 
                return;
            }

            
            int maxTipoMovimientoLength = movimientos.Max(m => m.NombreTipoMovimiento.Length);

            int maxTipoYObservacionesLength = movimientos.Max(m =>
            $"{m.NombreTipoMovimiento} - ({m.Observaciones})".Length + " - []".Length);

            treeViewHistorial.Nodes.Clear();

            string tipoD = modo == 0 ? "ETIQUETA: " : "ENTRADA: ";
            TreeNode nodoPrincipal = new TreeNode($"{tipoD} {etiquetaSeleccionada}")
            {
                NodeFont = new Font(treeViewHistorial.Font, FontStyle.Bold),
                ImageKey = "tipoMovimiento", 
                SelectedImageKey = "tipoMovimiento"
            };
            treeViewHistorial.Nodes.Add(nodoPrincipal);

          
            foreach (vmHistorialMovimientos movimiento in movimientos)
            {
                
                string nombreTipoMovimientoRelleno = movimiento.NombreTipoMovimiento.PadRight(maxTipoMovimientoLength, ' ');
                string tipoYObservaciones = $"{nombreTipoMovimientoRelleno} - ({movimiento.Observaciones})";
                string tipoYObservacionesRelleno = tipoYObservaciones.PadRight(maxTipoYObservacionesLength, ' ');
                string imagenName = movimiento.NombreTipoMovimiento?.Trim();


                TreeNode nodoMovimiento = new TreeNode($"{tipoYObservacionesRelleno} - [{movimiento.FechaHoraMovimiento.ToString("d")}]")
                {
                    ImageKey = imagenName, 
                    SelectedImageKey = "alert",
                    ToolTipText = "Haz clic para más detalles...",
                    ForeColor = Color.DarkSlateBlue,
                    NodeFont = boldFont
                };
                nodoPrincipal.Nodes.Add(nodoMovimiento);
                if (!string.IsNullOrEmpty(movimiento.DescripcionCorta))
                {
                    nodoMovimiento.Nodes.Add(new TreeNode($"{titulos[0].PadRight(maxLength)}    → {movimiento.DescripcionCorta}"));
                }
                if (!string.IsNullOrEmpty(movimiento.DocumentoAnterior))
                {
                    nodoMovimiento.Nodes.Add(new TreeNode($"{titulos[1].PadRight(maxLength)}    → {movimiento.DocumentoAnterior}"));
                }
                if (!string.IsNullOrEmpty(movimiento.Origen))
                {
                    nodoMovimiento.Nodes.Add(new TreeNode($"{titulos[2].PadRight(maxLength)}    → {movimiento.Origen}"));
                }
                if (!string.IsNullOrEmpty(movimiento.Destino))
                {
                    nodoMovimiento.Nodes.Add(new TreeNode($"{titulos[3].PadRight(maxLength)}    → {movimiento.Destino}"));
                }
                if (movimiento.FechaHoraMovimiento != DateTime.MinValue) // Asumiendo que es una fecha que nunca será la mínima
                {
                    nodoMovimiento.Nodes.Add(new TreeNode($"{titulos[4].PadRight(maxLength)}    → {movimiento.FechaHoraMovimiento.ToString("g")}"));
                }
                if (!string.IsNullOrEmpty(movimiento.UsuarioResponsable))
                {
                    nodoMovimiento.Nodes.Add(new TreeNode($"{titulos[5].PadRight(maxLength)}    → {movimiento.UsuarioResponsable}"));
                }
                if (!string.IsNullOrEmpty(movimiento.Observaciones))
                {
                    nodoMovimiento.Nodes.Add(new TreeNode($"{titulos[6].PadRight(maxLength)}    → {movimiento.Observaciones}"));
                }

            }

            // Mantener los nodos contraídos por defecto
            nodoPrincipal.Expand();

            _isGunaBusy = false;
        }



        private async void gunaTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_isBusy==false)
                {
                    _isBusy = true;
                    loadControl1.Visible = true;
                    bool esTecleado = false;
                    string id = "";
                    try
                    {
                        treeViewHistorial.Nodes.Clear();
                        switch (_tipoBusqueda)
                        {
                            case "Ent":
                                if (esTecleado) return;
                                esTecleado = true;
                                ValidabPrincipal();
                                id = gunaTextBox2.Text;
                                await refresh(id, _tipoBusqueda);
                                if (gunaDataGridView1.RowCount <= 0)
                                {
                                    MessageBox.Show("No se encontraron datos");
                                    return;
                                }
                                await Task.Run(() => { Thread.Sleep(1000); });
                                formatodeceldas();
                                e.Handled = true;
                                break;
                            case "Flete":
                                if (esTecleado) return;
                                esTecleado = true;
                                id = gunaTextBox2.Text;
                                if (String.IsNullOrWhiteSpace(gunaTextBox2.Text) || id.Length < 4)
                                {
                                    MessageBox.Show("El campo de busqueda esta vacio!");
                                    return;
                                }
                                await refresh(id, _tipoBusqueda);
                                if (gunaDataGridView1.RowCount <= 0)
                                {
                                    MessageBox.Show("No se encontraron datos");
                                    return;
                                }
                                await Task.Run(() => { Thread.Sleep(1000); });
                                formatodeceldas();
                                e.Handled = true;
                                break;
                            case "Cliente":
                                if (esTecleado) return;
                                esTecleado = true;
                                id = gunaTextBox2.Text;
                                if (id == "" || id.Length < 2)
                                {
                                    MessageBox.Show("El campo de busqueda esta vacio!");
                                    return;
                                }
                                await refresh(id, _tipoBusqueda);
                                if (gunaDataGridView1.RowCount <= 0)
                                {
                                    MessageBox.Show("No se encontraron datos");
                                    return;
                                }
                                await Task.Run(() => { Thread.Sleep(1000); });
                                formatodeceldas();
                                e.Handled = true;
                                break;
                            case "Usuario":
                                if (esTecleado) return;
                                esTecleado = true;
                                /* //id = gunaTextBox2.Text;
                                 if (id == "" || id.Length < 2)
                                 {
                                     MessageBox.Show("El campo de busqueda esta vacio!");
                                     return;
                                 }*/
                                await refresh(id, _tipoBusqueda);
                                if (gunaDataGridView1.RowCount <= 0)
                                {
                                    MessageBox.Show("No se encontraron datos");
                                    return;
                                }
                                await Task.Run(() => { Thread.Sleep(1000); });
                                formatodeceldas();
                                e.Handled = true;
                                break;
                            case "SD":
                                if (esTecleado) return;
                                esTecleado = true;
                                /* //id = gunaTextBox2.Text;
                                 if (id == "" || id.Length < 2)
                                 {
                                     MessageBox.Show("El campo de busqueda esta vacio!");
                                     return;
                                 }*/
                                await refresh(id, _tipoBusqueda);
                                if (gunaDataGridView1.RowCount <= 0)
                                {
                                    MessageBox.Show("No se encontraron datos");
                                    return;
                                }
                                await Task.Run(() => { Thread.Sleep(1000); });
                                formatodeceldas();
                                e.Handled = true;
                                break;
                            case "TJ":
                                if (esTecleado) return;
                                esTecleado = true;
                                /* //id = gunaTextBox2.Text;
                                 if (id == "" || id.Length < 2)
                                 {
                                     MessageBox.Show("El campo de busqueda esta vacio!");
                                     return;
                                 }*/
                                await refresh(id, _tipoBusqueda);
                                if (gunaDataGridView1.RowCount <= 0)
                                {
                                    MessageBox.Show("No se encontraron datos");
                                    return;
                                }
                                await Task.Run(() => { Thread.Sleep(1000); });
                                formatodeceldas();
                                e.Handled = true;
                                break;
                            case "CSL":
                                if (esTecleado) return;
                                esTecleado = true;
                                /* //id = gunaTextBox2.Text;
                                 if (id == "" || id.Length < 2)
                                 {
                                     MessageBox.Show("El campo de busqueda esta vacio!");
                                     return;
                                 }*/
                                await refresh(id, _tipoBusqueda);
                                if (gunaDataGridView1.RowCount <= 0)
                                {
                                    MessageBox.Show("No se encontraron datos");
                                    return;
                                }
                                await Task.Run(() => { Thread.Sleep(1000); });
                                formatodeceldas();
                                e.Handled = true;
                                break;
                            case "IMSD":
                                if (esTecleado) return;
                                esTecleado = true;
                                /* //id = gunaTextBox2.Text;
                                 if (id == "" || id.Length < 2)
                                 {
                                     MessageBox.Show("El campo de busqueda esta vacio!");
                                     return;
                                 }*/
                                await refresh(id, _tipoBusqueda);
                                if (gunaDataGridView1.RowCount <= 0)
                                {
                                    MessageBox.Show("No se encontraron datos");
                                    return;
                                }
                                await Task.Run(() => { Thread.Sleep(1000); });
                                formatodeceldas();
                                e.Handled = true;
                                break;
                            case "usrEnt":
                                if (esTecleado) return;
                                esTecleado = true;
                                id = gunaTextBox2.Text;
                                if (id == "" || id.Length < 2)
                                {
                                    MessageBox.Show("El campo de busqueda esta vacio!");
                                    return;
                                }
                                id = id.Trim();
                                await refresh(id, _tipoBusqueda);
                                if (gunaDataGridView1.RowCount <= 0)
                                {
                                    MessageBox.Show("No se encontraron datos");
                                    return;
                                }
                                await Task.Run(() => { Thread.Sleep(1000); });
                                formatodeceldas();
                                e.Handled = true;
                                break;
                            case "Inventario":
                                if (esTecleado) return;
                                esTecleado = true;
                                //ValidabPrincipal();
                                id = gunaTextBox2.Text;
                                await refresh(id, _tipoBusqueda);
                                if (gunaDataGridView1.RowCount <= 0)
                                {
                                    MessageBox.Show("No se encontraron datos");
                                    return;
                                }
                                await Task.Run(() => { Thread.Sleep(1000); });
                                formatodeceldas();
                                e.Handled = true;
                                break;

                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        esTecleado = false;
                        loadControl1.Visible = false;
                        _isBusy = false;
                    }
                }
              
               
            }
        }


        public async Task refrescatabla( string id)
        {
            gunaTextBox2.Text = id;
            await refresh(id,_tipoBusqueda);
            await Task.Run(() => { Thread.Sleep(1000); });
            formatodeceldas();
            
        }

        private void ValidabPrincipal()
        {
            if (gunaTextBox2.Text == "")
            {
                MessageBox.Show("El campo de busqueda esta vacio!");
                return;
            }
            int datparseado;
            bool bent = Int32.TryParse(gunaTextBox2.Text, out datparseado);
            if (bent == true)
            {
                gunaTextBox2.Text = datparseado.ToString("D7");
            }
            else
            {
                MessageBox.Show("Las entradas tienen que ser un codigo numerico, y no pueden contener letras");
                return;
            }
        }

        private void gunaTextBox2_MouseEnter(object sender, EventArgs e)
        {
            if (gunaTextBox2.Text == "Buscar...")
            {
                gunaTextBox2.Text = "";

            }
        }

        private void gunaTextBox2_MouseLeave(object sender, EventArgs e)
        {
            //label4.Text = "Busqueda rapida de entrada :)";
        }

        private void gunaDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gunaDataGridView1.Rows.Count > 0)
            {
                string id = "";
              string orig = "";
                try
                {
                    string nombrecolumna = gunaDataGridView1.Columns[e.ColumnIndex].HeaderText;


                    if (nombrecolumna.Trim() == "Link" && gunaDataGridView1.Rows[e.RowIndex].Cells[26].Value.ToString().Contains("BTRACKSALIDA"))
                    {
                        string valorEnt = gunaDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        string ValorSuc = gunaDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        string url = string.Format("https://arniangroup.dispatchtrack.com/search/{0}", ValorSuc.Trim() + "-" + valorEnt.Trim());
                        System.Diagnostics.Process.Start(url);
                        return;

                    }

                     id = gunaDataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString();
                     orig = gunaDataGridView1.Rows[e.RowIndex].Cells[3].Value?.ToString();




                    string valorPrimerCelda = gunaDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
                catch 
                {

                   // throw;
                }
                if (String.IsNullOrWhiteSpace(orig) || String.IsNullOrWhiteSpace(id))
                {
                    MessageBox.Show("Ocurrio un error");
                    return;
                }
                frmSelectorFotos frm = new frmSelectorFotos();
                frm.txbEntrada.Text = orig + "-UD3501-"+id;
                frm.ShowDialog();
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("No hay datos para buscar.");
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            frmInicioCoordinadores frm = new frmInicioCoordinadores();
            frm.ShowDialog();

        }

        private void Over_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm.Dispose();
            frm.Close();
            this.Dispose();
            this.Close();
        }

        private void skyButton1_Click(object sender, EventArgs e)
        {

            if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "ADMIN")
            {
               
                frm.pasado += new frmInicioCoordinadores.pasar(refrescatabla);
                AbrirFormEnPanel(frm);
            }
          

        }

        private void skyButton2_Click(object sender, EventArgs e)
        {
            if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "ADMIN")
            {
             
                tstflirk ts = new tstflirk();
                AbrirFormEnPanel(ts);
            }

        }

        private void skyButton1_Click_1(object sender, EventArgs e)
        {
            if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "ADMIN")
            {

                frmVentaPequeña ts = new frmVentaPequeña();
                AbrirFormEnPanel(ts);
            }
        }

        private void skyButton1_Click_2(object sender, EventArgs e)
        {
            if (Negocios.Common.Cache.CacheLogin.rol.Trim() == "ADMIN")
            {

                VistaCXC ts = new VistaCXC();
                AbrirFormEnPanel(ts);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton rd = (RadioButton)sender;


            _tipoBusqueda = rd.Tag.ToString();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void btnToExcel_Click(object sender, EventArgs e)
        {
            if (gunaDataGridView1.Rows.Count ==0)
            {
                return;
            }
            await GeneraExcel();
        }
        List<BusquedaInicial> dtgDatos = new List<BusquedaInicial>();

        private async Task GeneraExcel()
        {
          
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Guardar archivo de Excel";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string nm = saveFileDialog.FileName;
            await Task.Run(() =>
            {



                try
                {
                    if (dtgDatos.Count() <= 0)
                    {
                        MessageBox.Show("No hay datos para Enviar");

                        return;
                    }
                    btnToExcel.Enabled = false;
                    loadControl1.Visible = true;
                    // Mostrar el diálogo para seleccionar la ubicación y el nombre del archivo


                    string fullPath = nm;
                    new Over().Export<BusquedaInicial>(dtgDatos, fullPath, "salida");
                    MessageBox.Show("El documento se creó satisfactoriamente", "Creado");

                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error", "Error");

                    throw;
                }
                finally
                {
                    loadControl1.Invoke(new Action(() => { loadControl1.Visible = false; }));
                    btnToExcel.Invoke(new Action(() => { btnToExcel.Enabled = true; }));
                }
            });


        }

        public bool Export<T>(List<T> list, string file, string nombre)
        {
            bool exportado = false;
            using (XLWorkbook xlfile = new XLWorkbook())
            {
                xlfile.AddWorksheet(nombre).FirstCell().InsertTable<T>(list, false);
                //xlfile.Worksheets.Add("Reporte");
                //xlfile.Table("Reporte").ShowAutoFilter = false;// Disable AutoFilter.
                //xlfile.Table(nombre).Theme = XLTableTheme.TableStyleDark5;// Remove Theme.
                xlfile.SaveAs(file);
                exportado = true;

            }
            return exportado;
        }

        private void gunaDataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = gunaDataGridView1.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    // Des-selecciona cualquier selección actual
                    gunaDataGridView1.ClearSelection();
                    // Selecciona la celda en la cual se hizo clic derecho
                    gunaDataGridView1[hitTestInfo.ColumnIndex, hitTestInfo.RowIndex].Selected = true;
                }
            }
        }
        //--------------grafuca

    }
}
