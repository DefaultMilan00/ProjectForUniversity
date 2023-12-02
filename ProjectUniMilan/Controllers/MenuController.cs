using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectUniMilan.Data;
using ProjectUniMilan.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectUniMilan.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ApiContext _context;

        public MenuController(ApiContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Menu menu)
        {
            if (menu.Id == 0)
            {
                _context.Menus.Add(menu);
            }
            else
            {
                var MenuInDb = _context.Menus.Find(menu.Id);
                if (MenuInDb == null)
                    return new JsonResult(NotFound());

                MenuInDb = menu;

            }
            _context.SaveChanges();
            return new JsonResult(Ok(menu));
        }
        //Get

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Menus.Find(id);

            if (result == null) return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Menus.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Menus.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

        //Get all

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Menus.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
