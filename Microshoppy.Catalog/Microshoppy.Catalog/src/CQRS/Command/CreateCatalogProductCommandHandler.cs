using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Catalog.src.Repositories;

namespace Microshoppy.Catalog.src.CQRS.Command
{
	public class CreateCatalogProductCommandHandler : Handler, IRequestHandler<CreateCatalogProductCommand, Unit>
	{
		public CreateCatalogProductCommandHandler(ICatalogRepository repo) : base(repo)
		{
		}

		public Task<Unit> Handle(CreateCatalogProductCommand request, CancellationToken cancellationToken)
		{
			var productToCreate = new CatalogProduct()
			{
				ProductId = request.ProductId,
				Description = request.Description,
				Name = request.Name,
				Photo = request.Photo
			};

			_repo.CreateProduct(productToCreate);
			return Task.FromResult(Unit.Value);
		}
	}
}
