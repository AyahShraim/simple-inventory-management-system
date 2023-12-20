using Dapper;
using SimpleInventoryManagementSystem.DataAccess;
using System.Data.SqlClient;

namespace SimpleInventoryManagementSystem.ProductsManagement
{
    public class InventoryRepository
    {
        private readonly IDbConnectionProvider _connectionProvider;
        public InventoryRepository(IDbConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider ?? throw new ArgumentNullException(nameof(connectionProvider));
        }
        public bool AddProduct(Product product)
        {
            if (!IsExistProduct(product.Name))
            {
                using SqlConnection connection = OpenConnection();
                string insertQuery = @"
                                INSERT INTO Product 
                                    (Name, Quantity, Price, Currency) 
                                VALUES 
                                    (@Name, @Quantity, @Price, @Currency)";
                int rowsAffected = connection.Execute(insertQuery, product);
                connection.Close();
                return rowsAffected > 0;
            }
            return false;
        }
        private SqlConnection OpenConnection()
        {
            SqlConnection connection = _connectionProvider.GetSqlConnection();
            connection.Open();
            return connection;
        }
        public bool IsExistProduct(string name)
        {
            using SqlConnection connection = OpenConnection();
            string checkExistenceQuery = @"
                                    SELECT
                                        COUNT(*) 
                                    FROM
                                        Product 
                                    WHERE
                                        Name = @Name";
            var parameters = new { Name = name };
            int existingProductCount = connection.QueryFirstOrDefault<int>(checkExistenceQuery, parameters);
            connection.Close();
            return existingProductCount > 0;
        }
        public bool DeleteProduct(string name)
        {
            using SqlConnection connection = OpenConnection();
            string deleteQuery = @"
                            DELETE FROM Product 
                            WHERE
                                Name = @Name";
            var parameters = new { Name = name };
            int rowsAffected = connection.Execute(deleteQuery, parameters);
            connection.Close();
            return rowsAffected > 0;
            
        }
        public bool UpdateProduct(string oldName, Product updatedProduct)
        {
            if (CouldUpdateProduct(updatedProduct, oldName))
            {
                var parameters = new
                {
                    updatedName = updatedProduct.Name,
                    updatedQuantity = updatedProduct.Quantity,
                    updatedPrice = updatedProduct.Price,
                    updatedCurrency = updatedProduct.Currency.ToString(),
                    productOldName = oldName
                };
                using SqlConnection connection = OpenConnection();
                string updateQuery = @"
                                 UPDATE Product
                                 SET 
                                    Name = @updatedName,
                                    Quantity = @updatedQuantity,
                                    Price = @updatedPrice,
                                    Currency = @updatedCurrency                              
                                 WHERE
                                    Name = @productOldName";
                int rowsAffected = connection.Execute(updateQuery, parameters);
                connection.Close();
                return rowsAffected > 0;
            }
            return false;
        }
        private bool CouldUpdateProduct(Product updatedProduct, string oldName)
        {
            return !IsExistProduct(updatedProduct.Name) || updatedProduct.Name.Equals(oldName);
        }
        public Product? SearchProduct(string name)
        {
            using SqlConnection connection = OpenConnection();
            var parameters = new { Name = name };
            string selectQuery = @"
                            SELECT *
                            FROM
                                Product
                            WHERE
                                Name = @Name";
            Product? product = connection.QueryFirstOrDefault<Product>(selectQuery, parameters);
            connection.Close();
            return product;
        }
        public List<Product> GetAllProducts()
        {
            using SqlConnection connection = OpenConnection();
            string selectQuery = @"
                            SELECT *
                            FROM
                                Product";
            List<Product> products = connection.Query<Product>(selectQuery).ToList();
            connection.Close();
            return products;
        }
    }
}

      


