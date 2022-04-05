using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenses.DB.Migrations
{
    public partial class modelamount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Balance",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
