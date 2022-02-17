using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace PullaShop.Api.DataAccess.DatabaseAccess;

public class SqlDataAccess : ISqlDataAccess
{
        private readonly IConfiguration _config;

        public string MyConnectionString { get; set; } = "Default";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T>(string sql)
        {

            string connectionString = _config.GetConnectionString(MyConnectionString);

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql);
                return data.ToList();
            }
        }

        public async Task<T> LoadDataSingle<T>(string sql)
        {

            string connectionString = _config.GetConnectionString(MyConnectionString);

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var data = await connection.QueryFirstOrDefaultAsync<T>(sql);
                return data;
            }
        }

        public async Task SaveData<T>(string sql)
        {
            string connectionString = _config.GetConnectionString(MyConnectionString);

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql);
            }
        }
}