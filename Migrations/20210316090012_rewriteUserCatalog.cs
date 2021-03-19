using Microsoft.EntityFrameworkCore.Migrations;

namespace dms_api.Migrations
{
    public partial class rewriteUserCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCatalogs_Catalogs_CatalogId",
                table: "UserCatalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCatalogs_Users_UserId",
                table: "UserCatalogs");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCatalogs_Catalogs_CatalogId",
                table: "UserCatalogs",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCatalogs_Users_UserId",
                table: "UserCatalogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCatalogs_Catalogs_CatalogId",
                table: "UserCatalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCatalogs_Users_UserId",
                table: "UserCatalogs");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCatalogs_Catalogs_CatalogId",
                table: "UserCatalogs",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCatalogs_Users_UserId",
                table: "UserCatalogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
