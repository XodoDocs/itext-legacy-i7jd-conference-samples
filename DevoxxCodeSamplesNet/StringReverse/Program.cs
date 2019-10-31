
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace StringReverse
{
    class Program
    {
        private static string DEST = "results/reverse.pdf";

        static void Main(string[] args)
        {
            new Program().CreatePdf();
        }

        private void CreatePdf()
        {
            string text = "Reverse this String!";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(DEST));
            Document document = new Document(pdfDocument);
            document.Add(new Paragraph(new Text(text)));
            document.Add(new Paragraph(new Text(Reverse(text))));
            pdfDocument.Close();
        }

        private string Reverse(string text)
        {
            //TODO Use a recursive call to reverse the text parameter
            if (text.Length > 1)
            {
                return text.Substring(text.Length - 1) + Reverse(text.Substring(0, text.Length - 1));
            }

            return text;
        }
    }
}