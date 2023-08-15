using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminStorePortal.Data;

public partial class CreateEmptyProductsTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Departments");

        migrationBuilder.CreateTable(
            name: "StoreDepartments",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StoreDepartments", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "StoreProducts",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ProductNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                Style = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                Category = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                Size = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StoreProducts", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "StoreDepartments");

        migrationBuilder.DropTable(
            name: "StoreProducts");

        migrationBuilder.CreateTable(
            name: "Departments",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Departments", x => x.Id);
            });
    }
}
