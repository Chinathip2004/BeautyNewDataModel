namespace Beauty1.Models
{
    public partial class CombineElement
    {
        public CombineElement Create(CustomContext custom)
        {
            ComponentElement ce = this.ComponentElement;
            ce.Create(custom);

            return this;
        }

        public CombineElement Delete(CustomContext custom)
        {
            ComponentElement ce = this.ComponentElement;
            ce.Delete(custom);

            IsDelete = true;
            custom.CombineElements.Update(this);
            return this;
        }

        public CombineElement Update(CustomContext custom)
        {
            List<ComponentElement> coo = custom.ComponentElements.Where(c => c.IsDelete == true).ToList();

            foreach (var cc in coo)
            {
                cc.Delete(custom);
            }

            if (ComponentElement.Id == 0)
            {
                ComponentElement.Create(custom);
            }


            ComponentElement.Update(custom);
            ComponentElement = null;

            IsDelete = false;
            custom.Update(this);
            return this;
        }


        public CombineElement Duplicate(CustomContext custom)
        {
            ComponentElement come = this.ComponentElement.Duplicate(custom);

            

            CombineElement cb = new CombineElement();
            cb.ComponentId = this.ComponentId;
            cb.ComponentElementId = come.Id;
            cb.IsDelete = false;
            custom.Add(cb);
            custom.SaveChanges();

            return this;
        }
    }
}
