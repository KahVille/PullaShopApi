using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PullaShop.Api.Models;
using Moq;

namespace PullaShop.Api.Test;

[TestClass]
public class ProductsUnitTest
{
    [TestMethod]
    public void GetAllProductsReturnsAllProducts()
    {

        // Arrange
        var initialProduct = new ProductModel { Name = "Test Product" };
        var mock = new Mock(IProductData);
        mock.Setup(product => product.GetAllProducts()).Returns(new List<ProductModel>() {initialProduct});
        var productData = new ProductData(mock.Object);
        
        // Act
        var actualAllProducts = productData.GetAllProducts();

        // Assert
        Assert.AreEqual(1, actualAllProducts.Count);
    }

    [TestMethod]
    public void GetReturnsProduct()
    {

        // var productData = new ProductData();
        // var actualProduct = productData.GetProduct(0);
        // var expectedProduct = new ProductModel { Name = "Test Product" };

        // Assert.AreEqual(expectedProduct.Name, actualProduct.Name);
    }
}