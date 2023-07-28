namespace DemoEF.Model
{
    public class Employee
    {
        public Ulid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string Designation { get; set; }
    }
}
