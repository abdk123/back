using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Update_Delivery_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransportedQuantity",
                table: "Delivery");

            migrationBuilder.AddColumn<double>(
                name: "ApprovedQuantity",
                table: "DeliveryItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RejectedQuantity",
                table: "DeliveryItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TransportedQuantity",
                table: "DeliveryItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedQuantity",
                table: "DeliveryItem");

            migrationBuilder.DropColumn(
                name: "RejectedQuantity",
                table: "DeliveryItem");

            migrationBuilder.DropColumn(
                name: "TransportedQuantity",
                table: "DeliveryItem");

            migrationBuilder.AddColumn<double>(
                name: "TransportedQuantity",
                table: "Delivery",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
