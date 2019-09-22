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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          


           String pass = Preferencias.Usuario.PassUsuario(txtNombre.Text);

          

         if ( pass == txtPassword.Text)
            {
          
            home menu = new home();
            menu.Show();
          

            }
         else
            {
                MessageBox.Show("Usuario o contraseña incorrectos\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            }
           
        

     private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtPassword.Text != "")
            {
                btnlog.Enabled = true;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtPassword.Text != "")
            {
                btnlog.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if( cbVer.Checked==true)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';

            }
        }
    }
}