using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testdbfirst.Models;
using testdbfirst.Repository.ImplRepository;

namespace testdbfirst.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigins")]
    [ApiController]
    [Produces("application/json")]

    public class ProductController : ControllerBase
    {

        private readonly IProduct _resProduct;
        public ProductController(IProduct Product)
        {
            _resProduct = Product;
            
        }

        const string _errorAdd = "19971";
        const string _errorEdit = "19972";
        const string _errorDelete = "19973";
        const string _errorRead = "19974";

        [HttpGet("getAllProduct")]
        public ActionResult<Product> getAllProduct()
        {
            try
            {
                var listProduct = _resProduct.getAllProduct();
                return Ok(listProduct);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }

        [HttpPost("createProduct")]
        public ActionResult<Product> createProduct([FromBody] Product RPC)
        {
            if(RPC.ProductId.Equals("") || RPC.ProductName.Equals("")
                || RPC.OtherProductDetails.Equals(""))
            {
                return Ok("Co truong chua nhap du lieu");
            }
            
                bool boolAdd = _resProduct.CreateProduct(RPC);
                if (boolAdd) {
                return Ok(boolAdd);
                    }
                return Ok(_errorAdd);
            

        }

        [HttpPut("editProduct/id")]
        public ActionResult<Product> editProduct([FromBody] Product RPC,string id)
        {
            if (RPC.ProductId.Equals("") || RPC.ProductName.Equals("")
               || RPC.OtherProductDetails.Equals(""))
            {
                return Ok("Co truong chua nhap du lieu");
            }

            bool boolAdd = _resProduct.EditProduct(id,RPC);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorEdit);


        }

        [HttpDelete("deleteProduct")]
        public ActionResult<Product> deleteProduct(string id)
        {

            bool boolAdd = _resProduct.deleteProduct(id);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorDelete);


        }

        [HttpGet("getFindIDProduct/id")]
        public ActionResult<Product> getFindIDProduct(string id)
        {
            
           
                var RPC = _resProduct.getFindIDProduct(id);
                return Ok(RPC);
            
            

        }


       

        [HttpGet("FilterProduct/{pageSize}/{pageNow}/{stringFilter}")]
        public ActionResult<Product> filter(int pageSize, int pageNow,string stringFilter)
        {
            try
            {
                var listProduct = _resProduct.PagingAndFilterProduct(pageSize, pageNow, stringFilter, false);
                return Ok(listProduct);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }


        [HttpGet("CountProductFilter/{stringFilter}/{conditionCount}")]
        public ActionResult<int> CountProductFilter(string stringFilter, bool conditionCount)
        {
            try
            {
                int countFilter = _resProduct.CountProductFilter(stringFilter,conditionCount);
                return Ok(countFilter);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }

        [HttpGet("testEagerLoading")]
        public ActionResult<String> testEagerLoading()
        {
            try
            {

                return Ok(_resProduct.testLoading());
                
                
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }


    }
}