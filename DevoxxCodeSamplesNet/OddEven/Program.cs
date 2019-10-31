using System;
using System.IO;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.Win32.SafeHandles;

namespace OddEven
{
    class Program
    {
        private static string DEST = "results/oddEven.pdf";

        static void Main(string[] args)
        {
            new Program().CreatePdf();
        }

        public void CreatePdf()
        {
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(new FileStream(DEST, FileMode.Create)));
            Document document = new Document(pdfDocument);
            Table table = new Table(6);
            for (int i = 0; i < 600; i++)
            {
                Cell cell = new Cell();
                //TODO Add a conditional statement that changes the background color to gray if i is odd
                if (i%2 != 0)
                {
                    cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY);
                }

                table.AddCell(cell.Add(new Paragraph(i.ToString())));
            }

            document.Add(table);
            pdfDocument.Close();
        }
    }
}