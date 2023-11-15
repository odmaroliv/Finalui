namespace mainVentana.Reportes.Salidas
{
    partial class frmRepSalidas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSalidas = new Guna.UI.WinForms.GunaDataGridView();
            this.iconButton10 = new FontAwesome.Sharp.IconButton();
            this.txbBusqueda = new Guna.UI.WinForms.GunaTextBox();
            this.btnToExcel = new FontAwesome.Sharp.IconButton();
            this.SucCombo = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtFecha2 = new Guna.UI.WinForms.GunaDateTimePicker();
            this.dtFecha1 = new Guna.UI.WinForms.GunaDateTimePicker();
            this.swTipo = new ReaLTaiizor.Controls.MaterialSwitch();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.loadControl1 = new Ventana1.LoadControl.loadControl();
            this.cmbSucEntrada = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSalidas
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvSalidas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSalidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalidas.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalidas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalidas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSalidas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSalidas.ColumnHeadersHeight = 30;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalidas.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvSalidas.EnableHeadersVisualStyles = false;
            this.dgvSalidas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSalidas.Location = new System.Drawing.Point(22, 86);
            this.dgvSalidas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSalidas.Name = "dgvSalidas";
            this.dgvSalidas.RowHeadersVisible = false;
            this.dgvSalidas.RowHeadersWidth = 51;
            this.dgvSalidas.RowTemplate.Height = 30;
            this.dgvSalidas.RowTemplate.ReadOnly = true;
            this.dgvSalidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalidas.Size = new System.Drawing.Size(911, 284);
            this.dgvSalidas.TabIndex = 33;
            this.dgvSalidas.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgvSalidas.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSalidas.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSalidas.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvSalidas.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSalidas.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSalidas.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSalidas.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSalidas.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvSalidas.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSalidas.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvSalidas.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSalidas.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvSalidas.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvSalidas.ThemeStyle.ReadOnly = false;
            this.dgvSalidas.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSalidas.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSalidas.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvSalidas.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSalidas.ThemeStyle.RowsStyle.Height = 30;
            this.dgvSalidas.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSalidas.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // iconButton10
            // 
            this.iconButton10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton10.BackColor = System.Drawing.Color.White;
            this.iconButton10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton10.FlatAppearance.BorderSize = 0;
            this.iconButton10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.iconButton10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.iconButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton10.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.iconButton10.ForeColor = System.Drawing.Color.Transparent;
            this.iconButton10.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconButton10.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.iconButton10.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton10.IconSize = 20;
            this.iconButton10.Location = new System.Drawing.Point(898, 17);
            this.iconButton10.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton10.Name = "iconButton10";
            this.iconButton10.Size = new System.Drawing.Size(29, 36);
            this.iconButton10.TabIndex = 35;
            this.iconButton10.UseVisualStyleBackColor = false;
            this.iconButton10.Click += new System.EventHandler(this.iconButton10_Click);
            // 
            // txbBusqueda
            // 
            this.txbBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.txbBusqueda.BaseColor = System.Drawing.Color.White;
            this.txbBusqueda.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(238)))), ((int)(((byte)(254)))));
            this.txbBusqueda.BorderSize = 1;
            this.txbBusqueda.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbBusqueda.FocusedBaseColor = System.Drawing.Color.White;
            this.txbBusqueda.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.txbBusqueda.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txbBusqueda.Font = new System.Drawing.Font("Trebuchet MS", 18F);
            this.txbBusqueda.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txbBusqueda.Location = new System.Drawing.Point(783, 11);
            this.txbBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.txbBusqueda.Name = "txbBusqueda";
            this.txbBusqueda.PasswordChar = '\0';
            this.txbBusqueda.Radius = 10;
            this.txbBusqueda.Size = new System.Drawing.Size(150, 54);
            this.txbBusqueda.TabIndex = 34;
            this.txbBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gunaTextBox2_KeyDown);
            // 
            // btnToExcel
            // 
            this.btnToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToExcel.FlatAppearance.BorderSize = 0;
            this.btnToExcel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnToExcel.IconChar = FontAwesome.Sharp.IconChar.Newspaper;
            this.btnToExcel.IconColor = System.Drawing.Color.Black;
            this.btnToExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnToExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnToExcel.Location = new System.Drawing.Point(775, 387);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(158, 51);
            this.btnToExcel.TabIndex = 36;
            this.btnToExcel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // SucCombo
            // 
            this.SucCombo.Location = new System.Drawing.Point(22, 29);
            this.SucCombo.Name = "SucCombo";
            this.SucCombo.Size = new System.Drawing.Size(237, 48);
            this.SucCombo.TabIndex = 151;
            this.SucCombo.TabStop = false;
            this.SucCombo.Text = "Sucursal";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label6.Location = new System.Drawing.Point(537, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 179;
            this.label6.Text = "A:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label7.Location = new System.Drawing.Point(278, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 178;
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
            this.dtFecha2.Location = new System.Drawing.Point(560, 35);
            this.dtFecha2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtFecha2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtFecha2.Name = "dtFecha2";
            this.dtFecha2.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtFecha2.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha2.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha2.OnPressedColor = System.Drawing.Color.Black;
            this.dtFecha2.Size = new System.Drawing.Size(196, 30);
            this.dtFecha2.TabIndex = 177;
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
            this.dtFecha1.Location = new System.Drawing.Point(309, 35);
            this.dtFecha1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtFecha1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtFecha1.Name = "dtFecha1";
            this.dtFecha1.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtFecha1.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha1.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha1.OnPressedColor = System.Drawing.Color.Black;
            this.dtFecha1.Size = new System.Drawing.Size(203, 30);
            this.dtFecha1.TabIndex = 176;
            this.dtFecha1.Text = "viernes, marzo 10, 2023";
            this.dtFecha1.Value = new System.DateTime(2023, 3, 10, 11, 29, 29, 92);
            // 
            // swTipo
            // 
            this.swTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.swTipo.AutoSize = true;
            this.swTipo.Depth = 0;
            this.swTipo.Location = new System.Drawing.Point(23, 387);
            this.swTipo.Margin = new System.Windows.Forms.Padding(0);
            this.swTipo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swTipo.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.swTipo.Name = "swTipo";
            this.swTipo.Ripple = true;
            this.swTipo.Size = new System.Drawing.Size(308, 37);
            this.swTipo.TabIndex = 196;
            this.swTipo.Text = "Salidas Totales/Entradas en Salida";
            this.swTipo.UseAccentColor = false;
            this.swTipo.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Coins;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton1.Location = new System.Drawing.Point(584, 387);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(172, 51);
            this.iconButton1.TabIndex = 197;
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // loadControl1
            // 
            this.loadControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadControl1.Location = new System.Drawing.Point(507, 398);
            this.loadControl1.Margin = new System.Windows.Forms.Padding(2);
            this.loadControl1.Name = "loadControl1";
            this.loadControl1.Size = new System.Drawing.Size(72, 40);
            this.loadControl1.TabIndex = 198;
            this.loadControl1.Visible = false;
            // 
            // cmbSucEntrada
            // 
            this.cmbSucEntrada.AutoCompleteCustomSource.AddRange(new string[] {
            "SD",
            "TJ",
            "CSL"});
            this.cmbSucEntrada.DisplayMember = "SD";
            this.cmbSucEntrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSucEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSucEntrada.FormattingEnabled = true;
            this.cmbSucEntrada.Items.AddRange(new object[] {
            "SD",
            "TJ",
            "CSL"});
            this.cmbSucEntrada.Location = new System.Drawing.Point(27, 44);
            this.cmbSucEntrada.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSucEntrada.Name = "cmbSucEntrada";
            this.cmbSucEntrada.Size = new System.Drawing.Size(227, 28);
            this.cmbSucEntrada.TabIndex = 199;
            this.cmbSucEntrada.SelectedIndexChanged += new System.EventHandler(this.cmbSucEntrada_SelectedIndexChanged);
            // 
            // frmRepSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 450);
            this.Controls.Add(this.cmbSucEntrada);
            this.Controls.Add(this.loadControl1);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.swTipo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtFecha2);
            this.Controls.Add(this.dtFecha1);
            this.Controls.Add(this.SucCombo);
            this.Controls.Add(this.btnToExcel);
            this.Controls.Add(this.iconButton10);
            this.Controls.Add(this.txbBusqueda);
            this.Controls.Add(this.dgvSalidas);
            this.Name = "frmRepSalidas";
            this.ShowIcon = false;
            this.Text = "Reporte de Salidas";
            this.Load += new System.EventHandler(this.frmRepSalidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaDataGridView dgvSalidas;
        private FontAwesome.Sharp.IconButton iconButton10;
        public Guna.UI.WinForms.GunaTextBox txbBusqueda;
        private FontAwesome.Sharp.IconButton btnToExcel;
        private System.Windows.Forms.GroupBox SucCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Guna.UI.WinForms.GunaDateTimePicker dtFecha2;
        private Guna.UI.WinForms.GunaDateTimePicker dtFecha1;
        private ReaLTaiizor.Controls.MaterialSwitch swTipo;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Ventana1.LoadControl.loadControl loadControl1;
        private System.Windows.Forms.ComboBox cmbSucEntrada;
    }
}