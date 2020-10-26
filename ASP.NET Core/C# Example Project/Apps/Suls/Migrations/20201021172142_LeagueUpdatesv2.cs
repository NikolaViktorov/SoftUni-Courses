using Microsoft.EntityFrameworkCore.Migrations;

namespace Suls.Migrations
{
    public partial class LeagueUpdatesv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Champions_ChampionId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_ChampionId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Champions",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "ChampionId",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Champions",
                newName: "ChampionsStatic");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChampionsStatic",
                table: "ChampionsStatic",
                column: "ChampionId");

            migrationBuilder.CreateTable(
                name: "PlayerChampion",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    ChampionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerChampion", x => new { x.PlayerId, x.ChampionId });
                    table.ForeignKey(
                        name: "FK_PlayerChampion_ChampionsStatic_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "ChampionsStatic",
                        principalColumn: "ChampionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerChampion_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerChampion_ChampionId",
                table: "PlayerChampion",
                column: "ChampionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerChampion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChampionsStatic",
                table: "ChampionsStatic");

            migrationBuilder.RenameTable(
                name: "ChampionsStatic",
                newName: "Champions");

            migrationBuilder.AddColumn<int>(
                name: "ChampionId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Champions",
                table: "Champions",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ChampionId",
                table: "Players",
                column: "ChampionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Champions_ChampionId",
                table: "Players",
                column: "ChampionId",
                principalTable: "Champions",
                principalColumn: "ChampionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
