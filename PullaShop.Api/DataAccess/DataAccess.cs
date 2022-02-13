using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace PullaShop.Api.DataAccess.DatabaseAccess;

public class DataAccess : IDataAccess 
{
        private readonly IConfiguration _config;

        public string MyConnectionString { get; set; } = "Default";

        public DataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {

            string connectionString = _config.GetConnectionString(MyConnectionString);

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }
}