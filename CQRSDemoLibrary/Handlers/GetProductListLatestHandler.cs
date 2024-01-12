using CQRSDemoLibrary.DataAccess;
using CQRSDemoLibrary.Models;
using CQRSDemoLibrary.Queries;
using MediatR;

namespace CQRSDemoLibrary.Handlers
{
    public class GetProductListLatestHandler : IRequestHandler<GetProductListLatestQuery, List<Product>>
    {
        private readonly IDataAccess<Product> _data;

        public GetProductListLatestHandler(IDataAccess<Product> data)
        {
            _data = data;
        }

        public Task<List<Product>> Handle(GetProductListLatestQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.GetLatestProducts(request.pageStart, request.pageSize).ToList());
        }
    }
}
