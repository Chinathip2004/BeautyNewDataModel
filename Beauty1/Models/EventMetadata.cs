using System.ComponentModel.DataAnnotations.Schema;

namespace Beauty1.Models
{
    public partial class Event
    {
        [NotMapped]
        public Component com { get; set; }
        public Event Create(CustomContext custom)
        {
            custom.Events.Add(this);
            custom.SaveChanges();


            if (com != null)
            {
                Page page = new Page
                {
                    Name = com.Name,
                    Containings = com.Containings,
                    EventId = this.Id

                };
                page.Create(custom, this);

            }




            return this;
        }
    }
}
