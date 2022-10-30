using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BattleOfMinds.API.Migrations
{
    public partial class UserScores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Championship",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Championship",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Users");
        }
    }
}
