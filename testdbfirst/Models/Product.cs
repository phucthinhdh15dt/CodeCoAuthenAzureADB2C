using System;
using System.Collections.Generic;

namespace testdbfirst.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public string ProductId { get; set; }
        public string ProductCategoryCode { get; set; }
        public string ProductName { get; set; }
        public string OtherProductDetails { get; set; }
        public decimal? ProductPrice { get; set; }

        public RefProductCategories ProductCategoryCodeNavigation { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
    }
}
