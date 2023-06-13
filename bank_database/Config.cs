using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_database
{
    internal class Config
    {
        private readonly string _dataSource;
        private string connectionString { get; set; }
        internal SqlConnection? connection { get; set; }
        internal Config(string dataSource)
        {

            _dataSource = dataSource;
            connectionString = "Data Source=" + _dataSource + "; Initial Catalog=bank_database;Integrated Security=True;TrustServerCertificate=True";
            connection = new SqlConnection(connectionString);
        }
    }
}
