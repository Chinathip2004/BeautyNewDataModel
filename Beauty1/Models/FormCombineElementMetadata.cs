namespace Beauty1.Models
{
    public partial class FormCombineElement
    {
        public FormCombineElement Create(CustomContext custom, int? id)
        {
            ComponentElement ff = custom.ComponentElements.Where(f => f.Id == id).FirstOrDefault();
            
            FormElement fe = new FormElement();
            fe.Create(custom, ff.Id);

            this.FormElementId = fe.Id;
            custom.Add(this);
            custom.SaveChanges();



            return this;
        }
    }
}
