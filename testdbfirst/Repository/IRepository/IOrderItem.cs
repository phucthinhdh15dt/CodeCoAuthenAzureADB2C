using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testdbfirst.Models;

namespace testdbfirst.Repository.IRepository
{
    public interface IOrderItem
    {
        IEnumerable<OrderItem> getAllOrderItem(string oderItem);
        OrderItem getFindIDOrderItem(string order_id, string product_id);
        bool CreateOrderItem(OrderItem RPC);
        bool EditOrderItem(string order_id, string product_id, int quantity ,string product_id_Change);
        bool deleteOrderItem(string order_id,string product_id);

    }
}
