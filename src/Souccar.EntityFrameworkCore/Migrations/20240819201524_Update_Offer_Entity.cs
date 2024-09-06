using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Update_Offer_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Customer_SupplierId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_SupplierId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Offer");

            migrationBuilder.AddColumn<string>(
                name: "MaterialName",
                table: "OfferItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "OfferItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitName",
                table: "OfferItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_SupplierId",
                table: "OfferItem",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferItem_Customer_SupplierId",
                table: "OfferItem",
                column: "SupplierId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferItem_Customer_SupplierId",
                table: "OfferItem");

            migrationBuilder.DropIndex(
                name: "IX_OfferItem_SupplierId",
                table: "OfferItem");

            migrationBuilder.DropColumn(
                name: "MaterialName",
                table: "OfferItem");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "OfferItem");

            migrationBuilder.DropColumn(
                name: "UnitName",
                table: "OfferItem");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Offer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offer_SupplierId",
                table: "Offer",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Customer_SupplierId",
                table: "Offer",
                column: "SupplierId",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
