using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApplication1;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;


namespace WindowsFormsApplication1
{
    class PDF_plano
    {


               public void GenerarPDF(int origen,string encabezado
            , DataTable tablacabecera, string talonario, string titulo  , string cuerpo, DataGridView grilla , string pie)
            

        {
            int o = origen;
            for (int l = 0; l < 1; l++)
            {

                //crear el PDF
                Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

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
                string nombre = encabezado + "_" + version + ".pdf";
                //Document();

                PdfWriter.GetInstance(doc, new FileStream(nombre, FileMode.Create));
                doc.Open();
                Paragraph _titulo = new Paragraph();
                _titulo.Font = FontFactory.GetFont(FontFactory.COURIER_BOLD, 14f);



                // agrego linea titulo   y una linea al pdf
                iTextSharp.text.pdf.draw.LineSeparator line = new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1);
                doc.Add(new Chunk(line));
                _titulo.Add(encabezado);
                _titulo.Alignment = Element.ALIGN_CENTER;

                doc.Add(_titulo);

                iTextSharp.text.pdf.draw.LineSeparator line1 = new iTextSharp.text.pdf.draw.LineSeparator(1.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1);
                doc.Add(new Chunk(line1));

                //defino letra general
                iTextSharp.text.Font Fuente = FontFactory.GetFont(FontFactory.TIMES, size: 9);

             


                #region GrillaElementos
                PdfPTable tabla = new PdfPTable(grilla.Columns.Count);
                //cabecera tama;os
                tabla.TotalWidth = 550f;
                tabla.LockedWidth = true;
                float[] widthsc = new float[] { 35f, 30f, 30f, 30f, 40f, 20f, 40f };
                tabla.SetWidths(widthsc);





                for (int i = 0; i < grilla.Columns.Count; i++)
                {

                    tabla.AddCell(new Phrase(grilla.Columns[i].HeaderText, FontFactory.GetFont(FontFactory.TIMES, 12f)));

                }

                tabla.HeaderRows = 1;

                for (int i = 0; i < grilla.Rows.Count; i++)
                {
                    for (int k = 0; k < grilla.Columns.Count; k++)
                    {
                        if (grilla[k, i].Value != null)
                        {
                            tabla.AddCell(new Phrase(grilla[k, i].Value.ToString(), FontFactory.GetFont(FontFactory.TIMES, 10f)));
                        }
                    }
                }



                // Insertamos salto de linea
                Paragraph saltoDeLinea1 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                doc.Add(saltoDeLinea1);


                doc.Add(tabla);

                #endregion

                // Insertamos salto de linea
                Paragraph saltoDeLinea2 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                doc.Add(saltoDeLinea2);


           

                // Insertamos salto de linea
                Paragraph saltoDeLinea3 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                doc.Add(saltoDeLinea3);

                Paragraph _Piedepagina = new Paragraph();
                _Piedepagina.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10f);
                _Piedepagina.Alignment = Element.ALIGN_LEFT;
                _Piedepagina.SpacingBefore = 5;
                _Piedepagina.Add("Pagina nro:1:");

                doc.Add(_Piedepagina);

                Paragraph _version = new Paragraph();
                _version.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10f);

                _version.Alignment = Element.ALIGN_RIGHT;

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


                doc.Add(_version);
                

                doc.Close();



                Process.Start(nombre);

            }
        }

        private void celdas(PdfPTable tabla, String strText)
        {
            PdfPCell cell = new PdfPCell(new Phrase(strText));
            cell.BackgroundColor = new iTextSharp.text.BaseColor(51, 102, 102);
            tabla.AddCell(cell);


        }



    }


}
