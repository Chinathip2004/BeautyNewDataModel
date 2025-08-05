namespace Beauty1.Models
{
    public partial class EventCategorize
    {
        public EventCategorize Create(CustomContext custom)
        {
            EventCategorize ec = new EventCategorize();
            ec.EventId = this.EventId;
            ec.CategoryId = this.CategoryId;
            custom.EventCategorizes.Add(ec);
            custom.SaveChanges();


            return ec;
        }
    }
}
