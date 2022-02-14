using Xunit;
using System.Collections.Generic;
using PullaShop.Api.Models;
using Moq;
using PullaShop.Api.DataAccess.Data;
using System.Threading.Tasks;

namespace PullaShop.Api.Test;

public class ProductsUnitTest
{

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
        Assert.NotEmpty(actualAllProducts);
        Assert.Single(actualAllProducts);
    }

    [Fact]
    public async Task GetProductReturnsProduct()
    {
        //  // Arrange
        var expectedProduct = new ProductModel { Name = "Test Product" };
        var mock = new Mock<IProductData>();
        mock.Setup(products => products.GetProduct(1)).ReturnsAsync(expectedProduct);
        var productData = mock.Object;

        // // Act
        var actualProduct = await productData.GetProduct(1);

        // // Assert
        Assert.Equal<ProductModel>(expected: expectedProduct, actual: actualProduct);
    }

}