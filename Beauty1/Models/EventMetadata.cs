using System.ComponentModel.DataAnnotations.Schema;

namespace Beauty1.Models
{
    public partial class Event
    {
        [NotMapped]
        public List<Component> com { get; set; }
        public Event Create(CustomContext custom)
        {
            Event ee = new Event();
            ee.Name = this.Name;
            ee.IsFavorite = this.IsFavorite;
            //ee.FileId = this.FileId;
            custom.Add(ee);
            custom.SaveChanges();

            foreach (var cat in this.EventCategorizes)
            {
                cat.EventId = ee.Id;
                cat.Create(custom);

            }

            if (com != null)
            {
                foreach (Component compo in com)
                {
                    Page page = new Page
                    {
                        Name = compo.Name,
                        Containings = compo.Containings,
                        EventId = ee.Id

                    };
                    page.Create(custom, ee);
                }
            }
            return this;
        }
    }
}
