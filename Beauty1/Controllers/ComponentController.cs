using Beauty1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Beauty1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly CustomContext _context;

        public ComponentController(CustomContext context)
        {
            _context = context;
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] string Halo)
        {
            Event ev = JsonConvert.DeserializeObject<Event>(Halo);
            ev.Create(_context);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public ActionResult CreateCopy(int? id)
        {

            Form f = new Form();
            f.Create(_context, id);
            return Ok();
        }
    }
}
