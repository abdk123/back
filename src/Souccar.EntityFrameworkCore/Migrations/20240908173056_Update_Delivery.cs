using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Update_Delivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryItem_InvoiceItem_InvoiceItemId",
                table: "DeliveryItem");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryItem_InvoiceItemId",
                table: "DeliveryItem");

            migrationBuilder.DropColumn(
                name: "InvoiceItemId",
                table: "DeliveryItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceItemId",
                table: "DeliveryItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryItem_InvoiceItemId",
                table: "DeliveryItem",
                column: "InvoiceItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryItem_InvoiceItem_InvoiceItemId",
                table: "DeliveryItem",
                column: "InvoiceItemId",
                principalTable: "InvoiceItem",
                principalColumn: "Id");
        }
    }
}
