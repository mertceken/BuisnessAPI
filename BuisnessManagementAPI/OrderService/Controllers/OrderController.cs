using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        DatabaseContext db_;

        public OrderController()
        {
            db_ = new DatabaseContext();    
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return db_.Orders.ToList();    
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return db_.Orders.Find(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] Order orderModel)
        {
            try
            {
                db_.Orders.Add(orderModel);
                db_.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, orderModel);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, orderModel);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order orderModel)
        {
            var orderDetail = (from a in db_.Orders where a.Id == orderModel.Id select a).FirstOrDefault();

            if (orderDetail!=null)
            {
                orderDetail.CustomerID = orderModel.CustomerID;
                orderDetail.Quantity = orderModel.Quantity;
                orderDetail.Price = orderModel.Price;
                orderDetail.Product = orderModel.Product;
                orderDetail.Address = orderModel.Address;
                orderDetail.CreatedTime = orderModel.CreatedTime;
                orderDetail.UpdatedTime = orderModel.UpdatedTime;
                db_.SaveChanges();

                return Ok(orderModel);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, orderModel);
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var orderDelete = (from a in db_.Orders where a.Id == id select a).FirstOrDefault();

                if (orderDelete!=null)
                {
                    db_.Orders.Remove(orderDelete);
                    db_.SaveChanges();
                    return Ok(orderDelete);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, orderDelete);
                }

            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,id);
            }
        }
    }
}
