using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimePlace.Migrations
{
    public partial class morework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompletedWatchList",
                columns: table => new
                {
                    CompletedWatchListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedWatchList", x => x.CompletedWatchListId);
                    table.ForeignKey(
                        name: "FK_CompletedWatchList_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchingLists",
                columns: table => new
                {
                    WatchingListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchingLists", x => x.WatchingListId);
                    table.ForeignKey(
                        name: "FK_WatchingLists_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeCompletedWatchList",
                columns: table => new
                {
                    CompletedAnimesAnimeId = table.Column<int>(type: "int", nullable: false),
                    CompletedWatchListsCompletedWatchListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeCompletedWatchList", x => new { x.CompletedAnimesAnimeId, x.CompletedWatchListsCompletedWatchListId });
                    table.ForeignKey(
                        name: "FK_AnimeCompletedWatchList_Animes_CompletedAnimesAnimeId",
                        column: x => x.CompletedAnimesAnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeCompletedWatchList_CompletedWatchList_CompletedWatchListsCompletedWatchListId",
                        column: x => x.CompletedWatchListsCompletedWatchListId,
                        principalTable: "CompletedWatchList",
                        principalColumn: "CompletedWatchListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeWatchingList",
                columns: table => new
                {
                    WatchingAnimesListAnimeId = table.Column<int>(type: "int", nullable: false),
                    WatchingListsWatchingListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeWatchingList", x => new { x.WatchingAnimesListAnimeId, x.WatchingListsWatchingListId });
                    table.ForeignKey(
                        name: "FK_AnimeWatchingList_Animes_WatchingAnimesListAnimeId",
                        column: x => x.WatchingAnimesListAnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeWatchingList_WatchingLists_WatchingListsWatchingListId",
                        column: x => x.WatchingListsWatchingListId,
                        principalTable: "WatchingLists",
                        principalColumn: "WatchingListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeCompletedWatchList_CompletedWatchListsCompletedWatchListId",
                table: "AnimeCompletedWatchList",
                column: "CompletedWatchListsCompletedWatchListId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeWatchingList_WatchingListsWatchingListId",
                table: "AnimeWatchingList",
                column: "WatchingListsWatchingListId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedWatchList_ApplicationUserId",
                table: "CompletedWatchList",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WatchingLists_ApplicationUserId",
                table: "WatchingLists",
                column: "ApplicationUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeCompletedWatchList");

            migrationBuilder.DropTable(
                name: "AnimeWatchingList");

            migrationBuilder.DropTable(
                name: "CompletedWatchList");

            migrationBuilder.DropTable(
                name: "WatchingLists");
        }
    }
}
