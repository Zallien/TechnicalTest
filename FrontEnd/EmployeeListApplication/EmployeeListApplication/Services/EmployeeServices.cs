using EmployeeListApplication.ServiceModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeListApplication.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        string baseurl = Program.BaseURL;

        public EmployeeServices()
        {

        }

        //Get Employee
        public async Task<List<EmployeeDisplay>> GetEmployee(Pagination pagination)
        {
            List<EmployeeDisplay> employeeDisplays = new List<EmployeeDisplay>();
            try
            {
                using (var httpclient = new HttpClient())
                {
                    string url = $"{baseurl}/api/Employee/GetEmployee";

                    var APIres = await httpclient.PostAsJsonAsync(url, pagination);
                    if (APIres.StatusCode == HttpStatusCode.OK)
                    {
                        var response = APIres.Content.ReadAsStringAsync();
                        employeeDisplays = JsonConvert.DeserializeObject<List<EmployeeDisplay>>(response.Result);
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return employeeDisplays;
        }
        //Add Employee
        public async Task<bool> AddEmployee(InsertEmployee employee)
        {
            bool SuccessfullyAdded = false;
            try
            {
                string url = $"{baseurl}/api/Employee/InsertEmployee";
                using (var httpclient = new HttpClient())
                {
                    var APIres = await httpclient.PostAsJsonAsync(url, employee);
                    if (APIres.StatusCode == HttpStatusCode.OK)
                    {
                        var apiresponse = APIres.Content.ReadAsStringAsync();
                        SuccessfullyAdded = JsonConvert.DeserializeObject<bool>(apiresponse.Result);
                        return SuccessfullyAdded;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return SuccessfullyAdded;
        }
        //Remove Employee
        public async Task<bool> RemoveEmployee(Guid employeeId)
        {
            bool SuccessFullyRemoved = false;
            try
            {
                string url = $"{baseurl}/api/Employee/RemoveEmployee";
                using (var httpclient = new HttpClient())
                {
                    var employeeid = new{ ID  =  employeeId };
                    var APIres = await httpclient.PostAsJsonAsync(url, employeeid);
                    if (APIres.StatusCode == HttpStatusCode.OK)
                    {
                        var apiresponse = APIres.Content.ReadAsStringAsync();
                        SuccessFullyRemoved = JsonConvert.DeserializeObject<bool>(apiresponse.Result);
                        return SuccessFullyRemoved;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return SuccessFullyRemoved;
        }
        //Update Employee
        public async Task<bool> UpdateEmployee(UpdateEmployee employee)
        {
            bool SuccessfullyUpdated = false;
            try
            {
                string url = $"{baseurl}/api/Employee/UpdateEmployeeInformation";
                using (var httpclient = new HttpClient())
                {
                    var APIres = await httpclient.PostAsJsonAsync(url, employee);
                    if (APIres.StatusCode == HttpStatusCode.OK)
                    {
                        var apiresponse = APIres.Content.ReadAsStringAsync();
                        SuccessfullyUpdated = JsonConvert.DeserializeObject<bool>(apiresponse.Result);
                        return SuccessfullyUpdated;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return SuccessfullyUpdated;
        }
        //Get EmployeeData By Id
        public async Task<EmployeeInformation> GetEmployeeInfoById(Guid employeeId)
        {
            EmployeeInformation employeeInformation = new EmployeeInformation();
            try
            {
                string url = $"{baseurl}/api/Employee/GetEmployeeInformationById";
                using (var httpclient = new HttpClient())
                {
                    var employeeid = new { ID = employeeId };
                    var APIres = await httpclient.PostAsJsonAsync(url, employeeid);
                    if (APIres.StatusCode == HttpStatusCode.OK)
                    {
                        var apiresponse = APIres.Content.ReadAsStringAsync();
                        employeeInformation = JsonConvert.DeserializeObject<EmployeeInformation>(apiresponse.Result);
                        return employeeInformation;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return employeeInformation;
        }





    }
}
