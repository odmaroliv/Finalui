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
        public string repProveedor;
        public string repTCliente;
        public string repUnidades;
        public string repTFecha;
        public string repTipoUnidades;
        public string repNumFlete;
        public string repOrdCompra;
        public string repNumBultos;
        public string repContMercancia;
        public string repNotas;
        public string repCodigoTexto; // "origen-entrada"
        public string repBarPath;     // ruta del PNG del código de barras
        // public List<vmEtiquetasReporte> lstrep = new List<vmEtiquetasReporte>();

        public TestReport()
        {
            InitializeComponent();
        }

        private void TestReport_Load(object sender, EventArgs e)
        {

            CargaParam();



            this.reportViewer1.RefreshReport();
           
        }

        private void CargaParam()
        {

            //vmEtiquetasReporteBindingSource.DataSource = lstrep;

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("repOrigen", repTOrigen));
            reportParameters.Add(new ReportParameter("repProveedor", repProveedor));
            reportParameters.Add(new ReportParameter("repCliente", repTCliente));
            reportParameters.Add(new ReportParameter("repUnidades", repUnidades));
            reportParameters.Add(new ReportParameter("repEntrada", repTEntrada));
            reportParameters.Add(new ReportParameter("repFecha", repTFecha));
            reportParameters.Add(new ReportParameter("repOrdCompra", repOrdCompra));
            reportParameters.Add(new ReportParameter("repNumFlete", repNumFlete));
            reportParameters.Add(new ReportParameter("repTipoUnidades", repTipoUnidades));
            reportParameters.Add(new ReportParameter("repNumBultos", repNumBultos));
            reportParameters.Add(new ReportParameter("repContMercancia", repContMercancia));
            reportParameters.Add(new ReportParameter("repNotas", repNotas));
            reportParameters.Add(new ReportParameter("repBarCode", new Uri(repBarPath).AbsoluteUri));


            //new ReportParameter("repBarCode", new Uri(repBarPath).AbsoluteUri);
            // reportParameters.Add(new ReportParameter("repBarCode", new Uri(repTBar).AbsoluteUri));

            //cargaimg();

            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            


            this.reportViewer1.RefreshReport();
        }

       /* private void cargaimg()
        {
            FileInfo fi = new FileInfo(repTBar);
            //ReportParameter pName = new ReportParameter("pName", fi.Name);
            ReportParameter repBarCode = new ReportParameter("repBarCode", new Uri(repTBar).AbsoluteUri);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repBarCode });
            //this.reportViewer1.RefreshReport();
        }*/



    }
}
