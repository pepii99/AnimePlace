using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimePlace.Migrations
{
    public partial class something6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelatedAnime");

            migrationBuilder.CreateIndex(
                name: "IX_Animes_RelatedAnimeId",
                table: "Animes",
                column: "RelatedAnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animes_Animes_RelatedAnimeId",
                table: "Animes",
                column: "RelatedAnimeId",
                principalTable: "Animes",
                principalColumn: "AnimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animes_Animes_RelatedAnimeId",
                table: "Animes");

            migrationBuilder.DropIndex(
                name: "IX_Animes_RelatedAnimeId",
                table: "Animes");

            migrationBuilder.CreateTable(
                name: "RelatedAnime",
                columns: table => new
                {
                    RelatedAnimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedAnime", x => x.RelatedAnimeId);
                    table.ForeignKey(
                        name: "FK_RelatedAnime_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelatedAnime_AnimeId",
                table: "RelatedAnime",
                column: "AnimeId");
        }
    }
}
