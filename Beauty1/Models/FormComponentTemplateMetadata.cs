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
                    FormComponentTemplate sf = (FormComponentTemplate)ss;
                    sf.FormId = component.Id;
                    custom.Add(sf);
                    custom.SaveChanges();
                    
                    this.Id = sf.Id;
                    break;

                case "TextField":
                    
                    TextField td = new TextField();
                    td.TypeName = this.TypeName;
                    FormComponentTemplate tf = (FormComponentTemplate)td;
                    tf.FormId = component.Id;
                    custom.Add(tf);
                    custom.SaveChanges();
                    this.Id = tf.Id;
                    break;

                case "Date":
                    this.FormId = component.Id;
                    Date d = new Date();
                    d.TypeName = this.TypeName;
                    FormComponentTemplate dt = (FormComponentTemplate)d;
                    dt.FormId = component.Id;
                    custom.Add(dt);
                    custom.SaveChanges();
                    this.Id = dt.Id;
                    break;

                case "BirthDate":
                    this.FormId = component.Id;
                    BirthDate bd = new BirthDate();
                    bd.TypeName = this.TypeName;
                    FormComponentTemplate hbd = (FormComponentTemplate)bd;
                    hbd.FormId = component.Id;
                    custom.Add(hbd);
                    custom.SaveChanges();
                    this.Id = hbd.Id;
                    break;

                case "ImageUpload":
                    this.FormId = component.Id;
                    ImageUpload iu = new ImageUpload();
                    iu.TypeName = this.TypeName;
                    FormComponentTemplate it = (FormComponentTemplate)iu;
                    it.FormId = component.Id;
                    custom.Add(it);
                    custom.SaveChanges();
                    this.Id = it.Id;
                    break;

                case "ImageUploadWithImageContent":
                    this.FormId = component.Id;
                    ImageUploadWithImageContent ic = new ImageUploadWithImageContent();
                    ic.TypeName = this.TypeName;
                    FormComponentTemplate ifc = (FormComponentTemplate)ic;
                    ifc.FormId = component.Id;
                    custom.Add(ifc);
                    custom.SaveChanges();
                    this.Id = ifc.Id;
                    break;

                case "ButtonForm":
                    this.FormId = component.Id;
                    ButtonForm bf = new ButtonForm();
                    bf.TypeName = this.TypeName;
                    FormComponentTemplate bt = (FormComponentTemplate)bf;
                    bt.FormId = component.Id;
                    custom.Add(bt);
                    custom.SaveChanges();
                    this.Id = bt.Id;
                    break;
                    
            }


            

            foreach (var cbf in this.CombineFormElementTemplates)
            {
                cbf.FormComponentId = this.Id;
                cbf.Create(custom, this);
            }

            return this;
        }
    }
}
