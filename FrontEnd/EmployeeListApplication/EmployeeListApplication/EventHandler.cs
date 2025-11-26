using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeListApplication
{
    public static class EventHandler
    {
        public static event Func<Task>? EmployeeNotifier;

        public static async Task InvokeEmployeeNotifier()
        {
            if (EmployeeNotifier != null)
            {
                await EmployeeNotifier.Invoke();
            }
        }
    }
}
