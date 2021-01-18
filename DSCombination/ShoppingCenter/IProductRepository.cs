

using System.Collections.Generic;

namespace ShoppingCenter
{
    public interface IProductRepository
    {
        void AddProduct(string name, decimal price, string producer);
        int DeleteByProducer(string producer);
        int DeleteByNameAndProducer(string name, string producer);
        IEnumerable<Product> FindByName(string name);
        IEnumerable<Product> FindByProducer(string producer);
        IEnumerable<Product> FindProductsByPriceRange(decimal fromPrice, decimal toPrice);
    }
}
