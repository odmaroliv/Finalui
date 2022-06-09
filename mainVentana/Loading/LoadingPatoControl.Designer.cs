namespace mainVentana.Loading
{
    partial class LoadingPatoControl
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
            this.pbxPatoLoading = new AForge.Controls.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPatoLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxPatoLoading
            // 
            this.pbxPatoLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxPatoLoading.Image = global::mainVentana.Properties.Resources.cargandopatogif;
            this.pbxPatoLoading.Location = new System.Drawing.Point(0, 0);
            this.pbxPatoLoading.Name = "pbxPatoLoading";
            this.pbxPatoLoading.Size = new System.Drawing.Size(150, 180);
            this.pbxPatoLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxPatoLoading.TabIndex = 0;
            this.pbxPatoLoading.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Image = global::mainVentana.Properties.Resources.cargador;
            this.pictureBox1.Location = new System.Drawing.Point(0, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // LoadingPatoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pbxPatoLoading);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LoadingPatoControl";
            this.Size = new System.Drawing.Size(150, 259);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPatoLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.PictureBox pbxPatoLoading;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
