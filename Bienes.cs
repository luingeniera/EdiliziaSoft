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
using System.Diagnostics;



namespace WindowsFormsApplication1
{
    public partial class Bienes : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        public Bienes()
        {
            InitializeComponent();
         }

       
        private void Bienes_Load(object sender, EventArgs e)
        {
      

            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            MySqlDataReader dataReaderBienes = DB.GetData("select distinct category  from assets");
            
                if (dataReaderBienes.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dataReaderBienes);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cbTipo.ValueMember = "Valor";
                    cbTipo.DisplayMember = "category";
                    cbTipo.Items.Add(dt.Rows[i][0]);
                    }
                }
            }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            PDF pp = new PDF();
            string cuerpo,titulo;
            titulo = "Pantalla gestion de bienes";
            cuerpo = "cuerpo del pdf";

            pp.GenerarPDF(titulo,cuerpo);
         


                }

        private void button2_Click(object sender, EventArgs e)
        {

            Printer p = new Printer();
            p.CapturarPantalla();
            p.printDocument1_PrintPage();
            

        }
    }

}
