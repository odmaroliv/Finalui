namespace mainVentana.Reportes.Clientes
{
    partial class frmRepClientexZona
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel11 = new System.Windows.Forms.Panel();
            this.cmbZona = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAlta = new Guna.UI.WinForms.GunaGradientTileButton();
            this.dgvRep = new Guna.UI.WinForms.GunaDataGridView();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRep)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1149, 492);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 188;
            this.label4.Text = "Total:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1095, 492);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 183;
            this.label3.Text = "Total:";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(10, 492);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(210, 23);
            this.progressBar1.TabIndex = 187;
            this.progressBar1.Value = 99;
            this.progressBar1.Visible = false;
            // 
            // panel11
            // 
            this.panel11.AutoScroll = true;
            this.panel11.AutoScrollMargin = new System.Drawing.Size(1, 1);
            this.panel11.AutoScrollMinSize = new System.Drawing.Size(262, 0);
            this.panel11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel11.Controls.Add(this.cmbZona);
            this.panel11.Controls.Add(this.label15);
            this.panel11.Location = new System.Drawing.Point(10, 3);
            this.panel11.MinimumSize = new System.Drawing.Size(270, 40);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(829, 59);
            this.panel11.TabIndex = 186;
            // 
            // cmbZona
            // 
            this.cmbZona.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZona.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbZona.FormattingEnabled = true;
            this.cmbZona.Items.AddRange(new object[] {
            "Daniel Olivares"});
            this.cmbZona.Location = new System.Drawing.Point(54, 13);
            this.cmbZona.Margin = new System.Windows.Forms.Padding(2);
            this.cmbZona.Name = "cmbZona";
            this.cmbZona.Size = new System.Drawing.Size(235, 28);
            this.cmbZona.TabIndex = 110;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 20);
            this.label15.TabIndex = 111;
            this.label15.Text = "Zona";
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
            this.btnAlta.Location = new System.Drawing.Point(968, 3);
            this.btnAlta.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnAlta.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnAlta.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAlta.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAlta.OnHoverImage = null;
            this.btnAlta.OnPressedColor = System.Drawing.Color.Black;
            this.btnAlta.Radius = 5;
            this.btnAlta.Size = new System.Drawing.Size(222, 59);
            this.btnAlta.TabIndex = 185;
            this.btnAlta.Text = "Buscar";
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // dgvRep
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvRep.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRep.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRep.BackgroundColor = System.Drawing.Color.White;
            this.dgvRep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRep.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRep.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRep.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvRep.ColumnHeadersHeight = 30;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRep.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRep.EnableHeadersVisualStyles = false;
            this.dgvRep.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRep.Location = new System.Drawing.Point(11, 88);
            this.dgvRep.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRep.Name = "dgvRep";
            this.dgvRep.RowHeadersVisible = false;
            this.dgvRep.RowHeadersWidth = 51;
            this.dgvRep.RowTemplate.Height = 30;
            this.dgvRep.RowTemplate.ReadOnly = true;
            this.dgvRep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRep.Size = new System.Drawing.Size(1179, 400);
            this.dgvRep.TabIndex = 184;
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
            // frmRepClientexZona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 519);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.dgvRep);
            this.Name = "frmRepClientexZona";
            this.Text = "frmRepClientexZona";
            this.Load += new System.EventHandler(this.frmRepClientexZona_Load);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ComboBox cmbZona;
        private System.Windows.Forms.Label label15;
        private Guna.UI.WinForms.GunaGradientTileButton btnAlta;
        private Guna.UI.WinForms.GunaDataGridView dgvRep;
    }
}