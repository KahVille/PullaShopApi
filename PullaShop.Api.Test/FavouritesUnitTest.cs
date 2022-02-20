using Xunit;
using System.Collections.Generic;
using PullaShop.Api.Models;
using Moq;
using PullaShop.Api.DataAccess.Data;
using System.Threading.Tasks;
using PullaShop.Api.DataAccess.DatabaseAccess;
using System.Linq;
using System.Text.Json;
using System;

namespace PullaShop.Api.Test;

public class FavouritesUnitTest
{

    [Fact]
    public async Task GetAllFavouriteProductsReturnsAllFavouriteProducts()
    {
        // Arrange
        var expectedFavourites = new FavouriteModel();
        expectedFavourites.Id = 1;
        expectedFavourites.Products = GetSampleProducts();
        string sql = $"SELECT Id, ProductId FROM FavouriteProducts WHERE Id = {1}";
        var databaseMock = new Mock<ISqlDataAccess>();
        databaseMock.Setup(dataAccess => dataAccess.MyConnectionString).Returns("Default");
        databaseMock.Setup(dataAccess => dataAccess.LoadData<ProductModel>(sql)).ReturnsAsync(GetSampleProducts());


        // Act
        var favouritesData = new FavouriteData(databaseMock.Object);
        await favouritesData.SaveFavourites(expectedFavourites);
        var actualFavourites = await favouritesData.GetFavourites(expectedFavourites.Id);

        // Assert
        Assert.Equal(expectedFavourites.Id, actualFavourites.Id);
        Assert.Equal(expectedFavourites.Products.Count, actualFavourites.Products.Count);

    }

    public async Task AddFavouriteProductsToFavaourites() {

        // Arrange
        var expectedFavourites = new FavouriteModel();
        expectedFavourites.Id = 1;
        expectedFavourites.Products = GetSampleProducts();
        string sql = "";
        var databaseMock = new Mock<ISqlDataAccess>();
        databaseMock.Setup(dataAccess => dataAccess.MyConnectionString).Returns("Default");
        databaseMock.Setup(dataAccess => dataAccess.SaveData(sql, new {})).Returns(Task.FromResult(1));
        databaseMock.Setup(dataAccess => dataAccess.LoadDataSingle<FavouriteModel>(sql)).ReturnsAsync(expectedFavourites);


        // Act
        var favouritesData = new FavouriteData(databaseMock.Object);
        await favouritesData.SaveFavourites(expectedFavourites);
        var actualSavedFavourites = await favouritesData.GetFavourites(expectedFavourites.Id);

        // Assert
        Assert.Equal(expectedFavourites, actualSavedFavourites);

    }

    private List<ProductModel> GetSampleProducts()
    {
        return new List<ProductModel>() {
            new ProductModel { Id= 0, Name = "Test Product" }
        };
    }

}