using CQRSDemoLibrary.DataAccess;
using CQRSDemoLibrary.Models;
using CQRSDemoLibrary.Queries;
using MediatR;

namespace CQRSDemoLibrary.Handlers
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<Product>>
    {
        private readonly IDataAccess<Product> _data;

        public GetProductListHandler(IDataAccess<Product> data)
        {
            _data = data;
        }

        public Task<List<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.List(request.pageStart, request.pageSize).ToList());
        }
    }
}
