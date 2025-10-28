using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartTech_Store.Migrations
{
    /// <inheritdoc />
    public partial class createnewtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OrderItemId",
                table: "Employees",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_OrderItems_OrderItemId",
                table: "Employees",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_OrderItems_OrderItemId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_OrderItemId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "Employees");
        }
    }
}
