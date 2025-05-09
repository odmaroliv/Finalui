﻿using System.Drawing;
using System.Windows.Forms;

namespace mainVentana
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
           
        }
        

        private void initialize()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
       


        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lblRol = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.lbFecha = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblNombreUsr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.tmFechaHora = new System.Windows.Forms.Timer(this.components);
            this.panel17 = new System.Windows.Forms.Panel();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonOrbMenuItem2 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonOrbMenuItem3 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonOrbRecentItem1 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonDescriptionMenuItem1 = new System.Windows.Forms.RibbonDescriptionMenuItem();
            this.rpnlInicio = new System.Windows.Forms.RibbonPanel();
            this.rbtnEntrada = new System.Windows.Forms.RibbonButton();
            this.rbtnEntradaAlta = new System.Windows.Forms.RibbonButton();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.rbtnCargas = new System.Windows.Forms.RibbonButton();
            this.rbtnSalida = new System.Windows.Forms.RibbonButton();
            this.rbtnRecepcion = new System.Windows.Forms.RibbonButton();
            this.rbtnBill = new System.Windows.Forms.RibbonButton();
            this.rbtnCord = new System.Windows.Forms.RibbonButton();
            this.vbtnCotizacion = new System.Windows.Forms.RibbonButton();
            this.rCordbtnBuscaCot = new System.Windows.Forms.RibbonButton();
            this.vbtnClientes = new System.Windows.Forms.RibbonButton();
            this.oldrpKepler = new System.Windows.Forms.RibbonButton();
            this.btnCargaTo = new System.Windows.Forms.RibbonButton();
            this.consultaBill = new System.Windows.Forms.RibbonButton();
            this.rbtnEntregasPruebas = new System.Windows.Forms.RibbonButton();
            this.rbtnConsultaCargaCord = new System.Windows.Forms.RibbonButton();
            this.rbtnReportes = new System.Windows.Forms.RibbonButton();
            this.rbReporteSalida = new System.Windows.Forms.RibbonButton();
            this.rbReporteClienteXcord = new System.Windows.Forms.RibbonButton();
            this.rbRepEntradasSD = new System.Windows.Forms.RibbonButton();
            this.rbRepClientesActivos = new System.Windows.Forms.RibbonButton();
            this.rbRepClienteXZona = new System.Windows.Forms.RibbonButton();
            this.rbRepCotXCantidad = new System.Windows.Forms.RibbonButton();
            this.rbtnAjustes = new System.Windows.Forms.RibbonButton();
            this.apiConfig = new System.Windows.Forms.RibbonButton();
            this.ribbonButton6 = new System.Windows.Forms.RibbonButton();
            this.rbAgregarUsuario = new System.Windows.Forms.RibbonButton();
            this.rbtnMovimientos = new System.Windows.Forms.RibbonButton();
            this.rbtnInventario = new System.Windows.Forms.RibbonButton();
            this.rpnlAccesosWeb = new System.Windows.Forms.RibbonPanel();
            this.ribbonItemGroup1 = new System.Windows.Forms.RibbonItemGroup();
            this.lblWha = new System.Windows.Forms.RibbonLabel();
            this.lblWebex = new System.Windows.Forms.RibbonLabel();
            this.lblGmail = new System.Windows.Forms.RibbonLabel();
            this.lblAmazon = new System.Windows.Forms.RibbonLabel();
            this.rpnlSuc = new System.Windows.Forms.RibbonPanel();
            this.rcmbSucAct = new System.Windows.Forms.RibbonComboBox();
            this.cbxiSD = new System.Windows.Forms.RibbonButton();
            this.cbxiTJ = new System.Windows.Forms.RibbonButton();
            this.cbxiCSL = new System.Windows.Forms.RibbonButton();
            this.cbxiIMSD = new System.Windows.Forms.RibbonButton();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.rtabMy = new System.Windows.Forms.RibbonTab();
            this.rpnlGeneralesUsuario = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.rtabWMS = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonDescriptionMenuItem2 = new System.Windows.Forms.RibbonDescriptionMenuItem();
            this.panelContenedorForm = new System.Windows.Forms.Panel();
            this.rbRepEntradasTotalesPorUsuario = new System.Windows.Forms.RibbonButton();
            this.panel11.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel17.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.panel13);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 707);
            this.panel11.Margin = new System.Windows.Forms.Padding(2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1245, 74);
            this.panel11.TabIndex = 1;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(58)))), ((int)(((byte)(88)))));
            this.panel13.Controls.Add(this.lblRol);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.lblNombreUsr);
            this.panel13.Controls.Add(this.label3);
            this.panel13.Controls.Add(this.pictureBox7);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1245, 72);
            this.panel13.TabIndex = 6;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.ForeColor = System.Drawing.Color.White;
            this.lblRol.Location = new System.Drawing.Point(341, 37);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(0, 16);
            this.lblRol.TabIndex = 9;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.panel16);
            this.panel14.Controls.Add(this.panel15);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel14.Location = new System.Drawing.Point(1005, 0);
            this.panel14.Margin = new System.Windows.Forms.Padding(2);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(240, 72);
            this.panel14.TabIndex = 8;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.lbFecha);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(0, 47);
            this.panel16.Margin = new System.Windows.Forms.Padding(2);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(240, 25);
            this.panel16.TabIndex = 1;
            // 
            // lbFecha
            // 
            this.lbFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbFecha.ForeColor = System.Drawing.Color.White;
            this.lbFecha.Location = new System.Drawing.Point(0, 0);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(240, 25);
            this.lbFecha.TabIndex = 4;
            this.lbFecha.Text = "Lunes, 26 de septiembre 2022";
            this.lbFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.lblHora);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Margin = new System.Windows.Forms.Padding(2);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(240, 47);
            this.panel15.TabIndex = 0;
            // 
            // lblHora
            // 
            this.lblHora.BackColor = System.Drawing.Color.Transparent;
            this.lblHora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.White;
            this.lblHora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHora.Location = new System.Drawing.Point(0, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(240, 47);
            this.lblHora.TabIndex = 1;
            this.lblHora.Text = "21:49:45";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNombreUsr
            // 
            this.lblNombreUsr.AutoSize = true;
            this.lblNombreUsr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsr.ForeColor = System.Drawing.Color.White;
            this.lblNombreUsr.Location = new System.Drawing.Point(67, 37);
            this.lblNombreUsr.Name = "lblNombreUsr";
            this.lblNombreUsr.Size = new System.Drawing.Size(0, 16);
            this.lblNombreUsr.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(68, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Arnian Group";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::mainVentana.Properties.Resources.arnian_gr;
            this.pictureBox7.Location = new System.Drawing.Point(12, 12);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(43, 45);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 3;
            this.pictureBox7.TabStop = false;
            // 
            // tmFechaHora
            // 
            this.tmFechaHora.Tick += new System.EventHandler(this.tmFechaHora_Tick);
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.SystemColors.Control;
            this.panel17.Controls.Add(this.ribbon1);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Margin = new System.Windows.Forms.Padding(2);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(1245, 120);
            this.panel17.TabIndex = 3;
            // 
            // ribbon1
            // 
            this.ribbon1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ribbon1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ribbon1.BorderMode = System.Windows.Forms.RibbonWindowMode.InsideWindow;
            this.ribbon1.ContextSpace = -25;
            this.ribbon1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.ForeColor = System.Drawing.Color.White;
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbMenuItem1);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbMenuItem2);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbMenuItem3);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonSeparator1);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.RecentItems.Add(this.ribbonOrbRecentItem1);
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 207);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAccessToolbar.DropDownButtonVisible = false;
            this.ribbon1.QuickAccessToolbar.Enabled = false;
            this.ribbon1.QuickAccessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1245, 117);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab3);
            this.ribbon1.Tabs.Add(this.rtabMy);
            this.ribbon1.Tabs.Add(this.rtabWMS);
            this.ribbon1.TabSpacing = 4;
            this.ribbon1.Text = "ribbon1";
            // 
            // ribbonOrbMenuItem1
            // 
            this.ribbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.Image")));
            this.ribbonOrbMenuItem1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.LargeImage")));
            this.ribbonOrbMenuItem1.Name = "ribbonOrbMenuItem1";
            this.ribbonOrbMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.SmallImage")));
            this.ribbonOrbMenuItem1.Text = "Sesion";
            // 
            // ribbonOrbMenuItem2
            // 
            this.ribbonOrbMenuItem2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem2.Image")));
            this.ribbonOrbMenuItem2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem2.LargeImage")));
            this.ribbonOrbMenuItem2.Name = "ribbonOrbMenuItem2";
            this.ribbonOrbMenuItem2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem2.SmallImage")));
            this.ribbonOrbMenuItem2.Text = "Ayuda";
            // 
            // ribbonOrbMenuItem3
            // 
            this.ribbonOrbMenuItem3.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem3.Image")));
            this.ribbonOrbMenuItem3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem3.LargeImage")));
            this.ribbonOrbMenuItem3.Name = "ribbonOrbMenuItem3";
            this.ribbonOrbMenuItem3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem3.SmallImage")));
            this.ribbonOrbMenuItem3.Text = "ribbonOrbMenuItem3";
            this.ribbonOrbMenuItem3.Visible = false;
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.Name = "ribbonSeparator1";
            // 
            // ribbonOrbRecentItem1
            // 
            this.ribbonOrbRecentItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem1.Image")));
            this.ribbonOrbRecentItem1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem1.LargeImage")));
            this.ribbonOrbRecentItem1.Name = "ribbonOrbRecentItem1";
            this.ribbonOrbRecentItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem1.SmallImage")));
            this.ribbonOrbRecentItem1.Text = "Salir";
            this.ribbonOrbRecentItem1.Click += new System.EventHandler(this.ribbonOrbRecentItem1_Click);
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.rpnlInicio);
            this.ribbonTab1.Panels.Add(this.rpnlAccesosWeb);
            this.ribbonTab1.Panels.Add(this.rpnlSuc);
            this.ribbonTab1.Text = "Inicio";
            this.ribbonTab1.ToolTipImage = global::mainVentana.Properties.Resources.work_from_home;
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ButtonMoreEnabled = false;
            this.ribbonPanel1.ButtonMoreVisible = false;
            this.ribbonPanel1.Items.Add(this.ribbonButton1);
            this.ribbonPanel1.Items.Add(this.ribbonSeparator2);
            this.ribbonPanel1.Items.Add(this.ribbonButton2);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "General";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = global::mainVentana.Properties.Resources.dupdo;
            this.ribbonButton1.LargeImage = global::mainVentana.Properties.Resources.dupdo;
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "LOG";
            this.ribbonButton1.Click += new System.EventHandler(this.ribbonButton1_Click);
            // 
            // ribbonSeparator2
            // 
            this.ribbonSeparator2.Name = "ribbonSeparator2";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.DropDownItems.Add(this.ribbonDescriptionMenuItem1);
            this.ribbonButton2.Image = global::mainVentana.Properties.Resources.papel;
            this.ribbonButton2.LargeImage = global::mainVentana.Properties.Resources.papel;
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "Decimal";
            this.ribbonButton2.Click += new System.EventHandler(this.ribbonButton2_Click);
            // 
            // ribbonDescriptionMenuItem1
            // 
            this.ribbonDescriptionMenuItem1.DescriptionBounds = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ribbonDescriptionMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonDescriptionMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.Image")));
            this.ribbonDescriptionMenuItem1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.LargeImage")));
            this.ribbonDescriptionMenuItem1.Name = "ribbonDescriptionMenuItem1";
            this.ribbonDescriptionMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.SmallImage")));
            this.ribbonDescriptionMenuItem1.Text = "ribbonDescriptionMenuItem1";
            // 
            // rpnlInicio
            // 
            this.rpnlInicio.ButtonMoreEnabled = false;
            this.rpnlInicio.ButtonMoreVisible = false;
            this.rpnlInicio.Items.Add(this.rbtnEntrada);
            this.rpnlInicio.Items.Add(this.rbtnCargas);
            this.rpnlInicio.Items.Add(this.rbtnSalida);
            this.rpnlInicio.Items.Add(this.rbtnRecepcion);
            this.rpnlInicio.Items.Add(this.rbtnBill);
            this.rpnlInicio.Items.Add(this.rbtnCord);
            this.rpnlInicio.Items.Add(this.rbtnReportes);
            this.rpnlInicio.Items.Add(this.rbtnAjustes);
            this.rpnlInicio.Items.Add(this.rbtnMovimientos);
            this.rpnlInicio.Items.Add(this.rbtnInventario);
            this.rpnlInicio.Name = "rpnlInicio";
            this.rpnlInicio.Text = "Pantallas";
            // 
            // rbtnEntrada
            // 
            this.rbtnEntrada.DropDownItems.Add(this.rbtnEntradaAlta);
            this.rbtnEntrada.DropDownItems.Add(this.ribbonButton5);
            this.rbtnEntrada.Image = global::mainVentana.Properties.Resources.log_in;
            this.rbtnEntrada.LargeImage = global::mainVentana.Properties.Resources.log_in;
            this.rbtnEntrada.Name = "rbtnEntrada";
            this.rbtnEntrada.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnEntrada.SmallImage")));
            this.rbtnEntrada.Style = System.Windows.Forms.RibbonButtonStyle.SplitDropDown;
            this.rbtnEntrada.Text = "Entrada";
            this.rbtnEntrada.Click += new System.EventHandler(this.rbtnEntrada_Click);
            // 
            // rbtnEntradaAlta
            // 
            this.rbtnEntradaAlta.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnEntradaAlta.Image = ((System.Drawing.Image)(resources.GetObject("rbtnEntradaAlta.Image")));
            this.rbtnEntradaAlta.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbtnEntradaAlta.LargeImage")));
            this.rbtnEntradaAlta.Name = "rbtnEntradaAlta";
            this.rbtnEntradaAlta.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnEntradaAlta.SmallImage")));
            this.rbtnEntradaAlta.Text = "Nueva Entrada";
            this.rbtnEntradaAlta.Click += new System.EventHandler(this.rbtnEntrada_Click);
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonButton5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.Image")));
            this.ribbonButton5.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.LargeImage")));
            this.ribbonButton5.Name = "ribbonButton5";
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "Alta Proovedor";
            this.ribbonButton5.Click += new System.EventHandler(this.ribbonButton5_Click);
            // 
            // rbtnCargas
            // 
            this.rbtnCargas.Image = global::mainVentana.Properties.Resources.boxes;
            this.rbtnCargas.LargeImage = global::mainVentana.Properties.Resources.boxes;
            this.rbtnCargas.Name = "rbtnCargas";
            this.rbtnCargas.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCargas.SmallImage")));
            this.rbtnCargas.Text = "Carga";
            this.rbtnCargas.Click += new System.EventHandler(this.rbtnCargas_Click);
            // 
            // rbtnSalida
            // 
            this.rbtnSalida.Image = global::mainVentana.Properties.Resources.delivery_truck;
            this.rbtnSalida.LargeImage = global::mainVentana.Properties.Resources.delivery_truck;
            this.rbtnSalida.Name = "rbtnSalida";
            this.rbtnSalida.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnSalida.SmallImage")));
            this.rbtnSalida.Text = "Salida";
            this.rbtnSalida.Click += new System.EventHandler(this.rbtnSalida_Click);
            // 
            // rbtnRecepcion
            // 
            this.rbtnRecepcion.Image = global::mainVentana.Properties.Resources.warehouse;
            this.rbtnRecepcion.LargeImage = global::mainVentana.Properties.Resources.warehouse;
            this.rbtnRecepcion.Name = "rbtnRecepcion";
            this.rbtnRecepcion.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnRecepcion.SmallImage")));
            this.rbtnRecepcion.Text = "Recepcion";
            this.rbtnRecepcion.Click += new System.EventHandler(this.rbtnRecepcion_Click);
            // 
            // rbtnBill
            // 
            this.rbtnBill.Image = global::mainVentana.Properties.Resources.staff_picks;
            this.rbtnBill.LargeImage = global::mainVentana.Properties.Resources.staff_picks;
            this.rbtnBill.Name = "rbtnBill";
            this.rbtnBill.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnBill.SmallImage")));
            this.rbtnBill.Text = "BOL";
            this.rbtnBill.Click += new System.EventHandler(this.rbtnBill_Click);
            // 
            // rbtnCord
            // 
            this.rbtnCord.DropDownItems.Add(this.vbtnCotizacion);
            this.rbtnCord.DropDownItems.Add(this.rCordbtnBuscaCot);
            this.rbtnCord.DropDownItems.Add(this.vbtnClientes);
            this.rbtnCord.DropDownItems.Add(this.oldrpKepler);
            this.rbtnCord.DropDownItems.Add(this.btnCargaTo);
            this.rbtnCord.DropDownItems.Add(this.consultaBill);
            this.rbtnCord.DropDownItems.Add(this.rbtnEntregasPruebas);
            this.rbtnCord.DropDownItems.Add(this.rbtnConsultaCargaCord);
            this.rbtnCord.Image = global::mainVentana.Properties.Resources.b2c__2_;
            this.rbtnCord.LargeImage = global::mainVentana.Properties.Resources.b2c__2_;
            this.rbtnCord.Name = "rbtnCord";
            this.rbtnCord.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCord.SmallImage")));
            this.rbtnCord.Style = System.Windows.Forms.RibbonButtonStyle.SplitDropDown;
            this.rbtnCord.Text = "Ejecutivo";
            this.rbtnCord.Click += new System.EventHandler(this.rbtnCord_Click);
            // 
            // vbtnCotizacion
            // 
            this.vbtnCotizacion.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.vbtnCotizacion.Image = ((System.Drawing.Image)(resources.GetObject("vbtnCotizacion.Image")));
            this.vbtnCotizacion.LargeImage = ((System.Drawing.Image)(resources.GetObject("vbtnCotizacion.LargeImage")));
            this.vbtnCotizacion.Name = "vbtnCotizacion";
            this.vbtnCotizacion.SmallImage = ((System.Drawing.Image)(resources.GetObject("vbtnCotizacion.SmallImage")));
            this.vbtnCotizacion.Text = "Nueva cotización";
            this.vbtnCotizacion.Click += new System.EventHandler(this.vbtnCotizacion_Click);
            // 
            // rCordbtnBuscaCot
            // 
            this.rCordbtnBuscaCot.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rCordbtnBuscaCot.Image = ((System.Drawing.Image)(resources.GetObject("rCordbtnBuscaCot.Image")));
            this.rCordbtnBuscaCot.LargeImage = ((System.Drawing.Image)(resources.GetObject("rCordbtnBuscaCot.LargeImage")));
            this.rCordbtnBuscaCot.Name = "rCordbtnBuscaCot";
            this.rCordbtnBuscaCot.SmallImage = ((System.Drawing.Image)(resources.GetObject("rCordbtnBuscaCot.SmallImage")));
            this.rCordbtnBuscaCot.Text = "Buscar Cotización";
            this.rCordbtnBuscaCot.Click += new System.EventHandler(this.rCordbtnBuscaCot_Click);
            // 
            // vbtnClientes
            // 
            this.vbtnClientes.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.vbtnClientes.Image = ((System.Drawing.Image)(resources.GetObject("vbtnClientes.Image")));
            this.vbtnClientes.LargeImage = ((System.Drawing.Image)(resources.GetObject("vbtnClientes.LargeImage")));
            this.vbtnClientes.Name = "vbtnClientes";
            this.vbtnClientes.SmallImage = ((System.Drawing.Image)(resources.GetObject("vbtnClientes.SmallImage")));
            this.vbtnClientes.Text = "Clientes";
            this.vbtnClientes.Click += new System.EventHandler(this.vbtnClientes_Click);
            // 
            // oldrpKepler
            // 
            this.oldrpKepler.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.oldrpKepler.Image = ((System.Drawing.Image)(resources.GetObject("oldrpKepler.Image")));
            this.oldrpKepler.LargeImage = ((System.Drawing.Image)(resources.GetObject("oldrpKepler.LargeImage")));
            this.oldrpKepler.Name = "oldrpKepler";
            this.oldrpKepler.SmallImage = ((System.Drawing.Image)(resources.GetObject("oldrpKepler.SmallImage")));
            this.oldrpKepler.Text = "Reporte Cotizaciones Kepler";
            this.oldrpKepler.Click += new System.EventHandler(this.oldrpKepler_Click);
            // 
            // btnCargaTo
            // 
            this.btnCargaTo.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.btnCargaTo.Image = ((System.Drawing.Image)(resources.GetObject("btnCargaTo.Image")));
            this.btnCargaTo.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCargaTo.LargeImage")));
            this.btnCargaTo.Name = "btnCargaTo";
            this.btnCargaTo.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCargaTo.SmallImage")));
            this.btnCargaTo.Text = "Asignar Cargas";
            this.btnCargaTo.Click += new System.EventHandler(this.btnCargaTo_Click);
            // 
            // consultaBill
            // 
            this.consultaBill.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.consultaBill.Image = ((System.Drawing.Image)(resources.GetObject("consultaBill.Image")));
            this.consultaBill.LargeImage = ((System.Drawing.Image)(resources.GetObject("consultaBill.LargeImage")));
            this.consultaBill.Name = "consultaBill";
            this.consultaBill.SmallImage = ((System.Drawing.Image)(resources.GetObject("consultaBill.SmallImage")));
            this.consultaBill.Text = "Consulta Bill";
            this.consultaBill.ToolTip = "Consulta bills de Arsys y Kepler";
            this.consultaBill.Click += new System.EventHandler(this.consultaBill_Click);
            // 
            // rbtnEntregasPruebas
            // 
            this.rbtnEntregasPruebas.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnEntregasPruebas.Image = ((System.Drawing.Image)(resources.GetObject("rbtnEntregasPruebas.Image")));
            this.rbtnEntregasPruebas.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbtnEntregasPruebas.LargeImage")));
            this.rbtnEntregasPruebas.Name = "rbtnEntregasPruebas";
            this.rbtnEntregasPruebas.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnEntregasPruebas.SmallImage")));
            this.rbtnEntregasPruebas.Text = "Pruebas de entrega";
            this.rbtnEntregasPruebas.Click += new System.EventHandler(this.rbtnEntregasPruebas_Click);
            // 
            // rbtnConsultaCargaCord
            // 
            this.rbtnConsultaCargaCord.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnConsultaCargaCord.Image = ((System.Drawing.Image)(resources.GetObject("rbtnConsultaCargaCord.Image")));
            this.rbtnConsultaCargaCord.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbtnConsultaCargaCord.LargeImage")));
            this.rbtnConsultaCargaCord.Name = "rbtnConsultaCargaCord";
            this.rbtnConsultaCargaCord.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnConsultaCargaCord.SmallImage")));
            this.rbtnConsultaCargaCord.Text = "Consulta Cargas";
            this.rbtnConsultaCargaCord.Click += new System.EventHandler(this.rbtnConsultaCargaCord_Click);
            // 
            // rbtnReportes
            // 
            this.rbtnReportes.DropDownItems.Add(this.rbReporteSalida);
            this.rbtnReportes.DropDownItems.Add(this.rbReporteClienteXcord);
            this.rbtnReportes.DropDownItems.Add(this.rbRepEntradasSD);
            this.rbtnReportes.DropDownItems.Add(this.rbRepClientesActivos);
            this.rbtnReportes.DropDownItems.Add(this.rbRepClienteXZona);
            this.rbtnReportes.DropDownItems.Add(this.rbRepCotXCantidad);
            this.rbtnReportes.DropDownItems.Add(this.rbRepEntradasTotalesPorUsuario);
            this.rbtnReportes.Image = global::mainVentana.Properties.Resources.delivery;
            this.rbtnReportes.LargeImage = global::mainVentana.Properties.Resources.delivery;
            this.rbtnReportes.Name = "rbtnReportes";
            this.rbtnReportes.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnReportes.SmallImage")));
            this.rbtnReportes.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.rbtnReportes.Text = "Reportes";
            this.rbtnReportes.Click += new System.EventHandler(this.rbtnReportes_Click);
            // 
            // rbReporteSalida
            // 
            this.rbReporteSalida.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbReporteSalida.Image = ((System.Drawing.Image)(resources.GetObject("rbReporteSalida.Image")));
            this.rbReporteSalida.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbReporteSalida.LargeImage")));
            this.rbReporteSalida.Name = "rbReporteSalida";
            this.rbReporteSalida.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbReporteSalida.SmallImage")));
            this.rbReporteSalida.Text = "Reporte Salidas";
            this.rbReporteSalida.Click += new System.EventHandler(this.rbReporteSalida_Click);
            // 
            // rbReporteClienteXcord
            // 
            this.rbReporteClienteXcord.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbReporteClienteXcord.Image = ((System.Drawing.Image)(resources.GetObject("rbReporteClienteXcord.Image")));
            this.rbReporteClienteXcord.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbReporteClienteXcord.LargeImage")));
            this.rbReporteClienteXcord.Name = "rbReporteClienteXcord";
            this.rbReporteClienteXcord.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbReporteClienteXcord.SmallImage")));
            this.rbReporteClienteXcord.Text = "Reporte de Clientes x Cord";
            this.rbReporteClienteXcord.Click += new System.EventHandler(this.rbReporteClienteXcord_Click);
            // 
            // rbRepEntradasSD
            // 
            this.rbRepEntradasSD.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbRepEntradasSD.Image = ((System.Drawing.Image)(resources.GetObject("rbRepEntradasSD.Image")));
            this.rbRepEntradasSD.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbRepEntradasSD.LargeImage")));
            this.rbRepEntradasSD.Name = "rbRepEntradasSD";
            this.rbRepEntradasSD.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbRepEntradasSD.SmallImage")));
            this.rbRepEntradasSD.Text = "Entradas Con tiempo";
            this.rbRepEntradasSD.Click += new System.EventHandler(this.rbRepEntradasSD_Click);
            // 
            // rbRepClientesActivos
            // 
            this.rbRepClientesActivos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbRepClientesActivos.Image = ((System.Drawing.Image)(resources.GetObject("rbRepClientesActivos.Image")));
            this.rbRepClientesActivos.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbRepClientesActivos.LargeImage")));
            this.rbRepClientesActivos.Name = "rbRepClientesActivos";
            this.rbRepClientesActivos.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbRepClientesActivos.SmallImage")));
            this.rbRepClientesActivos.Text = "Clientes Activos";
            this.rbRepClientesActivos.Click += new System.EventHandler(this.rbRepClientesActivos_Click);
            // 
            // rbRepClienteXZona
            // 
            this.rbRepClienteXZona.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbRepClienteXZona.Image = ((System.Drawing.Image)(resources.GetObject("rbRepClienteXZona.Image")));
            this.rbRepClienteXZona.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbRepClienteXZona.LargeImage")));
            this.rbRepClienteXZona.Name = "rbRepClienteXZona";
            this.rbRepClienteXZona.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbRepClienteXZona.SmallImage")));
            this.rbRepClienteXZona.Text = "ClientesXZona";
            this.rbRepClienteXZona.Click += new System.EventHandler(this.rbRepClienteXZona_Click);
            // 
            // rbRepCotXCantidad
            // 
            this.rbRepCotXCantidad.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbRepCotXCantidad.Image = ((System.Drawing.Image)(resources.GetObject("rbRepCotXCantidad.Image")));
            this.rbRepCotXCantidad.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbRepCotXCantidad.LargeImage")));
            this.rbRepCotXCantidad.Name = "rbRepCotXCantidad";
            this.rbRepCotXCantidad.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbRepCotXCantidad.SmallImage")));
            this.rbRepCotXCantidad.Text = "RepCotXCantidad";
            this.rbRepCotXCantidad.Click += new System.EventHandler(this.rbRepCotXCantidad_Click);
            // 
            // rbtnAjustes
            // 
            this.rbtnAjustes.DropDownItems.Add(this.apiConfig);
            this.rbtnAjustes.DropDownItems.Add(this.rbAgregarUsuario);
            this.rbtnAjustes.Enabled = false;
            this.rbtnAjustes.Image = global::mainVentana.Properties.Resources.settings;
            this.rbtnAjustes.LargeImage = global::mainVentana.Properties.Resources.settings;
            this.rbtnAjustes.Name = "rbtnAjustes";
            this.rbtnAjustes.SmallImage = global::mainVentana.Properties.Resources.settings;
            this.rbtnAjustes.Style = System.Windows.Forms.RibbonButtonStyle.SplitDropDown;
            this.rbtnAjustes.Text = "Ajustes";
            // 
            // apiConfig
            // 
            this.apiConfig.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.apiConfig.DropDownItems.Add(this.ribbonButton6);
            this.apiConfig.Image = ((System.Drawing.Image)(resources.GetObject("apiConfig.Image")));
            this.apiConfig.LargeImage = ((System.Drawing.Image)(resources.GetObject("apiConfig.LargeImage")));
            this.apiConfig.Name = "apiConfig";
            this.apiConfig.SmallImage = ((System.Drawing.Image)(resources.GetObject("apiConfig.SmallImage")));
            this.apiConfig.Text = "Api Config";
            this.apiConfig.Click += new System.EventHandler(this.apiConfig_Click);
            // 
            // ribbonButton6
            // 
            this.ribbonButton6.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.Image")));
            this.ribbonButton6.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.LargeImage")));
            this.ribbonButton6.Name = "ribbonButton6";
            this.ribbonButton6.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.SmallImage")));
            this.ribbonButton6.Text = "ribbonButton6";
            // 
            // rbAgregarUsuario
            // 
            this.rbAgregarUsuario.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbAgregarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("rbAgregarUsuario.Image")));
            this.rbAgregarUsuario.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbAgregarUsuario.LargeImage")));
            this.rbAgregarUsuario.Name = "rbAgregarUsuario";
            this.rbAgregarUsuario.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbAgregarUsuario.SmallImage")));
            this.rbAgregarUsuario.Text = "Crear Usuarios";
            this.rbAgregarUsuario.Click += new System.EventHandler(this.rbAgregarUsuario_Click);
            // 
            // rbtnMovimientos
            // 
            this.rbtnMovimientos.Enabled = false;
            this.rbtnMovimientos.Image = global::mainVentana.Properties.Resources.almatrans;
            this.rbtnMovimientos.LargeImage = global::mainVentana.Properties.Resources.almatrans;
            this.rbtnMovimientos.Name = "rbtnMovimientos";
            this.rbtnMovimientos.SmallImage = global::mainVentana.Properties.Resources.almatrans;
            this.rbtnMovimientos.Text = "Movimientos";
            this.rbtnMovimientos.Click += new System.EventHandler(this.rbtnMovimientos_Click);
            // 
            // rbtnInventario
            // 
            this.rbtnInventario.Image = global::mainVentana.Properties.Resources.product;
            this.rbtnInventario.LargeImage = global::mainVentana.Properties.Resources.product;
            this.rbtnInventario.Name = "rbtnInventario";
            this.rbtnInventario.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnInventario.SmallImage")));
            this.rbtnInventario.Text = "Inventario";
            this.rbtnInventario.Click += new System.EventHandler(this.rbtnInventario_Click);
            // 
            // rpnlAccesosWeb
            // 
            this.rpnlAccesosWeb.ButtonMoreEnabled = false;
            this.rpnlAccesosWeb.ButtonMoreVisible = false;
            this.rpnlAccesosWeb.Items.Add(this.ribbonItemGroup1);
            this.rpnlAccesosWeb.Name = "rpnlAccesosWeb";
            this.rpnlAccesosWeb.Text = "Accesos Web";
            // 
            // ribbonItemGroup1
            // 
            this.ribbonItemGroup1.Items.Add(this.lblWha);
            this.ribbonItemGroup1.Items.Add(this.lblWebex);
            this.ribbonItemGroup1.Items.Add(this.lblGmail);
            this.ribbonItemGroup1.Items.Add(this.lblAmazon);
            this.ribbonItemGroup1.Name = "ribbonItemGroup1";
            this.ribbonItemGroup1.Text = "W";
            this.ribbonItemGroup1.Value = "";
            // 
            // lblWha
            // 
            this.lblWha.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.lblWha.Name = "lblWha";
            this.lblWha.Text = "WhatsApp";
            this.lblWha.ToolTip = "Utiliza este Boton para abrir WhatsApp directamente.";
            this.lblWha.Click += new System.EventHandler(this.ribbonLabel1_Click);
            // 
            // lblWebex
            // 
            this.lblWebex.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.lblWebex.Name = "lblWebex";
            this.lblWebex.Text = "RingCentral";
            this.lblWebex.ToolTip = "Utiliza este Boton para abrir WEBEX directamente.";
            this.lblWebex.Click += new System.EventHandler(this.lblWebex_Click);
            // 
            // lblGmail
            // 
            this.lblGmail.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.lblGmail.Name = "lblGmail";
            this.lblGmail.Text = "Gmail";
            this.lblGmail.ToolTip = "Utiliza este Boton para abrir Gmail directamente.";
            this.lblGmail.Click += new System.EventHandler(this.lblGmail_Click);
            // 
            // lblAmazon
            // 
            this.lblAmazon.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.lblAmazon.Name = "lblAmazon";
            this.lblAmazon.Text = "BeeTrack";
            this.lblAmazon.ToolTip = "Utiliza este Boton para abrir Amazon directamente.";
            this.lblAmazon.Click += new System.EventHandler(this.lblAmazon_Click);
            // 
            // rpnlSuc
            // 
            this.rpnlSuc.ButtonMoreEnabled = false;
            this.rpnlSuc.ButtonMoreVisible = false;
            this.rpnlSuc.Items.Add(this.rcmbSucAct);
            this.rpnlSuc.Name = "rpnlSuc";
            this.rpnlSuc.Text = "Sucursal Actual";
            // 
            // rcmbSucAct
            // 
            this.rcmbSucAct.AllowTextEdit = false;
            this.rcmbSucAct.DropDownItems.Add(this.cbxiSD);
            this.rcmbSucAct.DropDownItems.Add(this.cbxiTJ);
            this.rcmbSucAct.DropDownItems.Add(this.cbxiCSL);
            this.rcmbSucAct.DropDownItems.Add(this.cbxiIMSD);
            this.rcmbSucAct.Name = "rcmbSucAct";
            this.rcmbSucAct.SelectedIndex = -1;
            this.rcmbSucAct.Text = "Sucursal";
            this.rcmbSucAct.TextBoxText = "";
            this.rcmbSucAct.ToolTip = "Autiliza esta lista para seleccionar una sucursal por defecto a la hora de abrir " +
    "la mayoria de ventanas.";
            this.rcmbSucAct.ToolTipTitle = "Ayuda (:";
            this.rcmbSucAct.Value = "";
            this.rcmbSucAct.DropDownItemClicked += new System.Windows.Forms.RibbonComboBox.RibbonItemEventHandler(this.rcmbSucAct_DropDownItemClicked);
            // 
            // cbxiSD
            // 
            this.cbxiSD.Image = ((System.Drawing.Image)(resources.GetObject("cbxiSD.Image")));
            this.cbxiSD.LargeImage = ((System.Drawing.Image)(resources.GetObject("cbxiSD.LargeImage")));
            this.cbxiSD.Name = "cbxiSD";
            this.cbxiSD.SmallImage = ((System.Drawing.Image)(resources.GetObject("cbxiSD.SmallImage")));
            this.cbxiSD.Text = "San Diego";
            this.cbxiSD.Value = "SD";
            // 
            // cbxiTJ
            // 
            this.cbxiTJ.Image = ((System.Drawing.Image)(resources.GetObject("cbxiTJ.Image")));
            this.cbxiTJ.LargeImage = ((System.Drawing.Image)(resources.GetObject("cbxiTJ.LargeImage")));
            this.cbxiTJ.Name = "cbxiTJ";
            this.cbxiTJ.SmallImage = ((System.Drawing.Image)(resources.GetObject("cbxiTJ.SmallImage")));
            this.cbxiTJ.Text = "Tijuana";
            this.cbxiTJ.Value = "TJ";
            // 
            // cbxiCSL
            // 
            this.cbxiCSL.Image = ((System.Drawing.Image)(resources.GetObject("cbxiCSL.Image")));
            this.cbxiCSL.LargeImage = ((System.Drawing.Image)(resources.GetObject("cbxiCSL.LargeImage")));
            this.cbxiCSL.Name = "cbxiCSL";
            this.cbxiCSL.SmallImage = ((System.Drawing.Image)(resources.GetObject("cbxiCSL.SmallImage")));
            this.cbxiCSL.Text = "Cabo San Lucas";
            this.cbxiCSL.Value = "CSL";
            // 
            // cbxiIMSD
            // 
            this.cbxiIMSD.Image = ((System.Drawing.Image)(resources.GetObject("cbxiIMSD.Image")));
            this.cbxiIMSD.LargeImage = ((System.Drawing.Image)(resources.GetObject("cbxiIMSD.LargeImage")));
            this.cbxiIMSD.Name = "cbxiIMSD";
            this.cbxiIMSD.SmallImage = ((System.Drawing.Image)(resources.GetObject("cbxiIMSD.SmallImage")));
            this.cbxiIMSD.Text = "IMP-EXP SD CA";
            this.cbxiIMSD.Value = "IMSD";
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Text = "Ayuda";
            // 
            // rtabMy
            // 
            this.rtabMy.Name = "rtabMy";
            this.rtabMy.Panels.Add(this.rpnlGeneralesUsuario);
            this.rtabMy.Text = "MiUsuario";
            // 
            // rpnlGeneralesUsuario
            // 
            this.rpnlGeneralesUsuario.ButtonMoreEnabled = false;
            this.rpnlGeneralesUsuario.ButtonMoreVisible = false;
            this.rpnlGeneralesUsuario.Items.Add(this.ribbonButton3);
            this.rpnlGeneralesUsuario.Name = "rpnlGeneralesUsuario";
            this.rpnlGeneralesUsuario.Text = "Generales";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.Image")));
            this.ribbonButton3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.LargeImage")));
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "Perfil";
            // 
            // rtabWMS
            // 
            this.rtabWMS.Name = "rtabWMS";
            this.rtabWMS.Panels.Add(this.ribbonPanel3);
            this.rtabWMS.Text = "WMS";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ButtonMoreEnabled = false;
            this.ribbonPanel3.ButtonMoreVisible = false;
            this.ribbonPanel3.Items.Add(this.ribbonButton4);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "";
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.Image")));
            this.ribbonButton4.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.LargeImage")));
            this.ribbonButton4.Name = "ribbonButton4";
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "Tijuana";
            this.ribbonButton4.Click += new System.EventHandler(this.ribbonButton4_Click);
            // 
            // ribbonDescriptionMenuItem2
            // 
            this.ribbonDescriptionMenuItem2.DescriptionBounds = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ribbonDescriptionMenuItem2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonDescriptionMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem2.Image")));
            this.ribbonDescriptionMenuItem2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem2.LargeImage")));
            this.ribbonDescriptionMenuItem2.Name = "ribbonDescriptionMenuItem2";
            this.ribbonDescriptionMenuItem2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem2.SmallImage")));
            this.ribbonDescriptionMenuItem2.Text = "ribbonDescriptionMenuItem2";
            // 
            // panelContenedorForm
            // 
            this.panelContenedorForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenedorForm.Location = new System.Drawing.Point(0, 122);
            this.panelContenedorForm.Margin = new System.Windows.Forms.Padding(2);
            this.panelContenedorForm.Name = "panelContenedorForm";
            this.panelContenedorForm.Size = new System.Drawing.Size(1245, 583);
            this.panelContenedorForm.TabIndex = 2;
            // 
            // rbRepEntradasTotalesPorUsuario
            // 
            this.rbRepEntradasTotalesPorUsuario.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbRepEntradasTotalesPorUsuario.Image = ((System.Drawing.Image)(resources.GetObject("rbRepEntradasTotalesPorUsuario.Image")));
            this.rbRepEntradasTotalesPorUsuario.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbRepEntradasTotalesPorUsuario.LargeImage")));
            this.rbRepEntradasTotalesPorUsuario.Name = "rbRepEntradasTotalesPorUsuario";
            this.rbRepEntradasTotalesPorUsuario.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbRepEntradasTotalesPorUsuario.SmallImage")));
            this.rbRepEntradasTotalesPorUsuario.Text = "Entradas x Usuario";
            this.rbRepEntradasTotalesPorUsuario.Click += new System.EventHandler(this.rbRepEntradasTotalesPorUsuario_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 781);
            this.Controls.Add(this.panelContenedorForm);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.panel11);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1129, 820);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ARSYS - Sistema Arnian";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel11.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel17.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer tmFechaHora;
        private System.Windows.Forms.Label lblNombreUsr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel17;
        private Label lblRol;
        private Ribbon ribbon1;
        private RibbonOrbMenuItem ribbonOrbMenuItem1;
        private RibbonOrbMenuItem ribbonOrbMenuItem2;
        private RibbonOrbMenuItem ribbonOrbMenuItem3;
        private RibbonSeparator ribbonSeparator1;
        private RibbonOrbRecentItem ribbonOrbRecentItem1;
        private RibbonTab ribbonTab1;
        private RibbonTab ribbonTab3;
        private RibbonPanel ribbonPanel1;
        private RibbonButton ribbonButton1;
        private RibbonSeparator ribbonSeparator2;
        private RibbonButton ribbonButton2;
        private RibbonPanel rpnlInicio;
        private RibbonButton rbtnEntrada;
        private RibbonButton rbtnCargas;
        private RibbonButton rbtnSalida;
        private RibbonButton rbtnRecepcion;
        private RibbonButton rbtnBill;
        private RibbonButton rbtnReportes;
        private RibbonButton rbtnAjustes;
        private RibbonDescriptionMenuItem ribbonDescriptionMenuItem1;
        private RibbonDescriptionMenuItem ribbonDescriptionMenuItem2;
        private RibbonPanel rpnlAccesosWeb;
        private RibbonItemGroup ribbonItemGroup1;
        private RibbonLabel lblWha;
        private RibbonLabel lblWebex;
        private RibbonLabel lblGmail;
        private RibbonLabel lblAmazon;
        private Panel panelContenedorForm;
        private RibbonPanel rpnlSuc;
        private RibbonComboBox rcmbSucAct;
        private RibbonButton cbxiSD;
        private RibbonButton cbxiTJ;
        private RibbonButton cbxiCSL;
        private RibbonTab rtabMy;
        private RibbonPanel rpnlGeneralesUsuario;
        private RibbonButton ribbonButton3;
        private RibbonButton apiConfig;
        private RibbonButton rbtnCord;
        private RibbonButton vbtnCotizacion;
        private RibbonButton rCordbtnBuscaCot;
        private RibbonTab rtabWMS;
        private RibbonPanel ribbonPanel3;
        private RibbonButton ribbonButton4;
        private RibbonButton vbtnClientes;
        private RibbonButton oldrpKepler;
        private RibbonButton rbtnEntradaAlta;
        private RibbonButton ribbonButton5;
        private RibbonButton btnCargaTo;
        private RibbonButton ribbonButton6;
        private RibbonButton rbAgregarUsuario;
        private RibbonButton consultaBill;
        private RibbonButton rbtnEntregasPruebas;
        private RibbonButton rbtnConsultaCargaCord;
        private RibbonButton rbReporteSalida;
        private RibbonButton rbReporteClienteXcord;
        private RibbonButton rbRepEntradasSD;
        private RibbonButton rbtnMovimientos;
        private RibbonButton cbxiIMSD;
        private RibbonButton rbRepClientesActivos;
        private RibbonButton rbRepClienteXZona;
        private RibbonButton rbtnInventario;
        private RibbonButton rbRepCotXCantidad;
        private RibbonButton rbRepEntradasTotalesPorUsuario;
    }
}

