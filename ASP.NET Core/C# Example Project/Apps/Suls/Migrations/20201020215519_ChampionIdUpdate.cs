using Microsoft.EntityFrameworkCore.Migrations;

namespace Suls.Migrations
{
    public partial class ChampionIdUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChampionRiotId",
                table: "Champions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChampionRiotId",
                table: "Champions");
        }
    }
}
