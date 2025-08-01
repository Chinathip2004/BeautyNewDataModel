using System.ComponentModel.DataAnnotations.Schema;

namespace Beauty1.Models
{
    public partial class CombineFormElementTemplate
    {
        [NotMapped]
        public ComponentElement compp { get; set; }
        public CombineFormElementTemplate Create(CustomContext custom, FormComponentTemplate fce)
        {
            //FormElementTemplate fe = this.FormElement;
            //fe.Create(custom);

            //CombineFormElementTemplate ce = new CombineFormElementTemplate();
            //ce.FormComponentId = fce.Id;
            //ce.FormElementId = fe.Id;
            //custom.Add(ce);
            //custom.SaveChanges();
            
            if(compp != null)
            {
                ComponentElement comp = compp.Create(custom);
                FormElementId = comp.Id;
            }

            return this;
        }
    }
}