using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.InventoryManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
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
                    { new Guid("5ea76040-f484-4ae0-8486-e690d8a8c88e"), new DateTime(2025, 10, 2, 14, 45, 37, 3, DateTimeKind.Local).AddTicks(7694), "Keyboard na sira Enter key", "Keyboard", 2250m, 6, new DateTime(2025, 10, 2, 14, 45, 37, 3, DateTimeKind.Local).AddTicks(7697) },
                    { new Guid("6c93b54b-0ae3-4294-9ae6-4c5280ee5c63"), new DateTime(2025, 10, 2, 14, 45, 37, 2, DateTimeKind.Local).AddTicks(5165), "Mouse na malibag", "Mouse", 1400.99m, 12, new DateTime(2025, 10, 2, 14, 45, 37, 3, DateTimeKind.Local).AddTicks(7298) },
                    { new Guid("9c815d01-cc82-4adb-957b-850a6a7a2f2b"), new DateTime(2025, 10, 2, 14, 45, 37, 3, DateTimeKind.Local).AddTicks(7700), "Pwedeng pang halo sa sinigang", "Headphones", 1600.50m, 24, new DateTime(2025, 10, 2, 14, 45, 37, 3, DateTimeKind.Local).AddTicks(7701) }
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
