using PullaShop.Api.Models;

namespace PullaShop.Api.DataAccess.Data;

public interface IProductData
{
    Task<List<ProductModel>> GetAllProducts();
}