using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    public partial class addedfilesandfileimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductImageFile_ProductImageFile_ProductImageFilesId",
                table: "ProductProductImageFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImageFile",
                table: "ProductImageFile");

            migrationBuilder.RenameTable(
                name: "ProductImageFile",
                newName: "Files");

            migrationBuilder.AlterColumn<bool>(
                name: "Showcase",
                table: "Files",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductImageFile_Files_ProductImageFilesId",
                table: "ProductProductImageFile",
                column: "ProductImageFilesId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductImageFile_Files_ProductImageFilesId",
                table: "ProductProductImageFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Files");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "ProductImageFile");

            migrationBuilder.AlterColumn<bool>(
                name: "Showcase",
                table: "ProductImageFile",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImageFile",
                table: "ProductImageFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductImageFile_ProductImageFile_ProductImageFilesId",
                table: "ProductProductImageFile",
                column: "ProductImageFilesId",
                principalTable: "ProductImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
