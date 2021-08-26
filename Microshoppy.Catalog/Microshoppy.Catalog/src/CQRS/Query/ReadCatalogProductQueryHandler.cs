using System.Threading;
using System.Threading.Tasks;
using Microshoppy.Catalog.Repositories;

namespace Microshoppy.Catalog.CQRS.Query
{
	public class ReadCatalogProductQueryHandler : Handler<ReadCatalogProductQuery, CatalogProduct>
	{
		public ReadCatalogProductQueryHandler(ICatalogRepository repo) : base(repo)
		{
		}

		public override Task<CatalogProduct> Handle(ReadCatalogProductQuery request, CancellationToken cancellationToken)
		{
			return Repo.ReadProduct(request.ProductId);
		}
	}
}
