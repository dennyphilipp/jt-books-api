using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace book_api.Migrations
{
    /// <inheritdoc />
    public partial class alter_name_table_payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Livro_BookId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_PaymentType_TypeId",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentType",
                table: "PaymentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "PaymentType",
                newName: "TipoPagamento");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Pagamento");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_TypeId",
                table: "Pagamento",
                newName: "IX_Pagamento_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_BookId",
                table: "Pagamento",
                newName: "IX_Pagamento_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoPagamento",
                table: "TipoPagamento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pagamento",
                table: "Pagamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_Livro_BookId",
                table: "Pagamento",
                column: "BookId",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_TipoPagamento_TypeId",
                table: "Pagamento",
                column: "TypeId",
                principalTable: "TipoPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_Livro_BookId",
                table: "Pagamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_TipoPagamento_TypeId",
                table: "Pagamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoPagamento",
                table: "TipoPagamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pagamento",
                table: "Pagamento");

            migrationBuilder.RenameTable(
                name: "TipoPagamento",
                newName: "PaymentType");

            migrationBuilder.RenameTable(
                name: "Pagamento",
                newName: "Payment");

            migrationBuilder.RenameIndex(
                name: "IX_Pagamento_TypeId",
                table: "Payment",
                newName: "IX_Payment_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Pagamento_BookId",
                table: "Payment",
                newName: "IX_Payment_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentType",
                table: "PaymentType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Livro_BookId",
                table: "Payment",
                column: "BookId",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_PaymentType_TypeId",
                table: "Payment",
                column: "TypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
