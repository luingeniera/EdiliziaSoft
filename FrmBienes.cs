using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApplication1;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class FrmBienes : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        public FrmBienes()
        {
            InitializeComponent();
         }

       
        private void Bienes_Load(object sender, EventArgs e)
        {
      

            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            MySqlDataReader dataReaderBienes = DB.GetData("select * from rooms");

            // cbTipo.DataSource = bindingSource1;

            //DB.GetData("select * from users");



            if (dataReaderBienes.HasRows)
            {

                dataReaderBienes.Read();

             //devuelve que tenes en el el dataredear   MessageBox.Show(dataReaderBienes.GetString(1));

                DataTable dt = new DataTable();
                dt.Load(dataReaderBienes);

                #region TipodeBien
                string Tipo = "";
                cbTipo.Items.Clear(); 
                for (int x = 2010; x <= 2030; x++)
                {
                    cbTipo.Items.Add(x);

                }
                #endregion


                

                //cbTipo.Items.Insert(0, "prueba");

                //cbTipo.DataSource = dt;
                //cbTipo.DisplayMember = "description";
                //cbTipo.ValueMember = "code";

                //List<Elementos> Lista = new List<Elementos>();
                //OleDbDataReader reader = getCom(getSelect(Campo, Valor, tb)).ExecuteReader();
                //if (reader.HasRows)
                //{
                //    while (reader.Read())
                //        Lista.Add(new Elementos() { codigo = Convert.ToInt32(reader[Valor]), Cadena = reader[Campo].ToString() });

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            ////Dialogo de guardar cmo

            //Stream myStream;
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //saveFileDialog1.FilterIndex = 2;
            //saveFileDialog1.RestoreDirectory = true;
            //saveFileDialog1.Title = "Ediliziaprueba";
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    if ((myStream = saveFileDialog1.OpenFile()) != null)
            //    {


            //crear el PDF
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("holahola.pdf", FileMode.Create));
            doc.Open();
            Paragraph title = new Paragraph();
            title.Font = FontFactory.GetFont(FontFactory.HELVETICA, 18f, BaseColor.BLUE);
            title.Add("Hola Mundo!!");
            doc.Add(title);
            MessageBox.Show("gola probando que hace click");

            
            doc.Add(new Paragraph("Parrafo 1"));
            doc.Add(new Paragraph("Parrafo 2"));
            doc.Close();


                }
            }

}
