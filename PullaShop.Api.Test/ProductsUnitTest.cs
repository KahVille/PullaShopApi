using Xunit;
using System.Collections.Generic;
using PullaShop.Api.Models;
using Moq;
using PullaShop.Api.DataAccess.Data;
using System.Threading.Tasks;
using PullaShop.Api.DataAccess.DatabaseAccess;

namespace PullaShop.Api.Test;

public class ProductsUnitTest
{

    // Note Tests not respond to actual implementations yet with mocking

    [Fact]
    public async Task GetAllProductsReturnsAllProducts()
    {

        // Arrange
        string sql = "SELECT Id, Name, Price, Description FROM AvailableProducts";
        
        var databaseMock = new Mock<ISqlDataAccess>();
        databaseMock.Setup(dataAccess => dataAccess.MyConnectionString).Returns("Default");
        databaseMock.Setup(dataAccess => dataAccess.LoadData<ProductModel>(sql)).ReturnsAsync(GetSampleProducts());
        
        var productData = new ProductData(databaseMock.Object);

        // Act
        var actualAllProducts = await productData.GetAllProducts();

        // Assert
        Assert.NotEmpty(actualAllProducts);
        Assert.Single(actualAllProducts);
    }

    [Fact]
    public async Task GetProductReturnsProduct()
    {
        // Arrange
        var expectedProduct = new ProductModel { Id= 0, Name = "Test Product" };
        var mock = new Mock<IProductData>();
        mock.Setup(products => products.GetProduct(1)).ReturnsAsync(expectedProduct);
        var productData = mock.Object;

        // Act
        var actualProduct = await productData.GetProduct(1);

        // Assert
        Assert.Equal<ProductModel>(expected: expectedProduct, actual: actualProduct);
    }

    private List<ProductModel> GetSampleProducts()
    {
        return new List<ProductModel>() {
            new ProductModel { Id= 0, Name = "Test Product" }
        };
    }

}