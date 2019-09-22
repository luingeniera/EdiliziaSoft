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
            MySqlDataReader dataReaderBienes = DB.GetData("select distinct description  from assets");

            if (dataReaderBienes.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dataReaderBienes);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbCategoria.ValueMember = "Valor";
                    cbCategoria.DisplayMember = "description";
                    cbCategoria.Items.Add(dt.Rows[i][0]);
                }
            }
        }

      



        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            dgBienes.DataSource = bindingSource1;
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            string sqlQuery = "";


            sqlQuery = "SELECT id_assets,code,'' as vacia,description FROM edilizia.assets;";
            MySqlDataReader dataReaderLocal = DB.GetData(sqlQuery);

            if (dataReaderLocal.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dataReaderLocal);

                dgBienes.DataSource = dt;
            }
    }

        private void PDF_Click(object sender, EventArgs e)
        {
            PDF pp = new PDF();
            string cuerpo, titulo, encabezado, talonario;

            titulo = "Listado de Bienes";
            
            cuerpo = "";
            encabezado = "Bienes";
            talonario = "001";
            pp.GenerarPDF(encabezado, talonario, titulo, cuerpo, dgBienes, null);
        }
    }
}
