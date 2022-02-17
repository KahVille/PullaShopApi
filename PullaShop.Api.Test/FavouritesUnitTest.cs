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
        var expectedFavourites = new FavouriteModel();
        expectedFavourites.Id = 1;
        expectedFavourites.Products = GetSampleProducts();
        string sql = "";
        var databaseMock = new Mock<ISqlDataAccess>();
        databaseMock.Setup(dataAccess => dataAccess.MyConnectionString).Returns("Default");
        databaseMock.Setup(dataAccess => dataAccess.SaveData<int>(sql)).Returns(Task.FromResult(1));
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