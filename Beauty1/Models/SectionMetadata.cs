namespace Beauty1.Models
{
    public partial class Section : Container
    {
        public void DeleteSection(CustomContext custom)
        {
            if(this.Containings == null)
            {
                return;
            }

            foreach(var con in this.Containings)
            {
                Component component = con.Component.Delete(custom);

                con.Delete(custom);

                

                if(component.Name == "Section")
                {
                    Section section = (Section)component;
                    section.DeleteSection(custom);
                }
            }

        }

        public void UpdateSection(CustomContext custom)
        {

            if(this.Containings == null)
            {
                return;
            }

            foreach(var con in this.Containings)
            {
                Component component = con.Component.Update(custom);

                if(component.Name == "Section")
                {
                    Section section = (Section)component;
                    section.UpdateSection(custom);

                    con.Update(custom);
                }
            }
            
        }
    }
}
