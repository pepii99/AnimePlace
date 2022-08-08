using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimePlace.Migrations
{
    public partial class fixedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeApplicationUser_Animes_AnimesAnimeId",
                table: "AnimeApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCharacter_Characters_CharactersCharacterId",
                table: "ApplicationUserCharacter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeApplicationUser",
                table: "AnimeApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_AnimeApplicationUser_ApplicationUsersId",
                table: "AnimeApplicationUser");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CharactersCharacterId",
                table: "ApplicationUserCharacter",
                newName: "FavoriteCharactersCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserCharacter_CharactersCharacterId",
                table: "ApplicationUserCharacter",
                newName: "IX_ApplicationUserCharacter_FavoriteCharactersCharacterId");

            migrationBuilder.RenameColumn(
                name: "AnimesAnimeId",
                table: "AnimeApplicationUser",
                newName: "FavoriteAnimesAnimeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeApplicationUser",
                table: "AnimeApplicationUser",
                columns: new[] { "ApplicationUsersId", "FavoriteAnimesAnimeId" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeApplicationUser_FavoriteAnimesAnimeId",
                table: "AnimeApplicationUser",
                column: "FavoriteAnimesAnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeApplicationUser_Animes_FavoriteAnimesAnimeId",
                table: "AnimeApplicationUser",
                column: "FavoriteAnimesAnimeId",
                principalTable: "Animes",
                principalColumn: "AnimeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCharacter_Characters_FavoriteCharactersCharacterId",
                table: "ApplicationUserCharacter",
                column: "FavoriteCharactersCharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeApplicationUser_Animes_FavoriteAnimesAnimeId",
                table: "AnimeApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCharacter_Characters_FavoriteCharactersCharacterId",
                table: "ApplicationUserCharacter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeApplicationUser",
                table: "AnimeApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_AnimeApplicationUser_FavoriteAnimesAnimeId",
                table: "AnimeApplicationUser");

            migrationBuilder.RenameColumn(
                name: "FavoriteCharactersCharacterId",
                table: "ApplicationUserCharacter",
                newName: "CharactersCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserCharacter_FavoriteCharactersCharacterId",
                table: "ApplicationUserCharacter",
                newName: "IX_ApplicationUserCharacter_CharactersCharacterId");

            migrationBuilder.RenameColumn(
                name: "FavoriteAnimesAnimeId",
                table: "AnimeApplicationUser",
                newName: "AnimesAnimeId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeApplicationUser",
                table: "AnimeApplicationUser",
                columns: new[] { "AnimesAnimeId", "ApplicationUsersId" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeApplicationUser_ApplicationUsersId",
                table: "AnimeApplicationUser",
                column: "ApplicationUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeApplicationUser_Animes_AnimesAnimeId",
                table: "AnimeApplicationUser",
                column: "AnimesAnimeId",
                principalTable: "Animes",
                principalColumn: "AnimeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCharacter_Characters_CharactersCharacterId",
                table: "ApplicationUserCharacter",
                column: "CharactersCharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
