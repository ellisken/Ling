using Microsoft.EntityFrameworkCore.Migrations;

namespace Ling.Migrations
{
    public partial class addURI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URI",
                table: "Recordings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URI",
                table: "Recordings");
        }
    }
}
