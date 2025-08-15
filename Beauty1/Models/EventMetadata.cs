using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static Azure.Core.HttpHeader;

namespace Beauty1.Models
{
    public partial class Event
    {
        [NotMapped]
        public List<Component> com { get; set; }


        public Event Create(CustomContext custom)
        {
            Event ee = new Event();
            ee.Name = this.Name;
            ee.IsFavorite = this.IsFavorite;
            ee.FileId = this.FileId;
            
            ee.IsDelete = false;
            custom.Add(ee);
            custom.SaveChanges();

            foreach (var cat in this.EventCategorizes)
            {
                cat.EventId = ee.Id;
                cat.Create(custom);

            }

            if (com != null)
            {
                foreach (Component compo in com)
                {
                    Page page = new Page
                    {
                        Name = compo.Name,
                        Containings = compo.Containings,
                        EventId = ee.Id

                    };
                    page.Create(custom, ee);
                }
            }
            return this;
        }

        public Event Delete(CustomContext custom)
        {
            this.IsDelete = true;
            custom.Events.Update(this);

            foreach(var dd in this.EventCategorizes)
            {
                dd.Delete(custom);
            }

            foreach(var p in this.Pages)
            {
                p.DeletePage(custom);
            }

            return this;
        }


        public static Event GetById(CustomContext custom, int? id)
        {
            Event ev = custom.Events.Where(e => e.Id == id && e.IsDelete != true).First();
            ev.EventCategorizes = custom.EventCategorizes.Where(e => e.EventId == id && e.IsDelete != true).ToList();
            ev.Pages = custom.Pages.Where(p => p.EventId == id).ToList();

            foreach (var d in ev.Pages)
            {
                d.Id = (d as Component).Id;
                d.Containings = custom.Containings.Where(c => c.ContainerId == (d as Component).Id).ToList();
                foreach (var c in d.Containings)
                {
                    var compo = c.Component = custom.Components.Where(co => co.Id == c.ComponentId).Include(c => c.CombineElements).FirstOrDefault();
                    if (compo.Name == "Section")
                    {

                        Section sc = (Section)compo;
                        sc.Id = (sc as Component).Id;
                        LoadComponent(custom, compo);
                    }
                    if (compo.Name == "Banner")
                    {
                        Banner b = (Banner)compo;
                        b.Id = (b as Component).Id;
                    }
                    if (compo.Name == "TextBox")
                    {
                        TextBox t = (TextBox)compo;
                        t.Id = (t as Component).Id;
                    }
                    if (compo.Name == "ImageWithCaption")
                    {
                        ImageWithCaption iw = (ImageWithCaption)compo;
                        iw.Id = (iw as Component).Id;
                    }
                    if (compo.Name == "GridTwoColumn")
                    {
                        GridTwoColumn g2 = (GridTwoColumn)compo;
                        g2.Id = (g2 as Component).Id;
                    }
                    if (compo.Name == "ImageDesc")
                    {
                        ImageDesc ic = (ImageDesc)compo;
                        ic.Id = (ic as Component).Id;
                    }
                    if (compo.Name == "GridFourImage")
                    {
                        GridFourImage g4 = (GridFourImage)compo;
                        g4.Id = (g4 as Component).Id;
                    }
                    if (compo.Name == "TableWithTopicAndDesc")
                    {
                        TableWithTopicAndDesc ttd = (TableWithTopicAndDesc)compo;
                        ttd.Id = (ttd as Component).Id;
                    }
                    if (compo.Name == "OneTopicImageCaptionButton")
                    {
                        OneTopicImageCaptionButton ot = (OneTopicImageCaptionButton)compo;
                        ot.Id = (ot as Component).Id;
                    }
                    if (compo.Name == "TwoTopicImageCaptionButton")
                    {
                        TwoTopicImageCaptionButton tb = (TwoTopicImageCaptionButton)compo;
                        tb.Id = (tb as Component).Id;
                    }
                    if (compo.Name == "Sale")
                    {
                        Sale sa = (Sale)compo;
                        sa.Id = (sa as Component).Id;
                    }
                    if (compo.Name == "ButtonComponent")
                    {
                        ButtonComponent bc = (ButtonComponent)compo;
                        bc.Id = (bc as Component).Id;
                    }
                    if (compo.Name == "About")
                    {
                        About ab = (About)compo;
                        ab.Id = (ab as Component).Id;
                    }
                    foreach (var cb in compo.CombineElements)
                    {
                        ComponentElement ce = cb.ComponentElement = custom.ComponentElements.Where(d => d.Id == cb.ComponentElementId).FirstOrDefault();
                        ///
                        if (ce.Name == "Text")
                        {
                            Text tt = (Text)ce;
                            tt.Id = (tt as ComponentElement).Id;
                        }
                        if (ce.Name == "Button")
                        {
                            Button btn = (Button)ce;
                            btn.Id = (btn as ComponentElement).Id;
                        }
                        if (ce.Name == "Picture")
                        {
                            Picture pt = (Picture)ce;
                            pt.Id = (pt as ComponentElement).Id;
                        }
                        if (ce.Name == "NumberTable")
                        {
                            NumberTable nbt = (NumberTable)ce;
                            nbt.Id = (nbt as ComponentElement).Id;
                        }
                        if (ce.Name == "DateTimeTable")
                        {
                            DateTimeTable dtt = (DateTimeTable)ce;
                            dtt.Id = (dtt as ComponentElement).Id;
                        }
                    }

                    if (compo.Name == "FormTemplate")
                    {

                        FormTemplate ftem = compo.FormTemplate = custom.FormTemplates.Include(f => f.FormComponentTemplates).Where(w => w.Id == compo.Id).FirstOrDefault();
                        ftem.Id = (ftem as Component).Id;
                        foreach (var fc in ftem.FormComponentTemplates)
                        {
                            fc.CombineFormElementTemplates = custom.CombineFormElementTemplates.Where(c => c.FormComponentId == fc.Id).ToList();
                            if (fc.TypeName == "SingleSelection")
                            {
                                SingleSelection ss = (SingleSelection)fc;
                                ss.Id = (ss as FormComponentTemplate).Id;
                            }

                            if (fc.TypeName == "PopUpForm")
                            {
                                PopUpForm pf = (PopUpForm)fc;
                                pf.Id = (pf as FormComponentTemplate).Id;
                            }
                            ///
                            if (fc.TypeName == "TextField")
                            {
                                TextField tf = (TextField)fc;
                                tf.Id = (tf as FormComponentTemplate).Id;
                            }
                            if (fc.TypeName == "Date")
                            {
                                Date dt = (Date)fc;
                                dt.Id = (dt as FormComponentTemplate).Id;
                            }
                            if (fc.TypeName == "BirthDate")
                            {
                                BirthDate bd = (BirthDate)fc;
                                bd.Id = (bd as FormComponentTemplate).Id;
                            }
                            if (fc.TypeName == "ImageUpload")
                            {
                                ImageUpload iu = (ImageUpload)fc;
                                iu.Id = (iu as FormComponentTemplate).Id;
                            }
                            if (fc.TypeName == "ImageUploadWithImageContent")
                            {
                                ImageUploadWithImageContent im = (ImageUploadWithImageContent)fc;
                                im.Id = (im as FormComponentTemplate).Id;
                            }
                            if (fc.TypeName == "ButtonForm")
                            {
                                ButtonForm bf = (ButtonForm)fc;
                                bf.Id = (bf as FormComponentTemplate).Id;
                            }

                            foreach (var el in fc.CombineFormElementTemplates)
                            {
                                FormElementTemplate fe = el.FormElement = custom.FormElementTemplates.Where(f => f.Id == el.FormElementId).FirstOrDefault();

                                if (fe.Type == "PopUpTemplate")
                                {
                                    PopUpTemplate pt = (PopUpTemplate)fe;
                                    pt.Id = (pt as FormElementTemplate).Id;
                                }
                                if (fe.Type == "ButtonTemplate")
                                {
                                    ButtonTemplate bt = (ButtonTemplate)fe;
                                    bt.Id = (bt as FormElementTemplate).Id;
                                }
                                if (fe.Type == "FormLabelTemplate")
                                {
                                    FormLabelTemplate fl = (FormLabelTemplate)fe;
                                    fl.Id = (fl as FormElementTemplate).Id;
                                }
                                if (fe.Type == "FormOptionTemplate")
                                {
                                    FormOptionTemplate fo = (FormOptionTemplate)fe;
                                    fo.Id = (fo as FormElementTemplate).Id;
                                }
                                if (fe.Type == "FormInputTextTemplate")
                                {
                                    FormInputTextTemplate fi = (FormInputTextTemplate)fe;
                                    fi.Id = (fi as FormElementTemplate).Id;
                                }
                                if (fe.Type == "FormInputFileTemplate")
                                {
                                    FormInputFileTemplate fif = (FormInputFileTemplate)fe;
                                    fif.Id = (fif as FormElementTemplate).Id;
                                }
                                if (fe.Type == "FormInputDateTemplate")
                                {
                                    FormInputDateTemplate fd = (FormInputDateTemplate)fe;
                                    fd.Id = (fd as FormElementTemplate).Id;
                                }
                                if (fe.Type == "PictureTemplate")
                                {
                                    PictureTemplate pic = (PictureTemplate)fe;
                                    pic.Id = (pic as FormElementTemplate).Id;
                                }
                            }
                        }
                    }
                }
            }

            return ev;
        }


        public static void LoadComponent(CustomContext custom, Component component)
        {
            if (component.Name == "Section")
            {
                Section section = custom.Sections.Where(s => s.Id == component.Id).FirstOrDefault();
                if (section != null)
                {
                    section.Containings = custom.Containings.Where(d => d.ContainerId == component.Id).ToList();
                    foreach (var con in section.Containings)
                    {
                        var comm = con.Component = custom.Components.Where(d => d.Id == con.ComponentId).Include(c => c.CombineElements).FirstOrDefault();
                        if (comm.Name == "Section")
                        {
                            Section s = (Section)comm;
                            s.Id = (s as Component).Id;
                            LoadComponent(custom, comm);
                        }
                        if (comm.Name == "Banner")
                        {
                            Banner b = (Banner)comm;
                            b.Id = (b as Component).Id;
                        }
                        if (comm.Name == "TextBox")
                        {
                            TextBox t = (TextBox)comm;
                            t.Id = (t as Component).Id;
                        }
                        if (comm.Name == "ImageWithCaption")
                        {
                            ImageWithCaption iw = (ImageWithCaption)comm;
                            iw.Id = (iw as Component).Id;
                        }
                        if (comm.Name == "GridTwoColumn")
                        {
                            GridTwoColumn g2 = (GridTwoColumn)comm;
                            g2.Id = (g2 as Component).Id;
                        }
                        if (comm.Name == "ImageDesc")
                        {
                            ImageDesc ic = (ImageDesc)comm;
                            ic.Id = (ic as Component).Id;
                        }
                        if (comm.Name == "GridFourImage")
                        {
                            GridFourImage g4 = (GridFourImage)comm;
                            g4.Id = (g4 as Component).Id;
                        }
                        if (comm.Name == "TableWithTopicAndDesc")
                        {
                            TableWithTopicAndDesc ttd = (TableWithTopicAndDesc)comm;
                            ttd.Id = (ttd as Component).Id;
                        }
                        if (comm.Name == "OneTopicImageCaptionButton")
                        {
                            OneTopicImageCaptionButton ot = (OneTopicImageCaptionButton)comm;
                            ot.Id = (ot as Component).Id;
                        }
                        if (comm.Name == "TwoTopicImageCaptionButton")
                        {
                            TwoTopicImageCaptionButton tb = (TwoTopicImageCaptionButton)comm;
                            tb.Id = (tb as Component).Id;
                        }
                        foreach (var cbi in comm.CombineElements)
                        {
                            ComponentElement ce = cbi.ComponentElement = custom.ComponentElements.Where(d => d.Id == cbi.ComponentElementId).FirstOrDefault();
                            if (ce.Name == "Text")
                            {
                                Text tt = (Text)ce;
                                tt.Id = (tt as ComponentElement).Id;
                            }
                            if (ce.Name == "Button")
                            {
                                Button btn = (Button)ce;
                                btn.Id = (btn as ComponentElement).Id;
                            }
                            if (ce.Name == "Picture")
                            {
                                Picture pt = (Picture)ce;
                                pt.Id = (pt as ComponentElement).Id;
                            }
                            if (ce.Name == "NumberTable")
                            {
                                NumberTable nbt = (NumberTable)ce;
                                nbt.Id = (nbt as ComponentElement).Id;
                            }
                            if (ce.Name == "DateTimeTable")
                            {
                                DateTimeTable dtt = (DateTimeTable)ce;
                                dtt.Id = (dtt as ComponentElement).Id;
                            }
                        }
                        if (comm.Name == "FormTemplate")
                        {
                            FormTemplate ff = comm.FormTemplate = custom.FormTemplates.Include(f => f.FormComponentTemplates).Where(w => w.Id == comm.Id).FirstOrDefault();
                            ff.Id = (ff as Component).Id;
                            foreach (var fc in ff.FormComponentTemplates)
                            {
                                fc.CombineFormElementTemplates = custom.CombineFormElementTemplates.Where(c => c.FormComponentId == fc.Id).ToList();
                                if (fc.TypeName == "PopUpForm")
                                {
                                    PopUpForm pf = (PopUpForm)fc;
                                    pf.Id = (pf as FormComponentTemplate).Id;
                                }
                                if (fc.TypeName == "SingleSelection")
                                {
                                    SingleSelection ss = (SingleSelection)fc;
                                    ss.Id = (ss as FormComponentTemplate).Id;
                                }
                                if (fc.TypeName == "TextField")
                                {
                                    TextField tf = (TextField)fc;
                                    tf.Id = (tf as FormComponentTemplate).Id;
                                }
                                if (fc.TypeName == "Date")
                                {
                                    Date d = (Date)fc;
                                    d.Id = (d as FormComponentTemplate).Id;
                                }
                                if (fc.TypeName == "BirthDate")
                                {
                                    BirthDate bd = (BirthDate)fc;
                                    bd.Id = (bd as FormComponentTemplate).Id;
                                }
                                if (fc.TypeName == "ImageUpload")
                                {
                                    ImageUpload iu = (ImageUpload)fc;
                                    iu.Id = (iu as FormComponentTemplate).Id;
                                }
                                if (fc.TypeName == "ImageUploadWithImageContent")
                                {
                                    ImageUploadWithImageContent im = (ImageUploadWithImageContent)fc;
                                    im.Id = (im as FormComponentTemplate).Id;
                                }
                                if (fc.TypeName == "ButtonForm")
                                {
                                    ButtonForm bf = (ButtonForm)fc;
                                    bf.Id = (bf as FormComponentTemplate).Id;
                                }

                                foreach (var el in fc.CombineFormElementTemplates)
                                {
                                    FormElementTemplate fe = el.FormElement = custom.FormElementTemplates.Where(f => f.Id == el.FormElementId).FirstOrDefault();
                                    if (fe.Type == "PopUpTemplate")
                                    {
                                        PopUpTemplate pt = (PopUpTemplate)fe;
                                        pt.Id = (pt as FormElementTemplate).Id;
                                    }
                                    if (fe.Type == "FormLabelTemplate")
                                    {
                                        FormLabelTemplate fl = (FormLabelTemplate)fe;
                                        fl.Id = (fl as FormElementTemplate).Id;
                                    }
                                    if (fe.Type == "FormOptionTemplate")
                                    {
                                        FormOptionTemplate fo = (FormOptionTemplate)fe;
                                        fo.Id = (fo as FormElementTemplate).Id;
                                    }
                                    if (fe.Type == "FormInputTextTemplate")
                                    {
                                        FormInputTextTemplate fi = (FormInputTextTemplate)fe;
                                        fi.Id = (fi as FormElementTemplate).Id;
                                    }
                                    if (fe.Type == "FormInputFileTemplate")
                                    {
                                        FormInputFileTemplate fif = (FormInputFileTemplate)fe;
                                        fif.Id = (fif as FormElementTemplate).Id;
                                    }
                                    if (fe.Type == "FormInputDateTemplate")
                                    {
                                        FormInputDateTemplate fd = (FormInputDateTemplate)fe;
                                        fd.Id = (fd as FormElementTemplate).Id;
                                    }
                                    if (fe.Type == "PictureTemplate")
                                    {
                                        PictureTemplate pic = (PictureTemplate)fe;
                                        pic.Id = (pic as FormElementTemplate).Id;
                                    }
                                    if (fe.Type == "ButtonTemplate")
                                    {
                                        ButtonTemplate bt = (ButtonTemplate)fe;
                                        bt.Id = (bt as FormElementTemplate).Id;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            JsonSerializerSettings setting = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var json = JsonConvert.SerializeObject(component, setting);
        }



        public Event Update(CustomContext custom, Event ev)
        {

            

            List<Page> page = ev.Pages.ToList();
            ev.Pages.Clear();

            List<EventCategorize> oldEcat = custom.EventCategorizes.Where(c => c.EventId == this.Id && c.IsDelete != true).AsNoTracking().ToList();
            List<EventCategorize> ECat = oldEcat.Where(c => !this.EventCategorizes.Any(e => e.Id == c.Id)).ToList();
            List<Page> oldPage = custom.Pages.Where(p => p.EventId == this.Id && p.IsDelete != true).AsNoTracking().ToList();
            List<Page> PEpage = oldPage.Where(p => this.Pages.Any(e => e.Id == ((Component)p).Id)).ToList();
            
           

            ev.IsDelete = false;
            custom.Update(ev);
            custom.SaveChanges();


            
            foreach(var ecat in ECat)
            {
                ecat.Delete(custom);
            }

            foreach (var ec in this.EventCategorizes)
            {
                if(ec.Id == 0)
                {
                    ec.Create(custom);
                }
                else
                {
                    ec.Update(custom);
                }
            }

            foreach(var pp in PEpage)
            {
                pp.DeletePage(custom);
            }
            

            foreach (var p in page)
            {
                if(p.Id == 0)
                {
                    p.EventId = this.Id;
                    p.Create(custom);
                }
                else
                {
                    p.UpdatePage(custom);
                }
            }
            

            return this;
        }

        public Event Copy(CustomContext custom, int? id)
        {
            Event ev = custom.Events.Include(c=>c.EventCategorizes).Include(p=>p.Pages).Where(f => f.Id == id).FirstOrDefault();

            this.Name = ev.Name;
            this.FileId = ev.FileId;
            this.IsFavorite = ev.IsFavorite;
            this.IsDelete = false;
            custom.Add(this);
            custom.SaveChanges();

            foreach (var ec in ev.EventCategorizes)
            {
                EventCategorize ecat = new EventCategorize();
                ecat.EventId = this.Id;
                ecat.CategoryId = ec.CategoryId;
                ecat.Duplicate(custom);
            }

            foreach (var pp in ev.Pages)
            {
                Page pa = new Page();
                pa.Id = (pp as Component).Id;
                pa.EventId = this.Id;
                pa.Name = pp.Name;
                
                pa.DuplicatePage(custom);
            }
            

            return this;
        }


        public static List<Event> search(CustomContext custom, string name)
        {
            List<Event> listofevent = custom.Events.Where(e => e.Name.Contains(name) && e.IsDelete != true).ToList();

            return listofevent;
        }
    }
}
