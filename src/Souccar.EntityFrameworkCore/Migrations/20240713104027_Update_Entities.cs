using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Update_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "TransportCompany");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Offer",
                newName: "PorchaseOrderId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Offer",
                newName: "OrderNumber");

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Offer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Offer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OfferEndDate",
                table: "Offer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Offer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Offer",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransportCompany",
                table: "TransportCompany",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClearanceCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BalanceInDollar = table.Column<double>(type: "float", nullable: false),
                    BalanceInDinar = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClearanceCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClearanceCompanyBalance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherType = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    VoucherNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClearanceCompanyId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_ClearanceCompanyBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClearanceCompanyBalance_Customer_ClearanceCompanyId",
                        column: x => x.ClearanceCompanyId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerBalance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherType = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    VoucherNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_CustomerBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerBalance_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportCost = table.Column<double>(type: "float", nullable: false),
                    TransportCostCurrency = table.Column<int>(type: "int", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TransportedQuantity = table.Column<double>(type: "float", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Delivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delivery_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfferItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferItem_Customer_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferItem_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferItem_Offer_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "Offer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferItem_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferItem_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransportCompanyBalance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherType = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    VoucherNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransportCompanyId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_TransportCompanyBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportCompanyBalance_Customer_TransportCompanyId",
                        column: x => x.TransportCompanyId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Receiving",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportCost = table.Column<double>(type: "float", nullable: false),
                    TransportCostCurrency = table.Column<int>(type: "int", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportCompanyId = table.Column<int>(type: "int", nullable: true),
                    ClearanceCost = table.Column<double>(type: "float", nullable: false),
                    ClearanceCostCurrency = table.Column<int>(type: "int", nullable: false),
                    ClearanceCompanyId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Receiving", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receiving_ClearanceCompany_ClearanceCompanyId",
                        column: x => x.ClearanceCompanyId,
                        principalTable: "ClearanceCompany",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Receiving_Customer_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Receiving_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Receiving_TransportCompany_TransportCompanyId",
                        column: x => x.TransportCompanyId,
                        principalTable: "TransportCompany",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    TotalMaterilPrice = table.Column<double>(type: "float", nullable: false),
                    ReceivedQuantity = table.Column<double>(type: "float", nullable: false),
                    OfferItemId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    InvoiceItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_InvoiceItem_InvoiceItemId",
                        column: x => x.InvoiceItemId,
                        principalTable: "InvoiceItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceItem_OfferItem_OfferItemId",
                        column: x => x.OfferItemId,
                        principalTable: "OfferItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryId = table.Column<int>(type: "int", nullable: true),
                    InvoiceItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryItem_Delivery_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Delivery",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveryItem_InvoiceItem_InvoiceItemId",
                        column: x => x.InvoiceItemId,
                        principalTable: "InvoiceItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReceivingItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivedQuantity = table.Column<double>(type: "float", nullable: false),
                    InvoiceItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivingItem_InvoiceItem_InvoiceItemId",
                        column: x => x.InvoiceItemId,
                        principalTable: "InvoiceItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offer_CustomerId",
                table: "Offer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_SupplierId",
                table: "Offer",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ClearanceCompanyBalance_ClearanceCompanyId",
                table: "ClearanceCompanyBalance",
                column: "ClearanceCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBalance_CustomerId",
                table: "CustomerBalance",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_CustomerId",
                table: "Delivery",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryItem_DeliveryId",
                table: "DeliveryItem",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryItem_InvoiceItemId",
                table: "DeliveryItem",
                column: "InvoiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_OfferId",
                table: "Invoice",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceId",
                table: "InvoiceItem",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceItemId",
                table: "InvoiceItem",
                column: "InvoiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_OfferItemId",
                table: "InvoiceItem",
                column: "OfferItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_MaterialId",
                table: "OfferItem",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_PurchaseOrderId",
                table: "OfferItem",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_SizeId",
                table: "OfferItem",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_SupplierId",
                table: "OfferItem",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_UnitId",
                table: "OfferItem",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_ClearanceCompanyId",
                table: "Receiving",
                column: "ClearanceCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_InvoiceId",
                table: "Receiving",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_SupplierId",
                table: "Receiving",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_TransportCompanyId",
                table: "Receiving",
                column: "TransportCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingItem_InvoiceItemId",
                table: "ReceivingItem",
                column: "InvoiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportCompanyBalance_TransportCompanyId",
                table: "TransportCompanyBalance",
                column: "TransportCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Customer_CustomerId",
                table: "Offer",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Customer_SupplierId",
                table: "Offer",
                column: "SupplierId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Customer_CustomerId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Customer_SupplierId",
                table: "Offer");

            migrationBuilder.DropTable(
                name: "ClearanceCompanyBalance");

            migrationBuilder.DropTable(
                name: "CustomerBalance");

            migrationBuilder.DropTable(
                name: "DeliveryItem");

            migrationBuilder.DropTable(
                name: "Receiving");

            migrationBuilder.DropTable(
                name: "ReceivingItem");

            migrationBuilder.DropTable(
                name: "TransportCompanyBalance");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "ClearanceCompany");

            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "OfferItem");

            migrationBuilder.DropIndex(
                name: "IX_Offer_CustomerId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_SupplierId",
                table: "Offer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransportCompany",
                table: "TransportCompany");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "OfferEndDate",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Offer");

            migrationBuilder.RenameTable(
                name: "TransportCompany",
                newName: "Company");

            migrationBuilder.RenameColumn(
                name: "PorchaseOrderId",
                table: "Offer",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "OrderNumber",
                table: "Offer",
                newName: "Description");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Offer",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");
        }
    }
}
