using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testdbfirst.Models;

namespace testdbfirst.Repository.ImplRepository
{
    public interface IRefProductCategories
    {
        IEnumerable<RefProductCategories> getAllRefProductCategories();
        RefProductCategories getFindIDRefProductCategories(string id);
        bool CreateRefProductCategories(RefProductCategories RPC);
        bool EditRefProductCategories(string id, RefProductCategories RPC);
        bool deleteRefProductCategories(string id);
        IEnumerable<RefProductCategories> PagingAndFilterRefProductCategories(int pageSize, int pazeNow, string filter, bool sortBy);
        int CountRefProductCategoriesFilter(string filter, bool conditionCount);

       

    }
}
