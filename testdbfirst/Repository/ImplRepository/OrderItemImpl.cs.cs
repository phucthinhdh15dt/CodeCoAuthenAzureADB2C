using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testdbfirst.Models;
using testdbfirst.Repository.IRepository;

namespace testdbfirst.Repository.ImplRepository
{
    public class OrderItemImpl : IOrderItem
    {
        ProductOderDemoContext db = new ProductOderDemoContext();
        public bool CreateOrderItem(OrderItem RPC)
        {
            try
            {
                OrderItem checkOrderItem =(OrderItem)db.OrderItem.
                    Where(o => o.OrderId.Equals(RPC.OrderId) && o.ProductId.Equals(RPC.ProductId)).
                    SingleOrDefault();
                
                if (checkOrderItem == null)
                {
                    var addCustome = db.OrderItem.Add(RPC);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteOrderItem(string order_id, string product_id)
        {
            
                db.OrderItem.Remove((OrderItem)db.OrderItem.Where(s => s.OrderId.Contains(order_id) && s.ProductId.Contains(product_id)).SingleOrDefault());
                db.SaveChanges();
                return true;
         
        }

        public bool EditOrderItem(string order_id, string product_id, int quantity,string product_id_Change)
        {
            
                var findOrderItem = (OrderItem)db.OrderItem.Where(s => s.OrderId.Equals(order_id)
                && s.ProductId.Equals(product_id)).SingleOrDefault();
                if (findOrderItem != null)
                {
                    OrderItem checkOrderItem = (OrderItem)db.OrderItem.
                    Where(o => o.OrderId.Equals(findOrderItem.OrderId) && o.ProductId.Equals(product_id_Change)).
                    SingleOrDefault();


                if (checkOrderItem == null)
                {
                    findOrderItem.Quantity = quantity;
                    findOrderItem.ProductId = product_id_Change;
                    db.SaveChanges();
                }
                else
                {
                    return false;
                }
                  
                }

            return true;
        }

        public IEnumerable<OrderItem> getAllOrderItem(string oderItem)
        {
            if (oderItem.Equals("ALL"))
            {
                return db.OrderItem.ToList();
            }
            else
            {
                return db.OrderItem.Where(s => s.OrderId.Equals(oderItem)).ToList();
            }
            
        }

        public OrderItem getFindIDOrderItem(string order_id, string product_id)
        {
            

                return (OrderItem)db.OrderItem.Where(s => s.OrderId.Contains(order_id) && s.ProductId.Contains(product_id)).SingleOrDefault();
                
           
        }
    }
}
