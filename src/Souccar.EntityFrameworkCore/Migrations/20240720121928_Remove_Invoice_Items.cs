using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Invoice_Items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_InvoiceItem_InvoiceItemId",
                table: "InvoiceItem");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItem_InvoiceItemId",
                table: "InvoiceItem");

            migrationBuilder.DropColumn(
                name: "InvoiceItemId",
                table: "InvoiceItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceItemId",
                table: "InvoiceItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceItemId",
                table: "InvoiceItem",
                column: "InvoiceItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_InvoiceItem_InvoiceItemId",
                table: "InvoiceItem",
                column: "InvoiceItemId",
                principalTable: "InvoiceItem",
                principalColumn: "Id");
        }
    }
}
