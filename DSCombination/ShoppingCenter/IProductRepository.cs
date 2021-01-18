

using System.Collections.Generic;

namespace ShoppingCenter
{
    public interface IProductRepository
    {
        void AddProduct();
        int DeleteByProducer();
        int DeleteByNameAndProducer();
        IEnumerable<Product> FindByName();
        IEnumerable<Product> FindByProducer();
        IEnumerable<Product> FindProductsByPriceRange();
    }
}
