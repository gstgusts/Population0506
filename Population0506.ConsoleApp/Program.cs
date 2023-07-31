using Microsoft.Extensions.Configuration;
using Population0506.Data.Models;
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

            //var regions = dataAccessService.GetRegions();

            //foreach (var region in regions) { 
            //    Console.WriteLine(region.Name);
            //}

            //var region = dataAccessService.GetRegionById(1);

            //var city = new City
            //{
            //    Name = "Riga",
            //    Region = region
            //};

            //var result = dataAccessService.SaveCity(city);

            //Console.WriteLine(result);


            var cities = DataReader.Load();

            foreach (var c in cities)
            {
                var city = new City
                {
                    Name = c.Name,
                    Region = new Region(c.RegionId, "")
                };

                var result= dataAccessService.SaveCity(city);
                Console.WriteLine(result);
            }
        }
    }
}