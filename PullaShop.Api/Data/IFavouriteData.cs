using PullaShop.Api.Models;

namespace PullaShop.Api.DataAccess.Data;

public interface IFavouriteData
{
    Task<FavouriteModel> GetFavourites(int id);
    Task SaveFavourites(FavouriteModel favourites);
}