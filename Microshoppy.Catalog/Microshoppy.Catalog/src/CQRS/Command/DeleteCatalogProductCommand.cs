using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Microshoppy.Catalog.src.CQRS.Command
{
	public class DeleteCatalogProductCommand : IRequest<Unit>
	{
		public Guid ProductId { get; set; }
	}
}
