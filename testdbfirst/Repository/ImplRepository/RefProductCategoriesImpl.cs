using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testdbfirst.MethodUseGeneral.ImplementMethodUseGeneral;
using testdbfirst.Models;


namespace testdbfirst.Repository.ImplRepository
{
    public class RefProductCategoriesImpl : IRefProductCategories
    {
        ProductOderDemoContext db = new ProductOderDemoContext();
        PagingCategory pagingCategory;

        public int CountRefProductCategoriesFilter(string filter, bool conditionCount)
        {
            pagingCategory = new PagingCategory();
            int countCatelogy= pagingCategory.CountProductFilter(filter, db, conditionCount);
            return countCatelogy;
        }

        public bool CreateRefProductCategories(RefProductCategories RPC)
        {
            try
            {
                var addCustome = db.RefProductCategories.Add(RPC);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteRefProductCategories(string id)
        {
            try
            {
                db.RefProductCategories.Remove(db.RefProductCategories.Find(id));
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditRefProductCategories(string id, RefProductCategories RPC)
        {
            
            var findIdRefProductCategories = db.RefProductCategories.Find(id);
            if (findIdRefProductCategories != null)
            {
                findIdRefProductCategories.ProductCategoryDescription = RPC.ProductCategoryDescription;
                db.SaveChanges();
                return true;
            }
            else
            {

                return false;
            }

          
           
        }

        public IEnumerable<RefProductCategories> getAllRefProductCategories()
        {
            return db.RefProductCategories.ToList();
        }

        public RefProductCategories getFindIDRefProductCategories(string id)
        {
            return db.RefProductCategories.Find(id);
        }

        public IEnumerable<RefProductCategories> PagingAndFilterRefProductCategories(int pageSize, int pazeNow, string filter, bool sortBy)
        {
            PagingCategory pagingCategory = new PagingCategory();
            IEnumerable<RefProductCategories> listCatelogy= pagingCategory.PaginationGeneral(pageSize, pazeNow, sortBy, filter, db);
            return listCatelogy;
        }

        
    }
}
