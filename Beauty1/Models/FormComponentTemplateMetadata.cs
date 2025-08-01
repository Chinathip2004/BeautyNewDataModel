namespace Beauty1.Models
{
    public partial class FormComponentTemplate
    {
        public FormComponentTemplate Create(CustomContext custom, Component component)
        {
            this.FormId = component.Id;
            custom.FormComponentTemplates.Add(this);
            custom.SaveChanges();

            foreach(var cbf in this.CombineFormElementTemplates)
            {
                cbf.FormComponentId = this.Id;
                cbf.Create(custom, this);
            }

            return this;
        }
    }
}
