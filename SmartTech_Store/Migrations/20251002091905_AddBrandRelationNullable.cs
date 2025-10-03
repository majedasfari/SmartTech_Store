using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartTech_Store.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandRelationNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Shops",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shops_BrandId",
                table: "Shops",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Brands_BrandId",
                table: "Shops",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Brands_BrandId",
                table: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Shops_BrandId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Shops");
        }
    }
}
