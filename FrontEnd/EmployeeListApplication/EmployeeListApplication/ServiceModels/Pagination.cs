using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeListApplication.ServiceModels
{
    public class Pagination
    {
        public string Searchvalue { get; set; }
        public int CurrentPage { get; set; }
        public int Itemperpage { get; set; }
    }
}
