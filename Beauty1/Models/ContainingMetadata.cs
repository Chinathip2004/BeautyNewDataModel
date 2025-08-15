using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models
{
    public partial class Containing
    {
        public Containing Create(CustomContext custom, Component component)
        {
            Component component1 = this.Component;
            component1.Create(custom);

            Containing cc = new Containing();
            cc.ContainerId = component.Id;
            cc.ComponentId = component1.Id;
            cc.Order = this.Order;
            cc.IsShow = this.IsShow;
            cc.IsDelete = false;
            custom.Add(cc);
            custom.SaveChanges();



            if (component1.Name == "Section")
            {
                foreach (Containing conning in component1.Containings)
                {
                    conning.Create(custom, component1);
                }
            }


            return this;
        }

        public Containing Delete(CustomContext custom)
        {

            this.IsDelete = true;
            custom.Update(this);
            custom.SaveChanges();

            return this;
        }

        public Containing Update(CustomContext custom)
        {



            if (this.Component.Id == 0)
            {
                this.Component.Create(custom);
            }

            this.Component.Update(custom);

            if (this.Component.Name == "Section")
            {
                foreach (var con in this.Component.Containings)
                {
                    con.Update(custom);
                }
            }


            this.IsDelete = false;

            this.Component = null;
            custom.Update(this);
            custom.SaveChanges();

            return this;
        }

        public Containing Duplicate(CustomContext custom, Component component)
        {
            Component component1 = this.Component.Duplicate(custom);

            Containing containing = new Containing();
            containing.ContainerId = component.Id;
            containing.ComponentId = component1.Id;
            containing.Order = this.Order;
            containing.IsDelete = false;
            containing.IsShow = this.IsShow;
            custom.Add(containing);
            custom.SaveChanges();

            if(component1.Name == "Section")
            {
                List<Containing> cc = custom.Containings.Include(c => c.Component).ThenInclude(c => c.CombineElements).ThenInclude(c => c.ComponentElement)
                    .Include(f => f.Component).ThenInclude(f => f.FormTemplate).ThenInclude(f => f.FormComponentTemplates).ThenInclude(f => f.CombineFormElementTemplates).ThenInclude(f => f.FormElement)
                    .Where(w => w.ContainerId == this.ComponentId).AsNoTracking().ToList();

                foreach(var coning in cc)
                {
                    
                    coning.Duplicate(custom, component1);
                }
            }

            return this;
        }
    }
}
