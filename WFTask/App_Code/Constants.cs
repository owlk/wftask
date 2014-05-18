using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.App_Code
{
    public static class Constants
    {
        public static readonly string SESSION_KEY_DICTIONARY = "pathToCategoryDict";
        public static readonly string SESSION_KEY_COMMUNICATE = "communicate";

        public static readonly string COMMUNICATE_CATEGORY_EXISTS = "category already exists";
        public static readonly string COMMUNICATE_PRODUCT_ADDED = "Product added successfully";
        public static readonly string COMMUNICATE_NOTE_NOT_SELECTED = "You should select category first";
    }
}