namespace mainVentana.VistaRecepcion
{
    partial class frmRecepcion
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNumRecepción = new System.Windows.Forms.Label();
            this.btnImportarExcel = new Guna.UI.WinForms.GunaGradientTileButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvOrdenesEntrada = new Guna.UI.WinForms.GunaDataGridView();
            this.gunaGradientTileButton1 = new Guna.UI.WinForms.GunaGradientTileButton();
            this.btnSalida = new Guna.UI.WinForms.GunaGradientTileButton();
            this.dgvEscaneados = new Guna.UI.WinForms.GunaDataGridView();
            this.gbxDetalles = new Guna.UI.WinForms.GunaGroupBox();
            this.txbTValor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbTPeso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbTPieza = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTEnt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.gbxDocumento = new Guna.UI.WinForms.GunaGroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbxDatosGenerales = new Guna.UI.WinForms.GunaGroupBox();
            this.cmbSucRecibe = new System.Windows.Forms.ComboBox();
            this.cmbSucEnvia = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesEntrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEscaneados)).BeginInit();
            this.gbxDetalles.SuspendLayout();
            this.gbxDocumento.SuspendLayout();
            this.gbxDatosGenerales.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblNumRecepción);
            this.panel2.Controls.Add(this.btnImportarExcel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(947, 50);
            this.panel2.TabIndex = 3;
            // 
            // lblNumRecepción
            // 
            this.lblNumRecepción.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumRecepción.AutoSize = true;
            this.lblNumRecepción.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRecepción.Location = new System.Drawing.Point(736, 13);
            this.lblNumRecepción.Name = "lblNumRecepción";
            this.lblNumRecepción.Size = new System.Drawing.Size(142, 25);
            this.lblNumRecepción.TabIndex = 28;
            this.lblNumRecepción.Text = "numRecepción";
            // 
            // btnImportarExcel
            // 
            this.btnImportarExcel.Animated = true;
            this.btnImportarExcel.AnimationHoverSpeed = 0.07F;
            this.btnImportarExcel.AnimationSpeed = 0.03F;
            this.btnImportarExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnImportarExcel.BaseColor1 = System.Drawing.Color.Lime;
            this.btnImportarExcel.BaseColor2 = System.Drawing.Color.Lime;
            this.btnImportarExcel.BorderColor = System.Drawing.Color.Black;
            this.btnImportarExcel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnImportarExcel.FocusedColor = System.Drawing.Color.Empty;
            this.btnImportarExcel.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnImportarExcel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnImportarExcel.Image = null;
            this.btnImportarExcel.ImageSize = new System.Drawing.Size(100, 80);
            this.btnImportarExcel.Location = new System.Drawing.Point(58, 5);
            this.btnImportarExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportarExcel.Name = "btnImportarExcel";
            this.btnImportarExcel.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnImportarExcel.OnHoverBaseColor2 = System.Drawing.Color.Green;
            this.btnImportarExcel.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnImportarExcel.OnHoverForeColor = System.Drawing.Color.White;
            this.btnImportarExcel.OnHoverImage = null;
            this.btnImportarExcel.OnPressedColor = System.Drawing.Color.Black;
            this.btnImportarExcel.Radius = 5;
            this.btnImportarExcel.Size = new System.Drawing.Size(346, 38);
            this.btnImportarExcel.TabIndex = 26;
            this.btnImportarExcel.Text = "Importar De Excel";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvOrdenesEntrada);
            this.panel1.Controls.Add(this.gunaGradientTileButton1);
            this.panel1.Controls.Add(this.btnSalida);
            this.panel1.Controls.Add(this.dgvEscaneados);
            this.panel1.Controls.Add(this.gbxDetalles);
            this.panel1.Controls.Add(this.gbxDocumento);
            this.panel1.Controls.Add(this.gbxDatosGenerales);
            this.panel1.Location = new System.Drawing.Point(40, 68);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 477);
            this.panel1.TabIndex = 2;
            // 
            // dgvOrdenesEntrada
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvOrdenesEntrada.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrdenesEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrdenesEntrada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdenesEntrada.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdenesEntrada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrdenesEntrada.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrdenesEntrada.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenesEntrada.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrdenesEntrada.ColumnHeadersHeight = 4;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdenesEntrada.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrdenesEntrada.EnableHeadersVisualStyles = false;
            this.dgvOrdenesEntrada.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvOrdenesEntrada.Location = new System.Drawing.Point(18, 181);
            this.dgvOrdenesEntrada.Margin = new System.Windows.Forms.Padding(2);
            this.dgvOrdenesEntrada.Name = "dgvOrdenesEntrada";
            this.dgvOrdenesEntrada.RowHeadersVisible = false;
            this.dgvOrdenesEntrada.RowHeadersWidth = 51;
            this.dgvOrdenesEntrada.RowTemplate.Height = 24;
            this.dgvOrdenesEntrada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenesEntrada.Size = new System.Drawing.Size(347, 84);
            this.dgvOrdenesEntrada.TabIndex = 25;
            this.dgvOrdenesEntrada.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgvOrdenesEntrada.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvOrdenesEntrada.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvOrdenesEntrada.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvOrdenesEntrada.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvOrdenesEntrada.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvOrdenesEntrada.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvOrdenesEntrada.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvOrdenesEntrada.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvOrdenesEntrada.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvOrdenesEntrada.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvOrdenesEntrada.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvOrdenesEntrada.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvOrdenesEntrada.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvOrdenesEntrada.ThemeStyle.ReadOnly = false;
            this.dgvOrdenesEntrada.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvOrdenesEntrada.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrdenesEntrada.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvOrdenesEntrada.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvOrdenesEntrada.ThemeStyle.RowsStyle.Height = 24;
            this.dgvOrdenesEntrada.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvOrdenesEntrada.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // gunaGradientTileButton1
            // 
            this.gunaGradientTileButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGradientTileButton1.Animated = true;
            this.gunaGradientTileButton1.AnimationHoverSpeed = 0.07F;
            this.gunaGradientTileButton1.AnimationSpeed = 0.03F;
            this.gunaGradientTileButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradientTileButton1.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gunaGradientTileButton1.BaseColor2 = System.Drawing.Color.Navy;
            this.gunaGradientTileButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientTileButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientTileButton1.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGradientTileButton1.ForeColor = System.Drawing.Color.White;
            this.gunaGradientTileButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gunaGradientTileButton1.Image = null;
            this.gunaGradientTileButton1.ImageSize = new System.Drawing.Size(100, 80);
            this.gunaGradientTileButton1.Location = new System.Drawing.Point(710, 181);
            this.gunaGradientTileButton1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaGradientTileButton1.Name = "gunaGradientTileButton1";
            this.gunaGradientTileButton1.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.gunaGradientTileButton1.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.gunaGradientTileButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientTileButton1.OnHoverImage = null;
            this.gunaGradientTileButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton1.Radius = 5;
            this.gunaGradientTileButton1.Size = new System.Drawing.Size(130, 84);
            this.gunaGradientTileButton1.TabIndex = 24;
            this.gunaGradientTileButton1.Text = "Escanear";
            // 
            // btnSalida
            // 
            this.btnSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalida.Animated = true;
            this.btnSalida.AnimationHoverSpeed = 0.07F;
            this.btnSalida.AnimationSpeed = 0.03F;
            this.btnSalida.BackColor = System.Drawing.Color.Transparent;
            this.btnSalida.BaseColor1 = System.Drawing.Color.Turquoise;
            this.btnSalida.BaseColor2 = System.Drawing.Color.MediumTurquoise;
            this.btnSalida.BorderColor = System.Drawing.Color.Black;
            this.btnSalida.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSalida.FocusedColor = System.Drawing.Color.Empty;
            this.btnSalida.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalida.ForeColor = System.Drawing.Color.White;
            this.btnSalida.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnSalida.Image = null;
            this.btnSalida.ImageSize = new System.Drawing.Size(100, 80);
            this.btnSalida.Location = new System.Drawing.Point(379, 181);
            this.btnSalida.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnSalida.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnSalida.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSalida.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSalida.OnHoverImage = null;
            this.btnSalida.OnPressedColor = System.Drawing.Color.Black;
            this.btnSalida.Radius = 5;
            this.btnSalida.Size = new System.Drawing.Size(311, 84);
            this.btnSalida.TabIndex = 23;
            this.btnSalida.Text = "Ordenes de Salida";
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // dgvEscaneados
            // 
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
            this.dgvEscaneados.ColumnHeadersHeight = 4;
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
            this.dgvEscaneados.Location = new System.Drawing.Point(19, 280);
            this.dgvEscaneados.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEscaneados.Name = "dgvEscaneados";
            this.dgvEscaneados.RowHeadersVisible = false;
            this.dgvEscaneados.RowHeadersWidth = 51;
            this.dgvEscaneados.RowTemplate.Height = 24;
            this.dgvEscaneados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEscaneados.Size = new System.Drawing.Size(823, 181);
            this.dgvEscaneados.TabIndex = 3;
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
            this.dgvEscaneados.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvEscaneados.ThemeStyle.ReadOnly = false;
            this.dgvEscaneados.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEscaneados.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEscaneados.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvEscaneados.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvEscaneados.ThemeStyle.RowsStyle.Height = 24;
            this.dgvEscaneados.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEscaneados.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // gbxDetalles
            // 
            this.gbxDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxDetalles.BackColor = System.Drawing.Color.Transparent;
            this.gbxDetalles.BaseColor = System.Drawing.Color.White;
            this.gbxDetalles.BorderColor = System.Drawing.Color.Gainsboro;
            this.gbxDetalles.Controls.Add(this.txbTValor);
            this.gbxDetalles.Controls.Add(this.label3);
            this.gbxDetalles.Controls.Add(this.txbTPeso);
            this.gbxDetalles.Controls.Add(this.label2);
            this.gbxDetalles.Controls.Add(this.txbTPieza);
            this.gbxDetalles.Controls.Add(this.label1);
            this.gbxDetalles.Controls.Add(this.txbTEnt);
            this.gbxDetalles.Controls.Add(this.label13);
            this.gbxDetalles.ForeColor = System.Drawing.Color.White;
            this.gbxDetalles.LineColor = System.Drawing.Color.Blue;
            this.gbxDetalles.Location = new System.Drawing.Point(379, 2);
            this.gbxDetalles.Margin = new System.Windows.Forms.Padding(2);
            this.gbxDetalles.Name = "gbxDetalles";
            this.gbxDetalles.Radius = 10;
            this.gbxDetalles.Size = new System.Drawing.Size(311, 167);
            this.gbxDetalles.TabIndex = 2;
            this.gbxDetalles.Text = "Totales";
            this.gbxDetalles.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // txbTValor
            // 
            this.txbTValor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbTValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTValor.Location = new System.Drawing.Point(116, 131);
            this.txbTValor.MaxLength = 100;
            this.txbTValor.Name = "txbTValor";
            this.txbTValor.Size = new System.Drawing.Size(184, 26);
            this.txbTValor.TabIndex = 125;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 22);
            this.label3.TabIndex = 126;
            this.label3.Text = "Valor";
            // 
            // txbTPeso
            // 
            this.txbTPeso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbTPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTPeso.Location = new System.Drawing.Point(116, 103);
            this.txbTPeso.MaxLength = 100;
            this.txbTPeso.Name = "txbTPeso";
            this.txbTPeso.Size = new System.Drawing.Size(184, 26);
            this.txbTPeso.TabIndex = 123;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 22);
            this.label2.TabIndex = 124;
            this.label2.Text = "Peso";
            // 
            // txbTPieza
            // 
            this.txbTPieza.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbTPieza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTPieza.Location = new System.Drawing.Point(116, 72);
            this.txbTPieza.MaxLength = 100;
            this.txbTPieza.Name = "txbTPieza";
            this.txbTPieza.Size = new System.Drawing.Size(184, 26);
            this.txbTPieza.TabIndex = 121;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 22);
            this.label1.TabIndex = 122;
            this.label1.Text = "Piezas:";
            // 
            // txbTEnt
            // 
            this.txbTEnt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbTEnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTEnt.Location = new System.Drawing.Point(116, 41);
            this.txbTEnt.MaxLength = 100;
            this.txbTEnt.Name = "txbTEnt";
            this.txbTEnt.Size = new System.Drawing.Size(184, 26);
            this.txbTEnt.TabIndex = 119;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(10, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 22);
            this.label13.TabIndex = 120;
            this.label13.Text = "Entradas";
            // 
            // gbxDocumento
            // 
            this.gbxDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxDocumento.BackColor = System.Drawing.Color.Transparent;
            this.gbxDocumento.BaseColor = System.Drawing.Color.White;
            this.gbxDocumento.BorderColor = System.Drawing.Color.Gainsboro;
            this.gbxDocumento.Controls.Add(this.label8);
            this.gbxDocumento.Controls.Add(this.label7);
            this.gbxDocumento.Controls.Add(this.label6);
            this.gbxDocumento.Controls.Add(this.label5);
            this.gbxDocumento.Controls.Add(this.label4);
            this.gbxDocumento.ForeColor = System.Drawing.Color.White;
            this.gbxDocumento.LineColor = System.Drawing.Color.Blue;
            this.gbxDocumento.Location = new System.Drawing.Point(709, 2);
            this.gbxDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.gbxDocumento.Name = "gbxDocumento";
            this.gbxDocumento.Radius = 10;
            this.gbxDocumento.Size = new System.Drawing.Size(132, 167);
            this.gbxDocumento.TabIndex = 1;
            this.gbxDocumento.Text = "Documento";
            this.gbxDocumento.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(3, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 22);
            this.label8.TabIndex = 131;
            this.label8.Text = "xxx";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(3, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 22);
            this.label7.TabIndex = 130;
            this.label7.Text = "Fecha";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 22);
            this.label6.TabIndex = 129;
            this.label6.Text = "xxxx";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 22);
            this.label5.TabIndex = 128;
            this.label5.Text = "No. Documento";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 22);
            this.label4.TabIndex = 127;
            this.label4.Text = "Alta";
            // 
            // gbxDatosGenerales
            // 
            this.gbxDatosGenerales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxDatosGenerales.BackColor = System.Drawing.Color.Transparent;
            this.gbxDatosGenerales.BaseColor = System.Drawing.Color.White;
            this.gbxDatosGenerales.BorderColor = System.Drawing.Color.Blue;
            this.gbxDatosGenerales.Controls.Add(this.cmbSucRecibe);
            this.gbxDatosGenerales.Controls.Add(this.cmbSucEnvia);
            this.gbxDatosGenerales.Controls.Add(this.label9);
            this.gbxDatosGenerales.Controls.Add(this.label10);
            this.gbxDatosGenerales.ForeColor = System.Drawing.Color.White;
            this.gbxDatosGenerales.LineColor = System.Drawing.Color.Blue;
            this.gbxDatosGenerales.Location = new System.Drawing.Point(18, 2);
            this.gbxDatosGenerales.Margin = new System.Windows.Forms.Padding(2);
            this.gbxDatosGenerales.Name = "gbxDatosGenerales";
            this.gbxDatosGenerales.Radius = 10;
            this.gbxDatosGenerales.Size = new System.Drawing.Size(346, 167);
            this.gbxDatosGenerales.TabIndex = 0;
            this.gbxDatosGenerales.Text = "Datos generales";
            this.gbxDatosGenerales.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // cmbSucRecibe
            // 
            this.cmbSucRecibe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbSucRecibe.AutoCompleteCustomSource.AddRange(new string[] {
            "SD",
            "TJ",
            "CSL"});
            this.cmbSucRecibe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSucRecibe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSucRecibe.FormattingEnabled = true;
            this.cmbSucRecibe.Items.AddRange(new object[] {
            "SD",
            "TJ",
            "CSL"});
            this.cmbSucRecibe.Location = new System.Drawing.Point(6, 124);
            this.cmbSucRecibe.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSucRecibe.Name = "cmbSucRecibe";
            this.cmbSucRecibe.Size = new System.Drawing.Size(327, 28);
            this.cmbSucRecibe.TabIndex = 106;
            // 
            // cmbSucEnvia
            // 
            this.cmbSucEnvia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbSucEnvia.AutoCompleteCustomSource.AddRange(new string[] {
            "SD",
            "TJ",
            "CSL"});
            this.cmbSucEnvia.DisplayMember = "SD";
            this.cmbSucEnvia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSucEnvia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSucEnvia.FormattingEnabled = true;
            this.cmbSucEnvia.Items.AddRange(new object[] {
            "SD",
            "TJ",
            "CSL"});
            this.cmbSucEnvia.Location = new System.Drawing.Point(6, 64);
            this.cmbSucEnvia.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSucEnvia.Name = "cmbSucEnvia";
            this.cmbSucEnvia.Size = new System.Drawing.Size(327, 28);
            this.cmbSucEnvia.TabIndex = 105;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(4, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 24);
            this.label9.TabIndex = 104;
            this.label9.Text = "Sucursal Que Envia:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(4, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(253, 20);
            this.label10.TabIndex = 107;
            this.label10.Text = "Sucursal Que Recibe:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(53, 547);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 25);
            this.label11.TabIndex = 27;
            this.label11.Text = "Recepción";
            // 
            // frmRecepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 574);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmRecepcion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recepcion";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesEntrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEscaneados)).EndInit();
            this.gbxDetalles.ResumeLayout(false);
            this.gbxDetalles.PerformLayout();
            this.gbxDocumento.ResumeLayout(false);
            this.gbxDatosGenerales.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaGradientTileButton btnImportarExcel;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaDataGridView dgvOrdenesEntrada;
        private Guna.UI.WinForms.GunaGradientTileButton gunaGradientTileButton1;
        private Guna.UI.WinForms.GunaGradientTileButton btnSalida;
        private Guna.UI.WinForms.GunaDataGridView dgvEscaneados;
        private Guna.UI.WinForms.GunaGroupBox gbxDetalles;
        public System.Windows.Forms.TextBox txbTValor;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txbTPeso;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txbTPieza;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txbTEnt;
        private System.Windows.Forms.Label label13;
        private Guna.UI.WinForms.GunaGroupBox gbxDocumento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaGroupBox gbxDatosGenerales;
        private System.Windows.Forms.ComboBox cmbSucRecibe;
        private System.Windows.Forms.ComboBox cmbSucEnvia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblNumRecepción;
    }
}