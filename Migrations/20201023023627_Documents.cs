using Microsoft.EntityFrameworkCore.Migrations;

namespace dms_api.Migrations
{
    public partial class Documents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileDirectoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_FileDirectories_FileDirectoryId",
                        column: x => x.FileDirectoryId,
                        principalTable: "FileDirectories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FileDirectoryId",
                table: "Documents",
                column: "FileDirectoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
