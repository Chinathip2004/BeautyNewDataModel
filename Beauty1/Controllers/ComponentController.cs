using Beauty1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost("CopyForm")]
        public ActionResult CreateCopy(int? id)
        {
            Form f = new Form();
            f.Create(_context, id);
            return Ok();
        }

        
        [HttpGet("GetAll")]
        public ActionResult  GetAll()
        {
            var e = _context.Events.Where(f => f.IsDelete == false).ToList();

            return Ok(e);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            Event e = Event.GetById(_context, id);
            if(e != null)
            {
                e.Delete(_context);
            }
            _context.SaveChanges();
            return Ok(e);
        }

        [HttpGet("GetById")]
        public ActionResult GetById(int? id)
        {
            Event ev = Event.GetById(_context, id);

            var setting = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var json = JsonConvert.SerializeObject(ev, setting);
            return Ok(json);
        }

        [HttpPut]
        public ActionResult Update([FromBody]string halo)
        {
            Event ev = JsonConvert.DeserializeObject<Event>(halo);
            ev.Update(_context,ev);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("Duplicate")]
        public ActionResult Duplicate(int? id)
        {
            Event ee = new Event();
            ee.Copy(_context, id);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("Search")]
        public ActionResult Search(string name)
        {
            List<Event> events = Event.search(_context, name);
            if(events.Count == 0)
            {
                return NotFound("NotFound This Event");
            }
            return Ok(events);
            
        }
    }
}
