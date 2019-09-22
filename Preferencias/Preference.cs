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
    public partial class Preference : Form
    {
        public string usuariologueado = "LPERALTA";
        public Preference()
        {
            InitializeComponent();
            txtpass.MaxLength = 15;
            txtpass2.MaxLength = 15;
        }

        private void Preference_Load(object sender, EventArgs e)
        {
            txtUser.Text = usuariologueado.ToString();
            txtUser.Enabled = false;

            rbtUsuario.Text = "USUARIO: " + usuariologueado.ToString() + "\n Email: luciaperalta@gmail.com";

        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {

          
            #region ChequeoPassActual

            String pass = Usuario.PassUsuario(usuariologueado);

                if (txtpassactual.Text == pass)
                {
                #region Chequeonuevasiguales
                    if (txtpass.Text == txtpass2.Text)
                    {

                        bool retorno = Usuario.CambioContraseña(usuariologueado, txtpass.Text);
                        #region valido cambio correcto de pass
                        if (retorno == true)
                        {
                            MessageBox.Show("La contraseña ha sido cambiada satisfactoriamente");
                        }
                        else
                        {

                            MessageBox.Show("Las contraseña no pudo ser cambiada\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                    }

                   else
                    {
             
                        MessageBox.Show("Las contraseñas  no coinciden\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion
                }
               
            
            else
            {
                MessageBox.Show("La contraseña o el usuario son incorrectos\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            if (txtpass.Text != "" && txtpass2.Text != "" && txtUser.Text !="" && txtpassactual.Text !="")
            {
                cmdAceptar.Enabled = true;
            }
        }

        private void txtpass2_TextChanged(object sender, EventArgs e)
        {
            if (txtpass.Text != "" && txtpass2.Text != "" && txtUser.Text !="" && txtpassactual.Text !="")
            {
                cmdAceptar.Enabled = true;
            }
        }
    }
    }
