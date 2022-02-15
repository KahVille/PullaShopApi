using PullaShop.Api.DataAccess.DatabaseAccess;
using PullaShop.Api.Models;

namespace PullaShop.Api.DataAccess.Data;

public class ProductData : IProductData
{
    private readonly ISqlDataAccess database;

    public ProductData (ISqlDataAccess database)
    {
        this.database = database;
    }

    public Task<List<ProductModel>> GetAllProducts()
    {
        string sql = "SELECT Id, Name, Price, Description FROM AvailableProducts";
        return this.database.LoadData<ProductModel>(sql);
    }

    public Task<ProductModel> GetProduct(int id)
    {
        string sql = $"SELECT Id, Name, Price, Description FROM AvailableProducts WHERE Id = '{id}'";
        return this.database.LoadDataSingle<ProductModel>(sql);
    }

}