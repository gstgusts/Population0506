using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population0506.Data.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Region Region { get; set; }
    }
}
