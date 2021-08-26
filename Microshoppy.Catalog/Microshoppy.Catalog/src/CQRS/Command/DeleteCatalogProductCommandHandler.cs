using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Catalog.Repositories;

namespace Microshoppy.Catalog.CQRS.Command
{
	public class DeleteCatalogProductCommandHandler : Handler<DeleteCatalogProductCommand, Unit>
	{
		public DeleteCatalogProductCommandHandler(ICatalogRepository repo) : base(repo)
		{
		}

		public override Task<Unit> Handle(DeleteCatalogProductCommand request, CancellationToken cancellationToken)
		{
			Repo.DeleteProduct(request.ProductId);
			return Task.FromResult(Unit.Value);
		}
	}
}
