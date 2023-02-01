using Datos.ViewModels.Coord;
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

namespace mainVentana.Reportes.Cotizaciones.cotToPDF
{
    public partial class frmToRepCot : Form
    {

        public string quote;
        public string date;
        public string referencia;
        public string entradas;
        public string pedimento;
        public string paridad;
        public string vGod;
        public string vArn;
        public string cliente;
        public string vOfGoods;
        public string subTotal;
        public string iva;
        public string sumGoodsTaxesServices;
        public string toPayArn;
        public string sucursal;
        public List<vmInfoTablaCot> lst = new List<vmInfoTablaCot>();



        public frmToRepCot()
        {
            InitializeComponent();
         
        }

        private void frmToRepCot_Load(object sender, EventArgs e)
        {
            CargaParam();
            this.reportViewer1.RefreshReport();
        }

        private void CargaParam()
        {

            //vmEtiquetasReporteBindingSource.DataSource = lstrep;


            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("quote", quote));
            reportParameters.Add(new ReportParameter("date", date));
            reportParameters.Add(new ReportParameter("referencia", referencia));
            reportParameters.Add(new ReportParameter("entradas", entradas));
            reportParameters.Add(new ReportParameter("pedimento", pedimento));
            reportParameters.Add(new ReportParameter("paridad", paridad));
            reportParameters.Add(new ReportParameter("vGod", vGod));
            reportParameters.Add(new ReportParameter("vArn", vArn));
            reportParameters.Add(new ReportParameter("cliente", cliente));
            reportParameters.Add(new ReportParameter("vOfGoods", vOfGoods));
            reportParameters.Add(new ReportParameter("subTotal", subTotal));
            reportParameters.Add(new ReportParameter("iva", iva));
            reportParameters.Add(new ReportParameter("sumGoodsTaxesServices", sumGoodsTaxesServices));
            reportParameters.Add(new ReportParameter("toPayArn", toPayArn));
            reportParameters.Add(new ReportParameter("sucursal", sucursal));



            ReportDataSource rs = new ReportDataSource();

            //establecemos el origen de datos a la lista primero se creo el origen en el archibo rdlc
            rs.Name = "tableinfotabla";
            rs.Value = lst;
            reportViewer1.LocalReport.DataSources.Add(rs);


            this.reportViewer1.RefreshReport();




            this.reportViewer1.LocalReport.SetParameters(reportParameters);



            this.reportViewer1.RefreshReport();
        }


    }
    
}
