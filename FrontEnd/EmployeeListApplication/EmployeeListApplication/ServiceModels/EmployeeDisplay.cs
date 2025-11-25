using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeListApplication.ServiceModels
{
    public class EmployeeDisplay
    {
        public Guid EmployeeId { get; set; }
        public string Fullname { get; set; }
        public string Employenumber { get; set; }
        public DateTime Datecreated { get; set; }
    }
}
