using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ling.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnglishName = table.Column<string>(nullable: true),
                    OriginalName = table.Column<string>(nullable: true),
                    Romanized = table.Column<string>(nullable: true),
                    ISOCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Recordings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageID = table.Column<int>(nullable: false),
                    Audio = table.Column<byte>(nullable: false),
                    AlternateLanguages = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recordings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recordings_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "EnglishName", "ISOCode", "OriginalName", "Romanized" },
                values: new object[,]
                {
                    { 1, "Mandarin", "cmn-Hans-CN", "官话", "Guānhuà" },
                    { 2, "English", "en-US", "English", null },
                    { 3, "Hindi", "hi-IN", "Hindī", "हिन्दी " },
                    { 4, "Spanish (Spain)", "es-ES", "Español (España)", "español" },
                    { 5, "Spanish", "es-MX", "Español", "español, castellano" },
                    { 6, "Arabic (Egypt)", "ar-EG", "العربية", "al-ʻarabiyyah" },
                    { 7, "Portuguese (Brazil)", "pt-BR", "Português (Brasil)", "português" },
                    { 8, "Russian", "ru-RU", "русский язык", "russkiy yazyk" },
                    { 9, "Bengali", "bn-IN", "বাংলা", "Bangla" },
                    { 10, "French", "fr-FR", "français", "français" },
                    { 11, "Japanese", "ja-JP", "日本語", "Nihongo" },
                    { 12, "Malay", "ms-MY", "بهاس ملايو‎", "Bahasa Melayu" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recordings_LanguageID",
                table: "Recordings",
                column: "LanguageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recordings");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
