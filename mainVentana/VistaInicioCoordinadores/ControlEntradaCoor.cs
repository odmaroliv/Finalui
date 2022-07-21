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
        public ControlEntradaCoor()
        {
            InitializeComponent();
        }

        private void lblEntrada_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           // Clipboard.SetText(lblEntrada.Text);
        }


        public delegate Task pasar2(string id);
        public event pasar2 pasado2;


        private void button1_Click_1(object sender, EventArgs e)
        {
            
            string tex = button1.Text;
            Clipboard.SetText(tex);
            pasado2(tex);

        }
    }
}
