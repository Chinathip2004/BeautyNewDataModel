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

                //if(component.Name == "Section" && component.IsDelete != true)
                //{
                //    Section section = (Section)component;
                //    section.Delete(custom);
                //}

                if(component.Name == "Section")
                {
                    Section section = (Section)component;
                    section.DeleteSection(custom);
                }
            }

        }
    }
}
