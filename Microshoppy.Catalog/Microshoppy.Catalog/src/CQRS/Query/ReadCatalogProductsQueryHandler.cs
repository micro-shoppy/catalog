using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microshoppy.Catalog.Repositories;

namespace Microshoppy.Catalog.CQRS.Query
{
	public class ReadCatalogProductsQueryHandler : Handler<ReadCatalogProductsQuery, IEnumerable<CatalogProduct>>
	{
		public ReadCatalogProductsQueryHandler(ICatalogRepository repo) : base(repo)
		{
		}

		public override Task<IEnumerable<CatalogProduct>> Handle(ReadCatalogProductsQuery request, CancellationToken cancellationToken)
		{
			return Repo.ReadProducts();
		}
	}
}
