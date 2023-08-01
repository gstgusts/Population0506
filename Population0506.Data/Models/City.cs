using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population0506.Data.Models
{
    public class City : IAddableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Region Region { get; set; }

        public string StoredProcedureName => "spAddCity";

        public void AddParameters(SqlParameterCollection parameterCollection)
        {
            parameterCollection.AddWithValue("@name", Name);
            parameterCollection.AddWithValue("@region_id", Region.Id);
        }
    }
}
