using Microsoft.EntityFrameworkCore.Migrations;

namespace Ling.Migrations
{
    public partial class fixNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 17,
                column: "EnglishName",
                value: "Chinese");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 18,
                column: "EnglishName",
                value: "Chinese");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 17,
                column: "EnglishName",
                value: "\"Chinese");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: 18,
                column: "EnglishName",
                value: "\"Chinese");
        }
    }
}
