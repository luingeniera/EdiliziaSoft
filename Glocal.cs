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
            if (cbNivel.SelectedItem == null || cbNumero.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un nivel y un local.");
                
            } 
            else 
            {
                string deliveriedTo = "";
                string comprobante = "";
                string TipoComprobante = "";
                lblComprobante.Text = "";
                rbAuditoria.Enabled = false;
                rbDevolucion.Enabled = false;
                rbEntrega.Enabled = false;
                btnConfirmar.Visible = false;
                dgLocales.DataSource = null;
                if (rbEntrega.Checked == true)
                {
                    TipoComprobante = "ENT";
                    cbEntrega.Enabled = true;
                }
                if (rbDevolucion.Checked == true)
                {
                    TipoComprobante = "DEV";
                    cbEntrega.Enabled = false;
                }
                if (rbAuditoria.Checked == true)
                {
                    TipoComprobante = "AUD";
                    cbEntrega.Enabled = false;
                }

                dgLocales.DataSource = bindingSource1;
                if (dgLocales.Columns.Contains("Estado Obs."))
                    dgLocales.Columns.Remove("Estado Obs.");

                string sqlQuery = "";
                //Con esta consulta busco el nombre de la oficina, dueño y cantidad de bienes que tiene.
                sqlQuery = "select rooms.description as 'oficina' , CONCAT(resp.name,', ',resp.last_name) as 'responsable', " +
                "count(abr.idasset) as 'bienes', rooms.idRooms from rooms LEFT JOIN edilizia.rooms_by_users ON idRooms = id_room " +
                "LEFT JOIN edilizia.users resp on resp.idUsers = id_user_owner LEFT JOIN edilizia.assets_by_room abr on abr.idRoom = rooms.idRooms " +
                "WHERE rooms.level=" + cbNivel.SelectedItem + " and rooms.number=" + cbNumero.SelectedItem;
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
                " ,art.idtransaction,abr.idAsset, abr.idRoom, '' as Evaluacion FROM rooms r INNER JOIN edilizia.assets_by_room abr ON abr.idRoom = r.idRooms INNER JOIN assets a on a.id_assets = abr.idAsset" +
                " INNER JOIN assets_status s on a.idStatus = s.idstatus LEFT OUTER JOIN rooms_by_users rbu on r.idRooms = rbu.id_room and rbu.end_date is null " +
                " LEFT OUTER JOIN users u on u.idUsers = rbu.id_user_responsible LEFT OUTER JOIN assets_room_Transaction art on art.id_Asset = abr.idAsset and art.id_Room = abr.idRoom and art.return_date is null" +
                " LEFT OUTER JOIN transaction t on t.idtransaction = art.idtransaction and t.bookCode='"+TipoComprobante+"' WHERE level = " + cbNivel.SelectedItem + " and number = " + cbNumero.SelectedItem + " order by a.code";
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
                    dgLocales.Columns["idAsset"].Visible = false;
                    dgLocales.Columns["idRoom"].Visible = false;
                    btPicking.Enabled = true;

                }

                if (deliveriedTo == "")
                {
                    //Habilito el combo box de "entregar a" y lo completo con los usuarios activos (status=1)
                    cbEntrega.Enabled = true;
                    MySqlDataReader dataReaderUsers = DB.GetData("select distinct concat(last_name, ', ', name) from users where status = 1");
                    if (dataReaderUsers.HasRows)
                    {
                        cbEntrega.Items.Clear();
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
                    //Para los casos en que estoy filtrando un local que ya se generó la entrega
                    //oculto el btn Entregar y muestro el salir, inhabilito el combo de personas a entregar y 
                    //agrego la columna "estado observado" para que puedan realizar correciones.
                    if (TipoComprobante == "ENT")
                    {
                        btnEntregar.Visible = false;
                        btnConfirmar.Visible = true;

                        cbEntrega.Enabled = false;
                        cbEntrega.Text = "";
                        cbEntrega.SelectedText = deliveriedTo;
                        lblComprobante.Text = comprobante;
                        btnConfirmar.Visible = true;
                        btPicking.Enabled = false;
                    }
                    if (TipoComprobante == "DEV")
                    {
                        //Habilito el combo box de "entregar a" y lo completo con los usuarios activos (status=1)
                        //cbEntrega.Enabled = true;
                        //MySqlDataReader dataReaderUsers = DB.GetData("select distinct concat(last_name, ', ', name) from users where status = 1");
                        //if (dataReaderUsers.HasRows)
                        //{
                        //    DataTable dt = new DataTable();
                        //    dt.Load(dataReaderUsers);
                        //    for (int i = 0; i < dt.Rows.Count; i++)
                        //    {
                        //        cbEntrega.ValueMember = "Valor";
                        //        cbEntrega.DisplayMember = "Usuario";
                        //        cbEntrega.Items.Add(dt.Rows[i][0]);
                        //    }
                        //}
                    }
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
            {
                sql = "select distinct number from rooms where level = " + cbNivel.SelectedItem;
                cbNumero.Enabled = true;
            }
            else
            {
                sql = "select distinct number from rooms";
                cbNumero.Enabled = false;
            }
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

        private void btnPDF_Click(object sender, EventArgs e)
        {
           //PDF pp = new PDF();
         
           //origen =1
            //pp.GenerarPDF(1,"Entrega de Local", "1", "Entrega",
            //            "cuerpo", dgLocales, cbEntrega.SelectedItem.ToString());
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            string TipoComprobante = "";
            if (cbEntrega.SelectedIndex > -1)
            {
                
                WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
                string sql = "";
                int totalRows = 0;
                int rowsVerde = 0;
                totalRows = dgLocales.Rows.Count - 1;
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
                    //sql = " call ActualizaNroComprobante('" + TipoComprobante + "')";
                    MySqlDataReader dataUpdBookNumber = DB.GetData(sql);
                    //Inserto registro en la tabla transaction para reflejar la entrega, dev o auditoria.
                    sql = "INSERT INTO transaction(bookNumber, date,bookCode, idTransaction_Status) values(" + dtBook.Rows[0][0] + ", now(),'"+TipoComprobante+"',1) ";
                    //sql = "call InsTransaction('" + TipoComprobante + "')";
                    long IDTransaction = DB.InsertData(sql);

                    //Guardo los bienes del local aparejados a la transaction realizada.
                    for (int j = 0; j < dgLocales.Rows.Count-1; j++)
                    {
                        string Status = "";
                        string idAsset = "";
                        string observaciones = "";
                        if (dgLocales["Estado Obs.", j].Value != null)
                        {
                            idAsset = dgLocales["idAsset", j].Value.ToString();
                            Status = dgLocales["Estado Obs.", j].Value.ToString();
                            if (dgLocales["Observaciones", j].Value != null)
                                observaciones = dgLocales["Observaciones", j].Value.ToString();
                            //Observaciones
                            //Si es verde guardo normalmente.
                            if (dgLocales["Evaluacion",j].Style.BackColor == Color.Green)
                            {
                                rowsVerde++;

                                sql = "INSERT INTO assets_room_transaction (delivery_status,delivery_date,observation,idTransaction,color,id_Asset,id_Room) " +
                                " values ('" + Status + "', now(),'" + observaciones + "', " + IDTransaction + ",'1', " + idAsset + ", " + IdRoomSelected + ")";
                                //sql = "call InsAssetsTransaction('" + Status + "','" + observaciones + "'," + IDTransaction + "," + idAsset + "," + IdRoomSelected + ")";
                                long IDAssetRoomTrans = DB.InsertData(sql);

                                //sql = "UPDATE assets set idStatus = " +Status+ " where id_assets = " + idAsset ;
                                //long IDAsset = DB.InsertData(sql);
                            }

                            #region amarillo
                            //Si es amarillo transfiero el bien al local seleccionado.
                            if (dgLocales["Evaluacion", j].Style.BackColor == Color.Yellow)
                            {
                                sql = "update assets_by_room set idRoom = "+ IdRoomSelected + " where idAsset = "+idAsset;
                                long IDAssetsByRoom = DB.InsertData(sql);

                                sql = "INSERT INTO assets_room_transaction (delivery_status,delivery_date,observation,idTransaction,color,id_Asset,id_Room) " +
                                " values ('" + Status + "', now(),'" + observaciones + "', " + IDTransaction + ",'2', " + idAsset + ", " + IdRoomSelected + ")";
                                long IDAssetRoomTrans = DB.InsertData(sql);

                                sql = "UPDATE assets set idStatus = " + Status + " where id_assets = " + idAsset;
                                long IDAsset = DB.InsertData(sql);

                                //INSERTO LAS DIFERENCIAS. En el caso de amarillo figuraba en un local y lo pickeo donde hago la entrega (se movio).
                                //int IdRoomOrig = 0;
                                string estadoOrig = "''";
                                if (dgLocales["Estado", j].Value.ToString() == "Bueno")
                                    estadoOrig = "1";
                                if (dgLocales["Estado", j].Value.ToString() == "Regular")
                                    estadoOrig = "2";
                                if (dgLocales["Estado", j].Value.ToString() == "Malo")
                                    estadoOrig = "3";
                                if (dgLocales["Estado", j].Value.ToString() == "Nuevo")
                                    estadoOrig = "10";
                                sql = "INSERT INTO diferences (idComprobante,idBien,idLocalOrig,idLocalPicking,idEstadoOrig,idEstadoObs,Semaforo) " +
                                " values (" + IDTransaction + ", " + dgLocales["idAsset", j].Value.ToString() + ", " + dgLocales["idRoom", j].Value.ToString() + ", " + IdRoomSelected + ","+ estadoOrig + ", " + Status + ", 'amarillo')";
                                //" values (" + IDTransaction + ", " + IDAsset + ", " + IdRoomOrig + ", " + IdRoomSelected + ", " + dgLocales["Estado", j].Value.ToString() + ", " + Status + ", 'amarillo')";
                                //En la grilla deberia guardar el idStatus del bien y ocultarlo. Ojo q me cambia el for
                                long idDifference = DB.InsertData(sql);
                            }
                            #endregion
                        }
                        else //Este else significa que entro por evaluacion = rojo
                        {
                            //Si es rojo muevo el bien al dep. virtual
                            if (dgLocales["Evaluacion", j].Style.BackColor == Color.Red)
                            {
                                if (dgLocales["Observaciones", j].Value != null)
                                    observaciones = dgLocales["Observaciones", j].Value.ToString();

                                //Por defecto tomo que el idRoom=1 es el deposito virtual.
                                idAsset = dgLocales["idAsset", j].Value.ToString();
                                sql = "update assets_by_room set idRoom = 1 where idAsset=" + idAsset;
                                long IDAssetsByRoom = DB.InsertData(sql);

                                sql = "INSERT INTO assets_room_transaction (delivery_date,observation,idTransaction,color,id_Asset,id_Room) " +
                                " values (now(),'" + observaciones + "', " + IDTransaction + ",'3', " + idAsset + ", 1)";
                                long IDAssetRoomTrans = DB.InsertData(sql);

                                sql = "INSERT INTO diferences (idComprobante,idBien,idLocalOrig,idLocalPicking,Semaforo) " +
                                " values (" + IDTransaction + ", " + dgLocales["idAsset", j].Value.ToString() + ", " + dgLocales["idRoom", j].Value.ToString() + ", '1','rojo')";
                                //" values (" + IDTransaction + ", " + IDAsset + ", " + IdRoomOrig + ", " + IdRoomSelected + ", " + dgLocales["Estado", j].Value.ToString() + ", " + Status + ", 'amarillo')";
                                //En la grilla deberia guardar el idStatus del bien y ocultarlo. Ojo q me cambia el for
                                long idDifference = DB.InsertData(sql);
                            }
                        }
                    }
                    
                    if (totalRows == rowsVerde)
                    {
                        //Si coinciden las cantidades es xq estuvo todo bien y el estado de la transaccion es aprobado.
                        sql = "UPDATE transaction SET idTransaction_status=3 where idtransaction=" + IDTransaction;
                        long idTrans = DB.InsertData(sql);                        
                    } 
                    else
                    {
                        //Si NO coinciden las cantidades es xq existen diferencias y el estado de la transaccion
                        //es Pendiente de aprobar.
                        sql = "UPDATE transaction SET idTransaction_status=2 where idtransaction=" + IDTransaction;
                        long idTrans = DB.InsertData(sql);
                    }
                    //Asigno el local a un usuario responsable.
                    //IdUserResponsibleSelected = int.Parse(cbEntrega.SelectedValue.ToString());
                    if (rbEntrega.Checked == true)
                        sql = "UPDATE rooms_by_users SET id_user_responsible = (select idUsers from users where status = 1  " +
                         " and concat(last_name,', ',name)='" + cbEntrega.SelectedItem + "') where end_date is null and id_room = " + IdRoomSelected;
                    if (rbDevolucion.Checked == true)
                        sql = "UPDATE rooms_by_users SET id_user_responsible = null  where end_date is null and id_room = " + IdRoomSelected;

                    long IDRoomByUser = DB.InsertData(sql);

                    MessageBox.Show("Se ha realizado la entrega del local exitosamente.");
                    
                    PDF_Comp callPDF = new PDF_Comp();
                    callPDF.PrintPDF(Convert.ToInt32(IDTransaction));
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar a quien realizar la entrega del local.");
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btPicking_Click(object sender, EventArgs e)
        {
            cbNivel.Enabled = false;
            cbNumero.Enabled = false;
            Picking formPicking = new Picking(this);
            formPicking.ShowDialog();
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            string sql = "";

            //Recorro lo que pickee y por cada uno me fijo si coincide con los bienes, en tal caso los pinto de verde 
            //y seteo en "1" el valor "matches" del datatable dtReturnPicking.
            for (int i = 0; i< dtReturnPicking.Rows.Count; i++)
            {
                for (int j = 0; j < dgLocales.Rows.Count; j++)
                {
                    if (dgLocales.Rows[j].Cells["Codigo"].FormattedValue.ToString() == dtReturnPicking.Rows[i][0].ToString().ToUpper())
                    {
                        dgLocales["Evaluacion", j].Style.BackColor = Color.Green;
                        dtReturnPicking.Rows[i][1] = "1";                  
                    }
                }
            }
            //Todos aquellos bienes pickeados que no estaban en la grilla original los agrego con color amarillo.
            for (int i = 0; i < dtReturnPicking.Rows.Count; i++)
            {
                if (dtReturnPicking.Rows[i][1].ToString() == "0")
                {
                    //Recupero el id_assets y el id_room
                    sql = "SELECT id_assets,idRoom FROM edilizia.assets inner join assets_by_room on id_assets = idAsset " +
                        "where code = '" + dtReturnPicking.Rows[i][0].ToString().ToUpper() + "'";
                    MySqlDataReader dataReaderInfo = DB.GetData(sql);
                    //Si existe el bien lo agrego y pinto en amarillo, sino digo que no existe el bien.
                    if (dataReaderInfo.HasRows)
                    {
                        DataRow dr = dataTableDgLocales.NewRow();
                        dr["Codigo"] = dtReturnPicking.Rows[i][0].ToString().ToUpper();
                        dr["Evaluacion"] = "";
                        DataTable dtInfo = new DataTable();
                        dtInfo.Load(dataReaderInfo);
                        dr["idAsset"] = dtInfo.Rows[0][0].ToString();
                        dr["idRoom"] = dtInfo.Rows[0][1].ToString();
                        dataTableDgLocales.Rows.Add(dr);
                        dgLocales.DataSource = dataTableDgLocales;
                        dgLocales["Evaluacion", dgLocales.NewRowIndex - 1].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        MessageBox.Show("El bien " + dtReturnPicking.Rows[i][0].ToString().ToUpper() + " no existe y no será agregado. Por favor asegurese que sea correcto.");
                    }
                }
            }

            //Agrego la columna "Estado Observado"
            if (dtReturnPicking.Rows.Count > 0)
            {
                MySqlDataReader dataAssets_status = DB.GetData("select distinct idstatus, description from assets_status");
                //List<string> assets_status = new List<string>();
                DataSet ds = new DataSet();
                if (dataAssets_status.HasRows)
                {
                    DataTable das = new DataTable();
                    das.Load(dataAssets_status);
                    ds.Tables.Add(das);
                }
                //Son 7 columnas porque tambien tengo columnas invisibles.
                if (ds.Tables[0].Rows.Count > 0 && dgLocales.Columns.Count == 7)
                {
                    var column = new DataGridViewComboBoxColumn();
                    column.Name = "Estado Obs.";
                    column.DataSource = ds.Tables[0];
                    column.DisplayMember = "description";
                    column.ValueMember = "idstatus";
                    column.ToolTipText = "Asegurarse de haber realizado el picking completo del local antes de actualizar estos datos";
                    dgLocales.Columns.Add(column);

                    var column1 = new DataGridViewTextBoxColumn();
                    column1.Name = "Observaciones";
                    column1.ToolTipText = "Asegurarse de haber realizado el picking completo del local antes de actualizar estos datos";
                    dgLocales.Columns.Add(column1);
                }

                //El resto de los bienes que figuraban en el local y no fueron pickeados van a color rojo y deshabilito
                //la posibilidad de cambiarles el estado.
                for (int j = 0; j < dgLocales.Rows.Count - 1; j++)
                {
                    if (dgLocales["Evaluacion", j].Style.BackColor != Color.Green && dgLocales["Evaluacion", j].Style.BackColor != Color.Yellow)
                    {
                        dgLocales["Evaluacion", j].Style.BackColor = Color.Red;
                        dgLocales["Estado Obs.", j].ReadOnly = true;
                    }
                }
            }
        }

        private void cbNumero_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbNivel.SelectedIndex > -1)
            {
                btBuscar_Click(null, new EventArgs());
            }
        }

        private void dgLocales_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgLocales.Columns[e.ColumnIndex].Name == "Estado Obs.")
            {
                if (dgLocales[e.ColumnIndex, e.RowIndex].FormattedValue.ToString() != dgLocales["Estado", e.RowIndex].Value.ToString())
                    dgLocales["Evaluacion", e.RowIndex].Style.BackColor = Color.Yellow;
                else
                    dgLocales["Evaluacion", e.RowIndex].Style.BackColor = Color.Green;
            }
        }
    }
}
