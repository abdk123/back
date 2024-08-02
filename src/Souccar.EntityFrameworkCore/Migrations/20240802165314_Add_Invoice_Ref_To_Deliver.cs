using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Add_Invoice_Ref_To_Deliver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Delivery",
                type: "int",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_Invoice_InvoiceId",
                table: "Delivery");

            migrationBuilder.DropIndex(
                name: "IX_Delivery_InvoiceId",
                table: "Delivery");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Delivery");
        }
    }
}
