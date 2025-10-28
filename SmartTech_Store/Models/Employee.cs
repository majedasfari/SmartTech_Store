namespace SmartTech_Store.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public int? JobId { get; set; }
        public Job? Job { get; set; }

    }
}
