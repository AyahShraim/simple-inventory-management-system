using System.Configuration;

namespace SimpleInventoryManagementSystem.Utilities
{
    public static class DBHelper
    {
        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        } 
    }
}
