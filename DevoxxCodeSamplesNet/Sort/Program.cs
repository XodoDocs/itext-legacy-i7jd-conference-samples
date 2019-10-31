using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace Sort
{
    class Program
    {
        private static string DEST = "results/sort.pdf";

        static void Main(string[] args)
        {
            new Program().CreatePdf();
        }

        public void CreatePdf()
        {
            int[] array = new int[10];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (int) (random.Next(20));
            }

            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(DEST));
            Document document = new Document(pdfDocument);
            document.Add(new Paragraph("Unsorted"));
            document.Add(PrintArray(array));
            document.Add(new Paragraph("Sorted"));
            document.Add(PrintArray(SortArray(array)));
            pdfDocument.Close();
        }

        private Table PrintArray(int[] array)
        {
            Table table = new Table(1);
            for (int i = 0; i < array.Length; i++)
            {
                table.AddCell(array[i].ToString());
            }

            return table;
        }

        private int[] SortArray(int[] array)
        {
            // TODO Sort the array using any sorting algorithm
            // Selection sort
            for (int i = 0; i < array.Length; i++)
            {
                int min = array[i];
                int minId = i;
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[j] < min)
                    {
                        min = array[j];
                        minId = j;
                    }
                }

                int temp = array[i];
                array[i] = min;
                array[minId] = temp;
            }

            return array;
        }
    }
}