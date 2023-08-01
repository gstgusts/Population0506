using Microsoft.Data.SqlClient;

namespace Population0506.Data.Models
{
    public class Region : IAddableEntity
    {

        public Region(string name) { 
            Name = name;
        }

        public Region(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string StoredProcedureName => "spAddRegion";

        public void AddParameters(SqlParameterCollection parameterCollection)
        {
            parameterCollection.AddWithValue("@name", Name);
        }
    }
}
