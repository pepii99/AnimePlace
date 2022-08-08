using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimePlace.Migrations
{
    public partial class morefixes09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimePlanToWatchList_Animes_WatchingAnimesListAnimeId",
                table: "AnimePlanToWatchList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimePlanToWatchList",
                table: "AnimePlanToWatchList");

            migrationBuilder.DropIndex(
                name: "IX_AnimePlanToWatchList_WatchingAnimesListAnimeId",
                table: "AnimePlanToWatchList");

            migrationBuilder.RenameColumn(
                name: "WatchingAnimesListAnimeId",
                table: "AnimePlanToWatchList",
                newName: "PlanToWatchAnimeListAnimeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimePlanToWatchList",
                table: "AnimePlanToWatchList",
                columns: new[] { "PlanToWatchAnimeListAnimeId", "PlanToWatchListsPlanToWatchListId" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimePlanToWatchList_PlanToWatchListsPlanToWatchListId",
                table: "AnimePlanToWatchList",
                column: "PlanToWatchListsPlanToWatchListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimePlanToWatchList_Animes_PlanToWatchAnimeListAnimeId",
                table: "AnimePlanToWatchList",
                column: "PlanToWatchAnimeListAnimeId",
                principalTable: "Animes",
                principalColumn: "AnimeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimePlanToWatchList_Animes_PlanToWatchAnimeListAnimeId",
                table: "AnimePlanToWatchList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimePlanToWatchList",
                table: "AnimePlanToWatchList");

            migrationBuilder.DropIndex(
                name: "IX_AnimePlanToWatchList_PlanToWatchListsPlanToWatchListId",
                table: "AnimePlanToWatchList");

            migrationBuilder.RenameColumn(
                name: "PlanToWatchAnimeListAnimeId",
                table: "AnimePlanToWatchList",
                newName: "WatchingAnimesListAnimeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimePlanToWatchList",
                table: "AnimePlanToWatchList",
                columns: new[] { "PlanToWatchListsPlanToWatchListId", "WatchingAnimesListAnimeId" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimePlanToWatchList_WatchingAnimesListAnimeId",
                table: "AnimePlanToWatchList",
                column: "WatchingAnimesListAnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimePlanToWatchList_Animes_WatchingAnimesListAnimeId",
                table: "AnimePlanToWatchList",
                column: "WatchingAnimesListAnimeId",
                principalTable: "Animes",
                principalColumn: "AnimeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
