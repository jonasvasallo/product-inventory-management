using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.InventoryManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addpricevaluecontraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5ea76040-f484-4ae0-8486-e690d8a8c88e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6c93b54b-0ae3-4294-9ae6-4c5280ee5c63"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c815d01-cc82-4adb-957b-850a6a7a2f2b"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5ade0064-50ab-404f-8e95-6a0b9a44bcab"), new DateTime(2025, 10, 2, 14, 54, 20, 425, DateTimeKind.Local).AddTicks(4207), "Keyboard na sira Enter key", "Keyboard", 2250m, 6, new DateTime(2025, 10, 2, 14, 54, 20, 425, DateTimeKind.Local).AddTicks(4210) },
                    { new Guid("c0b5afb1-c316-40db-96d6-55d2f3cf641d"), new DateTime(2025, 10, 2, 14, 54, 20, 425, DateTimeKind.Local).AddTicks(4223), "Pwedeng pang halo sa sinigang", "Headphones", 1600.50m, 24, new DateTime(2025, 10, 2, 14, 54, 20, 425, DateTimeKind.Local).AddTicks(4223) },
                    { new Guid("f3bd4ce2-2731-46b4-91ad-460d14ba6ea1"), new DateTime(2025, 10, 2, 14, 54, 20, 424, DateTimeKind.Local).AddTicks(2331), "Mouse na malibag", "Mouse", 1400.99m, 12, new DateTime(2025, 10, 2, 14, 54, 20, 425, DateTimeKind.Local).AddTicks(3822) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5ade0064-50ab-404f-8e95-6a0b9a44bcab"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c0b5afb1-c316-40db-96d6-55d2f3cf641d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f3bd4ce2-2731-46b4-91ad-460d14ba6ea1"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
    }
}
