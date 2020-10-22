using Microsoft.EntityFrameworkCore.Migrations;

namespace dms_api.Migrations
{
    public partial class fileDirectory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileDirectories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RootDirectoryId = table.Column<int>(nullable: true),
                    CatalogId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDirectories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileDirectories_Catalogs_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileDirectories_FileDirectories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FileDirectories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileDirectories_RootDirectories_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalTable: "RootDirectories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileDirectories_CatalogId",
                table: "FileDirectories",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_FileDirectories_ParentId",
                table: "FileDirectories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_FileDirectories_RootDirectoryId",
                table: "FileDirectories",
                column: "RootDirectoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileDirectories");
        }
    }
}
