namespace mainVentana.vistaReportes
{
    partial class frmVentaPequeña
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label14 = new System.Windows.Forms.Label();
            this.tipoOper = new System.Windows.Forms.ComboBox();
            this.gunaElipsePanel1 = new Guna.UI.WinForms.GunaElipsePanel();
            this.gunaElipsePanel2 = new Guna.UI.WinForms.GunaElipsePanel();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.gunaElipsePanel1.SuspendLayout();
            this.gunaElipsePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.chart1.Location = new System.Drawing.Point(12, 85);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Label = "SD";
            series1.Name = "SD";
            series2.ChartArea = "ChartArea1";
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Label = "TJ";
            series2.Name = "TJ";
            series3.ChartArea = "ChartArea1";
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.Label = "SD";
            series3.Name = "CSL";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(461, 286);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Valor Arnian por Sucursal";
            this.chart1.Titles.Add(title1);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(57, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 22);
            this.label14.TabIndex = 107;
            this.label14.Text = "Tipo de Operacion:";
            // 
            // tipoOper
            // 
            this.tipoOper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoOper.FormattingEnabled = true;
            this.tipoOper.Items.AddRange(new object[] {
            "SD",
            "TJ",
            "CSL"});
            this.tipoOper.Location = new System.Drawing.Point(60, 42);
            this.tipoOper.Margin = new System.Windows.Forms.Padding(2);
            this.tipoOper.Name = "tipoOper";
            this.tipoOper.Size = new System.Drawing.Size(225, 28);
            this.tipoOper.TabIndex = 106;
            this.tipoOper.SelectedIndexChanged += new System.EventHandler(this.tipoOper_SelectedIndexChanged);
            // 
            // gunaElipsePanel1
            // 
            this.gunaElipsePanel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel1.BaseColor = System.Drawing.Color.White;
            this.gunaElipsePanel1.Controls.Add(this.chart1);
            this.gunaElipsePanel1.Controls.Add(this.label14);
            this.gunaElipsePanel1.Controls.Add(this.tipoOper);
            this.gunaElipsePanel1.Location = new System.Drawing.Point(31, 24);
            this.gunaElipsePanel1.Name = "gunaElipsePanel1";
            this.gunaElipsePanel1.Radius = 20;
            this.gunaElipsePanel1.Size = new System.Drawing.Size(485, 384);
            this.gunaElipsePanel1.TabIndex = 109;
            // 
            // gunaElipsePanel2
            // 
            this.gunaElipsePanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaElipsePanel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel2.BaseColor = System.Drawing.Color.White;
            this.gunaElipsePanel2.Controls.Add(this.chart2);
            this.gunaElipsePanel2.Location = new System.Drawing.Point(522, 24);
            this.gunaElipsePanel2.Name = "gunaElipsePanel2";
            this.gunaElipsePanel2.Radius = 20;
            this.gunaElipsePanel2.Size = new System.Drawing.Size(675, 384);
            this.gunaElipsePanel2.TabIndex = 110;
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.chart2.Location = new System.Drawing.Point(12, 85);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.Label = "SD";
            series4.Name = "SD";
            series5.ChartArea = "ChartArea1";
            series5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series5.Label = "TJ";
            series5.Name = "TJ";
            series6.ChartArea = "ChartArea1";
            series6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series6.Label = "SD";
            series6.Name = "CSL";
            this.chart2.Series.Add(series4);
            this.chart2.Series.Add(series5);
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(647, 286);
            this.chart2.TabIndex = 0;
            this.chart2.Text = "chart2";
            title2.Name = "Title1";
            title2.Text = "Valor por Coordinador";
            this.chart2.Titles.Add(title2);
            // 
            // frmVentaPequeña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 432);
            this.Controls.Add(this.gunaElipsePanel2);
            this.Controls.Add(this.gunaElipsePanel1);
            this.Name = "frmVentaPequeña";
            this.Text = "frmVentaPequeña";
            this.Load += new System.EventHandler(this.frmVentaPequeña_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.gunaElipsePanel1.ResumeLayout(false);
            this.gunaElipsePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox tipoOper;
        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel1;
        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}