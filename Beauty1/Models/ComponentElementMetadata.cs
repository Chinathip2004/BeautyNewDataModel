namespace Beauty1.Models
{
    public partial class ComponentElement
    {
        public ComponentElement Create(CustomContext custom)
        {


            if (this.Name == "Button")
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
            if (this.Name == "Text")
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
            if (this.Name == "Picture")
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

            if (this.Name == "NumberTable")
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

            if (this.Name == "DateTimeTable")
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

        public ComponentElement Update(CustomContext custom)
        {
            if (this.Name == "Button")
            {
                (this.Button as ComponentElement).Id = this.Id;
                custom.Buttons.Update(this.Button);
                custom.SaveChanges();
            }

            if (this.Name == "Text")
            {
                (this.Text as ComponentElement).Id = this.Id;
                custom.Texts.Update(this.Text);
                custom.SaveChanges();
            }

            if(this.Name == "Picture")
            {
                (this.Picture as ComponentElement).Id = this.Id;
                custom.Pictures.Update(this.Picture);
                custom.SaveChanges();
            }

            if(this.Name == "NumberTable")
            {
                (this.NumberTable as ComponentElement).Id = this.Id;
                custom.NumberTables.Update(this.NumberTable);
                custom.SaveChanges();
            }

            if(this.Name == "DateTimeTable")
            {
                (this.DateTimeTable as ComponentElement).Id = this.Id;
                custom.DateTimeTables.Update(this.DateTimeTable);
                custom.SaveChanges();
            }

            return this;
        }

        public ComponentElement Duplicate(CustomContext custom)
        {
            switch(this.Name)
            {
                case "Button":
                    Button button = new Button();
                    button.Name = this.Name;
                    button.ButtonText = (this as Button).ButtonText;
                    button.ButtonUrl = (this as Button).ButtonUrl;
                    button.IsActive = (this as Button).IsActive;
                    button.IsDelete = false;
                    ComponentElement be = (ComponentElement)button;
                    custom.Add(be);
                    custom.SaveChanges();
                    this.Id = be.Id;
                    break;

                case "Text":
                    Text t = new Text();
                    t.Name = this.Name;
                    t.TextValue = (this as Text).TextValue;
                    ComponentElement te = (ComponentElement)t;
                    custom.Add(te);
                    custom.SaveChanges();
                    this.Id = te.Id;
                    break;

                case "Picture":
                    Picture p = new Picture();
                    p.Name = this.Name;
                    p.ImageUrl = (this as Picture).ImageUrl;
                    p.ImageId = (this as Picture).ImageId;
                    p.IsDelete = false;
                    ComponentElement pe = (ComponentElement)p;
                    custom.Add(pe);
                    custom.SaveChanges();
                    this.Id = pe.Id;
                    break;

                case "NumberTable":
                    NumberTable nt = new NumberTable();
                    nt.Name = this.Name;
                    nt.NumberValue = (this as NumberTable).NumberValue;
                    nt.IsDelete = false;
                    ComponentElement nc = (ComponentElement)nt;
                    custom.Add(nc);
                    custom.SaveChanges();
                    this.Id = nc.Id;
                    break;

                case "DateTimeTable":
                    DateTimeTable dt = new DateTimeTable();
                    dt.Name = this.Name;
                    dt.IsDelete = false;
                    dt.DateTimeValue = (this as DateTimeTable).DateTimeValue;
                    ComponentElement dc = (ComponentElement)dt;
                    custom.Add(dc);
                    custom.SaveChanges();
                    this.Id = dc.Id;
                    break;
            
            }

            return this;
        }
    }
}
