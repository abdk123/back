using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Update_Cash_Flow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentBalanceDinar",
                table: "TransportCompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "CurrentBalanceDollar",
                table: "TransportCompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "TransportCompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "CurrentBalanceDinar",
                table: "CustomerCashFlows");

            migrationBuilder.DropColumn(
                name: "CurrentBalanceDollar",
                table: "CustomerCashFlows");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "CustomerCashFlows");

            migrationBuilder.DropColumn(
                name: "CurrentBalanceDinar",
                table: "ClearanceCompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "CurrentBalanceDollar",
                table: "ClearanceCompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "ClearanceCompanyCashFlows");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CurrentBalanceDinar",
                table: "TransportCompanyCashFlows",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CurrentBalanceDollar",
                table: "TransportCompanyCashFlows",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "TransportCompanyCashFlows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CurrentBalanceDinar",
                table: "CustomerCashFlows",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CurrentBalanceDollar",
                table: "CustomerCashFlows",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "CustomerCashFlows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CurrentBalanceDinar",
                table: "ClearanceCompanyCashFlows",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CurrentBalanceDollar",
                table: "ClearanceCompanyCashFlows",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "ClearanceCompanyCashFlows",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
