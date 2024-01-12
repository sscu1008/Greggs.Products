using CQRSDemoLibrary.DataAccess;
using CQRSDemoLibrary.Handlers;
using CQRSDemoLibrary.Models;
using CQRSDemoLibrary.Queries;
using Microsoft.Extensions.Options;
using System.Linq;
using Xunit;


namespace Greggs.Products.UnitTests
{
    public class ProductListTests
    {
        [Fact]
        public async void Pagination_CheckNumberReturned()
        {

            // create app settings for dependency injection
            IOptions<AppSettings> appSettings = Options.Create<AppSettings>(new AppSettings() { EuroExchangeRate = 3.33m });

            var data = new ProductAccess(appSettings);

            GetProductListQuery request = new GetProductListQuery() { pageStart = 1, pageSize = 2 };

            GetProductListHandler handler = new GetProductListHandler((IDataAccess<Product>)data);

            //Act
            var result = await handler.Handle(request, new System.Threading.CancellationToken());
            //Assert
            //Do the assertion

            Assert.Contains(result, product => product.Name == "Sausage Roll");
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void Pagination_CorrectRowsForPageNumberReturned()
        {
            // check 2nd page of pagesize 3 returns contain 'Bacon Sandwich','sausage roll' and Coca Cola', in that order.
            // create app settings for dependency injection
            IOptions<AppSettings> appSettings = Options.Create<AppSettings>(new AppSettings() { EuroExchangeRate = 3.33m });

            var data = new ProductAccess(appSettings);

            GetProductListLatestQuery request = new GetProductListLatestQuery() { pageStart = 2, pageSize = 3 };

            GetProductListLatestHandler handler = new GetProductListLatestHandler((IDataAccess<Product>)data);

            //Act
            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            //Assert
            // check only 3 rows returned by pagination
            Assert.Equal(3, result.Count);

            // check results only contain 'Bacon Sandwich','sausage roll' and Coca Cola', in that order
            Assert.Equal("Bacon Sandwich", result[0].Name);
            Assert.Equal("Sausage Roll", result[1].Name);
            Assert.Equal("Coca Cola", result[2].Name);
        }

        [Fact]
        public async void LatestProductsReturned()
        {
            // create app settings for dependency injection
            IOptions<AppSettings> appSettings = Options.Create<AppSettings>(new AppSettings() { EuroExchangeRate = 3.33m });

            var data = new ProductAccess(appSettings);

            GetProductListLatestQuery request = new GetProductListLatestQuery() { pageStart = 1, pageSize = 2 };

            GetProductListLatestHandler handler = new GetProductListLatestHandler((IDataAccess<Product>)data);

            //Act
            var result = await handler.Handle(request, new System.Threading.CancellationToken());
            //Assert
            //newest product is 'Stake Bake'
            Assert.Equal("Steak Bake", result.First().Name);
            //secomd newest product is 'Yum Yum'
            Assert.Equal("Yum Yum", result[1].Name);
        }
    }
}
