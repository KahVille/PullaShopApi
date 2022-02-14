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
            return this.database.LoadData<ProductModel, dynamic>(sql, new { });
    }

    public Task<ProductModel> GetProduct(int id)
    {
        var products = new List<ProductModel>();
        string sql = $"SELECT Id, Name, Price, Description FROM AvailableProducts WHERE Id = '{id}'";
        return this.database.LoadDataSingle<ProductModel, dynamic>(sql, new { });
    }

}