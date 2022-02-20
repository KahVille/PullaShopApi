using PullaShop.Api.DataAccess.DatabaseAccess;
using PullaShop.Api.Models;

namespace PullaShop.Api.DataAccess.Data;

public class FavouriteData : IFavouriteData
{
    private readonly ISqlDataAccess database;

    public FavouriteData (ISqlDataAccess database)
    {
        this.database = database;
    }

    public async Task<FavouriteModel> GetFavourites(int id)
    {
        var sql = $"SELECT Id, ProductId FROM FavouriteProducts WHERE Id = {id}";
        var favouriteProducts = await this.database.LoadData<ProductModel>(sql);

        return new FavouriteModel() {
            Id = id,
            Products = favouriteProducts ?? new List<ProductModel>()
        };
    }

    public Task SaveFavourites(FavouriteModel favourites)
    {
        var productsToFavourite = favourites.Products;

            string sql = @$"INSERT INTO FavouriteProducts (Id, ProductId) VALUES";
        
        productsToFavourite.ForEach(product => {
                sql += $" ({favourites.Id}, {product.Id}),";
        });
        sql = sql.Substring(0, sql.Length-1);
        sql += ";";

        return this.database.SaveData(sql, favourites);

    }
}