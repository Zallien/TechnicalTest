using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyAPI.APIServiceModels;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public MyAPIDbcontext _db;

        public EmployeeController(MyAPIDbcontext mdb) 
        {
            _db = mdb;
        }

        [HttpPost("GetEmployee")]
        public async Task<List<EmployeeDisplay>> GetEmployee([FromBody] Pagination pagination)
        {
            List<EmployeeDisplay> employeeDisplays = new List<EmployeeDisplay>();
            try
            {
                employeeDisplays = await (from a in _db.Employee
                                          where a.IsActive == true 
                                          && (a.Firstname.Contains(pagination.Searchvalue) || a.Lastname.Contains(pagination.Searchvalue))
                                          select new EmployeeDisplay()
                                          {
                                              EmployeeId = a.EmployeeId,
                                              Datecreated = a.Datecreated,
                                              Employenumber = a.Employenumber,
                                              Fullname = $"{a.Firstname} {a.Lastname} {a.Middlename}",
                                              
                                          })
                                          .Skip((pagination.CurrentPage - 1) * pagination.Itemperpage)
                                          .Take(pagination.Itemperpage)
                                          .ToListAsync();
            }
            catch (Exception ex)
            {
                
            }
            return employeeDisplays;



        }

        [HttpPost("InsertEmployee")]
        public async Task<bool> InsertEmployee([FromBody] InsertEmployee employee)
        {
            bool IssuccessfullyAdded = false;
            try
            {
                Guid employeeid = Guid.NewGuid();
                Employee newemployee = new Employee()
                {
                    EmployeeId=employeeid,
                    Employenumber = "",
                    Firstname = employee.Firstname,
                    Lastname = employee.Lastname,
                    Middlename = employee.Middlename,
                    Sex = employee.Sex,
                    Age = employee.Age,
                    IsActive = true,
                    Datecreated= DateTime.Now,
                    Username = employee.Username
                };
                await _db.AddAsync(newemployee);
                await _db.SaveChangesAsync();
                newemployee = new Employee();
                newemployee = await _db.Employee.FirstOrDefaultAsync(x => x.EmployeeId == employeeid);
                if (newemployee != null)
                {
                    int count = await _db.Employee.CountAsync();
                    newemployee.Employenumber = $"Employee{count.ToString("D4")}";
                    _db.Update(newemployee);
                    await _db.SaveChangesAsync();
                    IssuccessfullyAdded = true;
                    return IssuccessfullyAdded;
                }
            }
            catch (Exception ex)
            {
                return IssuccessfullyAdded;
            }
            return IssuccessfullyAdded;
        }

        [HttpPost("RemoveEmployee")]
        public async Task<bool> RemoveEmployee([FromBody] EmployeeId employeeId)
        {
            bool Successfulyremoved = false;
            try
            {
                Employee employee = await _db.Employee.FirstOrDefaultAsync(x => x.EmployeeId == employeeId.ID);
                if (employee != null)
                {
                    employee.IsActive = false;
                    _db.Update(employee);
                    await _db.SaveChangesAsync();
                    Successfulyremoved = true;
                    return Successfulyremoved;  
                }


            }
            catch (Exception ex)
            {
                return Successfulyremoved;
            }
            return Successfulyremoved;
        }

        [HttpPost("UpdateEmployeeInformation")]
        public async Task<bool> UpdateEmployeeInformation([FromBody] UpdateEmployee employee)
        {
            bool successfulyupdated = false;
            try
            {
                Employee theemployee = await _db.Employee.FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);
                if (theemployee != null)
                {
                    theemployee.Firstname = employee.Firstname;
                    theemployee.Lastname = employee.Lastname;
                    theemployee.Middlename = employee.Middlename;
                    theemployee.Age = employee.Age;
                    theemployee.Sex = employee.Sex;
                    theemployee.Username = employee.Username;
                    _db.Update(theemployee);
                    await _db.SaveChangesAsync();
                    successfulyupdated = true;
                    return successfulyupdated;

                }
            }
            catch (Exception ex)
            {
                return successfulyupdated;
            }
            return successfulyupdated;
        }

        [HttpPost("GetEmployeeInformationById")]
        public async Task<EmployeeInformation> GetEmployeeInformationById([FromBody] EmployeeId employeeid)
        {
           EmployeeInformation employeeInformation = new EmployeeInformation();
            try
            {
                employeeInformation = await (from a in _db.Employee
                                             where a.EmployeeId == employeeid.ID
                                             select new EmployeeInformation()
                                             {
                                                 Firstname = a.Firstname,
                                                 Lastname = a.Lastname,
                                                 Middlename = a.Middlename,
                                                 Sex = a.Sex,
                                                 Age = a.Age,
                                                 Username = a.Username
                                             })
                                             .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

            }
            return employeeInformation;
        }


    }
}
