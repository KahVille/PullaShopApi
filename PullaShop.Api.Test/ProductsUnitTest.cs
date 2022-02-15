using Xunit;
using System.Collections.Generic;
using PullaShop.Api.Models;
using Moq;
using PullaShop.Api.DataAccess.Data;
using System.Threading.Tasks;
using PullaShop.Api.DataAccess.DatabaseAccess;
using System.Linq;
using System.Text.Json;

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
        var expectedProduct = GetSampleProducts().First();
        int id = 0;
        string sql = $"SELECT Id, Name, Price, Description FROM AvailableProducts WHERE Id = '{id}'";
        var databaseMock = new Mock<ISqlDataAccess>();
        databaseMock.Setup(dataAccess => dataAccess.MyConnectionString).Returns("Default");
        databaseMock.Setup(dataAccess => dataAccess.LoadDataSingle<ProductModel>(sql)).ReturnsAsync(GetSampleProducts().First());
        
        var productData = new ProductData(databaseMock.Object);

        // Act
        var actualProduct = await productData.GetProduct(id);

        // Assert
        var expectedAsJson = JsonSerializer.Serialize(expectedProduct);
        var actualAsJson =JsonSerializer.Serialize(actualProduct);
        Assert.Equal(expectedAsJson, actualAsJson);
    }

    private List<ProductModel> GetSampleProducts()
    {
        return new List<ProductModel>() {
            new ProductModel { Id= 0, Name = "Test Product" }
        };
    }

}