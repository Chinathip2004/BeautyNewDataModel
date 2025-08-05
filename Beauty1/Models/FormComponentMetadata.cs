namespace Beauty1.Models
{
    public partial class FormComponent
    {
        public FormComponent Create(CustomContext custom, Form form)
        {
            

            List<FormComponentTemplate> ff = custom.FormComponentTemplates.Where(f => f.FormId == form.FormTemplateId).ToList();


            foreach(var d in ff)
            {
                FormComponent ddd = new FormComponent();
                ddd.FormComponentTemplateId = d.Id;
                ddd.FormId = form.Id;
                custom.Add(ddd);
                custom.SaveChanges();

                List<CombineFormElementTemplate> cc = custom.CombineFormElementTemplates.Where(fff => fff.FormComponentId == d.Id).ToList();
                foreach(var c in cc)
                {
                    FormCombineElement f1 = new FormCombineElement();
                    f1.FormComponentId = ddd.Id;
                    f1.Create(custom, c.FormElementId);
                }
            }
            //this.FormComponentTemplateId = ff.Id;
            //custom.FormComponents.Add(this);
            //custom.SaveChanges();

            


            return this;
        }
    }
}
