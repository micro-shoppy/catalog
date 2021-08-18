using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Catalog.src.Repositories;

namespace Microshoppy.Catalog.src.CQRS.Query
{
	public class ReadCatalogProductsQueryHandler : Handler, IRequestHandler<ReadCatalogProductsQuery, IEnumerable<CatalogProduct>>
	{
		public ReadCatalogProductsQueryHandler(ICatalogRepository repo) : base(repo)
		{
		}

		public Task<IEnumerable<CatalogProduct>> Handle(ReadCatalogProductsQuery request, CancellationToken cancellationToken)
		{
			return Task.FromResult(_repo.ReadProducts());
		}
	}
}
