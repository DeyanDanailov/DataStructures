﻿

using System;
using System.Diagnostics.CodeAnalysis;

namespace ShoppingCenter
{
    public class Product : IComparable<Product>
    {
        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Producer { get; private set; }

        public int CompareTo([AllowNull] Product other)
        {
            var cmp = this.Name.CompareTo(other.Name);
            if (cmp == 0) cmp = this.Producer.CompareTo(other.Producer);
            if (cmp == 0) cmp = this.Price.CompareTo(other.Price);

            return cmp;
        }
        public override string ToString()
        {
            return $"{this.Name};{this.Producer};{this.Price:F2}";
        }
    }
}
