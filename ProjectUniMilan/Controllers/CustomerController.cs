using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectUniMilan.Data;
using ProjectUniMilan.Models;
using Microsoft.EntityFrameworkCore;
namespace ProjectUniMilan.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApiContext _context;

        public CustomerController(ApiContext context)
        {
            _context = context;
        }
        [HttpPost]
        public JsonResult CreateEdit(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var CustomerInDb = _context.Customers.Find(customer.Id);
                if (CustomerInDb == null)
                    return new JsonResult(NotFound());

                CustomerInDb = customer;

            }
            _context.SaveChanges();
            return new JsonResult(Ok(customer));
        }
        //Get

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Customers.Find(id);

            if (result == null) return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Customers.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Customers.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

        //Get all

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Customers.ToList();

            return new JsonResult(Ok(result));
        }


    }
}
