using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebApplication2.Model
{
    public class CategoryEnumerable : SortedSet<Category>, IHierarchicalEnumerable
    {
        public IHierarchyData GetHierarchyData(object enumeratedItem)
        {
            return enumeratedItem as IHierarchyData;
        }
    }
}