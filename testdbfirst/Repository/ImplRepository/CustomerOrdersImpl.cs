using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testdbfirst.MethodUseGeneral.ImplementMethodUseGeneral;
using testdbfirst.Models;


namespace testdbfirst.Repository.ImplRepository
{
    public class CustomerOrdersImpl : ICustomerOrders
    {
        ProductOderDemoContext db = new ProductOderDemoContext();

        public int CountCustomerOrdersFilter(string filter, bool conditionCount)
        {
            PagingCustomerOrder pagingCustomerOrder = new PagingCustomerOrder();
            int count = pagingCustomerOrder.CountCustomerOrdersFilter(filter,db,conditionCount);
            return count;
        }

        public bool CreateCustomerOrders(CustomerOrders RPC)
        {
            try
            {
                var addCustome = db.CustomerOrders.Add(RPC);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteCustomerOrders(string id)
        {
            try
            {
                db.CustomerOrders.Remove(db.CustomerOrders.Find(id));
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditCustomerOrders(string id, CustomerOrders RPC)
        {

            var findIdCustomerOrders = db.CustomerOrders.Find(id);
            if (findIdCustomerOrders != null)
            {
                findIdCustomerOrders.OrderItem = RPC.OrderItem;
                findIdCustomerOrders.Customer = RPC.Customer;
                findIdCustomerOrders.CustomerId = RPC.CustomerId;
                findIdCustomerOrders.OderPlaceDatatime = RPC.OderPlaceDatatime;
                findIdCustomerOrders.OrderDeliveDatatime = RPC.OrderDeliveDatatime;
                findIdCustomerOrders.OrderId = RPC.OrderId;
                findIdCustomerOrders.OrderItem = RPC.OrderItem;
                findIdCustomerOrders.OrderShoppingCharges = RPC.OrderShoppingCharges;
                findIdCustomerOrders.OrderStatusCode = RPC.OrderStatusCode;
                findIdCustomerOrders.OtherOrtherDetails = RPC.OtherOrtherDetails;
                findIdCustomerOrders.ShippingMethodCode = RPC.ShippingMethodCode;

                db.SaveChanges();
                return true;
            }
            else
            {

                return false;
            }



        }

        public IEnumerable<CustomerOrders> getAllCustomerOrders()
        {
            return db.CustomerOrders.ToList();
        }

        public CustomerOrders getFindIDCustomerOrders(string id)
        {
            return db.CustomerOrders.Find(id);
        }

        public IEnumerable<CustomerOrders> PagingAndFilterCustomerOrders(int pageSize, int pazeNow, string filter, bool sortBy)
        {
            PagingCustomerOrder pagingCustomerOrder = new PagingCustomerOrder();
            IEnumerable<CustomerOrders> listCustomerOrders = pagingCustomerOrder.PaginationGeneral(pageSize,pazeNow,sortBy,filter,db);
            return listCustomerOrders;
        }
    }
}
