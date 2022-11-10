using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BattleOfMinds.API.Migrations
{
    public partial class UserTableUpdated1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedCode",
                table: "Users");
        }
    }
}
