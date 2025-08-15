namespace Beauty1.Models
{
    public partial class FormElementTemplate
    {
        public FormElementTemplate Create(CustomContext custom)
        {
            //PictureTemplate ยังไม่ได้เปิดให้ใส่ไอดีของรูปภาพ

            if (this.Type == "FormLabelTemplate")
            {
                FormLabelTemplate la = new FormLabelTemplate();
                la.LabelText = this.FormLabelTemplate.LabelText;
                la.Type = this.Type;
                la.IsDelete = false;
                FormElementTemplate lf = (FormElementTemplate)la;
                
                
                custom.Add(lf);
                custom.SaveChanges();
                this.Id = lf.Id;
                
            }

            if(this.Type == "FormOptionTemplate")
            {
                FormOptionTemplate op = new FormOptionTemplate();
                op.OptionValue = this.FormOptionTemplate.OptionValue;
                op.Type = this.Type;
                op.IsDelete = false;
                FormElementTemplate off = (FormElementTemplate)op;

                //ff = off;
                custom.Add(off);
                custom.SaveChanges();
                this.Id = off.Id;
            }

            if(this.Type == "FormInputTextTemplate")
            {
                FormInputTextTemplate it = new FormInputTextTemplate();
                it.Type = this.Type;
                it.IsDelete = false;
                FormElementTemplate tf = (FormElementTemplate)it;

                //ff = tf;
                custom.Add(tf);
                custom.SaveChanges();
                this.Id = tf.Id;
            }

            if(this.Type == "FormInputDateTemplate")
            {
                FormInputDateTemplate dt = new FormInputDateTemplate();
                dt.Type = this.Type;
                dt.IsDelete = false;
                FormElementTemplate df = (FormElementTemplate)dt;

                //ff = df;
                custom.Add(df);
                custom.SaveChanges();
                this.Id = df.Id;
            }

            if(this.Type == "FormInputFileTemplate")
            {
                FormInputFileTemplate ft = new FormInputFileTemplate();
                ft.Type = this.Type;
                ft.IsDelete = false;
                FormElementTemplate ff1 = (FormElementTemplate)ft;

                //ff = ff1;
                custom.Add(ff1);
                custom.SaveChanges();
                this.Id = ff1.Id;

            }

            if(this.Type == "PopUpTemplate")
            {
                PopUpTemplate pu = new PopUpTemplate();
                pu.Type = this.Type;
                pu.IsDelete = false;
                pu.Url = this.PopUpTemplate.Url;
                pu.TextValue = this.PopUpTemplate.TextValue;
                FormElementTemplate puf = (FormElementTemplate)pu;
                custom.Add(puf);
                custom.SaveChanges();
                this.Id = puf.Id;
            }

            if(this.Type == "PictureTemplate")//อันนี้ยังไม่ได้เปิดให้ใส่ไอดีรูป
            {
                PictureTemplate piggy = new PictureTemplate();
                piggy.Type = this.Type;
                piggy.IsDelete = false;
                //piggy.FileId = this.PictureTemplate.FileId;
                FormElementTemplate panama888 = (FormElementTemplate)piggy;
                custom.Add(panama888);
                custom.SaveChanges();
                this.Id = panama888.Id;
            }

            if(this.Type == "ButtonTemplate")
            {
                ButtonTemplate bot = new ButtonTemplate();
                bot.Type = this.Type;
                bot.IsDelete = false;
                bot.ButtonUrl = this.ButtonTemplate.ButtonUrl;
                bot.ButtonName = this.ButtonTemplate.ButtonName;
                bot.IsActive = this.ButtonTemplate.IsActive;
                FormElementTemplate bg = (FormElementTemplate)bot;
                custom.Add(bg);
                custom.SaveChanges();
                this.Id = bg.Id;
            }

            return this;
        }

        public FormElementTemplate Delete(CustomContext custom)
        {
            IsDelete = true;
            custom.FormElementTemplates.Update(this);
            return this;
        }

        public FormElementTemplate Update(CustomContext custom)
        {
            if(this.Type == "FormLabelTemplate")
            {
                (this.FormLabelTemplate as FormElementTemplate).Id = this.Id;
                custom.FormLabelTemplates.Update(this.FormLabelTemplate);
                custom.SaveChanges();
            }
            if(this.Type == "FormOptionTemplate")
            {
                (this.FormOptionTemplate as FormElementTemplate).Id = this.Id;
                custom.FormOptionTemplates.Update(this.FormOptionTemplate);
                custom.SaveChanges();
            }
            if(this.Type == "FormInputTextTemplate")
            {
                (this.FormInputTextTemplate as FormElementTemplate).Id = this.Id;
                custom.FormInputTextTemplates.Update(this.FormInputTextTemplate);
                custom.SaveChanges();
            }
            if(this.Type == "FormInputFileTemplate")
            {
                (this.FormInputFileTemplate as FormElementTemplate).Id = this.Id;
                custom.FormInputFileTemplates.Update(this.FormInputFileTemplate);
                custom.SaveChanges();
            }
            if(this.Type == "FormInputDateTemplate")
            {
                (this.FormInputDateTemplate as FormElementTemplate).Id = this.Id;
                custom.FormInputDateTemplates.Update(this.FormInputDateTemplate);
                custom.SaveChanges();
            }
            if(this.Type == "PopUpTemplate")
            {
                (this.PopUpTemplate as FormElementTemplate).Id = this.Id;
                custom.PopUpTemplates.Update(this.PopUpTemplate);
                custom.SaveChanges();
            }
            if(this.Type == "PictureTemplate")
            {
                (this.PictureTemplate as FormElementTemplate).Id = this.Id;
                custom.PictureTemplates.Update(this.PictureTemplate);
                custom.SaveChanges();
            }
            if(this.Type == "ButtonTemplate")
            {
                (this.ButtonTemplate as FormElementTemplate).Id = this.Id;
                custom.ButtonTemplates.Update(this.ButtonTemplate);
                custom.SaveChanges();
            }

            return this;
        }

        public FormElementTemplate Duplicate(CustomContext custom)
        {
            switch(this.Type)
            {

                case "FormLabelTemplate":
                    FormLabelTemplate fl = new FormLabelTemplate();
                    fl.Type = this.Type;
                    fl.IsDelete = false;
                    fl.LabelText = (this as FormLabelTemplate).LabelText;
                    FormElementTemplate fl2 = (FormElementTemplate)fl;
                    custom.Add(fl2);
                    custom.SaveChanges();
                    this.Id = fl2.Id;
                    break;
            }

            return this;
        }
    }
}
