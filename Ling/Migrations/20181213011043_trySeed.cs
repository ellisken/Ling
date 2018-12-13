using Microsoft.EntityFrameworkCore.Migrations;

namespace Ling.Migrations
{
    public partial class trySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "German (Germany)", "de-de", "Deutsch (Deutschland)", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Japanese (Japan)", "ja-JP", "日本語（日本）", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName" },
                values: new object[] { "English (Canada)", "en-CA", "English (Canada)" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "English (Great Britain)", "en-GB", "English (Great Britain)", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "English (India)", "en-IN", "English (India)", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "English (United States)", "en-US", "English (United States)", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Spanish (Argentina)", "es-AR", "Español (Argentina)", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Spanish (Spain)", "es-es", "Español (España)", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Spanish (United States)", "es-US", "Español (Estados Unidos)", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Spanish (Mexico)", "es-mx", "Español (México)", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "EnglishName", "OriginalName", "Romanized" },
                values: new object[] { "French (France)", "Français (France)", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "French (Canada)", "fr-ca", "Français (Canada)", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Arabic (United Arab Emirates)", "ar-AE", "العربية (الإمارات)", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Arabic (Saudi Arabia)", "ar-SA", "العربية (السعودية)", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Arabic (Egypt)", "ar-EG", "العربية (مصر)", null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Bengali (Bangladesh)", "bn-BD", "বাংলা (বাংলাদেশ)", null });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[,]
                {
                    { 17, "\"Chinese", "cmn-Hans-CN", "普通话 (中国大陆)", null },
                    { 18, "\"Chinese", "cmn-Hant-TW", "國語 (台灣)", null },
                    { 19, "Hindi (India)", "hi-IN", "हिन्दी (भारत)", null },
                    { 20, "Malay (Malaysia)", "ms-MY", "Bahasa Melayu (Malaysia)", null },
                    { 21, "Swahili (Kenya)", "sw-KE", "Swahili (Kenya)", null },
                    { 22, "Portuguese (Brazil)", "pt-br", "Português (Brasil)", null },
                    { 23, "Portuguese (Portugal)", "pt-pt", "Português (Portugal)", null },
                    { 24, "Polish (Poland)", "pl-PL", "Polski (Polska)", null },
                    { 25, "Russian (Russia)", "ru-ru", "Русский (Россия)", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 25);

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
                columns: new[] { "EnglishName", "ISOCode", "OriginalName" },
                values: new object[] { "English", "en-us", "English" });

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
                columns: new[] { "EnglishName", "OriginalName", "Romanized" },
                values: new object[] { "French", "français", "français" });

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

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[] { "Polish", "pl-pl", "‎Polski", "Polski" });

            migrationBuilder.InsertData(
                table: "Recordings",
                columns: new[] { "ID", "FileName", "LanguageID", "Transcription", "URI" },
                values: new object[,]
                {
                    { 1, "fr-sample.flac", 11, "maître corbeau sur un arbre perché tenait en son bec un fromage", "https://lingblob.blob.core.windows.net/soundrecording/fr-sample.flac" },
                    { 2, "those-internets.wav", 3, "", "https://lingblob.blob.core.windows.net/soundrecording/those-internets.wav" }
                });
        }
    }
}
