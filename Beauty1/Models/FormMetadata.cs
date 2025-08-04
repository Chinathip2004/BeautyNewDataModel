namespace Beauty1.Models
{
    public partial class Form
    {
        public Form Create(CustomContext custom, int? id)
        {
            Component c = custom.Components.Where(c => c.FormTemplate.Id == id).FirstOrDefault();

            this.FormTemplateId = c.Id;
            custom.Forms.Add(this);
            custom.SaveChanges();

            FormComponent fc = new FormComponent();
            fc.FormId = this.Id;
            fc.Create(custom, this);

            return this;
        }
    }
}
