using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using book_api.Book.Domain;
using book_api.Persistence;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;

namespace book_api.Book.Service
{
    public class ReportBookService
    {
        private readonly Context _context;

        public ReportBookService(Context context)
        {
            _context = context;
        }

        internal async Task<byte[]> Execute()
        {
            var result = await _context.ReportBook.ToListAsync();
            var dataTable = ConvertToDataTable(result);
            return GeneratePdfReport(dataTable);
        }

        static DataTable ConvertToDataTable(List<ReportBook> dados)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Autor", typeof(string));
            dataTable.Columns.Add("Livro", typeof(string));
            dataTable.Columns.Add("Editora", typeof(string));
            dataTable.Columns.Add("Edicao", typeof(int));
            dataTable.Columns.Add("Ano", typeof(string));
            dataTable.Columns.Add("Assunto", typeof(string));

            foreach (var dado in dados)
            {
                dataTable.Rows.Add(dado.Author, dado.Book, dado.Publisher, dado.Version, dado.Year, dado.Subject);
            }

            return dataTable;
        }

        private byte[] GeneratePdfReport(DataTable dataTable)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();

                // Adiciona o título ao documento
                Font titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
                Paragraph title = new Paragraph("Relatório de Autores, Livros e Assuntos", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20
                };
                document.Add(title);

                // Adiciona a tabela ao documento
                PdfPTable table = new PdfPTable(dataTable.Columns.Count);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 20f, 20f, 20f, 20f, 20f, 20f });

                // Adiciona o cabeçalho
                foreach (DataColumn column in dataTable.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont("Arial", 12, Font.BOLD)))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = BaseColor.LIGHT_GRAY
                    };
                    table.AddCell(cell);
                }

                // Adiciona as linhas
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(item.ToString(), FontFactory.GetFont("Arial", 10)))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER
                        };
                        table.AddCell(cell);
                    }
                }

                document.Add(table);
                document.Close();
                writer.Close();

                return ms.ToArray();
            }
        }
    }
}