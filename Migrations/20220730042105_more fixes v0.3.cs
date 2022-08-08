using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimePlace.Migrations
{
    public partial class morefixesv03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedWatchList_AspNetUsers_ApplicationUserId",
                table: "CompletedWatchList");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchingLists_AspNetUsers_ApplicationUserId",
                table: "WatchingLists");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "WatchingLists",
                newName: "ApplicationUserRef");

            migrationBuilder.RenameIndex(
                name: "IX_WatchingLists_ApplicationUserId",
                table: "WatchingLists",
                newName: "IX_WatchingLists_ApplicationUserRef");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "CompletedWatchList",
                newName: "ApplicationUserRef");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedWatchList_ApplicationUserId",
                table: "CompletedWatchList",
                newName: "IX_CompletedWatchList_ApplicationUserRef");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedWatchList_AspNetUsers_ApplicationUserRef",
                table: "CompletedWatchList",
                column: "ApplicationUserRef",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchingLists_AspNetUsers_ApplicationUserRef",
                table: "WatchingLists",
                column: "ApplicationUserRef",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedWatchList_AspNetUsers_ApplicationUserRef",
                table: "CompletedWatchList");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchingLists_AspNetUsers_ApplicationUserRef",
                table: "WatchingLists");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserRef",
                table: "WatchingLists",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_WatchingLists_ApplicationUserRef",
                table: "WatchingLists",
                newName: "IX_WatchingLists_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserRef",
                table: "CompletedWatchList",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedWatchList_ApplicationUserRef",
                table: "CompletedWatchList",
                newName: "IX_CompletedWatchList_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedWatchList_AspNetUsers_ApplicationUserId",
                table: "CompletedWatchList",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchingLists_AspNetUsers_ApplicationUserId",
                table: "WatchingLists",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
