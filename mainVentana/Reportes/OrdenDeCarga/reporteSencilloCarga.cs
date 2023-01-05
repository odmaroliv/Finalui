using Datos.ViewModels.Carga;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.Reportes.OrdenDeCarga
{
    public partial class reporteSencilloCarga : Form
    {
        public string sucursalInicial;
        public string tipoDeOperacion;
        public string sucursalDestino;
        public string numeroDeCarga;
        public string fechaDeAlta;
        public string referencia;
        public string fechaCierre;
        public string horaCierre;
        public string fechaImprecion;
      

        public List<vmEntradasEnCarga> lst = new List<vmEntradasEnCarga>();


        public reporteSencilloCarga()
        {
            InitializeComponent();
        }

        private void reporteSencilloCarga_Load(object sender, EventArgs e)
        {
            CargaParam();

            this.reportViewer1.RefreshReport();


        
        }


        private void CargaParam()
        {

            //vmEtiquetasReporteBindingSource.DataSource = lstrep;


            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("sucursalInicial", sucursalInicial));
            reportParameters.Add(new ReportParameter("sucursalDestino", sucursalDestino));
            reportParameters.Add(new ReportParameter("referencia", referencia));
            reportParameters.Add(new ReportParameter("numeroDeCarga", numeroDeCarga));
            reportParameters.Add(new ReportParameter("fechaCierre", fechaCierre));
            reportParameters.Add(new ReportParameter("fechaDeAlta", fechaDeAlta));
            reportParameters.Add(new ReportParameter("horaCierre", horaCierre));
            reportParameters.Add(new ReportParameter("fechaImprecion", fechaImprecion));
            reportParameters.Add(new ReportParameter("tipoDeOperacion", tipoDeOperacion));
            

         

            ReportDataSource rs = new ReportDataSource();

            //establecemos el origen de datos a la lista primero se creo el origen en el archibo rdlc
            rs.Name= "tablaEntradasEnCarga";
            rs.Value = lst;
            reportViewer1.LocalReport.DataSources.Add(rs);
            
       
            this.reportViewer1.RefreshReport();



           
            this.reportViewer1.LocalReport.SetParameters(reportParameters);



            this.reportViewer1.RefreshReport();
        }

    }
}
