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
        private OrderedDictionary<decimal, Bag<Product>> byPrice;
        public ProductRepository()
        {
            byNameAndProducer = new Dictionary<string, List<Product>>();
            byName = new Dictionary<string, OrderedBag<Product>>();
            byProducer = new Dictionary<string, OrderedBag<Product>>();
            byPrice = new OrderedDictionary<decimal, Bag<Product>>();
        }

        public void AddProduct(string name, decimal price, string producer)
        {
            var product = new Product(name, price, producer);
            AddByNameAndProducer(name, producer, product);
            AddByName(name, product);
            AddByProducer(producer, product);
            AddByPrice(price, product);
        }
        public int DeleteByNameAndProducer(string name, string producer)
        {
            var key = $"{name}{producer}";
            if (!byNameAndProducer.ContainsKey(key))
            {
                throw new ArgumentException("No products found");
            }
            var toDelete = byNameAndProducer[key];
            foreach (var product in toDelete)
            {
                byName[product.Name].Remove(product);
                byProducer[product.Producer].Remove(product);
                byPrice[product.Price].Remove(product);
            }
            byNameAndProducer.Remove(key);

            return toDelete.Count;
        }

        public int DeleteByProducer(string producer)
        {
            if (!byProducer.ContainsKey(producer))
            {
                throw new ArgumentException("No products found");
            }
            var toDelete = byProducer[producer];
            foreach (var product in toDelete)
            {
                byName[product.Name].Remove(product);
                byNameAndProducer[$"{product.Name}{product.Producer}"].Remove(product);
                byPrice[product.Price].Remove(product);
            }
            byProducer.Remove(producer);

            return toDelete.Count;
        }

        public IEnumerable<Product> FindByName(string name)
        {
            if (!byName.ContainsKey(name))
            {
                throw new ArgumentException("No products found");
            }
            if (byName[name].Count == 0)
            {
                throw new ArgumentException("No products found");
            }
            return byName[name];
        }

        public IEnumerable<Product> FindByProducer(string producer)
        {
            if (!byProducer.ContainsKey(producer))
            {
                throw new ArgumentException("No products found");
            }
            if (byProducer[producer].Count == 0)
            {
                throw new ArgumentException("No products found");
            }
            return byProducer[producer];
        }

        public IEnumerable<Product> FindProductsByPriceRange(decimal fromPrice, decimal toPrice)
        {
            var result = new OrderedBag<Product>();

            var priceResults = byPrice.Range(fromPrice, true, toPrice, true);
          
            foreach (var item in priceResults)
            {
                result.AddMany(item.Value);
            }
            if (result.Count == 0)
            {
                throw new ArgumentException("No products found");
            }
            return result;
        }
        
        private void AddByPrice(decimal price, Product product)
        {
            if (!byPrice.ContainsKey(price))
            {
                this.byPrice.Add(price, new Bag<Product>());
            }
            this.byPrice[price].Add(product);
        }

        private void AddByProducer(string producer, Product product)
        {
            if (!this.byProducer.ContainsKey(producer))
            {
                this.byProducer.Add(producer, new OrderedBag<Product>());
            }
            this.byProducer[producer].Add(product);
        }

        private void AddByName(string name, Product product)
        {
            if (!this.byName.ContainsKey(name))
            {
                this.byName.Add(name, new OrderedBag<Product>());
            }
            this.byName[name].Add(product);
        }

        private void AddByNameAndProducer(string name, string producer, Product product)
        {
            var key = $"{name}{producer}";
            if (!this.byNameAndProducer.ContainsKey(key))
            {
                this.byNameAndProducer.Add(key, new List<Product>());
            }
            this.byNameAndProducer[key].Add(product);
        }
    }
}
