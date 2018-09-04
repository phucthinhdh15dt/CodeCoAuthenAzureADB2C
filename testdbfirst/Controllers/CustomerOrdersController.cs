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
    public class CustomerOrdersController : ControllerBase
    {

        private readonly ICustomerOrders _resCustomerOrders;
        public CustomerOrdersController(ICustomerOrders CustomerOrders)
        {
            _resCustomerOrders = CustomerOrders;

        }

        const string _errorAdd = "19971";
        const string _errorEdit = "19972";
        const string _errorDelete = "19973";
        const string _errorRead = "19974";

        [HttpGet("getAllCustomerOrders")]
        public ActionResult<CustomerOrders> getAllCustomerOrders()
        {
            try
            {
                var listCustomerOrders = _resCustomerOrders.getAllCustomerOrders();
                return Ok(listCustomerOrders);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }

        [HttpPost("createCustomerOrders")]
        public ActionResult<CustomerOrders> createCustomerOrders([FromBody] CustomerOrders RPC)
        {

            bool boolAdd = _resCustomerOrders.CreateCustomerOrders(RPC);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorAdd);


        }

        [HttpPut("editCustomerOrders/id")]
        public ActionResult<CustomerOrders> editCustomerOrders([FromBody] CustomerOrders RPC, string id)
        {

            bool boolAdd = _resCustomerOrders.EditCustomerOrders(id, RPC);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorEdit);


        }

        [HttpDelete("deleteCustomerOrders")]
        public ActionResult<CustomerOrders> deleteCustomerOrders(string id)
        {

            bool boolAdd = _resCustomerOrders.deleteCustomerOrders(id);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorDelete);


        }

        [HttpGet("getFindIDCustomerOrders/id")]
        public ActionResult<CustomerOrders> getFindIDCustomerOrders(string id)
        {
            try
            {
                var RPC = _resCustomerOrders.getFindIDCustomerOrders(id);
                return Ok(RPC);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }

        [HttpGet("FilterCustomerOrders/{pageSize}/{pageNow}/{stringFilter}")]
        public ActionResult<Customer> filter(int pageSize, int pageNow, string stringFilter)
        {
            try
            {
                var listCustomer = _resCustomerOrders.PagingAndFilterCustomerOrders(pageSize, pageNow, stringFilter, false);
                return Ok(listCustomer);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }


        [HttpGet("CountCustomerOrdersFilter/{stringFilter}/{conditionCount}")]
        public ActionResult<int> CountCustomerFilter(string stringFilter, bool conditionCount)
        {
            try
            {
                int countFilter = _resCustomerOrders.CountCustomerOrdersFilter(stringFilter, conditionCount);
                return Ok(countFilter);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }




    }
}