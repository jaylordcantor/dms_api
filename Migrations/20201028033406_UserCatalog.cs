using Microsoft.EntityFrameworkCore.Migrations;

namespace dms_api.Migrations
{
    public partial class UserCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCatalog",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CatalogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCatalog", x => new { x.UserId, x.CatalogId });
                    table.ForeignKey(
                        name: "FK_UserCatalog_Users_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCatalog_Catalogs_UserId",
                        column: x => x.UserId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCatalog_CatalogId",
                table: "UserCatalog",
                column: "CatalogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCatalog");
        }
    }
}
