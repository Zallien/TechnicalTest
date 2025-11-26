using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeListApplication.ServiceModels
{
    public class ModalAction
    {
        public string ModalActionName { get; set; }
        public EmployeeInformation? EmployeeInfo { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}
