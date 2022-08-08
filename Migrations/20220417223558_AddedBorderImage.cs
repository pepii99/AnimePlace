using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimePlace.Migrations
{
    public partial class AddedBorderImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BorderImageUrl",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorderImageUrl",
                table: "Animes");
        }
    }
}
