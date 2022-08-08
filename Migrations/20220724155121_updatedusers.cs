using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimePlace.Migrations
{
    public partial class updatedusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeApplicationUser_AspNetUsers_UsersId",
                table: "AnimeApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCharacter_AspNetUsers_UsersId",
                table: "ApplicationUserCharacter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserCharacter",
                table: "ApplicationUserCharacter");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserCharacter_UsersId",
                table: "ApplicationUserCharacter");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "ApplicationUserCharacter",
                newName: "ApplicationUsersId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "AnimeApplicationUser",
                newName: "ApplicationUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeApplicationUser_UsersId",
                table: "AnimeApplicationUser",
                newName: "IX_AnimeApplicationUser_ApplicationUsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserCharacter",
                table: "ApplicationUserCharacter",
                columns: new[] { "ApplicationUsersId", "CharactersCharacterId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserCharacter_CharactersCharacterId",
                table: "ApplicationUserCharacter",
                column: "CharactersCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeApplicationUser_AspNetUsers_ApplicationUsersId",
                table: "AnimeApplicationUser",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCharacter_AspNetUsers_ApplicationUsersId",
                table: "ApplicationUserCharacter",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeApplicationUser_AspNetUsers_ApplicationUsersId",
                table: "AnimeApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCharacter_AspNetUsers_ApplicationUsersId",
                table: "ApplicationUserCharacter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserCharacter",
                table: "ApplicationUserCharacter");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserCharacter_CharactersCharacterId",
                table: "ApplicationUserCharacter");

            migrationBuilder.RenameColumn(
                name: "ApplicationUsersId",
                table: "ApplicationUserCharacter",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUsersId",
                table: "AnimeApplicationUser",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeApplicationUser_ApplicationUsersId",
                table: "AnimeApplicationUser",
                newName: "IX_AnimeApplicationUser_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserCharacter",
                table: "ApplicationUserCharacter",
                columns: new[] { "CharactersCharacterId", "UsersId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserCharacter_UsersId",
                table: "ApplicationUserCharacter",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeApplicationUser_AspNetUsers_UsersId",
                table: "AnimeApplicationUser",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCharacter_AspNetUsers_UsersId",
                table: "ApplicationUserCharacter",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
