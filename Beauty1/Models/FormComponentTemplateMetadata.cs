using System.ComponentModel;

namespace Beauty1.Models
{
    public partial class FormComponentTemplate
    {
        public FormComponentTemplate Create(CustomContext custom, Component component)
        {
            

            switch (this.TypeName)
            {
                case "SingleSelection":
                    
                    SingleSelection ss = new SingleSelection();
                    ss.TypeName = this.TypeName;
                    ss.IsDelete = false;
                    FormComponentTemplate sf = (FormComponentTemplate)ss;
                    sf.FormId = component.Id;
                    custom.Add(sf);
                    custom.SaveChanges();
                    
                    this.Id = sf.Id;
                    break;

                case "TextField":
                    
                    TextField td = new TextField();
                    td.TypeName = this.TypeName;
                    td.IsDelete = false;
                    FormComponentTemplate tf = (FormComponentTemplate)td;
                    tf.FormId = component.Id;
                    custom.Add(tf);
                    custom.SaveChanges();
                    this.Id = tf.Id;
                    break;

                case "Date":
                    //this.FormId = component.Id;
                    Date d = new Date();
                    d.TypeName = this.TypeName;
                    d.IsDelete = false;
                    FormComponentTemplate dt = (FormComponentTemplate)d;
                    dt.FormId = component.Id;
                    custom.Add(dt);
                    custom.SaveChanges();
                    this.Id = dt.Id;
                    break;

                case "BirthDate":
                    //this.FormId = component.Id;
                    BirthDate bd = new BirthDate();
                    bd.TypeName = this.TypeName;
                    bd.IsDelete = false;
                    FormComponentTemplate hbd = (FormComponentTemplate)bd;
                    hbd.FormId = component.Id;
                    custom.Add(hbd);
                    custom.SaveChanges();
                    this.Id = hbd.Id;
                    break;

                case "ImageUpload":
                    //this.FormId = component.Id;
                    ImageUpload iu = new ImageUpload();
                    iu.TypeName = this.TypeName;
                    iu.IsDelete = false;
                    FormComponentTemplate it = (FormComponentTemplate)iu;
                    it.FormId = component.Id;
                    custom.Add(it);
                    custom.SaveChanges();
                    this.Id = it.Id;
                    break;

                case "ImageUploadWithImageContent":
                    //this.FormId = component.Id;
                    ImageUploadWithImageContent ic = new ImageUploadWithImageContent();
                    ic.TypeName = this.TypeName;
                    ic.IsDelete = false;
                    FormComponentTemplate ifc = (FormComponentTemplate)ic;
                    ifc.FormId = component.Id;
                    custom.Add(ifc);
                    custom.SaveChanges();
                    this.Id = ifc.Id;
                    break;

                case "ButtonForm":
                    //this.FormId = component.Id;
                    ButtonForm bf = new ButtonForm();
                    bf.TypeName = this.TypeName;
                    bf.IsDelete = false;
                    FormComponentTemplate bt = (FormComponentTemplate)bf;
                    bt.FormId = component.Id;
                    custom.Add(bt);
                    custom.SaveChanges();
                    this.Id = bt.Id;
                    break;

                case "PopUpForm":
                    
                    PopUpForm pf = new PopUpForm();
                    pf.TypeName = this.TypeName;
                    pf.IsDelete = false;
                    FormComponentTemplate pt = (FormComponentTemplate)pf;
                    pt.FormId = component.Id;
                    custom.Add(pt);
                    custom.SaveChanges();
                    this.Id = pt.Id;
                    break;
                    
            }


            

            foreach (var cbf in this.CombineFormElementTemplates)
            {
                cbf.FormComponentId = this.Id;
                cbf.Create(custom, this);
            }

            return this;
        }

        public FormComponentTemplate Delete(CustomContext custom)
        {
            IsDelete = true;
            custom.Update(this);

            foreach(var cb in this.CombineFormElementTemplates)
            {
                cb.Delete(custom);
            }

            return this;
        }
    }
}
