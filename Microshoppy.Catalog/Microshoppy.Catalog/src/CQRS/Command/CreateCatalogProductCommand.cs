using System;
using MediatR;
namespace Microshoppy.Catalog.CQRS.Command
{
	public class CreateCatalogProductCommand : IRequest<Unit>
	{
		public Guid ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double NetPrice { get; set; }
		public double TaxPercentage { get; set; }
	}
}
