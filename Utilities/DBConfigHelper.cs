using Microsoft.Extensions.Configuration;

namespace SimpleInventoryManagementSystem.Utilities
{
    public static class DBConfigHelper
    {
        public static IConfiguration GetConfiguration()
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                 .SetBasePath(AppContext.BaseDirectory)
                 .AddJsonFile("appSettings.json")
                 .Build();
                return configuration;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error loading configuration from appSettings.json", ex);
            }
        }
    }
}
