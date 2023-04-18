namespace mainVentana.VistaEntrada
{
    partial class BusquedasEnt
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
            this.gunaTextBox2 = new Guna.UI.WinForms.GunaTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaShadowPanel1 = new Guna.UI.WinForms.GunaShadowPanel();
            this.txbClave = new System.Windows.Forms.TextBox();
            this.foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.gunaGradientTileButton4 = new Guna.UI.WinForms.GunaGradientTileButton();
            this.gunaShadowPanel2 = new Guna.UI.WinForms.GunaShadowPanel();
            this.gunaTextBox1 = new Guna.UI.WinForms.GunaTextBox();
            this.gunaTextBox3 = new Guna.UI.WinForms.GunaTextBox();
            this.txbOBusqueda = new System.Windows.Forms.TextBox();
            this.dgvBusqueda = new Guna.UI.WinForms.GunaDataGridView();
            this.foreverLabel2 = new ReaLTaiizor.Controls.ForeverLabel();
            this.gunaShadowPanel1.SuspendLayout();
            this.gunaShadowPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaTextBox2
            // 
            this.gunaTextBox2.BaseColor = System.Drawing.Color.White;
            this.gunaTextBox2.BorderColor = System.Drawing.Color.Silver;
            this.gunaTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaTextBox2.FocusedBaseColor = System.Drawing.Color.White;
            this.gunaTextBox2.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaTextBox2.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.gunaTextBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gunaTextBox2.Location = new System.Drawing.Point(29, 84);
            this.gunaTextBox2.Name = "gunaTextBox2";
            this.gunaTextBox2.PasswordChar = '\0';
            this.gunaTextBox2.ReadOnly = true;
            this.gunaTextBox2.Size = new System.Drawing.Size(296, 28);
            this.gunaTextBox2.TabIndex = 2;
            this.gunaTextBox2.Visible = false;
            this.gunaTextBox2.TextChanged += new System.EventHandler(this.gunaTextBox2_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(29, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(296, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Busqueda";
            // 
            // gunaShadowPanel1
            // 
            this.gunaShadowPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaShadowPanel1.BaseColor = System.Drawing.Color.White;
            this.gunaShadowPanel1.Controls.Add(this.foreverLabel2);
            this.gunaShadowPanel1.Controls.Add(this.dgvBusqueda);
            this.gunaShadowPanel1.Controls.Add(this.txbOBusqueda);
            this.gunaShadowPanel1.Controls.Add(this.txbClave);
            this.gunaShadowPanel1.Controls.Add(this.foreverLabel1);
            this.gunaShadowPanel1.Controls.Add(this.label2);
            this.gunaShadowPanel1.Controls.Add(this.comboBox1);
            this.gunaShadowPanel1.Controls.Add(this.label1);
            this.gunaShadowPanel1.Location = new System.Drawing.Point(9, 10);
            this.gunaShadowPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaShadowPanel1.Name = "gunaShadowPanel1";
            this.gunaShadowPanel1.Radius = 10;
            this.gunaShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.gunaShadowPanel1.ShadowDepth = 50;
            this.gunaShadowPanel1.ShadowShift = 10;
            this.gunaShadowPanel1.Size = new System.Drawing.Size(352, 282);
            this.gunaShadowPanel1.TabIndex = 7;
            // 
            // txbClave
            // 
            this.txbClave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbClave.Location = new System.Drawing.Point(225, 90);
            this.txbClave.Name = "txbClave";
            this.txbClave.Size = new System.Drawing.Size(100, 20);
            this.txbClave.TabIndex = 9;
            this.txbClave.Visible = false;
            this.txbClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbClave_KeyDown_1);
            // 
            // foreverLabel1
            // 
            this.foreverLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverLabel1.AutoSize = true;
            this.foreverLabel1.BackColor = System.Drawing.Color.Transparent;
            this.foreverLabel1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.foreverLabel1.ForeColor = System.Drawing.Color.LightGray;
            this.foreverLabel1.Location = new System.Drawing.Point(223, 73);
            this.foreverLabel1.Name = "foreverLabel1";
            this.foreverLabel1.Size = new System.Drawing.Size(34, 13);
            this.foreverLabel1.TabIndex = 8;
            this.foreverLabel1.Text = "Clave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 6;
            // 
            // gunaGradientTileButton4
            // 
            this.gunaGradientTileButton4.Animated = true;
            this.gunaGradientTileButton4.AnimationHoverSpeed = 0.07F;
            this.gunaGradientTileButton4.AnimationSpeed = 0.03F;
            this.gunaGradientTileButton4.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradientTileButton4.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(131)))), ((int)(((byte)(157)))));
            this.gunaGradientTileButton4.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(11)))), ((int)(((byte)(154)))));
            this.gunaGradientTileButton4.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientTileButton4.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientTileButton4.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGradientTileButton4.ForeColor = System.Drawing.Color.White;
            this.gunaGradientTileButton4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gunaGradientTileButton4.Image = null;
            this.gunaGradientTileButton4.ImageSize = new System.Drawing.Size(100, 80);
            this.gunaGradientTileButton4.Location = new System.Drawing.Point(29, 117);
            this.gunaGradientTileButton4.Margin = new System.Windows.Forms.Padding(2);
            this.gunaGradientTileButton4.Name = "gunaGradientTileButton4";
            this.gunaGradientTileButton4.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.gunaGradientTileButton4.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(43)))), ((int)(((byte)(255)))));
            this.gunaGradientTileButton4.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton4.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientTileButton4.OnHoverImage = null;
            this.gunaGradientTileButton4.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientTileButton4.Radius = 5;
            this.gunaGradientTileButton4.Size = new System.Drawing.Size(296, 41);
            this.gunaGradientTileButton4.TabIndex = 21;
            this.gunaGradientTileButton4.Text = "Validar y aceptar";
            this.gunaGradientTileButton4.Click += new System.EventHandler(this.gunaGradientTileButton4_Click);
            // 
            // gunaShadowPanel2
            // 
            this.gunaShadowPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaShadowPanel2.BaseColor = System.Drawing.Color.White;
            this.gunaShadowPanel2.Controls.Add(this.gunaTextBox1);
            this.gunaShadowPanel2.Controls.Add(this.gunaTextBox3);
            this.gunaShadowPanel2.Controls.Add(this.gunaGradientTileButton4);
            this.gunaShadowPanel2.Controls.Add(this.gunaTextBox2);
            this.gunaShadowPanel2.Location = new System.Drawing.Point(9, 286);
            this.gunaShadowPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.gunaShadowPanel2.Name = "gunaShadowPanel2";
            this.gunaShadowPanel2.Radius = 10;
            this.gunaShadowPanel2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.gunaShadowPanel2.ShadowDepth = 50;
            this.gunaShadowPanel2.ShadowShift = 10;
            this.gunaShadowPanel2.Size = new System.Drawing.Size(352, 166);
            this.gunaShadowPanel2.TabIndex = 8;
            // 
            // gunaTextBox1
            // 
            this.gunaTextBox1.BaseColor = System.Drawing.Color.White;
            this.gunaTextBox1.BorderColor = System.Drawing.Color.Silver;
            this.gunaTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaTextBox1.FocusedBaseColor = System.Drawing.Color.White;
            this.gunaTextBox1.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaTextBox1.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.gunaTextBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gunaTextBox1.Location = new System.Drawing.Point(29, 23);
            this.gunaTextBox1.Name = "gunaTextBox1";
            this.gunaTextBox1.PasswordChar = '\0';
            this.gunaTextBox1.ReadOnly = true;
            this.gunaTextBox1.Size = new System.Drawing.Size(296, 28);
            this.gunaTextBox1.TabIndex = 23;
            this.gunaTextBox1.Visible = false;
            // 
            // gunaTextBox3
            // 
            this.gunaTextBox3.BaseColor = System.Drawing.Color.White;
            this.gunaTextBox3.BorderColor = System.Drawing.Color.Silver;
            this.gunaTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaTextBox3.FocusedBaseColor = System.Drawing.Color.White;
            this.gunaTextBox3.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaTextBox3.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.gunaTextBox3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gunaTextBox3.Location = new System.Drawing.Point(29, 53);
            this.gunaTextBox3.Name = "gunaTextBox3";
            this.gunaTextBox3.PasswordChar = '\0';
            this.gunaTextBox3.ReadOnly = true;
            this.gunaTextBox3.Size = new System.Drawing.Size(296, 28);
            this.gunaTextBox3.TabIndex = 22;
            this.gunaTextBox3.Visible = false;
            // 
            // txbOBusqueda
            // 
            this.txbOBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbOBusqueda.Location = new System.Drawing.Point(29, 121);
            this.txbOBusqueda.Name = "txbOBusqueda";
            this.txbOBusqueda.Size = new System.Drawing.Size(295, 20);
            this.txbOBusqueda.TabIndex = 10;
            this.txbOBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbOBusqueda_KeyPress);
            // 
            // dgvBusqueda
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvBusqueda.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBusqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBusqueda.BackgroundColor = System.Drawing.Color.White;
            this.dgvBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBusqueda.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBusqueda.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBusqueda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBusqueda.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBusqueda.EnableHeadersVisualStyles = false;
            this.dgvBusqueda.GridColor = System.Drawing.Color.White;
            this.dgvBusqueda.Location = new System.Drawing.Point(29, 147);
            this.dgvBusqueda.Name = "dgvBusqueda";
            this.dgvBusqueda.ReadOnly = true;
            this.dgvBusqueda.RowHeadersVisible = false;
            this.dgvBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBusqueda.Size = new System.Drawing.Size(295, 109);
            this.dgvBusqueda.TabIndex = 11;
            this.dgvBusqueda.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgvBusqueda.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBusqueda.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBusqueda.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBusqueda.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBusqueda.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBusqueda.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBusqueda.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.dgvBusqueda.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvBusqueda.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBusqueda.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvBusqueda.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBusqueda.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusqueda.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvBusqueda.ThemeStyle.ReadOnly = true;
            this.dgvBusqueda.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBusqueda.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBusqueda.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvBusqueda.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBusqueda.ThemeStyle.RowsStyle.Height = 22;
            this.dgvBusqueda.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBusqueda.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBusqueda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusqueda_CellDoubleClick);
            // 
            // foreverLabel2
            // 
            this.foreverLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverLabel2.AutoSize = true;
            this.foreverLabel2.BackColor = System.Drawing.Color.Transparent;
            this.foreverLabel2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.foreverLabel2.ForeColor = System.Drawing.Color.LightGray;
            this.foreverLabel2.Location = new System.Drawing.Point(27, 97);
            this.foreverLabel2.Name = "foreverLabel2";
            this.foreverLabel2.Size = new System.Drawing.Size(110, 13);
            this.foreverLabel2.TabIndex = 12;
            this.foreverLabel2.Text = "Busqueda dinamica:";
            // 
            // BusquedasEnt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(370, 461);
            this.Controls.Add(this.gunaShadowPanel2);
            this.Controls.Add(this.gunaShadowPanel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(386, 500);
            this.MinimumSize = new System.Drawing.Size(386, 400);
            this.Name = "BusquedasEnt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BusquedasEnt";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BusquedasEnt_FormClosed);
            this.Load += new System.EventHandler(this.BusquedasEnt_Load);
            this.gunaShadowPanel1.ResumeLayout(false);
            this.gunaShadowPanel1.PerformLayout();
            this.gunaShadowPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaTextBox gunaTextBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaShadowPanel gunaShadowPanel1;
        private Guna.UI.WinForms.GunaGradientTileButton gunaGradientTileButton4;
        private Guna.UI.WinForms.GunaShadowPanel gunaShadowPanel2;
        public System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaTextBox gunaTextBox3;
        private Guna.UI.WinForms.GunaTextBox gunaTextBox1;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private System.Windows.Forms.TextBox txbClave;
        private Guna.UI.WinForms.GunaDataGridView dgvBusqueda;
        private System.Windows.Forms.TextBox txbOBusqueda;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel2;
    }
}