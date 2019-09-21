using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Windows.Forms;



namespace WindowsFormsApplication1.Config
{
    class Contraseña
    {
        public static string PassUsuario(string usuario)
        {
            MessageBox.Show(usuario);
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            MySqlDataReader retorno = DB.GetData("SELECT pass FROM edilizia.users where user = '" + usuario + "'; ");


                
            

        }

        public static bool CambioContraseña(string usuariologueado, string contraseña)
        {


            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            string sql = "";
            //Falta recuperar el id_user_owner seleccionado.
            sql = "UPDATE users SET pass ='" + contraseña + "' where user='" + usuariologueado + "';";

             MySqlDataReader conexion = DB.GetData(sql);
            
            return true;
        }

       
    }
}
