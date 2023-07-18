using System;
using System.Drawing;
using System.IO;
using APIInventoryManagement.API.Models;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using Rectangle = System.Drawing.Rectangle;

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
            bool flag = false;

            Paragraph p0 = new Paragraph("Relatório de Mercadorias", FontFactory.GetFont("Times New Roman", 15, Font.BOLD, BaseColor.BLACK));
            p0.Alignment = Element.ALIGN_CENTER;
            document.Add(p0);
            document.Add(new Paragraph("\n"));

            cel.HorizontalAlignment = 1;
            table.TotalWidth = 560f;
            table.LockedWidth = true;

            cel.Phrase = new Phrase("Lista de Mercadorias", FontFactory.GetFont("Times New Roman", 13, Font.BOLD, BaseColor.WHITE));
            cel.Colspan = 6;
            cel.BackgroundColor = BaseColor.ORANGE;
            table.AddCell(cel);

            cel.Colspan = 1;
            cel.BackgroundColor = BaseColor.BLUE;

            cel.Phrase = new Phrase("Código", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("Nome", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("Numero Registro", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("Fabricante", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("Tipo", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("Descrição", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.BackgroundColor = BaseColor.WHITE;

            foreach (var m in merchandises)
            {
                if (flag)
                {
                    cel.BackgroundColor = BaseColor.GRAY;
                }
                cel.Phrase = new Phrase(m.Id.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.Name.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.RegisterNumber.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.Manufacturer.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.Type.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.Description.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.BackgroundColor = BaseColor.WHITE;
                flag = !flag;
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
            bool flag = false;

            Paragraph p0 = new Paragraph("Relatório de Estoque", FontFactory.GetFont("Times New Roman", 15, Font.BOLD, BaseColor.BLACK));
            p0.Alignment = Element.ALIGN_CENTER;
            document.Add(p0);
            document.Add(new Paragraph("\n"));

            cel.HorizontalAlignment = 1;
            table.TotalWidth = 560f;
            table.LockedWidth = true;

            cel.Phrase = new Phrase("Lista de Estoque", FontFactory.GetFont("Times New Roman", 13, Font.BOLD, BaseColor.WHITE));
            cel.Colspan = 6;
            cel.BackgroundColor = BaseColor.ORANGE;
            table.AddCell(cel);

            cel.Colspan = 1;
            cel.BackgroundColor = BaseColor.BLUE;

            cel.Phrase = new Phrase("Código", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("Mercadoria", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("Quantidade", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("Data", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("Local", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("Status", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.BackgroundColor = BaseColor.WHITE;

            foreach (var m in stocks)
            {
                if (flag)
                {
                    cel.BackgroundColor = BaseColor.GRAY;
                }
                cel.Phrase = new Phrase(m.Id.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.Merchandise.Name.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.Quantity.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.Date.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.Location.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.Receipt.Equals(true) ? "Entrada" : "Saída", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.BackgroundColor = BaseColor.WHITE;
                flag = !flag;
            }

            document.Add(table);

            // Fechamento do documento
            document.Close();

        }
    }
}
