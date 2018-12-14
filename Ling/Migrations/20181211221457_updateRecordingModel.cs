using Microsoft.EntityFrameworkCore.Migrations;

namespace Ling.Migrations
{
    public partial class updateRecordingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Audio",
                table: "Recordings");

            migrationBuilder.AddColumn<string>(
                name: "AudioURI",
                table: "Recordings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioURI",
                table: "Recordings");

            migrationBuilder.AddColumn<byte>(
                name: "Audio",
                table: "Recordings",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
