using System.Data.SqlClient;

namespace SimpleInventoryManagementSystem.DataAccess
{
    public interface IDbConnectionProvider
    {
        SqlConnection GetSqlConnection();
    }
}
