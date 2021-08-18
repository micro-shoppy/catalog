using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Catalog.src.Repositories;

namespace Microshoppy.Catalog.src.CQRS.Query
{
	public class ReadCatalogProductQueryHandler : Handler, IRequestHandler<ReadCatalogProductQuery, CatalogProduct>
	{
		public ReadCatalogProductQueryHandler(ICatalogRepository repo) : base(repo)
		{
		}

		public Task<CatalogProduct> Handle(ReadCatalogProductQuery request, CancellationToken cancellationToken)
		{
			return Task.FromResult(_repo.ReadProduct(request.ProductId));
		}
	}
}
