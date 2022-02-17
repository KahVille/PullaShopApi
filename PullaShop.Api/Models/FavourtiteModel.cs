namespace PullaShop.Api.Models;

public class FavouriteModel
{
    public int Id { get; set; } = default;
    public List<ProductModel> Products { get; set; } = new List<ProductModel>();
}