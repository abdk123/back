using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Update_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceivedQuantity",
                table: "InvoiceItem");

            migrationBuilder.AddColumn<int>(
                name: "ReceivingId",
                table: "ReceivingItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingItem_ReceivingId",
                table: "ReceivingItem",
                column: "ReceivingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingItem_Receiving_ReceivingId",
                table: "ReceivingItem",
                column: "ReceivingId",
                principalTable: "Receiving",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingItem_Receiving_ReceivingId",
                table: "ReceivingItem");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingItem_ReceivingId",
                table: "ReceivingItem");

            migrationBuilder.DropColumn(
                name: "ReceivingId",
                table: "ReceivingItem");

            migrationBuilder.AddColumn<double>(
                name: "ReceivedQuantity",
                table: "InvoiceItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
