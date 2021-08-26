using MediatR;
using Microshoppy.Catalog.Repositories;
using System.Threading.Tasks;
using System.Threading;

namespace Microshoppy.Catalog.CQRS
{
	public abstract class Handler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		protected readonly ICatalogRepository Repo;

		protected Handler(ICatalogRepository repo)
		{
			Repo = repo;
		}

		public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
	}
}
