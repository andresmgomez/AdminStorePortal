using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminStorePortal.Data
{
    public partial class AddForeignKeyItemsToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStyles",
                table: "ProductStyles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMaterials",
                table: "ProductMaterials");

            migrationBuilder.RenameTable(
                name: "ProductStyles",
                newName: "ClothingStyle");

            migrationBuilder.RenameTable(
                name: "ProductMaterials",
                newName: "ClothingMaterial");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "LineProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StyleId",
                table: "LineProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Style",
                table: "ClothingStyle",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "ClothingMaterial",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothingStyle",
                table: "ClothingStyle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothingMaterial",
                table: "ClothingMaterial",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LineProducts_MaterialId",
                table: "LineProducts",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_LineProducts_StyleId",
                table: "LineProducts",
                column: "StyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineProducts_ClothingMaterial_MaterialId",
                table: "LineProducts",
                column: "MaterialId",
                principalTable: "ClothingMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineProducts_ClothingStyle_StyleId",
                table: "LineProducts",
                column: "StyleId",
                principalTable: "ClothingStyle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineProducts_ClothingMaterial_MaterialId",
                table: "LineProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_LineProducts_ClothingStyle_StyleId",
                table: "LineProducts");

            migrationBuilder.DropIndex(
                name: "IX_LineProducts_MaterialId",
                table: "LineProducts");

            migrationBuilder.DropIndex(
                name: "IX_LineProducts_StyleId",
                table: "LineProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothingStyle",
                table: "ClothingStyle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothingMaterial",
                table: "ClothingMaterial");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "LineProducts");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "LineProducts");

            migrationBuilder.RenameTable(
                name: "ClothingStyle",
                newName: "ProductStyles");

            migrationBuilder.RenameTable(
                name: "ClothingMaterial",
                newName: "ProductMaterials");

            migrationBuilder.AlterColumn<string>(
                name: "Style",
                table: "ProductStyles",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "ProductMaterials",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStyles",
                table: "ProductStyles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMaterials",
                table: "ProductMaterials",
                column: "Id");
        }
    }
}
