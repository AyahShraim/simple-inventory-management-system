using Dapper;
using SimpleInventoryManagementSystem.DataAccess;
using System.Data.SqlClient;


namespace SimpleInventoryManagementSystem.ProductsManagement
{
    public class InventoryRepository
    {
        private readonly IDbConnectionProvider _connectionProvider;
        private readonly List<Product> products = new List<Product>();
        public InventoryRepository(IDbConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider ?? throw new ArgumentNullException(nameof(connectionProvider));
        }
        public bool AddProduct(Product product)
        {
            if (!IsExistProduct(product.Name))
            {
                using SqlConnection connection = OpenConnection();
                string insertQuery = "INSERT INTO Product (Name, Quantity, Price, Currency) VALUES (@Name, @Quantity, @Price, @Currency)";
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
            string checkExistenceQuery = "SELECT COUNT(*) FROM Product WHERE Name = @name";
            var parameters = new { Name = name };
            int existingProductCount = connection.QueryFirstOrDefault<int>(checkExistenceQuery, parameters);
            connection.Close();
            return existingProductCount > 0;
        }
        public bool DeleteProduct(string name)
        {
            using SqlConnection connection = OpenConnection();
            string deleteQuery = "DELETE FROM Product WHERE Name = @Name";
            var parameters = new { Name = name };
            int rowsAffected = connection.Execute(deleteQuery, parameters);
            connection.Close();
            return rowsAffected > 0;          
        }
    }
}

      


