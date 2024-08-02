namespace mainVentana.VistaEntrada.ReportesEntradas
{
    partial class frmReporteEntradas
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
            this.dgvData = new Guna.UI.WinForms.GunaDataGridView();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.dtFecha1 = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFecha2 = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvData.Location = new System.Drawing.Point(52, 178);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.DividerHeight = 1;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.RowTemplate.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(911, 359);
            this.dgvData.TabIndex = 13;
            this.dgvData.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgvData.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvData.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvData.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvData.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvData.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvData.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvData.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvData.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvData.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvData.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvData.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvData.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvData.ThemeStyle.ReadOnly = true;
            this.dgvData.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvData.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvData.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvData.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvData.ThemeStyle.RowsStyle.Height = 25;
            this.dgvData.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvData.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // cmbUsers
            // 
            this.cmbUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Items.AddRange(new object[] {
            "Daniel Olivares"});
            this.cmbUsers.Location = new System.Drawing.Point(659, 60);
            this.cmbUsers.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(304, 28);
            this.cmbUsers.TabIndex = 106;
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.AutoScroll = true;
            this.panel11.AutoScrollMargin = new System.Drawing.Size(1, 1);
            this.panel11.AutoScrollMinSize = new System.Drawing.Size(262, 0);
            this.panel11.Controls.Add(this.dtFecha1);
            this.panel11.Controls.Add(this.label1);
            this.panel11.Controls.Add(this.dtFecha2);
            this.panel11.Controls.Add(this.label2);
            this.panel11.Location = new System.Drawing.Point(52, 60);
            this.panel11.MinimumSize = new System.Drawing.Size(270, 40);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(299, 40);
            this.panel11.TabIndex = 107;
            // 
            // dtFecha1
            // 
            this.dtFecha1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFecha1.BaseColor = System.Drawing.Color.White;
            this.dtFecha1.BorderColor = System.Drawing.Color.Silver;
            this.dtFecha1.CustomFormat = null;
            this.dtFecha1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtFecha1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha1.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.dtFecha1.ForeColor = System.Drawing.Color.Black;
            this.dtFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha1.Location = new System.Drawing.Point(33, 3);
            this.dtFecha1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtFecha1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtFecha1.Name = "dtFecha1";
            this.dtFecha1.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtFecha1.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha1.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha1.OnPressedColor = System.Drawing.Color.Black;
            this.dtFecha1.Size = new System.Drawing.Size(106, 30);
            this.dtFecha1.TabIndex = 169;
            this.dtFecha1.Text = "3/10/2023";
            this.dtFecha1.Value = new System.DateTime(2023, 3, 10, 11, 29, 29, 92);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(139, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 172;
            this.label1.Text = "A:";
            // 
            // dtFecha2
            // 
            this.dtFecha2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFecha2.BaseColor = System.Drawing.Color.White;
            this.dtFecha2.BorderColor = System.Drawing.Color.Silver;
            this.dtFecha2.CustomFormat = null;
            this.dtFecha2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtFecha2.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha2.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.dtFecha2.ForeColor = System.Drawing.Color.Black;
            this.dtFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha2.Location = new System.Drawing.Point(159, 3);
            this.dtFecha2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtFecha2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtFecha2.Name = "dtFecha2";
            this.dtFecha2.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtFecha2.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha2.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha2.OnPressedColor = System.Drawing.Color.Black;
            this.dtFecha2.Size = new System.Drawing.Size(106, 30);
            this.dtFecha2.TabIndex = 170;
            this.dtFecha2.Text = "3/10/2023";
            this.dtFecha2.Value = new System.DateTime(2023, 3, 10, 11, 29, 29, 92);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 171;
            this.label2.Text = "DE:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Navy;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Blue;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
            this.btnBuscar.IconColor = System.Drawing.Color.Blue;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 35;
            this.btnBuscar.Location = new System.Drawing.Point(882, 96);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(81, 67);
            this.btnBuscar.TabIndex = 153;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmReporteEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 592);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.dgvData);
            this.MaximumSize = new System.Drawing.Size(1043, 631);
            this.MinimumSize = new System.Drawing.Size(1043, 631);
            this.Name = "frmReporteEntradas";
            this.ShowIcon = false;
            this.Text = "Reporte entradas";
            this.Load += new System.EventHandler(this.frmReporteEntradas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Guna.UI.WinForms.GunaDataGridView dgvData;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Panel panel11;
        private Guna.UI.WinForms.GunaDateTimePicker dtFecha1;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaDateTimePicker dtFecha2;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnBuscar;
    }
}