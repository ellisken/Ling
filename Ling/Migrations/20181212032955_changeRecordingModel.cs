using Microsoft.EntityFrameworkCore.Migrations;

namespace Ling.Migrations
{
    public partial class changeRecordingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Length",
                table: "Recordings");

            migrationBuilder.RenameColumn(
                name: "AudioURI",
                table: "Recordings",
                newName: "Transcription");

            migrationBuilder.RenameColumn(
                name: "AlternateLanguages",
                table: "Recordings",
                newName: "FileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Transcription",
                table: "Recordings",
                newName: "AudioURI");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Recordings",
                newName: "AlternateLanguages");

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                table: "Recordings",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
