using Microsoft.EntityFrameworkCore.Migrations;

namespace Ling.Migrations
{
    public partial class seedRecAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recordings",
                columns: new[] { "ID", "FileName", "LanguageID", "Transcription", "URI" },
                values: new object[] { 3, "sod.wav", 4, "you silly sod", "https://lingblob.blob.core.windows.net/soundrecording/sod.wav" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recordings",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
