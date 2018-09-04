using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testdbfirst.Models;
using testdbfirst.Repository.IRepository;

namespace testdbfirst.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigins")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItem _resOrderItem;
        public OrderItemController(IOrderItem OrderItem)
        {
            _resOrderItem = OrderItem;

        }

        const string _errorAdd = "19971";
        const string _errorEdit = "19972";
        const string _errorDelete = "19973";
        const string _errorRead = "19974";

        [HttpGet("getAllOrderItem/oderId")]
        public ActionResult<OrderItem> getAllOrderItem(string oderId)
        {
            try
            {
                var listOrderItem = _resOrderItem.getAllOrderItem(oderId);
                return Ok(listOrderItem);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }

        [HttpPost("createOrderItem")]
        public ActionResult<OrderItem> createCustomer([FromBody] OrderItem RPC)
        {

            bool boolAdd = _resOrderItem.CreateOrderItem(RPC);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorAdd);


        }

        [HttpPut("editOrderItem/orderId/productId/quantity/productChange")]
        public ActionResult<OrderItem> editCustomer(string orderId, string productId, int quantity,string productChange)
        {

            bool boolAdd = _resOrderItem.EditOrderItem(orderId, productId, quantity, productChange);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorEdit);


        }

        [HttpDelete("deleteOrderItem/orderId/productId")]
        public ActionResult<OrderItem> deleteOrderItem(string orderId, string productId)
        {

            bool boolAdd = _resOrderItem.deleteOrderItem(orderId, productId);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorDelete);


        }

        [HttpGet("getFindIDOrderItem/orderId/productId")]
        public ActionResult<Customer> getFindIDOrderItem(string orderId,string productId)
        {
            try
            {
                var RPC = _resOrderItem.getFindIDOrderItem(orderId, productId);
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
           

        }
    
}