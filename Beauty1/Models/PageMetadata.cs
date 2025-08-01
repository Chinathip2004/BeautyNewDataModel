namespace Beauty1.Models
{
    public partial class Page
    {
        public Page Create(CustomContext custom, Event e)
        {
            this.EventId = e.Id;
            Page p = new Page();
            p.Name = "Page";
            Component pc = (Component)this;
            custom.Add(pc);
            custom.SaveChanges();

            foreach(var c in this.Containings)
            {
                c.ContainerId = pc.Id;
                c.Create(custom, pc);
            }

            return this;
        }
    }
}
