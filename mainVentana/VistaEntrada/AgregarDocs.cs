using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;
namespace mainVentana.VistaEntrada
{
    public partial class AgregarDocs : Form
    {

        string entrada;
        string sucursalOrigen;


        public AgregarDocs()
        {
            InitializeComponent();
        }

        private void AgregarDocs_Load(object sender, EventArgs e)
        {
            Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Todos los archivos (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*if (txtName.Text.Trim().Equals("") || txtFile.Text.Trim().Equals(""))
            {
                MessageBox.Show("El nombre es obligatorio");
                return;
            }

            byte[] file = null;
            Stream myStream = openFileDialog1.OpenFile();
            using (MemoryStream ms = new MemoryStream())
            {
                myStream.CopyTo(ms);
                file = ms.ToArray();
            }

            using (Model.pruebaEntities db = new Model.pruebaEntities())
            {
                Model.document oDocument = new Model.document();
                oDocument.name = txtName.Text.Trim();
                oDocument.doc = file;
                oDocument.realName = openFileDialog1.SafeFileName;

                db.document.Add(oDocument);
                db.SaveChanges();
            }*/

            Refresh();
        }

        private async void Refresh()
        {

            Servicios datos = new Servicios();
            
            var lst = await datos.ObtieneIMG(entrada, sucursalOrigen); //aggregar esos datos mas tarde

            
            
            dgvLista.DataSource = lst.ToList();
            
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            /*if (dgvLista.Rows.Count > 0)
            {
                int id = int.Parse(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells[0].Value.ToString());
                Servicios datos = new Servicios();
                Task.Run(()=> datos.ObtieneByteDOCUMENTOSALL(entrada, sucursalOrigen));  
               

                using (Model.pruebaEntities db = new Model.pruebaEntities())
                {
                    var oDocument = db.document.Find(id);

                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string folder = path + "/temp/";
                    string fullFilePath = folder + oDocument.realName;

                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    if (File.Exists(fullFilePath))
                        Directory.Delete(fullFilePath);

                    File.WriteAllBytes(fullFilePath, oDocument.doc);

                    Process.Start(fullFilePath);
                }
            }*/
        }
    }
}
