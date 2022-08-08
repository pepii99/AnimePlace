using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimePlace.Migrations
{
    public partial class morefixes08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animes_CurrentlyWatchingLists_CurrentlyWatchingListId",
                table: "Animes");

            migrationBuilder.DropIndex(
                name: "IX_Animes_CurrentlyWatchingListId",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "CurrentlyWatchingListId",
                table: "Animes");

            migrationBuilder.CreateTable(
                name: "AnimeCurrentlyWatchingList",
                columns: table => new
                {
                    CurrentlyWatchingAnimesListAnimeId = table.Column<int>(type: "int", nullable: false),
                    CurrentlyWatchingListsCurrentlyWatchingListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeCurrentlyWatchingList", x => new { x.CurrentlyWatchingAnimesListAnimeId, x.CurrentlyWatchingListsCurrentlyWatchingListId });
                    table.ForeignKey(
                        name: "FK_AnimeCurrentlyWatchingList_Animes_CurrentlyWatchingAnimesListAnimeId",
                        column: x => x.CurrentlyWatchingAnimesListAnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeCurrentlyWatchingList_CurrentlyWatchingLists_CurrentlyWatchingListsCurrentlyWatchingListId",
                        column: x => x.CurrentlyWatchingListsCurrentlyWatchingListId,
                        principalTable: "CurrentlyWatchingLists",
                        principalColumn: "CurrentlyWatchingListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeCurrentlyWatchingList_CurrentlyWatchingListsCurrentlyWatchingListId",
                table: "AnimeCurrentlyWatchingList",
                column: "CurrentlyWatchingListsCurrentlyWatchingListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeCurrentlyWatchingList");

            migrationBuilder.AddColumn<int>(
                name: "CurrentlyWatchingListId",
                table: "Animes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animes_CurrentlyWatchingListId",
                table: "Animes",
                column: "CurrentlyWatchingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animes_CurrentlyWatchingLists_CurrentlyWatchingListId",
                table: "Animes",
                column: "CurrentlyWatchingListId",
                principalTable: "CurrentlyWatchingLists",
                principalColumn: "CurrentlyWatchingListId");
        }
    }
}
