using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testdbfirst.Models;

namespace testdbfirst.MethodUseGeneral.ImplementMethodUseGeneral
{
    public class PagingCustomer
    {
        public IEnumerable<Customer> PaginationGeneral(int sizePagination, int nowPagination, bool dest, string filter, ProductOderDemoContext db)
        {
            List<Customer> listCustomer = new List<Customer>();
            ProductOderDemoContext productContext = db;


            using (productContext = new ProductOderDemoContext())
            {

                int totalRecords = productContext.Customer.Count();
                int skipRow = (nowPagination - 1) * sizePagination;
                if (dest)
                {
                    listCustomer = productContext.Customer
                    .Skip(skipRow).Take(sizePagination)
                    .ToList();
                }
                if (filter != null && filter != "")
                {
                   
                    if (sizePagination != 0 && nowPagination != 0)
                    {
                        if (!filter.Equals("") || filter != null)
                        {
                            if (filter.Equals("ALL"))
                            {
                                return productContext.Customer
                                        .Skip(skipRow).Take(sizePagination)
                                        .ToList();
                            }
                            else
                            {
                                return productContext.Customer
                                        .Where(p => p.CustomerAddress.Contains(filter) || p.CustomerEmail.Contains(filter)
                                            || p.CustomerId.Contains(filter) || p.CustomerLogin.Contains(filter)
                                            || p.CustomerName.Contains(filter) || (p.CustomerPhone+"").Contains(filter)
                                            || p.CustomerPassword.Contains(filter) 

                                        )
                                        .Skip(skipRow).Take(sizePagination)
                                        .ToList();
                            }
                        }



                    }
                    if (sizePagination == 0 && nowPagination == 0 && filter.Equals("ALL"))
                    {
                        return productContext.Customer.ToList();
                    }
                    else
                    {
                        return new List<Customer>();
                    }

                }

            }
            return listCustomer;
        }

        public int CountProductFilter(string filter, ProductOderDemoContext db, bool conditionCount)
        {

            ProductOderDemoContext productContext = db;
            if (conditionCount)
            {

                int count = db.Product.Where(c => c.ProductCategoryCode.Contains(filter) || c.ProductName.Contains(filter)
                                      || c.OtherProductDetails.Contains(filter)
                ).Count();
                return count;
            }
            else
            {
                int count = db.Product.Count();
                return count;
            }

        }
    }
}
