namespace Beauty1.Models
{
    public partial class ComponentElement
    {
        public ComponentElement Create(CustomContext custom)
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
            if(this.Name == "Picture")
            {
                Picture pig = new Picture();
                pig.ImageId = this.Picture.ImageId;
                pig.ImageUrl = this.Picture.ImageUrl;
                ComponentElement p = (ComponentElement)pig;
                custom.Add(p);
                custom.SaveChanges();
                this.Id = p.Id;
            }

            if(this.Name == "NumberTable")
            {
                NumberTable nb = new NumberTable();
                nb.NumberValue = this.NumberTable.NumberValue;
                ComponentElement d = (ComponentElement)nb;
                custom.Add(d);
                custom.SaveChanges();
                this.Id = d.Id;
            }

            if(this.Name == "DateTimeTable")
            {
                DateTimeTable dt = new DateTimeTable();
                dt.DateTimeValue = this.DateTimeTable.DateTimeValue;
                ComponentElement dc = (ComponentElement)dt;
                custom.Add(dc);
                custom.SaveChanges();
                this.Id = dc.Id;
            }


            //if(this.Name == "FormElementTemplate")
            //{
            //    FormElementTemplate f = FormElementTemplate.Create(custom);
            //    f.Name = this.Name;
            //    this.Id = (f as ComponentElement).Id;
                
            //}

            return this;
        }
    }
}
