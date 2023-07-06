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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSalidas = new Guna.UI.WinForms.GunaDataGridView();
            this.iconButton10 = new FontAwesome.Sharp.IconButton();
            this.txbBusqueda = new Guna.UI.WinForms.GunaTextBox();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.SucCombo = new System.Windows.Forms.GroupBox();
            this.rCa = new System.Windows.Forms.RadioButton();
            this.rTj = new System.Windows.Forms.RadioButton();
            this.rSd = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtFecha2 = new Guna.UI.WinForms.GunaDateTimePicker();
            this.dtFecha1 = new Guna.UI.WinForms.GunaDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidas)).BeginInit();
            this.SucCombo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSalidas
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvSalidas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSalidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalidas.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalidas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalidas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSalidas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSalidas.ColumnHeadersHeight = 30;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalidas.DefaultCellStyle = dataGridViewCellStyle9;
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
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Enabled = false;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImprimir.IconChar = FontAwesome.Sharp.IconChar.Newspaper;
            this.btnImprimir.IconColor = System.Drawing.Color.Black;
            this.btnImprimir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(680, 387);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(253, 51);
            this.btnImprimir.TabIndex = 36;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Visible = false;
            // 
            // SucCombo
            // 
            this.SucCombo.Controls.Add(this.rCa);
            this.SucCombo.Controls.Add(this.rTj);
            this.SucCombo.Controls.Add(this.rSd);
            this.SucCombo.Location = new System.Drawing.Point(22, 17);
            this.SucCombo.Name = "SucCombo";
            this.SucCombo.Size = new System.Drawing.Size(237, 48);
            this.SucCombo.TabIndex = 151;
            this.SucCombo.TabStop = false;
            this.SucCombo.Text = "Sucursal";
            // 
            // rCa
            // 
            this.rCa.AutoSize = true;
            this.rCa.Location = new System.Drawing.Point(153, 19);
            this.rCa.Name = "rCa";
            this.rCa.Size = new System.Drawing.Size(63, 17);
            this.rCa.TabIndex = 2;
            this.rCa.Text = "Cabo S.";
            this.rCa.UseVisualStyleBackColor = true;
            // 
            // rTj
            // 
            this.rTj.AutoSize = true;
            this.rTj.Location = new System.Drawing.Point(87, 19);
            this.rTj.Name = "rTj";
            this.rTj.Size = new System.Drawing.Size(60, 17);
            this.rTj.TabIndex = 1;
            this.rTj.Text = "Tijuana";
            this.rTj.UseVisualStyleBackColor = true;
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
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label6.Location = new System.Drawing.Point(537, 21);
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
            this.label7.Location = new System.Drawing.Point(278, 21);
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
            this.dtFecha2.Location = new System.Drawing.Point(560, 23);
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
            this.dtFecha1.Location = new System.Drawing.Point(309, 23);
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
            // frmRepSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtFecha2);
            this.Controls.Add(this.dtFecha1);
            this.Controls.Add(this.SucCombo);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.iconButton10);
            this.Controls.Add(this.txbBusqueda);
            this.Controls.Add(this.dgvSalidas);
            this.Name = "frmRepSalidas";
            this.ShowIcon = false;
            this.Text = "Reporte de Salidas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidas)).EndInit();
            this.SucCombo.ResumeLayout(false);
            this.SucCombo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaDataGridView dgvSalidas;
        private FontAwesome.Sharp.IconButton iconButton10;
        public Guna.UI.WinForms.GunaTextBox txbBusqueda;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private System.Windows.Forms.GroupBox SucCombo;
        private System.Windows.Forms.RadioButton rCa;
        private System.Windows.Forms.RadioButton rTj;
        private System.Windows.Forms.RadioButton rSd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Guna.UI.WinForms.GunaDateTimePicker dtFecha2;
        private Guna.UI.WinForms.GunaDateTimePicker dtFecha1;
    }
}