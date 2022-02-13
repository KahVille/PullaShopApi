using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PullaShop.Api.Models;
using Moq;
using PullaShop.Api.Data;
using System.Threading.Tasks;

namespace PullaShop.Api.Test;

[TestClass]
public class ProductsUnitTest
{
    [TestMethod]
    public void GetAllProductsReturnsAllProducts()
    {

        // Arrange
        var initialProduct = new ProductModel { Name = "Test Product" };
        var mock = new Mock<IProductData>();
        mock.Setup(products => products.GetAllProducts()).ReturnsAsync(new List<ProductModel>() {initialProduct});
        var productData = mock.Object;

        // Act
        var actualAllProducts = productData.GetAllProducts().Result;

        // Assert
        Assert.AreEqual(1,actualAllProducts.Count);
    }
}