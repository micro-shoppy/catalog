using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microshoppy.Catalog.src.CQRS.Command;
using Microshoppy.Catalog.src.CQRS.Query;

namespace Microshoppy.Catalog.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CatalogController : ControllerBase
	{
		private readonly ILogger<CatalogController> _logger;
		private readonly IMediator _mediator;

		public CatalogController(ILogger<CatalogController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IEnumerable<CatalogProduct>> ReadAllProducts()
		{
			return await _mediator.Send(new ReadCatalogProductsQuery());
		}

		[HttpGet]
		[Route("{productId}")]
		public async Task<CatalogProduct> ReadProduct(Guid productId)
		{
			return await _mediator.Send(new ReadCatalogProductQuery()
			{
				ProductId = productId
			});
		}

		[HttpPost]
		public void CreateProduct(CatalogProduct product)
		{
			_mediator.Send(new CreateCatalogProductCommand()
			{
				ProductId = product.ProductId,
				Name = product.Name,
				Description = product.Description,
				Photo = product.Photo
			});
		}

		[HttpPost]
		[Route("{productId}")]
		public void UpdateProduct(Guid productId, CatalogProduct product)
		{
			_mediator.Send(new UpdateCatalogProductCommand()
			{
				ProductId = productId,
				Name = product.Name,
				Description = product.Description,
				Photo = product.Photo
			});
		}

		[HttpDelete]
		[Route("{productId}")]
		public void DeleteProduct(Guid productId)
		{
			_mediator.Send(new DeleteCatalogProductCommand()
			{
				ProductId = productId
			});
		}
	}
}
