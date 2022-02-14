using Xunit;
using System.Collections.Generic;
using PullaShop.Api.Models;
using Moq;
using PullaShop.Api.DataAccess.Data;
using System.Threading.Tasks;

namespace PullaShop.Api.Test;

public class ProductsUnitTest
{
    //Todo: Investigate: Skipped but why?
     [Fact]
    public async Task GetAllProductsReturnsAllProducts()
    {

        // Arrange
        var initialProduct = new ProductModel { Name = "Test Product" };
        var mock = new Mock<IProductData>();
        mock.Setup(products => products.GetAllProducts()).ReturnsAsync(new List<ProductModel>() {initialProduct});
        var productData = mock.Object;

        // Act
        var actualAllProducts = await productData.GetAllProducts();

        // Assert
        Assert.Single(actualAllProducts);
    }
}