using System;
using System.IO;
using iText.Html2pdf;

namespace HTML
{
    class Program
    {
        private static string DEST = "results/html.pdf";
        private static string HTML = "html/hello.html";
        
        static void Main(string[] args)
        {
            new Program().CreatePdf();
        }

        public void CreatePdf()
        {
            //TODO Create an input FileStream
            FileStream input = new FileStream(HTML, FileMode.Open);
            //TODO Create an output FileStream
            FileStream output = new FileStream(DEST, FileMode.CreateNew);
            
            ConverterProperties converterProperties = new ConverterProperties();
            converterProperties.SetBaseUri("html");
            HtmlConverter.ConvertToPdf(input, output, converterProperties);
        }
    }
}