using System.Drawing;
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
            this.ribbonSeparator4 = new System.Windows.Forms.RibbonSeparator();
            this.rbtnCargas = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator5 = new System.Windows.Forms.RibbonSeparator();
            this.rbtnSalida = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator6 = new System.Windows.Forms.RibbonSeparator();
            this.rbtnRecepcion = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator7 = new System.Windows.Forms.RibbonSeparator();
            this.rbtnBill = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator8 = new System.Windows.Forms.RibbonSeparator();
            this.rbtnReportes = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator9 = new System.Windows.Forms.RibbonSeparator();
            this.rbtnAjustes = new System.Windows.Forms.RibbonButton();
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
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.rlblSucGlobal = new System.Windows.Forms.RibbonLabel();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.rtabMy = new System.Windows.Forms.RibbonTab();
            this.rpnlGeneralesUsuario = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbonDescriptionMenuItem2 = new System.Windows.Forms.RibbonDescriptionMenuItem();
            this.panelContenedorForm = new System.Windows.Forms.Panel();
            this.apiConfig = new System.Windows.Forms.RibbonButton();
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
            this.panel11.Size = new System.Drawing.Size(1113, 74);
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
            this.panel13.Size = new System.Drawing.Size(1113, 72);
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
            this.panel14.Location = new System.Drawing.Point(873, 0);
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
            this.panel17.Size = new System.Drawing.Size(1113, 109);
            this.panel17.TabIndex = 3;
            // 
            // ribbon1
            // 
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
            this.ribbon1.Size = new System.Drawing.Size(1113, 107);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab3);
            this.ribbon1.Tabs.Add(this.rtabMy);
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
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
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
            this.ribbonButton1.Text = "Copiar";
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
            this.ribbonButton2.Text = "Pegar";
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
            this.rpnlInicio.Items.Add(this.ribbonSeparator4);
            this.rpnlInicio.Items.Add(this.rbtnCargas);
            this.rpnlInicio.Items.Add(this.ribbonSeparator5);
            this.rpnlInicio.Items.Add(this.rbtnSalida);
            this.rpnlInicio.Items.Add(this.ribbonSeparator6);
            this.rpnlInicio.Items.Add(this.rbtnRecepcion);
            this.rpnlInicio.Items.Add(this.ribbonSeparator7);
            this.rpnlInicio.Items.Add(this.rbtnBill);
            this.rpnlInicio.Items.Add(this.ribbonSeparator8);
            this.rpnlInicio.Items.Add(this.rbtnReportes);
            this.rpnlInicio.Items.Add(this.ribbonSeparator9);
            this.rpnlInicio.Items.Add(this.rbtnAjustes);
            this.rpnlInicio.Name = "rpnlInicio";
            this.rpnlInicio.Text = "Pantallas";
            // 
            // rbtnEntrada
            // 
            this.rbtnEntrada.Enabled = false;
            this.rbtnEntrada.Image = global::mainVentana.Properties.Resources.log_in;
            this.rbtnEntrada.LargeImage = global::mainVentana.Properties.Resources.log_in;
            this.rbtnEntrada.Name = "rbtnEntrada";
            this.rbtnEntrada.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnEntrada.SmallImage")));
            this.rbtnEntrada.Text = "Entrada";
            this.rbtnEntrada.Click += new System.EventHandler(this.rbtnEntrada_Click);
            // 
            // ribbonSeparator4
            // 
            this.ribbonSeparator4.Name = "ribbonSeparator4";
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
            // ribbonSeparator5
            // 
            this.ribbonSeparator5.Name = "ribbonSeparator5";
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
            // ribbonSeparator6
            // 
            this.ribbonSeparator6.Name = "ribbonSeparator6";
            // 
            // rbtnRecepcion
            // 
            this.rbtnRecepcion.Enabled = false;
            this.rbtnRecepcion.Image = global::mainVentana.Properties.Resources.warehouse;
            this.rbtnRecepcion.LargeImage = global::mainVentana.Properties.Resources.warehouse;
            this.rbtnRecepcion.Name = "rbtnRecepcion";
            this.rbtnRecepcion.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnRecepcion.SmallImage")));
            this.rbtnRecepcion.Text = "Recepcion";
            this.rbtnRecepcion.Click += new System.EventHandler(this.rbtnRecepcion_Click);
            // 
            // ribbonSeparator7
            // 
            this.ribbonSeparator7.Name = "ribbonSeparator7";
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
            // ribbonSeparator8
            // 
            this.ribbonSeparator8.Name = "ribbonSeparator8";
            // 
            // rbtnReportes
            // 
            this.rbtnReportes.Image = global::mainVentana.Properties.Resources.delivery;
            this.rbtnReportes.LargeImage = global::mainVentana.Properties.Resources.delivery;
            this.rbtnReportes.Name = "rbtnReportes";
            this.rbtnReportes.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnReportes.SmallImage")));
            this.rbtnReportes.Text = "Reportes";
            this.rbtnReportes.Click += new System.EventHandler(this.rbtnReportes_Click);
            // 
            // ribbonSeparator9
            // 
            this.ribbonSeparator9.Name = "ribbonSeparator9";
            // 
            // rbtnAjustes
            // 
            this.rbtnAjustes.DropDownItems.Add(this.apiConfig);
            this.rbtnAjustes.Image = global::mainVentana.Properties.Resources.settings;
            this.rbtnAjustes.LargeImage = global::mainVentana.Properties.Resources.settings;
            this.rbtnAjustes.Name = "rbtnAjustes";
            this.rbtnAjustes.SmallImage = global::mainVentana.Properties.Resources.settings;
            this.rbtnAjustes.Style = System.Windows.Forms.RibbonButtonStyle.SplitDropDown;
            this.rbtnAjustes.Text = "Ajustes";
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
            this.lblWebex.Text = "Webex";
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
            this.lblAmazon.Text = "Amazon";
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
            this.cbxiSD.Text = " San Diego";
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
            // ribbonPanel2
            // 
            this.ribbonPanel2.ButtonMoreEnabled = false;
            this.ribbonPanel2.ButtonMoreVisible = false;
            this.ribbonPanel2.Items.Add(this.rlblSucGlobal);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "";
            // 
            // rlblSucGlobal
            // 
            this.rlblSucGlobal.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rlblSucGlobal.Name = "rlblSucGlobal";
            this.rlblSucGlobal.Text = "Sucursal";
            this.rlblSucGlobal.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.rlblSucGlobal.ToolTip = "Esta es la Sucursal Global Seleccionada";
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
            this.ribbonButton3.Text = "ribbonButton3";
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
            this.panelContenedorForm.Location = new System.Drawing.Point(0, 104);
            this.panelContenedorForm.Margin = new System.Windows.Forms.Padding(2);
            this.panelContenedorForm.Name = "panelContenedorForm";
            this.panelContenedorForm.Size = new System.Drawing.Size(1113, 601);
            this.panelContenedorForm.TabIndex = 2;
            // 
            // apiConfig
            // 
            this.apiConfig.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.apiConfig.Image = ((System.Drawing.Image)(resources.GetObject("apiConfig.Image")));
            this.apiConfig.LargeImage = ((System.Drawing.Image)(resources.GetObject("apiConfig.LargeImage")));
            this.apiConfig.Name = "apiConfig";
            this.apiConfig.SmallImage = ((System.Drawing.Image)(resources.GetObject("apiConfig.SmallImage")));
            this.apiConfig.Text = "Api Config";
            this.apiConfig.Click += new System.EventHandler(this.apiConfig_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 781);
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
        private RibbonSeparator ribbonSeparator4;
        private RibbonButton rbtnCargas;
        private RibbonSeparator ribbonSeparator5;
        private RibbonButton rbtnSalida;
        private RibbonSeparator ribbonSeparator6;
        private RibbonButton rbtnRecepcion;
        private RibbonSeparator ribbonSeparator7;
        private RibbonButton rbtnBill;
        private RibbonSeparator ribbonSeparator8;
        private RibbonButton rbtnReportes;
        private RibbonSeparator ribbonSeparator9;
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
        private RibbonPanel ribbonPanel2;
        private RibbonLabel rlblSucGlobal;
        private RibbonButton apiConfig;
    }
}

