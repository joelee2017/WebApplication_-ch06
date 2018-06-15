using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_美學ch06.Models.ViewModel
{
    public class ProductCategoryViewModel
    {
        public string Name { get; set; }
        public string Book { get; set; }
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}