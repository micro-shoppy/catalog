using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microshoppy.Catalog.Repositories;
using MicroShoppy.Contract.Events;

namespace Microshoppy.Catalog.CQRS.Command
{
	public class CreateCatalogProductCommandHandler : Handler<CreateCatalogProductCommand, Unit>
	{
		private readonly IPublishEndpoint _publishEndpoint;
		public CreateCatalogProductCommandHandler(ICatalogRepository repo, IPublishEndpoint publishEndpoint) : base(repo)
		{
			_publishEndpoint = publishEndpoint;
		}

		public override  Task<Unit> Handle(CreateCatalogProductCommand request, CancellationToken cancellationToken)
		{
			var productToCreate = new CatalogProduct()
			{
				ProductId = request.ProductId,
				Description = request.Description,
				Name = request.Name
			};

			_publishEndpoint.Publish<ProductCreated>(new
			{
				productToCreate.ProductId,
				request.NetPrice,
				request.TaxPercentage
			}, cancellationToken);
			Repo.CreateProduct(productToCreate);
			return Task.FromResult(Unit.Value);
		}
	}

	internal class ProductCreated : IProductCreated
	{
		public Guid ProductId { get; set; }

		public double NetPrice { get; set; }

		public double TaxPercentage { get; set; }
	}
}
