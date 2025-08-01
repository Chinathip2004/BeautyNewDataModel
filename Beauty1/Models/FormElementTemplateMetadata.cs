namespace Beauty1.Models
{
    public partial class FormElementTemplate : ComponentElement
    {
        public FormElementTemplate Create(CustomContext custom)
        {
            FormElementTemplate ff = null;

            if (this.Type == "FormLabelTemplate")
            {
                FormLabelTemplate la = new FormLabelTemplate();
                la.LabelText = this.FormLabelTemplate.LabelText;
                la.Type = this.Type;
                FormElementTemplate lf = (FormElementTemplate)la;
                //ComponentElement ee = (ComponentElement)lf;
                ff = lf;
                custom.Add(lf);
                custom.SaveChanges();
                //this.Id = ee.Id;
            }

            return ff ?? this;
        }
    }
}
