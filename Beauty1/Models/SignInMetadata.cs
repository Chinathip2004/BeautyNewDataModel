namespace Beauty1.Models
{
    public partial class SignIn
    {
        public SignIn Register(CustomContext custom)
        {
            
            custom.Add(this);
            
            return this;
        }
    }
}
