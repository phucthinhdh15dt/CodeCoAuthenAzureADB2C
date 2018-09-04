using System;
using System.Collections.Generic;

namespace testdbfirst.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerOrders = new HashSet<CustomerOrders>();
        }

        public string CustomerId { get; set; }
        public string PaymentMethodCode { get; set; }
        public string CustomerName { get; set; }
        public long? CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerLogin { get; set; }
        public string CustomerPassword { get; set; }
        public string OthorCustomerDetails { get; set; }

        public ICollection<CustomerOrders> CustomerOrders { get; set; }
    }
}
