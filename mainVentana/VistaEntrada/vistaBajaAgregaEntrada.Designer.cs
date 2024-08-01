namespace mainVentana.VistaEntrada
{
    partial class vistaBajaAgregaEntrada
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gunaElipsePanel2 = new Guna.UI.WinForms.GunaElipsePanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTotalEt = new System.Windows.Forms.TextBox();
            this.dtgEtiquetas = new ADGV.AdvancedDataGridView();
            this.gunaElipsePanel1 = new Guna.UI.WinForms.GunaElipsePanel();
            this.lblEntrada = new Guna.UI.WinForms.GunaLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gunaGradientTileButton1 = new Guna.UI.WinForms.GunaGradientTileButton();
            this.btnEntrada = new Guna.UI.WinForms.GunaGradientTileButton();
            this.gunaElipsePanel3 = new Guna.UI.WinForms.GunaElipsePanel();
            this.txbDescripcion = new ReaLTaiizor.Controls.MaterialRichTextBox();
            this.txbEntiquetaSeleccionada = new System.Windows.Forms.TextBox();
            this.buttonSaveDesc = new Guna.UI.WinForms.GunaGradientTileButton();
            this.gbxBorra = new Guna.UI.WinForms.GunaGroupBox();
            this.btnBorra = new Guna.UI.WinForms.GunaTileButton();
            this.label6 = new System.Windows.Forms.Label();
            this.nBorra = new Guna.UI.WinForms.GunaNumeric();
            this.gbxAgrega = new Guna.UI.WinForms.GunaGroupBox();
            this.btnAgrega = new Guna.UI.WinForms.GunaTileButton();
            this.lblAgrega = new System.Windows.Forms.Label();
            this.nAgrega = new Guna.UI.WinForms.GunaNumeric();
            this.AddOrDeletePanel = new System.Windows.Forms.Panel();
            this.tbxLongitud = new System.Windows.Forms.TextBox();
            this.txbAnchura = new System.Windows.Forms.TextBox();
            this.txbAltura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLongitud = new System.Windows.Forms.Label();
            this.lblAnchura = new System.Windows.Forms.Label();
            this.lblAltura = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblPesoV = new System.Windows.Forms.Label();
            this.gunaElipsePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEtiquetas)).BeginInit();
            this.gunaElipsePanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gunaElipsePanel3.SuspendLayout();
            this.gbxBorra.SuspendLayout();
            this.gbxAgrega.SuspendLayout();
            this.AddOrDeletePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaElipsePanel2
            // 
            this.gunaElipsePanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaElipsePanel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel2.BaseColor = System.Drawing.Color.White;
            this.gunaElipsePanel2.Controls.Add(this.label1);
            this.gunaElipsePanel2.Controls.Add(this.txbTotalEt);
            this.gunaElipsePanel2.Controls.Add(this.dtgEtiquetas);
            this.gunaElipsePanel2.Location = new System.Drawing.Point(12, 132);
            this.gunaElipsePanel2.Name = "gunaElipsePanel2";
            this.gunaElipsePanel2.Radius = 20;
            this.gunaElipsePanel2.Size = new System.Drawing.Size(673, 426);
            this.gunaElipsePanel2.TabIndex = 160;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(21, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 161;
            this.label1.Text = "Total de etiquetas actuales:";
            // 
            // txbTotalEt
            // 
            this.txbTotalEt.Location = new System.Drawing.Point(24, 386);
            this.txbTotalEt.Name = "txbTotalEt";
            this.txbTotalEt.ReadOnly = true;
            this.txbTotalEt.Size = new System.Drawing.Size(100, 20);
            this.txbTotalEt.TabIndex = 140;
            // 
            // dtgEtiquetas
            // 
            this.dtgEtiquetas.AllowUserToAddRows = false;
            this.dtgEtiquetas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dtgEtiquetas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgEtiquetas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgEtiquetas.AutoGenerateContextFilters = true;
            this.dtgEtiquetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEtiquetas.BackgroundColor = System.Drawing.Color.White;
            this.dtgEtiquetas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgEtiquetas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEtiquetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgEtiquetas.ColumnHeadersHeight = 30;
            this.dtgEtiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgEtiquetas.DateWithTime = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgEtiquetas.DefaultCellStyle = dataGridViewCellStyle7;
            this.dtgEtiquetas.EnableHeadersVisualStyles = false;
            this.dtgEtiquetas.GridColor = System.Drawing.Color.White;
            this.dtgEtiquetas.Location = new System.Drawing.Point(22, 12);
            this.dtgEtiquetas.MultiSelect = false;
            this.dtgEtiquetas.Name = "dtgEtiquetas";
            this.dtgEtiquetas.ReadOnly = true;
            this.dtgEtiquetas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEtiquetas.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgEtiquetas.RowHeadersVisible = false;
            this.dtgEtiquetas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtgEtiquetas.RowTemplate.DividerHeight = 1;
            this.dtgEtiquetas.RowTemplate.Height = 50;
            this.dtgEtiquetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEtiquetas.Size = new System.Drawing.Size(629, 345);
            this.dtgEtiquetas.TabIndex = 139;
            this.dtgEtiquetas.TimeFilter = false;
            this.dtgEtiquetas.SelectionChanged += new System.EventHandler(this.dtgEtiquetas_SelectionChanged);
            // 
            // gunaElipsePanel1
            // 
            this.gunaElipsePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaElipsePanel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel1.BaseColor = System.Drawing.Color.White;
            this.gunaElipsePanel1.Controls.Add(this.lblEntrada);
            this.gunaElipsePanel1.Location = new System.Drawing.Point(12, 12);
            this.gunaElipsePanel1.Name = "gunaElipsePanel1";
            this.gunaElipsePanel1.Radius = 20;
            this.gunaElipsePanel1.Size = new System.Drawing.Size(1157, 108);
            this.gunaElipsePanel1.TabIndex = 159;
            // 
            // lblEntrada
            // 
            this.lblEntrada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Font = new System.Drawing.Font("Segoe UI Black", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntrada.Location = new System.Drawing.Point(369, 0);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(348, 106);
            this.lblEntrada.TabIndex = 0;
            this.lblEntrada.Text = "Entrada";
            this.lblEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gunaGradientTileButton1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEntrada, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(22, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(488, 104);
            this.tableLayoutPanel1.TabIndex = 158;
            // 
            // gunaGradientTileButton1
            // 
            this.gunaGradientTileButton1.Animated = true;
            this.gunaGradientTileButton1.AnimationHoverSpeed = 0.07F;
            this.gunaGradientTileButton1.AnimationSpeed = 0.03F;
            this.gunaGradientTileButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradientTileButton1.BaseColor1 = System.Drawing.Color.Blue;
            this.gunaGradientTileButton1.BaseColor2 = System.Drawing.Color.Navy;
            this.gunaGradientTileButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientTileButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaGradientTileButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientTileButton1.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGradientTileButton1.ForeColor = System.Drawing.Color.White;
            this.gunaGradientTileButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gunaGradientTileButton1.Image = null;
            this.gunaGradientTileButton1.ImageSize = new System.Drawing.Size(100, 80);
            this.gunaGradientTileButton1.Location = new System.Drawing.Point(246, 2);
            this.gunaGradientTileButton1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaGradientTileButton1.Name = "gunaGradientTileButton1";
            this.gunaGradientTileButton1.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.gunaGradientTileButton1.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.gunaGradientTileButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientTileButton1.OnHoverImage = null;
            this.gunaGradientTileButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton1.Radius = 5;
            this.gunaGradientTileButton1.Size = new System.Drawing.Size(240, 100);
            this.gunaGradientTileButton1.TabIndex = 22;
            this.gunaGradientTileButton1.Text = "Agregar";
            this.gunaGradientTileButton1.Click += new System.EventHandler(this.gunaGradientTileButton1_Click);
            // 
            // btnEntrada
            // 
            this.btnEntrada.Animated = true;
            this.btnEntrada.AnimationHoverSpeed = 0.07F;
            this.btnEntrada.AnimationSpeed = 0.03F;
            this.btnEntrada.BackColor = System.Drawing.Color.Transparent;
            this.btnEntrada.BaseColor1 = System.Drawing.Color.Red;
            this.btnEntrada.BaseColor2 = System.Drawing.Color.Maroon;
            this.btnEntrada.BorderColor = System.Drawing.Color.Black;
            this.btnEntrada.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEntrada.FocusedColor = System.Drawing.Color.Empty;
            this.btnEntrada.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrada.ForeColor = System.Drawing.Color.White;
            this.btnEntrada.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnEntrada.Image = null;
            this.btnEntrada.ImageSize = new System.Drawing.Size(100, 80);
            this.btnEntrada.Location = new System.Drawing.Point(2, 2);
            this.btnEntrada.Margin = new System.Windows.Forms.Padding(2);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnEntrada.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnEntrada.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnEntrada.OnHoverForeColor = System.Drawing.Color.White;
            this.btnEntrada.OnHoverImage = null;
            this.btnEntrada.OnPressedColor = System.Drawing.Color.Black;
            this.btnEntrada.Radius = 5;
            this.btnEntrada.Size = new System.Drawing.Size(240, 100);
            this.btnEntrada.TabIndex = 21;
            this.btnEntrada.Text = "Eliminar";
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // gunaElipsePanel3
            // 
            this.gunaElipsePanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaElipsePanel3.BackColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel3.BaseColor = System.Drawing.Color.White;
            this.gunaElipsePanel3.Controls.Add(this.lblPesoV);
            this.gunaElipsePanel3.Controls.Add(this.textBox1);
            this.gunaElipsePanel3.Controls.Add(this.lblAltura);
            this.gunaElipsePanel3.Controls.Add(this.lblAnchura);
            this.gunaElipsePanel3.Controls.Add(this.lblLongitud);
            this.gunaElipsePanel3.Controls.Add(this.label2);
            this.gunaElipsePanel3.Controls.Add(this.txbAltura);
            this.gunaElipsePanel3.Controls.Add(this.txbAnchura);
            this.gunaElipsePanel3.Controls.Add(this.tbxLongitud);
            this.gunaElipsePanel3.Controls.Add(this.txbDescripcion);
            this.gunaElipsePanel3.Controls.Add(this.txbEntiquetaSeleccionada);
            this.gunaElipsePanel3.Controls.Add(this.buttonSaveDesc);
            this.gunaElipsePanel3.Location = new System.Drawing.Point(691, 132);
            this.gunaElipsePanel3.Name = "gunaElipsePanel3";
            this.gunaElipsePanel3.Radius = 20;
            this.gunaElipsePanel3.Size = new System.Drawing.Size(478, 426);
            this.gunaElipsePanel3.TabIndex = 161;
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txbDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbDescripcion.Depth = 0;
            this.txbDescripcion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txbDescripcion.Hint = "";
            this.txbDescripcion.Location = new System.Drawing.Point(22, 53);
            this.txbDescripcion.MaxLength = 249;
            this.txbDescripcion.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(426, 140);
            this.txbDescripcion.TabIndex = 163;
            this.txbDescripcion.Text = "";
            // 
            // txbEntiquetaSeleccionada
            // 
            this.txbEntiquetaSeleccionada.Location = new System.Drawing.Point(22, 12);
            this.txbEntiquetaSeleccionada.Name = "txbEntiquetaSeleccionada";
            this.txbEntiquetaSeleccionada.ReadOnly = true;
            this.txbEntiquetaSeleccionada.Size = new System.Drawing.Size(160, 20);
            this.txbEntiquetaSeleccionada.TabIndex = 162;
            // 
            // buttonSaveDesc
            // 
            this.buttonSaveDesc.Animated = true;
            this.buttonSaveDesc.AnimationHoverSpeed = 0.07F;
            this.buttonSaveDesc.AnimationSpeed = 0.03F;
            this.buttonSaveDesc.BackColor = System.Drawing.Color.Transparent;
            this.buttonSaveDesc.BaseColor1 = System.Drawing.Color.Blue;
            this.buttonSaveDesc.BaseColor2 = System.Drawing.Color.Navy;
            this.buttonSaveDesc.BorderColor = System.Drawing.Color.Black;
            this.buttonSaveDesc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSaveDesc.FocusedColor = System.Drawing.Color.Empty;
            this.buttonSaveDesc.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveDesc.ForeColor = System.Drawing.Color.White;
            this.buttonSaveDesc.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.buttonSaveDesc.Image = null;
            this.buttonSaveDesc.ImageSize = new System.Drawing.Size(100, 80);
            this.buttonSaveDesc.Location = new System.Drawing.Point(103, 332);
            this.buttonSaveDesc.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveDesc.Name = "buttonSaveDesc";
            this.buttonSaveDesc.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.buttonSaveDesc.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.buttonSaveDesc.OnHoverBorderColor = System.Drawing.Color.Black;
            this.buttonSaveDesc.OnHoverForeColor = System.Drawing.Color.White;
            this.buttonSaveDesc.OnHoverImage = null;
            this.buttonSaveDesc.OnPressedColor = System.Drawing.Color.Black;
            this.buttonSaveDesc.Radius = 5;
            this.buttonSaveDesc.Size = new System.Drawing.Size(318, 74);
            this.buttonSaveDesc.TabIndex = 23;
            this.buttonSaveDesc.Text = "Guardar descripcion";
            // 
            // gbxBorra
            // 
            this.gbxBorra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxBorra.BackColor = System.Drawing.Color.Transparent;
            this.gbxBorra.BaseColor = System.Drawing.Color.White;
            this.gbxBorra.BorderColor = System.Drawing.Color.Gainsboro;
            this.gbxBorra.Controls.Add(this.btnBorra);
            this.gbxBorra.Controls.Add(this.label6);
            this.gbxBorra.Controls.Add(this.nBorra);
            this.gbxBorra.Enabled = false;
            this.gbxBorra.LineColor = System.Drawing.Color.Gainsboro;
            this.gbxBorra.Location = new System.Drawing.Point(573, 13);
            this.gbxBorra.Name = "gbxBorra";
            this.gbxBorra.Size = new System.Drawing.Size(210, 145);
            this.gbxBorra.TabIndex = 160;
            this.gbxBorra.Text = "Borrar";
            this.gbxBorra.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // btnBorra
            // 
            this.btnBorra.AnimationHoverSpeed = 0.07F;
            this.btnBorra.AnimationSpeed = 0.03F;
            this.btnBorra.BaseColor = System.Drawing.Color.Red;
            this.btnBorra.BorderColor = System.Drawing.Color.Black;
            this.btnBorra.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBorra.FocusedColor = System.Drawing.Color.Empty;
            this.btnBorra.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnBorra.ForeColor = System.Drawing.Color.White;
            this.btnBorra.Image = null;
            this.btnBorra.ImageSize = new System.Drawing.Size(52, 52);
            this.btnBorra.Location = new System.Drawing.Point(6, 107);
            this.btnBorra.Name = "btnBorra";
            this.btnBorra.OnHoverBaseColor = System.Drawing.Color.Maroon;
            this.btnBorra.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBorra.OnHoverForeColor = System.Drawing.Color.White;
            this.btnBorra.OnHoverImage = null;
            this.btnBorra.OnPressedColor = System.Drawing.Color.Black;
            this.btnBorra.Size = new System.Drawing.Size(201, 35);
            this.btnBorra.TabIndex = 162;
            this.btnBorra.Text = "Guardar";
            this.btnBorra.Click += new System.EventHandler(this.btnBorra_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label6.Location = new System.Drawing.Point(3, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 13);
            this.label6.TabIndex = 160;
            this.label6.Text = "Cantidad de etiquetas nuevas:";
            // 
            // nBorra
            // 
            this.nBorra.BaseColor = System.Drawing.Color.White;
            this.nBorra.BorderColor = System.Drawing.Color.Silver;
            this.nBorra.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.nBorra.ButtonForeColor = System.Drawing.Color.White;
            this.nBorra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nBorra.ForeColor = System.Drawing.Color.Black;
            this.nBorra.Location = new System.Drawing.Point(6, 63);
            this.nBorra.Maximum = ((long)(2000));
            this.nBorra.Minimum = ((long)(0));
            this.nBorra.Name = "nBorra";
            this.nBorra.Size = new System.Drawing.Size(86, 30);
            this.nBorra.TabIndex = 161;
            this.nBorra.Text = "gunaNumeric1";
            this.nBorra.Value = ((long)(0));
            // 
            // gbxAgrega
            // 
            this.gbxAgrega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxAgrega.BackColor = System.Drawing.Color.Transparent;
            this.gbxAgrega.BaseColor = System.Drawing.Color.White;
            this.gbxAgrega.BorderColor = System.Drawing.Color.Gainsboro;
            this.gbxAgrega.Controls.Add(this.btnAgrega);
            this.gbxAgrega.Controls.Add(this.lblAgrega);
            this.gbxAgrega.Controls.Add(this.nAgrega);
            this.gbxAgrega.Enabled = false;
            this.gbxAgrega.LineColor = System.Drawing.Color.Gainsboro;
            this.gbxAgrega.Location = new System.Drawing.Point(890, 13);
            this.gbxAgrega.Name = "gbxAgrega";
            this.gbxAgrega.Size = new System.Drawing.Size(210, 145);
            this.gbxAgrega.TabIndex = 140;
            this.gbxAgrega.Text = "Agregar";
            this.gbxAgrega.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // btnAgrega
            // 
            this.btnAgrega.AnimationHoverSpeed = 0.07F;
            this.btnAgrega.AnimationSpeed = 0.03F;
            this.btnAgrega.BaseColor = System.Drawing.Color.Blue;
            this.btnAgrega.BorderColor = System.Drawing.Color.Black;
            this.btnAgrega.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAgrega.FocusedColor = System.Drawing.Color.Empty;
            this.btnAgrega.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnAgrega.ForeColor = System.Drawing.Color.White;
            this.btnAgrega.Image = null;
            this.btnAgrega.ImageSize = new System.Drawing.Size(52, 52);
            this.btnAgrega.Location = new System.Drawing.Point(3, 107);
            this.btnAgrega.Name = "btnAgrega";
            this.btnAgrega.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAgrega.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAgrega.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAgrega.OnHoverImage = null;
            this.btnAgrega.OnPressedColor = System.Drawing.Color.Black;
            this.btnAgrega.Size = new System.Drawing.Size(201, 35);
            this.btnAgrega.TabIndex = 163;
            this.btnAgrega.Text = "Guardar";
            this.btnAgrega.Click += new System.EventHandler(this.btnAgrega_Click);
            // 
            // lblAgrega
            // 
            this.lblAgrega.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAgrega.AutoSize = true;
            this.lblAgrega.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblAgrega.Location = new System.Drawing.Point(3, 42);
            this.lblAgrega.Name = "lblAgrega";
            this.lblAgrega.Size = new System.Drawing.Size(151, 13);
            this.lblAgrega.TabIndex = 158;
            this.lblAgrega.Text = "Cantidad de etiquetas nuevas:";
            // 
            // nAgrega
            // 
            this.nAgrega.BaseColor = System.Drawing.Color.White;
            this.nAgrega.BorderColor = System.Drawing.Color.Silver;
            this.nAgrega.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.nAgrega.ButtonForeColor = System.Drawing.Color.White;
            this.nAgrega.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nAgrega.ForeColor = System.Drawing.Color.Black;
            this.nAgrega.Location = new System.Drawing.Point(6, 61);
            this.nAgrega.Maximum = ((long)(2000));
            this.nAgrega.Minimum = ((long)(0));
            this.nAgrega.Name = "nAgrega";
            this.nAgrega.Size = new System.Drawing.Size(86, 30);
            this.nAgrega.TabIndex = 159;
            this.nAgrega.Text = "gunaNumeric1";
            this.nAgrega.Value = ((long)(0));
            // 
            // AddOrDeletePanel
            // 
            this.AddOrDeletePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddOrDeletePanel.Controls.Add(this.gbxAgrega);
            this.AddOrDeletePanel.Controls.Add(this.gbxBorra);
            this.AddOrDeletePanel.Controls.Add(this.tableLayoutPanel1);
            this.AddOrDeletePanel.Location = new System.Drawing.Point(12, 564);
            this.AddOrDeletePanel.Name = "AddOrDeletePanel";
            this.AddOrDeletePanel.Size = new System.Drawing.Size(1157, 177);
            this.AddOrDeletePanel.TabIndex = 162;
            // 
            // tbxLongitud
            // 
            this.tbxLongitud.Location = new System.Drawing.Point(22, 217);
            this.tbxLongitud.Name = "tbxLongitud";
            this.tbxLongitud.Size = new System.Drawing.Size(82, 20);
            this.tbxLongitud.TabIndex = 164;
            // 
            // txbAnchura
            // 
            this.txbAnchura.Location = new System.Drawing.Point(128, 217);
            this.txbAnchura.Name = "txbAnchura";
            this.txbAnchura.Size = new System.Drawing.Size(82, 20);
            this.txbAnchura.TabIndex = 165;
            // 
            // txbAltura
            // 
            this.txbAltura.Location = new System.Drawing.Point(231, 217);
            this.txbAltura.Name = "txbAltura";
            this.txbAltura.Size = new System.Drawing.Size(82, 20);
            this.txbAltura.TabIndex = 166;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(19, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 167;
            this.label2.Text = "Descripcion Individual";
            // 
            // lblLongitud
            // 
            this.lblLongitud.AutoSize = true;
            this.lblLongitud.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblLongitud.Location = new System.Drawing.Point(19, 201);
            this.lblLongitud.Name = "lblLongitud";
            this.lblLongitud.Size = new System.Drawing.Size(65, 13);
            this.lblLongitud.TabIndex = 168;
            this.lblLongitud.Text = "Longitud (in)";
            // 
            // lblAnchura
            // 
            this.lblAnchura.AutoSize = true;
            this.lblAnchura.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblAnchura.Location = new System.Drawing.Point(125, 201);
            this.lblAnchura.Name = "lblAnchura";
            this.lblAnchura.Size = new System.Drawing.Size(64, 13);
            this.lblAnchura.TabIndex = 169;
            this.lblAnchura.Text = "Anchura (in)";
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblAltura.Location = new System.Drawing.Point(228, 201);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(51, 13);
            this.lblAltura.TabIndex = 170;
            this.lblAltura.Text = "Altura (in)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(333, 217);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(115, 20);
            this.textBox1.TabIndex = 171;
            // 
            // lblPesoV
            // 
            this.lblPesoV.AutoSize = true;
            this.lblPesoV.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblPesoV.Location = new System.Drawing.Point(331, 201);
            this.lblPesoV.Name = "lblPesoV";
            this.lblPesoV.Size = new System.Drawing.Size(126, 13);
            this.lblPesoV.TabIndex = 172;
            this.lblPesoV.Text = "Peso Volumetrico (Libras)";
            // 
            // vistaBajaAgregaEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 753);
            this.Controls.Add(this.AddOrDeletePanel);
            this.Controls.Add(this.gunaElipsePanel3);
            this.Controls.Add(this.gunaElipsePanel2);
            this.Controls.Add(this.gunaElipsePanel1);
            this.Name = "vistaBajaAgregaEntrada";
            this.ShowIcon = false;
            this.Text = "Agrega o Elimina Entradas";
            this.Load += new System.EventHandler(this.vistaBajaAgregaEntrada_Load);
            this.gunaElipsePanel2.ResumeLayout(false);
            this.gunaElipsePanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEtiquetas)).EndInit();
            this.gunaElipsePanel1.ResumeLayout(false);
            this.gunaElipsePanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gunaElipsePanel3.ResumeLayout(false);
            this.gunaElipsePanel3.PerformLayout();
            this.gbxBorra.ResumeLayout(false);
            this.gbxBorra.PerformLayout();
            this.gbxAgrega.ResumeLayout(false);
            this.gbxAgrega.PerformLayout();
            this.AddOrDeletePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel2;
        private ADGV.AdvancedDataGridView dtgEtiquetas;
        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI.WinForms.GunaGradientTileButton gunaGradientTileButton1;
        private Guna.UI.WinForms.GunaGradientTileButton btnEntrada;
        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel3;
        private Guna.UI.WinForms.GunaGroupBox gbxBorra;
        private System.Windows.Forms.Label label6;
        private Guna.UI.WinForms.GunaNumeric nBorra;
        private Guna.UI.WinForms.GunaGroupBox gbxAgrega;
        private System.Windows.Forms.Label lblAgrega;
        private Guna.UI.WinForms.GunaNumeric nAgrega;
        private Guna.UI.WinForms.GunaTileButton btnBorra;
        private Guna.UI.WinForms.GunaTileButton btnAgrega;
        private Guna.UI.WinForms.GunaLabel lblEntrada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbTotalEt;
        private System.Windows.Forms.Panel AddOrDeletePanel;
        private System.Windows.Forms.TextBox txbEntiquetaSeleccionada;
        private Guna.UI.WinForms.GunaGradientTileButton buttonSaveDesc;
        private ReaLTaiizor.Controls.MaterialRichTextBox txbDescripcion;
        private System.Windows.Forms.Label lblPesoV;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblAnchura;
        private System.Windows.Forms.Label lblLongitud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbAltura;
        private System.Windows.Forms.TextBox txbAnchura;
        private System.Windows.Forms.TextBox tbxLongitud;
    }
}