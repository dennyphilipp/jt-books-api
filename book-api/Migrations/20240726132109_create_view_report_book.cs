using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace book_api.Migrations
{
    /// <inheritdoc />
    public partial class create_view_report_book : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE VIEW public.""ReportBook"" AS
                SELECT
                    gen_random_uuid() AS ""Id"",
                    a.""Nome"" AS ""Autor"",
                    l.""Titulo"" AS ""Livro"",
                    l.""Editora"" AS ""Editora"",
                    l.""Edicao"" AS ""Edicao"",
                    l.""AnoPublicacao"" AS ""Ano"",
                    s.""Descricao"" AS ""Assunto""
                FROM
                    public.""Autor"" a
                JOIN
                    public.""AuthorBook"" ab ON a.""Id"" = ab.""AuthorsId""
                JOIN
                    public.""Livro"" l ON ab.""BooksId"" = l.""Id""
                JOIN
                    public.""BookSubject"" bs ON l.""Id"" = bs.""BooksId""
                JOIN
                    public.""Assunto"" s ON bs.""SubjectsId"" = s.""Id""
                ORDER BY
                    a.""Nome"", l.""Titulo"", s.""Descricao"";
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
