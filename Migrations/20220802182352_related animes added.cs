using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimePlace.Migrations
{
    public partial class relatedanimesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelatedAnime",
                columns: table => new
                {
                    RelatedAnimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedAnime", x => x.RelatedAnimeId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeRelatedAnime");

            migrationBuilder.DropTable(
                name: "RelatedAnime");
        }
    }
}
