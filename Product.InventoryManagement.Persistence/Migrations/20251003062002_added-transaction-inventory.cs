using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.InventoryManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedtransactioninventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UnitsAdded = table.Column<int>(type: "int", nullable: false),
                    UnitsRemoved = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3278c754-bbc4-45f5-9a62-b22705aba1c9"), new DateTime(2025, 10, 3, 14, 20, 1, 827, DateTimeKind.Local).AddTicks(8556), "Keyboard na sira Enter key", "Keyboard", 2250m, 6, new DateTime(2025, 10, 3, 14, 20, 1, 827, DateTimeKind.Local).AddTicks(8559) },
                    { new Guid("3c3ef91e-37db-49d2-948a-04166faab60a"), new DateTime(2025, 10, 3, 14, 20, 1, 826, DateTimeKind.Local).AddTicks(6445), "Mouse na malibag", "Mouse", 1400.99m, 12, new DateTime(2025, 10, 3, 14, 20, 1, 827, DateTimeKind.Local).AddTicks(8129) },
                    { new Guid("822a190d-0942-4af3-9c21-376114d90cf5"), new DateTime(2025, 10, 3, 14, 20, 1, 827, DateTimeKind.Local).AddTicks(8564), "Pwedeng pang halo sa sinigang", "Headphones", 1600.50m, 24, new DateTime(2025, 10, 3, 14, 20, 1, 827, DateTimeKind.Local).AddTicks(8565) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProductId",
                table: "Transactions",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

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
    }
}
