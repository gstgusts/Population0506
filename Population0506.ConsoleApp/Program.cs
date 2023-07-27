using Microsoft.Extensions.Configuration;
using Population0506.Data.Services;

namespace Population0506.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            var sqlConnectionProvider = new SqlConnectionProvider(configuration.GetConnectionString("PopulationDbConnectionString"));
            var dataAccessService = new DataAccessService(sqlConnectionProvider);

            var regions = dataAccessService.GetRegions();

            foreach (var region in regions) { 
                Console.WriteLine(region.Name);
            }
        }
    }
}