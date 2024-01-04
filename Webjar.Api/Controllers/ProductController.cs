using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webjar.Application.DTOs.Product;
using Webjar.Application.Features.Products.Requests.Commands;
using Webjar.Application.Features.Products.Requests.Queries;

namespace Webjar.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IMediator _mediator;
		public ProductController(IMediator mediator)
		{
			this._mediator = mediator;
		}

		// GET: api/<ProductsController>
		[HttpGet]
		public async Task<ActionResult<List<ProductDto>>> Get()
		{
			var products = await _mediator.Send(new GetProductListRequest());
			return Ok(products);
		}

		// POST api/<ProductsController>
		[HttpPost]
		public async Task<ActionResult> Post([FromForm] CreateProductDto product)
		{
			var response = await _mediator.Send(new CreateProductCommand { ProductDto = product });
			return Ok(response);
		}
	}
}
