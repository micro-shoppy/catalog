using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Catalog.Repositories;

namespace Microshoppy.Catalog.CQRS.Command
{
	public class CreateCatalogProductCommandHandler : Handler<CreateCatalogProductCommand, Unit>
	{
		public CreateCatalogProductCommandHandler(ICatalogRepository repo) : base(repo)
		{
		}

		public override  Task<Unit> Handle(CreateCatalogProductCommand request, CancellationToken cancellationToken)
		{
			var productToCreate = new CatalogProduct()
			{
				ProductId = request.ProductId,
				Description = request.Description,
				Name = request.Name,
				Photo = request.Photo
			};

			Repo.CreateProduct(productToCreate);
			return Task.FromResult(Unit.Value);
		}
	}
}
