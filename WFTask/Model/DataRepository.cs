using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Model
{
    public static class DataRepository
    {
        private static CategoryEnumerable categoryRoot = null;


        public static CategoryEnumerable GetCategoriesRoot()
        {
            if (categoryRoot == null)
            {
                PrepareInitialData();

            }
            return categoryRoot;
        }

        private static void PrepareInitialData()
        {
            categoryRoot = new CategoryEnumerable();
            var cat1 = new Category("A");
            cat1.Products.Add(new Product("P1", "description 1", "12"));
            cat1.Products.Add(new Product("P2", "description 2", "12"));
            cat1.Products.Add(new Product("P3", "description 3", "12"));
            cat1.AddChild(new Category("AB"));

            categoryRoot.Add(cat1);
            
            var cat2 = new Category("B");
            var cat3 = new Category("BB");

            cat3.Products.Add(new Product("P4", "description 4", "100"));
            cat3.Products.Add(new Product("P5", "description 5", "200"));
            cat3.Products.Add(new Product("P6", "description 6", "300"));

            cat2.AddChild(cat3);

            categoryRoot.Add(cat2);
        }

      
    }
}