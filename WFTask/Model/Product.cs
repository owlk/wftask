using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Model
{
    public class Product
    {

        public string Name { get; private set;}

        public string Description { get; private set; }

        public string Price { get; private set; }

        public Product(string name, string desc, string price)
        {
            Name = name;
            Description = desc;
            Price = price;
        }
    }
}