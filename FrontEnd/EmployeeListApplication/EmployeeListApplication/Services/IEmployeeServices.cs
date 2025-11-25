using EmployeeListApplication.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeListApplication.Services
{
    public interface IEmployeeServices
    {
        public Task<List<EmployeeDisplay>> GetEmployee(Pagination pagination);
        public Task<bool> AddEmployee(InsertEmployee employee);
        public Task<bool> RemoveEmployee(Guid employeeId);
        public Task<bool> UpdateEmployee(UpdateEmployee employee);
        public Task<EmployeeInformation> GetEmployeeInfoById(Guid employeeId);
    }
}
