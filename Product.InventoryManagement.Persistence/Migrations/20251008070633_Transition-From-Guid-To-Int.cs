using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.InventoryManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TransitionFromGuidToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 8, 15, 6, 33, 96, DateTimeKind.Local).AddTicks(8987), "Mouse na malibag", "Mouse", 1400.99m, 12, new DateTime(2025, 10, 8, 15, 6, 33, 98, DateTimeKind.Local).AddTicks(538) },
                    { 2, new DateTime(2025, 10, 8, 15, 6, 33, 98, DateTimeKind.Local).AddTicks(910), "Keyboard na sira Enter key", "Keyboard", 2250m, 6, new DateTime(2025, 10, 8, 15, 6, 33, 98, DateTimeKind.Local).AddTicks(912) },
                    { 3, new DateTime(2025, 10, 8, 15, 6, 33, 98, DateTimeKind.Local).AddTicks(915), "Pwedeng pang halo sa sinigang", "Headphones", 1600.50m, 24, new DateTime(2025, 10, 8, 15, 6, 33, 98, DateTimeKind.Local).AddTicks(916) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
