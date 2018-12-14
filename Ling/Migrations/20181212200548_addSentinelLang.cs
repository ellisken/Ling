using Microsoft.EntityFrameworkCore.Migrations;

namespace Ling.Migrations
{
    public partial class addSentinelLang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "No Language Set", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Mandarin", "cmn-hans-cn", "官话", "Guānhuà" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "English", "en-us", "English", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Hindi", "hi-in", "Hindī", "हिन्दी " });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Spanish (Spain)", "es-es", "Español (España)", "español" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Spanish", "es-mx", "Español", "español, castellano" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Arabic (Egypt)", "ar-eg", "العربية", "al-ʻarabiyyah" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Portuguese (Brazil)", "pt-br", "Português (Brasil)", "português" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Russian", "ru-ru", "русский язык", "russkiy yazyk" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Bengali", "bn-in", "বাংলা", "Bangla" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "French", "fr-fr", "français", "français" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Japanese", "ja-jp", "日本語", "Nihongo" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Malay", "ms-my", "بهاس ملايو‎", "Bahasa Melayu" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Swahili", "sw-ke", "Kiswahili‎", "Kiswahili" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "German", "de-de", "Deutsch‎", "Deutsch" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { 16, "Polish", "pl-pl", "‎Polski", "Polski" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Mandarin", "cmn-hans-cn", "官话", "Guānhuà" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "English", "en-us", "English", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Hindi", "hi-in", "Hindī", "हिन्दी " });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Spanish (Spain)", "es-es", "Español (España)", "español" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Spanish", "es-mx", "Español", "español, castellano" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Arabic (Egypt)", "ar-eg", "العربية", "al-ʻarabiyyah" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Portuguese (Brazil)", "pt-br", "Português (Brasil)", "português" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Russian", "ru-ru", "русский язык", "russkiy yazyk" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Bengali", "bn-in", "বাংলা", "Bangla" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "French", "fr-fr", "français", "français" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Japanese", "ja-jp", "日本語", "Nihongo" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Malay", "ms-my", "بهاس ملايو‎", "Bahasa Melayu" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Swahili", "sw-ke", "Kiswahili‎", "Kiswahili" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "German", "de-de", "Deutsch‎", "Deutsch" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Polish", "pl-pl", "‎Polski", "Polski" });
        }
    }
}
