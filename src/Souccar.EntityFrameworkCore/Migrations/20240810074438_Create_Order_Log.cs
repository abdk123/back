using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Create_Order_Log : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_Invoice_InvoiceId",
                table: "Delivery");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceItems_DeliveryItem_DeliveryItemId",
                table: "SaleInvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceItems_SaleInvoices_SaleInvoiceId",
                table: "SaleInvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_Delivery_InvoiceId",
                table: "Delivery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleInvoiceItems",
                table: "SaleInvoiceItems");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Delivery");

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

            migrationBuilder.AlterColumn<double>(
                name: "TotalQuantity",
                table: "SaleInvoiceItem",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleInvoiceItem",
                table: "SaleInvoiceItem",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrderLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_OrderLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderLogAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderLogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLogAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLogAttributes_OrderLogs_OrderLogId",
                        column: x => x.OrderLogId,
                        principalTable: "OrderLogs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLogAttributes_OrderLogId",
                table: "OrderLogAttributes",
                column: "OrderLogId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceItem_DeliveryItem_DeliveryItemId",
                table: "SaleInvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceItem_SaleInvoices_SaleInvoiceId",
                table: "SaleInvoiceItem");

            migrationBuilder.DropTable(
                name: "OrderLogAttributes");

            migrationBuilder.DropTable(
                name: "OrderLogs");

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

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Delivery",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalQuantity",
                table: "SaleInvoiceItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleInvoiceItems",
                table: "SaleInvoiceItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_InvoiceId",
                table: "Delivery",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Invoice_InvoiceId",
                table: "Delivery",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id");

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
    }
}
