using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Vanara.PInvoke.Ole32.PROPERTYKEY.System;

namespace mainVentana.Reportes.Entrega
{
    public partial class frmComprobanteEntImp : Form
    {
        public string nArnian;
        public string fechaEntrega;
        public string recibio;
        public string cordsEnt;

        public byte[] imgSignature;



        public frmComprobanteEntImp()
        {
            InitializeComponent();
        }

        private void frmComprobanteEntImp_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            CargaParam();

        }

        private void CargaParam()
        {

            //vmEtiquetasReporteBindingSource.DataSource = lstrep;


            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("nArnian", nArnian));
            reportParameters.Add(new ReportParameter("fechaEntrega", fechaEntrega));
            reportParameters.Add(new ReportParameter("recibio", recibio));
            reportParameters.Add(new ReportParameter("cordsEnt", cordsEnt));

            //this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("NombreDataSource", objetoFuenteDeDatos));

            if (imgSignature != null)
            {
                ReportParameter imagenParam = new ReportParameter("imgSignature", Convert.ToBase64String(imgSignature));
                reportParameters.Add(imagenParam);
            }

            //  this.reportViewer1.LocalReport.SetParameters(reportParameters);

            this.reportViewer1.RefreshReport();
        }


    }
}
