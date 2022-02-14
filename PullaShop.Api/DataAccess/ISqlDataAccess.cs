namespace PullaShop.Api.DataAccess.DatabaseAccess;

public interface ISqlDataAccess
{
        string MyConnectionString { get; set; }
        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task<T> LoadDataSingle<T, U>(string sql, U parameters);
}