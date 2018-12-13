using Microsoft.EntityFrameworkCore.Migrations;

namespace Ling.Migrations
{
    public partial class seedRec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recordings",
                columns: new[] { "ID", "FileName", "LanguageID", "Transcription", "URI" },
                values: new object[] { 1, "fr-sample.flac", 11, "maître corbeau sur un arbre perché tenait en son bec un fromage", "https://lingblob.blob.core.windows.net/soundrecording/fr-sample.flac" });

            migrationBuilder.InsertData(
                table: "Recordings",
                columns: new[] { "ID", "FileName", "LanguageID", "Transcription", "URI" },
                values: new object[] { 2, "those-internets.wav", 6, "", "https://lingblob.blob.core.windows.net/soundrecording/those-internets.wav" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recordings",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recordings",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
