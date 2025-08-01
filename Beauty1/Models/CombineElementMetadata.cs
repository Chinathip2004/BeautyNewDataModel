namespace Beauty1.Models
{
    public partial class CombineElement
    {
        public CombineElement Create(CustomContext custom)
        {
            ComponentElement ce = this.ComponentElement;
            ce.Create(custom);

            

            //CombineElement cb = new CombineElement();
            //cb.ComponentId = component.Id;
            //cb.ComponentElementId = ce.Id;
            //custom.Add(cb);
            //custom.SaveChanges();




            return this;
        }
    }
}
