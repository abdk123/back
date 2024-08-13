using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Add_RelatedId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OfferId",
                table: "OrderLogs",
                newName: "RelatedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelatedId",
                table: "OrderLogs",
                newName: "OfferId");
        }
    }
}
