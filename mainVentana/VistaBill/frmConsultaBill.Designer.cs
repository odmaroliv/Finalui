namespace mainVentana.VistaBill
{
    partial class frmConsultaBill
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxTo = new System.Windows.Forms.GroupBox();
            this.lblToZip = new System.Windows.Forms.Label();
            this.lblToLocalidad = new System.Windows.Forms.Label();
            this.lblToColonia = new System.Windows.Forms.Label();
            this.lblToCalle = new System.Windows.Forms.Label();
            this.lblToNombre = new System.Windows.Forms.Label();
            this.gbxFrom = new System.Windows.Forms.GroupBox();
            this.lblFromZip = new System.Windows.Forms.Label();
            this.lblFromLocalidad = new System.Windows.Forms.Label();
            this.lblFromColonia = new System.Windows.Forms.Label();
            this.lblFromCalle = new System.Windows.Forms.Label();
            this.lblFromNombre = new System.Windows.Forms.Label();
            this.gbxGeneral = new System.Windows.Forms.GroupBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.SucCombo = new System.Windows.Forms.GroupBox();
            this.rCa = new System.Windows.Forms.RadioButton();
            this.rTj = new System.Windows.Forms.RadioButton();
            this.rSd = new System.Windows.Forms.RadioButton();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.dgvEntEnCarga = new Guna.UI.WinForms.GunaDataGridView();
            this.iconButton10 = new FontAwesome.Sharp.IconButton();
            this.txbBuscaBill = new Guna.UI.WinForms.GunaTextBox();
            this.gridGroupingControl1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.lblCantida = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbxTo.SuspendLayout();
            this.gbxFrom.SuspendLayout();
            this.gbxGeneral.SuspendLayout();
            this.SucCombo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntEnCarga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupingControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblCantida);
            this.panel1.Controls.Add(this.gbxTo);
            this.panel1.Controls.Add(this.gbxFrom);
            this.panel1.Controls.Add(this.gbxGeneral);
            this.panel1.Controls.Add(this.SucCombo);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.dgvEntEnCarga);
            this.panel1.Controls.Add(this.iconButton10);
            this.panel1.Controls.Add(this.txbBuscaBill);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 426);
            this.panel1.TabIndex = 0;
            // 
            // gbxTo
            // 
            this.gbxTo.Controls.Add(this.lblToZip);
            this.gbxTo.Controls.Add(this.lblToLocalidad);
            this.gbxTo.Controls.Add(this.lblToColonia);
            this.gbxTo.Controls.Add(this.lblToCalle);
            this.gbxTo.Controls.Add(this.lblToNombre);
            this.gbxTo.Location = new System.Drawing.Point(235, 70);
            this.gbxTo.Name = "gbxTo";
            this.gbxTo.Size = new System.Drawing.Size(221, 77);
            this.gbxTo.TabIndex = 153;
            this.gbxTo.TabStop = false;
            this.gbxTo.Text = "To";
            // 
            // lblToZip
            // 
            this.lblToZip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToZip.AutoSize = true;
            this.lblToZip.Location = new System.Drawing.Point(183, 55);
            this.lblToZip.Name = "lblToZip";
            this.lblToZip.Size = new System.Drawing.Size(0, 13);
            this.lblToZip.TabIndex = 9;
            // 
            // lblToLocalidad
            // 
            this.lblToLocalidad.AutoSize = true;
            this.lblToLocalidad.Location = new System.Drawing.Point(4, 55);
            this.lblToLocalidad.Name = "lblToLocalidad";
            this.lblToLocalidad.Size = new System.Drawing.Size(0, 13);
            this.lblToLocalidad.TabIndex = 8;
            // 
            // lblToColonia
            // 
            this.lblToColonia.AutoSize = true;
            this.lblToColonia.Location = new System.Drawing.Point(4, 42);
            this.lblToColonia.Name = "lblToColonia";
            this.lblToColonia.Size = new System.Drawing.Size(0, 13);
            this.lblToColonia.TabIndex = 7;
            // 
            // lblToCalle
            // 
            this.lblToCalle.AutoSize = true;
            this.lblToCalle.Location = new System.Drawing.Point(4, 29);
            this.lblToCalle.Name = "lblToCalle";
            this.lblToCalle.Size = new System.Drawing.Size(0, 13);
            this.lblToCalle.TabIndex = 6;
            // 
            // lblToNombre
            // 
            this.lblToNombre.AutoSize = true;
            this.lblToNombre.Location = new System.Drawing.Point(4, 16);
            this.lblToNombre.Name = "lblToNombre";
            this.lblToNombre.Size = new System.Drawing.Size(0, 13);
            this.lblToNombre.TabIndex = 5;
            // 
            // gbxFrom
            // 
            this.gbxFrom.Controls.Add(this.lblFromZip);
            this.gbxFrom.Controls.Add(this.lblFromLocalidad);
            this.gbxFrom.Controls.Add(this.lblFromColonia);
            this.gbxFrom.Controls.Add(this.lblFromCalle);
            this.gbxFrom.Controls.Add(this.lblFromNombre);
            this.gbxFrom.Location = new System.Drawing.Point(18, 70);
            this.gbxFrom.Name = "gbxFrom";
            this.gbxFrom.Size = new System.Drawing.Size(212, 77);
            this.gbxFrom.TabIndex = 152;
            this.gbxFrom.TabStop = false;
            this.gbxFrom.Text = "From";
            // 
            // lblFromZip
            // 
            this.lblFromZip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromZip.AutoSize = true;
            this.lblFromZip.Location = new System.Drawing.Point(171, 55);
            this.lblFromZip.Name = "lblFromZip";
            this.lblFromZip.Size = new System.Drawing.Size(0, 13);
            this.lblFromZip.TabIndex = 4;
            // 
            // lblFromLocalidad
            // 
            this.lblFromLocalidad.AutoSize = true;
            this.lblFromLocalidad.Location = new System.Drawing.Point(6, 55);
            this.lblFromLocalidad.Name = "lblFromLocalidad";
            this.lblFromLocalidad.Size = new System.Drawing.Size(0, 13);
            this.lblFromLocalidad.TabIndex = 3;
            // 
            // lblFromColonia
            // 
            this.lblFromColonia.AutoSize = true;
            this.lblFromColonia.Location = new System.Drawing.Point(6, 42);
            this.lblFromColonia.Name = "lblFromColonia";
            this.lblFromColonia.Size = new System.Drawing.Size(0, 13);
            this.lblFromColonia.TabIndex = 2;
            // 
            // lblFromCalle
            // 
            this.lblFromCalle.AutoSize = true;
            this.lblFromCalle.Location = new System.Drawing.Point(6, 29);
            this.lblFromCalle.Name = "lblFromCalle";
            this.lblFromCalle.Size = new System.Drawing.Size(0, 13);
            this.lblFromCalle.TabIndex = 1;
            // 
            // lblFromNombre
            // 
            this.lblFromNombre.AutoSize = true;
            this.lblFromNombre.Location = new System.Drawing.Point(6, 16);
            this.lblFromNombre.Name = "lblFromNombre";
            this.lblFromNombre.Size = new System.Drawing.Size(0, 13);
            this.lblFromNombre.TabIndex = 0;
            // 
            // gbxGeneral
            // 
            this.gbxGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxGeneral.Controls.Add(this.lblTel);
            this.gbxGeneral.Location = new System.Drawing.Point(462, 70);
            this.gbxGeneral.Name = "gbxGeneral";
            this.gbxGeneral.Size = new System.Drawing.Size(289, 77);
            this.gbxGeneral.TabIndex = 151;
            this.gbxGeneral.TabStop = false;
            this.gbxGeneral.Text = "General";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(6, 16);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(0, 13);
            this.lblTel.TabIndex = 0;
            // 
            // SucCombo
            // 
            this.SucCombo.Controls.Add(this.rCa);
            this.SucCombo.Controls.Add(this.rTj);
            this.SucCombo.Controls.Add(this.rSd);
            this.SucCombo.Location = new System.Drawing.Point(18, 16);
            this.SucCombo.Name = "SucCombo";
            this.SucCombo.Size = new System.Drawing.Size(237, 48);
            this.SucCombo.TabIndex = 150;
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
            this.rSd.CheckedChanged += new System.EventHandler(this.rSd_CheckedChanged);
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
            this.btnImprimir.Location = new System.Drawing.Point(502, 369);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(253, 51);
            this.btnImprimir.TabIndex = 34;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // dgvEntEnCarga
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvEntEnCarga.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEntEnCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEntEnCarga.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEntEnCarga.BackgroundColor = System.Drawing.Color.White;
            this.dgvEntEnCarga.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEntEnCarga.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEntEnCarga.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEntEnCarga.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEntEnCarga.ColumnHeadersHeight = 30;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEntEnCarga.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvEntEnCarga.EnableHeadersVisualStyles = false;
            this.dgvEntEnCarga.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEntEnCarga.Location = new System.Drawing.Point(18, 152);
            this.dgvEntEnCarga.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEntEnCarga.Name = "dgvEntEnCarga";
            this.dgvEntEnCarga.RowHeadersVisible = false;
            this.dgvEntEnCarga.RowHeadersWidth = 51;
            this.dgvEntEnCarga.RowTemplate.Height = 30;
            this.dgvEntEnCarga.RowTemplate.ReadOnly = true;
            this.dgvEntEnCarga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntEnCarga.Size = new System.Drawing.Size(733, 212);
            this.dgvEntEnCarga.TabIndex = 33;
            this.dgvEntEnCarga.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgvEntEnCarga.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEntEnCarga.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvEntEnCarga.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvEntEnCarga.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvEntEnCarga.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvEntEnCarga.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvEntEnCarga.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEntEnCarga.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvEntEnCarga.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvEntEnCarga.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvEntEnCarga.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvEntEnCarga.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvEntEnCarga.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvEntEnCarga.ThemeStyle.ReadOnly = false;
            this.dgvEntEnCarga.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEntEnCarga.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEntEnCarga.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvEntEnCarga.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvEntEnCarga.ThemeStyle.RowsStyle.Height = 30;
            this.dgvEntEnCarga.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEntEnCarga.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // iconButton10
            // 
            this.iconButton10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton10.BackColor = System.Drawing.Color.White;
            this.iconButton10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton10.Enabled = false;
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
            this.iconButton10.Location = new System.Drawing.Point(714, 35);
            this.iconButton10.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton10.Name = "iconButton10";
            this.iconButton10.Size = new System.Drawing.Size(26, 18);
            this.iconButton10.TabIndex = 14;
            this.iconButton10.UseVisualStyleBackColor = false;
            // 
            // txbBuscaBill
            // 
            this.txbBuscaBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbBuscaBill.BackColor = System.Drawing.Color.Transparent;
            this.txbBuscaBill.BaseColor = System.Drawing.Color.White;
            this.txbBuscaBill.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(238)))), ((int)(((byte)(254)))));
            this.txbBuscaBill.BorderSize = 1;
            this.txbBuscaBill.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbBuscaBill.FocusedBaseColor = System.Drawing.Color.White;
            this.txbBuscaBill.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.txbBuscaBill.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txbBuscaBill.Font = new System.Drawing.Font("Trebuchet MS", 18F);
            this.txbBuscaBill.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txbBuscaBill.Location = new System.Drawing.Point(547, 26);
            this.txbBuscaBill.Margin = new System.Windows.Forms.Padding(2);
            this.txbBuscaBill.Name = "txbBuscaBill";
            this.txbBuscaBill.PasswordChar = '\0';
            this.txbBuscaBill.Radius = 10;
            this.txbBuscaBill.Size = new System.Drawing.Size(204, 38);
            this.txbBuscaBill.TabIndex = 13;
            this.txbBuscaBill.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gunaTextBox2_KeyDown);
            // 
            // gridGroupingControl1
            // 
            this.gridGroupingControl1.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gridGroupingControl1.BackColor = System.Drawing.SystemColors.Window;
            this.gridGroupingControl1.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Office2016;
            this.gridGroupingControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2016White;
            this.gridGroupingControl1.Location = new System.Drawing.Point(192, 61);
            this.gridGroupingControl1.Name = "gridGroupingControl1";
            this.gridGroupingControl1.Office2016ScrollBarsColorScheme = Syncfusion.Windows.Forms.ScrollBarOffice2016ColorScheme.White;
            this.gridGroupingControl1.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridGroupingControl1.Size = new System.Drawing.Size(130, 80);
            this.gridGroupingControl1.TabIndex = 16;
            this.gridGroupingControl1.TableDescriptor.AllowNew = false;
            this.gridGroupingControl1.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 28;
            this.gridGroupingControl1.TableDescriptor.TableOptions.RecordRowHeight = 28;
            this.gridGroupingControl1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gridGroupingControl1.TableOptions.SelectionTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.gridGroupingControl1.Text = "gridGroupingControl1";
            this.gridGroupingControl1.UseRightToLeftCompatibleTextBox = true;
            this.gridGroupingControl1.VersionInfo = "21.1460.35";
            // 
            // lblCantida
            // 
            this.lblCantida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantida.AutoSize = true;
            this.lblCantida.Location = new System.Drawing.Point(24, 382);
            this.lblCantida.Name = "lblCantida";
            this.lblCantida.Size = new System.Drawing.Size(0, 13);
            this.lblCantida.TabIndex = 1;
            // 
            // frmConsultaBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "frmConsultaBill";
            this.ShowIcon = false;
            this.Text = "Consulta Bill";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbxTo.ResumeLayout(false);
            this.gbxTo.PerformLayout();
            this.gbxFrom.ResumeLayout(false);
            this.gbxFrom.PerformLayout();
            this.gbxGeneral.ResumeLayout(false);
            this.gbxGeneral.PerformLayout();
            this.SucCombo.ResumeLayout(false);
            this.SucCombo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntEnCarga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupingControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton10;
        public Guna.UI.WinForms.GunaTextBox txbBuscaBill;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridGroupingControl1;
        private Guna.UI.WinForms.GunaDataGridView dgvEntEnCarga;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private System.Windows.Forms.GroupBox SucCombo;
        private System.Windows.Forms.RadioButton rCa;
        private System.Windows.Forms.RadioButton rTj;
        private System.Windows.Forms.RadioButton rSd;
        private System.Windows.Forms.GroupBox gbxGeneral;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.GroupBox gbxTo;
        private System.Windows.Forms.Label lblToZip;
        private System.Windows.Forms.Label lblToLocalidad;
        private System.Windows.Forms.Label lblToColonia;
        private System.Windows.Forms.Label lblToCalle;
        private System.Windows.Forms.Label lblToNombre;
        private System.Windows.Forms.GroupBox gbxFrom;
        private System.Windows.Forms.Label lblFromZip;
        private System.Windows.Forms.Label lblFromLocalidad;
        private System.Windows.Forms.Label lblFromColonia;
        private System.Windows.Forms.Label lblFromCalle;
        private System.Windows.Forms.Label lblFromNombre;
        private System.Windows.Forms.Label lblCantida;
    }
}