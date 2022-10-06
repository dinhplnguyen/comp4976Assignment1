using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeedIdentity.Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resolution",
                columns: table => new
                {
                    ResolutionId = table.Column<string>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<string>(type: "TEXT", nullable: true),
                    Abstract = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true, defaultValue: 0),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resolution", x => x.ResolutionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resolution");
        }
    }
}
