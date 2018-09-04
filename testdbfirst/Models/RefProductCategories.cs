using System;
using System.Collections.Generic;

namespace testdbfirst.Models
{
    public partial class RefProductCategories
    {
        public RefProductCategories()
        {
            Product = new HashSet<Product>();
        }

        public string ProductCategoryCode { get; set; }
        public string ProductCategoryDescription { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
