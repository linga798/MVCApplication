namespace CoreEFMVCApp.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        //relationship with Employees
        public ICollection<Employee> Employees { get; set; } //collection navigation property
    }
}
