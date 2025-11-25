using EmployeeListApplication.ServiceModels;
using EmployeeListApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeListApplication
{
    public partial class EmployeeModal : Form
    {
        private readonly IEmployeeServices employeeServices;



        public EmployeeModal(IEmployeeServices employeeservice)
        {
            InitializeComponent();
            employeeServices = employeeservice;
        }

        #region Functions
        private void Closemodal()
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }
        //Add Employee
        private async Task AddEmployee()
        {
            InsertEmployee insertEmployee = new InsertEmployee()
            {
                Firstname = firstnametxt.Text,
                Lastname = lastnametxt.Text,
                Middlename = middlenametxt.Text,
                Sex = sexcombobox.Text,
                Age = int.Parse(agetxt.Text),
                Username = usernametxt.Text,

            };
            bool IsAdded = await employeeServices.AddEmployee(insertEmployee);
            if (!IsAdded)
            {
                MessageBox.Show("Unsuccessfully Added Error Occured", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Closemodal();

        }



        #endregion





        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Closemodal();
        }

        private void submitbutton_Click(object sender, EventArgs e)
        {
            AddEmployee();
        }
    }
}
