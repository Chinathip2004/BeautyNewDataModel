using System.ComponentModel.DataAnnotations.Schema;

namespace Beauty1.Models
{
    public partial class CombineFormElementTemplate
    {
        //[NotMapped]
        //public ComponentElement compp { get; set; }
        public CombineFormElementTemplate Create(CustomContext custom, FormComponentTemplate fce)
        {


            
            FormElementTemplate fe = this.FormElement;
            fe.Create(custom);

            CombineFormElementTemplate ft = new CombineFormElementTemplate();
            ft.FormComponentId = fce.Id;
            ft.FormElementId = fe.Id;
            ft.IsDelete = false;
            custom.Add(ft);
            custom.SaveChanges();

            return this;
        }

        public CombineFormElementTemplate Delete(CustomContext custom)
        {
            
            IsDelete = true;

            FormElementTemplate fe = custom.FormElementTemplates.Where(f => f.Id == this.FormElementId).FirstOrDefault();

            fe.Delete(custom);

            custom.CombineFormElementTemplates.Update(this);
            

            return this;
        }


        public CombineFormElementTemplate Update(CustomContext custom)
        {
            if (FormElement.Id == 0)
            {
                FormElement.Create(custom);
            }

            if (FormElement.IsDelete == true)
            {
                FormElement.Delete(custom);
            }

            

            FormElement.Update(custom);
            FormElement = null;

            IsDelete = false;
            custom.Update(this);
            return this;
        }

        public CombineFormElementTemplate Duplicate(CustomContext custom)
        {
            this.FormElement.Duplicate(custom);

            CombineFormElementTemplate cm = new CombineFormElementTemplate();
            cm.FormComponentId = this.FormComponentId;
            cm.FormElementId = this.FormElementId;
            custom.Add(cm);
            custom.SaveChanges();
            return this;
        }
    }
}