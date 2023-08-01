using Population0506.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population0506.ConsoleApp.Data
{
    public class CityData : IMapable<City>
    {
        public string Name { get; set; }
        public int RegionId { get; set; }

        public City Map()
        {
            return new City
            {
                Name = Name,
                Region = new Region(RegionId, string.Empty)
            };
        }
    }
}
