using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Persistence.Migrations
{
    public class createStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_get_all_products;");
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_get_all_products()
                BEGIN
                    SELECT * FROM products;
                END;
            ");

            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_get_product_by_id;");
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_get_product_by_id(IN p_Id CHAR(36))
                BEGIN
	                SELECT * FROM products WHERE Id = p_Id;
                END
            ");

            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_create_product;");
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_create_product(
	                IN Id CHAR(36),
	                IN Name VARCHAR(100),
	                IN Description LONGTEXT, 
	                IN Price DECIMAL(10,2), 
	                IN Quantity INT,
	                IN CreatedAt DATETIME,
	                IN UpdatedAt DATETIME
                )
                BEGIN
	                INSERT INTO products VALUES (Id, Name, Description, Price, Quantity, CreatedAt, UpdatedAt);
                END
            ");

            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_update_product;");
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_update_product(IN Id CHAR(36), IN Name VARCHAR(100), IN Description LONGTEXT, IN Price DECIMAL(10,2), IN Quantity INT,IN CreatedAt DATETIME, IN UpdatedAt DATETIME)
                BEGIN
	                UPDATE products SET products.Name = Name, products.Description = Description, products.Price = Price, products.Quantity = Quantity, products.UpdatedAt = UpdatedAt WHERE products.Id = Id;
                END
            ");

            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_delete_product;");
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_delete_product(IN Id CHAR(36))
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
