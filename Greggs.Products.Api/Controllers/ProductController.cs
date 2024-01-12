using CQRSDemoLibrary.Models;
using CQRSDemoLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Greggs.Products.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [Obsolete("Products array is obsolete.")]
    private static readonly string[] Products = new[]
    {
        "Sausage Roll", "Vegan Sausage Roll", "Steak Bake", "Yum Yum", "Pink Jammie"
    };

    private readonly ILogger<ProductController> _logger;

    public IMediator _mediator { get; }

    public ProductController(IMediator mediator, ILogger<ProductController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<List<Product>> Get(int pageStart = 1, int pageSize = 5)
    {
        _logger.LogInformation("ProductController ProductList called");

        return await _mediator.Send(
           new GetProductListQuery()
           {
               pageStart = pageStart,
               pageSize = pageSize
           }
           );
    }

    [HttpGet]
    [Route("Latest")]
    public async Task<List<Product>> Latest(int pageStart = 1, int pageSize = 5)
    {
        _logger.LogInformation("ProductController ProductListLatest called");
        return await _mediator.Send(
            new GetProductListLatestQuery()
            {
                pageStart = pageStart,
                pageSize = pageSize
            }
            );
    }
}