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
            FormElementTemplate fe = this.FormElement;
            fe.Delete(custom);

            IsDelete = true;
            custom.Update(this);
            

            return this;
        }
    }
}