using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webjar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_ProductVariable_Discount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariables_Discounts_DiscountId",
                table: "ProductVariables");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariables_DiscountId",
                table: "ProductVariables");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountAmount",
                table: "ProductVariables",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DiscountExpireAt",
                table: "ProductVariables",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountExpireAt",
                table: "ProductVariables");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountAmount",
                table: "ProductVariables",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariables_DiscountId",
                table: "ProductVariables",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariables_Discounts_DiscountId",
                table: "ProductVariables",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "DiscountId");
        }
    }
}
