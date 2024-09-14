using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Supplier_Offer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierOfferItemId",
                table: "InvoiceItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierOfferId",
                table: "Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierOfferItemId",
                table: "DeliveryItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SupplierOffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PorchaseOrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SupplierOfferEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierOffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierOffer_Customer_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupplierOfferItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Specefecation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedBySmallUnit = table.Column<bool>(type: "bit", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    SupplierOfferId = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierOfferItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierOfferItem_Customer_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupplierOfferItem_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupplierOfferItem_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupplierOfferItem_SupplierOffer_SupplierOfferId",
                        column: x => x.SupplierOfferId,
                        principalTable: "SupplierOffer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupplierOfferItem_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_SupplierOfferItemId",
                table: "InvoiceItem",
                column: "SupplierOfferItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SupplierOfferId",
                table: "Invoice",
                column: "SupplierOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryItem_SupplierOfferItemId",
                table: "DeliveryItem",
                column: "SupplierOfferItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOffer_SupplierId",
                table: "SupplierOffer",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOfferItem_MaterialId",
                table: "SupplierOfferItem",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOfferItem_SizeId",
                table: "SupplierOfferItem",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOfferItem_SupplierId",
                table: "SupplierOfferItem",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOfferItem_SupplierOfferId",
                table: "SupplierOfferItem",
                column: "SupplierOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOfferItem_UnitId",
                table: "SupplierOfferItem",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryItem_SupplierOfferItem_SupplierOfferItemId",
                table: "DeliveryItem",
                column: "SupplierOfferItemId",
                principalTable: "SupplierOfferItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_SupplierOffer_SupplierOfferId",
                table: "Invoice",
                column: "SupplierOfferId",
                principalTable: "SupplierOffer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_SupplierOfferItem_SupplierOfferItemId",
                table: "InvoiceItem",
                column: "SupplierOfferItemId",
                principalTable: "SupplierOfferItem",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryItem_SupplierOfferItem_SupplierOfferItemId",
                table: "DeliveryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_SupplierOffer_SupplierOfferId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_SupplierOfferItem_SupplierOfferItemId",
                table: "InvoiceItem");

            migrationBuilder.DropTable(
                name: "SupplierOfferItem");

            migrationBuilder.DropTable(
                name: "SupplierOffer");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItem_SupplierOfferItemId",
                table: "InvoiceItem");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_SupplierOfferId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryItem_SupplierOfferItemId",
                table: "DeliveryItem");

            migrationBuilder.DropColumn(
                name: "SupplierOfferItemId",
                table: "InvoiceItem");

            migrationBuilder.DropColumn(
                name: "SupplierOfferId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "SupplierOfferItemId",
                table: "DeliveryItem");
        }
    }
}
