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

        //string icbFamilia;
        //string icbLocales;
        //string icbTipo;
        //string icbRubro;

       
        private void Bienes_Load(object sender, EventArgs e)
        {


           
            cbFamilia.Items.Add("Todos");
            cbFamilia.SelectedItem = "Todos";
            cbLocales.Items.Add("Todos");
            cbLocales.SelectedItem = "Todos";
            cbTipo.Items.Add("Todos");
            cbTipo.SelectedItem = "Todos";
            cbRubro.Items.Add("Todos");
            cbRubro.SelectedItem = "Todos";
            cargacombos("Todos", "Todos", "Todos", "Todos");
            bandera = 1;
                //cbFamilia.SelectedValue.ToString(), cbLocales.SelectedValue.ToString()
                //, cbRubro.SelectedValue.ToString(),cbTipo.SelectedValue.ToString());
        }



        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            dgBienes.DataSource = bindingSource1;
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            string sqlQuery = "";

            string wrubro = " branch='" + cbRubro.SelectedItem.ToString() + "'";
            string wtipo = " type='" + cbTipo.SelectedItem.ToString() + "'";
            string wlocal = " rooms.description='" + cbRubro.SelectedItem.ToString() + "'";
            string wfamilia = " family='" + cbFamilia.SelectedItem.ToString() + "'";


            if (cbRubro.SelectedItem.ToString() == "Todos") { wrubro = "1=1"; };
            if (cbTipo.SelectedItem.ToString() == "Todos") { wtipo = "1=1"; };
            if (cbLocales.SelectedItem.ToString() == "Todos") { wlocal = "1=1"; };
            if (cbFamilia.SelectedItem.ToString() == "Todos") { wfamilia = "1=1"; };


            sqlQuery =
             "SELECT branch as Rubro,type as Tipo, rooms.description as Local, family as Familia,   a.code as Codigo, a.description as Descripcion " +
             " from edilizia.rooms_by_users inner join edilizia.users on users.idUsers = id_user_responsible" +
             " inner join edilizia.rooms on rooms.idrooms = id_room" +
             " inner join edilizia.assets_by_room abr on abr.idRoom = rooms.idrooms" +
             " inner join edilizia.assets a on a.id_assets = abr.idAsset" +
             " where id_user_responsible = '2'" +
             " and " + wtipo +
             " and " + wlocal +
             " and " + wfamilia +
             " and " + wtipo + ";";
            


            MySqlDataReader dataReaderLocal = DB.GetData(sqlQuery);

            if (dataReaderLocal.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dataReaderLocal);
                dtBienes.Load(dataReaderLocal);
                dgBienes.DataSource = dt;
            }
    }

        private void PDF_Click(object sender, EventArgs e)
        {
            PDF_plano pepe = new PDF_plano();
            pepe.GenerarPDF(0, "Listado de bienes", dtBienes,null,null,null, dgBienes, "ultimoreglon"); 


        }

       

        private void cargacombos( string familia, string local, string rubro, string tipo)
        {




            DBConnection DB = new DBConnection();
            DBConnection DB1 = new DBConnection();
            string wrubro = " branch='" + rubro +"'";
            string wtipo = " type='" + tipo + "'";
            string wlocal = " rooms.description='" + local + "'";
            string wfamilia = " family='" + familia + "'";

          
            if (rubro == "Todos") { wrubro = "1=1"; };
            if (tipo == "Todos") { wtipo = "1=1"; };
            if (local == "Todos") { wlocal = "1=1"; };
            if (familia == "Todos") { wfamilia = "1=1";};


MySqlDataReader drRubro = DB1.GetData(
"SELECT distinct branch as rubro " +
" from edilizia.rooms_by_users inner join edilizia.users on users.idUsers = id_user_responsible" +
" inner join edilizia.rooms on rooms.idrooms = id_room" +
" inner join edilizia.assets_by_room abr on abr.idRoom = rooms.idrooms" +
" inner join edilizia.assets a on a.id_assets = abr.idAsset" +
" where id_user_responsible = '2'" +
" and "+ wtipo + 
" and " + wlocal + 
" and " + wfamilia + 
" and " + wtipo + ";"
);


MySqlDataReader drfamilia = DB.GetData(
"SELECT distinct family as familia" +
" from edilizia.rooms_by_users inner join edilizia.users on users.idUsers = id_user_responsible" +
" inner join edilizia.rooms on rooms.idrooms = id_room" +
" inner join edilizia.assets_by_room abr on abr.idRoom = rooms.idrooms" +
" inner join edilizia.assets a on a.id_assets = abr.idAsset" +
" where id_user_responsible = '2'" +
" and " + wtipo +
" and " + wlocal +
" and " + wfamilia +
" and " + wtipo + ";"
);

MySqlDataReader drtipo = DB.GetData(
"SELECT distinct type as tipo" +
" from edilizia.rooms_by_users inner join edilizia.users on users.idUsers = id_user_responsible" +
" inner join edilizia.rooms on rooms.idrooms = id_room" +
" inner join edilizia.assets_by_room abr on abr.idRoom = rooms.idrooms" +
" inner join edilizia.assets a on a.id_assets = abr.idAsset" +
" where id_user_responsible = '2'" +
" and " + wtipo +
" and " + wlocal +
" and " + wfamilia +
" and " + wtipo + ";"
);

MySqlDataReader drlocales = DB.GetData(
"SELECT distinct rooms.description as local" +
" from edilizia.rooms_by_users inner join edilizia.users on users.idUsers = id_user_responsible" +
" inner join edilizia.rooms on rooms.idrooms = id_room" +
" inner join edilizia.assets_by_room abr on abr.idRoom = rooms.idrooms" +
" inner join edilizia.assets a on a.id_assets = abr.idAsset" +
" where id_user_responsible = '2'" +
" and " + wtipo +
" and " + wlocal +
" and " + wfamilia +
" and " + wtipo + ";"
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



        }


        private void cbRubro_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (bandera != 0)
            //{
            //    cargacombos(cbFamilia.SelectedItem.ToString(), cbLocales.SelectedItem.ToString(),
            //        cbRubro.SelectedItem.ToString(), cbTipo.SelectedItem.ToString());
            //}

          
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
    }

}
