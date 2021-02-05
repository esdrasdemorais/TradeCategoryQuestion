using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeCategoryQuestion.Migrations
{
    public partial class IsPoliticallyExposed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPoliticallyExposed",
                table: "Trade",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPoliticallyExposed",
                table: "Trade");
        }
    }
}
