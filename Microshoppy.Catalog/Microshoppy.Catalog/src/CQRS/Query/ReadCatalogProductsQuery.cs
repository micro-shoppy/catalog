using System.Collections.Generic;
using MediatR;

namespace Microshoppy.Catalog.CQRS.Query
{
	public class ReadCatalogProductsQuery : IRequest<IEnumerable<CatalogProduct>>
	{

	}
}
