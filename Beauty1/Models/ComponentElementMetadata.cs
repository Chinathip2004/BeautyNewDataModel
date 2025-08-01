namespace Beauty1.Models
{
    public partial class ComponentElement
    {
        public ComponentElement     Create(CustomContext custom)
        {
            //ComponentElement ce = (ComponentElement)this;
            //custom.Add(ce);
            //custom.SaveChanges();

            if(this.Name == "Button")
            {
                Button bo = new Button();
                bo.ButtonText = this.Button.ButtonText;
                bo.ButtonUrl = this.Button.ButtonUrl;
                bo.IsActive = this.Button.IsActive;
                bo.Name = this.Name;
                ComponentElement be = (ComponentElement)bo;
                custom.Add(be);
                custom.SaveChanges();
                this.Id = be.Id;
            }
            if(this.Name == "Text")
            {
                Text t = new Text();
                t.TextValue = this.Text.TextValue;
                t.Name = this.Name;
                ComponentElement te = (ComponentElement)t;
                custom.Add(te);
                custom.SaveChanges();
                this.Id = te.Id;
            }
            if(this.Name == "FormElementTemplate")
            {
                FormElementTemplate f = FormElementTemplate.Create(custom);
                f.Name = this.Name;
                this.Id = (f as ComponentElement).Id;
                
            }

            return this;
        }
    }
}
