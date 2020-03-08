using Microsoft.EntityFrameworkCore.Migrations;

namespace silver_octo_app.Migrations
{
    public partial class FixedExpenseFKReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Expenses");

            migrationBuilder.AddColumn<long>(
                name: "BudgetItemId",
                table: "Expenses",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BudgetItemId",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
