using Datos.ViewModels.Reportes.Bill;
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

namespace mainVentana.Reportes.rbill
{
    public partial class frmBillVisorImp : Form
    {

        public string fromCalle;
        public string fromDir1;
        public string fromDir2;
        public string Note;
        public string Cellphone;
        public string toCalle;
        public string toDir1;
        public string toDir2;
        public string from;
        public string to;
        public string ShipDate;
        public string totalCases;
        public string Coordinador;
        public List<vmBillOfTable> lst = new List<vmBillOfTable>();
        public frmBillVisorImp()
        {
            InitializeComponent();
        }

        private void frmBillVisorImp_Load(object sender, EventArgs e)
        {
            CargaParam();
            this.reportViewer1.RefreshReport();
        }
        private void CargaParam()
        {

            //vmEtiquetasReporteBindingSource.DataSource = lstrep;


            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("fromCalle", fromCalle));
            reportParameters.Add(new ReportParameter("fromDir1", fromDir1));
            reportParameters.Add(new ReportParameter("fromDir2", fromDir2));
            reportParameters.Add(new ReportParameter("Note", Note));
            reportParameters.Add(new ReportParameter("Cellphone", Cellphone));
            reportParameters.Add(new ReportParameter("toCalle", toCalle));
            reportParameters.Add(new ReportParameter("toDir1", toDir1));
            reportParameters.Add(new ReportParameter("toDir2", toDir2));
            reportParameters.Add(new ReportParameter("from", from));
            reportParameters.Add(new ReportParameter("to", to));
            reportParameters.Add(new ReportParameter("ShipDate", ShipDate));
            reportParameters.Add(new ReportParameter("totalCases", totalCases));
            reportParameters.Add(new ReportParameter("Coordinador", Coordinador));




            ReportDataSource rs = new ReportDataSource();

            //establecemos el origen de datos a la lista primero se creo el origen en el archibo rdlc
            rs.Name = "itemsList";
            rs.Value = lst;
            reportViewer1.LocalReport.DataSources.Add(rs);

            
            this.reportViewer1.RefreshReport();




            this.reportViewer1.LocalReport.SetParameters(reportParameters);



            this.reportViewer1.RefreshReport();
        }
    }
}
