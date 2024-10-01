using System;
using System.Collections.Generic;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.IO;

namespace TextToPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            string filetxt = @"D:\repos\TextToPDF\Result\sample.txt";
            string filedpf = @"D:\repos\TextToPDF\Result\sample.pdf";

            TextToPDF.Create(filetxt, filedpf);
        }        
    }
    
    class TextToPDF
    {
        public static void Create(string textfilefullpath, string pdfsavefullpath)
        {
            //first read text to end add to a string list.
            List<string> textFileLines = new List<string>();
            using (StreamReader sr = new StreamReader(textfilefullpath))
            {
                while (!sr.EndOfStream)
                {
                    textFileLines.Add(sr.ReadLine());
                }
            }

            Document doc = new Document();
            Section section = doc.AddSection();

            //just font arrangements as you wish
            MigraDoc.DocumentObjectModel.Font font = new Font("Times New Roman", 15);
            font.Bold = true;

            //add each line to pdf 
            foreach (string line in textFileLines)
            {
                Paragraph paragraph = section.AddParagraph();
                paragraph.AddFormattedText(line, font);

            }


            //save pdf document
            PdfDocumentRenderer renderer = new PdfDocumentRenderer();
            renderer.Document = doc;
            renderer.RenderDocument();
            renderer.Save(pdfsavefullpath);
        }
    }
}
