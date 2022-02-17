using PullaShop.Api.Models;

namespace PullaShop.Api.DataAccess.Data;

public interface IFavouriteData
{
    Task<FavouriteModel> GetFavourites();
    Task SaveFavourites(FavouriteModel favourites);
}