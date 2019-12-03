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
            MySqlDataReader drReposnsable = DB.GetData("SELECT concat(last_name, ', ', name) as 'Responsable', u.idUsers  FROM edilizia.users u inner JOIN rooms_by_users rbu on u.idUsers = rbu.id_user_responsible; ");
            MySqlDataReader drNivel = DB.GetData("select  distinct number as Nivel from edilizia.rooms;");
            MySqlDataReader drLocal = DB.GetData("select CONCAT('[',rooms.code,'] - ', rooms.description) as 'Local'  from edilizia.rooms;");
            MySqlDataReader drLevel = DB.GetData("select distinct level from rooms");
            MySqlDataReader drNroComp = DB.GetData("SELECT booknumber as NroComprobante FROM edilizia.transaction;");

          
            if (drNivel.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(drNivel);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbNivel.ValueMember = "Valor";
                    cbNivel.DisplayMember = "Nivel";
                    cbNivel.Items.Add(dt.Rows[i][0]);
                }
            }

            if (drLocal.HasRows)
            {
                DataTable dt1 = new DataTable();
                dt1.Load(drLocal);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    cbLocales.ValueMember = "Valor";
                    cbLocales.DisplayMember = "Locales";
                    cbLocales.Items.Add(dt1.Rows[i][0]);
                }
            }

            if (drReposnsable.HasRows)
            {
                DataTable dt1 = new DataTable();
                dt1.Load(drReposnsable);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    cbResponsable.ValueMember = "Valor";
                    cbResponsable.DisplayMember = "Responsables";
                    cbResponsable.Items.Add(dt1.Rows[i][0]);
                }
            }

            if (drNroComp.HasRows)
            {
                DataTable dt1 = new DataTable();
                dt1.Load(drNroComp);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    cbComprobante.ValueMember = "Valor";
                    cbComprobante.DisplayMember = "Numero comprobante";
                    cbComprobante.Items.Add(dt1.Rows[i][0]);
                    
            }

            }



        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string TipoComprobante = "";
            if (rbEntrega.Checked == true)
            {
                TipoComprobante = "ENT";
                
            }
            if (rbDevolucion.Checked == true)
            {
                TipoComprobante = "DEV";
                
            }
            if (rbAuditoria.Checked == true)
            {
                TipoComprobante = "AUD";
               
            }
            string WbookCode = "AND bookcode='" + TipoComprobante.ToString()+  "' ";

            string wbooknumber = "AND 1=1 ";
            if (cbComprobante.SelectedItem != null) { wbooknumber = " AND booknumber='" + cbComprobante.SelectedItem.ToString() + "' "; }
          

          //  if (cbComprobante.SelectedItem != null) { WbookCode = " AND bookCode='" + cbComprobante.SelectedItem.ToString() + "' "; }
            string wnumber = "AND 1=1 ";

            if (cbNumero.SelectedItem != null ) { wnumber = " AND number='" + cbComprobante.SelectedItem.ToString() + "' "; }
            string wlevel = "AND 1=1 ";

            if (cbNivel.SelectedItem != null) { wlevel = " AND level='" + cbNivel.SelectedItem.ToString() + "' "; }





            string sqlQuery = "select * " +
" FROM rooms r" +
" INNER JOIN edilizia.assets_by_room abr ON abr.idRoom = r.idRooms" +
" INNER JOIN assets a on a.id_assets = abr.idAsset" +
" INNER JOIN assets_status s on a.idStatus = s.idstatus" +
" LEFT OUTER JOIN rooms_by_users rbu on r.idRooms = rbu.id_room" +
" LEFT OUTER JOIN users u on u.idUsers = rbu.id_user_responsible" +
" INNER JOIN assets_room_Transaction art on art.id_Asset = abr.idAsset" +
" inner join transaction t on t.idtransaction = art.idtransaction" +
" and art.id_Room = abr.idRoom" +
 " WHERE  idTransaction_status ='2' and date between '" + dtdesde.Value.ToShortDateString() + "' and '" + dthasta.Value.ToShortDateString() + "'" +

 WbookCode + wbooknumber + wnumber + wlevel;

            
             DBConnection DB = new DBConnection();
            MySqlDataReader comprobantes = DB.GetData(sqlQuery);
            richTextBox1.Text = sqlQuery;


            if (comprobantes.HasRows)
            {
               
                DataTable dgv = new DataTable();
                dgv.Load(comprobantes);
                dgvDiferencias.DataSource = dgv;


            }

        }

        }
}


