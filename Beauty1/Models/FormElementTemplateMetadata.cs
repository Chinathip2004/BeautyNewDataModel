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
                
                ff = lf;
                custom.Add(lf);
                custom.SaveChanges();
                
            }

            if(this.Type == "FormOptionTemplate")
            {
                FormOptionTemplate op = new FormOptionTemplate();
                op.OptionValue = this.FormOptionTemplate.OptionValue;
                op.Type = this.Type;
                FormElementTemplate off = (FormElementTemplate)op;

                ff = off;
                custom.Add(off);
                custom.SaveChanges();
            }

            if(this.Type == "FormInputTextTemplate")
            {
                FormInputTextTemplate it = new FormInputTextTemplate();
                it.Type = this.Type;
                FormElementTemplate tf = (FormElementTemplate)it;

                ff = tf;
                custom.Add(tf);
                custom.SaveChanges();
            }

            if(this.Type == "FormInputDateTemplate")
            {
                FormInputDateTemplate dt = new FormInputDateTemplate();
                dt.Type = this.Type;
                FormElementTemplate df = (FormElementTemplate)dt;

                ff = df;
                custom.Add(df);
                custom.SaveChanges();
            }

            if(this.Type == "FormInputFileTemplate")
            {
                FormInputFileTemplate ft = new FormInputFileTemplate();
                ft.Type = this.Type;
                FormElementTemplate ff1 = (FormElementTemplate)ft;

                ff = ff1;
                custom.Add(ff1);
                custom.SaveChanges();
                
            }

            return ff ?? this;
        }
    }
}
