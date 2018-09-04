using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testdbfirst.Models;

namespace testdbfirst.MethodUseGeneral.ImplementMethodUseGeneral
{
    public class PagingCategory
    {
        public IEnumerable<RefProductCategories> PaginationGeneral(int sizePagination, int nowPagination, bool dest, string filter, ProductOderDemoContext db)
        {
            List<RefProductCategories> listProduct = new List<RefProductCategories>();
            ProductOderDemoContext categoriesContext = db;


            using (categoriesContext = new ProductOderDemoContext())
            {

                int totalRecords = categoriesContext.Product.Count();
                int skipRow = (nowPagination - 1) * sizePagination;
                if (dest)
                {
                    listProduct = categoriesContext.RefProductCategories
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
                                return categoriesContext.RefProductCategories
                                        .Skip(skipRow).Take(sizePagination)
                                        .ToList();
                            }
                            else
                            {
                                return categoriesContext.RefProductCategories
                                        .Where(p => p.ProductCategoryCode.Contains(filter) || p.ProductCategoryDescription.Contains(filter)
                                            

                                        )
                                        .Skip(skipRow).Take(sizePagination)
                                        .ToList();
                            }
                        }



                    }
                    if (sizePagination == 0 && nowPagination == 0 && filter.Equals("ALL"))
                    {
                        return categoriesContext.RefProductCategories.ToList();
                    }
                    else
                    {
                        return new List<RefProductCategories>();
                    }

                }

            }
            return listProduct;
        }

        public int CountProductFilter(string filter, ProductOderDemoContext db, bool conditionCount)
        {

            ProductOderDemoContext productContext = db;
            if (conditionCount)
            {

                int count = db.RefProductCategories.Where(c => c.ProductCategoryCode.Contains(filter)
                                      || c.ProductCategoryDescription.Contains(filter)
                ).Count();
                return count;
            }
            else
            {
                int count = db.RefProductCategories.Count();
                return count;
            }

        }
    }
}
