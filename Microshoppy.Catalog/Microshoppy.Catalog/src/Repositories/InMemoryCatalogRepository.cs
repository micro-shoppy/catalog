using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microshoppy.Catalog.Repositories
{
	public class InMemoryCatalogRepository : ICatalogRepository
	{
		private static readonly List<CatalogProduct> Repo = new();
		public Task<CatalogProduct> CreateProduct(CatalogProduct product)
		{
			Repo.Add(product);
			return Task.FromResult(product);
		}

		public void DeleteProduct(Guid productId)
		{
			Repo.Remove(Repo.Find(p => p.ProductId == productId));
		}

		public Task<CatalogProduct> ReadProduct(Guid productId)
		{
			return Task.FromResult(Repo.Find(product => product.ProductId == productId));
		}

		public Task<IEnumerable<CatalogProduct>> ReadProducts()
		{
			return Task.FromResult(Repo.AsEnumerable());
		}

		public Task<CatalogProduct> UpdateProduct(Guid productId, CatalogProduct product)
		{
			Repo.Remove(Repo.Find(p => p.ProductId == productId));
			Repo.Add(product);
			return Task.FromResult(product);
		}
	}
}
