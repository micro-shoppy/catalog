using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Microshoppy.Catalog.src.CQRS.Command
{
	public class UpdateCatalogProductCommand : IRequest<Unit>
	{
		public Guid ProductId { get; set; }
		public String Name { get; set; }
		public String Description { get; set; }
		public String Photo { get; set; }
	}
}
