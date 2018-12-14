using Microsoft.EntityFrameworkCore.Migrations;

namespace Ling.Migrations
{
    public partial class updateURI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recordings",
                keyColumn: "ID",
                keyValue: 1,
                column: "URI",
                value: "https://lingblob.blob.core.windows.net/soundrecording/fr-sample.flac");

            migrationBuilder.UpdateData(
                table: "Recordings",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "LanguageID", "URI" },
                values: new object[] { 3, "https://lingblob.blob.core.windows.net/soundrecording/those-internets.wav" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recordings",
                keyColumn: "ID",
                keyValue: 1,
                column: "URI",
                value: null);

            migrationBuilder.UpdateData(
                table: "Recordings",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "LanguageID", "URI" },
                values: new object[] { 2, null });
        }
    }
}
