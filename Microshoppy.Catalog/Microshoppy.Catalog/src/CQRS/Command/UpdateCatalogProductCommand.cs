using System;
using MediatR;

namespace Microshoppy.Catalog.CQRS.Command
{
	public class UpdateCatalogProductCommand : IRequest<Unit>
	{
		public Guid ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Photo { get; set; }
	}
}
