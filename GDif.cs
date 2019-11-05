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


namespace WindowsFormsApplication1
{
    public partial class GDif : Form
    {
        public GDif()
        {
            InitializeComponent();

      
        }

        private void GDif_Load(object sender, EventArgs e)
        {

            DBConnection DB = new DBConnection();
            string sqlQuery = "";

            sqlQuery =
                  "SELECT branch as Rubro,type as Tipo, rooms.description as Local, family as Familia,   a.code as Codigo, a.description as Descripcion " +
                  " from edilizia.rooms_by_users inner join edilizia.users on users.idUsers = id_user_responsible" +
                  " inner join edilizia.rooms on rooms.idrooms = id_room" +
                  " inner join edilizia.assets_by_room abr on abr.idRoom = rooms.idrooms" +
                  " inner join edilizia.assets a on a.id_assets = abr.idAsset" +
                  //" where id_user_responsible = '2'"
                  " where 1=1";


            MySqlDataReader Bienes = DB.GetData(sqlQuery);


            if (Bienes.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(Bienes);
                dataGridView1.DataSource = dt;

            }



            //Comienzo las agrupacion
            // compienzo la agrupacion
            var grouper = new Subro.Controls.DataGridViewGrouper(dataGridView1);
            grouper.SetGroupOn("Tipo");

            //also valid:
            //grouper.SetGroupOn<TestData>(t => t.AString);
            //grouper.SetGroupOn(this.dataGridView1.Columns["AString"]);


            //all options available in the control (via the dropdown menu) can be set in code as well and vice versa all options in this example can be set via the control.

            //to start with all rows collapsed on a (re)load or when the group is changed you can set the option startcollapsed:
            //grouper.Options.StartCollapsed = true;

            //to collapse all loaded rows: (the difference with setting the option above, is that after choosing a new grouping (or on a reload), the new groups would expand.
            //grouper.CollapseAll();

            //if you don't want the (rowcount) to be shown in the headers:
            grouper.Options.ShowCount = false;

            //if you don't want the grouped column name to be repeated in the headers:
            //grouper.Options.ShowGroupName = false;

            //default sort order for the groups is ascending, you can change that in the options as well (ascending, descending or none)
            //grouper.Options.GroupSortOrder = SortOrder.Descending;

            //besides grouping on a property/column value, you can set a custom group:
            //   grouper.SetCustomGroup<TestData>(t => t.AnInt % 10, "Mod 10");

            //to customize the grouping display, you can attach to the DisplayGroup event:
            //  grouper.DisplayGroup += grouper_DisplayGroup;
        }
    }
}


