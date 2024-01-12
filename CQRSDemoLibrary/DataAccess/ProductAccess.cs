using CQRSDemoLibrary.Models;
using Microsoft.Extensions.Options;

namespace CQRSDemoLibrary.DataAccess
{
    public class ProductAccess : IDataAccess<Product>
    {
        public List<Product> ProductDemoDatabase = new List<Product>
        {
        new() { Name = "Sausage Roll", PriceInPounds = 1m , DateAdded = new DateTime(2022, 2, 12)},
        new() { Name = "Vegan Sausage Roll", PriceInPounds = 1.1m , DateAdded = new DateTime(2021, 1, 1)},
        new() { Name = "Steak Bake", PriceInPounds = 1.2m , DateAdded = new DateTime(2023, 12, 31)},
        new() { Name = "Yum Yum", PriceInPounds = 0.7m , DateAdded = new DateTime(2023, 11, 30)},
        new() { Name = "Pink Jammie", PriceInPounds = 0.5m },
        new() { Name = "Mexican Baguette", PriceInPounds = 2.1m , DateAdded = new DateTime(2022, 11, 15)},
        new() { Name = "Bacon Sandwich", PriceInPounds = 1.95m , DateAdded = new DateTime(2022, 06, 30)},
        new() { Name = "Coca Cola", PriceInPounds = 1.2m , DateAdded = new DateTime(2022, 01, 30)}
    };

        public IOptions<AppSettings> _appSettings { get; }

        public ProductAccess(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
            Product.SetEuroExchangeRate(appSettings.Value.EuroExchangeRate);
        }

        public IEnumerable<Product> List(int? pageStart, int? pageSize)
        {
            var queryable = ProductDemoDatabase.AsQueryable();
            if (pageStart.HasValue && pageSize.HasValue)
                queryable = queryable.Skip(((pageStart ?? 1) - 1) * (pageSize ?? 1));

            if (pageSize.HasValue)
                queryable = queryable.Take(pageSize.Value);

            return queryable.ToList();
        }

        public IEnumerable<Product> GetLatestProducts(int? pageStart, int? pageSize)
        {
            var queryable = ProductDemoDatabase.AsQueryable();
            queryable = queryable.OrderByDescending(p => p.DateAdded);

            if (pageStart.HasValue && pageSize.HasValue)
            {
                queryable = queryable.Skip(((pageStart ?? 1) - 1) * (pageSize ?? 1));
            }

            if (pageSize.HasValue)
            {
                queryable = queryable.Take(pageSize.Value);
            }

            return queryable.ToList();
        }
    }
}
