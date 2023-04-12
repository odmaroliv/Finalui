namespace mainVentana
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txbPass2 = new Guna.UI.WinForms.GunaLineTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbUsr = new Guna.UI.WinForms.GunaLineTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblModoPruebas = new ReaLTaiizor.Controls.BigLabel();
            this.cmbServerSelect = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.btnActivate = new ReaLTaiizor.Controls.FoxButton();
            this.cbxPass = new Guna.UI.WinForms.GunaCheckBox();
            this.pnlImg = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.lblBorrarArch = new ReaLTaiizor.Controls.BigLabel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txbPass2
            // 
            this.txbPass2.Animated = true;
            this.txbPass2.BackColor = System.Drawing.Color.White;
            this.txbPass2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbPass2.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txbPass2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbPass2.LineColor = System.Drawing.Color.Gainsboro;
            this.txbPass2.Location = new System.Drawing.Point(0, 104);
            this.txbPass2.Margin = new System.Windows.Forms.Padding(2);
            this.txbPass2.Name = "txbPass2";
            this.txbPass2.PasswordChar = '\0';
            this.txbPass2.Size = new System.Drawing.Size(275, 31);
            this.txbPass2.TabIndex = 1;
            this.txbPass2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbPass_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // txbUsr
            // 
            this.txbUsr.BackColor = System.Drawing.Color.White;
            this.txbUsr.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbUsr.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txbUsr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbUsr.LineColor = System.Drawing.Color.Gainsboro;
            this.txbUsr.Location = new System.Drawing.Point(0, 37);
            this.txbUsr.Margin = new System.Windows.Forms.Padding(2);
            this.txbUsr.Name = "txbUsr";
            this.txbUsr.PasswordChar = '\0';
            this.txbUsr.Size = new System.Drawing.Size(275, 31);
            this.txbUsr.TabIndex = 0;
            this.txbUsr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbUsr_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblModoPruebas);
            this.panel1.Controls.Add(this.cmbServerSelect);
            this.panel1.Controls.Add(this.btnActivate);
            this.panel1.Controls.Add(this.cbxPass);
            this.panel1.Controls.Add(this.pnlImg);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(402, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 346);
            this.panel1.TabIndex = 5;
            // 
            // lblModoPruebas
            // 
            this.lblModoPruebas.AutoSize = true;
            this.lblModoPruebas.BackColor = System.Drawing.Color.Transparent;
            this.lblModoPruebas.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblModoPruebas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblModoPruebas.Location = new System.Drawing.Point(33, 12);
            this.lblModoPruebas.Name = "lblModoPruebas";
            this.lblModoPruebas.Size = new System.Drawing.Size(87, 28);
            this.lblModoPruebas.TabIndex = 3;
            this.lblModoPruebas.Text = "Pruebas";
            this.lblModoPruebas.Visible = false;
            // 
            // cmbServerSelect
            // 
            this.cmbServerSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.cmbServerSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbServerSelect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbServerSelect.DropDownHeight = 100;
            this.cmbServerSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServerSelect.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbServerSelect.ForeColor = System.Drawing.Color.Silver;
            this.cmbServerSelect.FormattingEnabled = true;
            this.cmbServerSelect.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cmbServerSelect.IntegralHeight = false;
            this.cmbServerSelect.ItemHeight = 20;
            this.cmbServerSelect.Items.AddRange(new object[] {
            "KEPLER4",
            "KEPLER_PRUEBAS"});
            this.cmbServerSelect.Location = new System.Drawing.Point(178, 18);
            this.cmbServerSelect.Name = "cmbServerSelect";
            this.cmbServerSelect.Size = new System.Drawing.Size(135, 26);
            this.cmbServerSelect.StartIndex = 0;
            this.cmbServerSelect.TabIndex = 24;
            this.cmbServerSelect.Visible = false;
            this.cmbServerSelect.SelectedIndexChanged += new System.EventHandler(this.cmbServerSelect_SelectedIndexChanged);
            // 
            // btnActivate
            // 
            this.btnActivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivate.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnActivate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnActivate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivate.DisabledBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnActivate.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.btnActivate.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(190)))));
            this.btnActivate.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnActivate.EnabledCalc = true;
            this.btnActivate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnActivate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.btnActivate.Location = new System.Drawing.Point(193, 328);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.OverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnActivate.Size = new System.Drawing.Size(120, 15);
            this.btnActivate.TabIndex = 0;
            this.btnActivate.Text = "Licencia";
            this.btnActivate.Visible = false;
            this.btnActivate.Click += new ReaLTaiizor.Util.FoxBase.ButtonFoxBase.ClickEventHandler(this.btnActivate_Click);
            // 
            // cbxPass
            // 
            this.cbxPass.BaseColor = System.Drawing.Color.White;
            this.cbxPass.CheckedOffColor = System.Drawing.Color.Gray;
            this.cbxPass.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbxPass.FillColor = System.Drawing.Color.White;
            this.cbxPass.Location = new System.Drawing.Point(179, 201);
            this.cbxPass.Name = "cbxPass";
            this.cbxPass.Size = new System.Drawing.Size(130, 20);
            this.cbxPass.TabIndex = 23;
            this.cbxPass.Text = "Mostrar Contraseña";
            this.cbxPass.CheckedChanged += new System.EventHandler(this.cbxPass_CheckedChanged);
            // 
            // pnlImg
            // 
            this.pnlImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlImg.Location = new System.Drawing.Point(34, 290);
            this.pnlImg.Margin = new System.Windows.Forms.Padding(2);
            this.pnlImg.Name = "pnlImg";
            this.pnlImg.Size = new System.Drawing.Size(279, 35);
            this.pnlImg.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.Controls.Add(this.iconButton1);
            this.panel4.Location = new System.Drawing.Point(34, 239);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(279, 38);
            this.panel4.TabIndex = 5;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold);
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton1.Location = new System.Drawing.Point(0, 0);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(279, 38);
            this.iconButton1.TabIndex = 6;
            this.iconButton1.Text = "Ingresar";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.txbPass2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txbUsr);
            this.panel3.Location = new System.Drawing.Point(34, 49);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(279, 147);
            this.panel3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(138)))));
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.gunaPictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(402, 346);
            this.panel2.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblBorrarArch);
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(402, 346);
            this.panel5.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::mainVentana.Properties.Resources.arnian_gr;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 346);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(143)))));
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaPictureBox1.InitialImage = global::mainVentana.Properties.Resources.arnian_gr;
            this.gunaPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.gunaPictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(402, 346);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaPictureBox1.TabIndex = 0;
            this.gunaPictureBox1.TabStop = false;
            // 
            // lblBorrarArch
            // 
            this.lblBorrarArch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBorrarArch.AutoSize = true;
            this.lblBorrarArch.BackColor = System.Drawing.Color.Transparent;
            this.lblBorrarArch.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblBorrarArch.ForeColor = System.Drawing.Color.White;
            this.lblBorrarArch.Location = new System.Drawing.Point(23, 309);
            this.lblBorrarArch.Name = "lblBorrarArch";
            this.lblBorrarArch.Size = new System.Drawing.Size(0, 28);
            this.lblBorrarArch.TabIndex = 3;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 346);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(754, 385);
            this.MinimumSize = new System.Drawing.Size(750, 385);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaLineTextBox txbPass2;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaLineTextBox txbUsr;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.Panel pnlImg;
        private Guna.UI.WinForms.GunaCheckBox cbxPass;
        private ReaLTaiizor.Controls.FoxButton btnActivate;
        private ReaLTaiizor.Controls.ComboBoxEdit cmbServerSelect;
        private ReaLTaiizor.Controls.BigLabel lblModoPruebas;
        private ReaLTaiizor.Controls.BigLabel lblBorrarArch;
    }
}