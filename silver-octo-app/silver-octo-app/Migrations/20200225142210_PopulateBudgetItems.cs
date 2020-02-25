using Microsoft.EntityFrameworkCore.Migrations;

namespace silver_octo_app.Migrations
{
    public partial class PopulateBudgetItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("Insert into BudgetItems (CategoryName, Description, Amount) Values ('Beverages', 'All the drinks I enjoy.', 60.00)");
            migrationBuilder.Sql("Insert into BudgetItems (CategoryName, Description, Amount) Values ('Shopping', 'All the clothes I wear.', 40.00)");
            migrationBuilder.Sql("Insert into BudgetItems (CategoryName, Description, Amount) Values ('Food', 'For when I do not feel like cooking.', 100.00)");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }

    }
}
