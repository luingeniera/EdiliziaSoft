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
        public DataTable dtReturnPicking { get; set; }
        private DataTable dataTableDgLocales;
        //private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        //private MySqlDataReader dataReader;
        private int IdRoomSelected;
        WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
        public Glocal()
        {
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            string deliveriedTo = "";
            string comprobante = "";
            lblComprobante.Text = "";
            btnConfirmar.Visible = false;
            dgLocales.DataSource = null;
            dgLocales.DataSource = bindingSource1;
            if (dgLocales.Columns.Contains("Estado Obs."))
                dgLocales.Columns.Remove("Estado Obs.");
            //WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            string sqlQuery = "";
            //Con esta consulta busco el nombre de la oficina, dueño y cantidad de bienes que tiene.
            sqlQuery = "select rooms.description as 'oficina' , CONCAT(resp.name,', ',resp.last_name) as 'responsable', " +
            "count(abr.idasset) as 'bienes', rooms.idRooms from rooms INNER JOIN edilizia.rooms_by_users ON idRooms = id_room " +
            "INNER JOIN edilizia.users resp on resp.idUsers = id_user_owner INNER JOIN edilizia.assets_by_room abr on abr.idRoom = rooms.idRooms " +
            "WHERE rooms.level="+cbNivel.SelectedItem + " and rooms.number="+cbNumero.SelectedItem;
            MySqlDataReader dataReaderInfo = DB.GetData(sqlQuery);
            if (dataReaderInfo.HasRows)
            {
                DataTable dtInfo = new DataTable();
                dtInfo.Load(dataReaderInfo);
                lblLocal.Text = "Oficina: " + dtInfo.Rows[0][0].ToString();
                lblResponsable.Text = "Dueño: " + dtInfo.Rows[0][1].ToString();
                lblActivos.Text = "Cant. Bienes: " + dtInfo.Rows[0][2].ToString();
                IdRoomSelected = int.Parse(dtInfo.Rows[0][3].ToString());
            }
            //Busco datos de los bienes del local para completar la grilla.
            sqlQuery = "SELECT a.code as 'Codigo', a.description as 'Desc' ,s.description as 'Estado', concat(last_name, ', ', name) as 'Responsible', concat(t.bookCode,'-',t.bookNumber) as 'Comprobante' " +
            " ,art.idtransaction,art.idAsset_by_room, '' as color FROM rooms r INNER JOIN edilizia.assets_by_room abr ON abr.idRoom = r.idRooms INNER JOIN assets a on a.id_assets = abr.idAsset" +
            " INNER JOIN assets_status s on a.idStatus = s.idstatus LEFT OUTER JOIN rooms_by_users rbu on r.idRooms = rbu.id_room and rbu.end_date is null " +
            " LEFT OUTER JOIN users u on u.idUsers = rbu.id_user_responsible LEFT OUTER JOIN assets_room_Transaction art on art.idAsset_by_room = abr.idassets_by_room and art.return_date is null" +
            " LEFT OUTER JOIN transaction t on t.idtransaction = art.idtransaction WHERE level = " + cbNivel.SelectedItem + " and number = " + cbNumero.SelectedItem;
            MySqlDataReader dataReaderLocal = DB.GetData(sqlQuery);
            if (dataReaderLocal.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dataReaderLocal);
                dgLocales.DataSource = dt;
                dataTableDgLocales = dt;

                deliveriedTo = dt.Rows[0][3].ToString();
                comprobante = dt.Rows[0][4].ToString();
                dgLocales.Columns.Remove("Responsible");
                dgLocales.Columns.Remove("Comprobante");
                dgLocales.Columns["idtransaction"].Visible = false;
                dgLocales.Columns["idAsset_by_room"].Visible = false;
                btPicking.Enabled = true;
            }

            if (deliveriedTo == "")
            {
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
            } else
            {
                //Para los casos en que estoy filtrando un local que ya se generó la entrega (pero no se confirmó)
                //oculto el btn Entregar y muestro el confirmar, inhabilito el combo de personas a entregar y 
                //agrego la columna "estado observado" para que puedan realizar correciones.
                btnEntregar.Visible = false;
                btnConfirmar.Visible = true;

                //MySqlDataReader dataAssets_status = DB.GetData("select distinct description from assets_status");
                //List<string> assets_status = new List<string>();
                //if (dataAssets_status.HasRows)
                //{
                //    DataTable das = new DataTable();
                //    das.Load(dataAssets_status);
                //    for (int i = 0; i < das.Rows.Count; i++)
                //    {
                //        assets_status.Add(das.Rows[i][0].ToString());
                //    }
                //}
                //var column = new DataGridViewComboBoxColumn();
                //column.DataSource = new List<string>(assets_status);
                //dgLocales.Columns.Add(column);
                //dgLocales.Columns[3].Name = "Estado Observado";
                
                cbEntrega.Enabled = false;
                cbEntrega.Text = "";
                cbEntrega.SelectedText = deliveriedTo;
                lblComprobante.Text = comprobante;
                btnConfirmar.Visible = true;
                

                ////////Recupero el IdTransaction y una lista con todos los idAsset_by_room.
                //////sqlQuery = "SELECT art.idtransaction,art.idAsset_by_room FROM rooms r " +
                //////" INNER JOIN edilizia.assets_by_room abr ON abr.idRoom = r.idRooms LEFT OUTER JOIN assets_room_Transaction art " +
                //////" on art.idAsset_by_room = abr.idassets_by_room and art.return_date is null WHERE level = " + cbNivel.SelectedItem + " and number = " + cbNumero.SelectedItem;
                //////MySqlDataReader dataReaderAssetsByRoom = DB.GetData(sqlQuery);
                //////if (dataReaderAssetsByRoom.HasRows)
                //////{
                //////    DataTable dt = new DataTable();
                //////    dt.Load(dataReaderAssetsByRoom);
                //////    IdsAssets_by_room = new List<int>();
                //////    for (int i = 0; i < dt.Rows.Count; i++)
                //////    {
                //////        IdsAssets_by_room.Add(Convert.ToInt32(dt.Rows[i][1].ToString()));
                //////    }
                //////    IdTransaction = Convert.ToInt32(dt.Rows[0][0].ToString());
                //////}
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

        private void btnEntregar_Click(object sender, EventArgs e)
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
                    //VER COMO HACER ROLLBACK!!
                    
                    //Actualizo el numero del comprobante.
                    sql = "UPDATE book set number=number+1 where code='" + TipoComprobante + "'";
                    MySqlDataReader dataUpdBookNumber = DB.GetData(sql);
                    //Inserto registro en la tabla transaction para reflejar la entrega, dev o auditoria.
                    sql = "INSERT INTO transaction(bookNumber, date,bookCode, idTransaction_Status) values(" + dtBook.Rows[0][0] + ", now(),'"+TipoComprobante+"',1) ";
                    long IDTransaction = DB.InsertData(sql);
                    //Guardo los bienes del local aparejados a la transaction realizada.
                    for (int j = 0; j < dgLocales.Rows.Count; j++)
                    {
                        string Status = "";
                        Status = dgLocales["Estado Obs.", j].Value.ToString();
                        sql = "INSERT INTO assets_room_transaction (delivery_status,delivery_date,idTransaction,idAsset_by_room) " +
                        " select " + Status + ", now()," + IDTransaction + ",idassets_by_room from assets_by_room inner join assets on idAsset = id_assets " +
                        //" select idStatus, now()," + IDTransaction + ",idassets_by_room from assets_by_room inner join assets on idAsset = id_assets " +
                        " where idRoom = " + IdRoomSelected;
                        long IDAssetRoomTrans = DB.InsertData(sql);
                    }
                        
                    //Asigno el local a un usuario responsable.
                    //IdUserResponsibleSelected = int.Parse(cbEntrega.SelectedValue.ToString());
                    sql = "UPDATE rooms_by_users SET id_user_responsible = (select idUsers from users where status = 1  " +
                    " and concat(last_name,', ',name)='"+ cbEntrega.SelectedItem + "') where end_date is null and id_room = " + IdRoomSelected;
                    long IDRoomByUser = DB.InsertData(sql);

                    MessageBox.Show("Se ha realizado la entrega del local exitosamente.");
                    PDF_Click(null, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar a quien realizar la entrega del local.");
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //string sql = "";
            //for (int i = 0; i < dgLocales.Rows.Count; i++)
            //{
            //    MessageBox.Show(dgLocales.Columns["idTransaction"].ToString());
            //    MessageBox.Show(dgLocales.Columns["idAsset_by_room"].ToString());
            //}
        }

        private void btPicking_Click(object sender, EventArgs e)
        {
            Picking formPicking = new Picking(this);
            formPicking.ShowDialog();
            //Recorro lo que pickee y por cada uno me fijo si coincide con los bienes, en tal caso los pinto de verde 
            //y seteo en "1" el valor "matches" del datatable dtReturnPicking.
            for (int i = 0; i< dtReturnPicking.Rows.Count; i++)
            {
                for (int j = 0; j < dgLocales.Rows.Count; j++)
                {
                    if (dgLocales.Rows[j].Cells["Codigo"].FormattedValue.ToString() == dtReturnPicking.Rows[i][0].ToString())
                    {
                        dgLocales["color", j].Style.BackColor = Color.Green;
                        dtReturnPicking.Rows[i][1] = "1";                  
                    }
                }
            }
            //Todos aquellos bienes pickeados que no estaban en la grilla original los agrego con color amarillo.
            for (int i = 0; i < dtReturnPicking.Rows.Count; i++)
            {
                if (dtReturnPicking.Rows[i][1].ToString() == "0")
                {
                    //DataTable dt = new DataTable();
                    //dt.Columns.Add("bien", typeof(string));
                    
                    DataRow dr = dataTableDgLocales.NewRow();
                    dr["Codigo"] = dtReturnPicking.Rows[i][0].ToString();
                    dr["color"] = "";
                    dataTableDgLocales.Rows.Add(dr);
                    dgLocales.DataSource = dataTableDgLocales;
                    dgLocales["color", dgLocales.NewRowIndex-1].Style.BackColor = Color.Yellow;
                }
            }
            
            //Agrego la columna "Estado Observado"
            MySqlDataReader dataAssets_status = DB.GetData("select distinct idstatus, description from assets_status");
            //List<string> assets_status = new List<string>();
            DataSet ds = new DataSet();
            if (dataAssets_status.HasRows)
            {
                DataTable das = new DataTable();
                das.Load(dataAssets_status);
                ds.Tables.Add(das);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                var column = new DataGridViewComboBoxColumn();
                column.Name = "Estado Obs.";
                column.DataSource = ds.Tables[0];
                column.DisplayMember = "description";
                column.ValueMember = "idstatus";
                dgLocales.Columns.Add(column);
            }
                //var column = new DataGridViewComboBoxColumn();
                //column.Name = "Estado Obs.";
                //column.DataSource = new List<Foo>(assets_status);
                //column.DisplayMember = "description";
                //column.ValueMember = "idstatus";
                //dgLocales.Columns.Add(column);
            
            //El resto de los bienes que figuraban en el local y no fueron pickeados van a color rojo y deshabilito
            //la posibilidad de cambiarles el estado.
            for (int j = 0; j < dgLocales.Rows.Count; j++)
            {
                if (dgLocales["color", j].Style.BackColor != Color.Green && dgLocales["color", j].Style.BackColor != Color.Yellow)
                {
                    dgLocales["color", j].Style.BackColor = Color.Red;
                    dgLocales["Estado Obs.", j].ReadOnly = true;
                }
            }
            
        }
     }
}
