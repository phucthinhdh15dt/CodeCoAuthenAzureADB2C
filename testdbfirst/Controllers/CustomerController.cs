using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testdbfirst.Models;
using testdbfirst.Repository.ImplRepository;

namespace testdbfirst.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigins")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomer _resCustomer;
        public CustomerController(ICustomer Customer)
        {
            _resCustomer = Customer;

        }

        const string _errorAdd = "19971";
        const string _errorEdit = "19972";
        const string _errorDelete = "19973";
        const string _errorRead = "19974";

        [HttpGet("getAllCustomer")]
        public ActionResult<Customer> getAllCustomer()
        {
            try
            {
                var listCustomer = _resCustomer.getAllCustomer();
                return Ok(listCustomer);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }

        [HttpPost("createCustomer")]
        public ActionResult<Customer> createCustomer([FromBody] Customer RPC)
        {

            bool boolAdd = _resCustomer.CreateCustomer(RPC);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorAdd);


        }

        [HttpPut("editCustomer/id")]
        public ActionResult<Customer> editCustomer([FromBody] Customer RPC, string id)
        {

            bool boolAdd = _resCustomer.EditCustomer(id, RPC);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorEdit);


        }

        [HttpDelete("deleteCustomer")]
        public ActionResult<Customer> deleteCustomer(string id)
        {

            bool boolAdd = _resCustomer.deleteCustomer(id);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorDelete);


        }

        [HttpGet("getFindIDCustomer/id")]
        public ActionResult<Customer> getFindIDCustomer(string id)
        {
            try
            {
                var RPC = _resCustomer.getFindIDCustomer(id);
                if (RPC != null)
                {
                    return Ok(RPC);
                }
                else
                {

                    return Ok(_errorRead);
                }
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }

        [HttpGet("FilterCustomer/{pageSize}/{pageNow}/{stringFilter}")]
        public ActionResult<Customer> filter(int pageSize, int pageNow, string stringFilter)
        {
            try
            {
                var listCustomer = _resCustomer.PagingAndFilterCustomer(pageSize, pageNow, stringFilter, false);
                return Ok(listCustomer );
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }


        [HttpGet("CountCustomerFilter/{stringFilter}/{conditionCount}")]
        public ActionResult<int> CountCustomerFilter(string stringFilter, bool conditionCount)
        {
            try
            {
                int countFilter = _resCustomer.CountCustomerFilter(stringFilter, conditionCount);
                return Ok(countFilter);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }





    }
}
