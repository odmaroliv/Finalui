using Datos.ViewModels.Reportes.Bill;
using mainVentana.Reportes.rbill;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaBill
{
    public partial class frmMBill : Form
    {
        public frmMBill()
        {
            InitializeComponent();
        }

        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel();


        }

        private void AbrirFormEnPanel()
        {
            frmOperSalidas frm = new frmOperSalidas();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void gunaGradientTileButton2_Click(object sender, EventArgs e)
        {/* using (frmBillVisorImp bill = new frmBillVisorImp())
            {
                bill.from = "Cliente";
                bill.fromCalle = "Hola";
                bill.fromDir1 = "Call1";
                bill.fromDir2 = "Call2";
                bill.Coordinador = "Coordinador";
                bill.Note = "Notas";
                bill.Cellphone = "6656665644";
                bill.to = "Para";
                bill.toCalle = "Callw";
                bill.toDir1 = "ToDir1";
                bill.toDir2 = "Calle 2";
                bill.ShipDate = "12-12-12";
                bill.totalCases = "2";

                var lst = new List<vmBillOfTable>();    

                for (int i = 0; i < 500; i++)
                {
                    lst.Add(new vmBillOfTable { Description = "Helloooo " + i.ToString(), id = i.ToString() }); ;
                }

                bill.lst = lst;
                bill.ShowDialog();
            }*/
        }
    }
}
