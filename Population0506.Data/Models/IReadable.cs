using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population0506.Data.Models
{
    public interface IReadable<T>
    {
        T Create(SqlDataReader reader);
    }
}
