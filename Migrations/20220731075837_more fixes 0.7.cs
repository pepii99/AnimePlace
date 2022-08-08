using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimePlace.Migrations
{
    public partial class morefixes07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentlyWatchingListId",
                table: "Animes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CurrentlyWatchingLists",
                columns: table => new
                {
                    CurrentlyWatchingListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserRef = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentlyWatchingLists", x => x.CurrentlyWatchingListId);
                    table.ForeignKey(
                        name: "FK_CurrentlyWatchingLists_AspNetUsers_ApplicationUserRef",
                        column: x => x.ApplicationUserRef,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanToWatchLists",
                columns: table => new
                {
                    PlanToWatchListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserRef = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanToWatchLists", x => x.PlanToWatchListId);
                    table.ForeignKey(
                        name: "FK_PlanToWatchLists_AspNetUsers_ApplicationUserRef",
                        column: x => x.ApplicationUserRef,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimePlanToWatchList",
                columns: table => new
                {
                    PlanToWatchListsPlanToWatchListId = table.Column<int>(type: "int", nullable: false),
                    WatchingAnimesListAnimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimePlanToWatchList", x => new { x.PlanToWatchListsPlanToWatchListId, x.WatchingAnimesListAnimeId });
                    table.ForeignKey(
                        name: "FK_AnimePlanToWatchList_Animes_WatchingAnimesListAnimeId",
                        column: x => x.WatchingAnimesListAnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimePlanToWatchList_PlanToWatchLists_PlanToWatchListsPlanToWatchListId",
                        column: x => x.PlanToWatchListsPlanToWatchListId,
                        principalTable: "PlanToWatchLists",
                        principalColumn: "PlanToWatchListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animes_CurrentlyWatchingListId",
                table: "Animes",
                column: "CurrentlyWatchingListId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimePlanToWatchList_WatchingAnimesListAnimeId",
                table: "AnimePlanToWatchList",
                column: "WatchingAnimesListAnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentlyWatchingLists_ApplicationUserRef",
                table: "CurrentlyWatchingLists",
                column: "ApplicationUserRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanToWatchLists_ApplicationUserRef",
                table: "PlanToWatchLists",
                column: "ApplicationUserRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Animes_CurrentlyWatchingLists_CurrentlyWatchingListId",
                table: "Animes",
                column: "CurrentlyWatchingListId",
                principalTable: "CurrentlyWatchingLists",
                principalColumn: "CurrentlyWatchingListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animes_CurrentlyWatchingLists_CurrentlyWatchingListId",
                table: "Animes");

            migrationBuilder.DropTable(
                name: "AnimePlanToWatchList");

            migrationBuilder.DropTable(
                name: "CurrentlyWatchingLists");

            migrationBuilder.DropTable(
                name: "PlanToWatchLists");

            migrationBuilder.DropIndex(
                name: "IX_Animes_CurrentlyWatchingListId",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "CurrentlyWatchingListId",
                table: "Animes");
        }
    }
}
