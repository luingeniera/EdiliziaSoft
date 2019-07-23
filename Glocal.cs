using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Globalization;
using WindowsFormsApplication1;


namespace WindowsFormsApplication1
{
    public partial class Glocal : Form
    {
        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();
        //private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        //private MySqlDataReader dataReader;


        public Glocal()
        {
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            dgLocales.DataSource = bindingSource1;
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            string sqlQuery = "";
            sqlQuery = "SELECT rooms.description as 'oficina', CONCAT(resp.name,', ',resp.last_name) as 'responsable', " +
            "count(assets.idassets) as 'bienes' FROM edilizia.rooms INNER JOIN edilizia.rooms_by_users ON idRooms = id_room " +
            "INNER JOIN edilizia.users resp on resp.idUsers = id_user_resposible INNER JOIN edilizia.assets on id_room_by_user = idrooms_by_users";
            MySqlDataReader dataReaderInfo = DB.GetData(sqlQuery);
            if (dataReaderInfo.HasRows)
            {
                DataTable dtInfo = new DataTable();
                dtInfo.Load(dataReaderInfo);
                lblLocal.Text = "Oficina: " + dtInfo.Rows[0][0].ToString();
                lblResponsable.Text = "Responsable: " + dtInfo.Rows[0][1].ToString();
                lblActivos.Text = "Cant. Bienes: " + dtInfo.Rows[0][2].ToString();
            }

            sqlQuery = "select * from rooms where level = " + cbNivel.SelectedItem + " and number = " + cbNumero.SelectedItem;
            MySqlDataReader dataReaderLocal = DB.GetData(sqlQuery);

            if (dataReaderLocal.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dataReaderLocal);
                dgLocales.DataSource = dt;
            }

        }

        private void Glocal_Load(object sender, EventArgs e)
        {
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            MySqlDataReader dataReaderLevel = DB.GetData("select distinct level from rooms");
            if (dataReaderLevel.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dataReaderLevel);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbNivel.ValueMember = "Valor";
                    cbNivel.DisplayMember = "Nivel";
                    cbNivel.Items.Add(dt.Rows[i][0]);
                }
            }
        }

        private void cbNivel_SelectedValueChanged(object sender, EventArgs e)
        {
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            string sql = "";
            cbNumero.Items.Clear();
            if (cbNivel.SelectedIndex > -1)
                sql = "select distinct number from rooms where level = " + cbNivel.SelectedItem;
            else
                sql = "select distinct number from rooms";

            MySqlDataReader dataReaderNumber = DB.GetData(sql);
            if (dataReaderNumber.HasRows)
            {
                DataTable dtNro = new DataTable();
                dtNro.Load(dataReaderNumber);
                for (int i = 0; i < dtNro.Rows.Count; i++)
                {
                    cbNumero.ValueMember = "Valor";
                    cbNumero.DisplayMember = "Nro.";
                    cbNumero.Items.Add(dtNro.Rows[i][0]);
                }
            }
        }

        private void PDF_Click(object sender, EventArgs e)
        {
            PDF pp = new PDF();
            string cuerpo, titulo;
            titulo = "Pantalla gestion de locales";
            cuerpo = "cuerpo del pdf locales";
             pp.GenerarPDF(titulo, cuerpo);
        }
    }
}
