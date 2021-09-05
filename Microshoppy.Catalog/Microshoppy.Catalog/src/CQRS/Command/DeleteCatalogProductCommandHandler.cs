using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microshoppy.Catalog.Repositories;
using MicroShoppy.Contract.Events;

namespace Microshoppy.Catalog.CQRS.Command
{
	public class DeleteCatalogProductCommandHandler : Handler<DeleteCatalogProductCommand, Unit>
	{
		private readonly IPublishEndpoint _publishEndpoint;
		public DeleteCatalogProductCommandHandler(ICatalogRepository repo, IPublishEndpoint publishEndpoint) : base(repo)
		{
			_publishEndpoint = publishEndpoint;
		}

		public override Task<Unit> Handle(DeleteCatalogProductCommand request, CancellationToken cancellationToken)
		{
			Repo.DeleteProduct(request.ProductId);
			_publishEndpoint.Publish<IProductRemoved>(new {request.ProductId}, cancellationToken);
			return Task.FromResult(Unit.Value);
		}
	}
}
