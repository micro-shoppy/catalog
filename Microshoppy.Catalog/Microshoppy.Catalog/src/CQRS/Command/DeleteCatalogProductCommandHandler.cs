using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Catalog.src.Repositories;

namespace Microshoppy.Catalog.src.CQRS.Command
{
	public class DeleteCatalogProductCommandHandler : Handler, IRequestHandler<DeleteCatalogProductCommand, Unit>
	{
		public DeleteCatalogProductCommandHandler(ICatalogRepository repo) : base(repo)
		{
		}

		public Task<Unit> Handle(DeleteCatalogProductCommand request, CancellationToken cancellationToken)
		{
			_repo.DeleteProduct(request.ProductId);
			return Task.FromResult(Unit.Value);
		}
	}
}
