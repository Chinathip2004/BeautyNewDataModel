using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models
{
    public partial class Page
    {
        public Page Create(CustomContext custom, Event e)
        {
            
            Page p = new Page();
            p.EventId = e.Id;
            p.Name = this.Name;
            p.IsDelete = false;
            Component pc = (Component)p;
            custom.Add(pc);
            custom.SaveChanges();

            foreach (var c in this.Containings)
            {
                c.ContainerId = pc.Id;
                c.Create(custom, pc);
            }
            return this;
        }

        public Page DeletePage(CustomContext custom)
        {
            this.IsDelete = true;
            custom.Update(this);
            
            foreach (var c in this.Containings)
            {
                Component component = c.Component.Delete(custom);

                c.Delete(custom);

                if(component.Name == "Section")
                {
                    Section section = (Section)component;
                    section.DeleteSection(custom);
                }
                
            }

            return this;
        }

        public Page UpdatePage(CustomContext custom)
        {

            List<Containing> old = custom.Containings.Where(d => d.ContainerId == this.Id && d.IsDelete != true).AsNoTracking().ToList();
            

            foreach(var c in this.Containings)
            {
                if(c.Id == 0)
                {
                    c.ContainerId = this.Id;
                    c.Create(custom, this);
                }
                else
                {
                    c.Update(custom);
                }
            }

            foreach(var cc in old)
            {
                bool iinew = this.Containings.Any(c => c.Id == cc.Id);

                if(!iinew)
                {
                    Component delete = custom.Components.Where(c => c.Id == cc.ComponentId).Include(c => c.CombineElements).ThenInclude(f => f.ComponentElement).Include(f => f.FormTemplate.FormComponentTemplates).AsNoTracking().FirstOrDefault();

                    delete.Delete(custom);

                    Containing deleteCon = custom.Containings.AsNoTracking().FirstOrDefault(c => c.Id == cc.Id);

                    if(deleteCon != null)
                    {
                        deleteCon.Delete(custom);
                    }

                    if(delete.Name == "Section")
                    {
                        List<Containing> deSection = custom.Containings.Include(c => c.Component).ThenInclude(c => c.CombineElements).ThenInclude(f => f.ComponentElement).AsNoTracking().Where(c => c.ContainerId == delete.Id).ToList();

                        Section section = (Section)delete;
                        section.Containings = deSection.ToList() ?? new List<Containing>();
                        section.DeleteSection(custom);
                    }
                }
            }

            return this;
        }


        public Page DuplicatePage(CustomContext custom)
        {
            

            Page pp = new Page();
            pp.EventId = this.EventId;
            pp.Name = this.Name;
            pp.IsDelete = false;
            Component p = (Component)pp;
            custom.Add(p);
            custom.SaveChanges();

            List<Containing> containings = custom.Containings.Include(c => c.Component).ThenInclude(c=>c.CombineElements).ThenInclude(c=>c.ComponentElement)
                .Include(f =>f.Component).ThenInclude(f=>f.FormTemplate).ThenInclude(f=>f.FormComponentTemplates).ThenInclude(f=>f.CombineFormElementTemplates)
                .ThenInclude(f=>f.FormElement).Where(c => c.ContainerId == this.Id).AsNoTracking().ToList();

            foreach(var con in containings)
            {
                con.ContainerId = p.Id;
                con.Duplicate(custom, p);

            }

            return this;
        }
    }
}
