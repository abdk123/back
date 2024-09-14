using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Add_Rejection_Date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransportedQuantity",
                table: "DeliveryItem");

            migrationBuilder.AddColumn<DateTime>(
                name: "RejectionDate",
                table: "DeliveryItem",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RejectionDate",
                table: "DeliveryItem");

            migrationBuilder.AddColumn<double>(
                name: "TransportedQuantity",
                table: "DeliveryItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
