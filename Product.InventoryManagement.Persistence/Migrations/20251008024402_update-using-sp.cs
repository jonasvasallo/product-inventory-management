using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.InventoryManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateusingsp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("af746c68-72aa-4666-9be5-1bca25e04ee1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cf8b332e-f622-43e9-ba2e-756cf01dadfc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e8b37190-5a92-414e-bb40-10b0686c8e55"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8908a119-ebad-4352-9d27-fff680ae1d1a"), new DateTime(2025, 10, 8, 10, 44, 1, 510, DateTimeKind.Local).AddTicks(5865), "Pwedeng pang halo sa sinigang", "Headphones", 1600.50m, 24, new DateTime(2025, 10, 8, 10, 44, 1, 510, DateTimeKind.Local).AddTicks(5866) },
                    { new Guid("a0678d92-cd8c-4659-af47-b15146dbfd13"), new DateTime(2025, 10, 8, 10, 44, 1, 509, DateTimeKind.Local).AddTicks(3987), "Mouse na malibag", "Mouse", 1400.99m, 12, new DateTime(2025, 10, 8, 10, 44, 1, 510, DateTimeKind.Local).AddTicks(5465) },
                    { new Guid("d48f2991-c794-4048-b875-146d6364de77"), new DateTime(2025, 10, 8, 10, 44, 1, 510, DateTimeKind.Local).AddTicks(5858), "Keyboard na sira Enter key", "Keyboard", 2250m, 6, new DateTime(2025, 10, 8, 10, 44, 1, 510, DateTimeKind.Local).AddTicks(5861) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8908a119-ebad-4352-9d27-fff680ae1d1a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a0678d92-cd8c-4659-af47-b15146dbfd13"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d48f2991-c794-4048-b875-146d6364de77"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("af746c68-72aa-4666-9be5-1bca25e04ee1"), new DateTime(2025, 10, 8, 10, 28, 20, 724, DateTimeKind.Local).AddTicks(2461), "Pwedeng pang halo sa sinigang", "Headphones", 1600.50m, 24, new DateTime(2025, 10, 8, 10, 28, 20, 724, DateTimeKind.Local).AddTicks(2462) },
                    { new Guid("cf8b332e-f622-43e9-ba2e-756cf01dadfc"), new DateTime(2025, 10, 8, 10, 28, 20, 723, DateTimeKind.Local).AddTicks(675), "Mouse na malibag", "Mouse", 1400.99m, 12, new DateTime(2025, 10, 8, 10, 28, 20, 724, DateTimeKind.Local).AddTicks(2067) },
                    { new Guid("e8b37190-5a92-414e-bb40-10b0686c8e55"), new DateTime(2025, 10, 8, 10, 28, 20, 724, DateTimeKind.Local).AddTicks(2455), "Keyboard na sira Enter key", "Keyboard", 2250m, 6, new DateTime(2025, 10, 8, 10, 28, 20, 724, DateTimeKind.Local).AddTicks(2457) }
                });
        }
    }
}
