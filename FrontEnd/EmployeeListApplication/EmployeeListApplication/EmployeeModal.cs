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
        private ModalAction modalaction = new ModalAction();



        public EmployeeModal(IEmployeeServices employeeservice, ModalAction ModalAction)
        {
            InitializeComponent();
            employeeServices = employeeservice;
            modalaction = ModalAction;
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
            if (sexcombobox.Text != "Male" && sexcombobox.Text != "Female")
            {
                MessageBox.Show("Sex Must be Male and Female Only", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            await EventHandler.InvokeEmployeeNotifier();
            MessageBox.Show("Successfully Added", "Ssytem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Closemodal();

        }
        //Check Modal Action
        private async Task CheckModalAction()
        {
            if (modalaction.ModalActionName != "Add" && modalaction.EmployeeInfo != null)
            {
                firstnametxt.Text = modalaction.EmployeeInfo.Firstname;
                lastnametxt.Text = modalaction.EmployeeInfo.Lastname;
                middlenametxt.Text = modalaction.EmployeeInfo.Middlename;
                usernametxt.Text = modalaction.EmployeeInfo.Username;
                sexcombobox.Text = modalaction.EmployeeInfo.Sex;
                agetxt.Text = modalaction.EmployeeInfo.Age.ToString();

                submitbutton.Text = "Edit";
            }
        }
        //Update Information
        private async Task UpdateInformation()
        {
            if (sexcombobox.Text != "Male" && sexcombobox.Text != "Female")
            {
                MessageBox.Show("Sex Must be Male and Female Only", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateEmployee updateEmployee = new UpdateEmployee()
            {
                EmployeeId = modalaction.EmployeeId ?? Guid.Empty,
                Firstname = firstnametxt.Text,
                Lastname = lastnametxt.Text,
                Middlename = middlenametxt.Text,
                Sex = sexcombobox.Text,
                Age = int.Parse(agetxt.Text),
                Username = usernametxt.Text
            };
            bool successfullyupdated = await employeeServices.UpdateEmployee(updateEmployee);
            if (!successfullyupdated)
            {
                MessageBox.Show("Error Occured while Updating", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await EventHandler.InvokeEmployeeNotifier();
            MessageBox.Show("Successfully Updated", "Ssytem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Closemodal();
        }


        #endregion





        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Closemodal();
        }

        private void submitbutton_Click(object sender, EventArgs e)
        {
            if (modalaction.ModalActionName != "Add")
            {
                UpdateInformation();
                return;
            }
            AddEmployee();
        }

        private async void EmployeeModal_Load(object sender, EventArgs e)
        {
            await CheckModalAction();
        }

        private void agetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Block input
            }
        }
    }
}
