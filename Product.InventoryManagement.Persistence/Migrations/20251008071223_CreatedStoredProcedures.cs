using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.InventoryManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreatedStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_get_all_products;");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_get_product_by_id;");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_create_product;");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_update_product;");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_delete_product;");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_get_all_products()
                BEGIN
                    SELECT * FROM products;
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_get_product_by_id(IN p_Id INT)
                BEGIN
	                SELECT * FROM products WHERE Id = p_Id;
                END
            ");


            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_create_product(
	                IN Name VARCHAR(100),
	                IN Description LONGTEXT, 
	                IN Price DECIMAL(10,2), 
	                IN Quantity INT,
                    IN CreatedAt DATETIME,
                    IN UpdatedAt DATETIME,
                    OUT Id INT
                )
                BEGIN
	                
                    SET CreatedAt = CURRENT_TIMESTAMP();
                    SET UpdatedAt = CURRENT_TIMESTAMP();
    
	                INSERT INTO products VALUES (Id, Name, Description, Price, Quantity, CreatedAt, UpdatedAt);

                    SET Id = LAST_INSERT_ID();
                END
            ");


            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_update_product(IN Id int, IN Name VARCHAR(100), IN Description LONGTEXT, IN Price DECIMAL(10,2), IN Quantity INT,IN CreatedAt DATETIME, IN UpdatedAt DATETIME)
                BEGIN
                    SET UpdatedAt = CURRENT_TIMESTAMP();

	                UPDATE products SET products.Name = Name, products.Description = Description, products.Price = Price, products.Quantity = Quantity, products.UpdatedAt = UpdatedAt WHERE products.Id = Id;
                END
            ");


            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_delete_product(IN Id int)
                BEGIN
	                DELETE FROM products WHERE products.Id = Id;
                END
            ");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_get_all_products;");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_get_product_by_id;");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_create_product;");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_update_product;");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_delete_product;");
        }
    }
}
