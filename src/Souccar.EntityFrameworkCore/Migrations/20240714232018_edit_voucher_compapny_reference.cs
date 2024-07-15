using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class edit_voucher_compapny_reference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClearanceCompanyBalance_Customer_ClearanceCompanyId",
                table: "ClearanceCompanyBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportCompanyBalance_Customer_TransportCompanyId",
                table: "TransportCompanyBalance");

            migrationBuilder.AddForeignKey(
                name: "FK_ClearanceCompanyBalance_ClearanceCompany_ClearanceCompanyId",
                table: "ClearanceCompanyBalance",
                column: "ClearanceCompanyId",
                principalTable: "ClearanceCompany",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportCompanyBalance_TransportCompany_TransportCompanyId",
                table: "TransportCompanyBalance",
                column: "TransportCompanyId",
                principalTable: "TransportCompany",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClearanceCompanyBalance_ClearanceCompany_ClearanceCompanyId",
                table: "ClearanceCompanyBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportCompanyBalance_TransportCompany_TransportCompanyId",
                table: "TransportCompanyBalance");

            migrationBuilder.AddForeignKey(
                name: "FK_ClearanceCompanyBalance_Customer_ClearanceCompanyId",
                table: "ClearanceCompanyBalance",
                column: "ClearanceCompanyId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportCompanyBalance_Customer_TransportCompanyId",
                table: "TransportCompanyBalance",
                column: "TransportCompanyId",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
