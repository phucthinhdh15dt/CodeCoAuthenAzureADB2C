using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using testdbfirst.Models;

namespace testdbfirst.MethodUseGeneral.ImplementMethodUseGeneral
{
    public class PaginationImpl 
    {
        
        public IEnumerable<Product> PaginationGeneral(int sizePagination, int nowPagination, bool dest, string filter, ProductOderDemoContext db)
        {
            List<Product> listProduct = new List<Product>();
            ProductOderDemoContext productContext = db;


                using (productContext=new ProductOderDemoContext())
                {
                 
                   int totalRecords = productContext.Product.Count();
                    int skipRow = (nowPagination - 1) * sizePagination;
                    if (dest)
                    {
                        listProduct = productContext.Product
                        .Skip(skipRow).Take(sizePagination)
                        .ToList();
                    }
                    if (filter != null && filter != "")
                    {
                 
                    if (sizePagination != 0 && nowPagination != 0)
                    {
                        if (!filter.Equals("") || filter!=null)
                        {
                            if (filter.Equals("ALL"))
                            {
                                return productContext.Product
                                        .Skip(skipRow).Take(sizePagination)
                                        .ToList();
                            }
                            else
                            {
                                return productContext.Product
                                        .Where(p => p.ProductName.Contains(filter) || p.OtherProductDetails.Contains(filter)
                                            || p.ProductCategoryCode.Contains(filter) || (p.ProductPrice+"").Contains(filter)

                                        )
                                        .Skip(skipRow).Take(sizePagination)
                                        .ToList();
                            }
                        }
                       


                    }
                    if(sizePagination==0 && nowPagination==0 && filter.Equals("ALL"))
                    {
                      return  productContext.Product.ToList();
                    }
                    else
                    {
                        return  new List<Product>();
                    }
                          
                     }

            }
            return listProduct;
        }

            public int CountProductFilter(string filter , ProductOderDemoContext db,bool conditionCount)
        {

            ProductOderDemoContext productContext = db;
            if (conditionCount)
            {

                int count = db.Product.Where(c => c.ProductCategoryCode.Contains(filter) || c.ProductName.Contains(filter)
                                      || c.OtherProductDetails.Contains(filter) || (c.ProductPrice + "").Contains(filter)
                ).Count();
                return count;
            }
            else
            {
                int count = db.Product.Count();
                return count;
            }

        }
        

        //public IEnumerable<Product> PaginationGeneral(int sizePagination, int nowPagination, bool dest, string filter, ProductOderDemoContext db)
        //{

        //}
    }
}
