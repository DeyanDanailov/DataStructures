

namespace ShoppingCenter
{
    public class Product
    {
        public Product(string name, int price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }
        public string Name { get; private set; }
        public int Price { get; private set; }
        public string Producer { get; private set; }
    }
}
