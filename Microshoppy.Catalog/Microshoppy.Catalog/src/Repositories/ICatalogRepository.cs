using System;
using System.Collections.Generic;

namespace Microshoppy.Catalog.src.Repositories
{
	public interface ICatalogRepository
	{
		CatalogProduct CreateProduct(CatalogProduct product);
		CatalogProduct ReadProduct(Guid productId);
		IEnumerable<CatalogProduct> ReadProducts();
		CatalogProduct UpdateProduct(Guid productId, CatalogProduct product);
		void DeleteProduct(Guid productId);
	}
}
