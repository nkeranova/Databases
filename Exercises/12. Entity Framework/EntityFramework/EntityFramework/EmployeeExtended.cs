namespace EntityFramework
{
    public partial class Employee
    {
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
}
