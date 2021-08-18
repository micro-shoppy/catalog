using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Microshoppy.Catalog.src.CQRS.Query
{
	public class ReadCatalogProductsQuery : IRequest<IEnumerable<CatalogProduct>>
	{

	}
}
