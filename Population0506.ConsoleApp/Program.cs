using Microsoft.Extensions.Configuration;
using Population0506.ConsoleApp.Data;
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

            var sqlConnectionProvider = new SqlConnectionProvider(configuration.GetConnectionString("CarDbConnectionString"));
            var dataAccessService = new DataAccessService(sqlConnectionProvider);

            //var cities = DataReader.Load<CityData>(@"Data/data.csv");

            //var regions = DataReader.Load<RegionData>(@"Data/region_data.csv");

            //var dataWriter = new DataWriter(dataAccessService);

            //dataWriter.Write<CityData, City>(cities);

            //dataWriter.Write<RegionData, Region>(regions);

            var result = dataAccessService.GetItems<CarsPersOwner>("select * from dbo.vCarsPerOwner");

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name}-{item.Surname}-{item.NumberOfCars}");
            }
        }
    }
}