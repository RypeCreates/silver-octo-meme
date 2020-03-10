using Microsoft.EntityFrameworkCore.Migrations;

namespace silver_octo_app.Migrations
{
    public partial class AddedBudgetItemEntityToExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Expenses_BudgetItemId",
                table: "Expenses",
                column: "BudgetItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_BudgetItems_BudgetItemId",
                table: "Expenses",
                column: "BudgetItemId",
                principalTable: "BudgetItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_BudgetItems_BudgetItemId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_BudgetItemId",
                table: "Expenses");
        }
    }
}
