using System.ComponentModel.DataAnnotations.Schema;

namespace Beauty1.Models
{
    public partial class CombineFormElementTemplate
    {
        //[NotMapped]
        //public ComponentElement compp { get; set; }
        public CombineFormElementTemplate Create(CustomContext custom, FormComponentTemplate fce)
        {


            //if(compp != null)
            //{
            //    ComponentElement comp = compp.Create(custom);
            //    FormComponentId = fce.Id;
            //    FormElementId = comp.Id;

            //    custom.Add(this);
            //    custom.SaveChanges();
            //}
            FormElementTemplate fe = this.FormElement;
            fe.Create(custom);

            CombineFormElementTemplate ft = new CombineFormElementTemplate();
            ft.FormComponentId = fce.Id;
            ft.FormElementId = fe.Id;
            custom.Add(ft);
            custom.SaveChanges();

            return this;
        }
    }
}