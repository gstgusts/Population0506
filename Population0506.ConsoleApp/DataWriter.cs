using Population0506.ConsoleApp.Data;
using Population0506.Data.Models;
using Population0506.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population0506.ConsoleApp
{
    public class DataWriter
    {
        private DataAccessService _dataAccessService;
        public DataWriter(DataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        public void Write(IEnumerable<CityData> cities)
        {
            foreach (var c in cities)
            {
                var city = new City
                {
                    Name = c.Name,
                    Region = new Region(c.RegionId, "")
                };

                var result = _dataAccessService.SaveCity(city);
                Console.WriteLine(result);
            }
        }

        public void Write<T, K>(IEnumerable<T> items) where T : IMapable<K>
        {
            foreach (var c in items)
            {
                var entityToSave = c.Map();

                Console.WriteLine(entityToSave);

                //var result = _dataAccessService.SaveCity(city);
                //Console.WriteLine(result);
            }
        }
    }
}
