namespace mainVentana.Reportes.Clientes
{
    partial class frmRepClientesActivos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cord = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAlta = new Guna.UI.WinForms.GunaGradientTileButton();
            this.dgvRep = new Guna.UI.WinForms.GunaDataGridView();
            this.panel11 = new System.Windows.Forms.Panel();
            this.dtFecha1 = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFecha2 = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRep)).BeginInit();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // cord
            // 
            this.cord.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cord.FormattingEnabled = true;
            this.cord.Items.AddRange(new object[] {
            "Daniel Olivares"});
            this.cord.Location = new System.Drawing.Point(96, 11);
            this.cord.Margin = new System.Windows.Forms.Padding(2);
            this.cord.Name = "cord";
            this.cord.Size = new System.Drawing.Size(235, 28);
            this.cord.TabIndex = 110;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 20);
            this.label15.TabIndex = 111;
            this.label15.Text = "Coordinador:";
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
            this.btnAlta.Location = new System.Drawing.Point(953, 12);
            this.btnAlta.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnAlta.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnAlta.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAlta.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAlta.OnHoverImage = null;
            this.btnAlta.OnPressedColor = System.Drawing.Color.Black;
            this.btnAlta.Radius = 5;
            this.btnAlta.Size = new System.Drawing.Size(229, 59);
            this.btnAlta.TabIndex = 179;
            this.btnAlta.Text = "Buscar";
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // dgvRep
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvRep.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRep.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRep.BackgroundColor = System.Drawing.Color.White;
            this.dgvRep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRep.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRep.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRep.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRep.ColumnHeadersHeight = 30;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRep.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRep.EnableHeadersVisualStyles = false;
            this.dgvRep.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRep.Location = new System.Drawing.Point(21, 97);
            this.dgvRep.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRep.Name = "dgvRep";
            this.dgvRep.RowHeadersVisible = false;
            this.dgvRep.RowHeadersWidth = 51;
            this.dgvRep.RowTemplate.Height = 30;
            this.dgvRep.RowTemplate.ReadOnly = true;
            this.dgvRep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRep.Size = new System.Drawing.Size(1161, 400);
            this.dgvRep.TabIndex = 178;
            this.dgvRep.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgvRep.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRep.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvRep.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRep.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvRep.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvRep.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRep.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRep.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvRep.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRep.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvRep.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRep.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvRep.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvRep.ThemeStyle.ReadOnly = false;
            this.dgvRep.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRep.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRep.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvRep.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvRep.ThemeStyle.RowsStyle.Height = 30;
            this.dgvRep.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRep.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // panel11
            // 
            this.panel11.AutoScroll = true;
            this.panel11.AutoScrollMargin = new System.Drawing.Size(1, 1);
            this.panel11.AutoScrollMinSize = new System.Drawing.Size(262, 0);
            this.panel11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel11.Controls.Add(this.dtFecha1);
            this.panel11.Controls.Add(this.label1);
            this.panel11.Controls.Add(this.dtFecha2);
            this.panel11.Controls.Add(this.cord);
            this.panel11.Controls.Add(this.label2);
            this.panel11.Controls.Add(this.label15);
            this.panel11.Location = new System.Drawing.Point(21, 12);
            this.panel11.MinimumSize = new System.Drawing.Size(270, 40);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(835, 59);
            this.panel11.TabIndex = 180;
            // 
            // dtFecha1
            // 
            this.dtFecha1.BaseColor = System.Drawing.Color.White;
            this.dtFecha1.BorderColor = System.Drawing.Color.Silver;
            this.dtFecha1.CustomFormat = null;
            this.dtFecha1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtFecha1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha1.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.dtFecha1.ForeColor = System.Drawing.Color.Black;
            this.dtFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha1.Location = new System.Drawing.Point(426, 11);
            this.dtFecha1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtFecha1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtFecha1.Name = "dtFecha1";
            this.dtFecha1.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtFecha1.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha1.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha1.OnPressedColor = System.Drawing.Color.Black;
            this.dtFecha1.Size = new System.Drawing.Size(165, 30);
            this.dtFecha1.TabIndex = 169;
            this.dtFecha1.Text = "3/10/2023";
            this.dtFecha1.Value = new System.DateTime(2023, 3, 10, 11, 29, 29, 92);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(623, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 172;
            this.label1.Text = "A:";
            // 
            // dtFecha2
            // 
            this.dtFecha2.BaseColor = System.Drawing.Color.White;
            this.dtFecha2.BorderColor = System.Drawing.Color.Silver;
            this.dtFecha2.CustomFormat = null;
            this.dtFecha2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtFecha2.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha2.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.dtFecha2.ForeColor = System.Drawing.Color.Black;
            this.dtFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha2.Location = new System.Drawing.Point(643, 11);
            this.dtFecha2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtFecha2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtFecha2.Name = "dtFecha2";
            this.dtFecha2.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtFecha2.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha2.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtFecha2.OnPressedColor = System.Drawing.Color.Black;
            this.dtFecha2.Size = new System.Drawing.Size(167, 30);
            this.dtFecha2.TabIndex = 170;
            this.dtFecha2.Text = "3/10/2023";
            this.dtFecha2.Value = new System.DateTime(2023, 3, 10, 11, 29, 29, 92);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(400, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 171;
            this.label2.Text = "DE:";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(21, 502);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(210, 23);
            this.progressBar1.TabIndex = 181;
            this.progressBar1.Value = 99;
            this.progressBar1.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1080, 501);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 173;
            this.label3.Text = "Total:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1134, 501);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 182;
            this.label4.Text = "Total:";
            // 
            // frmRepClientesActivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 530);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.dgvRep);
            this.Name = "frmRepClientesActivos";
            this.ShowIcon = false;
            this.Text = "Reporte clientes Acitivos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRepClientesActivos_FormClosing);
            this.Load += new System.EventHandler(this.frmRepClientesActivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRep)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cord;
        private System.Windows.Forms.Label label15;
        private Guna.UI.WinForms.GunaGradientTileButton btnAlta;
        private Guna.UI.WinForms.GunaDataGridView dgvRep;
        private System.Windows.Forms.Panel panel11;
        private Guna.UI.WinForms.GunaDateTimePicker dtFecha1;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaDateTimePicker dtFecha2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}