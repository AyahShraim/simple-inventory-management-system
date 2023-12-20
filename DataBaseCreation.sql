IF NOT EXISTS (
	SELECT
		*
    FROM
		sys.databases
    WHERE
		NAME = 'InventoryDB'
)
BEGIN
    CREATE DATABASE InventoryDB
END;
go

USE inventorydb;

IF NOT EXISTS (
	SELECT
		*
    FROM
		information_schema.tables
    WHERE
		table_name = 'Product'
)
BEGIN
    CREATE TABLE product (
        id       INT PRIMARY KEY IDENTITY(1, 1),
        [name]   VARCHAR(255) NOT NULL,
        quantity INT NOT NULL,
        price    DECIMAL NOT NULL,
        currency VARCHAR(5) NOT NULL
    );
END;

CREATE INDEX ix_product_name ON product([name]); 