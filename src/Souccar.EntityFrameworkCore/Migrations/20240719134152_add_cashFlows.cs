using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class add_cashFlows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClearanceCompanyCashFlow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClearanceCompanyId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AmountDollar = table.Column<double>(type: "float", nullable: false),
                    CurrentBalanceDollar = table.Column<double>(type: "float", nullable: false),
                    AmountDinar = table.Column<double>(type: "float", nullable: false),
                    CurrentBalanceDinar = table.Column<double>(type: "float", nullable: false),
                    TransactionDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClearanceCompanyCashFlow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClearanceCompanyCashFlow_ClearanceCompany_ClearanceCompanyId",
                        column: x => x.ClearanceCompanyId,
                        principalTable: "ClearanceCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCashFlow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AmountDollar = table.Column<double>(type: "float", nullable: false),
                    CurrentBalanceDollar = table.Column<double>(type: "float", nullable: false),
                    AmountDinar = table.Column<double>(type: "float", nullable: false),
                    CurrentBalanceDinar = table.Column<double>(type: "float", nullable: false),
                    TransactionDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCashFlow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerCashFlow_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportCompanyCashFlow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportCompanyId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AmountDollar = table.Column<double>(type: "float", nullable: false),
                    CurrentBalanceDollar = table.Column<double>(type: "float", nullable: false),
                    AmountDinar = table.Column<double>(type: "float", nullable: false),
                    CurrentBalanceDinar = table.Column<double>(type: "float", nullable: false),
                    TransactionDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportCompanyCashFlow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportCompanyCashFlow_TransportCompany_TransportCompanyId",
                        column: x => x.TransportCompanyId,
                        principalTable: "TransportCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClearanceCompanyCashFlow_ClearanceCompanyId",
                table: "ClearanceCompanyCashFlow",
                column: "ClearanceCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCashFlow_CustomerId",
                table: "CustomerCashFlow",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportCompanyCashFlow_TransportCompanyId",
                table: "TransportCompanyCashFlow",
                column: "TransportCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClearanceCompanyCashFlow");

            migrationBuilder.DropTable(
                name: "CustomerCashFlow");

            migrationBuilder.DropTable(
                name: "TransportCompanyCashFlow");
        }
    }
}
