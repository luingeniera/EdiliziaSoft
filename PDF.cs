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


        public void GenerarPDF (string titulo,string cuerpo)

        {
            
            //crear el PDF
            Document doc = new Document();
          PdfWriter.GetInstance(doc, new FileStream("holahola2.pdf", FileMode.Create));
            doc.Open();
            Paragraph title = new Paragraph();
          title.Font = FontFactory.GetFont(FontFactory.HELVETICA, 18f, BaseColor.BLUE);
            title.Add(titulo);
            doc.Add(title);
            
             MessageBox.Show(cuerpo);
            
            doc.Add(new Paragraph(cuerpo));
           
            doc.Close();

            Process.Start("holahola2.pdf");


        }

    }
}
