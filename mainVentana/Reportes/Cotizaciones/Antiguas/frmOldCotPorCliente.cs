﻿using mainVentana.VistaEntrada;
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

namespace mainVentana.Reportes.Cotizaciones.Antiguas
{
    public partial class frmOldCotPorCliente : Form
    {

        private int datparseado;
        private string _nCotD7 = "";
        private string _oper = "Cliente"; 

        public frmOldCotPorCliente()
        {
            InitializeComponent();
        }






        public async Task refresh(string id)
        {

            //txbComent.Text = "";
            string sucursal = default;



            if (rSd.Checked == true)
            {
                sucursal = "SD";
            }
            if (rTj.Checked == true)
            {
                sucursal = "TJ";
            }
            if (rCa.Checked == true)
            {
                sucursal = "CSL";
            }

            Negocios.NGCotizacion.accesoCotizaciones dt = new Negocios.NGCotizacion.accesoCotizaciones();
            gunaDataGridView1.DataSource = null;
            var lls = await dt.BuscarCitizacionPorId(id, sucursal);
            gunaDataGridView1.DataSource = lls;
            if (gunaDataGridView1.RowCount <= 0)
            {
                MessageBox.Show("No se encontraron datos");
                return;
            }
        }

        private async void gunaTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               ValidabPrincipal();
                string id = gunaTextBox2.Text;
                await refresh(_nCotD7);
               // await Task.Run(() => { Thread.Sleep(1000); });

                e.SuppressKeyPress = true;
            }
        }
        private void ValidabPrincipal()
        {
            if (gunaTextBox2.Text == "")
            {
                MessageBox.Show("El campo de busqueda esta vacio!");
                return;
            }

            bool bent = Int32.TryParse(gunaTextBox2.Text, out datparseado);
            if (bent == true)
            {
                gunaTextBox2.Text = datparseado.ToString("D7");
                _nCotD7 = datparseado.ToString("D7");
            }
            else
            {
                MessageBox.Show("Las entradas tienen que ser un codigo numerico, y no pueden contener letras");
                return;
            }
        }

        private void gunaTileButton1_Click(object sender, EventArgs e)
        {

            using (VistaEntrada.BusquedasEnt buscador = new BusquedasEnt())
            {
                buscador.label2.Text = "CLIENTE";
                buscador.pasado += new BusquedasEnt.pasar(moverinfo);
                buscador.ShowDialog();
                buscador.pasado -= new BusquedasEnt.pasar(moverinfo);
            }

        }
        public void moverinfo(string dato, string dato2, string dato3, string dato4, string dato5, string dato6, string dato7, string correoCliente, int bandera) //cambia los datos de los textbox alias y clientes, la bandera dependera de la manera en la que se haya abierto el frm buscar, 0 clientes 1 alias, ADEMAS tambien sirve para cambiar el campo de cord
        {
            //coreoClientes = correoCliente;
            if (bandera == 0) //clientes
            {
                cliente.Text = dato;
                //alias.Text = dato2;
                label23.Text = dato4;
                label24.Text = dato5;
                label25.Text = dato6;
                label26.Text = "Dir Cliente";
                lblCodCliente.Text = dato7;


            }

        }

        private async void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            _oper = btn.Tag.ToString();
            Servicios datos = new Servicios();
            var lst1 = await datos.llenaCordOLD();
            cord.ValueMember = "C2";
            cord.DisplayMember = "C3";
            cord.DataSource = lst1;
        }

        private async void gunaTileButton2_Click(object sender, EventArgs e)
        {
            Negocios.NGCotizacion.accesoCotizaciones dt = new Negocios.NGCotizacion.accesoCotizaciones();
            gunaDataGridView1.DataSource = null;
            if (_oper =="Cliente")
            {
                string sucursal = default;



                if (rSd.Checked == true)
                {
                    sucursal = "SD";
                }
                if (rTj.Checked == true)
                {
                    sucursal = "TJ";
                }
                if (rCa.Checked == true)
                {
                    sucursal = "CSL";
                }
                var lls = await dt.BuscarCitizacionPorClienteOld(lblCodCliente.Text, sucursal);
                gunaDataGridView1.DataSource = lls;
            }
            if (_oper == "Coor")
            {
                



                string sucursal = default;

                var co = cord.SelectedValue.ToString();

                if (rSd.Checked == true)
                {
                    sucursal = "SD";
                }
                if (rTj.Checked == true)
                {
                    sucursal = "TJ";
                }
                if (rCa.Checked == true)
                {
                    sucursal = "CSL";
                }
                var lls = await dt.BuscarCitizacionPorCoordOld( co, sucursal);
                gunaDataGridView1.DataSource = lls;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}