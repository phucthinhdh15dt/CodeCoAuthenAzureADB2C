using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testdbfirst.Models;

namespace testdbfirst.MethodUseGeneral.ImplementMethodUseGeneral
{
    public class PagingCustomerOrder
    {
        public IEnumerable<CustomerOrders> PaginationGeneral(int sizePagination, int nowPagination, bool dest, string filter, ProductOderDemoContext db)
        {
            List<CustomerOrders> listCustomerOrders = new List<CustomerOrders>();
            ProductOderDemoContext productContext = db;


            using (productContext = new ProductOderDemoContext())
            {

                int totalRecords = productContext.Customer.Count();
                int skipRow = (nowPagination - 1) * sizePagination;
                if (dest)
                {
                    listCustomerOrders = productContext.CustomerOrders
                    .Skip(skipRow).Take(sizePagination)
                    .ToList();
                }
                if (filter != null && filter != "")
                {
                    //    if(sizePagination==0 && nowPagination == 0)
                    //    {
                    //    listProduct = productContext.Product
                    //         .Where(p => p.ProductName.Contains(filter) || p.OtherProductDetails.Contains(filter)
                    //             || p.ProductCategoryCode.Contains(filter)
                    //         )
                    //         .ToList();
                    //}
                    if (sizePagination != 0 && nowPagination != 0)
                    {
                        if (!filter.Equals("") || filter != null)
                        {
                            if (filter.Equals("ALL"))
                            {
                                return productContext.CustomerOrders
                                        .Skip(skipRow).Take(sizePagination)
                                        .ToList();
                            }
                            else
                            {
                                return productContext.CustomerOrders
                                        .Where(p => (p.OderPlaceDatatime + "").Contains(filter) || p.OrderId.Contains(filter)
                                            || p.CustomerId.Contains(filter) || p.CustomerId.Contains(filter)
                                            || (p.OderPlaceDatatime + "").Contains(filter) || p.OrderId.Contains(filter)
                                            || p.OrderShoppingCharges.Contains(filter)
                                             || p.OrderStatusCode.Contains(filter)
                                              || p.OtherOrtherDetails.Contains(filter)
                                              || p.ShippingMethodCode.Contains(filter)

                                        )
                                        .Skip(skipRow).Take(sizePagination)
                                        .ToList();
                            }
                        }



                    }
                    if (sizePagination == 0 && nowPagination == 0 && filter.Equals("ALL"))
                    {
                        return productContext.CustomerOrders.ToList();
                    }
                    else
                    {
                        return new List<CustomerOrders>();
                    }

                }

            }
            return listCustomerOrders;
        }

        public int CountCustomerOrdersFilter(string filter, ProductOderDemoContext db, bool conditionCount)
        {

            ProductOderDemoContext productContext = db;
            if (conditionCount)
            {

                int count = db.CustomerOrders.Where(p => (p.OderPlaceDatatime+"").Contains(filter) || p.OrderId.Contains(filter)
                                            || p.CustomerId.Contains(filter) || p.CustomerId.Contains(filter)
                                            || (p.OderPlaceDatatime+"").Contains(filter) || p.OrderId.Contains(filter)
                                            || p.OrderShoppingCharges.Contains(filter)
                                             || p.OrderStatusCode.Contains(filter)
                                              || p.OtherOrtherDetails.Contains(filter)
                                              || p.ShippingMethodCode.Contains(filter)

                                        ).Count();
                return count;
            }
            else
            {
                int count = db.CustomerOrders.Count();
                return count;
            }

        }
    }
}
