using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Preferencias
{
    class Usuario
    {


        public static string PassUsuario(string usuariologueado)
        {
            DBConnection DB = new DBConnection();
        string sqlQuery = "";
        sqlQuery ="SELECT  pass FROM edilizia.users where user='" + usuariologueado + "';";
        MySqlDataReader reader = DB.GetData(sqlQuery);

           
            string contraseña = "";
            while (reader.Read())
            {
         
                contraseña = reader["pass"].ToString();
                

            }
      

            return contraseña;


    }

        public static bool CambioContraseña(string usuariologueado, string passnew)

        {

       
        DBConnection DB = new DBConnection();
        string sql = "";
      
        sql = "UPDATE users SET pass ='" + passnew + "' where user='" + usuariologueado + "';";

             MySqlDataReader conexion = DB.GetData(sql);
            
            return true;

        }
    }
}
