using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testdbfirst.Authen;
using testdbfirst.Models;
using testdbfirst.Repository.ImplRepository;

namespace testdbfirst.Controllers
{
    
    [Route("api/[controller]")]
    //[EnableCors("AllowSpecificOrigins")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class RefProductCategoriesController : ControllerBase
    {
        
        private readonly IRefProductCategories _resRefProductCategories;
        private String setToken()
        {
            return HttpContext.User.FindFirst("http://schemas.microsoft.com/identity/claims/scope")?.Value;
        }
        public RefProductCategoriesController(IRefProductCategories RefProductCategories)
        {
            _resRefProductCategories = RefProductCategories;
           
        }

        const string _errorAdd = "19971";
        const string _errorEdit = "19972";
        const string _errorDelete = "19973";
        const string _errorRead = "19974";
        [Authorize]
        [HttpGet("getAllRefProductCategories")]
        public ActionResult<ProductOderDemoContext> getAllRefProductCategories()
        {
            
            if (AuthorizeSetController.setAuthorize(setToken()))
            {
                return Ok(_resRefProductCategories.getAllRefProductCategories());
            }
            else
            {
                return Unauthorized();
            }
               
            

        }

        [HttpPost("createRefProductCategories")]
        public ActionResult<RefProductCategories> createRefProductCategories([FromBody] RefProductCategories RPC)
        {
            
                bool boolAdd = _resRefProductCategories.CreateRefProductCategories(RPC);
                if (boolAdd) {
                return Ok(boolAdd);
                    }
                return Ok(_errorAdd);
            

        }

        [HttpPut("editRefProductCategories/id")]
        public ActionResult<RefProductCategories> editRefProductCategories([FromBody] RefProductCategories RPC,string id)
        {

            bool boolAdd = _resRefProductCategories.EditRefProductCategories(id,RPC);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorEdit);


        }

        [HttpDelete("deleteRefProductCategories")]
        public ActionResult<ProductOderDemoContext> deleteRefProductCategories(string id)
        {

            bool boolAdd = _resRefProductCategories.deleteRefProductCategories(id);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorDelete);


        }

        [HttpGet("getFindIDRefProductCategories/id")]
        public ActionResult<ProductOderDemoContext> getFindIDRefProductCategories(string id)
        {
            try
            {
                var RPC = _resRefProductCategories.getFindIDRefProductCategories(id);
                return Ok(RPC);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }


        [HttpGet("FilterCategory/{pageSize}/{pageNow}/{stringFilter}")]
        public ActionResult<ProductOderDemoContext> filter(int pageSize, int pageNow, string stringFilter)
        {
            try
            {
                var listcatelogy = _resRefProductCategories.PagingAndFilterRefProductCategories(pageSize, pageNow, stringFilter, false);
                return Ok(listcatelogy);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }


        [HttpGet("CountCategoryFilter/{stringFilter}/{conditionCount}")]
        public ActionResult<int> CountProductFilter(string stringFilter, bool conditionCount)
        {
            try
            {
                int countFilter = _resRefProductCategories.CountRefProductCategoriesFilter(stringFilter, conditionCount);
                return Ok(countFilter);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }

    }
}
