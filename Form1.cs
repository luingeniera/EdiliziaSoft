using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnect connection = new DBConnect();
            //connection.Initialize();
            //connection.OpenConnection();
            // MessageBox.Show("hola");
            home menu = new home();
            menu.Show();

            //  string nombre = txtNombre.Text;
            //  string password = txtPassword.Text;

            // MessageBox.Show(nombre);
            // MessageBox.Show(password);


            //  List<string> range = connection.Select();
            //  foreach (string item in range)
            //  {
            //  MessageBox.Show(item);
            // }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
