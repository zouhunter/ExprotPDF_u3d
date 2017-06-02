﻿using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Learn.Chap05
{
    public class Chap0517
    {
        public static void Main()
        {
            Console.WriteLine("Chapter 5 example 17: table offset");
            // step 1: creation of a document-object
            Document document = new Document();
            try
            {
                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter.getInstance(document, new FileStream("Chap0517.pdf", FileMode.Create));
                // step 3: we open the document
                document.Open();
                // step 4: we create a table and add it to the document
                Table table = new Table(3);
                table.BorderWidth = 1;
                table.BorderColor = new Color(0, 0, 255);
                table.Padding = 5;
                table.Spacing = 5;
                Cell cell = new Cell("header");
                cell.Header = true;
                cell.Colspan = 3;
                table.addCell(cell);
                cell = new Cell("example cell with colspan 1 and rowspan 2");
                cell.Rowspan = 2;
                cell.BorderColor = new Color(255, 0, 0);
                table.addCell(cell);
                table.addCell("1.1");
                table.addCell("2.1");
                table.addCell("1.2");
                table.addCell("2.2");
                table.addCell("cell test1");
                cell = new Cell("big cell");
                cell.Rowspan = 2;
                cell.Colspan = 2;
                cell.BackgroundColor = new Color(0xC0, 0xC0, 0xC0);
                table.addCell(cell);
                table.addCell("cell test2");
                document.Add(new Paragraph("repeating the same table 10 times, but with different offsets:"));
                document.Add(table);
                document.Add(new Paragraph("blah blah."));
                document.Add(table);
                document.Add(new Paragraph("we increase the offset."));
                table.Offset = 32;
                document.Add(table);
                document.Add(new Paragraph("blah blah."));
                document.Add(table);
                document.Add(new Paragraph("blah blah."));
                document.Add(table);
                document.Add(new Paragraph("we use an offset 0."));
                table.Offset = 0;
                document.Add(table);
                document.Add(new Paragraph("blah blah."));
                document.Add(table);
                document.Add(new Paragraph("blah blah."));
                document.Add(table);
                document.Add(new Paragraph("A negative offset."));
                table.Offset = -16;
                document.Add(table);
                document.Add(new Paragraph("blah blah."));
                document.Add(table);
            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }
            // step 5: we close the document
            document.Close();

            System.Diagnostics.Process.Start("Chap0517.pdf");
        }
    }


}