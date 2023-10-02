namespace mainVentana.vistaConfiguraciones
{
    partial class frmNuevoUsuario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gunaTileButton1 = new Guna.UI.WinForms.GunaTileButton();
            this.txbUsuario = new Guna.UI.WinForms.GunaLineTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbNombre = new Guna.UI.WinForms.GunaLineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbContrasena = new Guna.UI.WinForms.GunaLineTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbCorreo = new Guna.UI.WinForms.GunaLineTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbTelefono = new Guna.UI.WinForms.GunaLineTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbRol = new Guna.UI.WinForms.GunaLineTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbxNuser = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbMaster = new Guna.UI.WinForms.GunaLineTextBox();
            this.gunaTileButton3 = new Guna.UI.WinForms.GunaTileButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txbCliente = new Guna.UI.WinForms.GunaLineTextBox();
            this.txbSucursal = new Guna.UI.WinForms.GunaLineTextBox();
            this.dgvUsuarios = new Guna.UI.WinForms.GunaDataGridView();
            this.gunaTileButton2 = new Guna.UI.WinForms.GunaTileButton();
            this.gunaTileButton4 = new Guna.UI.WinForms.GunaTileButton();
            this.gunaTileButton5 = new Guna.UI.WinForms.GunaTileButton();
            this.txbUid = new Guna.UI.WinForms.GunaLineTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txbBusqueda = new System.Windows.Forms.TextBox();
            this.gbxNuser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaTileButton1
            // 
            this.gunaTileButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaTileButton1.AnimationHoverSpeed = 0.07F;
            this.gunaTileButton1.AnimationSpeed = 0.03F;
            this.gunaTileButton1.BaseColor = System.Drawing.Color.Blue;
            this.gunaTileButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaTileButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaTileButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaTileButton1.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Bold);
            this.gunaTileButton1.ForeColor = System.Drawing.Color.White;
            this.gunaTileButton1.Image = null;
            this.gunaTileButton1.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaTileButton1.Location = new System.Drawing.Point(686, 12);
            this.gunaTileButton1.Name = "gunaTileButton1";
            this.gunaTileButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gunaTileButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaTileButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaTileButton1.OnHoverImage = null;
            this.gunaTileButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaTileButton1.Size = new System.Drawing.Size(96, 27);
            this.gunaTileButton1.TabIndex = 185;
            this.gunaTileButton1.Text = "Buscar";
            this.gunaTileButton1.Click += new System.EventHandler(this.gunaTileButton1_Click);
            // 
            // txbUsuario
            // 
            this.txbUsuario.Animated = true;
            this.txbUsuario.BackColor = System.Drawing.Color.White;
            this.txbUsuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbUsuario.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txbUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsuario.LineColor = System.Drawing.Color.Gainsboro;
            this.txbUsuario.Location = new System.Drawing.Point(15, 57);
            this.txbUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txbUsuario.MaxLength = 30;
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.PasswordChar = '\0';
            this.txbUsuario.ReadOnly = true;
            this.txbUsuario.Size = new System.Drawing.Size(242, 29);
            this.txbUsuario.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 145;
            this.label1.Text = "Usuario";
            // 
            // txbNombre
            // 
            this.txbNombre.Animated = true;
            this.txbNombre.BackColor = System.Drawing.Color.White;
            this.txbNombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbNombre.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txbNombre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNombre.LineColor = System.Drawing.Color.Gainsboro;
            this.txbNombre.Location = new System.Drawing.Point(534, 57);
            this.txbNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txbNombre.MaxLength = 60;
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.PasswordChar = '\0';
            this.txbNombre.Size = new System.Drawing.Size(218, 29);
            this.txbNombre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(531, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 147;
            this.label2.Text = "Nombre";
            // 
            // txbContrasena
            // 
            this.txbContrasena.Animated = true;
            this.txbContrasena.BackColor = System.Drawing.Color.White;
            this.txbContrasena.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbContrasena.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txbContrasena.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbContrasena.LineColor = System.Drawing.Color.Gainsboro;
            this.txbContrasena.Location = new System.Drawing.Point(281, 57);
            this.txbContrasena.Margin = new System.Windows.Forms.Padding(2);
            this.txbContrasena.MaxLength = 50;
            this.txbContrasena.Name = "txbContrasena";
            this.txbContrasena.PasswordChar = '\0';
            this.txbContrasena.Size = new System.Drawing.Size(228, 29);
            this.txbContrasena.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Location = new System.Drawing.Point(278, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 149;
            this.label3.Text = "Contraseña";
            // 
            // txbCorreo
            // 
            this.txbCorreo.Animated = true;
            this.txbCorreo.BackColor = System.Drawing.Color.White;
            this.txbCorreo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbCorreo.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txbCorreo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCorreo.LineColor = System.Drawing.Color.Gainsboro;
            this.txbCorreo.Location = new System.Drawing.Point(15, 116);
            this.txbCorreo.Margin = new System.Windows.Forms.Padding(2);
            this.txbCorreo.Name = "txbCorreo";
            this.txbCorreo.PasswordChar = '\0';
            this.txbCorreo.Size = new System.Drawing.Size(242, 29);
            this.txbCorreo.TabIndex = 150;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 151;
            this.label4.Text = "Correo";
            // 
            // txbTelefono
            // 
            this.txbTelefono.Animated = true;
            this.txbTelefono.BackColor = System.Drawing.Color.White;
            this.txbTelefono.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbTelefono.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txbTelefono.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTelefono.LineColor = System.Drawing.Color.Gainsboro;
            this.txbTelefono.Location = new System.Drawing.Point(281, 116);
            this.txbTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txbTelefono.Name = "txbTelefono";
            this.txbTelefono.PasswordChar = '\0';
            this.txbTelefono.Size = new System.Drawing.Size(228, 29);
            this.txbTelefono.TabIndex = 152;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label5.Location = new System.Drawing.Point(278, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 153;
            this.label5.Text = "Telefono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label6.Location = new System.Drawing.Point(12, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 155;
            this.label6.Text = "Sucursal";
            // 
            // txbRol
            // 
            this.txbRol.Animated = true;
            this.txbRol.BackColor = System.Drawing.Color.White;
            this.txbRol.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbRol.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txbRol.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRol.LineColor = System.Drawing.Color.Gainsboro;
            this.txbRol.Location = new System.Drawing.Point(281, 174);
            this.txbRol.Margin = new System.Windows.Forms.Padding(2);
            this.txbRol.Name = "txbRol";
            this.txbRol.PasswordChar = '\0';
            this.txbRol.Size = new System.Drawing.Size(228, 29);
            this.txbRol.TabIndex = 156;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label7.Location = new System.Drawing.Point(278, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 157;
            this.label7.Text = "Rol";
            // 
            // gbxNuser
            // 
            this.gbxNuser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxNuser.Controls.Add(this.txbUid);
            this.gbxNuser.Controls.Add(this.label10);
            this.gbxNuser.Controls.Add(this.label9);
            this.gbxNuser.Controls.Add(this.txbMaster);
            this.gbxNuser.Controls.Add(this.gunaTileButton3);
            this.gbxNuser.Controls.Add(this.label8);
            this.gbxNuser.Controls.Add(this.txbCliente);
            this.gbxNuser.Controls.Add(this.txbSucursal);
            this.gbxNuser.Controls.Add(this.label7);
            this.gbxNuser.Controls.Add(this.txbRol);
            this.gbxNuser.Controls.Add(this.label6);
            this.gbxNuser.Controls.Add(this.label5);
            this.gbxNuser.Controls.Add(this.txbTelefono);
            this.gbxNuser.Controls.Add(this.label4);
            this.gbxNuser.Controls.Add(this.txbCorreo);
            this.gbxNuser.Controls.Add(this.label3);
            this.gbxNuser.Controls.Add(this.txbContrasena);
            this.gbxNuser.Controls.Add(this.label2);
            this.gbxNuser.Controls.Add(this.txbNombre);
            this.gbxNuser.Controls.Add(this.label1);
            this.gbxNuser.Controls.Add(this.txbUsuario);
            this.gbxNuser.Enabled = false;
            this.gbxNuser.Location = new System.Drawing.Point(12, 168);
            this.gbxNuser.Name = "gbxNuser";
            this.gbxNuser.Size = new System.Drawing.Size(776, 300);
            this.gbxNuser.TabIndex = 0;
            this.gbxNuser.TabStop = false;
            this.gbxNuser.Text = "Generales";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label9.Location = new System.Drawing.Point(531, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 190;
            this.label9.Text = "Master";
            // 
            // txbMaster
            // 
            this.txbMaster.Animated = true;
            this.txbMaster.BackColor = System.Drawing.Color.White;
            this.txbMaster.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbMaster.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txbMaster.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMaster.LineColor = System.Drawing.Color.Gainsboro;
            this.txbMaster.Location = new System.Drawing.Point(534, 174);
            this.txbMaster.Margin = new System.Windows.Forms.Padding(2);
            this.txbMaster.Name = "txbMaster";
            this.txbMaster.PasswordChar = '\0';
            this.txbMaster.Size = new System.Drawing.Size(75, 29);
            this.txbMaster.TabIndex = 189;
            // 
            // gunaTileButton3
            // 
            this.gunaTileButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaTileButton3.AnimationHoverSpeed = 0.07F;
            this.gunaTileButton3.AnimationSpeed = 0.03F;
            this.gunaTileButton3.BaseColor = System.Drawing.Color.DarkCyan;
            this.gunaTileButton3.BorderColor = System.Drawing.Color.Black;
            this.gunaTileButton3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaTileButton3.FocusedColor = System.Drawing.Color.Empty;
            this.gunaTileButton3.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Bold);
            this.gunaTileButton3.ForeColor = System.Drawing.Color.White;
            this.gunaTileButton3.Image = null;
            this.gunaTileButton3.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaTileButton3.Location = new System.Drawing.Point(652, 174);
            this.gunaTileButton3.Name = "gunaTileButton3";
            this.gunaTileButton3.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gunaTileButton3.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaTileButton3.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaTileButton3.OnHoverImage = null;
            this.gunaTileButton3.OnPressedColor = System.Drawing.Color.Black;
            this.gunaTileButton3.Size = new System.Drawing.Size(100, 29);
            this.gunaTileButton3.TabIndex = 188;
            this.gunaTileButton3.Text = "Guardar";
            this.gunaTileButton3.Click += new System.EventHandler(this.gunaTileButton3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label8.Location = new System.Drawing.Point(531, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 160;
            this.label8.Text = "Cliente";
            // 
            // txbCliente
            // 
            this.txbCliente.Animated = true;
            this.txbCliente.BackColor = System.Drawing.Color.White;
            this.txbCliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbCliente.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txbCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCliente.LineColor = System.Drawing.Color.Gainsboro;
            this.txbCliente.Location = new System.Drawing.Point(534, 116);
            this.txbCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txbCliente.Name = "txbCliente";
            this.txbCliente.PasswordChar = '\0';
            this.txbCliente.Size = new System.Drawing.Size(218, 29);
            this.txbCliente.TabIndex = 159;
            // 
            // txbSucursal
            // 
            this.txbSucursal.Animated = true;
            this.txbSucursal.BackColor = System.Drawing.Color.White;
            this.txbSucursal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbSucursal.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txbSucursal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSucursal.LineColor = System.Drawing.Color.Gainsboro;
            this.txbSucursal.Location = new System.Drawing.Point(15, 174);
            this.txbSucursal.Margin = new System.Windows.Forms.Padding(2);
            this.txbSucursal.MaxLength = 4;
            this.txbSucursal.Name = "txbSucursal";
            this.txbSucursal.PasswordChar = '\0';
            this.txbSucursal.Size = new System.Drawing.Size(242, 29);
            this.txbSucursal.TabIndex = 158;
            // 
            // dgvUsuarios
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvUsuarios.ColumnHeadersHeight = 30;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 12);
            this.dgvUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.RowTemplate.Height = 30;
            this.dgvUsuarios.RowTemplate.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(669, 151);
            this.dgvUsuarios.TabIndex = 186;
            this.dgvUsuarios.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgvUsuarios.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvUsuarios.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvUsuarios.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvUsuarios.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvUsuarios.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvUsuarios.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvUsuarios.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUsuarios.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvUsuarios.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUsuarios.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvUsuarios.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUsuarios.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvUsuarios.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvUsuarios.ThemeStyle.ReadOnly = false;
            this.dgvUsuarios.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvUsuarios.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsuarios.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvUsuarios.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvUsuarios.ThemeStyle.RowsStyle.Height = 30;
            this.dgvUsuarios.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUsuarios.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvUsuarios.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentDoubleClick);
            // 
            // gunaTileButton2
            // 
            this.gunaTileButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaTileButton2.AnimationHoverSpeed = 0.07F;
            this.gunaTileButton2.AnimationSpeed = 0.03F;
            this.gunaTileButton2.BaseColor = System.Drawing.SystemColors.ControlDark;
            this.gunaTileButton2.BorderColor = System.Drawing.Color.Black;
            this.gunaTileButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaTileButton2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaTileButton2.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Bold);
            this.gunaTileButton2.ForeColor = System.Drawing.Color.White;
            this.gunaTileButton2.Image = null;
            this.gunaTileButton2.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaTileButton2.Location = new System.Drawing.Point(686, 58);
            this.gunaTileButton2.Name = "gunaTileButton2";
            this.gunaTileButton2.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gunaTileButton2.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaTileButton2.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaTileButton2.OnHoverImage = null;
            this.gunaTileButton2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaTileButton2.Size = new System.Drawing.Size(96, 27);
            this.gunaTileButton2.TabIndex = 187;
            this.gunaTileButton2.Text = "Vendedor";
            this.gunaTileButton2.Click += new System.EventHandler(this.gunaTileButton2_Click);
            // 
            // gunaTileButton4
            // 
            this.gunaTileButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaTileButton4.AnimationHoverSpeed = 0.07F;
            this.gunaTileButton4.AnimationSpeed = 0.03F;
            this.gunaTileButton4.BaseColor = System.Drawing.Color.Coral;
            this.gunaTileButton4.BorderColor = System.Drawing.Color.Black;
            this.gunaTileButton4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaTileButton4.FocusedColor = System.Drawing.Color.Empty;
            this.gunaTileButton4.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Bold);
            this.gunaTileButton4.ForeColor = System.Drawing.Color.White;
            this.gunaTileButton4.Image = null;
            this.gunaTileButton4.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaTileButton4.Location = new System.Drawing.Point(686, 135);
            this.gunaTileButton4.Name = "gunaTileButton4";
            this.gunaTileButton4.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gunaTileButton4.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaTileButton4.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaTileButton4.OnHoverImage = null;
            this.gunaTileButton4.OnPressedColor = System.Drawing.Color.Black;
            this.gunaTileButton4.Size = new System.Drawing.Size(37, 27);
            this.gunaTileButton4.TabIndex = 188;
            this.gunaTileButton4.Text = "N";
            this.gunaTileButton4.Click += new System.EventHandler(this.gunaTileButton4_Click);
            // 
            // gunaTileButton5
            // 
            this.gunaTileButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaTileButton5.AnimationHoverSpeed = 0.07F;
            this.gunaTileButton5.AnimationSpeed = 0.03F;
            this.gunaTileButton5.BaseColor = System.Drawing.Color.Coral;
            this.gunaTileButton5.BorderColor = System.Drawing.Color.Black;
            this.gunaTileButton5.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaTileButton5.FocusedColor = System.Drawing.Color.Empty;
            this.gunaTileButton5.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Bold);
            this.gunaTileButton5.ForeColor = System.Drawing.Color.White;
            this.gunaTileButton5.Image = null;
            this.gunaTileButton5.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaTileButton5.Location = new System.Drawing.Point(745, 135);
            this.gunaTileButton5.Name = "gunaTileButton5";
            this.gunaTileButton5.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gunaTileButton5.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaTileButton5.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaTileButton5.OnHoverImage = null;
            this.gunaTileButton5.OnPressedColor = System.Drawing.Color.Black;
            this.gunaTileButton5.Size = new System.Drawing.Size(37, 27);
            this.gunaTileButton5.TabIndex = 189;
            this.gunaTileButton5.Text = "M";
            this.gunaTileButton5.Click += new System.EventHandler(this.gunaTileButton5_Click);
            // 
            // txbUid
            // 
            this.txbUid.Animated = true;
            this.txbUid.BackColor = System.Drawing.Color.White;
            this.txbUid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbUid.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txbUid.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUid.LineColor = System.Drawing.Color.Gainsboro;
            this.txbUid.Location = new System.Drawing.Point(15, 230);
            this.txbUid.Margin = new System.Windows.Forms.Padding(2);
            this.txbUid.MaxLength = 128;
            this.txbUid.Name = "txbUid";
            this.txbUid.PasswordChar = '\0';
            this.txbUid.Size = new System.Drawing.Size(242, 29);
            this.txbUid.TabIndex = 192;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label10.Location = new System.Drawing.Point(12, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 191;
            this.label10.Text = "UID";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label11.Location = new System.Drawing.Point(598, 487);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(190, 13);
            this.label11.TabIndex = 198;
            this.label11.Text = "Filtro (Escriba el valor y precione Enter)";
            // 
            // txbBusqueda
            // 
            this.txbBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbBusqueda.Location = new System.Drawing.Point(564, 503);
            this.txbBusqueda.Name = "txbBusqueda";
            this.txbBusqueda.Size = new System.Drawing.Size(224, 20);
            this.txbBusqueda.TabIndex = 197;
            this.txbBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbBusqueda_KeyDown);
            // 
            // frmNuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 598);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txbBusqueda);
            this.Controls.Add(this.gunaTileButton5);
            this.Controls.Add(this.gunaTileButton4);
            this.Controls.Add(this.gunaTileButton2);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.gbxNuser);
            this.Controls.Add(this.gunaTileButton1);
            this.Name = "frmNuevoUsuario";
            this.ShowIcon = false;
            this.Text = "Alta de Usuario";
            this.Load += new System.EventHandler(this.frmNuevoUsuario_Load);
            this.gbxNuser.ResumeLayout(false);
            this.gbxNuser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaTileButton gunaTileButton1;
        private Guna.UI.WinForms.GunaLineTextBox txbUsuario;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaLineTextBox txbNombre;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaLineTextBox txbContrasena;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaLineTextBox txbCorreo;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaLineTextBox txbTelefono;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI.WinForms.GunaLineTextBox txbRol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbxNuser;
        private Guna.UI.WinForms.GunaDataGridView dgvUsuarios;
        private Guna.UI.WinForms.GunaLineTextBox txbSucursal;
        private System.Windows.Forms.Label label8;
        private Guna.UI.WinForms.GunaLineTextBox txbCliente;
        private Guna.UI.WinForms.GunaTileButton gunaTileButton2;
        private Guna.UI.WinForms.GunaTileButton gunaTileButton3;
        private Guna.UI.WinForms.GunaTileButton gunaTileButton4;
        private Guna.UI.WinForms.GunaTileButton gunaTileButton5;
        private System.Windows.Forms.Label label9;
        private Guna.UI.WinForms.GunaLineTextBox txbMaster;
        private Guna.UI.WinForms.GunaLineTextBox txbUid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbBusqueda;
    }
}