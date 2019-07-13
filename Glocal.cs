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
            MySqlDataReader dataReaderLocal = DB.GetData("select * from rooms");
            //DB.GetData("select * from users");
            if (dataReaderLocal.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dataReaderLocal);
                dgLocales.DataSource = dt;
            }
        }
    }
}
