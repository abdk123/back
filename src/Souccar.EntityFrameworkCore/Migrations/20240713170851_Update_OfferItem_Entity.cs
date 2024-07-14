using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Update_OfferItem_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferItem_Customer_SupplierId",
                table: "OfferItem");

            migrationBuilder.DropIndex(
                name: "IX_OfferItem_SupplierId",
                table: "OfferItem");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "OfferItem");

            migrationBuilder.AddColumn<string>(
                name: "Specefecation",
                table: "OfferItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specefecation",
                table: "OfferItem");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Offer");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "OfferItem",
                type: "int",
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
    }
}
