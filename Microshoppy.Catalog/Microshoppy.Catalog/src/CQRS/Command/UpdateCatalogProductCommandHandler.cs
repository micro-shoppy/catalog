using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Catalog.Repositories;

namespace Microshoppy.Catalog.CQRS.Command
{
	public class UpdateCatalogProductCommandHandler : Handler<UpdateCatalogProductCommand, Unit>
	{
		public UpdateCatalogProductCommandHandler(ICatalogRepository repo) : base(repo)
		{
		}

		public override Task<Unit> Handle(UpdateCatalogProductCommand request, CancellationToken cancellationToken)
		{
			var itemToUpdate = new CatalogProduct()
			{
				ProductId = request.ProductId,
				Name = request.Name,
				Description = request.Description,
				Photo = request.Photo
			};
			Repo.UpdateProduct(request.ProductId, itemToUpdate);
			return Task.FromResult(Unit.Value);
		}
	}
}
