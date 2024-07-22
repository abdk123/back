using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class workflow_reference_nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClearanceCompanyCashFlow_ClearanceCompany_ClearanceCompanyId",
                table: "ClearanceCompanyCashFlow");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCashFlow_Customer_CustomerId",
                table: "CustomerCashFlow");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportCompanyCashFlow_TransportCompany_TransportCompanyId",
                table: "TransportCompanyCashFlow");

            migrationBuilder.AlterColumn<int>(
                name: "TransportCompanyId",
                table: "TransportCompanyCashFlow",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerCashFlow",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClearanceCompanyId",
                table: "ClearanceCompanyCashFlow",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ClearanceCompanyCashFlow_ClearanceCompany_ClearanceCompanyId",
                table: "ClearanceCompanyCashFlow",
                column: "ClearanceCompanyId",
                principalTable: "ClearanceCompany",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCashFlow_Customer_CustomerId",
                table: "CustomerCashFlow",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportCompanyCashFlow_TransportCompany_TransportCompanyId",
                table: "TransportCompanyCashFlow",
                column: "TransportCompanyId",
                principalTable: "TransportCompany",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClearanceCompanyCashFlow_ClearanceCompany_ClearanceCompanyId",
                table: "ClearanceCompanyCashFlow");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCashFlow_Customer_CustomerId",
                table: "CustomerCashFlow");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportCompanyCashFlow_TransportCompany_TransportCompanyId",
                table: "TransportCompanyCashFlow");

            migrationBuilder.AlterColumn<int>(
                name: "TransportCompanyId",
                table: "TransportCompanyCashFlow",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerCashFlow",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClearanceCompanyId",
                table: "ClearanceCompanyCashFlow",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClearanceCompanyCashFlow_ClearanceCompany_ClearanceCompanyId",
                table: "ClearanceCompanyCashFlow",
                column: "ClearanceCompanyId",
                principalTable: "ClearanceCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCashFlow_Customer_CustomerId",
                table: "CustomerCashFlow",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportCompanyCashFlow_TransportCompany_TransportCompanyId",
                table: "TransportCompanyCashFlow",
                column: "TransportCompanyId",
                principalTable: "TransportCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
