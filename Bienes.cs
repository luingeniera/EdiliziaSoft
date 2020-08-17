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

        int bandera = 0;
        DataTable dtBienes =  new DataTable();
        
        private BindingSource bindingSource1 = new BindingSource();
        public Bienes()
        {
            InitializeComponent();
        }

     
       
        private void Bienes_Load(object sender, EventArgs e)
        {


            cargacombos("Todos", "Todos", "Todos", "Todos", "Todos");
           
            cbFamilia.SelectedItem = "Todos";
            cbLocales.SelectedItem = "Todos";
            cbTipo.SelectedItem = "Todos";
            cbRubro.SelectedItem = "Todos";
            cbResponsable.SelectedItem = "Todos";

            bandera = 1;
            
        }



        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            dgBienes.DataSource = bindingSource1;
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            string sqlQuery = "";

            string wrubro = " branch='" + cbRubro.SelectedItem.ToString() + "'";
            string wtipo = " type='" + cbTipo.SelectedItem.ToString() + "'";

            //cambio pedido 13/08/2020 para que se filtre por codigo y descr de local
            //string wlocal = " rooms.description='" + cbLocales.SelectedItem.ToString() + "'";
            string wlocal = " CONCAT('[',rooms.code,'] - ', rooms.description) like '%" + cbLocales.SelectedItem.ToString() + "%' ";
            string wfamilia = " family='" + cbFamilia.SelectedItem.ToString() + "'";

            //pidio agregar responsable tmb
          
            string wresponsable = "  concat(u.last_name, ', ', u.name) = '" + cbResponsable.SelectedItem.ToString() + "' "; 


            if (cbRubro.SelectedItem.ToString() == "Todos") { wrubro = "1=1"; };
            if (cbTipo.SelectedItem.ToString() == "Todos") { wtipo = "1=1"; };
            if (cbLocales.SelectedItem.ToString() == "Todos") { wlocal = "1=1"; };
            if (cbFamilia.SelectedItem.ToString() == "Todos") { wfamilia = "1=1"; };
            if (cbResponsable.SelectedItem.ToString() == "Todos") { wresponsable = "1=1"; };

            sqlQuery =
            //concat(u.last_name, ', ', u.name) as Responsable
            " SELECT branch as Rubro,type as Tipo, CONCAT('[',rooms.code,'] - ', rooms.description) as Local, concat(u.last_name, ', ', u.name) as Responsable, family as Familia, a.code as Codigo, a.description as Descripcion " +
           
            "from edilizia.assets a inner join edilizia.assets_by_room abr on a.id_assets = abr.idAsset " +
            "inner join edilizia.rooms on abr.idRoom = rooms.idrooms" +
            " LEFT OUTER JOIN edilizia.rooms_by_users rbu on rooms.idRooms = rbu.id_room" +
           " LEFT OUTER JOIN edilizia.users u on u.idUsers = rbu.id_user_responsible" +
           " where 1=1" +
             " and " + wrubro +
             " and " + wlocal +
             " and " + wfamilia +
             " and " + wtipo +
              " and " + wresponsable +
             " order by 3;";
            


            MySqlDataReader dataReaderLocal = DB.GetData(sqlQuery);

            if (dataReaderLocal.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dataReaderLocal);
                dtBienes.Load(dataReaderLocal);
                dgBienes.DataSource = dt;
            }

            PDF.Enabled = true;
    }

        private void PDF_Click(object sender, EventArgs e)
        {
            PDF_plano pepe = new PDF_plano();
            pepe.GenerarPDF(0, "Listado de bienes", dtBienes,null,null,null, dgBienes, "ultimoreglon"); 
            
        }

       

        private void cargacombos( string familia, string local, string rubro, string tipo,string responsable)
        {
            DBConnection DB = new DBConnection();
            DBConnection DB1 = new DBConnection();

            string wrubro = " branch='" + rubro +"'";
            string wtipo = " type='" + tipo + "'";
            string wlocal = " rooms.description='" + local + "'";
            string wfamilia = " family='" + familia + "'";
            string wresponsable = " AND concat(u.last_name, ', ', u.name) = '" + responsable + "'" ;

            if (rubro == "Todos") { wrubro = "1=1"; };
            if (tipo == "Todos") { wtipo = "1=1"; };
            if (local == "Todos") { wlocal = "1=1"; };
            if (familia == "Todos") { wfamilia = "1=1";};
            if (responsable == "Todos") { wresponsable = "1=1"; };


            MySqlDataReader drRubro = DB1.GetData(

"SELECT distinct branch as rubro from edilizia.assets a inner join edilizia.assets_by_room abr on a.id_assets = abr.idAsset " +
"inner join edilizia.rooms on abr.idRoom = rooms.idrooms " +
 "LEFT OUTER JOIN edilizia.rooms_by_users rbu on rooms.idRooms = rbu.id_room "+
 "LEFT OUTER JOIN edilizia.users u on u.idUsers = rbu.id_user_responsible "+
"where 1=1" +
" and " + wtipo + 
" and " + wlocal + 
" and " + wfamilia + 
" and " + wtipo +
" and " + wresponsable + ";"
);


MySqlDataReader drfamilia = DB.GetData(

"SELECT distinct family as familia from edilizia.assets a inner join edilizia.assets_by_room abr on a.id_assets = abr.idAsset " +
"inner join edilizia.rooms on abr.idRoom = rooms.idrooms " +
 "LEFT OUTER JOIN edilizia.rooms_by_users rbu on rooms.idRooms = rbu.id_room " +
 "LEFT OUTER JOIN edilizia.users u on u.idUsers = rbu.id_user_responsible " +
"where 1=1" +
" and " + wtipo +
" and " + wlocal +
" and " + wfamilia +
" and " + wtipo +
" and " + wresponsable + ";"
);

            MySqlDataReader drtipo = DB.GetData(

"SELECT distinct type as tipo from edilizia.assets a inner join edilizia.assets_by_room abr on a.id_assets = abr.idAsset " +
"inner join edilizia.rooms on abr.idRoom = rooms.idrooms " +
 "LEFT OUTER JOIN edilizia.rooms_by_users rbu on rooms.idRooms = rbu.id_room " +
 "LEFT OUTER JOIN edilizia.users u on u.idUsers = rbu.id_user_responsible " +

" where 1=1" +
" and " + wtipo +
" and " + wlocal +
" and " + wfamilia +
" and " + wtipo +
" and " + wresponsable + ";"
);

            MySqlDataReader drlocales = DB.GetData(
//cambio para que muestre por codigo y desc del local 13/08/2020
"SELECT distinct CONCAT('[',rooms.code,'] - ', rooms.description) as 'Local'  from edilizia.assets a inner join edilizia.assets_by_room abr on a.id_assets = abr.idAsset " +
"inner join edilizia.rooms on abr.idRoom = rooms.idrooms " +
 "LEFT OUTER JOIN edilizia.rooms_by_users rbu on rooms.idRooms = rbu.id_room " +
 "LEFT OUTER JOIN edilizia.users u on u.idUsers = rbu.id_user_responsible " +
 "where 1=1" +
" and " + wtipo +
" and " + wlocal +
" and " + wfamilia +
" and " + wtipo +
" and " + wresponsable +
";"
);


 MySqlDataReader drReposnsable = DB.GetData("SELECT distinct concat(u.last_name, ', ', u.name) as 'Responsable'  from edilizia.assets a inner join edilizia.assets_by_room abr on a.id_assets = abr.idAsset " +
"inner join edilizia.rooms on abr.idRoom = rooms.idrooms " +
 "LEFT OUTER JOIN edilizia.rooms_by_users rbu on rooms.idRooms = rbu.id_room " +
 "LEFT OUTER JOIN edilizia.users u on u.idUsers = rbu.id_user_responsible " +
 "where 1=1" +
" and " + wtipo +
" and " + wlocal +
" and " + wfamilia +
" and " + wtipo +
" and " + wresponsable +
";"
);



            if (drRubro.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(drRubro);
                if (bandera == 0) { cbRubro.Items.Add("Todos"); }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbRubro.ValueMember = "Rubro";
                    cbRubro.DisplayMember = "rubro";
                    cbRubro.Items.Add(dt.Rows[i][0]);

                }
               

            }


            if (drfamilia.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(drfamilia);
                cbFamilia.Items.Add("Todos");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbFamilia.ValueMember = "Familia";
                    cbFamilia.DisplayMember = "familia";
                    cbFamilia.Items.Add(dt.Rows[i][0]);

                }
            }



            if (drtipo.HasRows)
            {
                DataTable dt1 = new DataTable();
                dt1.Load(drtipo);
               

                cbTipo.Items.Add("Todos");
               
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    cbTipo.ValueMember = "Tipo";
                    cbTipo.DisplayMember = "tipo";
                    cbTipo.Items.Add(dt1.Rows[i][0]);

                }
            }

            
            if (drlocales.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(drlocales);
                cbLocales.Items.Add("Todos");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbLocales.ValueMember = "Valor";
                    cbLocales.DisplayMember = "local";
                    cbLocales.Items.Add(dt.Rows[i][0]);
                }
            }

            if (drReposnsable.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(drReposnsable);
                cbResponsable.Items.Add("Todos");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbResponsable.ValueMember = "Valor";
                    cbResponsable.DisplayMember = "local";
                    cbResponsable.Items.Add(dt.Rows[i][0]);
                }
            }



        }


        private void cbRubro_SelectedValueChanged(object sender, EventArgs e)
        {
          
                //cargacombos(cbFamilia.SelectedItem.ToString(), cbLocales.SelectedItem.ToString(),
                //    cbRubro.SelectedItem.ToString(), cbTipo.SelectedItem.ToString(), cbResponsable.SelectedItem.ToString());
            


        }

        private void cbFamilia_SelectedValueChanged(object sender, EventArgs e)
        {

          


        }




        private void cbLocales_SelectedValueChanged(object sender, EventArgs e)
        {


          
        }

        private void cbTipo_SelectedValueChanged(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función no implementada.");
        }
    }

}
