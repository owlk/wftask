using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebApplication2.Model
{
    public class Category : IHierarchyData, IComparable
    {
        public CategoryEnumerable Children { get;  private set; }

        public Category Parent { get; private set; }

        public List<Product> Products { get; private set; }

        public string Name { get; private set; }

        public string NameAndProductCount
        {
            get
            {
                return string.Format("{0} ({1})", Name, Products.Count);
            }
        }

        public Category(String name)
        {
            Name = name;
            Children = new CategoryEnumerable();
            Products = new List<Product>();
        }

       
        public IHierarchicalEnumerable GetChildren()
        {
            return Children;
        }

        public IHierarchyData GetParent()
        {
            return Parent;
        }

        public bool AddChild(Category category)
        {
            category.Parent = this;
            return Children.Add(category);
        }

        public bool HasChildren
        {
            get { return Children.Count != 0; }
        }

        public object Item
        {
            get { return this; }
        }

        public string Path
        {
            get { return Name; }
        }

        public string Type
        {
            get { return this.GetType().ToString(); }
        }

        public int CompareTo(object obj)
        {
            if (obj == null || obj is Category)
            {
                var category = obj as Category;
                return Name.CompareTo(category.Name);
            } else
            {
                return -1;
            }
        }
    }
}