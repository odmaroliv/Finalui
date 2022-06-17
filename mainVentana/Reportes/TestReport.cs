using mainVentana.reportes.vmreportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;
using Datos.ViewModels.Reportes;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace mainVentana.Reportes
{
    public partial class TestReport : Form
    {
        public string repTEntrada;
        public string repTOrigen;
        public string repTdest;
        public string repTCliente;
        public string repTEtiqueta;
        public string repTFecha;
        public string repTAlias;
        public string repTZona;
        public string repTZonaNum;
        public string repTBar;
        public List<vmEtiquetasReporte> lstrep = new List<vmEtiquetasReporte>();

        public TestReport()
        {
            InitializeComponent();
        }

        private void TestReport_Load(object sender, EventArgs e)
        {

            CargaParam();



            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void CargaParam()
        {

            //vmEtiquetasReporteBindingSource.DataSource = lstrep;

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("repOrigen", repTOrigen));
            reportParameters.Add(new ReportParameter("repDestino", repTdest));
            reportParameters.Add(new ReportParameter("repCliente", repTCliente));
            reportParameters.Add(new ReportParameter("repEtiqueta", repTEtiqueta));
            reportParameters.Add(new ReportParameter("repEntrada", repTEntrada));
            reportParameters.Add(new ReportParameter("repFecha", repTFecha));
            
            reportParameters.Add(new ReportParameter("repAlias", repTAlias));
            reportParameters.Add(new ReportParameter("repZona", repTZona));

            reportParameters.Add(new ReportParameter("repBarCode", new Uri(repTBar).AbsoluteUri));

            //cargaimg();

            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            


            this.reportViewer1.RefreshReport();
        }

        private void cargaimg()
        {
            FileInfo fi = new FileInfo(repTBar);
            //ReportParameter pName = new ReportParameter("pName", fi.Name);
            ReportParameter repBarCode = new ReportParameter("repBarCode", new Uri(repTBar).AbsoluteUri);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repBarCode });
            //this.reportViewer1.RefreshReport();
        }



    }
}
