using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainVentana.VistaInicioCoordinadores
{
    public partial class ControlEntradaCoor : UserControl
    {

        //
        //El evento y delegado para manda a llamar a la busqueda en la tabla principal
        //
        public delegate Task pasar2(string id);
        public event pasar2 pasado2;
        /// <summary>
        /// Delegado para hacer un refresh de los paneles de los coordinadores
        /// </summary>
        public delegate Task refrescarcord();
        public event refrescarcord refrescado;

        public ControlEntradaCoor()
        {
            InitializeComponent();
        }

        private void lblEntrada_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           // Clipboard.SetText(lblEntrada.Text);
        }


        


        private void button1_Click_1(object sender, EventArgs e)
        {
            
            string tex = button1.Text;
            Clipboard.SetText(tex);
            pasado2(tex);

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            string tex = button1.Text;
            frmInfoEntradaCords frm = new frmInfoEntradaCords();
            frm.ShowDialog();
            frm.Dispose();
            refrescado();
        }

        private void ControlEntradaCoor_Load(object sender, EventArgs e)
        {
            nudValArn.Controls[0].Visible = false;
            nudValFac.Controls[0].Visible = false;
        }

        private void nudValArn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                AltasBD bd = new AltasBD();
                bd.ActualizaValores(button1.Text.Trim(), txbSuc.Text.Trim(), nudValFac.Value.ToString(), nudValArn.Value.ToString());
            }
        }
    }
}
