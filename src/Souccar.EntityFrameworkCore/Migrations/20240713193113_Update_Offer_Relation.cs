using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Update_Offer_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferItem_Offer_PurchaseOrderId",
                table: "OfferItem");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrderId",
                table: "OfferItem",
                newName: "OfferId");

            migrationBuilder.RenameIndex(
                name: "IX_OfferItem_PurchaseOrderId",
                table: "OfferItem",
                newName: "IX_OfferItem_OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferItem_Offer_OfferId",
                table: "OfferItem",
                column: "OfferId",
                principalTable: "Offer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferItem_Offer_OfferId",
                table: "OfferItem");

            migrationBuilder.RenameColumn(
                name: "OfferId",
                table: "OfferItem",
                newName: "PurchaseOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OfferItem_OfferId",
                table: "OfferItem",
                newName: "IX_OfferItem_PurchaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferItem_Offer_PurchaseOrderId",
                table: "OfferItem",
                column: "PurchaseOrderId",
                principalTable: "Offer",
                principalColumn: "Id");
        }
    }
}
