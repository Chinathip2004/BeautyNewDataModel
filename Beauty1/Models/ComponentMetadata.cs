using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


            if (this.Name == "FormTemplate")
            {
                int formId = (this as Component).Id;

                List<FormComponentTemplate> fcTemplate = custom.FormComponentTemplates.Include(f => f.CombineFormElementTemplates).ThenInclude(f => f.FormElement).Where(t => t.FormId == formId).ToList();

                foreach (var k in fcTemplate)
                {
                    FormComponentTemplate co = custom.FormComponentTemplates.Include(c => c.CombineFormElementTemplates).ThenInclude(c => c.FormElement).FirstOrDefault(t => t.Id == k.Id);


                    co.Delete(custom);
                }
            }


            foreach (var d in this.CombineElements)
            {
                d.Delete(custom);
            }

            IsDelete = true;
            custom.Update(this);

            return this;
        }

        public Component Update(CustomContext custom)
        {

            Component oldCom = custom.Components.Include(ci => ci.CombineElements).Include(c => c.Containings).Where(c => c.Id == this.Id && c.IsDelete == false).AsNoTracking().FirstOrDefault();



            if (this.Id == 0)
            {
                this.Create(custom);
            }


            if (this.Name == "FormTemplate")
            {
                FormTemplate foee = custom.FormTemplates.Include(f => f.FormComponentTemplates).ThenInclude(c => c.CombineFormElementTemplates).ThenInclude(f => f.FormElement).AsNoTracking().FirstOrDefault(c => c.Id == this.Id && c.IsDelete != true);

                (this.FormTemplate as Component).Id = this.Id;
                this.FormTemplate.Name = this.Name;
                this.FormTemplate.IsDelete = false;

                List<FormComponentTemplate> ff = custom.FormComponentTemplates.Where(f => f.IsDelete == true).ToList();

                foreach (var ff2 in ff)
                {
                    ff2.Delete(custom);
                }

                foreach (var f in this.FormTemplate.FormComponentTemplates)
                {
                    if (f.Id == 0)
                    {
                        f.Create(custom, this);
                    }

                    f.Update(custom);
                }

                foreach (var f1 in foee.FormComponentTemplates)
                {
                    bool ere = foee.FormComponentTemplates.Any(c => c.Id == f1.Id);
                    if (!ere)
                    {
                        FormComponentTemplate del = custom.FormComponentTemplates.Include(f => f.CombineFormElementTemplates).ThenInclude(f => f.FormElement).Where(c => c.Id == f1.Id).FirstOrDefault();

                        del.Delete(custom);
                    }
                }


                custom.Update(this.FormTemplate);
                custom.SaveChanges();
            }
            if (oldCom != null)
            {
                foreach (var combine in oldCom.CombineElements)
                {
                    bool ddd = this.CombineElements.Any(c => c.Id == combine.Id);
                    if (!ddd)
                    {
                        CombineElement decom = custom.CombineElements.Include(c => c.ComponentElement).Where(c => c.Id == combine.Id).FirstOrDefault();

                        decom.Delete(custom);
                    }
                }
            }


            foreach (var com in this.CombineElements)
            {
                if (com.Id == 0)
                {
                    com.Create(custom);
                }

                com.Update(custom);
            }


            return this;
        }


        public Component Duplicate(CustomContext custom)
        {
            this.Containings.Clear();

            List<CombineElement> combineElements = this.CombineElements.ToList();
            this.CombineElements.Clear();

            switch (this.Name)
            {
                case "Section":

                    Section section = new Section();
                    section.Name = this.Name;
                    Component sc = (Component)section;
                    custom.Add(sc);
                    custom.SaveChanges();
                    this.Id = sc.Id;
                    break;

                case "Banner":

                    Banner banner = new Banner();
                    banner.Name = this.Name;
                    banner.IsDelete = false;
                    Component bc = (Component)banner;
                    custom.Add(bc);
                    custom.SaveChanges();
                    this.Id = bc.Id;
                    break;

                case "TextBox":
                    TextBox textBox = new TextBox();
                    textBox.Name = this.Name;
                    textBox.IsDelete = false;
                    Component tc = (Component)textBox;
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
                    Component fc = (Component)ft;
                    custom.Add(fc);
                    custom.SaveChanges();
                    this.Id = fc.Id;

                    foreach(var ff in this.FormTemplate.FormComponentTemplates)
                    {
                        ff.FormId = fc.Id;
                        ff.Duplicate(custom, fc);
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

            foreach (var comb in combineElements)
            {

                CombineElement combine = new CombineElement();
                combine.ComponentId = this.Id;

                combine.ComponentElement = combineElements.FirstOrDefault(f => f.Id == comb.Id)?.ComponentElement;
                combine.Duplicate(custom);
            }


            return this;
        }
    }
}
