using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyService.Migrations
{
    public partial class start12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Approve",
                table: "RegisterUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approve",
                table: "RegisterUser");
        }
    }
}
