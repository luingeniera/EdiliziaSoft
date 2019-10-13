using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    class PDF2
    {

        public void PrintPDF(int comprobante)
        {
         
            for (int l = 0; l < 1; l++)
            {

                Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

                #region VersiondelPDF
                //confeccion de dstos del pdf
                string version = "";
            switch (l)
            {
                case 0:
                    version = "Original";
                    break;
                case 1:
                    version = "Duplicado";
                    break;
                case 2:
                    version = "Triplicado";
                    break;

                default:
                    version = "Defecto";
                    break;
            }
                #endregion

              
                WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
                
                String sql = "SELECT bookcode FROM edilizia.transaction where idtransaction = " + comprobante.ToString();
                              
                MySqlDataReader Comp = DB.GetData(sql);


                while (Comp.Read())
                {
                    if ( Comp.GetString(0) == "ENT")
                    {
                    MessageBox.Show("Entro en ENT");

                  String sql2 = "SELECT *  FROM edilizia.transaction where idtransaction = " + comprobante.ToString();



                    }
                else {



                        MessageBox.Show("Entro no ENT");



                    }
                
                }
            }

        }
}
}

