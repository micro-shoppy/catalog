using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microshoppy.Catalog.Repositories
{
	public interface ICatalogRepository
	{
		Task<CatalogProduct> CreateProduct(CatalogProduct product);
		Task<CatalogProduct> ReadProduct(Guid productId);
		Task<IEnumerable<CatalogProduct>> ReadProducts();
		Task<CatalogProduct> UpdateProduct(Guid productId, CatalogProduct product);
		void DeleteProduct(Guid productId);
	}
}
