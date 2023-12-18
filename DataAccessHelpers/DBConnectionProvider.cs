using System.Data.SqlClient;

namespace SimpleInventoryManagementSystem.DataAccess
{
    public class DBConnectionProvider : IDbConnectionProvider
    {
        private readonly string _connectionString;
        public DBConnectionProvider(string connectionString)
        {
            _connectionString = connectionString;
        }
        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
