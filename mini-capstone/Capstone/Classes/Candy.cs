using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Candy
    {
        // Properties
        public string Type { get; }
        public string Id { get; }
        public string Name { get; }
        public bool Wrapper { get; }
        public int Qty { get; set; } = 100;
        public decimal Price { get; }

        // Constructors
        public Candy (string type, string id, string name, decimal price, bool wrapper)
        {
            Type = type;
            Id = id;
            Name = name;
            Wrapper = wrapper;
            Price = price;
        }
    }
}
