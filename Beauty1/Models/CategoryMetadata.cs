namespace Beauty1.Models
{
    public partial class Category
    {
        public Category Create(CustomContext custom)
        {
            
            custom.Categories.Add(this);

            return this;
        }
    }
}
