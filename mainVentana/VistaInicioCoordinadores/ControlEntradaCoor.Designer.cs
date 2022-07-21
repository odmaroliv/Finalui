namespace mainVentana.VistaInicioCoordinadores
{
    partial class ControlEntradaCoor
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new Guna.UI.WinForms.GunaButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFentrada = new System.Windows.Forms.Label();
            this.lblCarga = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbar = new Guna.UI.WinForms.GunaMetroTrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AnimationHoverSpeed = 0.07F;
            this.button1.AnimationSpeed = 0.03F;
            this.button1.BaseColor = System.Drawing.SystemColors.Highlight;
            this.button1.BorderColor = System.Drawing.Color.Black;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.button1.FocusedColor = System.Drawing.Color.Empty;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = null;
            this.button1.ImageSize = new System.Drawing.Size(20, 20);
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.button1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.button1.OnHoverForeColor = System.Drawing.Color.White;
            this.button1.OnHoverImage = null;
            this.button1.OnPressedColor = System.Drawing.Color.Black;
            this.button1.Size = new System.Drawing.Size(135, 74);
            this.button1.TabIndex = 0;
            this.button1.Text = "gunaButton1";
            this.button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(189, 4);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha de entrada: ";
            // 
            // lblFentrada
            // 
            this.lblFentrada.AutoSize = true;
            this.lblFentrada.Location = new System.Drawing.Point(244, 26);
            this.lblFentrada.Name = "lblFentrada";
            this.lblFentrada.Size = new System.Drawing.Size(97, 13);
            this.lblFentrada.TabIndex = 4;
            this.lblFentrada.Text = "Fecha de entrada: ";
            // 
            // lblCarga
            // 
            this.lblCarga.AutoSize = true;
            this.lblCarga.Location = new System.Drawing.Point(244, 48);
            this.lblCarga.Name = "lblCarga";
            this.lblCarga.Size = new System.Drawing.Size(35, 13);
            this.lblCarga.TabIndex = 6;
            this.lblCarga.Text = "Carga";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(141, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Carga Asignada";
            // 
            // tbar
            // 
            this.tbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbar.Enabled = false;
            this.tbar.Location = new System.Drawing.Point(439, 42);
            this.tbar.Name = "tbar";
            this.tbar.Size = new System.Drawing.Size(222, 23);
            this.tbar.TabIndex = 7;
            this.tbar.TrackColor = System.Drawing.Color.Red;
            this.tbar.TrackHoverColor = System.Drawing.SystemColors.HighlightText;
            this.tbar.TrackIdleColor = System.Drawing.Color.Silver;
            this.tbar.TrackPressedColor = System.Drawing.Color.DarkBlue;
            this.tbar.Value = 66;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(482, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Asignada";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(562, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Aplicada";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(640, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Salida";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(404, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "NoAsignada";
            // 
            // ControlEntradaCoor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbar);
            this.Controls.Add(this.lblCarga);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblFentrada);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "ControlEntradaCoor";
            this.Size = new System.Drawing.Size(688, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI.WinForms.GunaButton button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblCliente;
        public System.Windows.Forms.Label lblFentrada;
        public System.Windows.Forms.Label lblCarga;
        public Guna.UI.WinForms.GunaMetroTrackBar tbar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
