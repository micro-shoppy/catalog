using System;
using System.Collections.Generic;

namespace Microshoppy.Catalog.src.Repositories
{
	public class InMemoryCatalogRepository : ICatalogRepository
	{
		private static readonly List<CatalogProduct> _repo = new();
		public CatalogProduct CreateProduct(CatalogProduct product)
		{
			_repo.Add(product);
			return product;
		}

		public void DeleteProduct(Guid productId)
		{
			var product = ReadProduct(productId);
			_repo.Remove(product);
		}

		public CatalogProduct ReadProduct(Guid productId)
		{
			return _repo.Find(product => product.ProductId == productId);
		}

		public IEnumerable<CatalogProduct> ReadProducts()
		{
			return _repo;
		}

		public CatalogProduct UpdateProduct(Guid productId, CatalogProduct product)
		{
			DeleteProduct(productId);
			return CreateProduct(product);
		}
	}
}
