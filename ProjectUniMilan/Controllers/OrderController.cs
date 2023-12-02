using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectUniMilan.Data;
using ProjectUniMilan.Models;

namespace ProjectUniMilan.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApiContext _context;

        public OrderController(ApiContext context)
        {
            _context = context;
        }
        [HttpPost]

        //Create and Edit
        public JsonResult CreateEdit(Order order)
        {
            if (order.Id == 0)
            {
                _context.Orders.Add(order);
            }
            else
            {
                var OrderInDb = _context.Orders.Find(order.Id);
                if (OrderInDb == null)
                    return new JsonResult(NotFound());

                OrderInDb = order;

            }
            _context.SaveChanges();
            return new JsonResult(Ok(order));
        }
        //Get

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Orders.Find(id);

            if (result == null) return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Orders.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Orders.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

        //Get all

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Orders.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
