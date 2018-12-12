using Microsoft.EntityFrameworkCore.Migrations;

namespace Ling.Migrations
{
    public partial class changeRecordingModelProduction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 1,
                column: "ISOCode",
                value: "cmn-hans-cn");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 2,
                column: "ISOCode",
                value: "en-us");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 3,
                column: "ISOCode",
                value: "hi-in");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 4,
                column: "ISOCode",
                value: "es-es");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 5,
                column: "ISOCode",
                value: "es-mx");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 6,
                column: "ISOCode",
                value: "ar-eg");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 7,
                column: "ISOCode",
                value: "pt-br");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 8,
                column: "ISOCode",
                value: "ru-ru");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 9,
                column: "ISOCode",
                value: "bn-in");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 10,
                column: "ISOCode",
                value: "fr-fr");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 11,
                column: "ISOCode",
                value: "ja-jp");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 12,
                column: "ISOCode",
                value: "ms-my");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[,]
                {
                    { 13, "Swahili", "sw-ke", "Kiswahili‎", "Kiswahili" },
                    { 14, "German", "de-de", "Deutsch‎", "Deutsch" },
                    { 15, "Polish", "pl-pl", "‎Polski", "Polski" }
                });

            migrationBuilder.InsertData(
                table: "Recordings",
                columns: new[] { "ID", "FileName", "LanguageID", "Transcription" },
                values: new object[,]
                {
                    { 1, "fr-sample.flac", 10, "maître corbeau sur un arbre perché tenait en son bec un fromage" },
                    { 2, "those-internets.wav", 2, "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Recordings",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recordings",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 1,
                column: "ISOCode",
                value: "cmn-Hans-CN");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 2,
                column: "ISOCode",
                value: "en-US");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 3,
                column: "ISOCode",
                value: "hi-IN");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 4,
                column: "ISOCode",
                value: "es-ES");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 5,
                column: "ISOCode",
                value: "es-MX");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 6,
                column: "ISOCode",
                value: "ar-EG");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 7,
                column: "ISOCode",
                value: "pt-BR");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 8,
                column: "ISOCode",
                value: "ru-RU");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 9,
                column: "ISOCode",
                value: "bn-IN");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 10,
                column: "ISOCode",
                value: "fr-FR");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 11,
                column: "ISOCode",
                value: "ja-JP");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 12,
                column: "ISOCode",
                value: "ms-MY");
        }
    }
}
