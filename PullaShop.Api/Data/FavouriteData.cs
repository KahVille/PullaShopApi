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

    public Task<FavouriteModel> GetFavourites(int id)
    {
        throw new NotImplementedException();
    }

    public Task SaveFavourites(FavouriteModel favourites)
    {
        throw new NotImplementedException();
    }
}