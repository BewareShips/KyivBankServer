using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenses.DB.Migrations
{
    public partial class modelupdateexpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ToAccount",
                table: "Expenses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToAccount",
                table: "Expenses");
        }
    }
}
