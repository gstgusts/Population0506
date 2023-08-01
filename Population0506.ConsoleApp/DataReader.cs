using CsvHelper;
using Population0506.ConsoleApp.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population0506.ConsoleApp
{
    public static class DataReader
    {
        public static IEnumerable<CityData> Load() {
            using (var reader = new StreamReader(@"Data/data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<CityData>();

                return records.ToArray();
            }
        }

        public static IEnumerable<T> Load<T>(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<T>();

                return records.ToArray();
            }
        }
    }
}
