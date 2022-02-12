using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PullaShop.Api.Models;

namespace PullaShop.Api.Test;

[TestClass]
public class ProductsUnitTest
{
    [TestMethod]
    public void TestGetAllProducts()
    {
        var productData = new ProductData();

        //Get 
        var allProducts = productData.GetAllProducts();

        var expectedProductCount = 1; 

        Assert.AreEqual(expectedProductCount, allProducts);
    }

    [TestMethod]
    public void TestGetSingleProduct()
    {
        var productData = new ProductData();

        var actualProduct = productData.GetProduct(0);

        var expectedProduct = new ProductModel { Name = "Test Product" };

        Assert.AreEqual(expectedProduct.Name, actualProduct.Name);
    }
}