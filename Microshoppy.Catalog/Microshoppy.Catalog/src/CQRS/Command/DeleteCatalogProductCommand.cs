using System;
using MediatR;

namespace Microshoppy.Catalog.CQRS.Command
{
	public class DeleteCatalogProductCommand : IRequest<Unit>
	{
		public Guid ProductId { get; set; }
	}
}
