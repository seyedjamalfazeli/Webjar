using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webjar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Delete_ProductVariable_DiscountId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "ProductVariables");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "ProductVariables",
                type: "int",
                nullable: true);
        }
    }
}
