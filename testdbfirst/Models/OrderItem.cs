using System;
using System.Collections.Generic;

namespace testdbfirst.Models
{
    public partial class OrderItem
    {
        public string Status { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Iditem { get; set; }
        public int? Quantity { get; set; }

        public CustomerOrders Order { get; set; }
        public Product Product { get; set; }
    }
}
