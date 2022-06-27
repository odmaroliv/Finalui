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
using Datos.ViewModels.Entradas;
using ImageMagick;
using Negocios;
namespace mainVentana.VistaEntrada
{
    public partial class AgregarDocs : Form 
    {

        public string entrada;
        public string sucursalOrigen;


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
            
            if (txtFile.Text.Trim().Equals(""))
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

            int co = dgvLista.RowCount + 1;
            List<vmListaFotos> lstFotos = new List<vmListaFotos>();
            string relanom = Path.GetFileName(txtFile.Text);
            string ex = Path.GetExtension(txtFile.Text);
            string extencioDoc = null;

            if (ex.Contains("png") || ex.Contains("jpg") || ex.Contains("jpeg"))
            {
                extencioDoc = "Imagen";
                valida(0);
                lstFotos.Add(new vmListaFotos { entrada = entrada.Trim(), nombre = sucursalOrigen.Trim() + "-" + entrada + "-" + co.ToString(), realnombre = relanom, bytedocumto = RedimencionaIMG(file), sucursal = sucursalOrigen, tipo = extencioDoc });
            }
            else if (ex.Contains("docx") || ex.Contains("pdf") || ex.Contains("xlsx"))
            {
                extencioDoc = "Doc"; 
                valida(1);
                lstFotos.Add(new vmListaFotos { entrada = entrada.Trim(), nombre = sucursalOrigen.Trim() + "-" + entrada + "-" + co.ToString(), realnombre = relanom, bytedocumto = file, sucursal = sucursalOrigen, tipo = extencioDoc });
            }

            
            Refresh();
        }

        private byte[] RedimencionaIMG(byte[] path)
        {
            byte[] pic;
            using (MagickImage imk = new MagickImage(path))
            {
                imk.Resize(600, 0);
                pic = imk.ToByteArray();

            }
            return pic;

        }

        private byte[] docbyte(string ruta)
        {
            byte[] file = null;
            vmListaFotos lsf = new vmListaFotos();
            Stream fs = new FileStream(ruta, FileMode.Open);
            //var img = ruta;
            // img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            using (MemoryStream ms = new MemoryStream())
            {
                fs.CopyTo(ms);
                file = ms.ToArray();
                fs.Dispose();
            }
            return file;
            //picture.Dispose();
        }

        private async void Refresh()
        {

            Servicios datos = new Servicios();
            dgvLista.Rows.Clear();
            var lst = await datos.ObtieneIMGreal(entrada, sucursalOrigen); //aggregar esos datos mas tarde
            //int f = 0;
            var se = lst;
            
            foreach (var q in se)
            {
                
                if (q.tipodedocto == "Doc")
                {
                    //dgvLista.Columns[3].Visible = false;
                    //dgvLista.Columns.RemoveAt(4);
                    //dgvLista.Columns.Add("Column6", "PDF");
                    dgvLista.Rows.Add(q.entrada, q.sucursal, q.realnombre,q.tipodedocto, q.bytedocumento,null,q.nombre);
                }
                if (q.tipodedocto == "Imagen")
                {
                    

                    dgvLista.Rows.Add(q.entrada, q.sucursal, q.realnombre, q.tipodedocto,"", RedimencionalaIMG(q.bytedocumento),q.nombre);

                }
               
          
            }


            // dgvLista.DataSource = lst.ToList();

        }
        private void valida(int dt) // 0 imgen 1 doc
        {
            int cImg = 0;
            int cDoc = 0;
            int rw = 0; 


            foreach (var q in dgvLista.Rows)
            {
                string rname = dgvLista.Rows[rw].Cells[3].Value.ToString();
                if (rname == "Imagen")
                {
                    cImg = cImg + 1;
                }
                if (rname == "Doc")
                {
                    cDoc = cDoc + 1;
                }

                rw = rw + 1;


            }
            
            if (cImg >=15 && dt ==0)
            {
                MessageBox.Show("Solo puedes tener 14 imagenes, borra una para aggregar otra", "Error en cantidad de imagenes");
                return;
            }
            if (cDoc >= 2 && dt == 1)
            {
                MessageBox.Show("Solo puedes tener 2 documentos, borra uno para aggregar otro", "Error en cantidad de documentos");
                return;
            }

        }
        private byte[] RedimencionalaIMG(byte[] path)
        {
            byte[] pic;
            using (MagickImage imk = new MagickImage(path))
            {
                imk.Resize(300, 0);
                pic = imk.ToByteArray();

            }
            return pic;

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

        private void dgvLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
            {
                string rdname = dgvLista.Rows[dgvLista.CurrentRow.Index].Cells[2].Value.ToString();
                string rtipodocumento = dgvLista.Rows[dgvLista.CurrentRow.Index].Cells[3].Value.ToString();
                string rname = dgvLista.Rows[dgvLista.CurrentRow.Index].Cells[6].Value.ToString();


                if (MessageBox.Show("Seguro que deseas BORRAR el documento " + rdname,"Cuidado, estas apunto de borrar",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BajaDB sv = new BajaDB();
                    sv.Elimina_FotoDoc(rname, rtipodocumento);
                    MessageBox.Show("Documento Borrado");
                }
                
                Refresh();
            }
        }
    }
}
