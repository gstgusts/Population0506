using Microsoft.Data.SqlClient;
using Population0506.Data.Models;
using System.Data;
using System.Text;

namespace Population0506.Data.Services
{
    public class DataAccessService
    {
        private readonly SqlConnectionProvider _connectionProvider;
        public DataAccessService(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public IEnumerable<T> GetItems<T>(string query) where T : IReadable<T> {
            return null;
            // return ExecuteSql<T>(query);
        }

        public IEnumerable<Region> GetRegions()
        {
            return ExecuteSql("select * from Region");
        }

        public Region? GetRegionById(int id)
        {
            var parameters = new Dictionary<string, object>
              {
                  { "@id", id}
              };

            var regions = ExecuteSql("select * from Region where Id=@id", parameters);

            return regions.FirstOrDefault();
        }

        public IEnumerable<Region> GetRegionsByName(string name)
        {
            var parameters = new Dictionary<string, object>
              {
                  { "@name", $"%{name}%"}
              };

            return ExecuteSql("select * from Region where Name like @name", parameters);
        }

        public int SaveCity(City city)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                try
                {
                    connection.Open();
                    var cmd = new SqlCommand("spAddCity", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@name", city.Name);
                    cmd.Parameters.AddWithValue("@region_id", city.Region.Id);

                    var outputParameter = new SqlParameter("@new_id", SqlDbType.Int);
                    outputParameter.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(outputParameter);

                    cmd.ExecuteNonQuery();

                    var newId = Convert.ToInt32(cmd.Parameters["@new_id"].Value);

                    connection.Close();

                    return newId;
                }
                catch (Exception)
                {
                    throw;
                }
            }
         }

        public int Add<T>(T entity) where T : IAddableEntity
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                try
                {
                    connection.Open();
                    var cmd = new SqlCommand(entity.StoredProcedureName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    entity.AddParameters(cmd.Parameters);

                    var outputParameter = new SqlParameter("@new_id", SqlDbType.Int);
                    outputParameter.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(outputParameter);

                    cmd.ExecuteNonQuery();

                    var newId = Convert.ToInt32(cmd.Parameters["@new_id"].Value);

                    connection.Close();

                    return newId;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private IEnumerable<Region> ExecuteSql(string sql, Dictionary<string, object>? parameters = null)
        {
            using(var connection = _connectionProvider.GetConnection())
            {
                var cmd = connection.CreateCommand();

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                if (parameters != null && parameters.Any())
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }

                try
                {
                    connection.Open();

                    var reader = cmd.ExecuteReader();

                    var items = new List<Region>();

                    while (reader.Read())
                    {
                        items.Add(new Region(reader.GetInt32("Id"), reader.GetString("Name")));
                    }

                    connection.Close();

                    return items;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        private IEnumerable<T> ExecuteSql<T>(string sql, Dictionary<string, object>? parameters = null) where T : IReadable<T>, new()
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                var cmd = connection.CreateCommand();

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                if (parameters != null && parameters.Any())
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }

                try
                {
                    connection.Open();

                    var reader = cmd.ExecuteReader();

                    var items = new List<T>();

                    while (reader.Read())
                    {
                        //items.Add(new T(reader));
                    }

                    connection.Close();

                    return items;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
