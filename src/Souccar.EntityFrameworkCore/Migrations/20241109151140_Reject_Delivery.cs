using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Reject_Delivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelatedId",
                table: "StockHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RejectedMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RejectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaterialSource = table.Column<int>(type: "int", nullable: false),
                    RejectedQuantity = table.Column<double>(type: "float", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    DeliveryItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejectedMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RejectedMaterial_Customers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RejectedMaterial_DeliveryItems_DeliveryItemId",
                        column: x => x.DeliveryItemId,
                        principalTable: "DeliveryItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RejectedMaterial_DeliveryItemId",
                table: "RejectedMaterial",
                column: "DeliveryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RejectedMaterial_SupplierId",
                table: "RejectedMaterial",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RejectedMaterial");

            migrationBuilder.DropColumn(
                name: "RelatedId",
                table: "StockHistories");
        }
    }
}
