using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper101
{
    public class Dapper101Configuration
    {
        public DataBase DataBase { get; set; }
    }

    public class DataBase
    {
        public string ConnectionString { get; set; }
    }
}
