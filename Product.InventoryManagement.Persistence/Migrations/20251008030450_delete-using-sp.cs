using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.InventoryManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deleteusingsp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("3416aa1d-0080-405d-8307-d49c81575a52"), new DateTime(2025, 10, 8, 11, 4, 49, 489, DateTimeKind.Local).AddTicks(9041), "Pwedeng pang halo sa sinigang", "Headphones", 1600.50m, 24, new DateTime(2025, 10, 8, 11, 4, 49, 489, DateTimeKind.Local).AddTicks(9041) },
                    { new Guid("3b1e19fe-7a54-44c3-95e2-bc8ee9e977d9"), new DateTime(2025, 10, 8, 11, 4, 49, 489, DateTimeKind.Local).AddTicks(9034), "Keyboard na sira Enter key", "Keyboard", 2250m, 6, new DateTime(2025, 10, 8, 11, 4, 49, 489, DateTimeKind.Local).AddTicks(9036) },
                    { new Guid("b6aab9b5-7dcb-4507-b09e-51ea4de3502c"), new DateTime(2025, 10, 8, 11, 4, 49, 488, DateTimeKind.Local).AddTicks(6622), "Mouse na malibag", "Mouse", 1400.99m, 12, new DateTime(2025, 10, 8, 11, 4, 49, 489, DateTimeKind.Local).AddTicks(8651) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3416aa1d-0080-405d-8307-d49c81575a52"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b1e19fe-7a54-44c3-95e2-bc8ee9e977d9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b6aab9b5-7dcb-4507-b09e-51ea4de3502c"));

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
    }
}
