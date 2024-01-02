namespace mainVentana.vistaInventario
{
    partial class frmInventarioMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSucOrigen = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeccion = new System.Windows.Forms.TextBox();
            this.cmbTipoInventario = new System.Windows.Forms.ComboBox();
            this.dgvFoliosAbiertos = new Guna.UI.WinForms.GunaDataGridView();
            this.lblSucursal = new ReaLTaiizor.Controls.BigLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblFolio = new ReaLTaiizor.Controls.BigLabel();
            this.btnScanini = new Guna.UI.WinForms.GunaGradientTileButton();
            this.txbEscaneo = new Guna.UI.WinForms.GunaTextBox();
            this.txbComentario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gunaGradientTileButton1 = new Guna.UI.WinForms.GunaGradientTileButton();
            this.dgvEscaneados = new Guna.UI.WinForms.GunaDataGridView();
            this.lblConteo = new ReaLTaiizor.Controls.BigLabel();
            this.gbxConteo = new System.Windows.Forms.GroupBox();
            this.pgbar = new ReaLTaiizor.Controls.PoisonProgressSpinner();
            this.groupBox1.SuspendLayout();
            this.gbGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoliosAbiertos)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEscaneados)).BeginInit();
            this.gbxConteo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gbGeneral);
            this.groupBox1.Controls.Add(this.dgvFoliosAbiertos);
            this.groupBox1.Controls.Add(this.lblSucursal);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(930, 244);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.label2);
            this.gbGeneral.Controls.Add(this.cmbSucOrigen);
            this.gbGeneral.Controls.Add(this.label4);
            this.gbGeneral.Controls.Add(this.label1);
            this.gbGeneral.Controls.Add(this.txtSeccion);
            this.gbGeneral.Controls.Add(this.cmbTipoInventario);
            this.gbGeneral.Location = new System.Drawing.Point(9, 19);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(329, 208);
            this.gbGeneral.TabIndex = 132;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "Generales";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 103;
            this.label2.Text = "Sucursal";
            // 
            // cmbSucOrigen
            // 
            this.cmbSucOrigen.AutoCompleteCustomSource.AddRange(new string[] {
            "SD",
            "TJ",
            "CSL"});
            this.cmbSucOrigen.DisplayMember = "SD";
            this.cmbSucOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSucOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSucOrigen.FormattingEnabled = true;
            this.cmbSucOrigen.Items.AddRange(new object[] {
            "SD",
            "TJ",
            "CSL"});
            this.cmbSucOrigen.Location = new System.Drawing.Point(9, 36);
            this.cmbSucOrigen.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSucOrigen.Name = "cmbSucOrigen";
            this.cmbSucOrigen.Size = new System.Drawing.Size(282, 28);
            this.cmbSucOrigen.TabIndex = 104;
            this.cmbSucOrigen.SelectedIndexChanged += new System.EventHandler(this.cmbSucOrigen_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 24);
            this.label4.TabIndex = 130;
            this.label4.Text = "Seccion ";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 106;
            this.label1.Text = "Tipo Inventario";
            // 
            // txtSeccion
            // 
            this.txtSeccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeccion.Location = new System.Drawing.Point(9, 171);
            this.txtSeccion.MaxLength = 20;
            this.txtSeccion.Name = "txtSeccion";
            this.txtSeccion.Size = new System.Drawing.Size(282, 26);
            this.txtSeccion.TabIndex = 129;
            // 
            // cmbTipoInventario
            // 
            this.cmbTipoInventario.AutoCompleteCustomSource.AddRange(new string[] {
            "SD",
            "TJ",
            "CSL"});
            this.cmbTipoInventario.DisplayMember = "SD";
            this.cmbTipoInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoInventario.FormattingEnabled = true;
            this.cmbTipoInventario.Items.AddRange(new object[] {
            "General"});
            this.cmbTipoInventario.Location = new System.Drawing.Point(9, 98);
            this.cmbTipoInventario.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipoInventario.Name = "cmbTipoInventario";
            this.cmbTipoInventario.Size = new System.Drawing.Size(282, 28);
            this.cmbTipoInventario.TabIndex = 107;
            // 
            // dgvFoliosAbiertos
            // 
            this.dgvFoliosAbiertos.AllowUserToAddRows = false;
            this.dgvFoliosAbiertos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvFoliosAbiertos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFoliosAbiertos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFoliosAbiertos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFoliosAbiertos.BackgroundColor = System.Drawing.Color.White;
            this.dgvFoliosAbiertos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFoliosAbiertos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvFoliosAbiertos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFoliosAbiertos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFoliosAbiertos.ColumnHeadersHeight = 20;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFoliosAbiertos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFoliosAbiertos.EnableHeadersVisualStyles = false;
            this.dgvFoliosAbiertos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvFoliosAbiertos.Location = new System.Drawing.Point(353, 108);
            this.dgvFoliosAbiertos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFoliosAbiertos.Name = "dgvFoliosAbiertos";
            this.dgvFoliosAbiertos.ReadOnly = true;
            this.dgvFoliosAbiertos.RowHeadersVisible = false;
            this.dgvFoliosAbiertos.RowHeadersWidth = 51;
            this.dgvFoliosAbiertos.RowTemplate.Height = 24;
            this.dgvFoliosAbiertos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFoliosAbiertos.Size = new System.Drawing.Size(568, 108);
            this.dgvFoliosAbiertos.TabIndex = 131;
            this.dgvFoliosAbiertos.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgvFoliosAbiertos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvFoliosAbiertos.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvFoliosAbiertos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvFoliosAbiertos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvFoliosAbiertos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvFoliosAbiertos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvFoliosAbiertos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvFoliosAbiertos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvFoliosAbiertos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvFoliosAbiertos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvFoliosAbiertos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvFoliosAbiertos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvFoliosAbiertos.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvFoliosAbiertos.ThemeStyle.ReadOnly = true;
            this.dgvFoliosAbiertos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvFoliosAbiertos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvFoliosAbiertos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvFoliosAbiertos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvFoliosAbiertos.ThemeStyle.RowsStyle.Height = 24;
            this.dgvFoliosAbiertos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvFoliosAbiertos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvFoliosAbiertos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFoliosAbiertos_CellContentDoubleClick);
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.BackColor = System.Drawing.Color.Transparent;
            this.lblSucursal.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblSucursal.ForeColor = System.Drawing.Color.Black;
            this.lblSucursal.Location = new System.Drawing.Point(346, 46);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(135, 41);
            this.lblSucursal.TabIndex = 105;
            this.lblSucursal.Text = "Sucursal";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblFolio);
            this.groupBox2.Location = new System.Drawing.Point(948, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Folio";
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.BackColor = System.Drawing.Color.Transparent;
            this.lblFolio.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.lblFolio.ForeColor = System.Drawing.Color.Red;
            this.lblFolio.Location = new System.Drawing.Point(47, 35);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(0, 46);
            this.lblFolio.TabIndex = 106;
            // 
            // btnScanini
            // 
            this.btnScanini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScanini.Animated = true;
            this.btnScanini.AnimationHoverSpeed = 0.07F;
            this.btnScanini.AnimationSpeed = 0.03F;
            this.btnScanini.BackColor = System.Drawing.Color.Transparent;
            this.btnScanini.BaseColor1 = System.Drawing.Color.SeaGreen;
            this.btnScanini.BaseColor2 = System.Drawing.SystemColors.InfoText;
            this.btnScanini.BorderColor = System.Drawing.Color.Black;
            this.btnScanini.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnScanini.FocusedColor = System.Drawing.Color.Empty;
            this.btnScanini.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanini.ForeColor = System.Drawing.Color.White;
            this.btnScanini.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnScanini.Image = null;
            this.btnScanini.ImageSize = new System.Drawing.Size(100, 80);
            this.btnScanini.Location = new System.Drawing.Point(948, 117);
            this.btnScanini.Margin = new System.Windows.Forms.Padding(2);
            this.btnScanini.Name = "btnScanini";
            this.btnScanini.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnScanini.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnScanini.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnScanini.OnHoverForeColor = System.Drawing.Color.White;
            this.btnScanini.OnHoverImage = null;
            this.btnScanini.OnPressedColor = System.Drawing.Color.Black;
            this.btnScanini.Radius = 5;
            this.btnScanini.Size = new System.Drawing.Size(220, 46);
            this.btnScanini.TabIndex = 31;
            this.btnScanini.Text = "Iniciar Inventario";
            this.btnScanini.Click += new System.EventHandler(this.btnScanini_Click);
            // 
            // txbEscaneo
            // 
            this.txbEscaneo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbEscaneo.BackColor = System.Drawing.Color.Transparent;
            this.txbEscaneo.BaseColor = System.Drawing.Color.White;
            this.txbEscaneo.BorderColor = System.Drawing.Color.Silver;
            this.txbEscaneo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbEscaneo.Enabled = false;
            this.txbEscaneo.FocusedBaseColor = System.Drawing.Color.White;
            this.txbEscaneo.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txbEscaneo.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txbEscaneo.Font = new System.Drawing.Font("Segoe UI", 30F);
            this.txbEscaneo.Location = new System.Drawing.Point(21, 262);
            this.txbEscaneo.Name = "txbEscaneo";
            this.txbEscaneo.PasswordChar = '\0';
            this.txbEscaneo.Radius = 10;
            this.txbEscaneo.Size = new System.Drawing.Size(912, 64);
            this.txbEscaneo.TabIndex = 30;
            this.txbEscaneo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbEscaneo_KeyDown);
            this.txbEscaneo.Leave += new System.EventHandler(this.txbEscaneo_Leave);
            // 
            // txbComentario
            // 
            this.txbComentario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbComentario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbComentario.Location = new System.Drawing.Point(21, 518);
            this.txbComentario.MaxLength = 250;
            this.txbComentario.Name = "txbComentario";
            this.txbComentario.Size = new System.Drawing.Size(912, 26);
            this.txbComentario.TabIndex = 127;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(18, 499);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 128;
            this.label3.Text = "Comentario:";
            // 
            // gunaGradientTileButton1
            // 
            this.gunaGradientTileButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGradientTileButton1.Animated = true;
            this.gunaGradientTileButton1.AnimationHoverSpeed = 0.07F;
            this.gunaGradientTileButton1.AnimationSpeed = 0.03F;
            this.gunaGradientTileButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradientTileButton1.BaseColor1 = System.Drawing.Color.SlateBlue;
            this.gunaGradientTileButton1.BaseColor2 = System.Drawing.Color.MediumVioletRed;
            this.gunaGradientTileButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientTileButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientTileButton1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGradientTileButton1.ForeColor = System.Drawing.Color.White;
            this.gunaGradientTileButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gunaGradientTileButton1.Image = null;
            this.gunaGradientTileButton1.ImageSize = new System.Drawing.Size(100, 80);
            this.gunaGradientTileButton1.Location = new System.Drawing.Point(948, 499);
            this.gunaGradientTileButton1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaGradientTileButton1.Name = "gunaGradientTileButton1";
            this.gunaGradientTileButton1.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.gunaGradientTileButton1.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.gunaGradientTileButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientTileButton1.OnHoverImage = null;
            this.gunaGradientTileButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton1.Radius = 5;
            this.gunaGradientTileButton1.Size = new System.Drawing.Size(220, 46);
            this.gunaGradientTileButton1.TabIndex = 129;
            this.gunaGradientTileButton1.Text = "Cerrar Inventario";
            this.gunaGradientTileButton1.Click += new System.EventHandler(this.gunaGradientTileButton1_Click);
            // 
            // dgvEscaneados
            // 
            this.dgvEscaneados.AllowUserToAddRows = false;
            this.dgvEscaneados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvEscaneados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEscaneados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEscaneados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEscaneados.BackgroundColor = System.Drawing.Color.White;
            this.dgvEscaneados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEscaneados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEscaneados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEscaneados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEscaneados.ColumnHeadersHeight = 20;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEscaneados.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvEscaneados.EnableHeadersVisualStyles = false;
            this.dgvEscaneados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEscaneados.Location = new System.Drawing.Point(21, 331);
            this.dgvEscaneados.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEscaneados.Name = "dgvEscaneados";
            this.dgvEscaneados.ReadOnly = true;
            this.dgvEscaneados.RowHeadersVisible = false;
            this.dgvEscaneados.RowHeadersWidth = 51;
            this.dgvEscaneados.RowTemplate.Height = 24;
            this.dgvEscaneados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEscaneados.Size = new System.Drawing.Size(912, 160);
            this.dgvEscaneados.TabIndex = 130;
            this.dgvEscaneados.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgvEscaneados.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEscaneados.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvEscaneados.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvEscaneados.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvEscaneados.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvEscaneados.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvEscaneados.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEscaneados.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvEscaneados.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvEscaneados.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvEscaneados.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvEscaneados.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvEscaneados.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvEscaneados.ThemeStyle.ReadOnly = true;
            this.dgvEscaneados.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEscaneados.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEscaneados.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvEscaneados.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvEscaneados.ThemeStyle.RowsStyle.Height = 24;
            this.dgvEscaneados.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEscaneados.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lblConteo
            // 
            this.lblConteo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConteo.AutoSize = true;
            this.lblConteo.BackColor = System.Drawing.Color.Transparent;
            this.lblConteo.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.lblConteo.ForeColor = System.Drawing.Color.Black;
            this.lblConteo.Location = new System.Drawing.Point(73, 62);
            this.lblConteo.Name = "lblConteo";
            this.lblConteo.Size = new System.Drawing.Size(38, 46);
            this.lblConteo.TabIndex = 133;
            this.lblConteo.Text = "0";
            // 
            // gbxConteo
            // 
            this.gbxConteo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxConteo.Controls.Add(this.lblConteo);
            this.gbxConteo.Location = new System.Drawing.Point(948, 331);
            this.gbxConteo.Name = "gbxConteo";
            this.gbxConteo.Size = new System.Drawing.Size(220, 160);
            this.gbxConteo.TabIndex = 134;
            this.gbxConteo.TabStop = false;
            this.gbxConteo.Text = "Conteo";
            // 
            // pgbar
            // 
            this.pgbar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgbar.BackColor = System.Drawing.SystemColors.Control;
            this.pgbar.Location = new System.Drawing.Point(995, 186);
            this.pgbar.Maximum = 100;
            this.pgbar.Name = "pgbar";
            this.pgbar.Size = new System.Drawing.Size(140, 140);
            this.pgbar.TabIndex = 133;
            this.pgbar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            this.pgbar.UseCustomBackColor = true;
            this.pgbar.UseCustomForeColor = true;
            this.pgbar.UseSelectable = true;
            this.pgbar.UseStyleColors = true;
            this.pgbar.Value = 100;
            this.pgbar.Visible = false;
            // 
            // frmInventarioMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 556);
            this.Controls.Add(this.pgbar);
            this.Controls.Add(this.gbxConteo);
            this.Controls.Add(this.dgvEscaneados);
            this.Controls.Add(this.gunaGradientTileButton1);
            this.Controls.Add(this.txbComentario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnScanini);
            this.Controls.Add(this.txbEscaneo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmInventarioMain";
            this.ShowIcon = false;
            this.Text = "Inventario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInventarioMain_FormClosing);
            this.Load += new System.EventHandler(this.frmInventarioMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoliosAbiertos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEscaneados)).EndInit();
            this.gbxConteo.ResumeLayout(false);
            this.gbxConteo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ReaLTaiizor.Controls.BigLabel lblSucursal;
        private System.Windows.Forms.ComboBox cmbSucOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private ReaLTaiizor.Controls.BigLabel lblFolio;
        private Guna.UI.WinForms.GunaGradientTileButton btnScanini;
        private Guna.UI.WinForms.GunaTextBox txbEscaneo;
        public System.Windows.Forms.TextBox txbComentario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtSeccion;
        private System.Windows.Forms.ComboBox cmbTipoInventario;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaGradientTileButton gunaGradientTileButton1;
        private Guna.UI.WinForms.GunaDataGridView dgvEscaneados;
        private Guna.UI.WinForms.GunaDataGridView dgvFoliosAbiertos;
        private System.Windows.Forms.GroupBox gbGeneral;
        private ReaLTaiizor.Controls.BigLabel lblConteo;
        private System.Windows.Forms.GroupBox gbxConteo;
        private ReaLTaiizor.Controls.PoisonProgressSpinner pgbar;
    }
}