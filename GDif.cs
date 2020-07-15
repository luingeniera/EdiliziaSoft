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
            dtdesde.CustomFormat = " ";
            dtdesde.Format = DateTimePickerFormat.Custom;
            DateTime dtnow = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtdesde.Value = dtnow;
            dtdesde.CustomFormat = " ";

            dthasta.CustomFormat = " ";
            dthasta.Format = DateTimePickerFormat.Custom;



            DBConnection DB = new DBConnection();
            MySqlDataReader drReposnsable = DB.GetData("SELECT concat(last_name, ', ', name) as 'Responsable', u.idUsers  FROM edilizia.users u inner JOIN rooms_by_users rbu on u.idUsers = rbu.id_user_responsible; ");
            MySqlDataReader drNroloc = DB.GetData("select  distinct number as Nivel from edilizia.rooms;");
            MySqlDataReader drLocal = DB.GetData("select CONCAT('[',rooms.code,'] - ', rooms.description) as 'Local'  from edilizia.rooms;");
           
            MySqlDataReader drNroComp = DB.GetData("SELECT booknumber as NroComprobante FROM edilizia.transaction;");
            MySqlDataReader drEdificio = DB.GetData("select distinct description from buildings");


            if (drEdificio.HasRows)
            {
                DataTable dt0 = new DataTable();
                dt0.Load(drEdificio);
                for (int i = 0; i < dt0.Rows.Count; i++)
                {
                    cbEdificio.ValueMember = "Valor";
                    cbEdificio.DisplayMember = "Nivel";
                    cbEdificio.Items.Add(dt0.Rows[i][0]);
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


            while (dgvDiferencias.RowCount > 1)
            {
                dgvDiferencias.Rows.Remove(dgvDiferencias.CurrentRow);

            }

          


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

            string WbookCode = "AND bookcode='" + TipoComprobante.ToString() + "' ";

            string wbooknumber = "AND 1=1 ";
            if (cbComprobante.SelectedItem != null) { wbooknumber = " AND booknumber='" + cbComprobante.SelectedItem.ToString() + "' "; }


            string wnumber = "AND 1=1 ";

            if (cbNumero.SelectedItem != null) { wnumber = " AND number='" + cbNumero.SelectedItem.ToString() + "' "; }
            string wlevel = "AND 1=1 ";

            if (cbNivel.SelectedItem != null) { wlevel = " AND level='" + cbNivel.SelectedItem.ToString() + "' "; }

            string wlocal = "AND 1=1 ";
            if (cbLocales.SelectedItem != null) { wlocal = " AND CONCAT('[',r.code,'] - ', r.description) like '%" + cbLocales.SelectedItem.ToString() + "%' "; }

            string wdesde = "AND 1=1 ";
            if (dtdesde.Text != " ")
            { wdesde += "and date >= '" + dtdesde.Text + "' "; }

            string whasta = "AND 1=1 ";
            if (dthasta.Text != " ")
            { whasta += "and date <= '" + dthasta.Text + "' "; }


            string wresponsable = "AND 1=1 ";
            if (cbResponsable.SelectedItem != null) { wresponsable = " AND  concat(last_name, ', ', name) = '" + cbResponsable.SelectedItem.ToString() + "' "; }



            string Consulta = " select bookCode as TipoComp, bookNumber as NroCompr, a.code,a.description, ori.code as 'Local por sistema' , pic.code as 'Local Observado'" +
                            " ,sori.description as 'Estado por sistema' , spic.description as 'Estado Observado' , iddiferences" +
                            "  FROM edilizia.diferences dif" +
                            " left join edilizia.assets a on a.id_assets = idbien" +
                            " left join edilizia.transaction t on t.idtransaction = idComprobante" +
                            " left join edilizia.rooms ori on idlocalORig =  ori.idrooms" +
                            " left join edilizia.rooms pic  on idLocalPicking =  pic.idrooms" +
                            " left join edilizia.assets_status spic on spic.idstatus =  idestadoobs" +
                            " left join edilizia.assets_status sori on sori.idstatus = idestadoorig" +
                            "  where  dif.idComprobante in " +

                            "  (select  distinct t.idtransaction  " +
                            "  FROM rooms r " +
                            "  INNER JOIN edilizia.assets_by_room abr ON abr.idRoom = r.idRooms INNER JOIN assets a on a.id_assets = abr.idAsset" +
                            "  INNER JOIN assets_status s on a.idStatus = s.idstatus LEFT OUTER JOIN rooms_by_users rbu on r.idRooms = rbu.id_room " +
                            "  LEFT OUTER JOIN users u on u.idUsers = rbu.id_user_responsible INNER JOIN assets_room_Transaction art on art.id_Asset = abr.idAsset inner join transaction t on t.idtransaction = art.idtransaction " +
                            "  " +
                            "  and art.id_Room = abr.idRoom " +
                            wdesde + whasta + WbookCode + wbooknumber + wlocal + wlevel + wnumber + wresponsable + ")" +
                            "  and FechaGestionDiferencia is null ";


            DBConnection DB = new DBConnection();
            MySqlDataReader comprobantes = DB.GetData(Consulta);



            if (comprobantes.HasRows)
            {
                //limpio columnas
                dgvDiferencias.Columns.Clear();
                //habilito la confirmacion de diferencias,  o deberia ser con algun tilde_
                btnConfirmar.Enabled = true;
                DataTable dgv = new DataTable();
                // dgv.Clear();
                dgv.Load(comprobantes);
                dgvDiferencias.DataSource = dgv;

                //Agregocheckbox

                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                { col.ReadOnly = false; }
                DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();
                { col1.ReadOnly = false; }
                DataGridViewCheckBoxColumn col2 = new DataGridViewCheckBoxColumn();
                { col2.ReadOnly = false; }
                DataGridViewCheckBoxColumn col3 = new DataGridViewCheckBoxColumn();
                { col3.ReadOnly = false; }


                
                dgvDiferencias.Columns.Insert(5, col);
                dgvDiferencias.Columns.Insert(6, col1);
                dgvDiferencias.Columns.Insert(9, col2);
                dgvDiferencias.Columns.Insert(10, col3);

                dgvDiferencias.Columns[12].Visible = false;

                //Autoajusto grilla
                for (int i = 0; i <= dgvDiferencias.Columns.Count - 1; i++)
                {

                    dgvDiferencias.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    if (i != 5 && i != 6 && i != 9 && i != 10)
                    {
                        dgvDiferencias.Columns[i].ReadOnly = true;
                    }


                }

               
                for (int i = 0; i <= dgvDiferencias.Rows.Count - 2; i++)
                {
                    if (dgvDiferencias[4, i].Value.ToString() != dgvDiferencias[7, i].Value.ToString())

                    {
                        dgvDiferencias[4, i].Style.BackColor = Color.DarkOrange;
                        dgvDiferencias[5, i].Style.BackColor = Color.DarkOrange;
                        dgvDiferencias[6, i].Style.BackColor = Color.DarkOrange;
                        dgvDiferencias[7, i].Style.BackColor = Color.DarkOrange;
                    }
                    if (dgvDiferencias[4, i].Value.ToString() == dgvDiferencias[7, i].Value.ToString())
                    {
                        dgvDiferencias[5, i].Value = true;
                        dgvDiferencias[6, i].Value = true;
                        dgvDiferencias[5, i].ReadOnly = true;
                        dgvDiferencias[6, i].ReadOnly = true;
                    }

                    if (dgvDiferencias[8, i].Value.ToString() != dgvDiferencias[11, i].Value.ToString())

                    {
                        dgvDiferencias[8, i].Style.BackColor = Color.DarkOrange;
                        dgvDiferencias[9, i].Style.BackColor = Color.DarkOrange;
                        dgvDiferencias[10, i].Style.BackColor = Color.DarkOrange;
                        dgvDiferencias[11, i].Style.BackColor = Color.DarkOrange;



                    }
                    if (dgvDiferencias[8, i].Value.ToString() == dgvDiferencias[11, i].Value.ToString())
                    {
                        dgvDiferencias[9, i].Value = true;
                        dgvDiferencias[10, i].Value = true;
                        dgvDiferencias[9, i].ReadOnly = true;
                        dgvDiferencias[10, i].ReadOnly = true;
                    }


                }
                Consulta = " ";

                

            }
            else
            { MessageBox.Show("No se encontraron comprobantes para la seleccion"); }

        }

        private void dgvDiferencias_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0 & e.ColumnIndex >= 0)
            {


                // reviso si las celdas son distintas para poder marcar cual quiero sino no no dejo editar
                if (dgvDiferencias[4, e.RowIndex].Value.ToString() != dgvDiferencias[7, e.RowIndex].Value.ToString())
                {
                    // valido para los chechbox que si marco uno demasrco el otro
                    if (e.ColumnIndex == 5)
                    {

                        dgvDiferencias.Rows[e.RowIndex].Cells[6].Value = false;
                    }

                    if (e.ColumnIndex == 6)
                    {
                        dgvDiferencias.Rows[e.RowIndex].Cells[5].Value = false;
                    }

                }
                if (dgvDiferencias[8, e.RowIndex].Value.ToString() != dgvDiferencias[11, e.RowIndex].Value.ToString())
                {

                    if (e.ColumnIndex == 9)
                    {
                        dgvDiferencias.Rows[e.RowIndex].Cells[10].Value = false;
                    }

                    if (e.ColumnIndex == 10)
                    {
                        dgvDiferencias.Rows[e.RowIndex].Cells[9].Value = false;
                    }
                }

            }
        }
       


        //void grouper_DisplayGroup(object sender, Subro.Controls.GroupDisplayEventArgs e)
        //{
        //    e.BackColor = (e.Group.GroupIndex % 2) == 0 ? Color.Blue : Color.LightBlue;
        //    e.Header = "[" + e.Header + "], grp: " + e.Group.GroupIndex;
        //    e.DisplayValue = "Value is " + e.DisplayValue;
        //    e.Summary = "contains " + e.Group.Count + " rows";
        //}
            
        private void dgvDiferencias_Sorted(object sender, EventArgs e)
        {


            //Autoajusto grilla
            for (int i = 0; i <= dgvDiferencias.Columns.Count - 1; i++)
            {

                dgvDiferencias.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            }

            // maneja los colores de lo que esta ok y lo que esta con diferencias

            for (int i = 0; i <= dgvDiferencias.Rows.Count - 2; i++)
            {
                if (dgvDiferencias[4, i].Value.ToString() != dgvDiferencias[7, i].Value.ToString())

                {
                    dgvDiferencias[4, i].Style.BackColor = Color.DarkOrange;
                    dgvDiferencias[5, i].Style.BackColor = Color.DarkOrange;
                    dgvDiferencias[6, i].Style.BackColor = Color.DarkOrange;
                    dgvDiferencias[7, i].Style.BackColor = Color.DarkOrange;
                }
                if (dgvDiferencias[4, i].Value.ToString() == dgvDiferencias[7, i].Value.ToString())
                {
                    dgvDiferencias[5, i].Value = true;
                    dgvDiferencias[6, i].Value = true;
                    dgvDiferencias[5, i].ReadOnly = true;
                    dgvDiferencias[6, i].ReadOnly = true;
                }

                if (dgvDiferencias[8, i].Value.ToString() != dgvDiferencias[11, i].Value.ToString())

                {
                    dgvDiferencias[8, i].Style.BackColor = Color.DarkOrange;
                    dgvDiferencias[9, i].Style.BackColor = Color.DarkOrange;
                    dgvDiferencias[10, i].Style.BackColor = Color.DarkOrange;
                    dgvDiferencias[11, i].Style.BackColor = Color.DarkOrange;



                }
                if (dgvDiferencias[8, i].Value.ToString() == dgvDiferencias[11, i].Value.ToString())
                {
                    dgvDiferencias[9, i].Value = true;
                    dgvDiferencias[10, i].Value = true;
                    dgvDiferencias[9, i].ReadOnly = true;
                    dgvDiferencias[10, i].ReadOnly = true;
                }
            }
        }

        private void cbEdificio_SelectedValueChanged(object sender, EventArgs e)
        {

            //si selecciono el edificio habilito nivel
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            string sql = "";
            cbNivel.Items.Clear();

            if (cbEdificio.SelectedIndex > -1)
            {
                // busco nivel 
                sql = "select distinct level from rooms inner join buildings b on bulding = b.idbuilding " +
                " where b.description = '" + cbEdificio.SelectedItem + "'";
                cbNivel.Enabled = true;
                lbNivel.Enabled = true;
            }
            else
            {
                sql = "select distinct number from rooms";
                cbNivel.Enabled = false;
                lbNivel.Enabled = false;

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

            // si selecciono nivel habilito numero local
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            string sql = "";
            cbNumero.Items.Clear();

            if (cbNivel.SelectedIndex > -1)
            {
                sql = "select distinct number from rooms where level = " + cbNivel.SelectedItem;
                cbNumero.Enabled = true;
                lbLocal.Enabled = true;
            }
            else
            {
                sql = "select distinct number from rooms";
                cbNumero.Enabled = false;
                lbLocal.Enabled = false;

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

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            #region ACTUALIZACION POR FILA
            Boolean bandera = false;
            //recorro todos las filas de la grilla
            for (int i = 0; i <= dgvDiferencias.Rows.Count - 2; i++)
            {
                
                //tengo que buscar valores que estan tildados.
                //PRINERO LOCAL /// 4 local original 7 local observado 5 y 6 contienen los tildes
                DBConnection DB = new DBConnection();

                // valido que la fila tenga completo los datos
                // al chequear que algo esta tildado pido que tilde si nada esta tildado
                if ((dgvDiferencias.Rows[i].Cells[5].Value != null || dgvDiferencias.Rows[i].Cells[6].Value != null) &&

                       (dgvDiferencias.Rows[i].Cells[9].Value != null || dgvDiferencias.Rows[i].Cells[10].Value != null))
                {
                    #region saldo diferencia
                    bandera = true;


                    if (dgvDiferencias.Rows[i].Cells[5].Value == null) { dgvDiferencias.Rows[i].Cells[5].Value = false; };

                    if (dgvDiferencias.Rows[i].Cells[6].Value == null) { dgvDiferencias.Rows[i].Cells[5].Value = false; };


                    string idlocalfinal = " ";
                    if (dgvDiferencias[5, i].Value.ToString() == "True")
                    {
                        #region local sistema
                        //busco el id del original
                        string sqlroom = "select idRooms from edilizia.rooms where code = '" + dgvDiferencias[4, i].Value.ToString() + "'";

                        MySqlDataReader idroom = DB.GetData(sqlroom);
                        if (idroom.Read())
                        { idlocalfinal = idroom["idRooms"].ToString(); }
                        #endregion
                    }
                    else
                    {//sino busco el observado

                        #region local obserbado
                        string sqlroom = "select idRooms from edilizia.rooms where code = '" + dgvDiferencias[7, i].Value.ToString() + "'";

                        MySqlDataReader idroom = DB.GetData(sqlroom);
                        if (idroom.Read())
                        { idlocalfinal = idroom["idRooms"].ToString(); }
                        #endregion
                    }



                    //valido que alo que esta en nulo le pongo falso sino pincha
                    if (dgvDiferencias.Rows[i].Cells[9].Value == null) { dgvDiferencias.Rows[i].Cells[9].Value = false; };
                    if (dgvDiferencias.Rows[i].Cells[10].Value == null) { dgvDiferencias.Rows[i].Cells[10].Value = false; };


                    //ESTADO FINAL
                    string idestadofinal = " ";
                    if (dgvDiferencias[9, i].Value.ToString() == "True" )
                    {
                        #region estado por sistema
                        //busco el id del original
                        string sqlroom = "SELECT idstatus FROM edilizia.assets_status where description ='" + dgvDiferencias[8, i].Value.ToString() + "'";


                        MySqlDataReader idestado = DB.GetData(sqlroom);
                        if (idestado.Read())
                        { idestadofinal = idestado["idstatus"].ToString(); }
                        #endregion
                    }
                    else
                    #region estado observado
                    {//sino busco el observado
                        string sqlroom = "SELECT idstatus FROM edilizia.assets_status where description ='" + dgvDiferencias[11, i].Value.ToString() + "'";

                        MySqlDataReader idestado = DB.GetData(sqlroom);
                        if (idestado.Read())
                        { idestadofinal = idestado["idstatus"].ToString(); }


                        #endregion
                    }

                    // esta es el idtransaccion a actualizar dgvDiferencias[12, i].Value.ToString());

                    string updatediferencias = "update edilizia.diferences set fechagestiondiferencia = now(), idlocalFinal=" + idlocalfinal + " , idestadofinal=" + idestadofinal + "  where idDiferences= " + dgvDiferencias[12, i].Value.ToString();
                    //actualizo el local en tabla de bienes por local
                    string updateassetbyrrom = "update edilizia.assets_by_room set idroom =" + idlocalfinal + " where idasset = (select idbien from edilizia.diferences where idDiferences = " + dgvDiferencias[12, i].Value.ToString() + ")";
                    //actualizo el comprobante
                    string updateassetstatus = "update edilizia.assets_room_transaction set color = '1' ,  delivery_status = " + idestadofinal + " where id_Asset = (select idbien from edilizia.diferences where idDiferences = " + dgvDiferencias[12, i].Value.ToString() + ")   and idtransaction = (select idComprobante from edilizia.diferences where idDiferences = " + dgvDiferencias[12, i].Value.ToString() + ")";
                    
                    
                    //habria que ver si necesita hacer un rollback completo por las tres tansacci

                    DB.GetData(updatediferencias);
                    DB.GetData(updateassetbyrrom);
                    DB.GetData(updateassetstatus);


                    // valido momento a momento si puedo actualizar 
                    string actualizartransaccion ="SELECT count(*) as cuenta FROM edilizia.assets_room_transaction where color <> 1 and idtransaction =  (select idComprobante from edilizia.diferences where idDiferences = " + dgvDiferencias[12, i].Value.ToString() + ")";

                    MySqlDataReader count = DB.GetData(actualizartransaccion);


                    string cuenta = "";
                    if (count.Read())
                    {  cuenta = count["cuenta"].ToString(); }

                    // chequeo si la transaccion esta para ser aprobada y lo pasamos a estado 3 que es cuando esta aprobada
                    if (cuenta == "0")
                    {

                        string actualizartransacciones = "update edilizia.transaction set idTransaction_status = 3  where idtransaction = (select idComprobante from edilizia.diferences where idDiferences = " + dgvDiferencias[12, i].Value.ToString() + ")";
                        DB.GetData(actualizartransacciones);

                    }
                 //cambio pedido revision 9/6 un solo cartel con todo.   MessageBox.Show("Se saldaron las diferencias cargadas");

                    #endregion

                   

                
                }


                else
                // sino vaido si esta algo tildado o si nada.

                // si todo nulo quiere decir q no hizo nada sobre la linea
                {
                    if ((dgvDiferencias.Rows[i].Cells[5].Value == null && dgvDiferencias.Rows[i].Cells[6].Value == null) &&  (dgvDiferencias.Rows[i].Cells[9].Value == null && dgvDiferencias.Rows[i].Cells[10].Value == null))
                    { }

                    //minuta 9/7 pide que no se muestre
                    //else
                    //{// si hay algo completo quiere decri que falta terminar
                    //    MessageBox.Show("Debe completar la diferencia en su totalidad");
                    //}

                }

                #endregion

              

            }

            //muestro solo si salde alguna diferencia sino no.
            if (bandera == true) { 
            MessageBox.Show("Se saldaron las diferencias cargadas");
            }

            btnBuscar_Click(this, new EventArgs());
        }

        private void dtdesde_ValueChanged_1(object sender, EventArgs e)
        {
            dtdesde.CustomFormat = "yyyyMMdd";
        }

        private void dthasta_ValueChanged_1(object sender, EventArgs e)
        {
            dthasta.CustomFormat = "yyyyMMdd";
        }

        private void dgvDiferencias_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
    }


