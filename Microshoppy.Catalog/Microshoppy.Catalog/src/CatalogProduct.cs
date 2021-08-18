using System;

namespace Microshoppy.Catalog
{
	public class CatalogProduct
	{
		public Guid ProductId { get; set; }
		public String Name { get; set; }
		public String Description { get; set; }
		public String Photo { get; set; }
	}
}
