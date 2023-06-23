namespace mainVentana.VistaInicioCoordinadores
{
    partial class frmAddToCarga
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txbReferencia = new System.Windows.Forms.TextBox();
            this.btnGuardar = new Guna.UI.WinForms.GunaGradientTileButton();
            this.tmCierre = new System.Windows.Forms.DateTimePicker();
            this.lblFechaC = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbCarga = new System.Windows.Forms.TextBox();
            this.panelSpliter = new System.Windows.Forms.Panel();
            this.txbTotal = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dtgSinAsignar = new Guna.UI.WinForms.GunaDataGridView();
            this.dgvCargadas = new Guna.UI.WinForms.GunaDataGridView();
            this.dtgAsignados = new Guna.UI.WinForms.GunaDataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.tipoOper = new System.Windows.Forms.ComboBox();
            this.cbxOrdenes = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAlta = new Guna.UI.WinForms.GunaGradientTileButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtFecha2 = new Guna.UI.WinForms.GunaDateTimePicker();
            this.dtFecha1 = new Guna.UI.WinForms.GunaDateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rCa = new System.Windows.Forms.RadioButton();
            this.rTj = new System.Windows.Forms.RadioButton();
            this.rSd = new System.Windows.Forms.RadioButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.swBill = new ReaLTaiizor.Controls.MaterialSwitch();
            this.lblnBill = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelSpliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSinAsignar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAsignados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txbReferencia);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.tmCierre);
            this.panel1.Controls.Add(this.lblFechaC);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txbCarga);
            this.panel1.Controls.Add(this.panelSpliter);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.tipoOper);
            this.panel1.Controls.Add(this.cbxOrdenes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAlta);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dtFecha2);
            this.panel1.Controls.Add(this.dtFecha1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(28, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 599);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Location = new System.Drawing.Point(274, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 193;
            this.label3.Text = "Referencia";
            // 
            // txbReferencia
            // 
            this.txbReferencia.Location = new System.Drawing.Point(276, 175);
            this.txbReferencia.MaxLength = 55;
            this.txbReferencia.Name = "txbReferencia";
            this.txbReferencia.ReadOnly = true;
            this.txbReferencia.Size = new System.Drawing.Size(226, 20);
            this.txbReferencia.TabIndex = 192;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Animated = true;
            this.btnGuardar.AnimationHoverSpeed = 0.07F;
            this.btnGuardar.AnimationSpeed = 0.03F;
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.BaseColor1 = System.Drawing.Color.Violet;
            this.btnGuardar.BaseColor2 = System.Drawing.Color.MediumSlateBlue;
            this.btnGuardar.BorderColor = System.Drawing.Color.Black;
            this.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGuardar.FocusedColor = System.Drawing.Color.Empty;
            this.btnGuardar.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnGuardar.Image = null;
            this.btnGuardar.ImageSize = new System.Drawing.Size(100, 80);
            this.btnGuardar.Location = new System.Drawing.Point(1018, 534);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnGuardar.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnGuardar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnGuardar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnGuardar.OnHoverImage = null;
            this.btnGuardar.OnPressedColor = System.Drawing.Color.Black;
            this.btnGuardar.Radius = 5;
            this.btnGuardar.Size = new System.Drawing.Size(229, 63);
            this.btnGuardar.TabIndex = 191;
            this.btnGuardar.Text = "Asignar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tmCierre
            // 
            this.tmCierre.Enabled = false;
            this.tmCierre.Location = new System.Drawing.Point(530, 175);
            this.tmCierre.Name = "tmCierre";
            this.tmCierre.Size = new System.Drawing.Size(230, 20);
            this.tmCierre.TabIndex = 190;
            // 
            // lblFechaC
            // 
            this.lblFechaC.AutoSize = true;
            this.lblFechaC.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblFechaC.Location = new System.Drawing.Point(527, 159);
            this.lblFechaC.Name = "lblFechaC";
            this.lblFechaC.Size = new System.Drawing.Size(37, 13);
            this.lblFechaC.TabIndex = 189;
            this.lblFechaC.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(14, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 187;
            this.label2.Text = "Orden";
            // 
            // txbCarga
            // 
            this.txbCarga.Location = new System.Drawing.Point(16, 175);
            this.txbCarga.MaxLength = 55;
            this.txbCarga.Name = "txbCarga";
            this.txbCarga.ReadOnly = true;
            this.txbCarga.Size = new System.Drawing.Size(225, 20);
            this.txbCarga.TabIndex = 186;
            // 
            // panelSpliter
            // 
            this.panelSpliter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSpliter.Controls.Add(this.txbTotal);
            this.panelSpliter.Controls.Add(this.splitContainer1);
            this.panelSpliter.Location = new System.Drawing.Point(16, 201);
            this.panelSpliter.Name = "panelSpliter";
            this.panelSpliter.Size = new System.Drawing.Size(1242, 328);
            this.panelSpliter.TabIndex = 185;
            // 
            // txbTotal
            // 
            this.txbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTotal.AutoSize = true;
            this.txbTotal.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.txbTotal.Location = new System.Drawing.Point(755, 304);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.Size = new System.Drawing.Size(34, 13);
            this.txbTotal.TabIndex = 191;
            this.txbTotal.Text = "Total:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dtgSinAsignar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCargadas);
            this.splitContainer1.Panel2.Controls.Add(this.dtgAsignados);
            this.splitContainer1.Size = new System.Drawing.Size(1242, 301);
            this.splitContainer1.SplitterDistance = 743;
            this.splitContainer1.TabIndex = 0;
            // 
            // dtgSinAsignar
            // 
            this.dtgSinAsignar.AllowUserToAddRows = false;
            this.dtgSinAsignar.AllowUserToDeleteRows = false;
            this.dtgSinAsignar.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtgSinAsignar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgSinAsignar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgSinAsignar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgSinAsignar.BackgroundColor = System.Drawing.Color.White;
            this.dtgSinAsignar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgSinAsignar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dtgSinAsignar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSinAsignar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgSinAsignar.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSinAsignar.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgSinAsignar.EnableHeadersVisualStyles = false;
            this.dtgSinAsignar.GridColor = System.Drawing.Color.Azure;
            this.dtgSinAsignar.Location = new System.Drawing.Point(6, 13);
            this.dtgSinAsignar.Margin = new System.Windows.Forms.Padding(2);
            this.dtgSinAsignar.Name = "dtgSinAsignar";
            this.dtgSinAsignar.ReadOnly = true;
            this.dtgSinAsignar.RowHeadersVisible = false;
            this.dtgSinAsignar.RowHeadersWidth = 100;
            this.dtgSinAsignar.RowTemplate.DividerHeight = 1;
            this.dtgSinAsignar.RowTemplate.Height = 50;
            this.dtgSinAsignar.RowTemplate.ReadOnly = true;
            this.dtgSinAsignar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgSinAsignar.Size = new System.Drawing.Size(721, 282);
            this.dtgSinAsignar.TabIndex = 178;
            this.dtgSinAsignar.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dtgSinAsignar.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgSinAsignar.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgSinAsignar.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgSinAsignar.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgSinAsignar.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgSinAsignar.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgSinAsignar.ThemeStyle.GridColor = System.Drawing.Color.Azure;
            this.dtgSinAsignar.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgSinAsignar.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgSinAsignar.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtgSinAsignar.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgSinAsignar.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgSinAsignar.ThemeStyle.HeaderStyle.Height = 40;
            this.dtgSinAsignar.ThemeStyle.ReadOnly = true;
            this.dtgSinAsignar.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgSinAsignar.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dtgSinAsignar.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtgSinAsignar.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgSinAsignar.ThemeStyle.RowsStyle.Height = 50;
            this.dtgSinAsignar.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgSinAsignar.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgSinAsignar.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSinAsignar_CellContentDoubleClick);
            // 
            // dgvCargadas
            // 
            this.dgvCargadas.AllowUserToAddRows = false;
            this.dgvCargadas.AllowUserToDeleteRows = false;
            this.dgvCargadas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvCargadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCargadas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCargadas.BackgroundColor = System.Drawing.Color.White;
            this.dgvCargadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCargadas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvCargadas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCargadas.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargadas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCargadas.EnableHeadersVisualStyles = false;
            this.dgvCargadas.GridColor = System.Drawing.Color.Azure;
            this.dgvCargadas.Location = new System.Drawing.Point(255, 13);
            this.dgvCargadas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCargadas.Name = "dgvCargadas";
            this.dgvCargadas.ReadOnly = true;
            this.dgvCargadas.RowHeadersVisible = false;
            this.dgvCargadas.RowHeadersWidth = 100;
            this.dgvCargadas.RowTemplate.DividerHeight = 1;
            this.dgvCargadas.RowTemplate.Height = 50;
            this.dgvCargadas.RowTemplate.ReadOnly = true;
            this.dgvCargadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCargadas.Size = new System.Drawing.Size(229, 282);
            this.dgvCargadas.TabIndex = 180;
            this.dgvCargadas.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgvCargadas.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCargadas.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCargadas.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCargadas.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCargadas.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCargadas.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCargadas.ThemeStyle.GridColor = System.Drawing.Color.Azure;
            this.dgvCargadas.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCargadas.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCargadas.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCargadas.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCargadas.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCargadas.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvCargadas.ThemeStyle.ReadOnly = true;
            this.dgvCargadas.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCargadas.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvCargadas.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCargadas.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCargadas.ThemeStyle.RowsStyle.Height = 50;
            this.dgvCargadas.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCargadas.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dtgAsignados
            // 
            this.dtgAsignados.AllowUserToAddRows = false;
            this.dtgAsignados.AllowUserToDeleteRows = false;
            this.dtgAsignados.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dtgAsignados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgAsignados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgAsignados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgAsignados.BackgroundColor = System.Drawing.Color.White;
            this.dtgAsignados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgAsignados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dtgAsignados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAsignados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgAsignados.ColumnHeadersHeight = 40;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgAsignados.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtgAsignados.EnableHeadersVisualStyles = false;
            this.dtgAsignados.GridColor = System.Drawing.Color.Azure;
            this.dtgAsignados.Location = new System.Drawing.Point(11, 13);
            this.dtgAsignados.Margin = new System.Windows.Forms.Padding(2);
            this.dtgAsignados.Name = "dtgAsignados";
            this.dtgAsignados.ReadOnly = true;
            this.dtgAsignados.RowHeadersVisible = false;
            this.dtgAsignados.RowHeadersWidth = 100;
            this.dtgAsignados.RowTemplate.DividerHeight = 1;
            this.dtgAsignados.RowTemplate.Height = 50;
            this.dtgAsignados.RowTemplate.ReadOnly = true;
            this.dtgAsignados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgAsignados.Size = new System.Drawing.Size(230, 282);
            this.dtgAsignados.TabIndex = 179;
            this.dtgAsignados.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dtgAsignados.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgAsignados.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgAsignados.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgAsignados.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgAsignados.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgAsignados.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgAsignados.ThemeStyle.GridColor = System.Drawing.Color.Azure;
            this.dtgAsignados.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgAsignados.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgAsignados.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtgAsignados.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgAsignados.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgAsignados.ThemeStyle.HeaderStyle.Height = 40;
            this.dtgAsignados.ThemeStyle.ReadOnly = true;
            this.dtgAsignados.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgAsignados.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dtgAsignados.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtgAsignados.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgAsignados.ThemeStyle.RowsStyle.Height = 50;
            this.dtgAsignados.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgAsignados.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(274, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 22);
            this.label14.TabIndex = 184;
            this.label14.Text = "Tipo de Operacion:";
            // 
            // tipoOper
            // 
            this.tipoOper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoOper.FormattingEnabled = true;
            this.tipoOper.Items.AddRange(new object[] {
            "SD",
            "TJ",
            "CSL"});
            this.tipoOper.Location = new System.Drawing.Point(277, 38);
            this.tipoOper.Margin = new System.Windows.Forms.Padding(2);
            this.tipoOper.Name = "tipoOper";
            this.tipoOper.Size = new System.Drawing.Size(225, 28);
            this.tipoOper.TabIndex = 183;
            this.tipoOper.SelectedIndexChanged += new System.EventHandler(this.tipoOper_SelectedIndexChanged);
            // 
            // cbxOrdenes
            // 
            this.cbxOrdenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.cbxOrdenes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxOrdenes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxOrdenes.DropDownHeight = 100;
            this.cbxOrdenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrdenes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbxOrdenes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.cbxOrdenes.FormattingEnabled = true;
            this.cbxOrdenes.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cbxOrdenes.IntegralHeight = false;
            this.cbxOrdenes.ItemHeight = 20;
            this.cbxOrdenes.Location = new System.Drawing.Point(16, 113);
            this.cbxOrdenes.Name = "cbxOrdenes";
            this.cbxOrdenes.Size = new System.Drawing.Size(225, 26);
            this.cbxOrdenes.StartIndex = 0;
            this.cbxOrdenes.TabIndex = 182;
            this.cbxOrdenes.SelectedIndexChanged += new System.EventHandler(this.cbxOrdenes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(14, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 181;
            this.label1.Text = "Ordenes";
            // 
            // btnAlta
            // 
            this.btnAlta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlta.Animated = true;
            this.btnAlta.AnimationHoverSpeed = 0.07F;
            this.btnAlta.AnimationSpeed = 0.03F;
            this.btnAlta.BackColor = System.Drawing.Color.Transparent;
            this.btnAlta.BaseColor1 = System.Drawing.Color.Turquoise;
            this.btnAlta.BaseColor2 = System.Drawing.Color.MediumTurquoise;
            this.btnAlta.BorderColor = System.Drawing.Color.Black;
            this.btnAlta.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAlta.FocusedColor = System.Drawing.Color.Empty;
            this.btnAlta.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlta.ForeColor = System.Drawing.Color.White;
            this.btnAlta.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnAlta.Image = null;
            this.btnAlta.ImageSize = new System.Drawing.Size(100, 80);
            this.btnAlta.Location = new System.Drawing.Point(1018, 83);
            this.btnAlta.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnAlta.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnAlta.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAlta.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAlta.OnHoverImage = null;
            this.btnAlta.OnPressedColor = System.Drawing.Color.Black;
            this.btnAlta.Radius = 5;
            this.btnAlta.Size = new System.Drawing.Size(229, 112);
            this.btnAlta.TabIndex = 176;
            this.btnAlta.Text = "Ordenes de Carga";
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label6.Location = new System.Drawing.Point(1028, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 175;
            this.label6.Text = "A:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label7.Location = new System.Drawing.Point(788, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 174;
            this.label7.Text = "DE:";
            // 
            // dtFecha2
            // 
            this.dtFecha2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFecha2.BaseColor = System.Drawing.Color.White;
            this.dtFecha2.BorderColor = System.Drawing.Color.Silver;
            this.dtFecha2.CustomFormat = null;
            this.dtFecha2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtFecha2.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtFecha2.ForeColor = System.Drawing.Color.Black;
            this.dtFecha2.Location = new System.Drawing.Point(1051, 26);
            this.dtFecha2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtFecha2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtFecha2.Name = "dtFecha2";
            this.dtFecha2.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtFecha2.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha2.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha2.OnPressedColor = System.Drawing.Color.Black;
            this.dtFecha2.Size = new System.Drawing.Size(196, 30);
            this.dtFecha2.TabIndex = 173;
            this.dtFecha2.Text = "viernes, marzo 10, 2023";
            this.dtFecha2.Value = new System.DateTime(2023, 3, 10, 11, 29, 29, 92);
            // 
            // dtFecha1
            // 
            this.dtFecha1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFecha1.BaseColor = System.Drawing.Color.White;
            this.dtFecha1.BorderColor = System.Drawing.Color.Silver;
            this.dtFecha1.CustomFormat = null;
            this.dtFecha1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtFecha1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtFecha1.ForeColor = System.Drawing.Color.Black;
            this.dtFecha1.Location = new System.Drawing.Point(819, 26);
            this.dtFecha1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtFecha1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtFecha1.Name = "dtFecha1";
            this.dtFecha1.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtFecha1.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha1.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha1.OnPressedColor = System.Drawing.Color.Black;
            this.dtFecha1.Size = new System.Drawing.Size(199, 30);
            this.dtFecha1.TabIndex = 172;
            this.dtFecha1.Text = "viernes, marzo 10, 2023";
            this.dtFecha1.Value = new System.DateTime(2023, 3, 10, 11, 29, 29, 92);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rCa);
            this.groupBox1.Controls.Add(this.rTj);
            this.groupBox1.Controls.Add(this.rSd);
            this.groupBox1.Location = new System.Drawing.Point(16, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 48);
            this.groupBox1.TabIndex = 170;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sucursal";
            // 
            // rCa
            // 
            this.rCa.AutoSize = true;
            this.rCa.Location = new System.Drawing.Point(179, 19);
            this.rCa.Name = "rCa";
            this.rCa.Size = new System.Drawing.Size(63, 17);
            this.rCa.TabIndex = 2;
            this.rCa.Text = "Cabo S.";
            this.rCa.UseVisualStyleBackColor = true;
            this.rCa.CheckedChanged += new System.EventHandler(this.rSd_CheckedChanged);
            // 
            // rTj
            // 
            this.rTj.AutoSize = true;
            this.rTj.Location = new System.Drawing.Point(97, 19);
            this.rTj.Name = "rTj";
            this.rTj.Size = new System.Drawing.Size(60, 17);
            this.rTj.TabIndex = 1;
            this.rTj.Text = "Tijuana";
            this.rTj.UseVisualStyleBackColor = true;
            this.rTj.CheckedChanged += new System.EventHandler(this.rSd_CheckedChanged);
            // 
            // rSd
            // 
            this.rSd.AutoSize = true;
            this.rSd.Checked = true;
            this.rSd.Location = new System.Drawing.Point(6, 19);
            this.rSd.Name = "rSd";
            this.rSd.Size = new System.Drawing.Size(75, 17);
            this.rSd.TabIndex = 0;
            this.rSd.TabStop = true;
            this.rSd.Text = "San Diego";
            this.rSd.UseVisualStyleBackColor = true;
            this.rSd.CheckedChanged += new System.EventHandler(this.rSd_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.swBill);
            this.panel2.Location = new System.Drawing.Point(1086, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 32);
            this.panel2.TabIndex = 194;
            // 
            // swBill
            // 
            this.swBill.AutoSize = true;
            this.swBill.Depth = 0;
            this.swBill.Location = new System.Drawing.Point(120, -5);
            this.swBill.Margin = new System.Windows.Forms.Padding(0);
            this.swBill.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swBill.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.swBill.Name = "swBill";
            this.swBill.Ripple = true;
            this.swBill.Size = new System.Drawing.Size(80, 37);
            this.swBill.TabIndex = 195;
            this.swBill.Text = "Bill";
            this.swBill.UseAccentColor = false;
            this.swBill.UseVisualStyleBackColor = true;
            this.swBill.CheckedChanged += new System.EventHandler(this.swBill_CheckedChanged);
            // 
            // lblnBill
            // 
            this.lblnBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnBill.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblnBill.Location = new System.Drawing.Point(25, 9);
            this.lblnBill.Name = "lblnBill";
            this.lblnBill.Size = new System.Drawing.Size(138, 22);
            this.lblnBill.TabIndex = 194;
            // 
            // frmAddToCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1324, 642);
            this.Controls.Add(this.lblnBill);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmAddToCarga";
            this.ShowIcon = false;
            this.Text = "Agregar a Carga";
            this.Load += new System.EventHandler(this.frmAddToCarga_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSpliter.ResumeLayout(false);
            this.panelSpliter.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSinAsignar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAsignados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Guna.UI.WinForms.GunaDateTimePicker dtFecha2;
        private Guna.UI.WinForms.GunaDateTimePicker dtFecha1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rCa;
        private System.Windows.Forms.RadioButton rTj;
        private System.Windows.Forms.RadioButton rSd;
        private Guna.UI.WinForms.GunaGradientTileButton btnAlta;
        public Guna.UI.WinForms.GunaDataGridView dtgAsignados;
        public Guna.UI.WinForms.GunaDataGridView dtgSinAsignar;
        private ReaLTaiizor.Controls.ComboBoxEdit cbxOrdenes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox tipoOper;
        private System.Windows.Forms.Panel panelSpliter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblFechaC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbCarga;
        private System.Windows.Forms.DateTimePicker tmCierre;
        private System.Windows.Forms.Label txbTotal;
        public Guna.UI.WinForms.GunaDataGridView dgvCargadas;
        private Guna.UI.WinForms.GunaGradientTileButton btnGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbReferencia;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Panel panel2;
        private ReaLTaiizor.Controls.MaterialSwitch swBill;
        private System.Windows.Forms.Label lblnBill;
    }
}