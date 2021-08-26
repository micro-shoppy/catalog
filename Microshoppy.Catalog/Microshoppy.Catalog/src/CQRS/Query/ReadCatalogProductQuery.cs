using System;
using MediatR;

namespace Microshoppy.Catalog.CQRS.Query
{
	public class ReadCatalogProductQuery : IRequest<CatalogProduct>
	{
		public Guid ProductId { get; set; }
	}
}
