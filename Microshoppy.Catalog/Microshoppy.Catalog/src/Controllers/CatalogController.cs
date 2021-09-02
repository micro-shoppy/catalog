using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microshoppy.Catalog.CQRS.Command;
using Microshoppy.Catalog.CQRS.Query;

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
			_logger.Info("Reading all products");
			return await _mediator.Send(new ReadCatalogProductsQuery());
		}

		[HttpGet]
		[Route("{productId}")]
		public async Task<CatalogProduct> ReadProduct(Guid productId)
		{
			_logger.Info($"Reading product with ID {productId}");
			return await _mediator.Send(new ReadCatalogProductQuery()
			{
				ProductId = productId
			});
		}

		[HttpPost]
		public void CreateProduct(CreateCatalogProductCommand command)
		{
			_logger.Info($"Creating new product: {command.Name}");
			_mediator.Send(command);
		}

		[HttpPost]
		[Route("{productId}")]
		public void UpdateProduct(Guid productId, UpdateCatalogProductCommand command)
		{
			command.ProductId = productId;
			_logger.Info($"Updating product with ID {productId} to {command}");
			_mediator.Send(command);
		}

		[HttpDelete]
		[Route("{productId}")]
		public void DeleteProduct(Guid productId)
		{
			_logger.Info($"Deleting product with ID {productId}");
			_mediator.Send(new DeleteCatalogProductCommand()
			{
				ProductId = productId
			});
		}
	}

	public static class ProdLogger
	{
		public static void Info(this ILogger logger, string info)
		{
			logger.Log(LogLevel.Information, $"[INFO] {info}");
		}
	}
}
