using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyService.Migrations
{
    public partial class start1234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceSeeker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookList");
        }
    }
}
