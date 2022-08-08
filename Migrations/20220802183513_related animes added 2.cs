using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimePlace.Migrations
{
    public partial class relatedanimesadded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeRelatedAnime");

            migrationBuilder.AddColumn<int>(
                name: "AnimeId",
                table: "RelatedAnime",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RelatedAnime_AnimeId",
                table: "RelatedAnime",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedAnime_Animes_AnimeId",
                table: "RelatedAnime",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "AnimeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelatedAnime_Animes_AnimeId",
                table: "RelatedAnime");

            migrationBuilder.DropIndex(
                name: "IX_RelatedAnime_AnimeId",
                table: "RelatedAnime");

            migrationBuilder.DropColumn(
                name: "AnimeId",
                table: "RelatedAnime");

            migrationBuilder.CreateTable(
                name: "AnimeRelatedAnime",
                columns: table => new
                {
                    RelatedAnimesAnimeId = table.Column<int>(type: "int", nullable: false),
                    RelatedAnimesRelatedAnimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeRelatedAnime", x => new { x.RelatedAnimesAnimeId, x.RelatedAnimesRelatedAnimeId });
                    table.ForeignKey(
                        name: "FK_AnimeRelatedAnime_Animes_RelatedAnimesAnimeId",
                        column: x => x.RelatedAnimesAnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeRelatedAnime_RelatedAnime_RelatedAnimesRelatedAnimeId",
                        column: x => x.RelatedAnimesRelatedAnimeId,
                        principalTable: "RelatedAnime",
                        principalColumn: "RelatedAnimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeRelatedAnime_RelatedAnimesRelatedAnimeId",
                table: "AnimeRelatedAnime",
                column: "RelatedAnimesRelatedAnimeId");
        }
    }
}
