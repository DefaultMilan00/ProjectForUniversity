using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectUniMilan.Data;
using ProjectUniMilan.Models;
namespace ProjectUniMilan.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        private readonly ApiContext _context;

        public FoodItemController(ApiContext context)
        {
            _context = context;
        }

        //Create/Edit

        [HttpPost]
        public JsonResult CreateEdit(FoodItem fooditem)
        {
            if(fooditem.Id == 0)
            {
                _context.FoodItems.Add(fooditem);
            }
            else
            {
                var FooditemInDb = _context.FoodItems.Find(fooditem.Id);
                if (FooditemInDb == null)               
                    return new JsonResult(NotFound());

                FooditemInDb = fooditem;               
                
            }
            _context.SaveChanges();
            return new JsonResult(Ok(fooditem));
        }
        //Get

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.FoodItems.Find(id);

            if(result == null) return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete (int id)
        {
            var result = _context.FoodItems.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.FoodItems.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

        //Get all

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.FoodItems.ToList();

            return new JsonResult(Ok(result));
        }

    }
}
