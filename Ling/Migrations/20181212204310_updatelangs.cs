using Microsoft.EntityFrameworkCore.Migrations;

namespace Ling.Migrations
{
    public partial class updatelangs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recordings",
                keyColumn: "ID",
                keyValue: 1,
                column: "LanguageID",
                value: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recordings",
                keyColumn: "ID",
                keyValue: 1,
                column: "LanguageID",
                value: 10);
        }
    }
}
