using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testdbfirst.Models;

namespace testdbfirst.Repository.ImplRepository
{
    public interface IProduct
    {
        IEnumerable<Product> getAllProduct();
        Product getFindIDProduct(string id);
        bool CreateProduct(Product RPC);
        bool EditProduct(string id, Product RPC);
        bool deleteProduct(string id);
        IEnumerable<Product> PagingAndFilterProduct(int pageSize ,int pazeNow ,string filter,bool sortBy);
        int CountProductFilter(string filter, bool conditionCount);
        IEnumerable<String> testLoading();
    }
}
