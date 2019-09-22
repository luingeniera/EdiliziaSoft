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


       

        public void GenerarPDF(string encabezado, string talonario, string titulo
            , string cuerpo, DataGridView grilla
            , string pie)

        {
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



                Paragraph _encabezado = new Paragraph();
                _encabezado.Font = FontFactory.GetFont(FontFactory.TIMES, 13f);
                //variable que debe usarse encabezado
                _encabezado.Add(encabezado + "\n\n\n");

                iTextSharp.text.pdf.draw.LineSeparator line2 = new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1);

                doc.Add(new Chunk(line2));

                _encabezado.Alignment = Element.ALIGN_CENTER;
                //   doc.Add(_encabezado);
                // Cabecera en recuadro





                PdfPTable Tabla_cabecera = new PdfPTable(6);
                Tabla_cabecera.WidthPercentage = 85;
                Tabla_cabecera.HorizontalAlignment = Element.ALIGN_CENTER;

                this.celdas(Tabla_cabecera, "Nivel");
                this.celdas(Tabla_cabecera, DateTime.Today.ToShortDateString());

                //Tabla_cabecera.AddCell(new Phrase("Nivel")) ;
                //Tabla_cabecera.AddCell(new Phrase("Nro"));

                //Tabla_cabecera.AddCell(new Phrase("Local"));
                //Tabla_cabecera.AddCell(new Phrase("Responsable"));

                //Tabla_cabecera.AddCell(new Phrase("Fecha"));
                //Tabla_cabecera.AddCell(new Phrase("Nro Comprobante"));


                //Tabla_cabecera.AddCell(new Phrase("00"));
                //Tabla_cabecera.AddCell(new Phrase("26"));

                //Tabla_cabecera.AddCell(new Phrase("Despacho consejal"));
                //Tabla_cabecera.AddCell(new Phrase("Conj. Zeno"));

                //Tabla_cabecera.AddCell(new Phrase(DateTime.Today.ToShortDateString()));
                Tabla_cabecera.AddCell(new Phrase(talonario));

                doc.Add(Tabla_cabecera);

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

                tabla_faltantes.AddCell("\n\n Local 5 3\n Nivel 1\n Reponsable Leandro\n\n");



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
                Paragraph _Firmaresponsable = new Paragraph();
                _Firmaresponsable.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10f);
                _Firmaresponsable.Alignment = Element.ALIGN_LEFT;
                _Firmaresponsable.SpacingBefore = 30;
                _Firmaresponsable.Add("....................................\n Firma Responsable");

                doc.Add(_Firmaresponsable);

                // Insertamos salto de linea
                Paragraph saltoDeLinea3 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                doc.Add(saltoDeLinea3);

                Paragraph _Piedepagina = new Paragraph();
                _Piedepagina.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10f);
                _Piedepagina.Alignment = Element.ALIGN_LEFT;
                _Piedepagina.SpacingBefore = 5;
                _Piedepagina.Add("Fecha: 16/09/2019 - Usuario: LRaies");

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
