using Microsoft.EntityFrameworkCore.Migrations;

namespace dms_api.Migrations
{
    public partial class UserCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Divisions_DivisionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DivisionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserCatalogs",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CatalogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCatalogs", x => new { x.UserId, x.CatalogId });
                    table.ForeignKey(
                        name: "FK_UserCatalogs_Users_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCatalogs_Catalogs_UserId",
                        column: x => x.UserId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCatalogs_CatalogId",
                table: "UserCatalogs",
                column: "CatalogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCatalogs");

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DivisionId",
                table: "Users",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Divisions_DivisionId",
                table: "Users",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
