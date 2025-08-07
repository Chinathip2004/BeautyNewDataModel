namespace Beauty1.Models
{
    public partial class Containing
    {
        public Containing Create(CustomContext custom , Component component)
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
            
            

            if(component1.Name == "Section")
            {
                foreach(Containing conning in component1.Containings)
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
    }
}
