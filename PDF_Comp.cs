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
    class PDF_Comp
    {

        public void PrintPDF(int comprobante)
        {
            // aca puse l < 1 pero es a 3 para que salgan 3 pdf
            for (int l = 0; l < 1; l++)
            {

                Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

                WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
                //String Movimiento = " select *  from comppdf  where id = " + comprobante.ToString();
                String Movimiento = " SELECT distinct r.code, r.description,CONCAT(u.last_name,', ',u.name) as Responsable, " +
                "CONCAT(t.bookCode,' - ',t.bookNumber) as Comp,DATE_FORMAT(t.date,'%d/%m/%Y') as date FROM edilizia.transaction t INNER JOIN edilizia.assets_room_transaction art ON t.idtransaction = art.idtransaction " +
                "INNER JOIN edilizia.rooms r on art.id_Room = r.idRooms INNER JOIN edilizia.rooms_by_users rbu on rbu.id_room = r.idRooms " +
                "INNER JOIN edilizia.users u on u.idUsers = rbu.id_user_responsible where t.idtransaction = " + comprobante.ToString();

                String tipo = "SELECT bookcode FROM edilizia.transaction where idtransaction = " + comprobante.ToString();

                MySqlDataReader RTipo = DB.GetData(tipo);

                MySqlDataReader RComp = DB.GetData(Movimiento);
                DataTable dtmovi = new DataTable();
                dtmovi.Load(RComp);

                String Number = "SELECT booknumber FROM edilizia.transaction where idtransaction = " + comprobante.ToString();

                MySqlDataReader RNumber = DB.GetData(Number);


                #region titulo
                Paragraph _titulo = new Paragraph();
                _titulo.Font = FontFactory.GetFont(FontFactory.TIMES, 13f);

                #region Seleccion
                string Mov = "";
                string Nom = "";
                string responsable = "";
                string TipoComp = "";
                while (RNumber.Read())
                {
                    string numero = RNumber.GetString(0);
                    while (RTipo.Read())
                    {
                        TipoComp = RTipo.GetString(0);
                        switch (RTipo.GetString(0))
                        {

                            case "ENT":
                                Mov = "Entrega de local Nro " + numero;
                                Nom = "Entrega_Nro_" + numero;
                                break;
                            case "DEV":
                                Mov = "Devolucion de local Nro " + numero;
                                Nom = "Devolucion_Nro_" + numero;
                                break;
                            case "AUD":
                                Mov = "Auditoria de local Nro " + numero;
                                Nom = "Auditoria_Nro_" + numero;
                                break;
                        }
                    }
                }
                switch (l)
                {
                    case 0:
                        Nom = Nom + "_Original";
                        break;
                    case 1:
                        Nom = Nom + "_Duplicado";
                        break;
                    case 2:
                        Nom = Nom + "_Triplicado";
                        break;             
                }
                #endregion

                //armo el nombre del pd
                String nombre = Nom + ".pdf";
                //creo el pdfwriter
                PdfWriter.GetInstance(doc, new FileStream(nombre, FileMode.Create));
                //abro el doc para agregarle los datos
                doc.Open();

                // agrego linea titulo  linea al pdf
                iTextSharp.text.pdf.draw.LineSeparator line = new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1);
                doc.Add(new Chunk(line));
                _titulo.Add(Mov);
                _titulo.Alignment = Element.ALIGN_CENTER;

                doc.Add(_titulo);

                iTextSharp.text.pdf.draw.LineSeparator line1 = new iTextSharp.text.pdf.draw.LineSeparator(1.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1);
                doc.Add(new Chunk(line1));

                doc.Add(new Paragraph("\n\n"));
                #endregion
                //defino letra general
                Font Fuente = FontFactory.GetFont("TIMES", size: 13);
                //agrego la tabla para la grilla
                #region tabla cabecera
                PdfPTable Tabla_cabecera = new PdfPTable(dtmovi.Columns.Count);
                Tabla_cabecera.WidthPercentage = 95;
                Tabla_cabecera.HorizontalAlignment = Element.ALIGN_CENTER;
                Tabla_cabecera.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;


                //titulos
                for (int i = 0; i < dtmovi.Columns.Count; i++)
                {
                    switch (dtmovi.Columns[i].ToString())
                    {
                        case "Comp":
                            Tabla_cabecera.AddCell(new Phrase("Comprobante"));
                            break;
                        case "description":
                            Tabla_cabecera.AddCell(new Phrase("Local"));
                            break;
                        case "date":
                            Tabla_cabecera.AddCell(new Phrase("Fecha"));
                            break;
                        case "code":
                            Tabla_cabecera.AddCell(new Phrase("Cod Local"));
                            break;
                        case "Responsable":
                            Tabla_cabecera.AddCell(new Phrase("Responsable"));
                            break;
                    }
                }

                // valores
                for (int i = 0; i < dtmovi.Rows.Count; i++)
                {
                    for (int j = 0; j < dtmovi.Columns.Count; j++)
                    {
                        this.celdas(Tabla_cabecera, dtmovi.Rows[i][j].ToString(), "0");
                    }
                }
                responsable = dtmovi.Rows[0][2].ToString();
                doc.Add(Tabla_cabecera);
                #endregion

                doc.Add(new Paragraph("\n\n"));
                //comienzo mostrado elementos en verde
                //string green = "SELECT * FROM edilizia.bienes_pdf where Semaforo =1 and id =" + comprobante.ToString();
                string green = "";
                if (TipoComp != "ENT")
                    green = "SELECT a.code as Referencia, a.description as 'Nombre de Activo', ast.description as Estado, " +
                    "ast.description as 'Estado Obs', r.code as Local, '' as Eval, art.observation as Observaciones " +
                    "FROM edilizia.assets_room_transaction art INNER JOIN edilizia.assets a on a.id_assets = art.id_Asset " +
                    "INNER JOIN edilizia.assets_status ast on ast.idstatus = art.delivery_status " +
                    "INNER JOIN edilizia.rooms r on art.id_Room = r.idRooms where art.idtransaction =" + comprobante.ToString() + " order by art.color, a.code";
                else
                    green = "SELECT a.code as Referencia, a.description as 'Nombre de Activo', ast.description as Estado, " +
                    "ast.description as 'Estado Obs', r.code as Local, '' as Eval, art.observation as Observaciones " +
                    "FROM edilizia.assets_room_transaction art INNER JOIN edilizia.assets a on a.id_assets = art.id_Asset " +
                    "INNER JOIN edilizia.assets_status ast on ast.idstatus = art.delivery_status " +
                    "INNER JOIN edilizia.rooms r on art.id_Room = r.idRooms where art.color = 1 and art.idtransaction =" + comprobante.ToString() + " order by art.color, a.code";

                MySqlDataReader Rgreen = DB.GetData(green);
                DataTable DTVerde = new DataTable();
                DTVerde.Load(Rgreen);

                #region tabla cabecera
                PdfPTable Tverde = new PdfPTable(DTVerde.Columns.Count);
                Tverde.WidthPercentage = 100;
                Tverde.HorizontalAlignment = Element.ALIGN_CENTER;
                Tverde.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;

                //titulos
                for (int i = 0; i < DTVerde.Columns.Count; i++)
                {
                    Tverde.AddCell(new Phrase(DTVerde.Columns[i].ToString()));
                }

                // valores
                for (int i = 0; i < DTVerde.Rows.Count; i++)
                {
                    for (int j = 0; j < DTVerde.Columns.Count; j++)
                    {

                        if (DTVerde.Columns[j].ColumnName == "Eval")
                        {
                            //DTVerde.Columns[j].ColumnName = "Eval")
                            this.celdas(Tverde, DTVerde.Rows[i][j].ToString(), "1");
                        }
                        else

                        {
                            this.celdas(Tverde, DTVerde.Rows[i][j].ToString(), "0");
                        }

                     
                    }
                 //   DTVerde.Rows[i]["Eval"] = ' ';
                }
                
                doc.Add(Tverde);
                #endregion
                //agrego la firma
                //Paragraph _firmas = new Paragraph();
                //_firmas.Font = FontFactory.GetFont(FontFactory.TIMES, 10f);
                //_firmas.Alignment = Element.ALIGN_RIGHT;
                //_firmas.Add(new Phrase("\n\n.............................\n Responsable del Local", _firmas.Font));
                //doc.Add(_firmas);
                PdfPTable tableR = new PdfPTable(1);
                tableR.DefaultCell.Border = Rectangle.NO_BORDER;
                PdfPCell cellR = new PdfPCell(new Phrase("\n\n", FontFactory.GetFont(FontFactory.TIMES, 10f)));
                cellR.Border = 0;
                cellR.Colspan = 2;
                cellR.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                tableR.AddCell(cellR);
                tableR.AddCell("......................................................");
                tableR.AddCell("Responsable del Local");
                doc.Add(tableR);

                if (TipoComp != "AUD")
                {
                    //comienzo mostrado elementos en yelloe y red
                    doc.Add(new Paragraph("\nLos siguientes bienes no serán asignados bajo la reponsabilidad de " + responsable + " por no haberse encontrado fisícamente en el local o por diferir sus estados.\n"));

                    doc.Add(new Paragraph("\n"));

                    //string yellow = "SELECT * FROM edilizia.assets_room_transaction where color <> 1 and idtransaction =" + comprobante.ToString();
                    string yellow = "SELECT  a.code as Referencia, a.description as 'Nombre de Activo', ast.description as Estado, " +
                    "astObs.description as 'Estado Obs',r.code as Local, '' as Eval, art.observation as Observaciones FROM edilizia.diferences d " +
                    "INNER JOIN edilizia.assets a on a.id_assets = d.idBien INNER JOIN edilizia.assets_status ast on ast.idstatus = ifnull(d.idEstadoOrig,a.idStatus) " +
                    "LEFT JOIN  edilizia.assets_status astObs on astObs.idstatus = d.idEstadoObs INNER JOIN edilizia.rooms r on d.idLocalPicking = r.idRooms " +
                    "INNER JOIN edilizia.assets_room_transaction art on d.idComprobante = art.idtransaction and d.idBien = art.id_Asset " +
                    "where art.color <> 1 and art.idtransaction =" + comprobante.ToString() + " order by art.color, a.code";

                    MySqlDataReader Ryellow = DB.GetData(yellow);
                    DataTable DTy = new DataTable();
                    DTy.Load(Ryellow);

                    #region tabla cabecera
                    PdfPTable Tyellow= new PdfPTable(DTy.Columns.Count);
                    Tyellow.WidthPercentage = 100;
                    Tyellow.HorizontalAlignment = Element.ALIGN_CENTER;
                    Tyellow.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;

                    //titulos
                    for (int i = 0; i < DTy.Columns.Count; i++)
                    {
                        Tyellow.AddCell(new Phrase(DTy.Columns[i].ToString()));
                    }
                    // valores
                    for (int i = 0; i < DTy.Rows.Count; i++)
                    {
                        for (int j = 0; j < DTy.Columns.Count; j++)
                        {
                            // this.celdas(Tyellowred, DTyr.Rows[i][j].ToString(), DTyr.Rows[i][j].ToString());
                            if (DTy.Columns[j].ColumnName == "Eval")
                            {
                                //DTVerde.Columns[j].ColumnName = "Eval")
                                this.celdas(Tyellow, DTy.Rows[i][j].ToString(), "2");

                            }
                            else

                            {
                                this.celdas(Tyellow, DTy.Rows[i][j].ToString(), "0");
                            }
                        }
                    }


                    doc.Add(Tyellow);
                    #endregion


                    //string yellowgreen = "SELECT * FROM edilizia.assets_room_transaction where color <> 1 and idtransaction =" + comprobante.ToString();
                    string red = "SELECT  a.code as Referencia, a.description as 'Nombre de Activo', ast.description as Estado, " +
                    "astObs.description as 'Estado Obs',r.code as Local, '' as Eval, art.observation as Observaciones FROM edilizia.diferences d " +
                    "INNER JOIN edilizia.assets a on a.id_assets = d.idBien INNER JOIN edilizia.assets_status ast on ast.idstatus = ifnull(d.idEstadoOrig,a.idStatus) " +
                    "LEFT JOIN  edilizia.assets_status astObs on astObs.idstatus = d.idEstadoObs INNER JOIN edilizia.rooms r on d.idLocalPicking = r.idRooms " +
                    "INNER JOIN edilizia.assets_room_transaction art on d.idComprobante = art.idtransaction and d.idBien = art.id_Asset " +
                    "where art.color = 1 and art.idtransaction =" + comprobante.ToString() + " order by art.color, a.code";

                    MySqlDataReader Rr = DB.GetData(red);
                    DataTable DTr = new DataTable();
                    DTr.Load(Rr);

                    #region tabla cabecera
                    PdfPTable Tred = new PdfPTable(DTr.Columns.Count);
                    Tred.WidthPercentage = 100;
                    Tred.HorizontalAlignment = Element.ALIGN_CENTER;
                    Tred.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;

                    //titulos
                    //for (int i = 0; i < DTr.Columns.Count; i++)
                    //{
                    //    Tred.AddCell(new Phrase(DTr.Columns[i].ToString()));
                    //}
                    // valores
                    for (int i = 0; i < DTr.Rows.Count; i++)
                    {
                        for (int j = 0; j < DTr.Columns.Count; j++)
                        {
                           // this.celdas(Tyellowred, DTyr.Rows[i][j].ToString(), DTyr.Rows[i][j].ToString());
                            if (DTr.Columns[j].ColumnName == "Eval")
                            {
                                //DTVerde.Columns[j].ColumnName = "Eval")
                                this.celdas(Tred, DTr.Rows[i][j].ToString(), "3");
                               
                            }
                            else

                            {
                                this.celdas(Tred, DTr.Rows[i][j].ToString(), "0");
                            }
                        }
                    }

                    
                    doc.Add(Tred);
                    #endregion
                }
                //agrego la firma
                //Paragraph _firmas2 = new Paragraph();
                //_firmas2.Font = FontFactory.GetFont(FontFactory.TIMES, 10f);
                //_firmas2.Alignment = Element.ALIGN_RIGHT;
                //_firmas2.Add(new Phrase("\n\n\n.............................\n Secretaria Administrativa", _firmas.Font));
                ////doc.Add(_firmas2);

                ////Paragraph _firmas3 = new Paragraph();
                //_firmas2.Font = FontFactory.GetFont(FontFactory.TIMES, 10f);
                //_firmas2.Alignment = Element.ALIGN_LEFT;
                //_firmas2.Add(new Phrase(".............................\n Responsable de Inventario", _firmas.Font));
                //doc.Add(_firmas2);

                PdfPTable table = new PdfPTable(2);
                table.DefaultCell.Border = Rectangle.NO_BORDER;
                PdfPCell cell = new PdfPCell(new Phrase("\n\n\n", FontFactory.GetFont(FontFactory.TIMES, 10f)));
                cell.Border = 0;
                cell.Colspan = 2;
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                table.AddCell(cell);
                table.AddCell("......................................................");
                table.AddCell("......................................................");
                table.AddCell("Responsable de Inventario");
                table.AddCell("Secretaria Administrativa");
                doc.Add(table);


                //Pie de pagina + version
                #region pie de pagina
                Paragraph _Piedepagina = new Paragraph();
                _Piedepagina.Font = FontFactory.GetFont(FontFactory.TIMES, 10f);
                _Piedepagina.Alignment = Element.ALIGN_RIGHT;
                _Piedepagina.SpacingBefore = 5;
                _Piedepagina.Add("Pagina nro: 1");

                doc.Add(_Piedepagina);
                //armo versionado para los 3 pdf
                Paragraph _version = new Paragraph();
                _version.Font = FontFactory.GetFont(FontFactory.TIMES, 10f);
                _version.Alignment = Element.ALIGN_LEFT;

                switch (l)
                {
                    case 0:
                        _version.Add("Original");
                        break;
                    case 1:
                        _version.Add("Duplicado");
                        break;
                    case 2:
                        _version.Add("Triplicado");
                        break;
                    default:
                        _version.Add("default");
                        break;
                }
                #endregion
                doc.Add(_version);

                doc.Close();
                Process.Start(nombre);

            }
        }
        //funcion reutilizada para armar celdas en tablas
        private void celdas(PdfPTable tabla, String strText, string color)
        {
            PdfPCell cell = new PdfPCell(new Phrase(strText));
            switch (color)
            {
                case "1":
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(0, 255, 0); //cambiar a verde                    
                    break;
                case "2":
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(225, 225, 0); //cambiar a amarillo                    
                    break;
                case "3":
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 0, 0); //cambiar a rojo
                    break;
                case "0":
                    break;
            }
            
            tabla.AddCell(cell);
            
            
        }

    }
}
