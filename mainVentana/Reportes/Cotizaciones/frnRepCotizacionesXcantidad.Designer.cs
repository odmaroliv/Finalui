namespace mainVentana.Reportes.Cotizaciones
{
    partial class frnRepCotizacionesXcantidad
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
            this.btnAlta = new Guna.UI.WinForms.GunaGradientTileButton();
            this.dgvRep = new Guna.UI.WinForms.GunaDataGridView();
            this.txbBusqueda = new Guna.UI.WinForms.GunaTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRep)).BeginInit();
            this.SuspendLayout();
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
            this.btnAlta.Location = new System.Drawing.Point(864, 46);
            this.btnAlta.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnAlta.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.btnAlta.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAlta.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAlta.OnHoverImage = null;
            this.btnAlta.OnPressedColor = System.Drawing.Color.Black;
            this.btnAlta.Radius = 5;
            this.btnAlta.Size = new System.Drawing.Size(229, 50);
            this.btnAlta.TabIndex = 181;
            this.btnAlta.Text = "Buscar";
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // dgvRep
            // 
            this.dgvRep.AllowUserToAddRows = false;
            this.dgvRep.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvRep.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRep.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvRep.BackgroundColor = System.Drawing.Color.White;
            this.dgvRep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRep.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRep.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRep.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRep.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRep.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRep.EnableHeadersVisualStyles = false;
            this.dgvRep.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRep.Location = new System.Drawing.Point(25, 124);
            this.dgvRep.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRep.Name = "dgvRep";
            this.dgvRep.RowHeadersVisible = false;
            this.dgvRep.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvRep.RowTemplate.Height = 30;
            this.dgvRep.RowTemplate.ReadOnly = true;
            this.dgvRep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRep.Size = new System.Drawing.Size(1068, 428);
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
            this.dgvRep.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvRep.ThemeStyle.ReadOnly = false;
            this.dgvRep.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRep.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRep.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvRep.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvRep.ThemeStyle.RowsStyle.Height = 30;
            this.dgvRep.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRep.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // txbBusqueda
            // 
            this.txbBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txbBusqueda.Location = new System.Drawing.Point(25, 46);
            this.txbBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.txbBusqueda.Name = "txbBusqueda";
            this.txbBusqueda.PasswordChar = '\0';
            this.txbBusqueda.Radius = 10;
            this.txbBusqueda.Size = new System.Drawing.Size(736, 50);
            this.txbBusqueda.TabIndex = 186;
            this.txbBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbBusqueda_KeyDown);
            // 
            // frnRepCotizacionesXcantidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 563);
            this.Controls.Add(this.txbBusqueda);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.dgvRep);
            this.Name = "frnRepCotizacionesXcantidad";
            this.ShowIcon = false;
            this.Text = "Cotizaciones Reporte / Valor Arnian";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frnRepCotizacionesXcantidad_FormClosing);
            this.Load += new System.EventHandler(this.frnRepCotizacionesXcantidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientTileButton btnAlta;
        private Guna.UI.WinForms.GunaDataGridView dgvRep;
        public Guna.UI.WinForms.GunaTextBox txbBusqueda;
    }
}