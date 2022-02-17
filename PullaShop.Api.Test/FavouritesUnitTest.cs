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
        throw new NotImplementedException();
    }

    public async Task AddFavouriteProductsToFavaourites() {

        // Arrange
        var expectedFavourites = GetSampleProducts();
        string sql = "";
        var databaseMock = new Mock<ISqlDataAccess>();
        databaseMock.Setup(dataAccess => dataAccess.MyConnectionString).Returns("Default");
        databaseMock.Setup(dataAccess => dataAccess.SaveData<int>(sql)).ReturnsAsync(1);

        // Act
        var favouritesData = new FavouriteData(databaseMock.Object);
        var actualSavedFavourites = await favouritesData.AddFavouriteProducts(It.IsAny<FavouriteModel>);

        // Assert
        Assert.Equal(expectedFavourites.Count, actualSavedFavourites.Count);

    }

    private List<ProductModel> GetSampleProducts()
    {
        return new List<ProductModel>() {
            new ProductModel { Id= 0, Name = "Test Product" }
        };
    }

}