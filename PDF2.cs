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
using System.Data;



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
                string nombre = "probando" + ".pdf";
                //Document();

                PdfWriter.GetInstance(doc, new FileStream(nombre, FileMode.Create));
                doc.Open();

                while (Comp.Read())
                {
                    if ( Comp.GetString(0) == "ENT")
                    {
                    MessageBox.Show("Entro en ENT");

                  String sql2 = "SELECT *  FROM edilizia.transaction where idtransaction = " + comprobante.ToString();

                        linea(doc);
                        seccion("Entrega de Local",'c', doc);
                        linea(doc);

                        DBConnection cab = new DBConnection();

                         string sql1 = "SELECT  distinct r.level as Nivel, r.number as Numero,r.description as 'oficina',CONCAT(resp.name,', ',resp.last_name) as 'responsable'"+
                            
", cab.idtransaction as nro,cab.date as dia" +
" FROM edilizia.transaction as cab" +
" inner join edilizia.assets_room_transaction as items on cab.idtransaction = items.idtransaction" +
" inner join rooms as r on r.idRooms = items.id_Room" +
" inner JOIN edilizia.rooms_by_users as rbu ON r.idRooms = rbu.id_room" +
" inner JOIN edilizia.users resp on resp.idUsers = rbu.id_user_owner";



                        MySqlDataReader Cabecera = cab.GetData(sql1);
                        
                        PdfPTable Tabla_cabecera = new PdfPTable(6);
                        Tabla_cabecera.WidthPercentage = 85;
                        Tabla_cabecera.HorizontalAlignment = Element.ALIGN_CENTER;

                        if (Cabecera.HasRows)
                        {
                            DataTable Cb = new DataTable();
                            Cb.Load(Cabecera);

                            

                                for (int m = 0; m < Cb.Columns.Count ; m++)
                                {
                                    this.celdas(Tabla_cabecera, Cb.Columns[m].ToString());
                                }

                        
                            for (int j = 0; j < Cb.Columns.Count; j++)
                            {
                                this.celdas(Tabla_cabecera, Cb.Rows[0][j].ToString());
                            }
                                
                                doc.Add(Tabla_cabecera);





                        break;
                    
                        }


                    }
                else {



                        MessageBox.Show("Entro no ENT");



                    }
                
                }
           
            doc.Close();



            Process.Start(nombre);
            }
        
        }
        private void seccion(string texto,char a, Document doc)
        {

            Paragraph _seccion = new Paragraph();
            _seccion.Font = FontFactory.GetFont(FontFactory.TIMES, 13f);
           
            switch (a)
                { 
                case 'l': { _seccion.Alignment = Element.ALIGN_LEFT; break; };
                case 'c': { _seccion.Alignment = Element.ALIGN_CENTER; break; };

                case 'r': { _seccion.Alignment = Element.ALIGN_RIGHT; break; };

                }


            _seccion.Add(texto + "\n");


            doc.Add(_seccion);

        }

        private void linea(Document doc)
        {
            iTextSharp.text.pdf.draw.LineSeparator line1 = new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1);

            doc.Add(new Chunk(line1));
        }
              
        private void celdas(PdfPTable tabla, String strText)
        {
            PdfPCell cell = new PdfPCell(new Phrase(strText));
            //cell.BackgroundColor = new iTextSharp.text.BaseColor(1, 49, 180);
            tabla.AddCell(cell);


        }


    }
}

