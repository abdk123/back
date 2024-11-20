using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Rejected_Material : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RejectedMaterial_Customers_SupplierId",
                table: "RejectedMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_RejectedMaterial_DeliveryItems_DeliveryItemId",
                table: "RejectedMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RejectedMaterial",
                table: "RejectedMaterial");

            migrationBuilder.RenameTable(
                name: "RejectedMaterial",
                newName: "RejectedMaterials");

            migrationBuilder.RenameIndex(
                name: "IX_RejectedMaterial_SupplierId",
                table: "RejectedMaterials",
                newName: "IX_RejectedMaterials_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_RejectedMaterial_DeliveryItemId",
                table: "RejectedMaterials",
                newName: "IX_RejectedMaterials_DeliveryItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RejectedMaterials",
                table: "RejectedMaterials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RejectedMaterials_Customers_SupplierId",
                table: "RejectedMaterials",
                column: "SupplierId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RejectedMaterials_DeliveryItems_DeliveryItemId",
                table: "RejectedMaterials",
                column: "DeliveryItemId",
                principalTable: "DeliveryItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RejectedMaterials_Customers_SupplierId",
                table: "RejectedMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_RejectedMaterials_DeliveryItems_DeliveryItemId",
                table: "RejectedMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RejectedMaterials",
                table: "RejectedMaterials");

            migrationBuilder.RenameTable(
                name: "RejectedMaterials",
                newName: "RejectedMaterial");

            migrationBuilder.RenameIndex(
                name: "IX_RejectedMaterials_SupplierId",
                table: "RejectedMaterial",
                newName: "IX_RejectedMaterial_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_RejectedMaterials_DeliveryItemId",
                table: "RejectedMaterial",
                newName: "IX_RejectedMaterial_DeliveryItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RejectedMaterial",
                table: "RejectedMaterial",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RejectedMaterial_Customers_SupplierId",
                table: "RejectedMaterial",
                column: "SupplierId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RejectedMaterial_DeliveryItems_DeliveryItemId",
                table: "RejectedMaterial",
                column: "DeliveryItemId",
                principalTable: "DeliveryItems",
                principalColumn: "Id");
        }
    }
}
