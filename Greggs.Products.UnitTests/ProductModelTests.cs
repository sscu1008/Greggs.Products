using CQRSDemoLibrary.Models;
using System;
using Xunit;

namespace Greggs.Products.UnitTests;

public class ProductModelTests
{
    [Fact]
    public void EuroPriceCalculatesCorrectly()
    {
        // Arrange
        Product pm = new Product { Name = "pie", PriceInPounds = 2.22m, DateAdded = new DateTime(2023, 12, 31) };

        // Act
        Product.SetEuroExchangeRate(1.11m);

        // Assert
        // Euro price is calculated correctly
        Assert.True(pm.PriceInEuros == 2.46m);
    }
}