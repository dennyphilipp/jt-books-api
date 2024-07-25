using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace book_api.Migrations
{
    /// <inheritdoc />
    public partial class many_to_many_book_subject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookSubject",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "integer", nullable: false),
                    SubjectsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSubject", x => new { x.BooksId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_BookSubject_Assunto_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Assunto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookSubject_Livro_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookSubject_SubjectsId",
                table: "BookSubject",
                column: "SubjectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookSubject");
        }
    }
}
