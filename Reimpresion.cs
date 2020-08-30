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
    public partial class Reimpresion : Form
    {
        WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
        public Reimpresion()
        {
            InitializeComponent();
        }

        private void Reimpresion_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            DateTime dtnow = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateTimePicker1.Value = dtnow;
            dateTimePicker1.CustomFormat = " ";
          
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            
            dateTimePicker2.Value = dtnow;
            dateTimePicker2.CustomFormat = " ";

            string sqlQuery = "";

            sqlQuery = "SELECT code, description FROM edilizia.book";
            MySqlDataReader dataReaderTrans = DB.GetData(sqlQuery);
            if (dataReaderTrans.HasRows)
            {
                cmbResponsible.Items.Clear();
                DataTable dtTrans = new DataTable();
                dtTrans.Load(dataReaderTrans);
                for (int i = 0; i < dtTrans.Rows.Count; i++)
                {
                    cmbTransaction.ValueMember = "code";
                    cmbTransaction.DisplayMember = "description";
                    cmbTransaction.DataSource = dtTrans;
                    cmbTransaction.SelectedIndex = -1;
                }
            }

            sqlQuery = "SELECT distinct u.idUsers, concat(u.last_name,',',u.name) as Responsable " +
                "FROM edilizia.rooms_by_users rbu inner join users u on rbu.id_user_responsible = u.idUsers";
            MySqlDataReader dataReaderUsers = DB.GetData(sqlQuery);
            if (dataReaderUsers.HasRows)
            {
                cmbResponsible.Items.Clear();
                DataTable dt = new DataTable();
                dt.Load(dataReaderUsers);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbResponsible.ValueMember = "idUsers";
                    cmbResponsible.DisplayMember = "Responsable";
                    cmbResponsible.DataSource = dt;
                    cmbResponsible.SelectedIndex = -1;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string where = "1=1 ";
            if (cmbTransaction.SelectedIndex > -1)
                where += "and bookCode = '" + cmbTransaction.SelectedValue + "' ";

            if (cmbResponsible.SelectedIndex > -1)
                where += "and id_user_responsible = '" + cmbResponsible.SelectedValue + "' ";

            if (dateTimePicker1.Text != " ")
                where += "and date >= '" + dateTimePicker1.Text + "' ";

            if (dateTimePicker2.Text != " ")
                where += "and date <= '" + dateTimePicker2.Text + "' ";

            if (textBox1.Text != "")
                where += "and bookNumber = '" + textBox1.Text + "' ";

            if (where == "1=1")
                MessageBox.Show("Debe completar al menos un filtro.");
            else
            {
                string sqlTransactions = "";
                sqlTransactions = "SELECT t.idtransaction, concat(t.bookCode,'-',t.bookNumber) as Comprobante, DATE_FORMAT(t.date,'%d/%m/%Y') as Fecha " +
                ", concat(u.last_name, ',', u.name) as Responsable, r.description as Oficina,b.Description as Edificio, r.level as Nivel, r.number as Nro FROM edilizia.transaction t " +
                "INNER JOIN edilizia.assets_room_transaction art on t.idtransaction = art.idtransaction INNER JOIN edilizia.rooms_by_users rbu " +
                "on art.id_Room = rbu.id_room INNER JOIN edilizia.users u on rbu.id_user_responsible = u.idUsers INNER JOIN rooms r on art.id_Room = r.idRooms "+
               " inner join edilizia.buildings b on b.idbuilding = r.buildings WHERE " + where;



                MySqlDataReader dataReaderTransactions = DB.GetData(sqlTransactions);
                if (dataReaderTransactions.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dataReaderTransactions);
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns["idtransaction"].Visible = false;
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else
                {
                    MessageBox.Show("No hay comprobantes para listar, controle los filtros.");
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyyMMdd";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "yyyyMMdd";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                PDF_Comp callPDF = new PDF_Comp();
                callPDF.PrintPDF(Convert.ToInt32(dataGridView1["idtransaction", i].Value.ToString()));
            }
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker2.CustomFormat = " ";

            cmbTransaction.Text = "";
            cmbResponsible.Text = "";
            textBox1.Text = "";
        }
    }
}
