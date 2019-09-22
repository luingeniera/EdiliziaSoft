using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Preferencias
{
    public partial class CambiarPass : Form
    {
        public CambiarPass()
        {
            InitializeComponent();
            txtpass.MaxLength = 15;
            txtpass2.MaxLength = 15;
        }
        public string usuariologueado = "LRAIES";


        private void CambiarPass_Load(object sender, EventArgs e)
        {

            txtUser.Text = usuariologueado.ToString();
            txtUser.Enabled = false;

        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (txtpass.Text != "" || txtpass2.Text != "")
            {


                String pass = Usuario.PassUsuario(usuariologueado);

                if (txtpassactual.Text == pass)
                {
                    if (txtpass.Text == txtpass2.Text)
                    {
                        

                         bool retorno = Usuario.CambioContraseña(usuariologueado, txtpass.Text);
                        if (retorno == true)
                           {
                            MessageBox.Show("La contraseña ha sido cambiada satisfactoriamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        else
                        {
                           
                            MessageBox.Show("Las contraseña no pudo ser cambiada\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

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
