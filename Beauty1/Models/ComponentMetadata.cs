using Microsoft.AspNetCore.Mvc;

namespace Beauty1.Models
{
    public class ComponentMetadata
    {
    }
    [ModelMetadataType(typeof(ComponentMetadata))]
    public partial class Component
    {
        public Component Create(CustomContext custom)
        {


            switch (this.Name)
            {
                case "Section":
                    Section s = new Section();
                    s.Name = this.Name;
                    s.IsDelete = false;
                    Component sc = (Component)s;
                    custom.Add(sc);
                    custom.SaveChanges();
                    this.Id = sc.Id;
                    
                    break;

                case "Banner":
                    Banner b = new Banner();
                    b.Name = this.Name;
                    b.IsDelete = false;
                    Component bc = (Component)b;
                    custom.Add(bc);
                    custom.SaveChanges();
                    this.Id = bc.Id;
                    break;

                case "TextBox":
                    TextBox t = new TextBox();
                    t.Name = this.Name;
                    t.IsDelete = false;
                    Component tc = (Component)t;
                    custom.Add(tc);
                    custom.SaveChanges();
                    this.Id = tc.Id;
                    break;

                case "ImageWithCaption":
                    ImageWithCaption iw = new ImageWithCaption();
                    iw.Name = this.Name;
                    iw.IsDelete = false;
                    Component ic = (Component)iw;
                    custom.Add(ic);
                    custom.SaveChanges();
                    this.Id = ic.Id;
                    break;

                case "GridTwoColumn":
                    GridTwoColumn g2 = new GridTwoColumn();
                    g2.Name = this.Name;
                    g2.IsDelete = false;
                    Component gc = (Component)g2;
                    custom.Add(gc);
                    custom.SaveChanges();
                    this.Id = gc.Id;
                    break;

                case "ImageDesc":
                    ImageDesc im = new ImageDesc();
                    im.Name = this.Name;
                    im.IsDelete = false;
                    Component icc = (Component)im;
                    custom.Add(icc);
                    custom.SaveChanges();
                    this.Id = icc.Id;
                    break;

                case "GridFourImage":
                    GridFourImage g4 = new GridFourImage();
                    g4.Name = this.Name;
                    g4.IsDelete = false;
                    Component gp = (Component)g4;
                    custom.Add(gp);
                    custom.SaveChanges();
                    this.Id = gp.Id;
                    break;

                case "TableWithTopicAndDesc":
                    TableWithTopicAndDesc tw = new TableWithTopicAndDesc();
                    tw.Name = this.Name;
                    tw.IsDelete = false;
                    Component tcc = (Component)tw;
                    custom.Add(tcc);
                    custom.SaveChanges();
                    this.Id = tcc.Id;
                    break;

                case "OneTopicImageCaptionButton":
                    OneTopicImageCaptionButton ot = new OneTopicImageCaptionButton();
                    ot.Name = this.Name;
                    ot.IsDelete = false;
                    Component otc = (Component)ot;
                    custom.Add(otc);
                    custom.SaveChanges();
                    this.Id = otc.Id;
                    break;

                case "TwoTopicImageCaptionButton":
                    TwoTopicImageCaptionButton tt = new TwoTopicImageCaptionButton();
                    tt.Name = this.Name;
                    tt.IsDelete = false;
                    Component ttc = (Component)tt;
                    custom.Add(ttc);
                    custom.SaveChanges();
                    this.Id = ttc.Id;
                    break;



                case "FormTemplate":
                    FormTemplate ft = new FormTemplate();
                    ft.Name = this.Name;
                    ft.IsDelete = false;
                    ft.Topic = this.FormTemplate.Topic;
                    ft.Url = this.FormTemplate.Url;
                    ft.ButtonName = this.FormTemplate.ButtonName;
                    Component ftc = (Component)ft;
                    custom.Add(ftc);
                    custom.SaveChanges();
                    this.Id = ftc.Id;

                    foreach (var f in this.FormTemplate.FormComponentTemplates)
                    {
                        f.FormId = ftc.Id;
                        f.Create(custom, ftc);

                    }

                    break;

                case "Sale":
                    Sale s1 = new Sale();
                    s1.Name = this.Name;
                    s1.IsDelete = false;
                    Component sc1 = (Component)s1;
                    custom.Add(sc1);
                    custom.SaveChanges();
                    this.Id = sc1.Id;
                    break;

                case "ButtonComponent":
                    ButtonComponent b1 = new ButtonComponent();
                    b1.Name = this.Name;
                    b1.IsDelete = false;
                    Component bc1 = (Component)b1;
                    custom.Add(bc1);
                    custom.SaveChanges();
                    this.Id = bc1.Id;
                    break;

                case "About":
                    About a4 = new About();
                    a4.Name = this.Name;
                    a4.IsDelete = false;
                    Component ac = (Component)a4;
                    custom.Add(ac);
                    custom.SaveChanges();
                    this.Id = ac.Id;
                    break;
            }

            foreach (var d in this.CombineElements)
            {
                d.Create(custom);
                CombineElement ce = new CombineElement();
                ce.ComponentId = this.Id;
                ce.ComponentElementId = d.ComponentElement.Id;
                ce.IsDelete = false;
                custom.Add(ce);
                custom.SaveChanges();

            }



            return this;
        }

        public Component Delete(CustomContext custom)
        {
         
            IsDelete = true;
            custom.Update(this);
            if(this.Name == "FormTemplate")
            {
                foreach (var k in this.FormTemplate.FormComponentTemplates)
                {
                    k.Delete(custom);
                }
            }
            

            foreach(var d in this.CombineElements)
            {
                d.Delete(custom);
            }


            
            return this;
        }
    }
}
