using Population0506.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population0506.ConsoleApp.Data
{
    public class RegionData : IMapable<Region>
    {
        public string? Name { get; set; }

        public Region Map()
        {
            return new Region(Name);
        }
    }
}
