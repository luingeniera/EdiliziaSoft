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
        private int IdRoomSelected;
        private string CodeLastTransaction;
        WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
        public Glocal()
        {
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            
            string HasDifference = "0";
            if (cbNivel.SelectedItem == null || cbNumero.SelectedItem == null || cbEdificio.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un edificio, un nivel y un local.");

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
                btnSalir.Visible = true;
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

                //Busco cual es el ultimo comprobante generado para el local, exceptuando auditorias.
                string LastTransaction = "";
                LastTransaction = "SELECT t.bookCode FROM edilizia.assets_room_transaction art inner join edilizia.transaction t on art.idtransaction = t.idtransaction " +
                " inner join rooms r on r.idRooms = art.id_Room inner join buildings b on b.idbuilding = r.buildings where t.bookCode <> 'AUD' and r.level='" + cbNivel.SelectedItem + "' and r.number=" + cbNumero.SelectedItem +
                " and b.description ='" + cbEdificio.SelectedItem + "' order by t.idtransaction desc limit 1 ";

                MySqlDataReader dataReaderLastTrans = DB.GetData(LastTransaction);
                if (dataReaderLastTrans.HasRows)
                {
                    DataTable dtInfoLastTran = new DataTable();
                    dtInfoLastTran.Load(dataReaderLastTrans);
                    CodeLastTransaction = dtInfoLastTran.Rows[0][0].ToString();
                    if (TipoComprobante == "AUD")
                    {
                        btnConfirmar.Visible = true;
                        btnConfirmar.Enabled = true;
                        btnSalir.Visible = true;
                    }
                    if (TipoComprobante == "ENT" && CodeLastTransaction == "ENT")
                    {
                        MessageBox.Show("Este local ya presenta una entrega vigente. Debe realizar otro tipo de transacción.");
                        btnConfirmar.Visible = false;
                        btnConfirmar.Enabled = false;
                        btnSalir.Visible = true;
                        btnSalir.Enabled = true;
                        cbEntrega.Enabled = false;
                        rbAuditoria.Enabled = true;
                        rbDevolucion.Enabled = true;
                        rbEntrega.Enabled = true;
                        cbNumero.SelectedIndex = -1;
                        cbNivel.SelectedIndex = -1;
                        cbEdificio.SelectedIndex = -1;
                        //datos_Grilla();
                        return;
                    }
                    if (TipoComprobante == "DEV" && CodeLastTransaction == "DEV")
                    {
                        MessageBox.Show("Este local ya presenta una devolución vigente. Debe realizar otro tipo de transacción.");
                        btnConfirmar.Visible = false;
                        btnConfirmar.Enabled = false;
                        btnSalir.Visible = true;
                        btnSalir.Enabled = true;
                        cbEntrega.Enabled = false;
                        rbAuditoria.Enabled = true;
                        rbDevolucion.Enabled = true;
                        rbEntrega.Enabled = true;
                        cbNumero.SelectedIndex = -1;
                        cbNivel.SelectedIndex = -1;
                        cbEdificio.SelectedIndex = -1;
                        //datos_Grilla();
                        return;
                    }
                }


                string sqlQuery = "";
                if (rbEntrega.Checked == true)
                {
                    //Con esta consulta busco el nombre de la oficina, dueño y cantidad de bienes que tiene.
                    sqlQuery = "select CONCAT('[',rooms.code,'] - ', rooms.description) as 'Local' , CONCAT(resp.last_name,', ',resp.name) as 'responsable', " +
                    "count(abr.idasset) as 'bienes', rooms.idRooms,CONCAT(tra.bookCode,'-',tra.bookNumber) as 'comprobante' from rooms LEFT JOIN edilizia.rooms_by_users ON idRooms = id_room " +
                    " inner join buildings b on b.idbuilding = rooms.buildings LEFT JOIN edilizia.users resp on resp.idUsers = id_user_owner LEFT JOIN edilizia.assets_by_room abr on abr.idRoom = rooms.idRooms " +
                    "LEFT JOIN edilizia.diferences dif on id_room = dif.idLocalOrig and dif.Semaforo <> 1 and dif.FechaGestionDiferencia <> null LEFT JOIN edilizia.transaction tra on dif.idComprobante = tra.idtransaction " +
                    "WHERE rooms.level='" + cbNivel.SelectedItem + "' and rooms.number=" + cbNumero.SelectedItem + " and b.description ='" + cbEdificio.SelectedItem + "'";
                }
                else
                {
                    //En el caso de una auditoria o devolucion el responsable no es el 'id_user_owner', sino el 'id_user_responsible' porque ya tiene alguien asignado.
                    sqlQuery = "select CONCAT('[',rooms.code,'] - ', rooms.description) as 'Local' , CONCAT(resp.last_name,', ',resp.name) as 'responsable', " +
                    "count(abr.idasset) as 'bienes', rooms.idRooms,CONCAT(tra.bookCode,'-',tra.bookNumber) as 'comprobante' from rooms LEFT JOIN edilizia.rooms_by_users ON idRooms = id_room " +
                    "inner join buildings b on b.idbuilding = rooms.buildings LEFT JOIN edilizia.users resp on resp.idUsers = id_user_responsible LEFT JOIN edilizia.assets_by_room abr on abr.idRoom = rooms.idRooms " +
                    "LEFT JOIN edilizia.diferences dif on id_room = dif.idLocalOrig and dif.FechaGestionDiferencia is null LEFT JOIN edilizia.transaction tra on dif.idComprobante = tra.idtransaction " +
                    "WHERE rooms.level='" + cbNivel.SelectedItem + "' and rooms.number=" + cbNumero.SelectedItem + " and b.description ='" + cbEdificio.SelectedItem + "'";
                }
                MySqlDataReader dataReaderInfo = DB.GetData(sqlQuery);
                if (dataReaderInfo.HasRows)
                {
                    DataTable dtInfo = new DataTable();
                    dtInfo.Load(dataReaderInfo);
                    lblLocal.Text = "Local: " + dtInfo.Rows[0][0].ToString();
                    lblResponsable.Text = "Responsable: " + dtInfo.Rows[0][1].ToString();
                    lblActivos.Text = "Cant. Bienes: " + dtInfo.Rows[0][2].ToString();
                    IdRoomSelected = int.Parse(dtInfo.Rows[0][3].ToString());
                    if (dtInfo.Rows[0][4].ToString() != "")
                    {
                        MessageBox.Show("No puede generar un comprobante nuevo hasta gestionar las diferencias que el local posee. Comprobante relacionado: " + dtInfo.Rows[0][4].ToString());
                        btnConfirmar.Visible = false;
                        btnSalir.Visible = true;
                        HasDifference = "1";
                        rbAuditoria.Enabled = true;
                        rbDevolucion.Enabled = true;
                        rbEntrega.Enabled = true;
                        cbNivel.SelectedIndex = -1;
                        cbEdificio.SelectedIndex = -1;
                        cbNumero.SelectedIndex = -1;
                        lblLocal.Text = "Local: ";
                        lblResponsable.Text = "Responsable: ";
                        lblActivos.Text = "Cant. Activos: ";
                        return;
                    }
                }
                //Busco datos de los bienes del local para completar la grilla.
                if (rbEntrega.Checked != true)
                {
                    sqlQuery = "SELECT distinct a.code as 'Referencia', a.description as 'Nombre de activo' ,(select s.description from assets_room_transaction art INNER JOIN assets_status s on art.delivery_status = s.idstatus " +
                    " where id_Asset = abr.idAsset and id_Room = abr.idRoom and return_date is null order by idtransaction desc limit 1)  as 'Estado', concat(last_name, ', ', name) as 'Responsible', '' as 'Comprobante' " +
                    " ,'' as idtransaction,abr.idAsset, abr.idRoom, /*(select color from assets_room_Transaction atr where atr.id_Asset = abr.idAsset and atr.id_Room = abr.idRoom order by idtransaction desc limit 1)*/ '' as 'Eval' " + //art.color as 'Eval' 
                    " FROM rooms r INNER JOIN edilizia.assets_by_room abr ON abr.idRoom = r.idRooms INNER JOIN assets a on a.id_assets = abr.idAsset" +
                    " LEFT OUTER JOIN rooms_by_users rbu on r.idRooms = rbu.id_room and rbu.end_date is null " +
                    " inner join edilizia.buildings bu on bu.idbuilding = r.buildings LEFT OUTER JOIN users u on u.idUsers = rbu.id_user_responsible " +
                    " WHERE  bu.Description  = '" + cbEdificio.SelectedItem + "' and level = '" + cbNivel.SelectedItem + "' and number = " + cbNumero.SelectedItem + " order by a.code";
                }
                else
                {
                    sqlQuery = "SELECT distinct a.code as 'Referencia', a.description as 'Nombre de activo' ,(select s.description from assets_room_transaction art INNER JOIN " +
                    "assets_status s on art.delivery_status = s.idstatus  where id_Asset = abr.idAsset and id_Room = abr.idRoom and return_date is null order by idtransaction desc limit 1)  as 'Estado', " +
                    "concat(last_name, ', ', name) as 'Responsible', '' as 'Comprobante'  ,'' as idtransaction,abr.idAsset, abr.idRoom, '' as 'Eval' " +
                    "FROM rooms r INNER JOIN edilizia.assets_by_room abr ON abr.idRoom = r.idRooms INNER JOIN assets a on a.id_assets = abr.idAsset LEFT OUTER JOIN rooms_by_users rbu on r.idRooms = rbu.id_room and rbu.end_date is null " +
                    "inner join edilizia.buildings bu on bu.idbuilding = r.buildings LEFT OUTER JOIN users u on u.idUsers = rbu.id_user_responsible" + " WHERE  bu.Description  = '" + cbEdificio.SelectedItem + "' and level = '" + cbNivel.SelectedItem + "' and number = " + cbNumero.SelectedItem + " order by a.code";

                    /* sqlQuery = "SELECT a.code as 'Referencia', a.description as 'Nombre de activo' ,s.description as 'Estado', concat(last_name, ', ', name) as 'Responsible', concat(t.bookCode,'-',t.bookNumber) as 'Comprobante' " +
                    " ,art.idtransaction,abr.idAsset, abr.idRoom, '' as 'Eval' FROM rooms r INNER JOIN edilizia.assets_by_room abr ON abr.idRoom = r.idRooms INNER JOIN assets a on a.id_assets = abr.idAsset" +
                    " INNER JOIN assets_status s on a.idStatus = s.idstatus LEFT OUTER JOIN rooms_by_users rbu on r.idRooms = rbu.id_room and rbu.end_date is null " +
                   "  inner join edilizia.buildings bu on bu.idbuilding = r.buildings " +
                    " LEFT OUTER JOIN users u on u.idUsers = rbu.id_user_responsible LEFT OUTER JOIN assets_room_Transaction art on art.id_Asset = abr.idAsset and art.id_Room = abr.idRoom and art.return_date is null" +
                    " LEFT OUTER JOIN transaction t on t.idtransaction = art.idtransaction and t.bookCode='" + TipoComprobante + "' WHERE  bu.Description  = '" + cbEdificio.SelectedItem + "' and level = '" + cbNivel.SelectedItem + "' and number = " + cbNumero.SelectedItem + " order by a.code";
                    */
                }

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
                    dgLocales.Columns["Eval"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgLocales.Columns["Nombre de activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                }
                else if (rbDevolucion.Checked == true)
                {
                    MessageBox.Show("No se puede realizar la operación ya que el local no está asignado a ningún responsable.");
                    btnConfirmar.Visible = false;
                    btnSalir.Visible = true;
                    cbEntrega.Enabled = false;
                }
                //Si el local no tiene diferencias pendientes de gestionar habilito la opcion de entregar.
                if (HasDifference == "0")
                {
                    if (deliveriedTo == "")
                    {
                        //Habilito el combobox de "entregar a" y lo completo con los usuarios activos (status=1)
                        if (TipoComprobante != "AUD")
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
                    }
                    else
                    {
                        //Para los casos en que estoy filtrando un local que ya se generó la entrega
                        //oculto el btn Entregar y muestro el salir, inhabilito el combo de personas a entregar y 
                        //agrego la columna "estado observado" para que puedan realizar correciones.
                        if (TipoComprobante == "ENT")
                        {

                            btnConfirmar.Visible = false;
                            btnSalir.Visible = true;
                            cbEntrega.Enabled = false;
                            cbEntrega.Text = "";
                            cbEntrega.SelectedText = deliveriedTo;
                            lblComprobante.Text = comprobante;
                            //btPicking.Enabled = false;
                        }
                        else
                        {
                            btnConfirmar.Visible = true;
                            btnConfirmar.Enabled = true;
                            btnSalir.Visible = true;

                            cbEntrega.Enabled = false;
                            cbEntrega.Text = "";
                            cbEntrega.SelectedText = deliveriedTo;
                            lblComprobante.Text = comprobante;
                            //btPicking.Enabled = false;
                            //for (int i = 0; i < dgLocales.Rows.Count - 1; i++)
                            //{
                            //    if (dgLocales["Eval", i].Value.ToString() == "1")
                            //        dgLocales["Eval", i].Style.BackColor = Color.Green;
                            //    if (dgLocales["Eval", i].Value.ToString() == "2")
                            //        dgLocales["Eval", i].Style.BackColor = Color.Yellow;
                            //    if (dgLocales["Eval", i].Value.ToString() == "3")
                            //        dgLocales["Eval", i].Style.BackColor = Color.Red;
                            //    dgLocales["Eval", i].Value = null;
                            //}
                        }
                    }
                }
                else
                {
                    btPicking.Enabled = false;
                    if (rbEntrega.Checked != true)
                    {
                        for (int i = 0; i < dgLocales.Rows.Count - 1; i++)
                        {
                            if (dgLocales["Eval", i].Value.ToString() == "1")
                                dgLocales["Eval", i].Style.BackColor = Color.Green;
                            if (dgLocales["Eval", i].Value.ToString() == "2")
                                dgLocales["Eval", i].Style.BackColor = Color.Yellow;
                            if (dgLocales["Eval", i].Value.ToString() == "3")
                                dgLocales["Eval", i].Style.BackColor = Color.Red;
                            dgLocales["Eval", i].Value = null;
                        }
                    }
                }
            }
        }

        private void Glocal_Load(object sender, EventArgs e)
        {
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            MySqlDataReader dataReaderLevel = DB.GetData("select distinct description from buildings");
            //MySqlDataReader dataReaderLevel = DB.GetData("select distinct level from rooms");
            if (dataReaderLevel.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dataReaderLevel);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    /*
                    cbNivel.ValueMember = "Valor";
                    cbNivel.DisplayMember = "Nivel";
                    cbNivel.Items.Add(dt.Rows[i][0]);
                    */
                    cbEdificio.ValueMember = "Valor";
                    cbEdificio.DisplayMember = "Edificio";
                    cbEdificio.Items.Add(dt.Rows[i][0]);
                }
            }
        }



        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string TipoComprobante = "";
            if ((cbEntrega.SelectedIndex > -1 && rbEntrega.Checked == true) || (rbDevolucion.Checked == true) || (rbAuditoria.Checked == true))
            {

                WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
                string sql = "";
                int totalRows = 0;
                int rowsVerde = 0;
                totalRows = dgLocales.Rows.Count - 1;
                //Falta recuperar el id_user_owner seleccionado.
                sql = "UPDATE rooms_by_users set id_user_owner=2 where id_room=" + IdRoomSelected;
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
                    sql = "INSERT INTO transaction(bookNumber, date,bookCode, idTransaction_Status) values(" + dtBook.Rows[0][0] + ", now(),'" + TipoComprobante + "',1) ";
                    //sql = "call InsTransaction('" + TipoComprobante + "')";
                    long IDTransaction = DB.InsertData(sql);

                    //if (TipoComprobante == "ENT")
                    //{
                    //Guardo los bienes del local aparejados a la transaction realizada.
                    for (int j = 0; j < dgLocales.Rows.Count - 1; j++)
                    {
                        string Status = "";
                        string idAsset = "";
                        string observaciones = "";
                        //En el caso de un bien que no se encuentra (color rojo) no posee estado, por lo tanto no asigno el status.
                        if (dgLocales["Eval", j].Style.BackColor != Color.Red && dgLocales["Estado Obs.", j].Value != null) 
                            Status = dgLocales["Estado Obs.", j].Value.ToString();
                        if (dgLocales["Eval", j].Style.BackColor != Color.Red && dgLocales["Estado Obs.", j].Value == null)
                            Status = dgLocales["Estado", j].Value.ToString();
                        
                        if ((rbEntrega.Checked == true && Status != "") || (rbAuditoria.Checked == true && Status != "") || (rbDevolucion.Checked == true && Status != ""))
                        {
                            idAsset = dgLocales["idAsset", j].Value.ToString();
                            //Observaciones
                            if (dgLocales["Observaciones", j].Value != null)
                                observaciones = dgLocales["Observaciones", j].Value.ToString();

                            //Si es verde guardo normalmente.
                            if (dgLocales["Eval", j].Style.BackColor == Color.Green)
                            {
                                rowsVerde++;

                                sql = "INSERT INTO assets_room_transaction (delivery_status,delivery_date,observation,idTransaction,color,id_Asset,id_Room) " +
                                " values ('" + Status + "', now(),'" + observaciones + "', " + IDTransaction + ",'1', " + idAsset + ", " + IdRoomSelected + ")";
                                long IDAssetRoomTrans = DB.InsertData(sql);
                            }

                            //Si es amarillo transfiero el bien al local seleccionado. NO REALIZO LA TRANSFERENCIA, SINO QUE CREO LA DIFERENCIA. VALIDAR CON LUZ.
                            if (dgLocales["Eval", j].Style.BackColor == Color.Yellow)
                            {
                                sql = "INSERT INTO assets_room_transaction (delivery_status,delivery_date,observation,idTransaction,color,id_Asset,id_Room) " +
                                " values ('" + Status + "', now(),'" + observaciones + "', " + IDTransaction + ",'2', " + idAsset + ", " + IdRoomSelected + ")";
                                long IDAssetRoomTrans = DB.InsertData(sql);

                                //INSERTO LAS DIFERENCIAS. En el caso de amarillo figuraba en un local y lo pickeo donde hago la entrega (se movio).
                                string estadoOrig = "NULL";
                                if (dgLocales["Estado", j].Value.ToString() == "Bueno")
                                    estadoOrig = "1";
                                if (dgLocales["Estado", j].Value.ToString() == "Regular")
                                    estadoOrig = "2";
                                if (dgLocales["Estado", j].Value.ToString() == "Malo")
                                    estadoOrig = "3";
                                if (dgLocales["Estado", j].Value.ToString() == "Nuevo")
                                    estadoOrig = "10";

                                string idEstadoFinal = "";
                                string idLocalFinal = "";
                                //Comparo si hay diferencia en el local donde se encuentra el bien y el local donde dice el sistema deberia estar el mismo.
                                if (dgLocales["idRoom", j].Value.ToString() == Convert.ToString(IdRoomSelected))
                                    idLocalFinal = Convert.ToString(IdRoomSelected);
                                //Comparo si hay diferencias en el estado observado del bien y el estado que dice el sistema.
                                if (estadoOrig == Status)
                                    idEstadoFinal = Status;

                                sql = "INSERT INTO diferences (idComprobante,idBien,idLocalOrig,idLocalPicking,idEstadoOrig,idEstadoObs,Semaforo,idLocalFinal,idEstadoFinal) " +
                                " values (" + IDTransaction + ", " + dgLocales["idAsset", j].Value.ToString() + ", " + dgLocales["idRoom", j].Value.ToString() +
                                ", " + IdRoomSelected + "," + estadoOrig + ", " + Status + ", '2','" + idLocalFinal + "', '" + idEstadoFinal + "')";

                                //En la grilla deberia guardar el idStatus del bien y ocultarlo. Ojo q me cambia el for
                                long idDifference = DB.InsertData(sql);
                            }
                        }
                        else //Este else significa que entro por evaluacion = rojo
                        {
                            //Si es rojo muevo el bien al dep. virtual. LO MUEVO DIRECTAMENTE AL VIRTUAL Y SI LO ENCUENTRO LO TRAIGO?
                            if (dgLocales["Eval", j].Style.BackColor == Color.Red)
                            {
                                if (dgLocales["Observaciones", j].Value != null)
                                    observaciones = dgLocales["Observaciones", j].Value.ToString();

                                string estadoOrig = "NULL";
                                if (dgLocales["Estado", j].Value.ToString() == "Bueno")
                                    estadoOrig = "1";
                                if (dgLocales["Estado", j].Value.ToString() == "Regular")
                                    estadoOrig = "2";
                                if (dgLocales["Estado", j].Value.ToString() == "Malo")
                                    estadoOrig = "3";
                                if (dgLocales["Estado", j].Value.ToString() == "Nuevo")
                                    estadoOrig = "10";

                                //Por defecto tomo que el idRoom=127 es el deposito virtual.
                                idAsset = dgLocales["idAsset", j].Value.ToString();
                                sql = "update assets_by_room set idRoom = 127 where idAsset=" + idAsset;
                                long IDAssetsByRoom = DB.InsertData(sql);

                                sql = "INSERT INTO assets_room_transaction (delivery_date,observation,idTransaction,color,id_Asset,id_Room) " +
                                " values (now(),'" + observaciones + "', " + IDTransaction + ",'3', " + idAsset + ", " + IdRoomSelected + ")";
                                long IDAssetRoomTrans = DB.InsertData(sql);

                                sql = "INSERT INTO diferences (idComprobante,idBien,idLocalOrig,idLocalPicking,idEstadoOrig,idEstadoObs,Semaforo,idLocalFinal,idEstadoFinal) " +
                                " values (" + IDTransaction + ", " + dgLocales["idAsset", j].Value.ToString() + ", " + dgLocales["idRoom", j].Value.ToString() + ", '127',"+estadoOrig+","+estadoOrig+",'3','','')";
                                //En la grilla deberia guardar el idStatus del bien y ocultarlo. Ojo q me cambia el for
                                long idDifference = DB.InsertData(sql);
                            }
                        }
                    }
                    //}

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

                    //Asigno el local a un usuario responsable. SOLO EN LAS ENTREGAS
                    //IdUserResponsibleSelected = int.Parse(cbEntrega.SelectedValue.ToString());
                    if (rbEntrega.Checked == true)
                        sql = "UPDATE rooms_by_users SET id_user_responsible = (select idUsers from users where status = 1  " +
                         " and concat(last_name,', ',name)='" + cbEntrega.SelectedItem + "') where end_date is null and id_room = " + IdRoomSelected;
                    if (rbDevolucion.Checked == true)
                        sql = "UPDATE rooms_by_users SET id_user_responsible = null  where end_date is null and id_room = " + IdRoomSelected;

                    long IDRoomByUser = DB.InsertData(sql);
                    string mensaje = "Se ha realizado la ";
                    if (rbEntrega.Checked == true)
                    {
                        mensaje = mensaje + "Entrega " + dtBook.Rows[0][0].ToString() + " del local " + cbNivel.SelectedItem + "-" + cbNumero.SelectedItem + " exitosamente";
                    }
                    if (rbDevolucion.Checked == true)
                    {
                        mensaje = mensaje + "Devolución " + dtBook.Rows[0][0].ToString() + " del local " + cbNivel.SelectedItem + "-" + cbNumero.SelectedItem + " exitosamente";
                    }
                    if (rbAuditoria.Checked == true)
                    {
                        mensaje = mensaje + "Auditoría  " + dtBook.Rows[0][0].ToString() + " del local " + cbNivel.SelectedItem + "-" + cbNumero.SelectedItem + " exitosamente";
                    }
                    MessageBox.Show(mensaje);

                    PDF_Comp callPDF = new PDF_Comp();
                    callPDF.PrintPDF(Convert.ToInt32(IDTransaction));
                    Close();
                }
            }
            else if (rbEntrega.Checked == true)
            {
                MessageBox.Show("Primero debe seleccionar a quien realizar la entrega del local.");
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
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
            for (int i = 0; i < dtReturnPicking.Rows.Count; i++)
            {
                for (int j = 0; j < dgLocales.Rows.Count; j++)
                {
                    if (dgLocales.Rows[j].Cells["Referencia"].FormattedValue.ToString() == dtReturnPicking.Rows[i][0].ToString().ToUpper())
                    {
                        dgLocales["Eval", j].Style.BackColor = Color.Green;
                        dtReturnPicking.Rows[i][1] = "1";
                    }
                }
            }
            //Sacado de aca la parte que pinta en amarillo los bienes pickeados.(1)

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
                    //column.FlatStyle = FlatStyle.Flat;
                    dgLocales.Columns.Add(column);

                    var column1 = new DataGridViewTextBoxColumn();
                    column1.Name = "Observaciones";
                    column1.ToolTipText = "Asegurarse de haber realizado el picking completo del local antes de actualizar estos datos";
                    column1.Width = 250;
                    dgLocales.Columns.Add(column1);
                }
                //Agregado aca lo que pinta en amarillo. Ver(1).
                //Todos aquellos bienes pickeados que no estaban en la grilla original los agrego con color amarillo.
                for (int i = 0; i < dtReturnPicking.Rows.Count; i++)
                {
                    if (dtReturnPicking.Rows[i][1].ToString() == "0")
                    {
                        //Recupero el id_assets y el id_room
                        sql = "SELECT a.id_assets,idRoom,a.description,s.description,r.code FROM edilizia.assets a inner join assets_by_room on a.id_assets = idAsset " +
                            "INNER JOIN assets_status s on a.idStatus = s.idstatus INNER JOIN edilizia.rooms r on idRoom = r.idRooms where a.code = '" + dtReturnPicking.Rows[i][0].ToString().ToUpper() + "'";
                        MySqlDataReader dataReaderInfo = DB.GetData(sql);
                        //Si existe el bien lo agrego y pinto en amarillo, sino digo que no existe el bien.
                        if (dataReaderInfo.HasRows)
                        {
                            DataRow dr = dataTableDgLocales.NewRow();
                            dr["Referencia"] = dtReturnPicking.Rows[i][0].ToString().ToUpper();
                            dr["Eval"] = "";
                            DataTable dtInfo = new DataTable();
                            dtInfo.Load(dataReaderInfo);
                            dr["idAsset"] = dtInfo.Rows[0][0].ToString();
                            dr["idRoom"] = dtInfo.Rows[0][1].ToString();
                            dr["Nombre de activo"] = dtInfo.Rows[0][2].ToString();
                            dr["Estado"] = dtInfo.Rows[0][3].ToString();
                            dr["Comprobante"] = "";
                            dr["idTransaction"] = "";
                            dataTableDgLocales.Rows.Add(dr);
                            dgLocales.DataSource = dataTableDgLocales;
                            dgLocales["Eval", dgLocales.NewRowIndex - 1].Style.BackColor = Color.Yellow;
                            dgLocales["Observaciones", dgLocales.NewRowIndex - 1].Value = "Por sistemas en " + dtInfo.Rows[0][4].ToString();
                        }
                        else
                        {
                            MessageBox.Show("El bien " + dtReturnPicking.Rows[i][0].ToString().ToUpper() + " no existe y no será agregado. Por favor asegurese que sea correcto.");
                        }
                    }
                }

                //El resto de los bienes que figuraban en el local y no fueron pickeados van a color rojo y deshabilito
                //la posibilidad de cambiarles el estado.
                for (int j = 0; j < dgLocales.Rows.Count - 1; j++)
                {
                    if (dgLocales["Eval", j].Style.BackColor != Color.Green && dgLocales["Eval", j].Style.BackColor != Color.Yellow)
                    {
                        dgLocales["Eval", j].Style.BackColor = Color.Red;
                        dgLocales["Estado Obs.", j].ErrorText = "No habilitado.";
                        dgLocales["Estado Obs.", j].ReadOnly = true;

                    }
                    else
                    {
                        dgLocales["Estado Obs.", j].ReadOnly = false;
                        dgLocales["Estado Obs.", j].ErrorText = string.Empty;
                        for (int r = 0; r < dtReturnPicking.Rows.Count; r++)
                        {
                            if (dgLocales[0, j].FormattedValue.ToString() == dtReturnPicking.Rows[r][0].ToString() && dgLocales["Eval", j].Style.BackColor != Color.Yellow)
                                dgLocales["Observaciones", j].Value = "";
                        }
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
                    dgLocales["Eval", e.RowIndex].Style.BackColor = Color.Yellow;
                else
                    dgLocales["Eval", e.RowIndex].Style.BackColor = Color.Green;
                //Dentro del for comparo si el articulo al que le cambio el estado es un articulo pickeado que no pertenecia al local originalmente, en este caso
                //por mas q coincida el estado lo dejo en amarillo ya que no coincidira el local.
                for (int j = 0; j < dtReturnPicking.Rows.Count; j++)
                {
                    if (dgLocales[0, e.RowIndex].FormattedValue.ToString() == dtReturnPicking.Rows[j][0].ToString() && dtReturnPicking.Rows[j][1].ToString() == "0")
                        dgLocales["Eval", e.RowIndex].Style.BackColor = Color.Yellow;
                }
            }
        }

        private void cbEdificio_SelectedValueChanged(object sender, EventArgs e)
        {
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            string sql = "";
            cbNivel.Items.Clear();

            if (cbEdificio.SelectedIndex > -1)
            {
                sql = "select distinct level from rooms inner join buildings b on buildings = b.idbuilding " +
                " where b.description = '" + cbEdificio.SelectedItem + "'";
                cbNivel.Enabled = true;
            }
            else
            {
                sql = "select distinct number from rooms";
                cbNivel.Enabled = false;
            }
            MySqlDataReader dataReaderNumber = DB.GetData(sql);
            if (dataReaderNumber.HasRows)
            {
                DataTable dtNro = new DataTable();
                dtNro.Load(dataReaderNumber);
                for (int i = 0; i < dtNro.Rows.Count; i++)
                {
                    cbNivel.ValueMember = "Valor";
                    cbNivel.DisplayMember = "Nivel";
                    cbNivel.Items.Add(dtNro.Rows[i][0]);
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
                sql = "select distinct number from rooms where level = '" + cbNivel.SelectedItem + "'";
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

        private void datos_Grilla()
        {
            string sqlQuery = "";
            if (rbEntrega.Checked == true)
            {
                //Con esta consulta busco el nombre de la oficina, dueño y cantidad de bienes que tiene.
                sqlQuery = "select CONCAT('[',rooms.code,'] - ', rooms.description) as 'Local' , CONCAT(resp.last_name,', ',resp.name) as 'responsable', " +
                "count(abr.idasset) as 'bienes', rooms.idRooms,CONCAT(tra.bookCode,'-',tra.bookNumber) as 'comprobante' from rooms LEFT JOIN edilizia.rooms_by_users ON idRooms = id_room " +
                " inner join buildings b on b.idbuilding = rooms.buildings LEFT JOIN edilizia.users resp on resp.idUsers = id_user_owner LEFT JOIN edilizia.assets_by_room abr on abr.idRoom = rooms.idRooms " +
                "LEFT JOIN edilizia.diferences dif on id_room = dif.idLocalOrig and dif.Semaforo <> 1 LEFT JOIN edilizia.transaction tra on dif.idComprobante = tra.idtransaction " +
                "WHERE rooms.level='" + cbNivel.SelectedItem + "' and rooms.number=" + cbNumero.SelectedItem + " and b.description ='" + cbEdificio.SelectedItem + "'";
            }
            else
            {
                //En el caso de una auditoria o devolucion el responsable no es el 'id_user_owner', sino el 'id_user_responsible' porque ya tiene alguien asignado.
                sqlQuery = "select CONCAT('[',rooms.code,'] - ', rooms.description) as 'Local' , CONCAT(resp.last_name,', ',resp.name) as 'responsable', " +
                "count(abr.idasset) as 'bienes', rooms.idRooms,CONCAT(tra.bookCode,'-',tra.bookNumber) as 'comprobante' from rooms LEFT JOIN edilizia.rooms_by_users ON idRooms = id_room " +
                "inner join buildings b on b.idbuilding = rooms.buildings LEFT JOIN edilizia.users resp on resp.idUsers = id_user_responsible LEFT JOIN edilizia.assets_by_room abr on abr.idRoom = rooms.idRooms " +
                "LEFT JOIN edilizia.diferences dif on id_room = dif.idLocalOrig and dif.Semaforo <> 1 LEFT JOIN edilizia.transaction tra on dif.idComprobante = tra.idtransaction " +
                "WHERE rooms.level='" + cbNivel.SelectedItem + "' and rooms.number=" + cbNumero.SelectedItem + " and b.description ='" + cbEdificio.SelectedItem + "'";
            }
            MySqlDataReader dataReaderInfo = DB.GetData(sqlQuery);
            if (dataReaderInfo.HasRows)
            {
                DataTable dtInfo = new DataTable();
                dtInfo.Load(dataReaderInfo);
                lblLocal.Text = "Local: " + dtInfo.Rows[0][0].ToString();
                lblResponsable.Text = "Responsable: " + dtInfo.Rows[0][1].ToString();
                lblActivos.Text = "Cant. Bienes: " + dtInfo.Rows[0][2].ToString();
                IdRoomSelected = int.Parse(dtInfo.Rows[0][3].ToString());

            }
            //Busco datos de los bienes del local para completar la grilla.
            if (rbEntrega.Checked != true)
            {
                sqlQuery = "SELECT distinct a.code as 'Referencia', a.description as 'Nombre de activo' ,s.description as 'Estado', concat(last_name, ', ', name) as 'Responsible', '' as 'Comprobante' " +
                " ,'' as idtransaction,abr.idAsset, abr.idRoom, art.color as 'Eval' FROM rooms r INNER JOIN edilizia.assets_by_room abr ON abr.idRoom = r.idRooms INNER JOIN assets a on a.id_assets = abr.idAsset" +
                " INNER JOIN assets_status s on a.idStatus = s.idstatus LEFT OUTER JOIN rooms_by_users rbu on r.idRooms = rbu.id_room and rbu.end_date is null " +
                "  inner join edilizia.buildings bu on bu.idbuilding = r.buildings " +
                " LEFT OUTER JOIN users u on u.idUsers = rbu.id_user_responsible INNER JOIN assets_room_Transaction art on art.id_Asset = abr.idAsset and art.id_Room = abr.idRoom and art.return_date is null" +
                " WHERE  bu.Description  = '" + cbEdificio.SelectedItem + "' and level = '" + cbNivel.SelectedItem + "' and number = " + cbNumero.SelectedItem + "  and t.idTransaction_status=3 order by a.code";
            }
            else
            {
                sqlQuery = "SELECT a.code as 'Referencia', a.description as 'Nombre de activo' ,s.description as 'Estado', concat(last_name, ', ', name) as 'Responsible', concat(t.bookCode,'-',t.bookNumber) as 'Comprobante' " +
                " ,art.idtransaction,abr.idAsset, abr.idRoom, IFNULL(art.color,'') as 'Eval' FROM rooms r INNER JOIN edilizia.assets_by_room abr ON abr.idRoom = r.idRooms INNER JOIN assets a on a.id_assets = abr.idAsset" +
                " INNER JOIN assets_status s on a.idStatus = s.idstatus LEFT OUTER JOIN rooms_by_users rbu on r.idRooms = rbu.id_room and rbu.end_date is null " +
               "  inner join edilizia.buildings bu on bu.idbuilding = r.buildings " +
                " LEFT OUTER JOIN users u on u.idUsers = rbu.id_user_responsible LEFT OUTER JOIN assets_room_Transaction art on art.id_Asset = abr.idAsset and art.id_Room = abr.idRoom and art.return_date is null" +
                " LEFT OUTER JOIN transaction t on t.idtransaction = art.idtransaction and t.bookCode='" + CodeLastTransaction + "' WHERE  bu.Description  = '" + cbEdificio.SelectedItem + "' and level = '" + cbNivel.SelectedItem + "' and number = " + cbNumero.SelectedItem + "  and t.idTransaction_status=3 order by a.code";
            }

            MySqlDataReader dataReaderLocal = DB.GetData(sqlQuery);
            if (dataReaderLocal.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dataReaderLocal);
                dgLocales.DataSource = dt;
                dataTableDgLocales = dt;

                cbEntrega.SelectedText = dt.Rows[0][3].ToString();
                lblComprobante.Text = dt.Rows[0][4].ToString();
                dgLocales.Columns.Remove("Responsible");
                dgLocales.Columns.Remove("Comprobante");
                dgLocales.Columns["idtransaction"].Visible = false;
                dgLocales.Columns["idAsset"].Visible = false;
                dgLocales.Columns["idRoom"].Visible = false;
                dgLocales.Columns["Eval"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgLocales.Columns["Nombre de activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }
        }
    }
}
