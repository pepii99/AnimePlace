using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimePlace.Migrations
{
    public partial class morefixes10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeWatchingList");

            migrationBuilder.DropTable(
                name: "WatchingLists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WatchingLists",
                columns: table => new
                {
                    WatchingListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserRef = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchingLists", x => x.WatchingListId);
                    table.ForeignKey(
                        name: "FK_WatchingLists_AspNetUsers_ApplicationUserRef",
                        column: x => x.ApplicationUserRef,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                name: "IX_AnimeWatchingList_WatchingListsWatchingListId",
                table: "AnimeWatchingList",
                column: "WatchingListsWatchingListId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchingLists_ApplicationUserRef",
                table: "WatchingLists",
                column: "ApplicationUserRef",
                unique: true);
        }
    }
}
