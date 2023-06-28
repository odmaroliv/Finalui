namespace mainVentana.VistaInicioCoordinadores
{
    partial class frmEvidenciasEntrega
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
            this.iconButton10 = new FontAwesome.Sharp.IconButton();
            this.txbBuscar = new Guna.UI.WinForms.GunaTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEnt = new System.Windows.Forms.Label();
            this.SucCombo = new System.Windows.Forms.GroupBox();
            this.rCa = new System.Windows.Forms.RadioButton();
            this.rTj = new System.Windows.Forms.RadioButton();
            this.rSd = new System.Windows.Forms.RadioButton();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.lblRecibe = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbFirma = new System.Windows.Forms.GroupBox();
            this.pbxFirma = new System.Windows.Forms.PictureBox();
            this.SucCombo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbFirma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFirma)).BeginInit();
            this.SuspendLayout();
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
            this.iconButton10.Location = new System.Drawing.Point(1007, 24);
            this.iconButton10.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton10.Name = "iconButton10";
            this.iconButton10.Size = new System.Drawing.Size(29, 29);
            this.iconButton10.TabIndex = 14;
            this.iconButton10.UseVisualStyleBackColor = false;
            this.iconButton10.Click += new System.EventHandler(this.iconButton10_Click);
            // 
            // txbBuscar
            // 
            this.txbBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbBuscar.BackColor = System.Drawing.Color.Transparent;
            this.txbBuscar.BaseColor = System.Drawing.Color.White;
            this.txbBuscar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(238)))), ((int)(((byte)(254)))));
            this.txbBuscar.BorderSize = 1;
            this.txbBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbBuscar.FocusedBaseColor = System.Drawing.Color.White;
            this.txbBuscar.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.txbBuscar.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txbBuscar.Font = new System.Drawing.Font("Trebuchet MS", 18F);
            this.txbBuscar.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txbBuscar.Location = new System.Drawing.Point(785, 11);
            this.txbBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txbBuscar.Name = "txbBuscar";
            this.txbBuscar.PasswordChar = '\0';
            this.txbBuscar.Radius = 10;
            this.txbBuscar.Size = new System.Drawing.Size(257, 54);
            this.txbBuscar.TabIndex = 13;
            this.txbBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbBuscar_KeyDown);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 182);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1029, 216);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // lblEnt
            // 
            this.lblEnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnt.Location = new System.Drawing.Point(88, 26);
            this.lblEnt.Name = "lblEnt";
            this.lblEnt.Size = new System.Drawing.Size(252, 22);
            this.lblEnt.TabIndex = 107;
            // 
            // SucCombo
            // 
            this.SucCombo.Controls.Add(this.rCa);
            this.SucCombo.Controls.Add(this.rTj);
            this.SucCombo.Controls.Add(this.rSd);
            this.SucCombo.Location = new System.Drawing.Point(12, 17);
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
            this.rSd.CheckedChanged += new System.EventHandler(this.rSd_CheckedChanged_1);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImprimir.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir.IconColor = System.Drawing.Color.Black;
            this.btnImprimir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(748, 554);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(293, 51);
            this.btnImprimir.TabIndex = 152;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblRecibe
            // 
            this.lblRecibe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecibe.Location = new System.Drawing.Point(89, 58);
            this.lblRecibe.Name = "lblRecibe";
            this.lblRecibe.Size = new System.Drawing.Size(251, 22);
            this.lblRecibe.TabIndex = 153;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 22);
            this.label6.TabIndex = 154;
            this.label6.Text = "N. Entrada";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 155;
            this.label1.Text = "Recibió";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblEnt);
            this.groupBox1.Controls.Add(this.lblRecibe);
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 104);
            this.groupBox1.TabIndex = 156;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generales";
            // 
            // gbFirma
            // 
            this.gbFirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbFirma.Controls.Add(this.pbxFirma);
            this.gbFirma.Location = new System.Drawing.Point(12, 404);
            this.gbFirma.Name = "gbFirma";
            this.gbFirma.Size = new System.Drawing.Size(237, 196);
            this.gbFirma.TabIndex = 157;
            this.gbFirma.TabStop = false;
            this.gbFirma.Text = "Firma";
            // 
            // pbxFirma
            // 
            this.pbxFirma.Location = new System.Drawing.Point(9, 19);
            this.pbxFirma.Name = "pbxFirma";
            this.pbxFirma.Size = new System.Drawing.Size(156, 110);
            this.pbxFirma.TabIndex = 0;
            this.pbxFirma.TabStop = false;
            // 
            // frmEvidenciasEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 612);
            this.Controls.Add(this.gbFirma);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.SucCombo);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.iconButton10);
            this.Controls.Add(this.txbBuscar);
            this.Name = "frmEvidenciasEntrega";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entregas";
            this.Load += new System.EventHandler(this.frmEvidenciasEntrega_Load);
            this.SucCombo.ResumeLayout(false);
            this.SucCombo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gbFirma.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFirma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton iconButton10;
        public Guna.UI.WinForms.GunaTextBox txbBuscar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblEnt;
        private System.Windows.Forms.GroupBox SucCombo;
        private System.Windows.Forms.RadioButton rCa;
        private System.Windows.Forms.RadioButton rTj;
        private System.Windows.Forms.RadioButton rSd;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private System.Windows.Forms.Label lblRecibe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbFirma;
        private System.Windows.Forms.PictureBox pbxFirma;
    }
}