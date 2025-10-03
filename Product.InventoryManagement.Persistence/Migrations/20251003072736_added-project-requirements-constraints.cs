using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.InventoryManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedprojectrequirementsconstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3278c754-bbc4-45f5-9a62-b22705aba1c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3c3ef91e-37db-49d2-948a-04166faab60a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("822a190d-0942-4af3-9c21-376114d90cf5"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2025, 10, 3, 15, 27, 35, 499, DateTimeKind.Local).AddTicks(3641),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
                    { new Guid("3278c754-bbc4-45f5-9a62-b22705aba1c9"), new DateTime(2025, 10, 3, 14, 20, 1, 827, DateTimeKind.Local).AddTicks(8556), "Keyboard na sira Enter key", "Keyboard", 2250m, 6, new DateTime(2025, 10, 3, 14, 20, 1, 827, DateTimeKind.Local).AddTicks(8559) },
                    { new Guid("3c3ef91e-37db-49d2-948a-04166faab60a"), new DateTime(2025, 10, 3, 14, 20, 1, 826, DateTimeKind.Local).AddTicks(6445), "Mouse na malibag", "Mouse", 1400.99m, 12, new DateTime(2025, 10, 3, 14, 20, 1, 827, DateTimeKind.Local).AddTicks(8129) },
                    { new Guid("822a190d-0942-4af3-9c21-376114d90cf5"), new DateTime(2025, 10, 3, 14, 20, 1, 827, DateTimeKind.Local).AddTicks(8564), "Pwedeng pang halo sa sinigang", "Headphones", 1600.50m, 24, new DateTime(2025, 10, 3, 14, 20, 1, 827, DateTimeKind.Local).AddTicks(8565) }
                });
        }
    }
}
