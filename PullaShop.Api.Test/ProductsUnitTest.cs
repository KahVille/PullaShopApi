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
        var allProducts = new List<ProductModel>() {};

        var expectedProducts = new List<ProductModel>() {
            new ProductModel { Name = "Tuote" }
        };

        CollectionAssert.AreEqual(allProducts, expectedProducts);

    }
}