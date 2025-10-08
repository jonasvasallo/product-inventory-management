using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.InventoryManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class createusingsp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("32b28a0d-403b-4c39-a25b-9f1f67a3fe7a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6df4a032-cfb9-4777-8173-e440da1330e9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b532fb9b-cd64-43d8-84be-2245d996c5e6"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2025, 10, 3, 15, 27, 35, 499, DateTimeKind.Local).AddTicks(3641));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2025, 10, 3, 15, 27, 35, 496, DateTimeKind.Local).AddTicks(416));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2025, 10, 3, 15, 27, 35, 499, DateTimeKind.Local).AddTicks(3641),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2025, 10, 3, 15, 27, 35, 496, DateTimeKind.Local).AddTicks(416),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("32b28a0d-403b-4c39-a25b-9f1f67a3fe7a"), new DateTime(2025, 10, 3, 15, 27, 35, 499, DateTimeKind.Local).AddTicks(6915), "Pwedeng pang halo sa sinigang", "Headphones", 1600.50m, 24, new DateTime(2025, 10, 3, 15, 27, 35, 499, DateTimeKind.Local).AddTicks(6916) },
                    { new Guid("6df4a032-cfb9-4777-8173-e440da1330e9"), new DateTime(2025, 10, 3, 15, 27, 35, 499, DateTimeKind.Local).AddTicks(6910), "Keyboard na sira Enter key", "Keyboard", 2250m, 6, new DateTime(2025, 10, 3, 15, 27, 35, 499, DateTimeKind.Local).AddTicks(6912) },
                    { new Guid("b532fb9b-cd64-43d8-84be-2245d996c5e6"), new DateTime(2025, 10, 3, 15, 27, 35, 499, DateTimeKind.Local).AddTicks(6391), "Mouse na malibag", "Mouse", 1400.99m, 12, new DateTime(2025, 10, 3, 15, 27, 35, 499, DateTimeKind.Local).AddTicks(6656) }
                });
        }
    }
}
