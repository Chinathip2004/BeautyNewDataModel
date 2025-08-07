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
    }
}
