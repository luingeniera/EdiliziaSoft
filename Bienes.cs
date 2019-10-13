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

            DBConnection DB = new DBConnection();

            MySqlDataReader drRubro = DB.GetData("SELECT distinct branch FROM edilizia.assets;");
            MySqlDataReader drfamilia = DB.GetData("SELECT distinct family FROM edilizia.assets;");
            MySqlDataReader drtipo = DB.GetData("SELECT distinct type FROM edilizia.assets;");
            //completo desplegble de locales del responsable logueado
            //ahora harcodeado hasta que tengamos dicho user
            MySqlDataReader drlocales = DB.GetData("SELECT rooms.description " +
        " from edilizia.rooms_by_users inner join edilizia.users on users.idUsers = id_user_responsible" +
        " inner join edilizia.rooms on rooms.idrooms = id_room where id_user_responsible = '2'; ");



            if (drRubro.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(drRubro);

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    
                    cbRubro.ValueMember = "Rubro";
                    cbRubro.DisplayMember = "brach";
                    cbRubro.Items.Add(dt.Rows[i][0]);

                }
            }


            if (drfamilia.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(drfamilia);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbFamilia.ValueMember = "Familia";
            cbFamilia.DisplayMember = "family";
            cbFamilia.Items.Add(dt.Rows[i][0]);

                }
            }



            if (drtipo.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(drtipo);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbTipo.ValueMember = "Tipo";
                    cbTipo.DisplayMember = "type";
                    cbTipo.Items.Add(dt.Rows[i][0]);

                }
            }



        
            if (drlocales.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(drlocales);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbLocales.ValueMember = "Valor";
                    cbLocales.DisplayMember = "description";
                    cbLocales.Items.Add(dt.Rows[i][0]);
                }
            }


        }



        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            dgBienes.DataSource = bindingSource1;
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            string sqlQuery = "";
            string xwhere = "";
            string xwhere1 = "";
            string xwhere2 = "";
            string xwhere3 = "";

            if (cbRubro.SelectedIndex > -1) { xwhere = " branch=" + cbRubro.SelectedItem.ToString(); };
            //if (cbFamilia.SelectedIndex > -1) { xwhere1 =  " family=" = cbFamilia.SelectedItem.ToString(); };
            //if (cbTipo.SelectedIndex > -1) { xwhere2 =  " type=" = cbFamilia.SelectedItem; };
            //if (cbLocales.SelectedIndex > -1) { xwhere3 ="description=" = cbFamilia.SelectedItem; };

            sqlQuery = "SELECT id_assets,code,'' as vacia,description FROM edilizia.assets" 
                + xwhere + xwhere1 + xwhere2 + xwhere3;

            MessageBox.Show(sqlQuery);
            //if (cbNivel.SelectedIndex > -1)
            //    sql = "select distinct number from rooms where level = " + cbNivel.SelectedItem;
            //else
            //    sql = "select distinct number from rooms";



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
            PDF2 pp = new PDF2();
            string cuerpo, titulo, encabezado, talonario;

            titulo = "Listado de Bienes";
            
            cuerpo = "";
            encabezado = "Bienes";
            talonario = "001";
            //origen = 2
            pp.PrintPDF(24);
        }
    }
}
