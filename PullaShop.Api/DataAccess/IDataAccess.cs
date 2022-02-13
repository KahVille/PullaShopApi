namespace PullaShop.Api.DataAccess.DatabaseAccess;

public interface IDataAccess
{
        string MyConnectionString { get; set; }
        Task<List<T>> LoadData<T, U>(string sql, U parameters);
}