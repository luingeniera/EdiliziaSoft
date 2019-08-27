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
        private int IdRoomSelected;
        
        public Glocal()
        {
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            dgLocales.DataSource = bindingSource1;
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            string sqlQuery = "";
            //Con esta consulta busco el nombre de la oficina, responsable y cantidad de bienes que tiene.
            sqlQuery = "select rooms.description as 'oficina' , CONCAT(resp.name,', ',resp.last_name) as 'responsable', " +
            "count(abr.idasset) as 'bienes', rooms.idRooms from rooms INNER JOIN edilizia.rooms_by_users ON idRooms = id_room " +
            "INNER JOIN edilizia.users resp on resp.idUsers = id_user_resposible INNER JOIN edilizia.assets_by_room abr on abr.idRoom = rooms.idRooms " +
            "WHERE rooms.level="+cbNivel.SelectedItem + " and rooms.number="+cbNumero.SelectedItem;
            MySqlDataReader dataReaderInfo = DB.GetData(sqlQuery);
            if (dataReaderInfo.HasRows)
            {
                DataTable dtInfo = new DataTable();
                dtInfo.Load(dataReaderInfo);
                lblLocal.Text = "Oficina: " + dtInfo.Rows[0][0].ToString();
                lblResponsable.Text = "Responsable: " + dtInfo.Rows[0][1].ToString();
                lblActivos.Text = "Cant. Bienes: " + dtInfo.Rows[0][2].ToString();
                IdRoomSelected = int.Parse(dtInfo.Rows[0][3].ToString());
            }

            sqlQuery = "SELECT a.code as 'Codigo', a.description as 'Desc' ,s.description as 'Estado', '' as 'Estado Obs' FROM rooms r INNER JOIN edilizia.assets_by_room abr ON abr.idRoom = r.idRooms " +
            "INNER JOIN assets a on a.id_assets = abr.idAsset INNER JOIN assets_status s on a.idStatus = s.idstatus where level = " + cbNivel.SelectedItem + " and number = " + cbNumero.SelectedItem;
            MySqlDataReader dataReaderLocal = DB.GetData(sqlQuery);
            if (dataReaderLocal.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dataReaderLocal);
                dgLocales.DataSource = dt;
            }
            //Habilito el combo box de "entregar a" y lo completo con los usuarios activos (status=1)
            cbEntrega.Enabled = true;
            MySqlDataReader dataReaderUsers = DB.GetData("select distinct concat(last_name, ', ', name) from users where status = 1");
            if (dataReaderUsers.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dataReaderUsers);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbEntrega.ValueMember = "Valor";
                    cbEntrega.DisplayMember = "Usuario";
                    cbEntrega.Items.Add(dt.Rows[i][0]);
       
                }
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string TipoComprobante = "";
            if (cbEntrega.SelectedIndex > -1)
            {
                
                WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
                string sql = "";
                //Falta recuperar el id_user_owner seleccionado.
                sql = "UPDATE rooms_by_users set id_user_owner=2 where id_room="+IdRoomSelected;
                MySqlDataReader dataUpdateRoomsByUsers = DB.GetData(sql);
                if (rbEntrega.Checked == true)
                    { TipoComprobante = "ENT"; }
                if (rbDevolucion.Checked == true)
                    { TipoComprobante = "DEV"; }
                if (rbAuditoria.Checked == true)
                    { TipoComprobante = "AUD"; }
                sql = "SELECT number+1 as 'nro', description from book where code='" + TipoComprobante + "'";
                MySqlDataReader dataGetBookNumber = DB.GetData(sql);
                if (dataGetBookNumber.HasRows)
                {
                    DataTable dtBook = new DataTable();
                    dtBook.Load(dataGetBookNumber);
                    //dtBook.Rows[i][0] -- nuevo nro de comprobante
                    //dtBook.Rows[i][1] -- descripcion del comprobante.
                    sql = "INSERT INTO transaction(idBook, date) values(" + dtBook.Rows[0][0] + ", now()) ";
                    MySqlDataReader dataInsTransaction = DB.GetData(sql);
                    sql = "UPDATE book set number=number+1 where code='" + TipoComprobante + "'";
                    MySqlDataReader dataUpdBookNumber = DB.GetData(sql);
                    MessageBox.Show("Se ha realizado la entrega del local exitosamente.");
                }
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar a quien realizar la entrega del local.");
            }
        }
    }
}
