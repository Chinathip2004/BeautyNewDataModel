using System.ComponentModel.DataAnnotations.Schema;

namespace Beauty1.Models
{
    public partial class CombineFormElementTemplate
    {
        [NotMapped]
        public ComponentElement compp { get; set; }
        public CombineFormElementTemplate Create(CustomContext custom, FormComponentTemplate fce)
        {
            
            
            if(compp != null)
            {
                ComponentElement comp = compp.Create(custom);
                FormComponentId = fce.Id;
                FormElementId = comp.Id;

                custom.Add(this);
                custom.SaveChanges();
            }

            return this;
        }
    }
}