using Microsoft.Data.SqlClient;
//using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Ordering.Infrastructure.Data
{
    public class DbConnector
    {
        private readonly IConfiguration _configuration;

        public DbConnector(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string _connectionString = _configuration.GetConnectionString("DefaultConnection");

            return new SqlConnection(_connectionString);
        }
    }
}
