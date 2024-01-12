using CQRSDemoLibrary.Models;
using MediatR;

namespace CQRSDemoLibrary.Queries
{
    public class GetProductListQuery : IRequest<List<Product>>
    {
        public int pageStart { get; set; } = 1;
        public int pageSize { get; set; } = 5;
    }

}
