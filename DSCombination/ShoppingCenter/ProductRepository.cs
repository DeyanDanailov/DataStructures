using Magnum.Collections;
using System;
using System.Collections.Generic;

namespace ShoppingCenter
{
    public class ProductRepository : IProductRepository
    {
        private Dictionary<string, List<Product>> byNameAndProducer;
        private Dictionary<string, OrderedBag<Product>> byName;
        private Dictionary<string, OrderedBag<Product>> byProducer;
        private OrderedDictionary<decimal, OrderedBag<Product>> byPrice;
        public ProductRepository()
        {
            byNameAndProducer = new Dictionary<string, List<Product>>();
            byName = new Dictionary<string, OrderedBag<Product>>();
            byProducer = new Dictionary<string, OrderedBag<Product>>();
            byPrice = new OrderedDictionary<decimal, OrderedBag<Product>>();
        }

        public void AddProduct(string name, decimal price, string producer)
        {
            var product = new Product(name, price, producer);
            AddByNameAndProducer(name, producer, product);
            AddByName(name, product);
        }

        private void AddByName(string name, Product product)
        {
            if (!byName.ContainsKey(name))
            {
                byName.Add(name, new OrderedBag<Product>());
            }
            byName[name].Add(product);
        }

        private void AddByNameAndProducer(string name, string producer, Product product)
        {
            var key = $"{name}{producer}";
            if (!byNameAndProducer.ContainsKey(key))
            {
                byNameAndProducer.Add(key, new List<Product>());
            }
            byNameAndProducer[key].Add(product);
        }

        public int DeleteByNameAndProducer(string name, string producer)
        {
            throw new NotImplementedException();
        }

        public int DeleteByProducer(string producer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindByProducer(string producer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindProductsByPriceRange(decimal fromPrice, decimal toPrice)
        {
            throw new NotImplementedException();
        }
    }
}
