using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Add_Notify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceItem_DeliveryItem_DeliveryItemId",
                table: "SaleInvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceItem_SaleInvoices_SaleInvoiceId",
                table: "SaleInvoiceItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleInvoiceItem",
                table: "SaleInvoiceItem");

            migrationBuilder.RenameTable(
                name: "SaleInvoiceItem",
                newName: "SaleInvoiceItems");

            migrationBuilder.RenameIndex(
                name: "IX_SaleInvoiceItem_SaleInvoiceId",
                table: "SaleInvoiceItems",
                newName: "IX_SaleInvoiceItems_SaleInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleInvoiceItem_DeliveryItemId",
                table: "SaleInvoiceItems",
                newName: "IX_SaleInvoiceItems_DeliveryItemId");

            migrationBuilder.AddColumn<bool>(
                name: "Notified",
                table: "SaleInvoices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleInvoiceItems",
                table: "SaleInvoiceItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceItems_DeliveryItem_DeliveryItemId",
                table: "SaleInvoiceItems",
                column: "DeliveryItemId",
                principalTable: "DeliveryItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceItems_SaleInvoices_SaleInvoiceId",
                table: "SaleInvoiceItems",
                column: "SaleInvoiceId",
                principalTable: "SaleInvoices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceItems_DeliveryItem_DeliveryItemId",
                table: "SaleInvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceItems_SaleInvoices_SaleInvoiceId",
                table: "SaleInvoiceItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleInvoiceItems",
                table: "SaleInvoiceItems");

            migrationBuilder.DropColumn(
                name: "Notified",
                table: "SaleInvoices");

            migrationBuilder.RenameTable(
                name: "SaleInvoiceItems",
                newName: "SaleInvoiceItem");

            migrationBuilder.RenameIndex(
                name: "IX_SaleInvoiceItems_SaleInvoiceId",
                table: "SaleInvoiceItem",
                newName: "IX_SaleInvoiceItem_SaleInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleInvoiceItems_DeliveryItemId",
                table: "SaleInvoiceItem",
                newName: "IX_SaleInvoiceItem_DeliveryItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleInvoiceItem",
                table: "SaleInvoiceItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceItem_DeliveryItem_DeliveryItemId",
                table: "SaleInvoiceItem",
                column: "DeliveryItemId",
                principalTable: "DeliveryItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceItem_SaleInvoices_SaleInvoiceId",
                table: "SaleInvoiceItem",
                column: "SaleInvoiceId",
                principalTable: "SaleInvoices",
                principalColumn: "Id");
        }
    }
}
