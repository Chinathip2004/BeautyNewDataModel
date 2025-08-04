namespace Beauty1.Models
{
    public partial class FormElement
    {
        public FormElement Create(CustomContext custom, int? id)
        {
            this.FormElementTemplateId = id;
            custom.Add(this);
            custom.SaveChanges();

            return this;
        }
    }
}
