using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenses.DB.Migrations
{
    public partial class modeluser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNumberGenerated",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Balance",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumberGenerated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Users");
        }
    }
}
