namespace Beauty1.Models
{
    public partial class ComponentElement
    {
        public ComponentElement Create(CustomContext custom)
        {
            

            if(this.Name == "Button")
            {
                Button bo = new Button();
                bo.ButtonText = this.Button.ButtonText;
                bo.ButtonUrl = this.Button.ButtonUrl;
                bo.IsActive = this.Button.IsActive;
                bo.Name = this.Name;
                bo.IsDelete = false;
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
                t.IsDelete = false;
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
                pig.Name = this.Name;
                pig.IsDelete = false;
                ComponentElement p = (ComponentElement)pig;
                custom.Add(p);
                custom.SaveChanges();
                this.Id = p.Id;
            }

            if(this.Name == "NumberTable")
            {
                NumberTable nb = new NumberTable();
                nb.NumberValue = this.NumberTable.NumberValue;
                nb.Name = this.Name;
                nb.IsDelete = false;
                ComponentElement d = (ComponentElement)nb;
                custom.Add(d);
                custom.SaveChanges();
                this.Id = d.Id;
            }

            if(this.Name == "DateTimeTable")
            {
                DateTimeTable dt = new DateTimeTable();
                dt.DateTimeValue = this.DateTimeTable.DateTimeValue;
                dt.Name = this.Name;
                dt.IsDelete = false;
                ComponentElement dc = (ComponentElement)dt;
                custom.Add(dc);
                custom.SaveChanges();
                this.Id = dc.Id;
            }


            

            return this;
        }

        public ComponentElement Delete(CustomContext custom)
        {

            IsDelete = true;
            custom.Update(this);

            return this;
        }
    }
}
