using Microsoft.EntityFrameworkCore.Migrations;

namespace dms_api.Migrations
{
    public partial class modifyFileDirectories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileDirectories_Catalogs_CatalogId",
                table: "FileDirectories");

            migrationBuilder.AlterColumn<int>(
                name: "CatalogId",
                table: "FileDirectories",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FileDirectories_Catalogs_CatalogId",
                table: "FileDirectories",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileDirectories_Catalogs_CatalogId",
                table: "FileDirectories");

            migrationBuilder.AlterColumn<int>(
                name: "CatalogId",
                table: "FileDirectories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FileDirectories_Catalogs_CatalogId",
                table: "FileDirectories",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
