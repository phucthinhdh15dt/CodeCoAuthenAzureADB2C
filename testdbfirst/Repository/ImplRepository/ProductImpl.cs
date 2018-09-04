using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testdbfirst.MethodUseGeneral.ImplementMethodUseGeneral;

using testdbfirst.Models;


namespace testdbfirst.Repository.ImplRepository
{
    public class ProductImpl : IProduct
    {
        ProductOderDemoContext db = new ProductOderDemoContext();


        //CRUD PRODUCT ...
        #region
        public bool CreateProduct(Product RPC)
        {
            try
            {
                var addCustome = db.Product.Add(RPC);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteProduct(string id)
        {
            try
            {
                db.Product.Remove(db.Product.Find(id));
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                return false;
            }
        }

        public bool EditProduct(string id, Product RPC)
        {

            var findIdProduct = db.Product.Find(id);
            if (findIdProduct != null)
            {
                
             
                findIdProduct.ProductCategoryCode= RPC.ProductCategoryCode;
                findIdProduct.OtherProductDetails = RPC.OtherProductDetails;
                findIdProduct.ProductId= RPC.ProductId;
                findIdProduct.ProductName= RPC.ProductName;
                findIdProduct.ProductPrice = RPC.ProductPrice;
                
                db.SaveChanges();
                return true;
            }
            else
            {

                return false;
            }



        }

        public IEnumerable<Product> getAllProduct()
        {
            return db.Product.ToList();
        }

        public Product getFindIDProduct(string id)
        {
            return db.Product.Find(id);
        }



        #endregion

        //PAGING AND FILTER PRODUCT
        #region
        public IEnumerable<Product> PagingAndFilterProduct(int pageSize, int pazeNow, string filter,bool sortBy)
        {
            PaginationImpl p = new PaginationImpl();
            IEnumerable<Product> listProduct= p.PaginationGeneral(pageSize,pazeNow,sortBy,filter,db);
            return listProduct;
        }


        public int CountProductFilter(string filter, bool conditionCount)
        {
            if (filter.Equals(""))
            {
                return 0;
            }
            PaginationImpl p = new PaginationImpl();
            return p.CountProductFilter(filter,db,conditionCount);
        }

        #endregion

        public IEnumerable<String> testLoading()
        {
            ProductOderDemoContext db = new ProductOderDemoContext();

            var testGroupBy = db.Product.GroupBy(s => s.ProductName);
            List<String> list = new List<String>();
            Hashtable ht = new Hashtable();
            
            foreach (var item in testGroupBy)
            {
                ht[item.Key] = list;
            }

            return list;

        }

        
    }
}
