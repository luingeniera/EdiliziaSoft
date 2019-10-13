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
            
            sqlQuery = "SELECT distinct idBien FROM edilizia.diferences";
    
                
            MySqlDataReader Bienes = DB.GetData(sqlQuery);

            //enlisto todos los parents = bienes

            treeView1.BeginUpdate();
            if (Bienes.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(Bienes);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    treeView1.Nodes.Add(dt.Rows[i][0].ToString());

                    //busco todos los comprobantes por cada bien
                    DBConnection DB1 = new DBConnection();
                    string sqlQuery1 = "";

                    sqlQuery1 = "SELECT * FROM edilizia.diferences";

                    //+
                     //"where idbien = " + dt.Rows[i][0].ToString() ;

                    MessageBox.Show(sqlQuery1);

                    MySqlDataReader Comp = DB1.GetData(sqlQuery1);
                    if (Comp.HasRows)
                    {
                        DataTable Cm = new DataTable();
                        Cm.Load(Comp);
                        for (int j = 0; j < Cm.Rows.Count; j++)
                        {

                            MessageBox.Show(Cm.Rows[j][0].ToString());

                            for (int l = 0; l < Cm.Columns.Count; j++)
                            {
                                treeView1.Nodes[i].Nodes.Add(Cm.Rows[j][l].ToString());


                        }
            }
                }
           


            //treeView1.Nodes[0].Nodes.Add("Child 1");
            //treeView1.Nodes[0].Nodes.Add("Child 2");
            //treeView1.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            //treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            treeView1.EndUpdate();
            }

        }
    }
}
}


