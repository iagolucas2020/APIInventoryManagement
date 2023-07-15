using System;
using System.IO;
using APIInventoryManagement.API.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace APIInventoryManagement.API.Services.Shared
{
    public class Usefuls
    {
        public static void merchandisesPdf(string pathDirectory, IEnumerable<Merchandise> merchandises)
        {

            // Criação do documento
            Document document = new Document();

            // Caminho para salvar o arquivo PDF
            string path = String.Concat(pathDirectory, "/wwwroot/temp/arquivo.pdf");

            // Criação do escritor de PDF
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

            // Abertura do documento
            document.Open();

            PdfPTable table = new PdfPTable(6);
            PdfPCell cel = new PdfPCell();

            cel.Phrase = new Phrase("Código");
            table.AddCell(cel);
            cel.Phrase = new Phrase("Nome");
            table.AddCell(cel);
            cel.Phrase = new Phrase("Numero Registro");
            table.AddCell(cel);
            cel.Phrase = new Phrase("Fabricante");
            table.AddCell(cel);
            cel.Phrase = new Phrase("Tipo");
            table.AddCell(cel);
            cel.Phrase = new Phrase("Descrição");
            table.AddCell(cel);

            foreach (var m in merchandises)
            {
                cel.Phrase = new Phrase(m.Id.ToString());
                table.AddCell(cel);
                cel.Phrase = new Phrase(m.Name.ToString());
                table.AddCell(cel);
                cel.Phrase = new Phrase(m.RegisterNumber.ToString());
                table.AddCell(cel);
                cel.Phrase = new Phrase(m.Manufacturer.ToString());
                table.AddCell(cel);
                cel.Phrase = new Phrase(m.Type.ToString());
                table.AddCell(cel);
                cel.Phrase = new Phrase(m.Description.ToString());
                table.AddCell(cel);
            }

            document.Add(table);

            // Fechamento do documento
            document.Close();

        }

        public static void stocksPdf(string pathDirectory, IEnumerable<Stock> stocks)
        {

            // Criação do documento
            Document document = new Document();

            // Caminho para salvar o arquivo PDF
            string path = String.Concat(pathDirectory, "/wwwroot/temp/arquivo.pdf");

            // Criação do escritor de PDF
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

            // Abertura do documento
            document.Open();

            PdfPTable table = new PdfPTable(6);
            PdfPCell cel = new PdfPCell();

            cel.Phrase = new Phrase("Código");
            table.AddCell(cel);
            cel.Phrase = new Phrase("Mercadoria");
            table.AddCell(cel);
            cel.Phrase = new Phrase("Quantidade");
            table.AddCell(cel);
            cel.Phrase = new Phrase("Data");
            table.AddCell(cel);
            cel.Phrase = new Phrase("Local");
            table.AddCell(cel);
            cel.Phrase = new Phrase("Status");
            table.AddCell(cel);


            foreach (var m in stocks)
            {
                cel.Phrase = new Phrase(m.Id.ToString());
                table.AddCell(cel);
                cel.Phrase = new Phrase(m.Merchandise.Name.ToString());
                table.AddCell(cel);
                cel.Phrase = new Phrase(m.Quantity.ToString());
                table.AddCell(cel);
                cel.Phrase = new Phrase(m.Date.ToString());
                table.AddCell(cel);
                cel.Phrase = new Phrase(m.Location.ToString());
                table.AddCell(cel);
                cel.Phrase = new Phrase(m.Receipt.Equals(true) ? "Entrada" : "Saída");
                table.AddCell(cel);
            }

            document.Add(table);

            // Fechamento do documento
            document.Close();

        }
    }
}
