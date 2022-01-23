using CustomersService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        DatabaseContext db;

        public CustomerController()
        {
            db = new DatabaseContext(); 
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return db.Customers.ToList();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customerModel)
        {
            try
            {
                db.Customers.Add(customerModel);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, customerModel);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, customerModel);
                
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customerModel)
        {
            var customerDetail = (from a in db.Customers where a.Id == id select a).FirstOrDefault();   
            if (customerDetail != null)
            {
                customerModel.Name = customerDetail.Name;
                customerModel.Adress = customerDetail.Adress;
                customerModel.Email = customerDetail.Email;
                customerModel.CreatedTime = customerDetail.CreatedTime;
                customerModel.UpdatedTime = customerDetail.UpdatedTime;

                db.SaveChanges();

                return Ok(customerModel);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, customerModel);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var customerDelete = (from a in db.Customers where a.Id == id select a).FirstOrDefault();

                if (customerDelete!=null)
                {
                    db.Customers.Remove(customerDelete);
                    db.SaveChanges();
                    return Ok(customerDelete);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, customerDelete);
                }
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, id);
            }

          


        }
    }
}
