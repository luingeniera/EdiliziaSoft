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
    public partial class Revit : Form
    {
        public Revit()
        {
            InitializeComponent();
        }

        public void Revit_load(object sender, EventArgs e)
        {
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            MySqlDataReader conect = DB.GetData("SELECT a.code as 'Código',a.description as 'Descripción',ro.number as 'Nro Local Revit',ro.name as 'Local Revit' " +
 ", redi.code as 'Nro Local Integracion',redi.description as 'Local Integracion' " +
 "FROM revit.rooms ro " +
 "inner join revit.`room associations` ra   on ra.`Room Id` =  ro.Id   " +
 "inner join revit.furniture f on f.Id = ra.Id " +
 "inner join  edilizia.assets a on f.referencia_SIPRECO = a.code " +
 "INNER JOIN edilizia.assets_by_room abr ON abr.idAsset = a.id_assets " +
 "inner join edilizia.rooms redi on redi.idRooms = abr.idRoom");
        
            if (conect.HasRows)
            {

                DataTable comparacion = new DataTable();
                comparacion.Load(conect);
                dgvRevit.DataSource = comparacion;


                  

                    //Autoajusto grilla
                    for (int i = 0; i <= dgvRevit.Columns.Count - 1; i++)
                    {

                    dgvRevit.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    
                    }
                    
                    for (int i = 0; i <= dgvRevit.Rows.Count - 2; i++)
                    {

                  //  MessageBox.Show(dgvRevit[2, i].Value.ToString() + dgvRevit[4, i].Value.ToString());
                    if (dgvRevit[2, i].Value.ToString() != dgvRevit[4, i].Value.ToString())

                        {
                      for (int j = 0; j <= dgvRevit.Columns.Count -1; j++)
                            dgvRevit[ j, i].Style.BackColor = Color.Red;
                           
                        }
                    else
                    {
                        for (int j = 0; j <= dgvRevit.Columns.Count - 1; j++)
                            dgvRevit[j, i].Style.BackColor = Color.DarkGreen;

                    }


                }









            }
            }
    }
}
