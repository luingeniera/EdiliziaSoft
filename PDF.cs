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
    class PDF
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
                _titulo.Font = FontFactory.GetFont(FontFactory.TIMES, 13f);



                // agrego titulo  del pdf
                _titulo.Add(titulo);
                _titulo.Alignment = Element.ALIGN_CENTER;

                iTextSharp.text.pdf.draw.LineSeparator line1 = new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1);

                doc.Add(new Chunk(line1));
                doc.Add(_titulo);



               
                iTextSharp.text.pdf.draw.LineSeparator line2 = new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1);

                doc.Add(new Chunk(line2));

                // 0 para defecto
                // 1 movimiento de entrega dev o auditoria
                // 2 para bienes
                switch (o)
                {
                    case 0:
                    case 2:
                        {

                            Paragraph _encabezado = new Paragraph();
                            _encabezado.Font = FontFactory.GetFont(FontFactory.TIMES, 13f);
                            //variable que debe usarse encabezado
                            _encabezado.Add(encabezado + "\n\n\n");

                            //_encabezado.Alignment = Element.ALIGN_CENTER;
                            doc.Add(_encabezado);
                            break;
                        }


                    case 1:
                   

                        {
                            PdfPTable Tabla_cabecera = new PdfPTable(5);
                            Tabla_cabecera.WidthPercentage = 85;
                            Tabla_cabecera.HorizontalAlignment = Element.ALIGN_CENTER;


                            for (int m = 0; m < tablacabecera.Columns.Count-1; m++)
                            {
                                this.celdas(Tabla_cabecera, tablacabecera.Columns[m].ToString());
                            }



                            Tabla_cabecera.AddCell(new Phrase(tablacabecera.Rows[0]["Nivel"].ToString()));
                            Tabla_cabecera.AddCell(new Phrase(tablacabecera.Rows[0]["Nro Local"].ToString()));
                            Tabla_cabecera.AddCell(new Phrase(tablacabecera.Rows[0]["Local"].ToString()));
                            Tabla_cabecera.AddCell(new Phrase(tablacabecera.Rows[0]["Responsable"].ToString()));
                            Tabla_cabecera.AddCell(new Phrase(tablacabecera.Rows[0]["Comprobante"].ToString()));


                            doc.Add(Tabla_cabecera);
                            break;
                        }
                }
                //concatenando cada parrafo que estará formado por una línea
                doc.Add(new Paragraph("\n\n"));



                #region GrillaElementos
                PdfPTable tabla = new PdfPTable(grilla.Columns.Count);

                for (int i = 0; i < grilla.Columns.Count; i++)
                {

                    tabla.AddCell(new Phrase(grilla.Columns[i].HeaderText));

                }

                tabla.HeaderRows = 1;

                for (int i = 0; i < grilla.Rows.Count; i++)
                {
                    for (int k = 0; k < grilla.Columns.Count; k++)
                    {
                        if (grilla[k, i].Value != null)
                        {
                            tabla.AddCell(new Phrase(grilla[k, i].Value.ToString()));
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


                // aca hay que chequear que venga desde entrega,devolcuion o auditoria. tengo que agregar un parametro desde donde convoco pdf
                PdfPTable tabla_faltantes = new PdfPTable(1);
                tabla_faltantes.WidthPercentage = 70;
                tabla_faltantes.HorizontalAlignment = Element.ALIGN_CENTER;
             
                tabla_faltantes.AddCell(".");



                Paragraph _titulofaltantes = new Paragraph();
                _titulofaltantes.Font = FontFactory.GetFont(FontFactory.TIMES, 13f);



                _titulofaltantes.Add("Bienes no encontrados");
                _titulofaltantes.Alignment = Element.ALIGN_CENTER;
                doc.Add(_titulofaltantes);
                Paragraph saltoDeLinea4 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                doc.Add(saltoDeLinea4);

                doc.Add(tabla_faltantes);

                //concatenando cada parrafo que estará formado por una línea
                doc.Add(new Paragraph("\n\n"));


                #region Pie de paguina
                

                PdfPTable Tabla_cabecera2 = new PdfPTable(3);
                Tabla_cabecera2.WidthPercentage = 95;
                Tabla_cabecera2.HorizontalAlignment = Element.ALIGN_CENTER;
                Tabla_cabecera2.DefaultCell.BorderColor = BaseColor.BLUE;
                

                Paragraph _fuentetabla = new Paragraph();
                _fuentetabla.Font = FontFactory.GetFont(FontFactory.COURIER, 10f);
                Tabla_cabecera2.AddCell(new PdfPCell(new Phrase("\n\n\n.............................\n Secretaria Administrativa", _fuentetabla.Font)));
                Tabla_cabecera2.AddCell(new PdfPCell(new Phrase("\n\n\n.............................\n Responsable del Local", _fuentetabla.Font))); ;
                Tabla_cabecera2.AddCell(new PdfPCell(new Phrase("\n\n\n.............................\n Responsable de Inventario", _fuentetabla.Font)));

            doc.Add(Tabla_cabecera2);
               

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
                #endregion

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
