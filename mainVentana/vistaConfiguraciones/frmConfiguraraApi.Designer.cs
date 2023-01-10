namespace mainVentana.vistaConfiguraciones
{
    partial class frmConfiguraraApi
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
            this.gunaGroupBox1 = new Guna.UI.WinForms.GunaGroupBox();
            this.txbUs = new ReaLTaiizor.Controls.AloneTextBox();
            this.txbPs = new ReaLTaiizor.Controls.AloneTextBox();
            this.crownLabel1 = new ReaLTaiizor.Controls.CrownLabel();
            this.crownLabel2 = new ReaLTaiizor.Controls.CrownLabel();
            this.foreverButton1 = new ReaLTaiizor.Controls.ForeverButton();
            this.gunaGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaGroupBox1
            // 
            this.gunaGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox1.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Controls.Add(this.foreverButton1);
            this.gunaGroupBox1.Controls.Add(this.crownLabel2);
            this.gunaGroupBox1.Controls.Add(this.crownLabel1);
            this.gunaGroupBox1.Controls.Add(this.txbPs);
            this.gunaGroupBox1.Controls.Add(this.txbUs);
            this.gunaGroupBox1.LineColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Location = new System.Drawing.Point(12, 26);
            this.gunaGroupBox1.Name = "gunaGroupBox1";
            this.gunaGroupBox1.Size = new System.Drawing.Size(260, 255);
            this.gunaGroupBox1.TabIndex = 0;
            this.gunaGroupBox1.Text = "Api Arnian Archivos";
            this.gunaGroupBox1.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // txbUs
            // 
            this.txbUs.BackColor = System.Drawing.Color.White;
            this.txbUs.EnabledCalc = true;
            this.txbUs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbUs.ForeColor = System.Drawing.Color.Gray;
            this.txbUs.Location = new System.Drawing.Point(14, 81);
            this.txbUs.MaxLength = 32767;
            this.txbUs.MultiLine = false;
            this.txbUs.Name = "txbUs";
            this.txbUs.ReadOnly = false;
            this.txbUs.Size = new System.Drawing.Size(230, 29);
            this.txbUs.TabIndex = 0;
            this.txbUs.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbUs.UseSystemPasswordChar = true;
            // 
            // txbPs
            // 
            this.txbPs.BackColor = System.Drawing.Color.White;
            this.txbPs.EnabledCalc = true;
            this.txbPs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbPs.ForeColor = System.Drawing.Color.Gray;
            this.txbPs.Location = new System.Drawing.Point(14, 151);
            this.txbPs.MaxLength = 32767;
            this.txbPs.MultiLine = false;
            this.txbPs.Name = "txbPs";
            this.txbPs.ReadOnly = false;
            this.txbPs.Size = new System.Drawing.Size(230, 29);
            this.txbPs.TabIndex = 1;
            this.txbPs.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbPs.UseSystemPasswordChar = true;
            // 
            // crownLabel1
            // 
            this.crownLabel1.AutoSize = true;
            this.crownLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.crownLabel1.Location = new System.Drawing.Point(24, 55);
            this.crownLabel1.Name = "crownLabel1";
            this.crownLabel1.Size = new System.Drawing.Size(21, 13);
            this.crownLabel1.TabIndex = 2;
            this.crownLabel1.Text = "usr";
            // 
            // crownLabel2
            // 
            this.crownLabel2.AutoSize = true;
            this.crownLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.crownLabel2.Location = new System.Drawing.Point(24, 129);
            this.crownLabel2.Name = "crownLabel2";
            this.crownLabel2.Size = new System.Drawing.Size(23, 13);
            this.crownLabel2.TabIndex = 3;
            this.crownLabel2.Text = "pss";
            // 
            // foreverButton1
            // 
            this.foreverButton1.BackColor = System.Drawing.Color.Transparent;
            this.foreverButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.foreverButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.foreverButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.foreverButton1.Location = new System.Drawing.Point(60, 196);
            this.foreverButton1.Name = "foreverButton1";
            this.foreverButton1.Rounded = false;
            this.foreverButton1.Size = new System.Drawing.Size(120, 40);
            this.foreverButton1.TabIndex = 4;
            this.foreverButton1.Text = "Guardar";
            this.foreverButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.foreverButton1.Click += new System.EventHandler(this.foreverButton1_Click);
            // 
            // frmConfiguraraApi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gunaGroupBox1);
            this.Name = "frmConfiguraraApi";
            this.Text = "Configuracion de Apis";
            this.gunaGroupBox1.ResumeLayout(false);
            this.gunaGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox1;
        private ReaLTaiizor.Controls.AloneTextBox txbPs;
        private ReaLTaiizor.Controls.AloneTextBox txbUs;
        private ReaLTaiizor.Controls.ForeverButton foreverButton1;
        private ReaLTaiizor.Controls.CrownLabel crownLabel2;
        private ReaLTaiizor.Controls.CrownLabel crownLabel1;
    }
}