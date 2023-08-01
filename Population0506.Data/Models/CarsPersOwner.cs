using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population0506.Data.Models
{
    public class CarsPersOwner : IReadable<CarsPersOwner>
    {
        public CarsPersOwner() { }

        public string? Name { get; set; }
        public string? Surname { get; set; }

        public int NumberOfCars { get; set; }

        public CarsPersOwner Create(SqlDataReader reader)
        {
            return new CarsPersOwner
            {
                Name = reader.GetString("Name"),
                Surname = reader.GetString("Surname"),
                NumberOfCars = reader.GetInt32("NumberOfCars")
            };
        }
    }
}
