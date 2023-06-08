namespace mainVentana.VistaOrdenCarga
{
    partial class frmModificaCarga
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.dgvEntEnCarga = new Guna.UI.WinForms.GunaDataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gunaGradientTileButton1 = new Guna.UI.WinForms.GunaGradientTileButton();
            this.btnCerrar = new Guna.UI.WinForms.GunaGradientTileButton();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.dtmHora = new System.Windows.Forms.DateTimePicker();
            this.gunaGroupBox3 = new Guna.UI.WinForms.GunaGroupBox();
            this.txbFechaAlta = new System.Windows.Forms.TextBox();
            this.txbCarga = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gunaGroupBox2 = new Guna.UI.WinForms.GunaGroupBox();
            this.cmbSucOrigen = new Guna.UI.WinForms.GunaComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaGroupBox1 = new Guna.UI.WinForms.GunaGroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtmFcierre = new Guna.UI.WinForms.GunaDateTimePicker();
            this.txbReferencia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbParidad = new System.Windows.Forms.TextBox();
            this.cmbMoneda = new Guna.UI.WinForms.GunaComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSucDest = new Guna.UI.WinForms.GunaComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tipoOper = new Guna.UI.WinForms.GunaComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOperacion = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.hopeSwitch1 = new ReaLTaiizor.Controls.HopeSwitch();
            this.label12 = new System.Windows.Forms.Label();
            this.loadControl1 = new Ventana1.LoadControl.loadControl();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntEnCarga)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.gunaGroupBox3.SuspendLayout();
            this.gunaGroupBox2.SuspendLayout();
            this.gunaGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.hopeSwitch1);
            this.panel2.Controls.Add(this.loadControl1);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txbTotal);
            this.panel2.Controls.Add(this.dgvEntEnCarga);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.btnImprimir);
            this.panel2.Controls.Add(this.dtmHora);
            this.panel2.Controls.Add(this.gunaGroupBox3);
            this.panel2.Controls.Add(this.gunaGroupBox2);
            this.panel2.Controls.Add(this.gunaGroupBox1);
            this.panel2.Controls.Add(this.txtOperacion);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 616);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 535);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Cantidad:";
            // 
            // txbTotal
            // 
            this.txbTotal.Location = new System.Drawing.Point(93, 530);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.ReadOnly = true;
            this.txbTotal.Size = new System.Drawing.Size(189, 20);
            this.txbTotal.TabIndex = 33;
            // 
            // dgvEntEnCarga
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvEntEnCarga.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEntEnCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEntEnCarga.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEntEnCarga.BackgroundColor = System.Drawing.Color.White;
            this.dgvEntEnCarga.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEntEnCarga.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEntEnCarga.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEntEnCarga.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEntEnCarga.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEntEnCarga.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEntEnCarga.EnableHeadersVisualStyles = false;
            this.dgvEntEnCarga.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEntEnCarga.Location = new System.Drawing.Point(29, 373);
            this.dgvEntEnCarga.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEntEnCarga.Name = "dgvEntEnCarga";
            this.dgvEntEnCarga.RowHeadersVisible = false;
            this.dgvEntEnCarga.RowHeadersWidth = 51;
            this.dgvEntEnCarga.RowTemplate.Height = 30;
            this.dgvEntEnCarga.RowTemplate.ReadOnly = true;
            this.dgvEntEnCarga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntEnCarga.Size = new System.Drawing.Size(733, 145);
            this.dgvEntEnCarga.TabIndex = 32;
            this.dgvEntEnCarga.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgvEntEnCarga.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEntEnCarga.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvEntEnCarga.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvEntEnCarga.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvEntEnCarga.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvEntEnCarga.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvEntEnCarga.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEntEnCarga.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvEntEnCarga.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvEntEnCarga.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvEntEnCarga.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvEntEnCarga.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvEntEnCarga.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvEntEnCarga.ThemeStyle.ReadOnly = false;
            this.dgvEntEnCarga.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEntEnCarga.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEntEnCarga.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvEntEnCarga.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvEntEnCarga.ThemeStyle.RowsStyle.Height = 30;
            this.dgvEntEnCarga.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEntEnCarga.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.gunaGradientTileButton1);
            this.flowLayoutPanel1.Controls.Add(this.btnCerrar);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(393, 547);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(369, 114);
            this.flowLayoutPanel1.TabIndex = 29;
            // 
            // gunaGradientTileButton1
            // 
            this.gunaGradientTileButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGradientTileButton1.AnimationHoverSpeed = 0.07F;
            this.gunaGradientTileButton1.AnimationSpeed = 0.03F;
            this.gunaGradientTileButton1.BaseColor1 = System.Drawing.Color.DarkSalmon;
            this.gunaGradientTileButton1.BaseColor2 = System.Drawing.Color.Crimson;
            this.gunaGradientTileButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientTileButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientTileButton1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGradientTileButton1.ForeColor = System.Drawing.Color.White;
            this.gunaGradientTileButton1.Image = null;
            this.gunaGradientTileButton1.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaGradientTileButton1.Location = new System.Drawing.Point(3, 3);
            this.gunaGradientTileButton1.Name = "gunaGradientTileButton1";
            this.gunaGradientTileButton1.OnHoverBaseColor1 = System.Drawing.Color.DimGray;
            this.gunaGradientTileButton1.OnHoverBaseColor2 = System.Drawing.Color.Gray;
            this.gunaGradientTileButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientTileButton1.OnHoverImage = null;
            this.gunaGradientTileButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton1.Size = new System.Drawing.Size(366, 51);
            this.gunaGradientTileButton1.TabIndex = 9;
            this.gunaGradientTileButton1.Text = "Modificar Orden de Carga.";
            this.gunaGradientTileButton1.Click += new System.EventHandler(this.gunaGradientTileButton1_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.AnimationHoverSpeed = 0.07F;
            this.btnCerrar.AnimationSpeed = 0.03F;
            this.btnCerrar.BaseColor1 = System.Drawing.Color.DarkCyan;
            this.btnCerrar.BaseColor2 = System.Drawing.Color.CadetBlue;
            this.btnCerrar.BorderColor = System.Drawing.Color.Black;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCerrar.Enabled = false;
            this.btnCerrar.FocusedColor = System.Drawing.Color.Empty;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Image = null;
            this.btnCerrar.ImageSize = new System.Drawing.Size(52, 52);
            this.btnCerrar.Location = new System.Drawing.Point(3, 60);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.OnHoverBaseColor1 = System.Drawing.Color.LightGray;
            this.btnCerrar.OnHoverBaseColor2 = System.Drawing.Color.Gray;
            this.btnCerrar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnCerrar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnCerrar.OnHoverImage = null;
            this.btnCerrar.OnPressedColor = System.Drawing.Color.Black;
            this.btnCerrar.Size = new System.Drawing.Size(366, 51);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar Orden.";
            this.btnCerrar.Visible = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimir.Enabled = false;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImprimir.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir.IconColor = System.Drawing.Color.Black;
            this.btnImprimir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(29, 556);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(253, 51);
            this.btnImprimir.TabIndex = 28;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // dtmHora
            // 
            this.dtmHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtmHora.CustomFormat = "HH:mm:ss";
            this.dtmHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmHora.Location = new System.Drawing.Point(620, 340);
            this.dtmHora.Name = "dtmHora";
            this.dtmHora.ShowUpDown = true;
            this.dtmHora.Size = new System.Drawing.Size(120, 20);
            this.dtmHora.TabIndex = 27;
            // 
            // gunaGroupBox3
            // 
            this.gunaGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox3.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox3.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox3.Controls.Add(this.txbFechaAlta);
            this.gunaGroupBox3.Controls.Add(this.txbCarga);
            this.gunaGroupBox3.Controls.Add(this.label3);
            this.gunaGroupBox3.Controls.Add(this.label2);
            this.gunaGroupBox3.LineColor = System.Drawing.Color.DarkSalmon;
            this.gunaGroupBox3.Location = new System.Drawing.Point(417, 58);
            this.gunaGroupBox3.Name = "gunaGroupBox3";
            this.gunaGroupBox3.Size = new System.Drawing.Size(345, 143);
            this.gunaGroupBox3.TabIndex = 8;
            this.gunaGroupBox3.Text = "Documento";
            this.gunaGroupBox3.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // txbFechaAlta
            // 
            this.txbFechaAlta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbFechaAlta.Enabled = false;
            this.txbFechaAlta.Location = new System.Drawing.Point(162, 92);
            this.txbFechaAlta.Name = "txbFechaAlta";
            this.txbFechaAlta.Size = new System.Drawing.Size(128, 20);
            this.txbFechaAlta.TabIndex = 22;
            // 
            // txbCarga
            // 
            this.txbCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCarga.Location = new System.Drawing.Point(162, 62);
            this.txbCarga.Name = "txbCarga";
            this.txbCarga.Size = new System.Drawing.Size(128, 20);
            this.txbCarga.TabIndex = 21;
            this.txbCarga.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbCarga_KeyDown);
            this.txbCarga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCarga_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Fecha de alta.";
            this.label3.UseMnemonic = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Numero de Orden.";
            this.label2.UseMnemonic = false;
            // 
            // gunaGroupBox2
            // 
            this.gunaGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox2.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox2.Controls.Add(this.cmbSucOrigen);
            this.gunaGroupBox2.Controls.Add(this.label1);
            this.gunaGroupBox2.LineColor = System.Drawing.Color.DarkSalmon;
            this.gunaGroupBox2.Location = new System.Drawing.Point(29, 58);
            this.gunaGroupBox2.Name = "gunaGroupBox2";
            this.gunaGroupBox2.Size = new System.Drawing.Size(345, 143);
            this.gunaGroupBox2.TabIndex = 7;
            this.gunaGroupBox2.Text = "Generales.";
            this.gunaGroupBox2.TextLocation = new System.Drawing.Point(10, 8);
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
            this.cmbSucOrigen.Location = new System.Drawing.Point(6, 79);
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
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Sucursal de Alta";
            this.label1.UseMnemonic = false;
            // 
            // gunaGroupBox1
            // 
            this.gunaGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox1.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Controls.Add(this.label10);
            this.gunaGroupBox1.Controls.Add(this.label9);
            this.gunaGroupBox1.Controls.Add(this.dtmFcierre);
            this.gunaGroupBox1.Controls.Add(this.txbReferencia);
            this.gunaGroupBox1.Controls.Add(this.label8);
            this.gunaGroupBox1.Controls.Add(this.txbParidad);
            this.gunaGroupBox1.Controls.Add(this.cmbMoneda);
            this.gunaGroupBox1.Controls.Add(this.label7);
            this.gunaGroupBox1.Controls.Add(this.label6);
            this.gunaGroupBox1.Controls.Add(this.cmbSucDest);
            this.gunaGroupBox1.Controls.Add(this.label5);
            this.gunaGroupBox1.Controls.Add(this.tipoOper);
            this.gunaGroupBox1.Controls.Add(this.label4);
            this.gunaGroupBox1.LineColor = System.Drawing.Color.DarkSalmon;
            this.gunaGroupBox1.Location = new System.Drawing.Point(29, 207);
            this.gunaGroupBox1.Name = "gunaGroupBox1";
            this.gunaGroupBox1.Size = new System.Drawing.Size(733, 161);
            this.gunaGroupBox1.TabIndex = 6;
            this.gunaGroupBox1.Text = "Detalles.";
            this.gunaGroupBox1.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(591, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "Fecha Cierre.";
            this.label10.UseMnemonic = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(591, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Hora cierre.";
            this.label9.UseMnemonic = false;
            // 
            // dtmFcierre
            // 
            this.dtmFcierre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtmFcierre.BaseColor = System.Drawing.Color.White;
            this.dtmFcierre.BorderColor = System.Drawing.Color.Silver;
            this.dtmFcierre.CustomFormat = null;
            this.dtmFcierre.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtmFcierre.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtmFcierre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtmFcierre.ForeColor = System.Drawing.Color.Black;
            this.dtmFcierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmFcierre.Location = new System.Drawing.Point(591, 61);
            this.dtmFcierre.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtmFcierre.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtmFcierre.Name = "dtmFcierre";
            this.dtmFcierre.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtmFcierre.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtmFcierre.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtmFcierre.OnPressedColor = System.Drawing.Color.Black;
            this.dtmFcierre.Size = new System.Drawing.Size(120, 30);
            this.dtmFcierre.TabIndex = 23;
            this.dtmFcierre.Text = "12/7/2022";
            this.dtmFcierre.Value = new System.DateTime(2022, 12, 7, 10, 36, 37, 20);
            // 
            // txbReferencia
            // 
            this.txbReferencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbReferencia.Location = new System.Drawing.Point(364, 124);
            this.txbReferencia.MaxLength = 19;
            this.txbReferencia.Name = "txbReferencia";
            this.txbReferencia.Size = new System.Drawing.Size(221, 20);
            this.txbReferencia.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(285, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Referencia.";
            this.label8.UseMnemonic = false;
            // 
            // txbParidad
            // 
            this.txbParidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbParidad.Enabled = false;
            this.txbParidad.Location = new System.Drawing.Point(364, 93);
            this.txbParidad.Name = "txbParidad";
            this.txbParidad.Size = new System.Drawing.Size(221, 20);
            this.txbParidad.TabIndex = 20;
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMoneda.BackColor = System.Drawing.Color.Transparent;
            this.cmbMoneda.BaseColor = System.Drawing.Color.White;
            this.cmbMoneda.BorderColor = System.Drawing.Color.Silver;
            this.cmbMoneda.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoneda.FocusedColor = System.Drawing.Color.Empty;
            this.cmbMoneda.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMoneda.ForeColor = System.Drawing.Color.Black;
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Location = new System.Drawing.Point(364, 61);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmbMoneda.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmbMoneda.Size = new System.Drawing.Size(221, 26);
            this.cmbMoneda.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(285, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Paridad.";
            this.label7.UseMnemonic = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(285, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Moneda.";
            this.label6.UseMnemonic = false;
            // 
            // cmbSucDest
            // 
            this.cmbSucDest.BackColor = System.Drawing.Color.Transparent;
            this.cmbSucDest.BaseColor = System.Drawing.Color.White;
            this.cmbSucDest.BorderColor = System.Drawing.Color.Silver;
            this.cmbSucDest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSucDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSucDest.FocusedColor = System.Drawing.Color.Empty;
            this.cmbSucDest.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSucDest.ForeColor = System.Drawing.Color.Black;
            this.cmbSucDest.FormattingEnabled = true;
            this.cmbSucDest.Location = new System.Drawing.Point(6, 118);
            this.cmbSucDest.Name = "cmbSucDest";
            this.cmbSucDest.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmbSucDest.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmbSucDest.Size = new System.Drawing.Size(247, 26);
            this.cmbSucDest.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Sucursal Destino.";
            this.label5.UseMnemonic = false;
            // 
            // tipoOper
            // 
            this.tipoOper.BackColor = System.Drawing.Color.Transparent;
            this.tipoOper.BaseColor = System.Drawing.Color.White;
            this.tipoOper.BorderColor = System.Drawing.Color.Silver;
            this.tipoOper.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tipoOper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoOper.FocusedColor = System.Drawing.Color.Empty;
            this.tipoOper.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tipoOper.ForeColor = System.Drawing.Color.Black;
            this.tipoOper.FormattingEnabled = true;
            this.tipoOper.Location = new System.Drawing.Point(6, 61);
            this.tipoOper.Name = "tipoOper";
            this.tipoOper.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.tipoOper.OnHoverItemForeColor = System.Drawing.Color.White;
            this.tipoOper.Size = new System.Drawing.Size(247, 26);
            this.tipoOper.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tipo de operación.";
            this.label4.UseMnemonic = false;
            // 
            // txtOperacion
            // 
            this.txtOperacion.AutoSize = true;
            this.txtOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOperacion.Location = new System.Drawing.Point(25, 17);
            this.txtOperacion.Name = "txtOperacion";
            this.txtOperacion.Size = new System.Drawing.Size(277, 20);
            this.txtOperacion.TabIndex = 5;
            this.txtOperacion.Text = "Modifica Folio de Orden de Carga";
            this.txtOperacion.UseMnemonic = false;
            this.txtOperacion.Click += new System.EventHandler(this.txtOperacion_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // hopeSwitch1
            // 
            this.hopeSwitch1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hopeSwitch1.AutoSize = true;
            this.hopeSwitch1.BackColor = System.Drawing.Color.White;
            this.hopeSwitch1.BaseColor = System.Drawing.Color.White;
            this.hopeSwitch1.BaseOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.hopeSwitch1.BaseOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.hopeSwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeSwitch1.ForeColor = System.Drawing.Color.White;
            this.hopeSwitch1.Location = new System.Drawing.Point(722, 32);
            this.hopeSwitch1.Name = "hopeSwitch1";
            this.hopeSwitch1.Size = new System.Drawing.Size(40, 20);
            this.hopeSwitch1.TabIndex = 30;
            this.hopeSwitch1.Text = "hopeSwitch1";
            this.hopeSwitch1.UseVisualStyleBackColor = false;
            this.hopeSwitch1.CheckedChanged += new System.EventHandler(this.hopeSwitch1_CheckedChanged);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(650, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 16);
            this.label12.TabIndex = 29;
            this.label12.Text = "Entrega:";
            this.label12.UseMnemonic = false;
            // 
            // loadControl1
            // 
            this.loadControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadControl1.Location = new System.Drawing.Point(293, 528);
            this.loadControl1.Margin = new System.Windows.Forms.Padding(2);
            this.loadControl1.Name = "loadControl1";
            this.loadControl1.Size = new System.Drawing.Size(81, 79);
            this.loadControl1.TabIndex = 35;
            this.loadControl1.Visible = false;
            // 
            // frmModificaCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 616);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(816, 596);
            this.Name = "frmModificaCarga";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifica Carga";
            this.Load += new System.EventHandler(this.frmModificaCarga_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntEnCarga)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gunaGroupBox3.ResumeLayout(false);
            this.gunaGroupBox3.PerformLayout();
            this.gunaGroupBox2.ResumeLayout(false);
            this.gunaGroupBox2.PerformLayout();
            this.gunaGroupBox1.ResumeLayout(false);
            this.gunaGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtmHora;
        private Guna.UI.WinForms.GunaGradientTileButton gunaGradientTileButton1;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox3;
        private System.Windows.Forms.TextBox txbFechaAlta;
        private System.Windows.Forms.TextBox txbCarga;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox2;
        private Guna.UI.WinForms.GunaComboBox cmbSucOrigen;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private Guna.UI.WinForms.GunaDateTimePicker dtmFcierre;
        private System.Windows.Forms.TextBox txbReferencia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbParidad;
        private Guna.UI.WinForms.GunaComboBox cmbMoneda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Guna.UI.WinForms.GunaComboBox cmbSucDest;
        private System.Windows.Forms.Label label5;
        private Guna.UI.WinForms.GunaComboBox tipoOper;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label txtOperacion;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI.WinForms.GunaGradientTileButton btnCerrar;
        private Guna.UI.WinForms.GunaDataGridView dgvEntEnCarga;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbTotal;
        private Ventana1.LoadControl.loadControl loadControl1;
        private System.Windows.Forms.Label label12;
        private ReaLTaiizor.Controls.HopeSwitch hopeSwitch1;
    }
}