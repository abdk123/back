using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Update_Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfferItemId",
                table: "DeliveryItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryItem_OfferItemId",
                table: "DeliveryItem",
                column: "OfferItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryItem_OfferItem_OfferItemId",
                table: "DeliveryItem",
                column: "OfferItemId",
                principalTable: "OfferItem",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryItem_OfferItem_OfferItemId",
                table: "DeliveryItem");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryItem_OfferItemId",
                table: "DeliveryItem");

            migrationBuilder.DropColumn(
                name: "OfferItemId",
                table: "DeliveryItem");
        }
    }
}
