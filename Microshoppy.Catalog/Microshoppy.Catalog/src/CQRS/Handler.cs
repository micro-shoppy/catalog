using Microshoppy.Catalog.src.Repositories;

namespace Microshoppy.Catalog.src.CQRS
{
	public class Handler
	{
		protected readonly ICatalogRepository _repo;

		public Handler(ICatalogRepository repo)
		{
			_repo = repo;
		}
	}
}
