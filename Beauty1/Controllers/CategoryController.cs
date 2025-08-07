using Beauty1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beauty1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CustomContext _context;

        public CategoryController(CustomContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Create(List<DtoCategory> cat)
        {
            
            
            foreach(var d in cat)
            {
                var Cat = new Category
                {
                    Name = d.Name
                    
                };
                
                Cat.Create(_context);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
