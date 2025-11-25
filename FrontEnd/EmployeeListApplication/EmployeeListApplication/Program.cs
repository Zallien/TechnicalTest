using EmployeeListApplication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeListApplication
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        public static IServiceProvider serviceProvider { get; private set; }
        public static string BaseURL { get;  set; }

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            //Change this based on the Localhost or URL of API
            BaseURL = "http://localhost:5129";

            var Service = new ServiceCollection();

            //Register Interface
            Service.AddSingleton<IEmployeeServices, EmployeeServices>();

            //Register Forms
            Service.AddTransient<MainApplication>();
            Service.AddTransient<EmployeeModal>();

            serviceProvider = Service.BuildServiceProvider();


            ApplicationConfiguration.Initialize();
            Application.Run(serviceProvider.GetRequiredService<MainApplication>());
        }
    }
}