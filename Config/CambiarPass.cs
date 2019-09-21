using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Config
{
    public partial class CambiarPass : Form
    {
        public string usuariologueado = "LRAIES";
        public CambiarPass()
        {
            InitializeComponent();
           
            txtpass.MaxLength = 15;
            txtpass2.MaxLength = 15;
        }

        private void CambiarPass1_Load(object sender, EventArgs e)
        {
            txtUser.Text = usuariologueado.ToString();
            txtUser.Enabled = false;

        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (txtpass.Text != "" || txtpass2.Text != "")
            {


                String pass  = Contraseña.PassUsuario(usuariologueado);

                if (txtpassactual.Text == pass)
                {
                    if (txtpass.Text == txtpass2.Text)
                    {
                        Contraseña.CambioContraseña(usuariologueado, txtpass.Text);

                    }


                }
                else
                {
                    MessageBox.Show(pass);
                    MessageBox.Show("Las contraseña actual no coincide\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La contraseña no puede ser nula\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
