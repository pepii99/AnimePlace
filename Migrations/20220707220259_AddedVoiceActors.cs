using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimePlace.Migrations
{
    public partial class AddedVoiceActors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Voice",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Voice",
                table: "Characters");
        }
    }
}
