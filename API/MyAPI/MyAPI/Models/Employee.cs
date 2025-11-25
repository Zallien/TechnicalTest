using System.ComponentModel.DataAnnotations;

namespace MyAPI.Models
{
    public class Employee
    {
        [Key]
        public int Row { get; set; }
        public Guid EmployeeId { get; set; }
        public string Employenumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public bool IsActive { get; set; }
        public DateTime Datecreated { get; set; }
        public string Username { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }

    }
}
