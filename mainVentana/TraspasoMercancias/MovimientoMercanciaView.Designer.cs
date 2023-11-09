namespace mainVentana.TraspasoMercancias
{
    partial class MovimientoMercanciaView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gunaGroupBox2 = new Guna.UI.WinForms.GunaGroupBox();
            this.cmbSucDestino = new Guna.UI.WinForms.GunaComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSucOrigen = new Guna.UI.WinForms.GunaComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaGroupBox3 = new Guna.UI.WinForms.GunaGroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnScanini = new Guna.UI.WinForms.GunaGradientTileButton();
            this.txbEscaneo = new Guna.UI.WinForms.GunaTextBox();
            this.dgvEscaneados = new Guna.UI.WinForms.GunaDataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gunaDataGridView1 = new Guna.UI.WinForms.GunaDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIniciaSalida = new Guna.UI.WinForms.GunaGradientTileButton();
            this.gunaGroupBox2.SuspendLayout();
            this.gunaGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEscaneados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaGroupBox2
            // 
            this.gunaGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox2.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox2.Controls.Add(this.cmbSucDestino);
            this.gunaGroupBox2.Controls.Add(this.label2);
            this.gunaGroupBox2.Controls.Add(this.cmbSucOrigen);
            this.gunaGroupBox2.Controls.Add(this.label1);
            this.gunaGroupBox2.LineColor = System.Drawing.Color.DarkSalmon;
            this.gunaGroupBox2.Location = new System.Drawing.Point(266, 12);
            this.gunaGroupBox2.Name = "gunaGroupBox2";
            this.gunaGroupBox2.Radius = 5;
            this.gunaGroupBox2.Size = new System.Drawing.Size(296, 187);
            this.gunaGroupBox2.TabIndex = 8;
            this.gunaGroupBox2.Text = "Generales.";
            this.gunaGroupBox2.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // cmbSucDestino
            // 
            this.cmbSucDestino.BackColor = System.Drawing.Color.Transparent;
            this.cmbSucDestino.BaseColor = System.Drawing.Color.White;
            this.cmbSucDestino.BorderColor = System.Drawing.Color.Silver;
            this.cmbSucDestino.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSucDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSucDestino.FocusedColor = System.Drawing.Color.Empty;
            this.cmbSucDestino.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSucDestino.ForeColor = System.Drawing.Color.Black;
            this.cmbSucDestino.FormattingEnabled = true;
            this.cmbSucDestino.Location = new System.Drawing.Point(12, 121);
            this.cmbSucDestino.Name = "cmbSucDestino";
            this.cmbSucDestino.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmbSucDestino.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmbSucDestino.Size = new System.Drawing.Size(247, 26);
            this.cmbSucDestino.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Almacen que recibe";
            this.label2.UseMnemonic = false;
            // 
            // cmbSucOrigen
            // 
            this.cmbSucOrigen.BackColor = System.Drawing.Color.Transparent;
            this.cmbSucOrigen.BaseColor = System.Drawing.Color.White;
            this.cmbSucOrigen.BorderColor = System.Drawing.Color.Silver;
            this.cmbSucOrigen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSucOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSucOrigen.FocusedColor = System.Drawing.Color.Empty;
            this.cmbSucOrigen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSucOrigen.ForeColor = System.Drawing.Color.Black;
            this.cmbSucOrigen.FormattingEnabled = true;
            this.cmbSucOrigen.Location = new System.Drawing.Point(12, 60);
            this.cmbSucOrigen.Name = "cmbSucOrigen";
            this.cmbSucOrigen.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmbSucOrigen.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmbSucOrigen.Size = new System.Drawing.Size(247, 26);
            this.cmbSucOrigen.TabIndex = 11;
            this.cmbSucOrigen.SelectedIndexChanged += new System.EventHandler(this.cmbSucOrigen_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Almacen que envia";
            this.label1.UseMnemonic = false;
            // 
            // gunaGroupBox3
            // 
            this.gunaGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox3.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox3.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox3.Controls.Add(this.radioButton2);
            this.gunaGroupBox3.Controls.Add(this.radioButton1);
            this.gunaGroupBox3.LineColor = System.Drawing.Color.DarkSalmon;
            this.gunaGroupBox3.Location = new System.Drawing.Point(12, 12);
            this.gunaGroupBox3.Name = "gunaGroupBox3";
            this.gunaGroupBox3.Radius = 5;
            this.gunaGroupBox3.Size = new System.Drawing.Size(232, 187);
            this.gunaGroupBox3.TabIndex = 10;
            this.gunaGroupBox3.Text = "Por defecto";
            this.gunaGroupBox3.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 87);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(147, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "1";
            this.radioButton2.Text = "Sub-Almacén => Almacén";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 45);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(150, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "0";
            this.radioButton1.Text = "Almacén  => Sub-Almacén";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // btnScanini
            // 
            this.btnScanini.Animated = true;
            this.btnScanini.AnimationHoverSpeed = 0.07F;
            this.btnScanini.AnimationSpeed = 0.03F;
            this.btnScanini.BackColor = System.Drawing.Color.Transparent;
            this.btnScanini.BaseColor1 = System.Drawing.Color.Salmon;
            this.btnScanini.BaseColor2 = System.Drawing.Color.LightCoral;
            this.btnScanini.BorderColor = System.Drawing.Color.Black;
            this.btnScanini.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnScanini.FocusedColor = System.Drawing.Color.Empty;
            this.btnScanini.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanini.ForeColor = System.Drawing.Color.White;
            this.btnScanini.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnScanini.Image = null;
            this.btnScanini.ImageSize = new System.Drawing.Size(100, 80);
            this.btnScanini.Location = new System.Drawing.Point(14, 218);
            this.btnScanini.Margin = new System.Windows.Forms.Padding(2);
            this.btnScanini.Name = "btnScanini";
            this.btnScanini.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnScanini.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnScanini.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnScanini.OnHoverForeColor = System.Drawing.Color.White;
            this.btnScanini.OnHoverImage = null;
            this.btnScanini.OnPressedColor = System.Drawing.Color.Black;
            this.btnScanini.Radius = 5;
            this.btnScanini.Size = new System.Drawing.Size(230, 52);
            this.btnScanini.TabIndex = 31;
            this.btnScanini.Text = "Iniciar Escaneo";
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
            this.txbEscaneo.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.txbEscaneo.Location = new System.Drawing.Point(266, 218);
            this.txbEscaneo.Name = "txbEscaneo";
            this.txbEscaneo.PasswordChar = '\0';
            this.txbEscaneo.Radius = 10;
            this.txbEscaneo.Size = new System.Drawing.Size(935, 52);
            this.txbEscaneo.TabIndex = 30;
            // 
            // dgvEscaneados
            // 
            this.dgvEscaneados.AllowUserToAddRows = false;
            this.dgvEscaneados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.White;
            this.dgvEscaneados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvEscaneados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEscaneados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEscaneados.BackgroundColor = System.Drawing.Color.White;
            this.dgvEscaneados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEscaneados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEscaneados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEscaneados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgvEscaneados.ColumnHeadersHeight = 20;
            this.dgvEscaneados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column5,
            this.Column7});
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEscaneados.DefaultCellStyle = dataGridViewCellStyle27;
            this.dgvEscaneados.EnableHeadersVisualStyles = false;
            this.dgvEscaneados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEscaneados.Location = new System.Drawing.Point(266, 287);
            this.dgvEscaneados.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEscaneados.Name = "dgvEscaneados";
            this.dgvEscaneados.ReadOnly = true;
            this.dgvEscaneados.RowHeadersVisible = false;
            this.dgvEscaneados.RowHeadersWidth = 51;
            this.dgvEscaneados.RowTemplate.Height = 24;
            this.dgvEscaneados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEscaneados.Size = new System.Drawing.Size(935, 363);
            this.dgvEscaneados.TabIndex = 32;
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
            // Column2
            // 
            this.Column2.HeaderText = "Etiquetas";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Carga";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Correo";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // gunaDataGridView1
            // 
            this.gunaDataGridView1.AllowUserToAddRows = false;
            this.gunaDataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.White;
            this.gunaDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle28;
            this.gunaDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gunaDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.gunaDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gunaDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.gunaDataGridView1.ColumnHeadersHeight = 20;
            this.gunaDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaDataGridView1.DefaultCellStyle = dataGridViewCellStyle30;
            this.gunaDataGridView1.EnableHeadersVisualStyles = false;
            this.gunaDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gunaDataGridView1.Location = new System.Drawing.Point(14, 287);
            this.gunaDataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaDataGridView1.Name = "gunaDataGridView1";
            this.gunaDataGridView1.ReadOnly = true;
            this.gunaDataGridView1.RowHeadersVisible = false;
            this.gunaDataGridView1.RowHeadersWidth = 51;
            this.gunaDataGridView1.RowTemplate.Height = 24;
            this.gunaDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gunaDataGridView1.Size = new System.Drawing.Size(229, 363);
            this.gunaDataGridView1.TabIndex = 123;
            this.gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gunaDataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gunaDataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.Height = 20;
            this.gunaDataGridView1.ThemeStyle.ReadOnly = true;
            this.gunaDataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gunaDataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaDataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.gunaDataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gunaDataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.gunaDataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gunaDataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Etiquetas";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Carga";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Correo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // btnIniciaSalida
            // 
            this.btnIniciaSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIniciaSalida.Animated = true;
            this.btnIniciaSalida.AnimationHoverSpeed = 0.07F;
            this.btnIniciaSalida.AnimationSpeed = 0.03F;
            this.btnIniciaSalida.BackColor = System.Drawing.Color.Transparent;
            this.btnIniciaSalida.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnIniciaSalida.BaseColor2 = System.Drawing.Color.Indigo;
            this.btnIniciaSalida.BorderColor = System.Drawing.Color.Black;
            this.btnIniciaSalida.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnIniciaSalida.FocusedColor = System.Drawing.Color.Empty;
            this.btnIniciaSalida.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciaSalida.ForeColor = System.Drawing.Color.White;
            this.btnIniciaSalida.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnIniciaSalida.Image = null;
            this.btnIniciaSalida.ImageSize = new System.Drawing.Size(100, 80);
            this.btnIniciaSalida.Location = new System.Drawing.Point(948, 12);
            this.btnIniciaSalida.Margin = new System.Windows.Forms.Padding(2);
            this.btnIniciaSalida.Name = "btnIniciaSalida";
            this.btnIniciaSalida.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnIniciaSalida.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnIniciaSalida.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnIniciaSalida.OnHoverForeColor = System.Drawing.Color.White;
            this.btnIniciaSalida.OnHoverImage = null;
            this.btnIniciaSalida.OnPressedColor = System.Drawing.Color.Black;
            this.btnIniciaSalida.Radius = 5;
            this.btnIniciaSalida.Size = new System.Drawing.Size(253, 187);
            this.btnIniciaSalida.TabIndex = 34;
            this.btnIniciaSalida.Text = "Buscar";
            this.btnIniciaSalida.Click += new System.EventHandler(this.btnIniciaSalida_Click_1);
            // 
            // MovimientoMercanciaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 758);
            this.Controls.Add(this.gunaDataGridView1);
            this.Controls.Add(this.btnIniciaSalida);
            this.Controls.Add(this.dgvEscaneados);
            this.Controls.Add(this.btnScanini);
            this.Controls.Add(this.txbEscaneo);
            this.Controls.Add(this.gunaGroupBox3);
            this.Controls.Add(this.gunaGroupBox2);
            this.Name = "MovimientoMercanciaView";
            this.ShowIcon = false;
            this.Text = "Movimiento Mercancia (SubAlmacen)";
            this.Load += new System.EventHandler(this.MovimientoMercanciaView_Load);
            this.gunaGroupBox2.ResumeLayout(false);
            this.gunaGroupBox2.PerformLayout();
            this.gunaGroupBox3.ResumeLayout(false);
            this.gunaGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEscaneados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox2;
        private Guna.UI.WinForms.GunaComboBox cmbSucOrigen;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaComboBox cmbSucDestino;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private Guna.UI.WinForms.GunaGradientTileButton btnScanini;
        private Guna.UI.WinForms.GunaTextBox txbEscaneo;
        private Guna.UI.WinForms.GunaDataGridView dgvEscaneados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private Guna.UI.WinForms.GunaDataGridView gunaDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Guna.UI.WinForms.GunaGradientTileButton btnIniciaSalida;
    }
}