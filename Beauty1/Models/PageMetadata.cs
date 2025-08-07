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
    }
}
