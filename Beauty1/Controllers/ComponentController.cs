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

        [HttpPost]
        public ActionResult CreateCopy(int? id)
        {

            Form f = new Form();
            f.Create(_context, id);
            return Ok();
        }

        [HttpGet("GetById")]
        public ActionResult GetById(int? id)
        {
            var ev = _context.Events.Where(w => w.Id == id).First();
            ev.Pages = _context.Pages.Where(p => p.EventId == id).ToList();

            foreach (var p in ev.Pages)
            {

                p.Containings = _context.Containings.Where(c => c.ContainerId == (p as Component).Id).ToList();

                foreach (var c in p.Containings)
                {
                    var d = c.Component = _context.Components.Where(co => co.Id == c.ComponentId).Include(c => c.CombineElements).FirstOrDefault();

                    if (d.Name == "Section")
                    {
                        
                        LoadComponent(d);
                    }
                    foreach (var ce in d.CombineElements)
                    {
                        ComponentElement dd = ce.ComponentElement = _context.ComponentElements.Where(d => d.Id == ce.ComponentElementId).FirstOrDefault();
                    }

                    if (d.Name == "FormTemplate")
                    {

                        FormTemplate ff = d.FormTemplate = _context.FormTemplates.Include(f => f.FormComponentTemplates).Where(w => w.Id == d.Id).FirstOrDefault();
                        foreach(var fc in ff.FormComponentTemplates)
                        {
                            fc.CombineFormElementTemplates = _context.CombineFormElementTemplates.Where(c => c.FormComponentId == fc.Id).ToList();

                            foreach (var Russell in fc.CombineFormElementTemplates)
                            {
                                FormElementTemplate f1 = Russell.FormElement = _context.FormElementTemplates.Where(f => f.Id == Russell.FormElementId).FirstOrDefault();
                            }
                        }

                    }

                }

            }
            var setting = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(ev, setting);


            return Ok(json);
        }



        private void LoadComponent(Component component)
        {
            if (component.Name == "Section")
            {

                Section section = _context.Sections.Where(s => s.Id == component.Id).FirstOrDefault();

                if (section != null)
                {
                    section.Containings = _context.Containings.Where(c => c.ContainerId == component.Id).ToList();
                    foreach (var con in section.Containings)
                    {
                        con.Component = _context.Components.Where(d => d.Id == con.ComponentId).Include(c => c.CombineElements).FirstOrDefault();

                        if (con.Component.Name == "Section")
                        {
                            LoadComponent(con.Component);
                        }

                        foreach (var ko in con.Component.CombineElements)
                        {
                            ComponentElement ed = ko.ComponentElement = _context.ComponentElements.Where(d => d.Id == ko.ComponentElementId).FirstOrDefault();
                        }
                    }
                }
            }
            var setting = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var json = JsonConvert.SerializeObject(component, setting);
        }

        [HttpGet("GetAll")]
        public ActionResult  GetAll()
        {
            var e = _context.Events.Where(f => f.IsFavorite == false).ToList();

            return Ok(e);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            
            


            return Ok();
        }
    }
}
