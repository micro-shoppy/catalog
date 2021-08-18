using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Catalog.src.Repositories;

namespace Microshoppy.Catalog.src.CQRS.Command
{
	public class UpdateCatalogProductCommandHandler : Handler, IRequestHandler<UpdateCatalogProductCommand, Unit>
	{
		public UpdateCatalogProductCommandHandler(ICatalogRepository repo) : base(repo)
		{
		}

		public Task<Unit> Handle(UpdateCatalogProductCommand request, CancellationToken cancellationToken)
		{
			var itemToUpdate = new CatalogProduct()
			{
				ProductId = request.ProductId,
				Name = request.Name,
				Description = request.Description,
				Photo = request.Photo
			};
			_repo.UpdateProduct(request.ProductId, itemToUpdate);
			return Task.FromResult(Unit.Value);
		}
	}
}
